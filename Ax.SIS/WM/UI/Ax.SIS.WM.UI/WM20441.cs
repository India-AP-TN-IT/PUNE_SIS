using System;
using System.Data;
using System.ServiceModel;
using HE.Framework.Core;
using System.Drawing;
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
    /// Area 마스터
    /// </summary>
    public partial class WM20441 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private AxComboList grd_PRDT_DIVCD;

        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public WM20441()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
            this.grd_PRDT_DIVCD = new AxComboList();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                HEParameterSet paramSet_WHCD_UNIT = new HEParameterSet();
                paramSet_WHCD_UNIT.Add("CORCD", _CORCD);
                paramSet_WHCD_UNIT.Add("BIZCD", _BIZCD);
                paramSet_WHCD_UNIT.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_WHCD_UNIT = _WSCOM.ExecuteDataSet("APG_WM20441.INQUERY_WHCD_GROUP", paramSet_WHCD_UNIT);
                DataSet combo_source_WHCD_UNIT = _WSCOM.ExecuteDataSet("APG_WM20441.INQUERY_WHCD_GROUP", paramSet_WHCD_UNIT, "OUT_CURSOR");

                //DataTable source1 = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_LINE_LIST", set, "OUT_CURSOR").Tables[0];

                this.cbo01_WHCD.DataBind(combo_source_WHCD_UNIT.Tables[0]); 
               
                #region [ grd01 ]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "선택", "CHK", "CHK");//ADDED, 2019.04.16
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Area 코드", "AREACD", "AREACD");
                this.grd01.Cols["AREACD"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "Area 명", "AREANM", "AREANM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "창고코드", "WHCD", "WHCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "사용여부", "USE_YN", "USE_YN");

                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_WHCD_UNIT.Tables[0], "WHCD", false);
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_WHCD_UNIT.Tables[0], "WHCD");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16

                //#region

                //HEParameterSet set = new HEParameterSet();
                //set.Add("CORCD", this.UserInfo.CorporationCode);
                //set.Add("BIZCD", this.UserInfo.BusinessCode);
                //set.Add("LANG_SET", this.UserInfo.Language);

                //DataTable DtSource = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_INSPEC_DIVCD", set).Tables[0];
                //#endregion
                //this.cbo01_USE_YN.DataBind(DtSource);
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, DtSource, "USE_YN");  

                #endregion

                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");

                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, true);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                
                this.cbo01_WHCD.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);
                this.cbo01_USE_YN.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);

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

                this.txt01_AREACD.Value = this.txt01_AREACD.GetValue().ToString().ToUpper();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("WHCD", this.cbo01_WHCD.GetValue());
                set.Add("AREACD", this.txt01_AREACD.GetValue());
                set.Add("AREANM", this.txt01_AREANM.GetValue());
                set.Add("USE_YN", this.cbo01_USE_YN.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.ExecuteDataSet("APG_WM20441.INQUERY", set, "OUT_CURSOR");
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20441.INQUERY", set);

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.grd01.SetValue(0, "CHK", "0");//2016.04.16 reset the check-box in the column-header

                //WriteReportXML(source);//2016.04.16 임시 XML 파일 생성.
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
                    "CORCD", "AREACD", "AREANM", "WHCD", "USE_YN", "EMPNO", "BIZCD", "LANG_SET");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                    rows["LANG_SET"] = this.UserInfo.Language;

                    rows["AREACD"] = Convert.ToString(rows["AREACD"]).ToUpper();
                    rows["WHCD"] = Convert.ToString(rows["WHCD"]).ToUpper();
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20441.DATA_SAVE", source);

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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = @"RxRpt/WM20441";

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


        //protected override void  BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
        //            "CORCD", "AREACD", "AREANM", "BIZCD", "LANG_SET");
        //        foreach (DataRow rows in source.Tables[0].Rows)
        //        {
        //            rows["BIZCD"] = this.UserInfo.BusinessCode;
        //            rows["LANG_SET"] = this.UserInfo.Language;
        //        }

        //        if (!IsDeleteValid(source)) return;

        //        this.BeforeInvokeServer(true);

        //        _WSCOM.ExecuteNonQueryTx("APG_WM20441.DATA_REMOVE", source);

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

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

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

        #region [사용자 정의 메서드]

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                //if (e.Row >= this.grd01.Rows.Fixed)
                //{
                //    if (e.Col == this.grd01.Cols["WHNM"].Index)
                //    {
                //        string INSPEC_DIVNM = this.grd01.GetValue(e.Row, "WHNM").ToString();
                //        this.grd01.SetValue(e.Row, "WHCD", INSPEC_DIVNM);
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Xml 파일 생성하는 임시 함수.
        /// 2019.04.16
        /// </summary>
        /// <param name="pDataSet"></param>
        private void WriteReportXML(DataSet pDataSet)
        {
            string s_path = string.Format(@"D:\20.SEOYON\ReportXml\WM20441.xml");
            pDataSet.Tables[0].TableName = "DATA";
            pDataSet.Tables[0].WriteXml(s_path, XmlWriteMode.WriteSchema);
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

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string AREACD = this.grd01.GetValue(i, "AREACD").ToString().ToUpper();
                    string AREANM = this.grd01.GetValue(i, "AREANM").ToString();
                    string WHCD = this.grd01.GetValue(i, "WHCD").ToString().ToUpper();
                    string USE_YN = this.grd01.GetValue(i, "USE_YN").ToString();

                    if (this.GetByteCount(AREACD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {Area 코드}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[3].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(AREACD) > 20)
                    {
                        //MsgBox.Show(i + " 번째 행에 {Area 코드}은 4byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i.ToString(), this.grd01.Cols[3].Caption.ToString(), "20");
                        return false;
                    }

                    if (this.GetByteCount(WHCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {창고코드}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[5].Caption.ToString());
                        return false;
                    }

                    if (!AREACD.StartsWith("A-"))
                    {
                        //MsgBox.Show(i + " {0} row - Prefix({1}) is mandatory.(ex:{2})");
                        MsgCodeBox.ShowFormat("XM00-0147", i.ToString(), "A-", "A-AR0001");
                        return false;
                    }

                    if (!WHCD.StartsWith("W-"))
                    {
                        //MsgBox.Show(i + " {0} row - Prefix({1}) is mandatory.(ex:{2})");
                        MsgCodeBox.ShowFormat("XM00-0147", i.ToString(), "W-", "W-WH0001");
                        return false;
                    }

                    //if (this.GetByteCount(WHNM) > 10)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 {계측항목코드}는 {10}byte 이상 입력할 수 없습니다.");
                    //    MsgCodeBox.ShowFormat("XM00-0045", i.ToString(), this.grd01.Cols[4].Caption.ToString(), "10");
                    //    return false;
                    //}

                    //if (this.GetByteCount(USE_YN) == 0)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 {계측항목 명칭}이 입력되지 않았습니다.");
                    //    MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[5].Caption.ToString());
                    //    return false;
                    //}

                    //if (this.GetByteCount(USE_YN) > 50)
                    //{
                    //    //MsgBox.Show(i + " 번째 행에 {계측항목 명칭}은 {50}byte 이상 입력할 수 없습니다.");
                    //    MsgCodeBox.ShowFormat("XM00-0045", i.ToString(), this.grd01.Cols[5].Caption.ToString(), "50");
                    //    return false;
                    //}
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 계측항목 정보가 존재하지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 계측항목 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //삭제하시겠습니까?
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