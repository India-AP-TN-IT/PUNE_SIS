#region ▶ Description & History
/* 
 * 프로그램명 : PD40350 SPC (Pre Control Chart)
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
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
using C1.Win.C1Chart;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// SPC(Pre control Chart) - 계측 평균
    /// </summary>
    public partial class PD40350 : AxCommonBaseControl
    {
        //SPC DATA
        string[] m_strDate;
        double[] m_dAvg;

        //초품 데이터
        int[] m_iFirstPos = new int[4];
        double[] m_dFirstData = new double[4];

        bool chk_screw = false; //스크류 체결값

        //private IPD40350 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40350";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40350()
        {
            InitializeComponent();

            //_WSCOM  = ClientFactory.CreateChannel<IPD40350>("PD", "PD40350_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.EnabledActionFlag = false;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.Cols[0].Caption = this.GetLabel("DATE_TITLE");   //날짜

                this.grd01.Rows.Add();

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.EnabledActionFlag = false;
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "No.6", "");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "No.7", "");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "No.8", "");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "No.9", "");

                this.grd02.Cols[0].Caption = this.GetLabel("TYPE1_QTY");    //초품

                this.grd02.Rows.Add();


                this.grd07.Initialize();
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "실적일자", "RSLT_DATE", "RSLT_DATE");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "#1", "D1");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "#2", "D2");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "#3", "D3");


                this.crt01.ChartArea.AxisY.Text = this.GetLabel("AVERAGE"); //평균
                this.crt01.ChartArea.AxisX.Text = this.GetLabel("DATE_TITLE");  //날짜
                this.crt01.ChartGroups[0].ChartData.SeriesList.Clear();
                
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cbo01_PRDT_DIV.DataBind("A0", false);

                DataTable source = new DataTable();
                source.Columns.Add("CODE");
                source.Columns.Add("TEXT");

                source.Rows.Add("01", this.GetLabel("GRAPHDAY"));   //일평균
                source.Rows.Add("02", this.GetLabel("GRAPHEACH"));  //개별

                this.cbo01_INQ_DIV.DataBind(source, false);

                this.nme01_DATA_CNT.SetValue(0);
                this.nme01_INSPEC_POS.SetValue(1);
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
                string RSLT_SDATE = this.dtp01_RSLT_SDATE.GetDateText().ToString();
                string RSLT_EDATE = this.dtp01_RSLT_EDATE.GetDateText().ToString();

                DateTime sdate = new DateTime(int.Parse(RSLT_SDATE.Substring(0, 4)), int.Parse(RSLT_SDATE.Substring(5, 2)), int.Parse(RSLT_SDATE.Substring(8, 2)));
                DateTime edate = new DateTime(int.Parse(RSLT_EDATE.Substring(0, 4)), int.Parse(RSLT_EDATE.Substring(5, 2)), int.Parse(RSLT_EDATE.Substring(8, 2)));

                TimeSpan ts = edate - sdate;

                if (ts.TotalDays > 31)
                {
                    //MsgBox.Show("조회 기간은 한달을 넘을 수가 없습니다.");
                    MsgCodeBox.Show("PD00-0035");
                    return;
                }

                if (ts.TotalDays < 0)
                {
                    //MsgBox.Show("종료일이 시작일보다 빠릅니다.");
                    MsgCodeBox.Show("PD00-0036");
                    return;
                }

                if (this.cbl01_LINECD.GetValue().ToString() == "")
                {
                    //MsgBox.Show("{라인코드}를 선택하세요.");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.Show("PD00-0039");
                    return;
                }

                if (chk_screw == false && this.cbl01_PARTNO.GetValue().ToString() == "")
                {
                    //MsgBox.Show("{라인코드}를 선택하세요.");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.Show("PD00-0038");
                    return;
                }

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("DIV", this.cbo01_INQ_DIV.GetValue());
                set.Add("CNT", this.nme01_DATA_CNT.GetDBValue().ToString().Equals("0") ? "" : this.nme01_DATA_CNT.GetDBValue());
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("INSPEC_DIV", this.cbo01_INSPEC_DIV.GetValue());
                set.Add("INSPEC_ITEMCD", this.cbo01_INSPEC_ITEMCD.GetValue());
                set.Add("INSPEC_POS", this.nme01_INSPEC_POS.GetDBValue());
                set.Add("RSLT_SDATE", this.dtp01_RSLT_SDATE.GetDateText());
                set.Add("RSLT_EDATE", this.dtp01_RSLT_EDATE.GetDateText());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("PARTNO", this.cbl01_PARTNO.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source1 = _WSCOM.INQUERY_GRD1(bizcd, set);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_GRD1"), set, "OUT_CURSOR");

                DataSet source7 = _WSCOM_N.ExecuteDataSet("APG_PD40350.INQUERY_CPK", set, "OUT_CURSOR");
                grd07.SetValue(source7);
                this.AfterInvokeServer();

                //조회 건수 없는 경우
                if (source1.Tables[0].Rows.Count <= 0)
                {
                    //MsgBox.Show("조회 데이터가 없습니다!!");
                    //조회된 데이터가 없습니다.
                    MsgCodeBox.Show("CD00-0039");
                    return;
                }

                //조회 된 데이터 배열 저장

                grd01.Cols.Count = source1.Tables[0].Rows.Count + 1;

                m_strDate = new string[source1.Tables[0].Rows.Count];
                m_dAvg = new double[source1.Tables[0].Rows.Count];
                int i = 0;

                //초품 데이터 조회용 - 첫번째 조회 일자
                string strFirstDate = "";

                foreach (DataRow oRow in source1.Tables[0].Rows)
                {
                    string strBuf = "";

                    if (this.cbo01_INQ_DIV.GetValue().ToString().Equals("02"))
                    {
                        strBuf = i.ToString();
                    }
                    else
                    {
                        strBuf = source1.Tables[0].Rows[i].ItemArray[0].ToString().Substring(5);
                        //strBuf =  this.dtp01_RSLT_SDATE.GetValue().ToString().Substring(5);
                    }
                    m_strDate[i] = strBuf;
                    
                    if (i == 0)
                    {
                        strFirstDate = (string)Nvl(oRow["RSLT_DATE"].ToString(), "");
                    }

                    m_dAvg[i] = Convert.ToDouble(Nvl(oRow["D_VALUE"], 0));

                    grd01.SetData(0, i + 1, m_strDate[i]);
                    grd01.SetData(1, i + 1, string.Format("{0:0.0}", m_dAvg[i]));

                    grd01.Cols[i + 1].TextAlign = TextAlignEnum.CenterCenter;
                    grd01.Cols[i + 1].TextAlignFixed = TextAlignEnum.CenterCenter;

                    i++;
                }

                grd01.AutoSizeCols(-5);


                this.BeforeInvokeServer(true);
                //DataSet source2 = _WSCOM.INQUERY_GRD2(bizcd, set);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_GRD2"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                if (source2.Tables[0].Rows.Count > 5)
                {
                    //배열 할당
                    m_iFirstPos = new int[source2.Tables[0].Rows.Count - 5];
                    m_dFirstData = new double[source2.Tables[0].Rows.Count - 5];

                    for (int iLoop = 5; iLoop < source2.Tables[0].Rows.Count; iLoop++)
                    {
                        DataRow oRow = source2.Tables[0].Rows[iLoop];

                        //날짜
                        m_iFirstPos[iLoop - 5] = 0; // iPos;

                        //계측 값

                        //m_dFirstData[iLoop - 5] = (double)Nvl(oRow["RSLT_INSPEC"], "");
                        if (oRow["RSLT_INSPEC"].ToString() == "")
                            m_dFirstData[iLoop - 5] = 0;
                        else
                            m_dFirstData[iLoop - 5] = Convert.ToDouble(oRow["RSLT_INSPEC"].ToString());

                        if (grd02 != null)
                        {
                            if (grd02.Cols.Count > iLoop - 5)
                            {
                                grd02.SetData(grd02.Rows.Count - 1, iLoop - 5 + 1, string.Format("{0:0.0}", m_dFirstData[iLoop - 5]));
                            }
                        }
                    }
                }

                grd02.AutoSizeCols();

                //------------------------------------------
                //그래프 그리기

                //------------------------------------------
                Draw_Chart();


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

        #region [ 기타 이벤트 정의 ]

        private void cbo01_PRDT_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", bizcd);

                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataTable source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];
                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECDIV"), set1).Tables[0];
                //DataTable source2 = _WSCOM_MES.INQUERY_COMBO_INSPECDIV(bizcd, set1).Tables[0];

                this.cbo01_INSPEC_DIV.DataBind(source2, false);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
            set.Add("LANG_SET", this.UserInfo.Language);
            DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];
            //DataTable source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];

            cbl01_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
        }

        private void cbl01_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("ASSY", this.cbo01_PRDT_DIV.GetValue().ToString().Equals("A0A") ? "1" : "2");
            set.Add("LINECD", this.cbl01_LINECD.GetValue());
            set.Add("RSLT_SDATE", this.dtp01_RSLT_SDATE.GetDateText());
            set.Add("RSLT_EDATE", this.dtp01_RSLT_EDATE.GetDateText());
            set.Add("LANG_SET", this.UserInfo.Language);
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_RESULTPARTNO"), set).Tables[0];
            //DataTable source = _WSCOM_MES.INQUERY_COMBO_RESULTPARTNO(bizcd, set).Tables[0];

            this.cbl01_PARTNO.DataBind(source, "PARTNO", "PARTNO", this.GetLabel("PARTNOTITLE") + ";" + this.GetLabel("PARTNONM") + ";ALC;" + this.GetLabel("VINCD"), "L;L;C;L");   //품번;품명;ALC;차종
        }

        private void cbo01_INSPEC_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("INSPEC_DIV", this.cbo01_INSPEC_DIV.GetValue());

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECITEM"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_INSPECITEM(bizcd, set).Tables[0];

                this.cbo01_INSPEC_ITEMCD.DataBind(source, false);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            if (cbo01_INSPEC_DIV.SelectedValue.ToString() == "05")
            {
                chk_screw = true;
                cbl01_PARTNO.Visible = false;
                lbl05_PART_NO.Visible = false;
                lbl08_INSPECTION_POS.Visible = false;
                nme01_INSPEC_POS.Visible = false;
                lbl09_SEARCH_OPT.Visible = false;
                cbo01_INQ_DIV.Visible = false;
                lbl01_DATA_CNT.Visible = false;
                nme01_DATA_CNT.Visible = false;
            }
            else
            {
                chk_screw = false;
                cbl01_PARTNO.Visible = true;
                lbl05_PART_NO.Visible = true;
                lbl08_INSPECTION_POS.Visible = true;
                nme01_INSPEC_POS.Visible = true;
                lbl09_SEARCH_OPT.Visible = true;
                cbo01_INQ_DIV.Visible = true;
                lbl01_DATA_CNT.Visible = true;
                nme01_DATA_CNT.Visible = true;
            }
        }

        private void cbo01_INQ_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbo01_INQ_DIV.GetValue().ToString().Equals("01"))
                {
                    this.lbl01_DATA_CNT.Visible = false;
                    this.nme01_DATA_CNT.Visible = false;
                }
                else
                {
                    this.lbl01_DATA_CNT.Visible = true;
                    this.nme01_DATA_CNT.Visible = true;

                    this.nme01_DATA_CNT.SetValue(1);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_PD40350_TITLE_CheckedChanged(object sender, EventArgs e)
        {
            panel4.BringToFront();
            panel4.Visible = chk01_PD40350_TITLE.Checked;
        }

        private void btn01_QUERY_Click(object sender, EventArgs e)
        {
            SubCPK();
        }
        #endregion

        #region [사용자 정의 메서드]
        private void SubCPK()
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();
            HEParameterSet set = new HEParameterSet();
            set.Add("DIV", this.cbo01_INQ_DIV.GetValue());
            set.Add("CNT", this.nme01_DATA_CNT.GetDBValue().ToString().Equals("0") ? "" : this.nme01_DATA_CNT.GetDBValue());
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("INSPEC_DIV", this.cbo01_INSPEC_DIV.GetValue());
            set.Add("INSPEC_ITEMCD", this.cbo01_INSPEC_ITEMCD.GetValue());
            set.Add("INSPEC_POS", this.nme01_INSPEC_POS.GetDBValue());
            set.Add("RSLT_SDATE", this.dtp01_RSLT_SDATE.GetDateText());
            set.Add("RSLT_EDATE", this.dtp01_RSLT_EDATE.GetDateText());
            set.Add("LINECD", this.cbl01_LINECD.GetValue());
            set.Add("PARTNO", this.cbl01_PARTNO.GetValue());

            //DataSet source1 = _WSCOM.INQUERY_GRD1(bizcd, set);

            DataSet source7 = _WSCOM_N.ExecuteDataSet("APG_PD40350.INQUERY_CPK", set, "OUT_CURSOR");
            grd07.SetValue(source7);
        }

        private void Draw_Chart()
        {
            try
            {
                crt01.ChartGroups[0].ChartData.SeriesList.Clear();

                crt01.Header.Text = "Precontrol Chart";

                //-----------------------------------------
                // Zone 영역을 설정하기 위한 데이터

                //-----------------------------------------
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PARTNO", this.cbl01_PARTNO.GetValue());
                set.Add("INSPEC_DIV", this.cbo01_INSPEC_DIV.GetValue());
                set.Add("INSPEC_ITEMCD", this.cbo01_INSPEC_ITEMCD.GetValue());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSPEC_POS", this.nme01_INSPEC_POS.GetDBValue());
                //DataTable source = _WSCOM.INQUERY_LIMIT(bizcd, set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LIMIT"), set, "OUT_CURSOR").Tables[0];

                if (chk_screw == false && source.Rows.Count == 0)
                {
                    //MsgBox.Show("상/하한 기준 정보가 없습니다!!");
                    MsgCodeBox.Show("PD00-0037");
                    return;
                }

                double dMax;
                double dMin;

                if (chk_screw == true)
                {
                    dMax = Convert.ToDouble(22);
                    dMin = Convert.ToDouble(2);
                }
                else
                {
                    DataRow oRow = source.Rows[0];

                    dMax = Convert.ToDouble(oRow["MAX_VALUE"]);
                    dMin = Convert.ToDouble(oRow["MIN_VALUE"]);
                }

                double dStd = dMin + (dMax - dMin) / 2.0;

                double dMidMax = dStd + ((dMax - dStd) / 2.0);
                double dMidMin = dStd - ((dStd - dMin) / 2.0);

                double dMinLimit = dMin - ((dMax - dStd) / 2.0);
                double dMaxLimit = dMax + ((dMax - dStd) / 2.0);


                crt01.ChartArea.AxisY.Max = dMaxLimit;
                crt01.ChartArea.AxisY.Min = dMinLimit;


                //-----------------------------------------
                // Zone 생성 및 색상 처리
                //-----------------------------------------
                //Zone 생성
                crt01.ChartArea.PlotArea.AlarmZones.Clear();
                AlarmZonesCollection zones = crt01.ChartArea.PlotArea.AlarmZones;

                zones.AddNewZone();
                zones[zones.Count - 1].BackColor = Color.Pink;
                zones[zones.Count - 1].UpperExtent = dMaxLimit;
                zones[zones.Count - 1].LowerExtent = dMax;
                zones[zones.Count - 1].Visible = true;

                zones.AddNewZone();
                zones[zones.Count - 1].BackColor = Color.Gold;
                zones[zones.Count - 1].UpperExtent = dMax;
                zones[zones.Count - 1].LowerExtent = dMidMax;
                zones[zones.Count - 1].Visible = true;

                zones.AddNewZone();
                zones[zones.Count - 1].BackColor = Color.LimeGreen;
                zones[zones.Count - 1].UpperExtent = dMidMax;
                zones[zones.Count - 1].LowerExtent = dStd;
                zones[zones.Count - 1].Visible = true;

                zones.AddNewZone();
                zones[zones.Count - 1].BackColor = Color.LimeGreen;
                zones[zones.Count - 1].UpperExtent = dStd;
                zones[zones.Count - 1].LowerExtent = dMidMin;
                zones[zones.Count - 1].Visible = true;

                zones.AddNewZone();
                zones[zones.Count - 1].BackColor = Color.Gold;
                zones[zones.Count - 1].UpperExtent = dMidMin;
                zones[zones.Count - 1].LowerExtent = dMin;
                zones[zones.Count - 1].Visible = true;

                zones.AddNewZone();
                zones[zones.Count - 1].BackColor = Color.Pink;
                zones[zones.Count - 1].UpperExtent = dMin;
                zones[zones.Count - 1].LowerExtent = dMinLimit;
                zones[zones.Count - 1].Visible = true;

                //-----------------------------------------
                //X, Y 축 기준 데이터 설정
                //-----------------------------------------
                //Y-축

                crt01.ChartArea.AxisY.Max = dMaxLimit;
                crt01.ChartArea.AxisY.Min = dMinLimit;
                crt01.ChartArea.AxisY.Text = "";
                crt01.ChartArea.AxisY.Font = new Font("굴림", 8, FontStyle.Regular);

                //crt01.ChartArea.AxisY.UnitMajor = Convert.ToInt32(dMaxLimit - dMinLimit) / 6;

                crt01.ChartArea.AxisY.AutoMajor = true;
                crt01.ChartArea.AxisY.AutoMinor = false;
                crt01.ChartArea.AxisY.AutoMax = false;
                crt01.ChartArea.AxisY.AutoMin = false;
                crt01.ChartArea.AxisY.AutoOrigin = false;

                crt01.ChartArea.AxisY.TickMajor = TickMarksEnum.None;
                crt01.ChartArea.AxisY.TickMinor = TickMarksEnum.None;
                crt01.ChartArea.AxisY.TickLabels = TickLabelsEnum.NextToAxis;

                crt01.ChartArea.AxisY.ValueLabels.Clear();
                crt01.ChartArea.AxisY.ValueLabels.Add(dMinLimit, Convert.ToInt32(dMinLimit).ToString());
                crt01.ChartArea.AxisY.ValueLabels.Add(dMidMin, Convert.ToInt32(dMidMin).ToString());
                crt01.ChartArea.AxisY.ValueLabels.Add(dMin, Convert.ToInt32(dMin).ToString());
                crt01.ChartArea.AxisY.ValueLabels.Add(dStd, Convert.ToInt32(dStd).ToString());
                crt01.ChartArea.AxisY.ValueLabels.Add(dMax, Convert.ToInt32(dMax).ToString());
                crt01.ChartArea.AxisY.ValueLabels.Add(dMidMax, Convert.ToInt32(dMidMax).ToString());
                crt01.ChartArea.AxisY.ValueLabels.Add(dMaxLimit, Convert.ToInt32(dMaxLimit).ToString());

                crt01.ChartArea.AxisY.AnnoMethod = AnnotationMethodEnum.ValueLabels;

                //X-축

                crt01.ChartArea.AxisX.Min = -1;
                crt01.ChartArea.AxisX.Max = m_strDate.Length;
                crt01.ChartArea.AxisX.Text = this.GetLabel("WORK_DATE"); //작업일자
                crt01.ChartArea.AxisX.Font = new Font("굴림", 8, FontStyle.Regular);

                //-----------------------------------------
                // 그래프 데이터 등록
                //-----------------------------------------
                if (m_dAvg == null)
                {
                    return;
                }
                ChartData data = crt01.ChartGroups[0].ChartData;
                ChartDataSeriesCollection series = data.SeriesList;

                //plot the temperature
                ChartDataSeries SeriesTemp = series.AddNewSeries();
                SeriesTemp.Label = "";
                SeriesTemp.LineStyle.Pattern = LinePatternEnum.Solid;
                SeriesTemp.LineStyle.Color = Color.Black;
                SeriesTemp.LineStyle.Thickness = 3;
                SeriesTemp.SymbolStyle.Shape = SymbolShapeEnum.Diamond;
                SeriesTemp.SymbolStyle.Color = Color.Red;
                SeriesTemp.X.CopyDataIn(m_strDate);
                SeriesTemp.Y.CopyDataIn(m_dAvg);
                SeriesTemp = null;


                //-----------------------------------------
                // 초품 그래프 출력
                //-----------------------------------------
                if (m_dFirstData == null)
                {
                    return;
                }

                ChartData data2 = crt01.ChartGroups[0].ChartData;
                ChartDataSeriesCollection series2 = data.SeriesList;

                ChartDataSeries SeriesDot = series.AddNewSeries();
                SeriesDot.Label = this.GetLabel("DOT"); //점
                SeriesDot.LineStyle.Pattern = LinePatternEnum.None;
                SeriesDot.SymbolStyle.Shape = SymbolShapeEnum.Diamond;
                SeriesDot.SymbolStyle.Size = 10;
                SeriesDot.SymbolStyle.Color = Color.Blue;

                SeriesDot.X.CopyDataIn(m_iFirstPos);
                SeriesDot.Y.CopyDataIn(m_dFirstData);
                SeriesDot = null;

            }
            catch (Exception ex)
            {
                MsgBox.Show("Error! : " + ex.Message);
            }
        }

        #endregion


        
    }
}
