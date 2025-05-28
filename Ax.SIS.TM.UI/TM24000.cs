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


namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class TM24000 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public TM24000()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;


                cdx01_VENDCD.HEPopupHelper = new TM24005();
                cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                cdx01_VENDCD.CodeParameterName = "CD";
                cdx01_VENDCD.NameParameterName = "NM";
                cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx01_VENDCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);
                                                                
                #region [grd01] [Search Condition]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "선택", "CHK", "CHK");//ADDED, 2019.04.16
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Location", "LOCCD", "LOCCD");                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "Location Description", "LOCNM", "LOCNM");
                this.grd01.Cols["LOCNM"].Style.BackColor = Color.FromArgb(208, 253, 248);

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 140, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "Vendor", "VENDNM", "VENDNM");


                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "BEG DATE", "ST_DATE", "ST_DATE");
                this.grd01.Cols["ST_DATE"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "END DATE", "ED_DATE", "ED_DATE");
                this.grd01.Cols["ED_DATE"].Style.BackColor = Color.FromArgb(208, 253, 248);


                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "WEB_ADDR", "WEB_ADDR", "WEB_ADDR");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ED_DATE");
               


                #endregion              
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

               

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                if (axCheckBox1.Checked)
                {
                    set.Add("VENDCD", "MIP");
                }
                else
                {
                    set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                }
                set.Add("LOCCD", this.axTextBox1.GetValue());
                set.Add("LOCNM", this.axTextBox2.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM24000.INQUERY", set, "OUT_CURSOR");

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                      , "CORCD"
                                                      , "BIZCD"  
                                                      , "VENDCD"
                                                      , "LOCCD"
                                                      , "LOCNM"
                                                      , "ST_DATE"
                                                      , "ED_DATE"
                                                      , "UPDATE_ID"
                                                      
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "VENDCD"
                                                      , "LOCCD"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["LOCCD"] = Convert.ToString(rows["LOCCD"]).ToUpper();
                    }


                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM24000.DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM24000.DATA_REMOVE", sourceD);

                    this.AfterInvokeServer();
                }


                this.BtnQuery_Click(null, null);

                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
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
        
        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = @"RPT/TM24000";

                DataSet dsRpt = new DataSet();// ((DataSet)this.grd01.DataSource).Copy();
                DataTable dtGrd01 = (DataTable)this.grd01.DataSource;

                DataTable dtRpt = new DataTable("DATA");
                dtRpt = dtGrd01.Clone();

                foreach (DataRow row in dtGrd01.Select())
                {
                    string s_check = row["CHK"].ToString().Trim().ToUpper();
                    if (s_check.Equals("1") || s_check.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dtRpt.ImportRow(row);
                    }
                }

                if (dtRpt.Rows.Count == 0) return;

                dsRpt.Tables.Add(dtRpt);

                // Main section(메인리포트 파라미터 셋)
                HERexSection main_section = new HERexSection();
                main_section.ReportParameter.Add("RPT_TITLE", "The Contents of WareHouse");
                main_section.ReportParameter.Add("EMP_NO", this.UserInfo.EmpNo);
                main_section.ReportParameter.Add("EMP_NAME", this.UserInfo.UserName);
                report.Sections.Add("MAIN", main_section);

                HERexSection xml_section = new HERexSection(dsRpt, new HEParameterSet());
                report.Sections.Add("XML1", xml_section);//레포트파일의 커넥션이름과동일해야함.
                AxRexpertReportViewer.ShowReport(report);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [컨트롤 이벤트]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", cbo01_CORCD.GetValue());
                    this.grd01.SetValue(i, "BIZCD", cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(i, "UPDATE_ID", this.UserInfo.UserID);
                    if (axCheckBox1.Checked)
                    {
                        this.grd01.SetValue(i, "VENDCD", "MIP");
                        this.grd01.SetValue(i, "VENDNM", "MIP-Seoyon");
                    }
                    else
                    {
                        this.grd01.SetValue(i, "VENDCD", cdx01_VENDCD.GetValue());
                        this.grd01.SetValue(i, "VENDNM", cdx01_VENDCD.GetText());
                    }
                    this.grd01.SetValue(i, "ST_DATE", DateTime.Now.ToShortDateString());
                    this.grd01.SetValue(i, "ED_DATE", Convert.ToDateTime("2099-12-31").ToShortDateString());
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine(this.grd01.MouseCol.ToString());
            if (this.grd01.MouseCol == IDX_CHECK_COLUMN)
            {
                if (this.grd01.MouseRow == 0)
                {
                    string s_value = this.grd01.GetValue(0, "CHK").ToString();
                    for (int j_cnt = this.grd01.Rows.Fixed; j_cnt < this.grd01.Rows.Count; j_cnt++)
                    {
                        this.grd01.SetValue(j_cnt, "CHK", s_value == "Y" ? "1" : "0");
                    }
                }
                else
                {
                    //C1.Win.C1FlexGrid.CheckEnum e_all_check = this.grd01.GetCellCheck(0, IDX_CHECK_COLUMN);
                    //C1.Win.C1FlexGrid.CheckEnum e_sin_check = this.grd01.GetCellCheck(this.grd01.MouseRow, IDX_CHECK_COLUMN);
                    string s_all_check = this.grd01.GetValue(0, "CHK").ToString();
                    string s_single = this.grd01.GetValue(this.grd01.MouseRow, "CHK").ToString();
                    if (s_single != "Y" && s_all_check == "Y") this.grd01.SetValue(0, "CHK", "0");
                }
            }
        }
        #endregion


        private void txt01_Query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnQuery_Click(null, null);
            }
        }

        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            string vendor = cdx01_VENDCD.GetValue().ToString();
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            if(axCheckBox1.Checked)
            {
                vendor = "MIP";
            }
            if (string.IsNullOrEmpty(vendor))
            {
                args.Cancel = true;
                MsgBox.Show("Vendor is mandatory for input!!");
                return;
            }
            else if(string.IsNullOrEmpty(bizcd))
            {
                args.Cancel = true;
                MsgBox.Show("Business Code is mandatory for input!!");
                return;
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdx01_VENDCD.HEPopupHelper = new TM24005();
            cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
            cdx01_VENDCD.CodeParameterName = "CD";
            cdx01_VENDCD.NameParameterName = "NM";
            cdx01_VENDCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            cdx01_VENDCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);
        }

        private void axCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(axCheckBox1.Checked)
            {
                cdx01_VENDCD.Visible = false;
            }
            else
            {
                cdx01_VENDCD.Visible = true;
            }
        }


    }
}
