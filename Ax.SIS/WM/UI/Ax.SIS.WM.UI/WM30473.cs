#region ▶ Description & History
/* 
 * 프로그램명 : [PD20472] 자재 출고 집계 및 상세조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// <b>자재창고 출고정보 집계 및 상세조회</b>
    /// - 작 성 자 : 
    /// - 작 성 일 :
    /// </summary>
    public partial class WM30473 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM30473()
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
                this.heDockingTab1.PanelWidth = 272;

                #region [그리드1]

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Date", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Work Date", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Work Time", "WORK_TIME");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "Resale Customer", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "Customer Name", "CUSTNM", "CUSTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Dom/Imp", "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "Lot No", "LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Resale Qty", "QTY", "QTY");

                this.grd01.Cols["QTY"].Format = _IntFormat;


                #endregion

                string strcorcd = this.UserInfo.CorporationCode;

                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cdx01_CUSTCD.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1(this.cdx01_CUSTCD);
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("Customer Code");// "업체 코드";
                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                this.cbo01_CORCD.SetReadOnly(true);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            this.Inquery();
        }

        #endregion

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
                this.txt01_PARTNO.Initialize();
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Inquery()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM30473.INQUERY", paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source);
                this.ShowDataCount(source);
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
