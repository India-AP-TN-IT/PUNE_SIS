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
    public partial class WM60100 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private bool m_ReadOnlyMode = false;
        public WM60100()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
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

                
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
               
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "S", "STATUS", "STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PO NO", "PONO", "PONO");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "PONO_SEQ", "PONO_SEQ", "PONO_SEQ");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 280, "VENDOR", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "VENDOR", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "PART NUMBER", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "PART DESCRIPTION", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "UNIT", "PO_UNIT", "PO_UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 65, "PO/QTY", "PO_QTY", "PO_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 65, "GR/QTY", "GR_QTY", "GR_QTY");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 65, "U/PRICE", "PO_UCOST", "PO_UCOST");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 90, "AMT", "PO_AMT", "PO_AMT");


                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "C/CODE", "KOSTL", "KOSTL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "C/CENTER", "KOSTL_NM", "KOSTL_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PO/DATE", "PO_DATE", "PO_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "D/DATE", "PO_DELI_DATE", "PO_DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "GR/DATE", "GR_DATE", "GR_DATE");


                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AllowSorting = AllowSortingEnum.None;

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PO NO", "PONO", "PONO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PO/SEQ", "PONO_SEQ", "PONO_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 105, "GR NO", "GRNO", "GRNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 45, "G/SEQ", "GR_SEQ", "GR_SEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 280, "VENDOR", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "P/NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "PART DESCRIPTION", "PARTNM", "PARTNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "HSN", "HSN", "HSN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "UNIT", "PO_UNIT", "PO_UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "QTY", "PO_QTY", "PO_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "GR/QTY", "GR_QTY", "GR_QTY");       
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "CUR", "COINCD", "COINCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "GR/DATE", "GR_DATE", "GR_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "REF/PERSON", "CONF_PERSON", "CONF_PERSON");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "VEND/INVOICE", "SUPP_INV_NO", "SUPP_INV_NO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "INV/DATE", "SUPP_INV_DATE", "SUPP_INV_DATE");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "SUPP_INV_DATE");
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private string GetDTType()
        {
            if(radioButton1.Checked)
            {
                return "1";
            }
            else if (radioButton2.Checked)
            {
                return "2";
            }
            else if(radioButton3.Checked)
            {
                return "3";
            }
            return "1";
        }
        #region [공통버튼]
        
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

        
        private void GetDET()
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

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private string GetGRNO(string corcd, string bizcd, string grdate)
        {
            
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("GR_DATE", grdate);
            DataTable dt = _WSCOM.ExecuteDataSet("APG_WM60100.GET_NEXT_GRNO", set, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["GRNO"].ToString();
            }
            return "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string grno = GetGRNO(cbo01_CORCD.GetValue().ToString(), cbo01_BIZCD.GetValue().ToString(), axDateEdit1.GetDateText());

                DataSet sourceIU = grd02.GetValue(AxFlexGrid.FActionType.Save,
                     "CORCD", "BIZCD","GRNO","GR_SEQ", "PONO", "PONO_SEQ"
                     ,"HSN"
                    , "GR_QTY"
                    , "GR_DATE"
                    , "CONF_PERSON", "SUPP_INV_NO","SUPP_INV_DATE","UPDATE_ID");
                foreach(DataRow dr in sourceIU.Tables[0].Rows)
                {
                    if (string.IsNullOrEmpty(dr["GRNO"].ToString()))
                    {
                        dr["GRNO"] = grno;
                    }
                    dr["CORCD"] = cbo01_CORCD.GetValue().ToString();
                    dr["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                    dr["UPDATE_ID"] = UserInfo.UserID;
                    dr["GR_DATE"] = axDateEdit1.GetDateText();
                }


                
                _WSCOM.ExecuteNonQueryTx("APG_WM60100.SAVE_DATA", sourceIU);

                GetDET();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            int row = this.grd02.SelectedRowIndex;

            if (row < 0)
            {
                MsgBox.Show("GR/NO is not selected!!", "Error");
                return;
            }


            string grno = grd02.GetData(row, "GRNO").ToString();
            PrintGRN(grno);
        }
        private void PrintGRN(string grno)
        {
            if (string.IsNullOrEmpty(grno))
            {
                MsgBox.Show("Wrong GR/NO!!", "Error");
                return;
            }
            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);

            report.ReportName = "RxRpt/WM60100_GRN";

            HEParameterSet param = new HEParameterSet();

            param.Add("CORCD", cbo01_CORCD.GetValue());
            param.Add("BIZCD", cbo01_BIZCD.GetValue());
            param.Add("GRNO", grno);
            DataSet ds = _WSCOM.ExecuteDataSet("APG_WM60100.PRINT_GRN", param);
           // ds.WriteXml(@"D:\A\R.XML", XmlWriteMode.WriteSchema);
            ds.Tables[0].TableName = "DATA";
            HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
            report.Sections.Add("MAIN", xmlSection);

            AxRexpertReportViewer.ShowReport(report);

            ds.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            if (row < 0)
            {
                MsgBox.Show("PO is not selected!!", "Error");
                return;
            }
            string pono = grd01.GetData(row, "PONO").ToString();
            grd02.InitializeDataSource();
            for(row=grd01.Rows.Fixed;row<grd01.Rows.Count;row++)
            {
                if(grd01.GetValue(row, "PONO").ToString() == pono)
                {
                    Row newrow=grd02.Rows.Add();
                    newrow["PONO"] = pono;

                    newrow["CORCD"] = grd01.GetValue(row, "CORCD").ToString();
                    newrow["BIZCD"] = grd01.GetValue(row, "BIZCD").ToString();
                    newrow["VENDCD"] = grd01.GetValue(row, "VENDCD").ToString();
                    newrow["PONO_SEQ"] = grd01.GetValue(row, "PONO_SEQ").ToString();
                    newrow["PARTNO"] = grd01.GetValue(row, "PARTNO").ToString();
                    
                    newrow["PARTNM"] = grd01.GetValue(row, "PARTNM").ToString();
                    newrow["GR_QTY"] = grd01.GetValue(row, "PO_QTY").ToString();
                    newrow["PO_QTY"] = grd01.GetValue(row, "PO_QTY").ToString();
                    newrow["PO_UNIT"] = grd01.GetValue(row, "PO_UNIT").ToString();
                }
            }
        }
        private bool Exist(string pono, string poseq)
        {
            for (int row = grd02.Rows.Fixed; row < grd02.Rows.Count; row++)
            {
                if (grd02.GetValue(row, "PONO").ToString() == pono && grd02.GetValue(row, "PONO_SEQ").ToString() == poseq)
                {
                    return true;
                }
            }
            return false;
        }
        private bool ExistVendor(string vendor)
        {
            if (grd02.Rows.Fixed == grd02.Rows.Count)
            {
                return true;
            }
            for (int row = grd02.Rows.Fixed; row < grd02.Rows.Count; row++)
            {
                if (grd02.GetValue(row, "VENDCD").ToString() == vendor)
                {
                    return true;
                }
                else if (string.IsNullOrEmpty(grd02.GetValue(row, "VENDCD").ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            if (row < 0)
            {
                MsgBox.Show("PO is not selected!!", "Error");
                return;
            }
            string pono = grd01.GetValue(row, "PONO").ToString();
            string poseq = grd01.GetValue(row, "PONO_SEQ").ToString();
            string vend = grd01.GetValue(row, "VENDCD").ToString();
            if (ExistVendor(vend))
            {
                if (Exist(pono, poseq) == false)
                {
                    Row newrow = grd02.Rows.Add();
                    newrow["PONO"] = pono;

                    newrow["CORCD"] = grd01.GetValue(row, "CORCD").ToString();

                    newrow["BIZCD"] = grd01.GetValue(row, "BIZCD").ToString();
                    newrow["VENDCD"] = grd01.GetValue(row, "VENDCD").ToString();
                    newrow["PONO_SEQ"] = grd01.GetValue(row, "PONO_SEQ").ToString();
                    newrow["PARTNO"] = grd01.GetValue(row, "PARTNO").ToString();

                    newrow["PARTNM"] = grd01.GetValue(row, "PARTNM").ToString();
                    newrow["GR_QTY"] = grd01.GetValue(row, "PO_QTY").ToString();
                    newrow["PO_QTY"] = grd01.GetValue(row, "PO_QTY").ToString();
                    newrow["PO_UNIT"] = grd01.GetValue(row, "PO_UNIT").ToString();
                }
            }
            else
            {
                MsgBox.Show("Wrong Vendor!!", "Error");
                return;
            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetDET();
        }

        


    }
}

