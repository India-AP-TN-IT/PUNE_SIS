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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class WM20443 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public WM20443()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;
                                                                
                #region [grd01] [Search Condition]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "선택", "CHK", "CHK");//ADDED, 2019.04.16
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "Location", "LOCNO", "Location");
                this.grd01.Cols["LOCNO"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "LOC NM", "LOCNM", "LOC NM");
                this.grd01.Cols["LOCNM"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "LOAD QTY", "LOAD_QTY", "LOAD QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "BEG DATE", "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "END DATE", "END_DATE", "END_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "PLANT", "PLANT_DIV", "PLANT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "GOODS DIV", "PRDT_DIV", "GOODS_DIV");
                this.grd01.Cols["PRDT_DIV"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Delivery Able", "DELIVERY_ABLE", "DELIVERY_ABLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "SLOT YN", "SLOT_YN", "SLOT_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "WH CODE", "WHCD", "WHCD");//ADDED, 2019.06.10

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "LINECD"           , "LINECD", "LINECD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "STR_LOC"          , "STR_LOC", "STR_LOC");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "USER_ID", "USER_ID", "USER_ID");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "LOAD_QTY");
                this.grd01.Cols["LOAD_QTY"].Format = _IntFormat;

                DataTable combo_source_PRDT = new DataTable();
                combo_source_PRDT.Columns.Add("CODE");
                combo_source_PRDT.Columns.Add("NAME");
                combo_source_PRDT.Rows.Add("M", "Material");
                combo_source_PRDT.Rows.Add("S", "Semi-Assy");
                combo_source_PRDT.Rows.Add("A", "ASSY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_PRDT, "PRDT_DIV");

                this.cbo01_PRDT.DataBind(combo_source_PRDT, true);
                this.cbo01_PRDT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source_SLOT_YN = new DataTable();
                combo_source_SLOT_YN.Columns.Add("CODE");
                combo_source_SLOT_YN.Columns.Add("NAME");
                combo_source_SLOT_YN.Rows.Add("Y", "YES");
                combo_source_SLOT_YN.Rows.Add("N", "NO");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_SLOT_YN, "DELIVERY_ABLE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_SLOT_YN, "SLOT_YN");

                this.cbo01_SLOT_YN.DataBind(combo_source_SLOT_YN, true);
                this.cbo01_SLOT_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_DELIVERY_ABLE.DataBind(combo_source_SLOT_YN, true);
                this.cbo01_DELIVERY_ABLE.DropDownStyle = ComboBoxStyle.DropDownList;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                DataTable dtWHCD = _WSCOM.ExecuteDataSet("APG_WM20443.INQUIRY_COMBO_WHCD", set1, "OUT_CURSOR").Tables[0];

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtWHCD, "WHCD");
                
                this.cbo01_WHCD.DataBind(dtWHCD, true);
                this.cbo01_WHCD.DropDownStyle = ComboBoxStyle.DropDownList;


                DataTable combo_source_PRT_SIZE = new DataTable();
                combo_source_PRT_SIZE.Columns.Add("CODE");
                combo_source_PRT_SIZE.Columns.Add("NAME");
                combo_source_PRT_SIZE.Rows.Add("", "Normal");
                combo_source_PRT_SIZE.Rows.Add("S", "Small");
                this.cbo01_PRT_SIZE.DataBind(combo_source_PRT_SIZE, false);
                this.cbo01_PRT_SIZE.DropDownStyle = ComboBoxStyle.DropDownList;
                #endregion              
                
                this.cbo01_WHCD.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);
                this.cbo01_PRDT.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);
                this.cbo01_SLOT_YN.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);
                this.cbo01_DELIVERY_ABLE.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);

                this.BtnQuery_Click(null, null);
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

                this.txt01_LOCATION_NO.Value = this.txt01_LOCATION_NO.GetValue().ToString().ToUpper();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("WHCD", this.cbo01_WHCD.GetValue());
                set.Add("PRDT", this.cbo01_PRDT.GetValue());
                set.Add("LOCNO", this.txt01_LOCATION_NO.GetValue());
                set.Add("SLOT_YN", this.cbo01_SLOT_YN.GetValue());
                set.Add("DELIVERY_ABLE", this.cbo01_DELIVERY_ABLE.GetValue());

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20443.INQUERY", set, "OUT_CURSOR");

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
                                                      , "LOCNO"
                                                      , "LOCNM"
                                                      , "LOAD_QTY"
                                                      , "BEG_DATE"
                                                      , "END_DATE"
                                                      , "PLANT_DIV"
                                                      , "PRDT_DIV"
                                                      , "SLOT_YN"
                                                      , "DELIVERY_ABLE"
                                                      , "LINECD"
                                                      , "STR_LOC"
                                                      , "USER_ID"
                                                      , "WHCD"
                                                      , "CORCD"
                                                      , "BIZCD"
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "LOCNO"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["LOCNO"] = Convert.ToString(rows["LOCNO"]).ToUpper();
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20443.DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {
                    if (!IsDeleteValid(sourceD)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20443.DATA_REMOVE", sourceD);

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
                report.ReportName = @"RxRpt/WM20443"+cbo01_PRT_SIZE.GetValue().ToString();

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
                    this.grd01.SetValue(i, "SLOT_YN", "N");
                    this.grd01.SetValue(i, "DELIVERY_ABLE", "N");

                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "BIZCD", this.UserInfo.BusinessCode);
                    this.grd01.SetValue(i, "USER_ID", this.UserInfo.UserID);
                    this.grd01.SetValue(i, "BEG_DATE", DateTime.Now.ToShortDateString());
                    this.grd01.SetValue(i, "END_DATE", Convert.ToDateTime("2099-12-31").ToShortDateString());
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

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string LOCNO = source.Tables[0].Rows[i]["LOCNO"].ToString().ToUpper();

                    if (this.GetByteCount(LOCNO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {LOC_NO}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[2].Caption.ToString());
                        return false;
                    }

                    string PRDT_DIV = source.Tables[0].Rows[i]["PRDT_DIV"].ToString().ToUpper(); ;// this.grd01.GetValue(i, "PRDT_DIV").ToString().ToUpper();

                    if (this.GetByteCount(PRDT_DIV) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {LOC_NO}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[8].Caption.ToString());
                        return false;
                    }

                    if (!LOCNO.StartsWith("L-"))
                    {
                        //MsgBox.Show(i + " {0} row - Prefix({1}) is mandatory.(ex:{2})");
                        MsgCodeBox.ShowFormat("XM00-0147", i.ToString(), "L-", "L-LC0001");
                        return false;
                    }

                    string WHCD = source.Tables[0].Rows[i]["WHCD"].ToString().ToUpper(); //this.grd01.GetValue(i, "WHCD").ToString().ToUpper();
                    if (this.GetByteCount(WHCD) == 0)
                    {
                        MsgCodeBox.ShowFormat("XM00-0148", MessageBoxButtons.OK);
                        return false;
                    }

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

        private void txt01_Query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnQuery_Click(null, null);
            }
        }

    }
}
