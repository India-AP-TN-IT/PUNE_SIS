#region ▶ Description & History
/* 
 * 프로그램명 : PD40130 제품별 작업 내역 추적 상세 현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 제품별 작업내역 추적 상세현황
    /// </summary>
    public partial class PD40130 : AxCommonBaseControl
    {
        private const int _MAX_SCREW_POINT = 47;
        private Color _OddRow_BackColor = Color.FromArgb(228, 248, 252);
        private Color _OddRow_ForeColor = Color.Black;
        private Color _EvenRow_BackColor = Color.White;
        private Color _EvenRow_ForeColor = Color.Black;
        private Color _GridLine_Color = Color.Gray;
        //private IPD40130 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40130";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40130()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40130>("PD", "PD40130_N.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region grd01

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "일자", "RSLT_DATE", "WORK_DATE3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "Lot No", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "ALC", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "완제품 P/NO", "PARTNO", "PART_NO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "비전결과", "CHK_VISION", "VISIONRESULT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "커넥터 체결이력", "CHK_LEADCABLE", "RSLT_CONNECT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Result", "CHK_FNL", "CHL_FNL");


                this.grd01.Cols["RSLT_DATE"].Format = "MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE");
                
                this.grd01.Cols[0].Visible = false;

                #endregion

                #region grd02

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
                this.grd02.SelectionMode = SelectionModeEnum.Cell;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "공정코드", "PROCCD", "PROCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "공정명", "PROCNM", "PROCNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "시작일자", "BEG_DATE", "BEGDATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "시작시간", "BEG_TIME", "BEG_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "종료일자", "END_DATE", "ENDDATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "종료시간", "END_TIME", "END_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "횟수", "WORK_CNT", "WORK_COUNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "결과", "WORK_STATUS_DESC", "WORK_STATUS_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "작업자", "WORKER_NM", "WORKER");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.grd02.Cols["PROCCD"].AllowMerging = true;
                this.grd02.Cols["PROCNM"].AllowMerging = true;

                this.grd02.Cols[0].Visible = false;

                //기본 색상 처리
                grd02.Styles.Alternate.BackColor = _OddRow_BackColor;
                grd02.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                grd02.Styles.Normal.BackColor = _EvenRow_BackColor;
                grd02.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                grd02.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd03

                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.SelectionMode = SelectionModeEnum.Cell;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "통전사양 및 코드", "ET_DTLNM", "ET_DTLNM");
                //this.grd03.AddColumn(true, true, HEFlexGrid.FtextAlign.C, 090, "통전항목코드", "INSPECCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "결과", "RESULT_DESC", "RESULT");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전류측정값(mA)", "RSLT_INSPEC", "RSLT_INSPEC");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전류하한값(mA)", "ET_CURRENT_MIN", "ET_CURRENT_MIN");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전류상한값(mA)", "ET_CURRENT_MAX", "ET_CURRENT_MAX");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사시간", "INSPEC_TIME", "INSPECT_TIME");

                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_INSPEC");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "ET_CURRENT_MIN");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "ET_CURRENT_MAX");

                this.grd03.Cols["RSLT_INSPEC"].Format = "###,###,###,##0.00";
                this.grd03.Cols["ET_CURRENT_MIN"].Format = "###,###,###,##0.00";
                this.grd03.Cols["ET_CURRENT_MAX"].Format = "###,###,###,##0.00";

                this.grd03.Cols[0].Visible = false;

                //기본 색상 처리
                grd03.Styles.Alternate.BackColor = _OddRow_BackColor;
                grd03.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                grd03.Styles.Normal.BackColor = _EvenRow_BackColor;
                grd03.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                grd03.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd04

                this.grd04.AllowEditing = false;
                this.grd04.Initialize();
                this.grd04.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd04.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd04.SelectionMode = SelectionModeEnum.Cell;

                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "단품누락유형", "INSPEC_ITEMCD", "INSPEC_ITEM_OUT");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "횟수", "WORK_CNT", "WORK_COUNT");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "결과", "RESULT", "RESULT");

                for (int i = 0; i <= _MAX_SCREW_POINT; i++)
                    this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 025, "    ", i.ToString());

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("INSPEC_DIV", "09");
                DataTable INSPEC_ITEMCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECITEM"), set).Tables[0];
                //DataTable INSPEC_ITEMCD = _WSCOM_MES.INQUERY_COMBO_INSPECITEM(this.cbo01_BIZCD.GetValue().ToString(), set).Tables[0];

                this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, INSPEC_ITEMCD, "INSPEC_ITEMCD");
                this.grd04.Cols[0].Visible = false;

                //기본 색상 처리
                grd04.Styles.Alternate.BackColor = _OddRow_BackColor;
                grd04.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                grd04.Styles.Normal.BackColor = _EvenRow_BackColor;
                grd04.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                grd04.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd05

                this.grd05.AllowEditing = false;
                this.grd05.Initialize();
                this.grd05.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd05.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
                this.grd05.SelectionMode = SelectionModeEnum.Cell;

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "계측명", "INSPEC_DIVNM", "INSPEC_NM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "SEQ", "INSPECCD", "SEQ");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "횟수", "WORK_CNT", "WORK_COUNT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "결과", "RESULT_DESC", "RESULT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "계측값", "RSLT_INSPEC", "RSLTINSPEC");

                this.grd05.Cols["INSPEC_DIVNM"].AllowMerging = true;
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_INSPEC");
                this.grd05.Cols[0].Visible = false;

                //기본 색상 처리
                grd05.Styles.Alternate.BackColor = _OddRow_BackColor;
                grd05.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                grd05.Styles.Normal.BackColor = _EvenRow_BackColor;
                grd05.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                grd05.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd06

                this.grd06.AllowEditing = false;
                this.grd06.Initialize();
                this.grd06.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd06.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd06.SelectionMode = SelectionModeEnum.Cell;

                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 115, "자재 P/No", "MAT_PARTNO", "MAT_PARTENO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "자재 Lot No", "MAT_LOTNO", "MAT_LOTNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사시간", "INSPEC_TIME", "INSPECT_TIME");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사결과", "RESULT", "RESULT");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "LOT NO", "LOTNO");

                this.grd06.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");

                //기본 색상 처리
                grd06.Styles.Alternate.BackColor = _OddRow_BackColor;
                grd06.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                grd06.Styles.Normal.BackColor = _EvenRow_BackColor;
                grd06.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                grd06.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd07

                this.grd07.AllowEditing = false;
                this.grd07.Initialize();
                this.grd07.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd07.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd07.SelectionMode = SelectionModeEnum.Cell;

                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "순번", "SEQ", "SEQ");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사시간", "INSPEC_TIME", "INSPECT_TIME");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "결과", "RESULT", "RESULT");
                this.grd07.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                //기본 색상 처리
                grd07.Styles.Alternate.BackColor = _OddRow_BackColor;
                grd07.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                grd07.Styles.Normal.BackColor = _EvenRow_BackColor;
                grd07.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                grd07.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();

                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명

                this.SetRequired(lbl01_BIZNM2, lbl02_WORK_DATE, lbl04_LINE, lbl05_POSTITLE);

                if (this.cbl01_LINECD.GetValue().ToString() == "HI0100")
                {
                    if (tabControl1.TabPages.Count == 2)
                        tabControl1.TabPages.Insert(2, tp01_PD40130_TP03);
                }
                else
                    tabControl1.TabPages.Remove(tp01_PD40130_TP03);
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
                if (this.cbl01_LINECD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{라인}을 선택해 주세요.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINE"));
                    return;
                }

                if (this.cbl01_INSTALL_POS.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{장착위치}를 선택해 주세요.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("POSTITLE"));
                    return;
                }

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("RSLT_SDATE", this.dtp01_RSLT_SDATE.GetDateText());
                set.Add("RSLT_EDATE", this.dtp01_RSLT_EDATE.GetDateText());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());

                //#001
                set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                set.Add("MAT_LOTNO", this.txt01_MAT_LOTNO.GetValue());
                set.Add("MAT_PARTNO", this.txt01_MAT_PARTNO.GetValue());
                set.Add("ALC", this.txt01_ALC.GetValue());
                set.Add("ASSY_PARTNO", this.txt01_PART_NO.GetValue());


                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                if (bizcd == "5220")
                {
                    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_NGMASTER"), set, "OUT_CURSOR");
                }

                this.grd01.SetValue(source);

                this.AfterInvokeServer();
                this.Init_Data();

                ShowDataCount(source);

                int result_col = this.grd01.Cols["CHK_FNL"].Index;
                for (int i = 1; i < grd01.Rows.Count; i++)
                {
                    string strResult = this.grd01.GetValue(i, "CHK_FNL").ToString();
                    CellRange oRange = this.grd01.GetCellRange(i, result_col);

                    switch (strResult)
                    {
                        case "IC":
                            this.grd01.SetValue(i, "CHK_FNL", "OK");
                            oRange.StyleNew.BackColor = Color.Lime;
                            oRange.StyleNew.ForeColor = Color.Black;
                            break;
                        case "IF":
                            this.grd01.SetValue(i, "CHK_FNL", "NG");
                            oRange.StyleNew.BackColor = Color.Red;
                            oRange.StyleNew.ForeColor = Color.White;
                            break;
                        default:
                            this.grd01.SetValue(i, "CHK_FNL","");
                            oRange.StyleNew.BackColor = Color.Black;
                            oRange.StyleNew.ForeColor = Color.Black;
                            break;
                    }
                }
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

        #region [기타 컨트롤 이벤트]

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", "");
            set.Add("LANG_SET", this.UserInfo.Language);
            DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
            //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

            this.cbl01_LINECD.DataBind(source1.Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
        }

        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.lbl02_REWORK.Value = "";
                this.grd05.InitializeDataSource();
                this.grd06.InitializeDataSource();
                this.grd07.InitializeDataSource();

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                string LOTNO = this.grd01.GetValue(row, "LOTNO").ToString();
                string ALCCD = this.grd01.GetValue(row, "ALCCD").ToString();
                string PARTNO = this.grd01.GetValue(row, "PARTNO").ToString();
                string VISION = this.grd01.GetValue(row, "CHK_VISION").ToString();               
                string CHK_LEADCABLE = this.grd01.GetValue(row, "CHK_LEADCABLE").ToString();

                switch (CHK_LEADCABLE)
                { 
                    case "Y":
                        //CHK_LEADCABLE = "합격";
                        CHK_LEADCABLE = this.GetLabel("PASS");
                        break;
                    case "E":
                        //CHK_LEADCABLE = "불합격";
                        CHK_LEADCABLE = this.GetLabel("UNPASS");
                        break;
                    case "C":
                        //CHK_LEADCABLE = "재확인";
                        CHK_LEADCABLE = this.GetLabel("RE_CONFIRM");
                        break;
                    case "R":
                        //CHK_LEADCABLE = "재검사 완료";
                        CHK_LEADCABLE = this.GetLabel("RE_CONFIRM_OK");
                        break;
                    default:
                        CHK_LEADCABLE = "";
                        break;
                }

                this.lbl02_LOTNO.Value = LOTNO;
                this.lbl02_ALCCODE.Value = ALCCD;
                this.lbl02_PARTNO.Value = PARTNO;
                this.lbl02_CHK_LEADCABLE.Value = CHK_LEADCABLE;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", LOTNO);
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_REWORKHISTORY"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_REWORKHISTORY(bizcd, set).Tables[0];
                if (source.Rows.Count > 0)
                    this.lbl02_REWORK.Value = source.Rows[0]["JOB_STATUS_DESC"].ToString();

                switch (VISION)
                {
                    //OK
                    case "Y":
                        lbl02_VISIONCHECK.Value = "OK";
                        lbl02_VISIONCHECK.BackColor = Color.Lime;
                        lbl02_VISIONCHECK.ForeColor = Color.Black;
                        break;

                    //SKIP
                    case "S":
                        lbl02_VISIONCHECK.Value = "SKIP";
                        lbl02_VISIONCHECK.BackColor = Color.Yellow;
                        lbl02_VISIONCHECK.ForeColor = Color.Black;
                        break;

                    //NG
                    case "E":
                        lbl02_VISIONCHECK.Value = "NG";
                        lbl02_VISIONCHECK.BackColor = Color.Red;
                        lbl02_VISIONCHECK.ForeColor = Color.White;
                        break;

                    //
                    default:
                        lbl02_VISIONCHECK.Value = "";
                        lbl02_VISIONCHECK.BackColor = Color.White;
                        lbl02_VISIONCHECK.ForeColor = Color.Black;
                        break;
                }

                //공정 작업 이력
                this.LoadProcHistory(LOTNO);

                //통전 검사 이력
                this.LoadEtHistory(LOTNO, PARTNO);

                //이종 검사 이력
                this.LoadPartsHistory(LOTNO, "");

                //스크류 누락 이력
                if (this.cbo01_BIZCD.GetValue().ToString() != "5210")
                    this.LoadScrewHistory(LOTNO);

                //누락 검사 이력
                if (this.cbo01_BIZCD.GetValue().ToString() == "5210")
                    this.LoadVisionHistory(LOTNO);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                int row = this.grd02.SelectedRowIndex;
                if (row < this.grd02.Rows.Fixed)
                    return;

                string LOTNO = this.lbl02_LOTNO.Value.ToString();
                string PROCCD = this.grd02.GetValue(row, "PROCCD").ToString();

                this.LoadMeasureHistory(LOTNO, PROCCD);
                this.LoadPartsHistory(LOTNO, PROCCD);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                int result_col = this.grd02.Cols["WORK_STATUS_DESC"].Index;

                if (this.grd02.Rows.Count < this.grd02.Rows.Fixed)

                    for (int i = 1; i < this.grd02.Rows.Count; i++)
                    {
                        string strResult = this.grd02.GetValue(i, "WORK_STATUS_DESC").ToString();
                        CellRange oRange = this.grd02.GetCellRange(i, result_col);

                        if(strResult==this.GetLabel("JOB_OK"))  //정상완료
                        {
                                oRange.StyleNew.BackColor = Color.Lime;
                                oRange.StyleNew.ForeColor = Color.Black;
                        } else if(strResult==this.GetLabel("JOB_NG"))   //불량취출
                        {
                                oRange.StyleNew.BackColor = Color.Red;
                                oRange.StyleNew.ForeColor = Color.White;
                        } else if(strResult==this.GetLabel("JOB_WORK")) //작업중
                        {
                                oRange.StyleNew.BackColor = Color.MistyRose;
                                oRange.StyleNew.ForeColor = Color.Black;
                        } else {
                                oRange.StyleNew.BackColor = Color.Black;
                                oRange.StyleNew.ForeColor = Color.Black;
                        }
                    }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd03_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                int result_col = this.grd03.Cols["RESULT_DESC"].Index;

                if (this.grd03.Rows.Count < this.grd03.Rows.Fixed)
                    return;

                for (int i = this.grd03.Rows.Fixed; i < this.grd03.Rows.Count; i++)
                {
                    string strResult = this.grd03.GetValue(i, "RESULT_DESC").ToString();
                    CellRange oRange = this.grd03.GetCellRange(i, result_col);

                    switch (strResult)
                    {
                        case "OK":
                            oRange.StyleNew.BackColor = Color.Lime;
                            oRange.StyleNew.ForeColor = Color.Black;
                            break;
                        case "NG":
                            oRange.StyleNew.BackColor = Color.Red;
                            oRange.StyleNew.ForeColor = Color.White;
                            break;
                        default:
                            oRange.StyleNew.BackColor = Color.Black;
                            oRange.StyleNew.ForeColor = Color.Black;
                            break;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd05_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                int result_col = this.grd05.Cols["RESULT_DESC"].Index;

                if (this.grd05.Rows.Count <= this.grd05.Rows.Fixed)
                    return;

                for (int i = this.grd05.Rows.Fixed; i < this.grd05.Rows.Count; i++)
                {
                    string strResult = this.grd05.GetValue(i, "RESULT_DESC").ToString();
                    CellRange oRange = this.grd05.GetCellRange(i, result_col);

                    if(strResult==this.GetLabel("WORK_SUCCESS")) //성공
                    {
                        oRange.StyleNew.BackColor = Color.Lime;
                        oRange.StyleNew.ForeColor = Color.Black;
                    } else if(strResult==this.GetLabel("WORK_FAIL")) //실패
                    {
                        oRange.StyleNew.BackColor = Color.Red;
                        oRange.StyleNew.ForeColor = Color.White;
                    } else if(strResult==this.GetLabel("WORK_PASS")) //패스
                    {
                        oRange.StyleNew.BackColor = Color.Yellow;
                        oRange.StyleNew.ForeColor = Color.Black;
                    } else 
                    {
                        oRange.StyleNew.BackColor = Color.Black;
                        oRange.StyleNew.ForeColor = Color.Black;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd06_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                for (int j = grd06.Rows.Fixed; j < grd06.Rows.Count + 1; j++)
                {
                    if (grd06.GetValue(j, "RESULT").ToString() == "OK")
                    {
                        CellRange oRange = this.grd06.GetCellRange(j, this.grd06.Cols["RESULT"].Index);
                        oRange.StyleNew.BackColor = Color.Lime;
                    }
                    if (grd06.GetValue(j, "RESULT").ToString() == "NG")
                    {
                        CellRange oRange = this.grd06.GetCellRange(j, this.grd06.Cols["RESULT"].Index);
                        oRange.StyleNew.BackColor = Color.Red;
                    }
                    if (grd06.GetValue(j, "RESULT").ToString() == this.GetLabel("OVERLAP")) // "중복")
                    {
                        CellRange oRange = this.grd06.GetCellRange(j, this.grd06.Cols["RESULT"].Index);
                        oRange.StyleNew.BackColor = Color.Orange;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void grd07_DoubleClick(object sender, EventArgs e)
        {
            int row = this.grd07.SelectedRowIndex;
            if (row < this.grd07.Rows.Fixed)
                return;

            try
            {
                string CN_FTP_INFOR_ULSAN = "10.10.10.10;mes;mes;21";
                PDFTP m_ftpHandle = new PDFTP(CN_FTP_INFOR_ULSAN);  //IP;ID;PWD;PORT

                if (this.grd07.GetValue(row, "RESULT").ToString() == "Y")
                {
                    m_ftpHandle.Download(@"c:/tmp.jpg", @"Point_image/" + this.cbl01_LINECD.GetValue().ToString() + "_" + this.cbl01_INSTALL_POS.GetValue().ToString() + ".jpg");
                }
                else
                {
                    m_ftpHandle.Download(@"c:/tmp.jpg", @"Point_image/" + this.grd07.GetValue(row, "INSPEC_DATE").ToString() + "/" + lbl02_LOTNO.Text + "_" + this.grd07.GetValue(row, "SEQ").ToString() + ".jpg");
                }

                pic1.ImageLocation = @"c:/tmp.jpg";
            }
            catch
            { }
        }

        private void tabPage1_Resize(object sender, EventArgs e)
        {   
            grp02_PD40130_2.Width = ((tp01_PD40130_TP01.Width / 3) * 2) - 5 ;  //공적정별 작업 이력 그리드가 컬럼이 더 많아서 넓게 
            grp03_PD40130_3.Width = ((tp01_PD40130_TP01.Width / 3)) - 5 ;
        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {
            grp04_PD40130_4.Width = (tp01_PD40130_TP02.Width / 2) - 5;
            grp05_PD40130_5.Width = (tp01_PD40130_TP02.Width / 2) - 5;
        }

        private void tabPage3_Resize(object sender, EventArgs e)
        {
            grp03_PD40130_8.Width = (tp01_PD40130_TP03.Width / 2) -5;
            grp03_PD40130_7.Width = (tp01_PD40130_TP03.Width / 2) - 5;

            pic1.Width = grp03_PD40130_7.Width - 15;
            pic1.Height = Convert.ToInt32(pic1.Width / (1.3));
        }

        private void cbl01_LINECD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbl01_LINECD.GetValue().ToString().Substring(0, 2) == "HI"
                    || this.cbl01_LINECD.GetValue().ToString().Substring(0, 2) == "IK"
                    || this.cbl01_LINECD.GetValue().ToString().Substring(0, 2) == "PD"
                    || this.cbl01_LINECD.GetValue().ToString().Substring(0, 2) == "AE"
                    || this.cbl01_LINECD.GetValue().ToString().Substring(0, 2) == "AD")
                {
                    if (tabControl1.TabPages.Count == 2)
                        tabControl1.TabPages.Insert(2, tp01_PD40130_TP03);
                }
                else
                    tabControl1.TabPages.Remove(tp01_PD40130_TP03);
            }
            catch (Exception ee)
            { }
        }

        #endregion

        #region [사용자 정의 메서드]

        private void Init_Data()
        {
            try
            {
                this.grd02.InitializeDataSource();
                this.grd03.InitializeDataSource();
                this.grd04.InitializeDataSource();
                this.grd05.InitializeDataSource();
                this.grd06.InitializeDataSource();

                this.lbl02_ALCCODE.Value = "";
                this.lbl02_LOTNO.Value = "";
                this.lbl02_PARTNO.Value = "";
                this.lbl02_REWORK.Value = "";
                this.lbl02_VISIONCHECK.Value = "";

                this.lbl02_CHK_LEADCABLE.Value = "";

                this.lbl02_VISIONCHECK.BackColor = Color.White;
                this.lbl02_VISIONCHECK.ForeColor = Color.Black;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadProcHistory(string LOTNO)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", LOTNO);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataTable source = _WSCOM.INQUERY_PROCHISTORY(bizcd, set).Tables[0];
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PROCHISTORY"), set, "OUT_CURSOR");

                this.grd02.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadEtHistory(string LOTNO, string PARTNO)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                string vincd = "";

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("PARTNO", PARTNO);
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_CARTYPE"), set1).Tables[0];
                //DataTable source1 = _WSCOM_ERM.INQUERY_CARTYPE(set1).Tables[0];


                if (source1.Rows.Count > 0)
                    vincd = source1.Rows[0]["VINCD"].ToString();

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("CORCD", this.UserInfo.CorporationCode);
                set2.Add("BIZCD", bizcd);
                set2.Add("LOTNO", LOTNO);
                set2.Add("VINCD", vincd);
                set2.Add("LINECD", this.cbl01_LINECD.GetValue());

                //DataTable source2 = _WSCOM.INQUERY_ETHISTORY(bizcd, set2).Tables[0];
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_ETHISTORY"), set2, "OUT_CURSOR");

                this.grd03.SetValue(source2);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadPartsHistory(string LOTNO, string PROCCD)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", LOTNO);
                set.Add("PROCCD", PROCCD);
                set.Add("SINSPDATE", dtp01_RSLT_SDATE.GetDateText());
                set.Add("EINSPDATE", dtp01_RSLT_EDATE.GetDateText());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataTable source = _WSCOM.INQUERY_PARTSHISTORY(bizcd, set).Tables[0];
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PARTSHISTORY"), set, "OUT_CURSOR");

                this.grd06.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void LoadVisionHistory(string LOTNO)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", LOTNO);

                DataSet source = _WSCOM_N.ExecuteDataSet("APG_PD40130.INQUERY_VISIONHISTORY", set, "OUT_CURSOR");

                this.grd07.SetValue(source);

                pic1.ImageLocation = "";
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
                
        private void LoadScrewHistory(string LOTNO)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                int fixrow = this.grd04.Rows.Fixed;
                int result_col = this.grd04.Cols["RESULT"].Index;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", LOTNO);

                //DataTable source = _WSCOM.INQUERY_SCREWHISTORY(bizcd, set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCREWHISTORY"), set, "OUT_CURSOR").Tables[0];

                if (source.Rows.Count >= 0)
                {
                    this.grd04.InitializeDataSource();

                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        int iRow = i + fixrow;
                        DataRow row = source.Rows[i];

                        this.grd04.Rows.Add();

                        //단품누락 유형
                        this.grd04.SetValue(i + fixrow, "INSPEC_ITEMCD", row["INSPEC_CD"]);
                        
                        //작업회수
                        this.grd04.SetValue(i + fixrow, "WORK_CNT", row["WORK_CNT"]);

                        //전체작업결과
                        this.grd04.SetValue(i + fixrow, "RESULT", row["RESULT"]);

                        //작업결과 색상 처리
                        CellRange oRange = this.grd04.GetCellRange(iRow, result_col, iRow, result_col);
                        oRange.StyleNew.BackColor = row["RESULT"].ToString().Equals("T") ? Color.Lime : Color.Red;
                        oRange.StyleNew.ForeColor = row["RESULT"].ToString().Equals("T") ? Color.Black : Color.White;

                        //---------------------------------
                        //에러 위치 화면 출력
                        //---------------------------------
                        //결과 2진수 변환

                        string BitCheckResult = MakeBinaryString(row["MEASURE_RESULT"].ToString().PadLeft(12, '0'));
                        string BitCheckPoint = MakeBinaryString(row["MEASURE_POINT"].ToString().PadLeft(12, '0'));

                        //--------------------------------------------------------------------
                        //결과 화면 출력
                        //--------------------------------------------------------------------
                        int iCol = 0;
                        int maxPoint = BitCheckPoint.Length - 1;
                        if (maxPoint >= 48) maxPoint = 47;
                        for (int j = 0; j <= maxPoint; j++)
                        {
                            //체크 포인트

                            string strCheck = BitCheckPoint.Substring(maxPoint - j, 1);
                            //체크 결과
                            string strResult = BitCheckResult.Substring(maxPoint - j, 1);

                            //결과 출력 위치 설정
                            if (j != 0)
                                iCol++;

                            //체크 포인트인 경우
                            if (strCheck == "1")
                            {
                                //체결 포인트 번호 출력
                                this.grd04.SetValue(iRow, iCol.ToString(), (j + 1).ToString());

                                //체결 결과 출력

                                int input_col = this.grd04.Cols[iCol.ToString()].Index;
                                oRange = this.grd04.GetCellRange(iRow, input_col, iRow, input_col);

                                //합격
                                if (strResult == "1")
                                {
                                    oRange.StyleNew.BackColor = Color.Lime;
                                    oRange.StyleNew.ForeColor = Color.Black;
                                }
                                else
                                {
                                    oRange.StyleNew.BackColor = Color.Red;
                                    oRange.StyleNew.ForeColor = Color.White;
                                }
                            }
                            else
                            {
                                this.grd04.SetValue(iRow, iCol.ToString(), "");
                            }
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadMeasureHistory(string LOTNO, string PROCCD)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", LOTNO);
                set.Add("PROCCD", PROCCD);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataTable source = _WSCOM.INQUERY_MEASUREHISTORY(bizcd, set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_MEASUREHISTORY"), set, "OUT_CURSOR").Tables[0];

                this.grd05.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private string MakeBinaryString(string Value)
        {
            try
            {
                string Binary = "";

                for (int i = Value.Length - 1; i >= 0; i--)
                {
                    string Digit = Value.Substring(i, 1);

                    int HexValue = Convert.ToInt32(Digit, 16);

                    string BitValue = Convert.ToString(HexValue, 2);

                    if (BitValue.Length < 4)
                    {
                        BitValue = new string('0', 4 - BitValue.Length) + BitValue;
                    }

                    Binary = BitValue + Binary;
                }

                return Binary;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return "";
            }
        }

        #endregion       

    }
}
