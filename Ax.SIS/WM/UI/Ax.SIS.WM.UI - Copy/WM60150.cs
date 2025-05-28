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
    public partial class WM60150 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        public WM60150()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                panel1.Visible = false;
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                this.cdx01_VENDCD.PopupTitle = lbl01_VENDCD.Text;
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_CORCD.DataBind_CORCD();
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
               
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "S", "STATUS", "STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PO NO", "PONO", "PONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "VENDOR", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "AMT", "PO_AMT", "PO_AMT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "C/CODE", "KOSTL", "KOSTL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "C/CENTER", "KOSTL_NM", "KOSTL_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PO/DATE", "PO_DATE", "PO_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "D/DATE", "PO_DELI_DATE", "PO_DELI_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CON_TERM", "CON_TERM", "CON_TERM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "DEL_TERM", "DEL_TERM", "DEL_TERM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "PAY_TERM", "PAY_TERM", "PAY_TERM");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PO NO", "PONO", "PONO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PO/SEQ", "PONO_SEQ", "PONO_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "P/NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "PART DESCRIPTION", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "UNIT", "PO_UNIT", "PO_UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "QTY", "PO_QTY", "PO_QTY");                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "PRICE", "PO_UCOST", "PO_UCOST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "PO/AMT", "PO_AMT", "PO_AMT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "GR/QTY", "GR_QTY", "GR_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "GR/AMT", "GR_AMT", "GR_AMT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CUR", "COINCD", "COINCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "GR/DATE", "GR_DATE", "GR_DATE");


                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private string GetDTType()
        {
            
            return "1";
        }
        #region [공통버튼]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            base.BtnSave_Click(sender, e);
            try
            {
                int row = this.grd01.SelectedRowIndex;

                if (row < 0)
                {
                    return;
                }

                string pono = this.grd01.GetValue(row, "PONO").ToString();

                HEParameterSet set = new HEParameterSet();
                
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("PONO", pono);
                set.Add("PAY_TERM", Txt_PAY_TERM.GetValue());
                set.Add("DEL_TERM", txt_DEL_TERM.GetValue());
                set.Add("CON_TERM", txt_CON_TERM.GetValue());
                set.Add("UPDATE_ID", UserInfo.UserID);
                _WSCOM.ExecuteNonQueryTx("APG_WM60100.SAVE_PO_DET", set);
            }
            catch(Exception eLog)
            {

            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DT_TYPE", GetDTType());
                set.Add("ST_DATE", dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));
                set.Add("ED_DATE", dtp01_ED_DATE.Value.ToString("yyyy-MM-dd"));
                set.Add("PONO", Txt_PONO.Text);
                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                set.Add("CCENTER", textBox1.Text);
                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("APG_WM60100.INQUERY", set, "OUT_CURSOR");

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
        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                



                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다..
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }


                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        #endregion

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                if (row < 0)
                {
                    return;
                }

                string pono = this.grd01.GetValue(row, "PONO").ToString();

                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("PONO", pono);
               

                source = _WSCOM.ExecuteDataSet("APG_WM60100.INQUERY_DET", set, "OUT_CURSOR");

                this.grd02.SetValue(source.Tables[0]);
                if (source.Tables[0].Rows.Count > 0)
                {
                    txt_CON_TERM.SetValue(source.Tables[0].Rows[0]["CON_TERM"].ToString());
                    Txt_PAY_TERM.SetValue(source.Tables[0].Rows[0]["PAY_TERM"].ToString());
                    txt_DEL_TERM.SetValue(source.Tables[0].Rows[0]["DEL_TERM"].ToString());
                    panel1.Visible = true;
                }
                else
                {
                    txt_CON_TERM.SetValue("");
                    Txt_PAY_TERM.SetValue("");
                    txt_DEL_TERM.SetValue("");
                    panel1.Visible = false;
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void PrintPO(string po)
        {
            
            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
           
            report.ReportName = "RxRpt/WM60150_PO";

            HEParameterSet param = new HEParameterSet();

            param.Add("CORCD", cbo01_CORCD.GetValue());
            param.Add("BIZCD", cbo01_BIZCD.GetValue());
            param.Add("PONO", po);
            DataSet ds = _WSCOM.ExecuteDataSet("APG_WM60100.PRINT_PO", param);
            //ds.WriteXml(@"D:\A\R.XML", XmlWriteMode.WriteSchema);
            ds.Tables[0].TableName = "DATA";
            HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
            report.Sections.Add("MAIN", xmlSection);

            AxRexpertReportViewer.ShowReport(report);

            ds.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = grd01.Row;
            if (row < this.grd01.Rows.Fixed) return;
            string po = grd01.GetValue(row, "PONO").ToString();
            BtnSave_Click(null, null);
            PrintPO(po);
        }
       


        


    }
}
