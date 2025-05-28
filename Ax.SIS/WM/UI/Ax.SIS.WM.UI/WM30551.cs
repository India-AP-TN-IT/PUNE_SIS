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
    /// 자재 발주/납품/SCAN/SAP입고 현황
    /// </summary>
    public partial class WM30551 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM30551()
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

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.EnabledActionFlag = false;
                this.grd01.AllowFreezing = AllowFreezingEnum.Columns;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "VENDCD", "VENDCD", "VENDCD6");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "VENDNM", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "납기일자", "PO_DELI_DATE", "PO_DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "발주일자", "PO_DATE", "PO_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "발주번호", "PONO", "PONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "차종", "VINNM", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "평가클래스", "ESTI_CLASS", "ESTI_CLASS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Unit", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "적입량", "UNIT_PACK_QTY_SIM", "UNIT_PACK_QTY_SIM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "발주량", "PO_QTY", "PO_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "납품완료", "ELIKZ", "DELI_CMP_CHK");

                //scm
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "납품일자", "DELI_DATE", "DELIVERYDATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "납품차수", "DELI_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "납품수량", "DELI_QTY", "DELI_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "박스수량", "BOX_QTY_SCM", "BOX_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "납품서번호", "DELI_NOTE", "DELI_NOTE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "납품서유형", "DELI_TYPE", "DELI_TYPE");
                //wms             
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "입고일자", "RCV_DATE_WMS", "ARRIVE_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "입고수량", "RCV_QTY_WMS", "ARRIV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "박스수량", "BOX_QTY_WMS", "BOX_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "미입고량", "NOT_GRN_QTY_WMS", "NOT_GRN_QTY");
                //sap
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "입고일자", "RCV_DATE_SAP", "ARRIVE_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "입고수량", "GRN_QTY", "ARRIV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "합격수량", "OK_QTY", "OK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "미입고량", "NOT_GRN_QTY_SAP", "NOT_GRN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "입고구분", "RCV_DIV", "RCV_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "입고번호", "RCVNO", "ARRIVENO");


                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "저장위치", "STR_LOCNM", "STR_LOCNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "구매조직", "PURC_ORGNM", "PURC_ORGNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "구매오더유형", "PURC_PO_TYPENM", "PURC_PO_TYPENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "구매그룹", "PURC_GRPNM", "PURC_GRPNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "유/무상구분", "PAY_YN_DIV", "UMSON");



                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "UNIT_PACK_QTY_SIM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PO_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BOX_QTY_SCM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RCV_QTY_WMS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BOX_QTY_WMS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "NOT_GRN_QTY_WMS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "GRN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "NOT_GRN_QTY_SAP");


                this.grd01.Cols["UNIT_PACK_QTY_SIM"].Format = _IntFormat;
                this.grd01.Cols["PO_QTY"].Format = _IntFormat;
                this.grd01.Cols["DELI_CNT"].Format = _IntFormat;
                this.grd01.Cols["DELI_QTY"].Format = _IntFormat;
                this.grd01.Cols["BOX_QTY_SCM"].Format = _IntFormat;
                this.grd01.Cols["RCV_QTY_WMS"].Format = _IntFormat;
                this.grd01.Cols["BOX_QTY_WMS"].Format = _IntFormat;
                this.grd01.Cols["NOT_GRN_QTY_WMS"].Format = _IntFormat;
                this.grd01.Cols["GRN_QTY"].Format = _IntFormat;
                this.grd01.Cols["OK_QTY"].Format = _IntFormat;
                this.grd01.Cols["DEF_QTY"].Format = _IntFormat;
                this.grd01.Cols["NOT_GRN_QTY_SAP"].Format = _IntFormat;

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "VENDCD", "VENDCD");
                this.grd01.AddMerge(0, 1, "VENDNM", "VENDNM");
                this.grd01.AddMerge(0, 1, "PO_DELI_DATE", "PO_DELI_DATE");
                this.grd01.AddMerge(0, 1, "PO_DATE", "PO_DATE");
                this.grd01.AddMerge(0, 1, "PONO", "PONO");
                this.grd01.AddMerge(0, 1, "VINNM", "VINNM");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd01.AddMerge(0, 1, "ESTI_CLASS", "ESTI_CLASS");
                this.grd01.AddMerge(0, 1, "UNIT", "UNIT");
                this.grd01.AddMerge(0, 1, "UNIT_PACK_QTY_SIM", "UNIT_PACK_QTY_SIM");
                this.grd01.AddMerge(0, 1, "PO_QTY", "PO_QTY");
                this.grd01.AddMerge(0, 1, "ELIKZ", "ELIKZ");

                this.grd01.AddMerge(0, 0, "DELI_DATE", "DELI_TYPE");
                this.grd01.SetHeadTitle(0, 0, "DELI_DATE", "DELI_TYPE", this.GetLabel("SCM_DELI_INFO")); //SCM 납품정보

                this.grd01.AddMerge(0, 0, "RCV_DATE_WMS", "NOT_GRN_QTY_WMS");
                this.grd01.SetHeadTitle(0, 0, "RCV_DATE_WMS", "NOT_GRN_QTY_WMS", "WMS " + this.GetLabel("ARRIVE_INFO")); 

                this.grd01.AddMerge(0, 0, "RCV_DATE_SAP", "RCVNO");
                this.grd01.SetHeadTitle(0, 0, "RCV_DATE_SAP", "RCVNO", "SAP " + this.GetLabel("ARRIVE_INFO"));

                this.grd01.AddMerge(0, 1, "STR_LOCNM", "STR_LOCNM");
                this.grd01.AddMerge(0, 1, "PURC_ORGNM", "PURC_ORGNM");
                this.grd01.AddMerge(0, 1, "PURC_PO_TYPENM", "PURC_PO_TYPENM");
                this.grd01.AddMerge(0, 1, "PURC_GRPNM", "PURC_GRPNM");
                this.grd01.AddMerge(0, 1, "PAY_YN_DIV", "PAY_YN_DIV");
                

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
                this.cbo01_ESTI_CLASS.SelectedIndex = 0;

                 // CANCEL YN
                DataTable dt_cancel = this.GetDataSourceSchema("KEY", "VALUE").Tables[0];
                dt_cancel.Rows.Add("NORMAL", "NORMAL");
                dt_cancel.Rows.Add("CANCEL", "CANCEL");
                this.cbo01_CANCEL_YN.DataBind(dt_cancel, false);
                this.cbo01_CANCEL_YN.SelectedIndex = 0;

                
                #endregion
                
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_PO_DELI_DATE);
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
                set.Add("DATE_FROM", this.dte01_DATE_FROM.Value.ToString("yyyy-MM-dd"));
                set.Add("DATE_TO", this.dte01_DATE_TO.Value.ToString("yyyy-MM-dd"));
                set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                set.Add("ESTI_CLASS", this.cbo01_ESTI_CLASS.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.Text);
                set.Add("PONO", this.txt01_PONO.Text);
                set.Add("DELI_NOTE", this.txt01_DELI_NOTE.Text);
                set.Add("DELI_TYPE", (this.cbo01_CANCEL_YN.GetValue().ToString().Equals("NORMAL")?"":"X"));
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM30551.INQUERY", set);
                //this.grd01.MergedRanges.Clear();
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
