
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using System.Drawing;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b> ASSY ALL LINE MORNITORING </b>
    /// </summary>
    public partial class PD31370 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
        private DateTime _svrDate;
        private const string _IntFormat = "###,###,###,###,##0";

        private string CURRENT_PGN = "";
        private string CURRENT_LINE_NM = "";
        private string CURRENT_LINE_TYPE = "";

        public PD31370()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        private void PD31370_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel4;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void InitGrid()
        {
            try
            {
                this.grpbox2.Visible = false;
                this.grd01.AllowEditing = true;
                this.grd01.Initialize(2, 2);
                this.grd01.Font = new Font("맑은 고딕", 8);
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "BIZCD", "BIZCD", "BIZCD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "-", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "PGN", "PGN", "PGN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "TITLE", "TITLE", "TITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "LINE", "LINE", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "PLAN", "KMI_PLAN_QTY", "KMI_PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "UPH", "KMI_RSLT_QTY", "KMI_RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "PLAN", "SAP_PLAN_QTY", "SAP_PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "RSLT", "SAP_RSLT_QTY", "SAP_RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "STD", "UPH", "UPH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "AVG", "GAVG", "GAVG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "SH1", "AVG1", "AVG1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "SH2", "AVG2", "AVG2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "SH3", "AVG3", "AVG3");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "08", "TOT_08", "TOT_08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "09", "TOT_09", "TOT_09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "10", "TOT_10", "TOT_10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "11", "TOT_11", "TOT_11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "12", "TOT_12", "TOT_12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "13", "TOT_13", "TOT_13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "14", "TOT_14", "TOT_14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "15", "TOT_15", "TOT_15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "16", "TOT_16", "TOT_16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "17", "TOT_17", "TOT_17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "18", "TOT_18", "TOT_18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "19", "TOT_19", "TOT_19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "20", "TOT_20", "TOT_20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "21", "TOT_21", "TOT_21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "22", "TOT_22", "TOT_22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "23", "TOT_23", "TOT_23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "24", "TOT_24", "TOT_24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "01", "TOT_01", "TOT_01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "02", "TOT_02", "TOT_02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "03", "TOT_03", "TOT_03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "04", "TOT_04", "TOT_04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "05", "TOT_05", "TOT_05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "06", "TOT_06", "TOT_06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 026, "07", "TOT_07", "TOT_07");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Stop Reason", "STOP_REASON", "STOP_REASON");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "PLAN_DATE", "PLAN_DATE", "PLAN_DATE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "KMI_PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "KMI_RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SAP_PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SAP_RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "UPH");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "GAVG");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "AVG1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "AVG2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "AVG3");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_10");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_11");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_12");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_13");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_14");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_15");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_16");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_17");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_18");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_19");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_20");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_21");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_22");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_23");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_24");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_06");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_07");

                this.grd01.Cols["KMI_PLAN_QTY"].Format = _IntFormat;
                this.grd01.Cols["KMI_RSLT_QTY"].Format = _IntFormat;
                this.grd01.Cols["SAP_PLAN_QTY"].Format = _IntFormat;
                this.grd01.Cols["SAP_RSLT_QTY"].Format = _IntFormat;
                this.grd01.Cols["UPH"].Format = _IntFormat;
                this.grd01.Cols["GAVG"].Format = _IntFormat;
                this.grd01.Cols["AVG1"].Format = _IntFormat;
                this.grd01.Cols["AVG2"].Format = _IntFormat;
                this.grd01.Cols["AVG3"].Format = _IntFormat;

                this.grd01.Cols["TOT_08"].Format = _IntFormat;
                this.grd01.Cols["TOT_09"].Format = _IntFormat;
                this.grd01.Cols["TOT_10"].Format = _IntFormat;
                this.grd01.Cols["TOT_11"].Format = _IntFormat;
                this.grd01.Cols["TOT_12"].Format = _IntFormat;
                this.grd01.Cols["TOT_13"].Format = _IntFormat;
                this.grd01.Cols["TOT_14"].Format = _IntFormat;
                this.grd01.Cols["TOT_15"].Format = _IntFormat;
                this.grd01.Cols["TOT_16"].Format = _IntFormat;
                this.grd01.Cols["TOT_17"].Format = _IntFormat;
                this.grd01.Cols["TOT_18"].Format = _IntFormat;
                this.grd01.Cols["TOT_19"].Format = _IntFormat;
                this.grd01.Cols["TOT_20"].Format = _IntFormat;
                this.grd01.Cols["TOT_21"].Format = _IntFormat;
                this.grd01.Cols["TOT_22"].Format = _IntFormat;
                this.grd01.Cols["TOT_23"].Format = _IntFormat;
                this.grd01.Cols["TOT_24"].Format = _IntFormat;
                this.grd01.Cols["TOT_01"].Format = _IntFormat;
                this.grd01.Cols["TOT_02"].Format = _IntFormat;
                this.grd01.Cols["TOT_03"].Format = _IntFormat;
                this.grd01.Cols["TOT_04"].Format = _IntFormat;
                this.grd01.Cols["TOT_05"].Format = _IntFormat;
                this.grd01.Cols["TOT_06"].Format = _IntFormat;
                this.grd01.Cols["TOT_07"].Format = _IntFormat;

                grd01.Cols.Frozen = 11;

                #region [Grid Merge]

                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                this.grd01.Cols["DELI_TYPE"].AllowMerging = true;

                for (int i = 1; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddMerge(0, 1, "LINE", "LINE");

                this.grd01.AddMerge(0, 0, "KMI_PLAN_QTY", "KMI_RSLT_QTY");
                this.grd01.SetHeadTitle(0, "KMI_PLAN_QTY", "KIN");
                this.grd01.AddMerge(0, 0, "SAP_PLAN_QTY", "SAP_RSLT_QTY");
                this.grd01.SetHeadTitle(0, "SAP_PLAN_QTY", "SSAP");
                this.grd01.AddMerge(0, 0, "UPH", "AVG3");
                this.grd01.SetHeadTitle(0, "UPH", "UPH");
                this.grd01.AddMerge(0, 0, "TOT_08", "TOT_16");
                this.grd01.SetHeadTitle(0, "TOT_08", "1 Shift");
                this.grd01.AddMerge(0, 0, "TOT_17", "TOT_24");
                this.grd01.SetHeadTitle(0, "TOT_17", "2 Shift");
                this.grd01.AddMerge(0, 0, "TOT_01", "TOT_07");
                this.grd01.SetHeadTitle(0, "TOT_01", "3 Shift");

                this.grd01.AddMerge(0, 1, "STOP_REASON", "STOP_REASON");

                #endregion

                this.grd04.AllowEditing = true;
                this.grd04.Initialize(1, 1);
                this.grd04.Font = new Font("맑은 고딕", 8);
                this.grd04.AllowDragging = AllowDraggingEnum.None;
                this.grd04.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 200, "CATEGORY", "M4", "M4");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "TOTAL", "SUB_STOP", "SUB_STOP");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "MIN", "STOP_MIN", "STOP_MIN");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 330, "REASON", "REASON", "REASON");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "LINE", "PGNDESC", "PGNDESC");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 200, "DEPARTMENT", "DEPT", "DEPT");

                this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "SUB_STOP");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "STOP_MIN");

                this.grd04.Cols["SUB_STOP"].Format = _IntFormat;
                this.grd04.Cols["STOP_MIN"].Format = _IntFormat;


                CellStyle csTITLE = grd01.Styles.Add("TITLE");
                CellStyle csTITLE1 = grd04.Styles.Add("TITLE");
                csTITLE.Font = new Font(this.Font, FontStyle.Bold);
                csTITLE.ForeColor = Color.White;
                csTITLE.BackColor = Color.Black;
                csTITLE1.Font = new Font(this.Font, FontStyle.Bold);
                csTITLE1.ForeColor = Color.White;
                csTITLE1.BackColor = Color.Black;

                CellStyle csDELI_TYPE = grd01.Styles.Add("DELI_TYPE");
                csDELI_TYPE.Font = new Font(this.Font, FontStyle.Bold);
                csDELI_TYPE.ForeColor = Color.Black;
                csDELI_TYPE.BackColor = Color.White;

                CellStyle csLINE = grd01.Styles.Add("LINE");
                CellStyle csLINE1 = grd04.Styles.Add("DIVISION");
                csLINE.Font = new Font(this.Font, FontStyle.Bold);
                csLINE.ForeColor = Color.Black;
                csLINE.BackColor = Color.LightSteelBlue;
                csLINE1.Font = new Font(this.Font, FontStyle.Bold);
                csLINE1.ForeColor = Color.Black;
                csLINE1.BackColor = Color.LightSteelBlue;

                CellStyle csKMI = grd01.Styles.Add("KMI");
                CellStyle csKMI1 = grd04.Styles.Add("MIN");
                csKMI.Font = new Font(this.Font, FontStyle.Bold);
                csKMI.ForeColor = Color.White;
                csKMI.BackColor = Color.Blue;
                csKMI1.Font = new Font(this.Font, FontStyle.Bold);
                csKMI1.ForeColor = Color.White;
                csKMI1.BackColor = Color.Blue;

                CellStyle csSSAP = grd01.Styles.Add("SSAP");
                csSSAP.Font = new Font(this.Font, FontStyle.Bold);
                csSSAP.ForeColor = Color.Black;
                csSSAP.BackColor = Color.DeepSkyBlue;

                CellStyle csTOTAL = grd01.Styles.Add("AVG");
                csTOTAL.Font = new Font(this.Font, FontStyle.Bold);
                csTOTAL.ForeColor = Color.White;
                csTOTAL.BackColor = Color.BlueViolet;

                CellStyle csHOUR = grd01.Styles.Add("HOUR");
                CellStyle csHOUR1 = grd04.Styles.Add("DEPT");
                csHOUR.Font = new Font(this.Font, FontStyle.Regular);
                csHOUR.ForeColor = Color.Black;
                csHOUR.BackColor = Color.Transparent;
                csHOUR1.Font = new Font(this.Font, FontStyle.Regular);
                csHOUR1.ForeColor = Color.Black;
                csHOUR1.BackColor = Color.Transparent;

                CellStyle csUPH100B = grd01.Styles.Add("UPH100B");
                csUPH100B.Font = new Font(this.Font, FontStyle.Bold);
                csUPH100B.ForeColor = Color.Black;
                csUPH100B.BackColor = Color.Lime;

                CellStyle csUPH050B = grd01.Styles.Add("UPH050B");
                csUPH050B.Font = new Font(this.Font, FontStyle.Bold);
                csUPH050B.ForeColor = Color.Black;
                csUPH050B.BackColor = Color.Yellow;

                CellStyle csUPH000B = grd01.Styles.Add("UPH000B");
                csUPH000B.Font = new Font(this.Font, FontStyle.Bold);
                csUPH000B.ForeColor = Color.White;
                csUPH000B.BackColor = Color.Red;

                CellStyle csUPH100 = grd01.Styles.Add("UPH100");
                csUPH100.Font = new Font(this.Font, FontStyle.Regular);
                csUPH100.ForeColor = Color.Black;
                csUPH100.BackColor = Color.Lime;

                CellStyle csUPH050 = grd01.Styles.Add("UPH050");
                csUPH050.Font = new Font(this.Font, FontStyle.Regular);
                csUPH050.ForeColor = Color.Black;
                csUPH050.BackColor = Color.Yellow;

                CellStyle csUPH000 = grd01.Styles.Add("UPH000");
                csUPH000.Font = new Font(this.Font, FontStyle.Regular);
                csUPH000.ForeColor = Color.White;
                csUPH000.BackColor = Color.Red;
                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STD_DATE);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        protected override void UI_Shown(EventArgs e)
        {
            this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
            this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

            this.cbo01_VINCD.DataBind("A3", false);
            this.cbo01_VINCD.SetValue("A3SP2I");

            InitGrid();
            BtnQuery_Click(null, null);
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                AxFlexGrid grd;
                HEParameterSet paramSet = new HEParameterSet();

                string QUERY;
                if (this.tabControl1.SelectedIndex == 0)
                {
                    grd = this.grd01;
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                    paramSet.Add("YMD", this.dtp01_PLAN_DATE.GetDateText());
                    paramSet.Add("VINCD", this.cbo01_VINCD.GetValue().ToString().Substring(2));
                    QUERY = "MES.PKG_TVOUT_SHIFT_UPH_BYLINE.GET_SHIFT_UPH_BYLINE";
                }
                else
                {
                    if (DateTime.Parse(this.dtp01_PLAN_DATE.GetDateText()) < DateTime.Parse("2019-11-13"))
                    {
                        QUERY = "MES.PKG_TVOUT_SHIFT_UPH_BYLINE.GET_LINE_STOP_DETAILS";
                    }
                    else
                    {
                        QUERY = "MES.PKG_TVOUT_SHIFT_UPH_BYLINE.GET_LINE_STOP_DETAILS_1";
                    }
                    grd = this.grd04;
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                    paramSet.Add("YMD", this.dtp01_PLAN_DATE.GetDateText());
                    paramSet.Add("VINCD", this.cbo01_VINCD.GetValue().ToString().Replace("A3",""));
                    ;
                }

                this.BeforeInvokeServer(true);

                DataTable dt = _WSCOM.ExecuteDataSet(QUERY, paramSet).Tables[0];

                _svrDate = getSVRTime();
                int iCurHour = Convert.ToInt16(_svrDate.Hour);
                if (this.tabControl1.SelectedIndex == 0) this.InitData(iCurHour, ref dt);
                dt.AcceptChanges();

                grd.SetValue(dt);
                ShowDataCount(dt);
                if (this.tabControl1.SelectedIndex == 0)
                {
                    this.MergeCols("DELI_TYPE");
                }
                else
                {
                    this.MergeCols("M4", "SUB_STOP", "DEPT");
                }
                this.SetGrdDisplay(iCurHour);

                this.grpbox2.Visible = false;

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
                DataSet source = AxFlexGrid.GetDataSourceSchema
                    (
                       "CORCD", "BIZCD", "PLAN_DATE", "PGN", "STOP_REASON", "TIMECD", "STOP_MIN", "CATEGORY", "STOP_REASON_1", "SEQ_NO", "DEPTCD", "CUSTCD", "VINCD"
                    );

                string corcd = this.UserInfo.CorporationCode;
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                string custcd = this.cbo01_VINCD.GetValue().ToString() == "A3YPI" ? "KVF2" : "KVF1";
                string vincd = this.cbo01_VINCD.GetValue().ToString().Replace("A3", "");
                string plan_date = this.dtp01_PLAN_DATE.GetDateText();
                string pgn = CURRENT_PGN;
                string line_type = CURRENT_LINE_TYPE;
                for (int hour = 1; hour <= 24; hour++)
                {
                    string hr = "cbo01_LINESTOP_REASON_" + hour.ToString("D2");
                    string hr1 = "cbo01_DEPTCD_" + hour.ToString("D2");
                    string hr2 = "txt02_LINESTOP_REASON_" + hour.ToString("D2");
                    string hr3 = "txt02_STOP_TIME_" + hour.ToString("D2");
                    string lbl = "lbl02_" + hour.ToString("D2");
                    AxComboBox ac = (AxComboBox)this.Controls.Find(hr, true)[0];
                    AxComboBox ac1 = (AxComboBox)this.Controls.Find(hr1, true)[0];
                    AxTextBox at = (AxTextBox)this.Controls.Find(hr2, true)[0];
                    AxTextBox at1 = (AxTextBox)this.Controls.Find(hr3, true)[0];

                    if (string.IsNullOrEmpty(ac.GetValue().ToString()) == false || string.IsNullOrEmpty(at1.GetValue().ToString()) == false)
                    {
                        source.Tables[0].Rows.Add
                            (
                                corcd,
                                bizcd,
                                plan_date,
                                pgn,
                                ac.GetValue().ToString(),
                                hour.ToString("D2"),
                                at1.GetValue().ToString(),
                                line_type,
                                at.GetValue().ToString(),
                                1,
                                ac1.GetValue().ToString(),
                                custcd,
                                vincd
                            );
                        //if (!this.IsSaveValid(source)) return;
                        this.BeforeInvokeServer(true);
                        _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", "MES.PKG_TVOUT_SHIFT_UPH_BYLINE", "SAVE_REMARK"), source);
                        this.AfterInvokeServer();
                    }
                }
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다.
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [사용자 정의]
        private void InitData(int iCurHour, ref DataTable dt)
        {
            string selDate = this.dtp01_PLAN_DATE.GetDateText();
            string curDate = _svrDate.ToString("yyyy-MM-dd");

            if (selDate != curDate) iCurHour = 7;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int iUPH = 0;
                int iUnit = 0;
                int iSumH = 0;
                int iSumSH1 = 0;
                int iSumSH2 = 0;
                int iSumSH3 = 0;
                int iTAVG = 0;
                int iSH1 = 0;
                int iSH2 = 0;
                int iSH3 = 0;

                int.TryParse(Convert.ToString(dt.Rows[i]["UPH"]), out iUPH);

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    DataColumn col = dt.Columns[j];
                    string colName = col.ColumnName;
                    if (colName.StartsWith("TOT"))
                    {
                        string sLineNm = Convert.ToString(dt.Rows[i]["LINE"]);
                        int hour = Convert.ToInt16(colName.Replace("TOT_", ""));
                        bool isNum = int.TryParse(Convert.ToString(dt.Rows[i][j]), out iUnit);

                        iTAVG += iUnit;
                        if (08 <= hour && hour <= 16) iSH1 += iUnit;
                        if (17 <= hour && hour <= 24) iSH2 += iUnit;
                        if (01 <= hour && hour <= 07) iSH3 += iUnit;

                        if (8 <= iCurHour && iCurHour <= 16)
                        {
                            if (hour <= iCurHour && hour >= 8) iSumSH1++;
                        }
                        else if (17 <= iCurHour && iCurHour <= 24)
                        {
                            iSumSH1 = 9;
                            if (hour <= iCurHour && hour >= 17) iSumSH2++;
                        }
                        else if (1 <= iCurHour && iCurHour <= 7)
                        {
                            iSumSH1 = 9;
                            iSumSH2 = 8;
                            if (hour <= iCurHour && hour >= 1) iSumSH3++;
                        }

                        if (iUnit == 0)
                        {
                            if (iCurHour > 0 && iCurHour < 8)
                            {
                                if (hour > iCurHour && hour < 8)
                                {
                                    dt.Rows[i][j] = DBNull.Value;
                                }
                            }
                            else
                            {
                                if (hour > iCurHour || hour < 8)
                                {
                                    dt.Rows[i][j] = DBNull.Value;
                                }
                            }
                        }
                    }
                }

                iSumH = iSumSH1 + iSumSH2 + iSumSH3;
                int dGAVG = iSumH == 0 ? 0 : (iTAVG / iSumH);
                int dAVG1 = iSumSH1 == 0 ? 0 : (iSH1 / iSumSH1);
                int dAVG2 = iSumSH2 == 0 ? 0 : (iSH2 / iSumSH2);
                int dAVG3 = iSumSH3 == 0 ? 0 : (iSH3 / iSumSH3);

                dt.Rows[i]["GAVG"] = dGAVG;// FX.Utils.Glb_FNS.GetO2D(iTAVG / iSumH);
                dt.Rows[i]["AVG1"] = dAVG1;// FX.Utils.Glb_FNS.GetO2D(iSH1 / iSumH);
                dt.Rows[i]["AVG2"] = dAVG2;// FX.Utils.Glb_FNS.GetO2D(iSH2 / iSumH);
                dt.Rows[i]["AVG3"] = dAVG3;// FX.Utils.Glb_FNS.GetO2D(iSH3 / iSumH);
            }
        }
        private void SetGrdDisplay(int iCurHour)
        {
            try
            {
                CellStyle cs = grd01.Styles.SelectedColumnHeader;
                cs.BackColor = Color.Cyan;
                CellRange rg;
                grd01.SelectionMode = SelectionModeEnum.Column;

                if (this.tabControl1.SelectedIndex == 0)
                {
                    string selDate = this.dtp01_PLAN_DATE.GetDateText();
                    string curDate = _svrDate.ToString("yyyy-MM-dd");

                    if (selDate != curDate) iCurHour = 7;

                    for (int j = 1; j < grd01.Cols.Count; j++)
                    {
                        //header
                        this.grd01.SetCellStyle(0, j, "TITLE");
                        this.grd01.SetCellStyle(1, j, "TITLE");
                    }

                    for (int i = 2; i < grd01.Rows.Count; i++)
                    {
                        #region Set Summary Style
                        int iCol = 0;
                        iCol = grd01.Cols["DELI_TYPE"].Index;
                        this.grd01.SetCellStyle(i, iCol, "DELI_TYPE");

                        iCol = grd01.Cols["LINE"].Index;
                        this.grd01.SetCellStyle(i, iCol, "LINE");

                        iCol = grd01.Cols["KMI_PLAN_QTY"].Index;
                        this.grd01.SetCellStyle(i, iCol, "KMI");
                        iCol = grd01.Cols["KMI_RSLT_QTY"].Index;
                        this.grd01.SetCellStyle(i, iCol, "KMI");

                        iCol = grd01.Cols["SAP_PLAN_QTY"].Index;
                        this.grd01.SetCellStyle(i, iCol, "SSAP");
                        iCol = grd01.Cols["SAP_RSLT_QTY"].Index;
                        this.grd01.SetCellStyle(i, iCol, "SSAP");

                        iCol = grd01.Cols["UPH"].Index;
                        this.grd01.SetCellStyle(i, iCol, "DELI_TYPE");

                        iCol = grd01.Cols["GAVG"].Index;
                        this.grd01.SetCellStyle(i, iCol, "AVG");
                        iCol = grd01.Cols["AVG1"].Index;
                        this.grd01.SetCellStyle(i, iCol, "AVG");
                        iCol = grd01.Cols["AVG2"].Index;
                        this.grd01.SetCellStyle(i, iCol, "AVG");
                        iCol = grd01.Cols["AVG3"].Index;
                        this.grd01.SetCellStyle(i, iCol, "AVG");
                        #endregion

                        int iUPH = 0;
                        int iUnit = 0;
                        int uph_50 = 0;

                        int.TryParse(Convert.ToString(grd01.Rows[i]["UPH"]), out iUPH);
                        uph_50 = Convert.ToInt16(iUPH / 2);

                        for (int hour = 1; hour <= 24; hour++)
                        {   //3 Shift에는 실적 표시
                            if (0 < hour && hour < 8)
                            {
                                if (hour == iCurHour)
                                {
                                    int iSPLAN = 0;
                                    int iSRSLT = 0;
                                    int.TryParse(Convert.ToString(grd01.Rows[i]["SAP_PLAN_QTY"]), out iSPLAN);
                                    int.TryParse(Convert.ToString(grd01.Rows[i]["SAP_RSLT_QTY"]), out iSRSLT);

                                    int iSap = grd01.Cols["SAP_RSLT_QTY"].Index;
                                    if (iSPLAN > iSRSLT) this.grd01.SetCellStyle(i, iSap, "UPH000B");
                                    else this.grd01.SetCellStyle(i, iSap, "UPH100B");
                                }
                                //continue;
                            }

                            string sCol = "TOT_" + hour.ToString("D2");
                            int j = grd01.Cols[sCol].Index;
                            this.grd01.SetCellStyle(i, j, "HOUR");

                            //if (hour == iCurHour)
                            //{
                            //    rg = grd01.GetCellRange(0, j, grd01.Rows.Count - 1, j);
                            //    grd01.Select(rg, false);
                            //}
                            int.TryParse(Convert.ToString(grd01.Rows[i][j]), out iUnit);

                            if (iCurHour > 0 && iCurHour < 8)
                            {
                                if (hour <= iCurHour || hour >= 8)
                                {
                                    SetUPHColor(iUnit, uph_50, iUPH, j, i);
                                }
                            }
                            else
                            {
                                if (hour <= iCurHour && hour >= 8)
                                {
                                    SetUPHColor(iUnit, uph_50, iUPH, j, i);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grd04.Rows.Count; i++)
                    {
                        for (int j = 1; j < grd04.Cols.Count; j++)
                        {
                            if (i == 0)
                            {
                                this.grd04.SetCellStyle(i, j, "TITLE");
                                continue;
                            }
                            string colName = grd04.Cols[j].Name;

                            if (colName.StartsWith("M4"))
                            { this.grd04.SetCellStyle(i, j, "M4"); }
                            if (colName.StartsWith("STOP_MIN"))
                            { { this.grd04.SetCellStyle(i, j, "STOP_MIN"); } }
                            if (colName.StartsWith("DEPT")) { this.grd04.SetCellStyle(i, j, "DEPT"); }
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
        }
        private void SetUPHColor(int iUnit, int uph_50, int iUPH, int j, int i = -1)
        {
            if (iUnit >= 0 && iUnit < uph_50)
            {
                this.grd01.SetCellStyle(i, j, "UPH000");
            }
            else if (iUnit >= uph_50 && iUnit < iUPH)
            {
                this.grd01.SetCellStyle(i, j, "UPH050");
            }
            else if (iUnit >= iUPH)
            {
                this.grd01.SetCellStyle(i, j, "UPH100");
            }
        }

        private void MergeCols(params string[] ColName)
        {
            for (int k = 0; k < ColName.Length; k++)
            {
                AxFlexGrid grd;
                int iS;
                int iE;
                if (ColName.Length == 1)
                {
                    grd = this.grd01;
                    iS = 2;//Start Row Index
                    iE = 0; //Start Row Index - 1
                }
                else
                {
                    grd = this.grd04;
                    iS = 1;//Start Row Index
                    iE = -1; //Start Row Index - 1
                }
                string sCurType = "";
                string sPreType = "";
                for (int i = iS; i < grd.Rows.Count; i++)
                {
                    iE++;
                    sCurType = Convert.ToString(grd.Rows[i][ColName[k]]);

                    if (sCurType != sPreType && sPreType != "")
                    {
                        grd.AddMerge(iS, iE, ColName[k], ColName[k]);
                        iS = iE + 1;

                    }
                    sPreType = sCurType;
                }
                if (grd.Rows.Count > iS) grd.AddMerge(iS, iE + 1, ColName[k], ColName[k]);
            }
        }

        private DateTime getSVRTime()
        {
            DateTime tDate = DateTime.Now;
            try
            {
                DataTable dt = _WSCOM.ExecuteDataSet("PKG_COM.GET_SVR_TIME").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    tDate = DateTime.ParseExact(dt.Rows[0]["SVRTIME"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentUICulture);
                }
            }
            catch
            {
            }
            return tDate;
        }
        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]
        private void grd01_CellChanged(object sender, RowColEventArgs e)
        {
            grd01.AutoSizeRow(e.Row);
        }
        #endregion

        # region [Other Functions]
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                string LINE = this.grd01.GetValue(row, "LINE").ToString();
                string PGN = this.grd01.GetValue(row, "PGN").ToString();
                string LINE_TYPE = this.grd01.GetValue(row, "TITLE").ToString();

                this.CURRENT_LINE_NM = LINE;
                this.CURRENT_PGN = PGN;
                this.CURRENT_LINE_TYPE = LINE_TYPE;
                this.LoadScreen(CURRENT_LINE_NM, CURRENT_PGN, CURRENT_LINE_TYPE);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadScreen(string Line_Name, string PGN, string Line_Type)
        {
            try
            {
                this.grpbox2.Visible = true;
                this.grpbox2.Text = Line_Name;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("YMD", this.dtp01_PLAN_DATE.GetDateText());
                paramSet.Add("VINCD", this.cbo01_VINCD.GetValue().ToString().Replace("A3",""));
                paramSet.Add("PGN", PGN);

                this.BeforeInvokeServer(true);

                DataTable dt = _WSCOM.ExecuteDataSet("MES.PKG_TVOUT_SHIFT_UPH_BYLINE.GET_STOP_REASON", paramSet).Tables[0];
                string cbx_value = "";

                switch (Line_Type)
                {
                    case "FG_LINE":
                        cbx_value = "0A"; break;
                    case "SFG_LINE":
                        cbx_value = "0B"; break;
                    case "INJ_LINE":
                        cbx_value = "0C"; break;
                    case "PAINT_LINE":
                        cbx_value = "0D"; break;
                }

                for (int i = 1; i <= 24; i++)
                {
                    string hr = "cbo01_LINESTOP_REASON_" + i.ToString("D2");
                    string hr1 = "cbo01_DEPTCD_" + i.ToString("D2");
                    string hr2 = "txt02_LINESTOP_REASON_" + i.ToString("D2");
                    string hr3 = "txt02_STOP_TIME_" + i.ToString("D2");
                    AxComboBox ac = (AxComboBox)this.Controls.Find(hr, true)[0];
                    AxComboBox ac1 = (AxComboBox)this.Controls.Find(hr1, true)[0];
                    AxTextBox at = (AxTextBox)this.Controls.Find(hr2, true)[0];
                    AxTextBox at1 = (AxTextBox)this.Controls.Find(hr3, true)[0];
                    ac.DataBind(cbx_value);
                    ac1.DataBind("CF");

                    ac.SetValue("");
                    ac1.SetValue("");
                    at.SetValue("");
                    at1.SetValue("");

                }
                if (dt.Rows.Count != 0)
                {
                    for (int hour = 0; hour < dt.Rows.Count; hour++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[hour]["TIMECD"].ToString()) == false)
                        {
                            string hr = "cbo01_LINESTOP_REASON_" + Convert.ToInt32(dt.Rows[hour]["TIMECD"]).ToString("D2");
                            string hr1 = "cbo01_DEPTCD_" + Convert.ToInt32(dt.Rows[hour]["TIMECD"]).ToString("D2");
                            string hr2 = "txt02_LINESTOP_REASON_" + Convert.ToInt32(dt.Rows[hour]["TIMECD"]).ToString("D2");
                            string hr3 = "txt02_STOP_TIME_" + Convert.ToInt32(dt.Rows[hour]["TIMECD"]).ToString("D2");
                            AxComboBox ac = (AxComboBox)this.Controls.Find(hr, true)[0];
                            AxComboBox ac1 = (AxComboBox)this.Controls.Find(hr1, true)[0];
                            AxTextBox at = (AxTextBox)this.Controls.Find(hr2, true)[0];
                            AxTextBox at1 = (AxTextBox)this.Controls.Find(hr3, true)[0];
                            ac.SetValue(dt.Rows[hour]["STOP_REASON"].ToString());
                            ac1.SetValue(dt.Rows[hour]["DEPTCD"].ToString());
                            at.SetValue(dt.Rows[hour]["STOP_REASON_1"].ToString());
                            at1.SetValue(dt.Rows[hour]["STOP_MIN"].ToString());
                            if (DateTime.Parse(this.dtp01_PLAN_DATE.GetDateText()) < DateTime.Parse("2019-11-13"))
                            {
                                ac.Text = dt.Rows[hour]["STOP_REASON"].ToString();
                                ac1.Text = dt.Rows[hour]["DEPTCD"].ToString();
                            }
                        }
                        else
                        {
                            this.cbo01_LINESTOP_REASON_08.SetValue(dt.Rows[0]["STOP_REASON"]);
                        }
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

        private void FnClick(object sender, EventArgs e)
        {
            var button = (AxButton)sender;
            string btn = button.Name.Substring(10);

            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema
                    (
                       "CORCD", "BIZCD", "PLAN_DATE", "PGN", "STOP_REASON", "TIMECD", "STOP_MIN", "CATEGORY", "STOP_REASON_1", "SEQ_NO", "DEPTCD", "CUSTCD", "VINCD"
                    );

                string corcd = this.UserInfo.CorporationCode;
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                string custcd = this.cbo01_VINCD.GetValue().ToString() == "A3YPI" ? "KVF2" : "KVF1";
                string vincd = this.cbo01_VINCD.GetValue().ToString().Replace("A3","");
                string plan_date = this.dtp01_PLAN_DATE.GetDateText();
                string pgn = CURRENT_PGN;
                string line_type = CURRENT_LINE_TYPE;

                string hr = "cbo01_LINESTOP_REASON_" + btn;
                string hr1 = "cbo01_DEPTCD_" + btn;
                string hr2 = "txt02_LINESTOP_REASON_" + btn;
                string hr3 = "txt02_STOP_TIME_" + btn;
                string lbl = "lbl02_" + btn;
                AxComboBox ac = (AxComboBox)this.Controls.Find(hr, true)[0];
                AxComboBox ac1 = (AxComboBox)this.Controls.Find(hr1, true)[0];
                AxTextBox at = (AxTextBox)this.Controls.Find(hr2, true)[0];
                AxTextBox at1 = (AxTextBox)this.Controls.Find(hr3, true)[0];
                if (string.IsNullOrEmpty(ac.GetValue().ToString()) == false || string.IsNullOrEmpty(at1.GetValue().ToString()) == false)
                {
                    source.Tables[0].Rows.Add
                        (
                            corcd,
                            bizcd,
                            plan_date,
                            pgn,
                            ac.GetValue().ToString(),
                            btn,
                            at1.GetValue().ToString(),
                            line_type,
                            at.GetValue().ToString(),
                            1,
                            ac1.GetValue().ToString(),
                            custcd,
                            vincd
                        );
                    //if (!this.IsSaveValid(source)) return;
                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", "MES.PKG_TVOUT_SHIFT_UPH_BYLINE", "SAVE_REMARK"), source);
                    this.AfterInvokeServer();
                }

                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다.
                ac.SetValue("");
                ac1.SetValue("");
                at.SetValue("");
                at1.SetValue("");
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
