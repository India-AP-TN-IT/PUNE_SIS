using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;

using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Diagnostics;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 초기화 
    /// </summary>
    public partial class WM20521 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private string pakageName = "APG_WM20521";
        private const int IDX_CHECK_COLUMN = 1;//2019.04.16
        
        public WM20521()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region initilize combo
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                this.cdx01_VENDCD.PopupTitle = lbl01_VENDCD.Text;
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cbo01_PURC_PO_TYPE.DataBind("1K", true);
                this.cbo01_PURC_ORG.DataBind("1A", false);

                this.cdx01_STR_LOC.HEPopupHelper = new CM30040P1(); //new PM20015P1();
                this.cdx01_STR_LOC.PopupTitle = this.GetLabel("STR_LOC");
                this.cdx01_STR_LOC.CodeParameterName = "STR_LOC";
                this.cdx01_STR_LOC.NameParameterName = "STR_LOCNM";
                this.cdx01_STR_LOC.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_STR_LOC.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                // tag size
                DataTable combo_source_PRINT_SIZE = new DataTable();
                combo_source_PRINT_SIZE.Columns.Add("CODE");
                combo_source_PRINT_SIZE.Columns.Add("NAME");
                combo_source_PRINT_SIZE.Rows.Add("", "Normal");
                combo_source_PRINT_SIZE.Rows.Add("S", "Small");
                this.cbo01_PRINT_SIZE.DataBind(combo_source_PRINT_SIZE, false);
                this.cbo01_PRINT_SIZE.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source_PRINT_TYPE = new DataTable();
                combo_source_PRINT_TYPE.Columns.Add("CODE");
                combo_source_PRINT_TYPE.Columns.Add("NAME");
                combo_source_PRINT_TYPE.Rows.Add("1", "1Set [1EA]");
                combo_source_PRINT_TYPE.Rows.Add("2", "1Set [2EA]");
                this.cbo01_PRINT_TYPE.DataBind(combo_source_PRINT_TYPE, false);
                this.cbo01_PRINT_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_PRINT_TYPE.SetValue("1");
                
                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_DELI_DATE, this.lbl01_VENDCD, this.lbl01_PURC_ORG, this.lbl01_PURC_PO_TYPE);
                #endregion

                #region grd01
                this.grd01.AllowEditing = false;
                this.grd01.SelectionMode = SelectionModeEnum.Row;
                this.grd01.Initialize();                

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "D.Date" , "DELI_DATE" , "DELI_DATE" );
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "D.Seq" , "DELI_CNT" , "DELI_CNT" );
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "D.Note" , "DELI_NOTE" , "DELI_NOTE" );
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "NationNm" , "NATIONNM" , "NATIONNM" );
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "CustomerNm" , "CUSTNM" , "CUSTNM" );
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "IdentyCode", "SUM_CUSTCD", "SUM_CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "Boxes", "BOX_COUNT", "BOX_COUNT");
                this.grd01.Cols["BOX_COUNT"].Format = "#,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BOX_COUNT");
                #endregion 
                
                #region grd02
                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 021, "CHK", "CHK", "CHK");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "P/O No", "PONO", "PONO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "Part NM", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Box ID", "BOX_BARCODE", "BOX_BARCODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Seq", "BOX_SEQ", "BOX_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "Qty(F).", "QTY", "QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "Unit", "PO_UNIT", "PO_UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "LotNo of Vendor", "VEND_LOTNO", "VEND_LOTNO");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "CHANGE_4M", "CHANGE_4M", "CHANGE_4M");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "PRDT_DATE", "PRDT_DATE", "PRDT_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "CUST_PONO", "CUST_PONO", "CUST_PONO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "SD_PONO", "SD_PONO", "SD_PONO");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd02.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd02.SetCellStyle(0, this.grd02.Cols["CHK"].Index, cs);                          //2019.04.16

                this.grd02.Cols["QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //유효성 검사
                if (!IsQueryValidation())
                {
                    return;
                }

                this.txt02_DELI_NOTE.Value = "";
                this.txt02_DELI_CNT.Value = "";

                grd02.InitializeDataSource();

                DataSet result = getDataSet();
                this.grd01.SetValue(result.Tables[0]);
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

        private DataSet getDataSet()
        {
            HEParameterSet param = new HEParameterSet();
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
            param.Add("VENDCD", cdx01_VENDCD.GetValue().ToString());
            param.Add("PURC_PO_TYPE", cbo01_PURC_PO_TYPE.GetValue().ToString());
            param.Add("PURC_ORG", cbo01_PURC_ORG.GetValue().ToString());
            param.Add("STR_LOC", cdx01_STR_LOC.GetValue().ToString()); //저장위치
            param.Add("DATE_FROM", ((DateTime)this.df01_FROM_DATE.Value).ToString("yyyy-MM-dd"));
            param.Add("DATE_TO", ((DateTime)this.df01_TO_DATE.Value).ToString("yyyy-MM-dd"));
            param.Add("DELI_NOTE", txt01_DELI_NOTE.Value.ToString());
            param.Add("LANG_SET", this.UserInfo.Language);
            DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", pakageName, "INQUERY"), param, "OUT_CURSOR");
            return source;
        }

        //private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    int row = this.grd01.MouseRow;
        //    int col = this.grd01.MouseCol;
        //    if (this.grd01.Row > 0
        //        && this.grd01.Selection.TopRow == this.grd01.Selection.BottomRow
        //        && this.grd01.Selection.LeftCol == this.grd01.Selection.RightCol
        //        )
        //    {
        //        if (grd01.MouseRow < grd01.Rows.Fixed || col < 0)
        //        {
        //            return;
        //        }

        //        string deli_note = this.grd01.GetValue(row, "DELI_NOTE").ToString();
        //        string deli_note_seq = this.grd01.GetValue(row, "DELI_CNT").ToString();

        //        this.txt02_DELI_NOTE.Value = deli_note;
        //        this.txt02_DELI_CNT.Value = deli_note_seq;

        //        DataSet result = getDataSetDetail(deli_note, deli_note_seq);

        //        this.grd02.SetValue(result.Tables[0]);
        //    }
        //}

        private void grd01_CellChanged(object sender, RowColEventArgs e)
        {
            grd01_Click(sender, e);
        }
        private void grd01_Click(object sender, EventArgs e)
        {
            int row = this.grd01.MouseRow;
            int col = this.grd01.MouseCol;
            if (this.grd01.Row > 0
                && this.grd01.Selection.TopRow == this.grd01.Selection.BottomRow
                && this.grd01.Selection.LeftCol == this.grd01.Selection.RightCol
                )
            {
                if (grd01.MouseRow < grd01.Rows.Fixed || col < 0)
                {
                    return;
                }

                string deli_note = this.grd01.GetValue(row, "DELI_NOTE").ToString();
                string deli_note_seq = this.grd01.GetValue(row, "DELI_CNT").ToString();

                this.txt02_DELI_NOTE.Value = deli_note;
                this.txt02_DELI_CNT.Value = deli_note_seq;

                DataSet result = getDataSetDetail(deli_note, deli_note_seq);

                this.grd02.SetValue(result.Tables[0]);
            }
        }
        private DataSet getDataSetDetail(string deli_note, string deli_note_seq)
        {
            HEParameterSet param = new HEParameterSet();
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
            param.Add("DELI_NOTE", deli_note);
            param.Add("DELI_NOTE_SEQ", deli_note_seq);
            param.Add("LANG_SET", this.UserInfo.Language);

            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", pakageName, "INQUERY_DETAIL"), param, "OUT_CURSOR");
        }
        #endregion

        #region [Control Event]
        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine(this.grd01.MouseCol.ToString());
            if (this.grd02.MouseCol == IDX_CHECK_COLUMN)
            {
                if (this.grd02.MouseRow == 0)
                {
                    string s_value = this.grd02.GetValue(0, "CHK").ToString();
                    for (int j_cnt = this.grd02.Rows.Fixed; j_cnt < this.grd02.Rows.Count; j_cnt++)
                    {
                        this.grd02.SetValue(j_cnt, "CHK", s_value == "Y" ? "1" : "0");
                    }
                }
                else
                {
                    string s_all_check = this.grd02.GetValue(0, "CHK").ToString();
                    string s_single = this.grd02.GetValue(this.grd02.MouseRow, "CHK").ToString();
                    if (s_single != "Y" && s_all_check == "Y") this.grd02.SetValue(0, "CHK", "0");
                }
            }
        }
        private void btn01_PRINTA4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Part_Print("A4");
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
        private void btn01_PRINTTAG_Click(object sender, EventArgs e)
        {
            try
            {
                this.Part_Print("TAG");
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
        #endregion

        #region [Part_Print]
        private void Part_Print(string PrintType)
        {
            try
            {
                if (txt02_DELI_NOTE.Text.Length == 0)
                {
                    MsgCodeBox.ShowFormat("SRMMM-0054"); //선택한 납품서 정보가 없습니다.
                    return;
                }
                System.Text.StringBuilder selBarcode = new System.Text.StringBuilder();

                DataTable dtGrd02 = (DataTable)this.grd02.DataSource;
                foreach (DataRow row in dtGrd02.Select())
                {
                    string s_check = row["CHK"].ToString().Trim().ToUpper();
                    if (s_check.Equals("1") || s_check.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    {
                        selBarcode.AppendFormat(",{0}", row["BOX_BARCODE"]);
                    }
                }

                if (string.IsNullOrEmpty(selBarcode.ToString())) return;

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
                param.Add("DELI_NOTE", txt02_DELI_NOTE.Value.ToString());
                param.Add("BOX_BARCODE_LIST", selBarcode.ToString().Substring(1));
                param.Add("LANG_SET", this.UserInfo.Language);

                DataSet srcDs = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", pakageName, "INQUERY_SEL_PRINT"), param, "OUT_CURSOR");

                string PRINT_SIZE = cbo01_PRINT_SIZE.GetValue().ToString();

                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);

                if (PrintType == "A4") report.ReportName = "RxRpt/WM20521" + PRINT_SIZE;
                if (PrintType == "TAG") report.ReportName = "RxRpt/WM20521" + "TAG";
                
                // Main Section ( 메인리포트 파라메터셋 )
                HERexSection mainSection = new HERexSection();
                if (PrintType == "A4") mainSection.ReportParameter.Add("TYPE", cbo01_PRINT_TYPE.GetValue().ToString());

                report.Sections.Add("MAIN", mainSection);

                HERexSection xmlSection = new HERexSection(srcDs, new HEParameterSet());
                report.Sections.Add("XML", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정

                AxRexpertReportViewer.ShowReport(report);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
        #endregion

        #region [ 유효성 검사 ]

        /// <summary>
        /// Validation
        /// </summary>
        /// <returns></returns>
        public bool IsQueryValidation()
        {
            if (string.IsNullOrEmpty(this.cdx01_VENDCD.GetValue().ToString()))
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_VENDCD.Text);
                return false;
            }

            if (string.IsNullOrEmpty(this.cbo01_BIZCD.GetValue().ToString()))
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                return false;
            }

            //if (string.IsNullOrEmpty(this.cbo01_PURC_PO_TYPE.GetValue().ToString()))
            //{
            //    //{0} 가(이) 입력되지 않았습니다.
            //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_PURC_PO_TYPE.Text);
            //    return false;
            //}

            if (string.IsNullOrEmpty(this.cbo01_PURC_ORG.GetValue().ToString()))
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_PURC_ORG.Text);
                return false;
            }

            return true;
        }

        #endregion

        private void cbo01_PURC_ORG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo01_PURC_ORG.GetValue().ToString().Equals("1A1100"))
            {
                this.df01_FROM_DATE.SetValue(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
            }
            else
            {
                this.df01_FROM_DATE.SetValue(DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd"));
            }

            this.df01_TO_DATE.SetValue(DateTime.Now);
        }
    }
}
 