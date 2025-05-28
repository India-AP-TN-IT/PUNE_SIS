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
    public partial class TM24300 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public TM24300()
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
                cdx01_VENDCD.PopupTitle = "Trolley Type";
                cdx01_VENDCD.CodeParameterName = "CD";
                cdx01_VENDCD.NameParameterName = "NM";
                cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx01_VENDCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);
                cdx01_VENDCD.HEUserParameterSetValue("DIV", "01");
                                                                
                #region [grd01] [Search Condition]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "CHK", "CHK", "CHK");//ADDED, 2019.04.16
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Asset No", "ASNO", "ASNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "Asset Description", "ASNM", "ASNM");
                this.grd01.Cols["ASNM"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "Specification", "SPEC", "SPEC");
                this.grd01.Cols["SPEC"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "SAP Asset No", "SAP_ASNO", "SAP_ASNO");
                this.grd01.Cols["SAP_ASNO"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "A/DATE", "ACQ_DATE", "ACQ_DATE");
                this.grd01.Cols["ACQ_DATE"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "C/Center", "DEPT", "DEPT");
                this.grd01.Cols["DEPT"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "C/Center", "DEPT", "DEPT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "C/Center", "DEPT", "DEPT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "C/Center", "DEPT", "DEPT");



                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "DIV", "DIV", "DIV");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "TYCD", "TYCD", "TYCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "WEB_ADDR", "WEB_ADDR", "WEB_ADDR");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ACQ_DATE");


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
                set.Add("DIV", "01");
                set.Add("TYCD", this.cdx01_VENDCD.GetValue());
                set.Add("ASNO", this.axTextBox1.GetValue());
                set.Add("ASNM", this.axTextBox2.GetValue());
                set.Add("SPEC", "");
                set.Add("SAP_ASNO", "");
                set.Add("ACQ_DATE", "");
                set.Add("DEPT", "");
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM24300.INQUERY", set, "OUT_CURSOR");

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
                                                      , "DIV"
                                                      , "TYCD"
                                                      , "ASNO"
                                                      , "ASNM"
                                                      , "SPEC"
                                                      , "SAP_ASNO"
                                                      , "ACQ_DATE"
                                                      , "DEPT"
                                                      , "UPDATE_ID"
                                                      
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "DIV"
                                                      , "TYCD"
                                                      , "ASNO"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    
                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM24300.DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM24300.DATA_REMOVE", sourceD);

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
                report.ReportName = @"RPT/TM24300";

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
                    this.grd01.SetValue(i, "TYCD", cdx01_VENDCD.GetValue());
                    this.grd01.SetValue(i, "DIV", "01");
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
            if (string.IsNullOrEmpty(vendor))
            {
                args.Cancel = true;
                MsgBox.Show("Trolley Type is mandatory for input!!");
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
            cdx01_VENDCD.PopupTitle = "Trolley Type";
            cdx01_VENDCD.CodeParameterName = "CD";
            cdx01_VENDCD.NameParameterName = "NM";
            cdx01_VENDCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            cdx01_VENDCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);
            cdx01_VENDCD.HEUserParameterSetValue("DIV", "01");
        }


    }
}
