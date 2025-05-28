
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
    public partial class WM30515 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM30515()
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

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Date", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Unit", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Base Stock", "BASE_QTY", "BASE_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Actual Stock", "ACT_QTY", "ACT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Gap Qty", "GAP_QTY", "GAP_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Vendor Name", "VENDNM", "VENDNM");

                this.grd01.Cols["BASE_QTY"].Format = _IntFormat;
                this.grd01.Cols["ACT_QTY"].Format = _IntFormat;
                this.grd01.Cols["GAP_QTY"].Format = _IntFormat;
                #endregion

                #region [그리드2]
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                         
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Date", "STD_DATE", "STD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Location No", "LOCATION_NO", "LOCATION_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Unit", "UNIT", "UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Base Stock", "BASE_QTY", "BASE_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Actual Stock", "ACT_QTY", "ACT_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Gap Qty", "GAP_QTY", "GAP_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Vendor", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Vendor Name", "VENDNM", "VENDNM");
                         
                this.grd02.Cols["BASE_QTY"].Format = _IntFormat;
                this.grd02.Cols["ACT_QTY"].Format = _IntFormat;
                this.grd02.Cols["GAP_QTY"].Format = _IntFormat;
                #endregion

                string strcorcd = this.UserInfo.CorporationCode;

                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cbo01_CORCD.SetReadOnly(true);

                //this.cbo01_JOB_TYPE.SetValue("A10");
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte01_DATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

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
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0: this.Inquery_Summary(); break;
                    case 1: this.Inquery_Detail(); break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.txt01_PARTNO.Initialize();
                        this.dte01_DATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    case 1:
                        this.grd02.InitializeDataSource();
                        this.txt01_PARTNO.Initialize();
                        this.txt01_LOCNO.Initialize();
                        this.dte01_DATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.lbl01_LOCNO.Visible = false;
                        this.txt01_LOCNO.Visible = false;
                        break;
                    case 1:
                        this.lbl01_LOCNO.Visible = true;
                        this.txt01_LOCNO.Visible = true;
                        break;
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Inquery_Summary()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("DATE", this.dte01_DATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM30515.INQUERY_SUMMARY", paramSet);
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

        private void Inquery_Detail()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("DATE", this.dte01_DATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LOCNO", this.txt01_LOCNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM30515.INQUERY_DETAIL", paramSet);
                this.AfterInvokeServer();

                this.grd02.SetValue(source);
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
