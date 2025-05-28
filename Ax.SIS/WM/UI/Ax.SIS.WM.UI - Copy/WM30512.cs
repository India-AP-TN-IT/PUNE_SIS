using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;

using C1.Win.C1FlexGrid;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 기초배고 비교 MES -> SAP
    /// </summary>
    public partial class WM30512 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM30512()
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

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();                
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "기준일자", "STD_DATE", "STD_DATE");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Part no", "PARTNO", "SAP_PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part name", "PARTNM", "PARTNM");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Unit", "UNIT", "SAP_UNIT");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "MES Qty", "MES_QTY","MES_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SAP Qty", "SAP_QTY","SAP_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "GAP Qty", "GAP_QTY", "GAP_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "Cost", "UCOST", "UCOST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "VENDCD", "VENDCD","VENDCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "VENDNM", "VENDNM", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "ESTI_CLASS", "ESTI_CLASS", "ESTI_CLASS");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "MES_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SAP_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "GAP_QTY");

                this.grd01.Cols["MES_QTY"].Format = _IntFormat;
                this.grd01.Cols["SAP_QTY"].Format = _IntFormat;
                this.grd01.Cols["GAP_QTY"].Format = _IntFormat;

                #endregion

                #region initilize codebox
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                #endregion

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                //평가클래스
                DataTable source = this.GetTypeCode("1F").Tables[0];
                source.DefaultView.RowFilter = "OBJECT_ID IN ('1F3000','1F3001','1F3100')";
                this.cbo01_ESTI_CLASS.DataBind(source.DefaultView.ToTable(), true);
                this.cbo01_ESTI_CLASS.SelectedItem = 0;
                
                #endregion
                
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);
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
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("DATE", this.dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));                    
                set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                set.Add("ESTI_CLASS", this.cbo01_ESTI_CLASS.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.Text);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM30512.INQUERY", set);
                this.grd01.MergedRanges.Clear();
                this.AfterInvokeServer();

                this.grd01.SetValue(source1.Tables[0]);
                this.ShowDataCount(source1);

                
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
