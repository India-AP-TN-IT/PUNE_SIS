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
    /// <b> JIT Delivery Status </b>
    /// </summary>
    public partial class PD50025 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
        private DateTime _svrDate;
        private const string _IntFormat = "###,###,###,###,##0";

        public PD50025()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ Initialization ]

        private void PD50025_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel3;
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
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(1, 1);
                this.grd01.Font = new Font("맑은 고딕", 8);

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "ITEM(09-09)", "ITEM", "ITEM");
                //Changed name from KMI to KIN
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "KIN PLAN", "KMI_PLAN", "KMI_PLAN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "TOTAL", "DELI_TOTAL", "DELI_TOTAL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "BASE", "KMI_BASE_STOCK", "KMI_BASE_STOCK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "DELIVERY", "DELI_QTY", "DELI_QTY");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "08", "TOT_08", "TOT_08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "09", "TOT_09", "TOT_09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "10", "TOT_10", "TOT_10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "11", "TOT_11", "TOT_11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "12", "TOT_12", "TOT_12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "13", "TOT_13", "TOT_13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "14", "TOT_14", "TOT_14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "15", "TOT_15", "TOT_15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "16", "TOT_16", "TOT_16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "17", "TOT_17", "TOT_17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "18", "TOT_18", "TOT_18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "19", "TOT_19", "TOT_19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "20", "TOT_20", "TOT_20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "21", "TOT_21", "TOT_21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "22", "TOT_22", "TOT_22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "23", "TOT_23", "TOT_23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "24", "TOT_24", "TOT_24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "01", "TOT_01", "TOT_01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "02", "TOT_02", "TOT_02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "03", "TOT_03", "TOT_03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "04", "TOT_04", "TOT_04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "05", "TOT_05", "TOT_05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "06", "TOT_06", "TOT_06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "07", "TOT_07", "TOT_07");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "KMI_PLAN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_TOTAL");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "KMI_BASE_STOCK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_QTY");
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

                this.grd01.Cols["KMI_PLAN"].Format = _IntFormat;
                this.grd01.Cols["DELI_TOTAL"].Format = _IntFormat;
                this.grd01.Cols["KMI_BASE_STOCK"].Format = _IntFormat;
                this.grd01.Cols["DELI_QTY"].Format = _IntFormat;

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



                grd01.Cols.Frozen = 1;


                this.grd02.AllowEditing = false;
                this.grd02.Initialize(1, 1);
                this.grd02.Font = new Font("맑은 고딕", 8);

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 280, "ITEM(09-09)", "PGNDESC", "PGNDESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "ORDER CNT", "ODER_CNT", "ODER_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "OUR CNT", "OUR_CNT", "OUR_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "QTY", "QTY", "QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "OUR QTY", "OUR_QTY", "OUR_QTY");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "ODER_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "OUR_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "OUR_QTY");

                this.grd02.Cols["ODER_CNT"].Format = _IntFormat;
                this.grd02.Cols["OUR_CNT"].Format = _IntFormat;
                this.grd02.Cols["QTY"].Format = _IntFormat;
                this.grd02.Cols["OUR_QTY"].Format = _IntFormat;

                CellStyle csTITLE = grd01.Styles.Add("TITLE");
                CellStyle csTITLE1 = grd02.Styles.Add("TITLE");
                csTITLE.Font = new Font(this.Font, FontStyle.Bold);
                csTITLE.ForeColor = Color.White;
                csTITLE.BackColor = Color.Black;
                csTITLE1.Font = new Font(this.Font, FontStyle.Bold);
                csTITLE1.ForeColor = Color.White;
                csTITLE1.BackColor = Color.Black;

                CellStyle csLBL = grd01.Styles.Add("LBL");
                CellStyle csLBL1 = grd02.Styles.Add("LBL");
                csLBL.Font = new Font(this.Font, FontStyle.Bold);
                csLBL.ForeColor = Color.Black;
                csLBL.BackColor = Color.LightGray;
                csLBL1.Font = new Font(this.Font, FontStyle.Bold);
                csLBL1.ForeColor = Color.Black;
                csLBL1.BackColor = Color.LightGray;

                CellStyle csTOTAL = grd01.Styles.Add("TOTAL");
                CellStyle csTOTAL1 = grd02.Styles.Add("TOTAL");
                csTOTAL.Font = new Font(this.Font, FontStyle.Bold);
                csTOTAL.ForeColor = Color.White;
                csTOTAL.BackColor = Color.DarkBlue;
                csTOTAL1.Font = new Font(this.Font, FontStyle.Bold);
                csTOTAL1.ForeColor = Color.White;
                csTOTAL1.BackColor = Color.DarkBlue;

                CellStyle csHOUR = grd01.Styles.Add("HOUR");
                csHOUR.Font = new Font(this.Font, FontStyle.Regular);
                csHOUR.ForeColor = Color.Black;
                csHOUR.BackColor = Color.Transparent;

                CellStyle csUPH100 = grd01.Styles.Add("UPH100");
                CellStyle cs1UPH100 = grd02.Styles.Add("UPH100");
                csUPH100.Font = new Font(this.Font, FontStyle.Regular);
                csUPH100.ForeColor = Color.Black;
                csUPH100.BackColor = Color.Lime;
                cs1UPH100.Font = new Font(this.Font, FontStyle.Regular);
                cs1UPH100.ForeColor = Color.Black;
                cs1UPH100.BackColor = Color.Lime;

                CellStyle csUPH050 = grd01.Styles.Add("UPH050");
                csUPH050.Font = new Font(this.Font, FontStyle.Regular);
                csUPH050.ForeColor = Color.Black;
                csUPH050.BackColor = Color.Yellow;

                CellStyle csUPH000 = grd01.Styles.Add("UPH000");
                CellStyle cs1UPH000 = grd02.Styles.Add("UPH000");
                csUPH000.Font = new Font(this.Font, FontStyle.Regular);
                csUPH000.ForeColor = Color.White;
                csUPH000.BackColor = Color.Red;
                cs1UPH000.Font = new Font(this.Font, FontStyle.Regular);
                cs1UPH000.ForeColor = Color.White;
                cs1UPH000.BackColor = Color.Red;

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

            InitGrid();
            BtnQuery_Click(null, null);
        }

        #endregion

        #region [ Event Definition for Buttons ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                AxFlexGrid grd;
                HEParameterSet set = new HEParameterSet();

                string QUERY;
                if (this.tabControl1.SelectedIndex == 0)
                {
                    grd = this.grd01;
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                    set.Add("YMD", this.dtp01_PLAN_DATE.GetDateText());
                    QUERY = "MES.PKG_TVOUT_JIT_DELIVERY_MONITORING.GET_JIT_DELIVERY_MONITORING";
                }
                else
                {
                    grd = this.grd02;
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                    set.Add("YMD", this.dtp01_PLAN_DATE.GetDateText());
                    QUERY = "MES.PKG_TVOUT_JIT_DELIVERY_MONITORING.GET_JIT_STOCK";
                }


                this.BeforeInvokeServer(true);

                DataTable dt = _WSCOM.ExecuteDataSet(QUERY, set).Tables[0];

                _svrDate = getSVRTime();
                int iCurHour = Convert.ToInt16(_svrDate.Hour);
                this.InitData(iCurHour, ref dt);
                dt.AcceptChanges();
                grd.SetValue(dt);
                ShowDataCount(dt);

                this.SetGrdDisplay(iCurHour);
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

        #region [ Event Definition for Other ]
        private void InitData(int iCurHour, ref DataTable dt)
        {
            string selDate = this.dtp01_PLAN_DATE.GetDateText();
            string curDate = _svrDate.ToString("yyyy-MM-dd");

            if (selDate != curDate) iCurHour = 7;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    DataColumn col = dt.Columns[j];
                    string colName = col.ColumnName;
                    if (colName.StartsWith("TOT"))
                    {
                        int colHour = Convert.ToInt16(colName.Replace("TOT_", ""));
                        int iUnit = 0;
                        bool isNum = int.TryParse(Convert.ToString(dt.Rows[i][j]), out iUnit);
                        if (iUnit == 0)
                        {
                            if (iCurHour > 0 && iCurHour < 8)
                            {
                                if (colHour > iCurHour && colHour < 8)
                                {
                                    dt.Rows[i][j] = DBNull.Value;
                                }
                            }
                            else
                            {
                                if (colHour > iCurHour || colHour < 8)
                                {
                                    dt.Rows[i][j] = DBNull.Value;
                                }
                            }
                        }
                    }
                }
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
                grd02.SelectionMode = SelectionModeEnum.Column;

                string selDate = this.dtp01_PLAN_DATE.GetDateText();
                string curDate = _svrDate.ToString("yyyy-MM-dd");

                if (selDate != curDate) iCurHour = 7;

                if (this.tabControl1.SelectedIndex == 0)
                {
                    for (int i = 0; i < grd01.Rows.Count; i++)
                    {
                        for (int j = 1; j < grd01.Cols.Count; j++)
                        {
                            //header
                            if (i == 0)
                            {
                                this.grd01.SetCellStyle(i, j, "TITLE");
                                continue;
                            }
                            string colName = grd01.Cols[j].Name;

                            if (colName.StartsWith("ITEM"))
                            { this.grd01.SetCellStyle(i, j, "LBL"); }
                            else if (colName.StartsWith("KMI_PLAN") || colName.StartsWith("DELI_TOTAL") || colName.StartsWith("KMI_BASE_STOCK") || colName.StartsWith("DELI_QTY"))
                            { this.grd01.SetCellStyle(i, j, "TOTAL"); }
                        }

                        int iSumHourRSLT = 0;
                        int iPLAN = 0;
                        int iSTOCK = 0;
                        int iRSLT = 0;

                        int.TryParse(Convert.ToString(grd01.Rows[i]["KMI_PLAN"]), out iPLAN);
                        int.TryParse(Convert.ToString(grd01.Rows[i]["KMI_BASE_STOCK"]), out iSTOCK);

                        for (int hour = 8; hour <= 24; hour++)
                        {
                            string sCol = "TOT_" + hour.ToString("D2");
                            iRSLT = 0;
                            int.TryParse(Convert.ToString(grd01.Rows[i][sCol]), out iRSLT);

                            if (hour <= iCurHour && hour >= 8)
                            {
                                iSumHourRSLT += iRSLT;

                                SetRSLTColor(iPLAN, iSTOCK, iSumHourRSLT, hour - 2, i);
                            }
                            else if (iCurHour < 8)
                            {
                                iSumHourRSLT += iRSLT;

                                SetRSLTColor(iPLAN, iSTOCK, iSumHourRSLT, hour - 2, i);
                            }

                            if (hour == iCurHour)
                            {
                                rg = grd01.GetCellRange(0, hour - 2, grd01.Rows.Count - 1, hour - 2);
                                grd01.Select(rg, false);
                            }
                        }
                        for (int hour = 1; hour <= 7; hour++)
                        {
                            string sCol = "TOT_" + hour.ToString("D2");
                            iRSLT = 0;
                            int.TryParse(Convert.ToString(grd01.Rows[i][sCol]), out iRSLT);
                            if (hour <= iCurHour && iCurHour < 8)
                            {
                                iSumHourRSLT += iRSLT;

                                SetRSLTColor(iPLAN, iSTOCK, iSumHourRSLT, hour + 22, i);
                            }

                            if (hour == iCurHour)
                            {
                                rg = grd01.GetCellRange(0, hour + 22, grd01.Rows.Count - 1, hour + 22);
                                grd01.Select(rg, false);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grd02.Rows.Count; i++)
                    {
                        for (int j = 1; j < grd02.Cols.Count; j++)
                        {
                            if (i == 0)
                            {
                                this.grd02.SetCellStyle(i, j, "TITLE");
                                continue;
                            }
                            string colName = grd02.Cols[j].Name;

                            if (colName.StartsWith("PGNDESC"))
                            { this.grd02.SetCellStyle(i, j, "LBL"); }
                            else if (colName.StartsWith("ODER_CNT") || colName.StartsWith("QTY"))
                            { this.grd02.SetCellStyle(i, j, "TOTAL"); }

                            int iPLAN = 0;
                            int iSTOCK = 0;
                            if (colName.StartsWith("OUR_CNT"))
                            {
                                int.TryParse(Convert.ToString(grd02.Rows[i]["ODER_CNT"]), out iPLAN);
                                int.TryParse(Convert.ToString(grd02.Rows[i]["OUR_CNT"]), out iSTOCK);
                                SetRSLTColor(iPLAN, iSTOCK, 0, j, i);
                            }
                            if (colName.StartsWith("OUR_QTY"))
                            {
                                int.TryParse(Convert.ToString(grd02.Rows[i]["QTY"]), out iPLAN);
                                int.TryParse(Convert.ToString(grd02.Rows[i]["OUR_QTY"]), out iSTOCK);
                                SetRSLTColor(iPLAN, iSTOCK, 0, j, i);
                            }

                        }
                    }
                }
            }
            catch
            {
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

        private void SetRSLTColor(int iPLAN, int iSTOCK, int iSumHourRSLT, int j, int i = -1)
        {
            AxFlexGrid grd;
            if (this.tabControl1.SelectedIndex == 0)
            {
                grd = this.grd01;
            }
            else
            {
                grd = this.grd02;
            }
            if (iPLAN > iSTOCK + iSumHourRSLT)
            {
                if (i > 0) grd.SetCellStyle(i,j, "UPH000");
            }
            else
            {
                if (i > 0) grd.SetCellStyle(i, j, "UPH100");
            }
        }

        #endregion

    }
}
