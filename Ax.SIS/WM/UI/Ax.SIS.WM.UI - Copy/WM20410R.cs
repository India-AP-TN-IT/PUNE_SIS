using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using System.Diagnostics;
using C1.Win.C1FlexGrid;
using System.Data.OleDb;
using System.Text;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class WM20410R : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
      
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public WM20410R()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_CORCD.DataBind_CORCD();
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                #region [그리드1]
                
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "MODEL", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Description", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "VENDOR", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 55, "UNIT", "UOM", "UOM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "USAGE", "USG", "USG");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "OPT", "OPT_RATE", "OPT_RATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "L/TIME(D)", "DEL_LEAD_TIME_DAYS", "DEL_LEAD_TIME_DAYS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "R/AVG", "DAY_AVG_USAGE", "DAY_AVG_USAGE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "STOCK", "STOCK_QTY", "STOCK_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "MIN", "MIN_STOCK_QTY", "MIN_STOCK_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "MAX", "MAX_STOCK_QTY", "MAX_STOCK_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "S/QTY", "QTY_TROLLEY_IN", "QTY_TROLLEY_IN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "L/CAPA", "LOC_CAPA", "LOC_CAPA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "STATUS", "STATUS", "STATUS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L,120, "REMARK", "REMARK", "REMARK");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 180, "VENDOR", "UPDATE_ID", "UPDATE_ID");

     


                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private string GetPRDT_DIV()
        {
            if(radioButton1.Checked)
            {
                return "A0A";
            }
            else if (radioButton1.Checked)
            {
                return "A0S";
            }
            return "A0M";
        }
        #region [공통버튼]
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("STD_DATE", dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));
                set.Add("PARTNO", Txt_PartNo.Text);
                set.Add("PRDT_DIV", GetPRDT_DIV());

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("APG_WM20410.INQUERY", set, "OUT_CURSOR");

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
        #endregion



    }
}
