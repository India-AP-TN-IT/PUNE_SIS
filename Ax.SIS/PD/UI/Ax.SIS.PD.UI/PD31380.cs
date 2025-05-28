
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
    public partial class PD31380 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
        private DateTime _svrDate;
        private const string _IntFormat = "###,###,###,###,##0";

        public PD31380()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]


        private void InitGrid()
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(1, 1);
                this.grd01.Font = new Font("맑은 고딕", 8);

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "LINE", "LINE", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "SHIFT", "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "STOP(m)", "TSPAN", "TSPAN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "LINE_STOP", "LINE_STOP", "LINE_STOP");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 360, "MOLD", "MOLDNM", "MOLDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "UPH", "UPH", "UPH");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "PLAN", "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "RSLT", "RSLT_QTY", "RSLT_QTY");
                
                
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
                this.grd01.AllowMerging = AllowMergingEnum.RestrictAll;
                this.grd01.Cols["LINE"].AllowMerging = true;
                this.grd01.Cols["SHIFT"].AllowMerging = true;
                this.grd01.Cols["TSPAN"].AllowMerging = true;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "UPH");
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

                this.grd01.Cols["PLAN_QTY"].Format = _IntFormat;
                this.grd01.Cols["RSLT_QTY"].Format = _IntFormat;
                this.grd01.Cols["UPH"].Format = _IntFormat;

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



                grd01.Cols.Frozen = 5;

                CellStyle csTITLE = grd01.Styles.Add("TITLE");
                csTITLE.Font = new Font(this.Font, FontStyle.Bold);
                csTITLE.ForeColor = Color.White;
                csTITLE.BackColor = Color.Black;

                CellStyle csLBL = grd01.Styles.Add("LBL");
                csLBL.Font = new Font(this.Font, FontStyle.Bold);
                //csLBL.ForeColor = Color.Black;
                //csLBL.BackColor = Color.LightSteelBlue;

                CellStyle csTOTAL = grd01.Styles.Add("TOTAL");
                csTOTAL.Font = new Font(this.Font, FontStyle.Bold);
                csTOTAL.ForeColor = Color.White;
                csTOTAL.BackColor = Color.DarkBlue;

                CellStyle csHOUR = grd01.Styles.Add("HOUR");
                csHOUR.Font = new Font(this.Font, FontStyle.Regular);
                csHOUR.ForeColor = Color.Black;
                csHOUR.BackColor = Color.Transparent;

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

            InitGrid();
            BtnQuery_Click(null, null);
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = DateTime.Now.ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("YMD", this.dtp01_PLAN_DATE.GetDateText());

                this.BeforeInvokeServer(true);

                DataTable dt = _WSCOM.ExecuteDataSet("MES.PKG_TVOUT_INJECTION_LINE_PLANRESULT_SH.GET_INJECTION_LINE_PLANRESULT", paramSet).Tables[0];

                _svrDate = getSVRTime();
                int iCurHour = Convert.ToInt16(_svrDate.Hour);
                this.InitData(iCurHour, ref dt);
                dt.AcceptChanges();
                this.grd01.SetValue(dt);
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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]
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
                        string sLineNm = Convert.ToString(dt.Rows[i]["LINE"]);
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
        private int GetColNum(string name)
        {
            for(int i=0;i<grd01.Cols.Count; i++)
            {
                if( name == grd01.Cols[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }
        private void SetGrdDisplay(int iCurHour)
        {
            try
            {
                CellStyle cs = grd01.Styles.SelectedColumnHeader;
                cs.BackColor = Color.Cyan;
                CellRange rg;
                grd01.SelectionMode = SelectionModeEnum.Column;

                string selDate = this.dtp01_PLAN_DATE.GetDateText();
                string curDate = _svrDate.ToString("yyyy-MM-dd");

                if (selDate != curDate) iCurHour = 7;

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

                        this.grd01.SetCellStyle(i, j, "HOUR");

                        string colName = grd01.Cols[j].Name;
                        if (colName.StartsWith("TOT"))
                        {
                            string sLineNm = Convert.ToString(grd01.Rows[i]["LINE"]);
                            int colHour = Convert.ToInt16(colName.Replace("TOT_", ""));

                            if (colHour == iCurHour)
                            {
                                rg = grd01.GetCellRange(0, j, grd01.Rows.Count - 1, j);
                                grd01.Select(rg, false);
                            }

                            int iUPH = 0;
                            bool isNumUPH = int.TryParse(Convert.ToString(grd01.Rows[i]["UPH"]), out iUPH);
                            int uph_50 = Convert.ToInt16(iUPH / 2);

                            int iUnit = 0;
                            bool isNum = int.TryParse(Convert.ToString(grd01.Rows[i][j]), out iUnit);

                            if (!(sLineNm.StartsWith("INJECT") || sLineNm.StartsWith("PAINT")))
                            {
                                if (iCurHour > 0 && iCurHour < 8)
                                {
                                    if (colHour <= iCurHour || colHour >= 8)
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
                                }
                                else
                                {
                                    if (colHour <= iCurHour && colHour >= 8)
                                    {
                                        if (iUnit > 0 && iUnit < uph_50)
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
                                }
                            }

                            if (!isNum) this.grd01.SetCellStyle(i, j, "HOUR");
                        }
                        else if (colName.StartsWith("LINE") || colName.StartsWith("INSTALL_POS"))
                        { this.grd01.SetCellStyle(i, j, "LBL"); }
                        else if (colName.StartsWith("PLAN") || colName.StartsWith("RSLT") || colName.StartsWith("UPH"))
                        { this.grd01.SetCellStyle(i, j, "TOTAL"); }

                        
                    }
                    if(grd01.GetValue(i, "LINE_STOP").ToString() == "Y")
                    {
                        int col = GetColNum("LINE");
                        grd01.SetCellStyle(i, col, "UPH000");
                    }
                    if (grd01.GetValue(i, "MOLDNM").ToString().Contains("▶"))
                    {
                        int col = GetColNum("MOLDNM");
                        grd01.SetCellStyle(i, col, "UPH050");
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
        #endregion

        #region [ 유효성 검사 ]
        #endregion



    }
}
