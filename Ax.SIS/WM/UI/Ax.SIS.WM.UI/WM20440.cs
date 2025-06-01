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


namespace Ax.SIS.WM.UI
{
    //=========================================================================
    // 수정 이력
    //=========================================================================
    // 2019.04.16 : 출력(레포트) 추가
    //=========================================================================

    using HE.Framework.Core.Report;//2019.04.16

    /// <summary>
    /// Warehouse 마스터
    /// </summary>
    public partial class WM20440 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const int IDX_CHECK_COLUMN = 1;//2019.04.16
        private const string _IntFormat = "###,###,###,###,##0";

        public WM20440()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "선택", "CHK", "CHK");//ADDED, 2019.04.16
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "법인", "CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "창고코드", "WHCD", "WHCD");
                this.grd01.Cols["WHCD"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "창고명", "WHNM", "WHNM");
                this.grd01.Cols["WHCD"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "사용여부", "USE_YN", "USE_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "WH TYPE", "WHTY", "WHTY");//ADDED, 2019.06.10
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "ROW", "LOC_ROWS", "ROW");//ADDED, 2019.07.16
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "COL", "LOC_COLS", "COL");//ADDED, 2019.07.16
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "STAGE", "LOC_STAGES", "STAGE");//ADDED, 2019.07.16
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "SLOT", "LOC_SLOT", "SLOT");//ADDED, 2019.07.16

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "LOC_ROWS");
                this.grd01.Cols["LOC_ROWS"].Format = _IntFormat;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "LOC_COLS");
                this.grd01.Cols["LOC_COLS"].Format = _IntFormat;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "LOC_STAGES");
                this.grd01.Cols["LOC_STAGES"].Format = _IntFormat;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "LOC_SLOT");
                this.grd01.Cols["LOC_SLOT"].Format = _IntFormat;
                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");

                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, true);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_USE_YN, "USE_YN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "1W", "WHTY", false);
                                
                this.cbo01_WHTY.DataBindCodeName("1W", true);

                this.cbo01_WHTY.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);
                this.cbo01_USE_YN.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]

        /// <summary>
        /// 출력버튼 이벤트 추가.
        /// 2016.04.16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            base.BtnPrint_Click(sender, e);

            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = @"RxRpt/WM20440";

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
            catch (FaultException<ExceptionDetail> except)
            {
                System.Diagnostics.Debug.WriteLine(except.ToString());
                MsgBox.Show(except.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                this.txt01_WHCD.Value = this.txt01_WHCD.GetValue().ToString().ToUpper();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("WHCD", this.txt01_WHCD.GetValue());
                set.Add("WHNM", this.txt01_WHNM.GetValue());
                set.Add("USE_YN", this.cbo01_USE_YN.GetValue());
                set.Add("WHTY", this.cbo01_WHTY.GetValue());

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20440.INQUERY", set, "OUT_CURSOR");
                
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.grd01.SetValue(0, "CHK", "0");//2016.04.16 reset the check-box in the column-header
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "WHCD", "WHNM", "USE_YN", "WHTY", "LOC_ROWS", "LOC_COLS", "LOC_STAGES","LOC_SLOT", "EMPNO");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["CORCD"] = this.UserInfo.CorporationCode;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["WHCD"] = Convert.ToString(rows["WHCD"]).ToUpper();
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20440.DATA_SAVE", source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 계측항목관리 정보가 저장되었습니다.");
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

        //protected override void  BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
        //            "CORCD", "BIZCD", "WHCD", "WHNM");
        //        foreach (DataRow rows in source.Tables[0].Rows)
        //        {
        //            rows["BIZCD"] = this.UserInfo.BusinessCode;
        //            rows["LANG_SET"] = this.UserInfo.Language;
        //        }

        //        if (!IsDeleteValid(source)) return;

        //        this.BeforeInvokeServer(true);

        //        _WSCOM.ExecuteNonQueryTx("APG_WM20440.DATA_REMOVE", source);

        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("선택하신 계측항목관리 정보가 삭제되었습니다");
        //        //삭제되었습니다.
        //        MsgCodeBox.Show("CD00-0072");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        #endregion

        #region [컨트롤 이벤트]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "USE_YN", "Y");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 전체선택 체크박스 선택시 해당 선택 값에 따라
        /// 모든 체크박스 업데이트
        /// 2019.04.16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
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
                    //MsgBox.Show("저장할 계측항목 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < source.Tables[0].Rows.Count; i++)
                {
                    string WHCD = this.grd01.GetValue(i, "WHCD").ToString().ToUpper();
                    string WHNM = this.grd01.GetValue(i, "WHNM").ToString();
                    string USE_YN = this.grd01.GetValue(i, "USE_YN").ToString();
                    string WHTY = this.grd01.GetValue(i, "WHTY").ToString();

                    if (this.GetByteCount(WHCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {창고코드}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[3].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(WHCD) > 10)
                    {
                        //MsgBox.Show(i + " 번째 행에 {창고코드}은 4byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i.ToString(), this.grd01.Cols[3].Caption.ToString(), "10");
                        return false;
                    }

                    if (!WHCD.StartsWith("W-"))
                    {
                        //MsgBox.Show(i + " {0} row - Prefix({1}) is mandatory.(ex:{2})");
                        MsgCodeBox.ShowFormat("XM00-0147", i.ToString(), "W-", "W-WH0001");
                        return false;
                    }

                    if (this.GetByteCount(WHTY) == 0)
                    {
                        MsgCodeBox.ShowFormat("XM00-0148");
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 계측항목 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        //private bool IsDeleteValid(DataSet source)
        //{
        //    try
        //    {
        //        if (source.Tables[0].Rows.Count == 0)
        //        {
        //            //MsgBox.Show("삭제할 계측항목 정보가 존재하지 않습니다.");
        //            //삭제할 데이터가 존재하지 않습니다.
        //            MsgCodeBox.Show("CD00-0041");
        //            return false;
        //        }

        //        //if (MsgBox.Show("선택하신 계측항목 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        //삭제하시겠습니까?
        //        if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //            return false;

        //        return true;
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //    }

        //    return false;
        //}
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
