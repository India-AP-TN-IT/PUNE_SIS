#region ▶ Description & History
/* 
 * 프로그램명 : 일일 클레임 종합현황조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-08-20      배명희      신규 생성
 *              2014-08-25      배명희      차트 스타일 변경(라인 타입 색깔 지정 및 기타 설정 변경)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;

using HE.Framework.ServiceModel;
using System.Drawing;

using System.Linq;
using System.Collections;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>일일 클레임 종합현황조회</b>   
    /// </summary>
    public partial class QA31431 : AxCommonBaseControl
    {

        #region [필드에 대한 정의]

        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA31431";
        private string PAKAGE_NAME_QA21411 = "APG_QA21411";
        ArrayList ar = new ArrayList();
        AxCheckBox ck;
        #endregion

        #region [생성자에 대한 정의]
        
        public QA31431()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

        }
        #endregion

        #region [초기화 작업에 대한 정의]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                ck = new AxCheckBox();
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);                
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                //if (this.UserInfo.IsAdmin == "Y")                
                //    this.cbo01_BIZCD.Enabled = true;                
                //else                
                //    this.cbo01_BIZCD.Enabled = false;

                DataSet source = this.GetTypeCode("QA", "QD", "QE");
                this.cbo01_TYPE.DataBind(source.Tables[1], true);
                this.cbo01_USE_MONTH.DataBind(source.Tables[0], false);
                this.cbo01_FILENO.DataBind(source.Tables[2], true);

                this.SetBindComboBox();


                this.dte01_PROD_SAL_SDATE.DataType = typeof(int);
                this.dte01_PROD_SAL_SDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_SDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_SDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_PROD_SAL_SDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_SDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_SDATE.EditFormat.CustomFormat = "########";
                this.dte01_PROD_SAL_SDATE.EditFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_EDATE.DataType = typeof(int);
                this.dte01_PROD_SAL_EDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_EDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_EDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_PROD_SAL_EDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_EDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_PROD_SAL_EDATE.EditFormat.CustomFormat = "########";
                this.dte01_PROD_SAL_EDATE.EditFormat.EmptyAsNull = true;
                this.dte01_PROD_SAL_SDATE.TextAlign = HorizontalAlignment.Center;
                this.dte01_PROD_SAL_EDATE.TextAlign = HorizontalAlignment.Center;

                string sdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddYears(-10).ToString("yyyyMMdd");
                string edate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyyMMdd");
                this.dte01_PROD_SAL_SDATE.SetValue(sdate);
                this.dte01_PROD_SAL_EDATE.SetValue(edate);

               
                this.dte01_REPR_CONF_SDATE.DataType = typeof(int);
                this.dte01_REPR_CONF_SDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_SDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_SDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_REPR_CONF_SDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_SDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_SDATE.EditFormat.CustomFormat = "########";
                this.dte01_REPR_CONF_SDATE.EditFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_EDATE.DataType = typeof(int);
                this.dte01_REPR_CONF_EDATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_EDATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_EDATE.DisplayFormat.CustomFormat = "####-##-##";
                this.dte01_REPR_CONF_EDATE.DisplayFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_EDATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.dte01_REPR_CONF_EDATE.EditFormat.CustomFormat = "########";
                this.dte01_REPR_CONF_EDATE.EditFormat.EmptyAsNull = true;
                this.dte01_REPR_CONF_SDATE.TextAlign = HorizontalAlignment.Center;
                this.dte01_REPR_CONF_EDATE.TextAlign = HorizontalAlignment.Center;

                string sdate2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-12).ToString("yyyyMMdd");
                this.dte01_REPR_CONF_SDATE.SetValue(sdate2);
                this.dte01_REPR_CONF_EDATE.SetValue(edate);

                #region [grd01 : 클레임현황]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);                

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "구분", "DIVNM1", "DIVNM1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "구분", "DIVNM2", "DIVNM2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "SEQ", "SEQ", "SEQ");
                this.grd01.Cols.Frozen = 2;

                this.grd01.AllowMerging = AllowMergingEnum.RestrictAll;

                this.grd01.Rows[0].AllowMerging = true;
                this.grd01.Cols["DIVNM1"].AllowMerging = true;
                this.grd01.Cols["DIVNM2"].AllowMerging = true;
                
                this.grd01.Styles[CellStyleEnum.Frozen].Border.Color = Color.Gainsboro;

                #endregion

                #region [grd02_1 : 현상별현황]
                this.grd02_1.AllowEditing = false;
                this.grd02_1.AllowDragging = AllowDraggingEnum.None;
                this.grd02_1.Initialize();
                this.grd02_1.Cols.RemoveRange(1, this.grd02_1.Cols.Count - 1);
                this.grd02_1.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "현상명", "PRESNM", "PRESNM");
                this.grd02_1.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "건수", "BAD_QTY", "BAD_QTY");
                this.grd02_1.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "비율", "RATE", "RATE");
                this.grd02_1.Cols["BAD_QTY"].DataType = typeof(decimal);
                this.grd02_1.Cols["BAD_QTY"].Format = "#,###,###,##0";
                this.grd02_1.Cols["RATE"].DataType = typeof(decimal);
                this.grd02_1.Cols["RATE"].Format = "#,##0.00";
                CellStyle csGrand = this.grd02_1.Styles[CellStyleEnum.GrandTotal];
                csGrand.BackColor = Color.FromArgb(255, 255, 200);
                csGrand.ForeColor = Color.Black;
                #endregion

                #region [grd02_2 : 사용기간별현황]
                this.grd02_2.AllowEditing = false;
                this.grd02_2.AllowDragging = AllowDraggingEnum.None;
                this.grd02_2.Initialize();
                this.grd02_2.Cols.RemoveRange(1, this.grd02_2.Cols.Count - 1);
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "사용기간", "USE_MONTHNM", "USE_MONTHNM");
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "건수", "BAD_QTY", "BAD_QTY");
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "비율", "RATE", "RATE");
                this.grd02_2.Cols["BAD_QTY"].DataType = typeof(decimal);
                this.grd02_2.Cols["BAD_QTY"].Format = "#,###,###,##0";
                this.grd02_2.Cols["RATE"].DataType = typeof(decimal);
                this.grd02_2.Cols["RATE"].Format = "#,##0.00";
                csGrand = this.grd02_2.Styles[CellStyleEnum.GrandTotal];
                csGrand.BackColor = Color.FromArgb(255, 255, 200);
                csGrand.ForeColor = Color.Black;
                #endregion

                #region [grd02_3 : 주행거리별현황]
                this.grd02_3.AllowEditing = false;
                this.grd02_3.AllowDragging = AllowDraggingEnum.None;
                this.grd02_3.Initialize();
                this.grd02_3.Cols.RemoveRange(1, this.grd02_3.Cols.Count - 1);
                this.grd02_3.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "주행거리", "USE_DISTANCENM", "USE_DISTANCENM");
                this.grd02_3.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "건수", "BAD_QTY", "BAD_QTY");
                this.grd02_3.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "비율", "RATE", "RATE");
                this.grd02_3.Cols["BAD_QTY"].DataType = typeof(decimal);
                this.grd02_3.Cols["BAD_QTY"].Format = "#,###,###,##0";
                this.grd02_3.Cols["RATE"].DataType = typeof(decimal);
                this.grd02_3.Cols["RATE"].Format = "#,##0.00";
                csGrand = this.grd02_3.Styles[CellStyleEnum.GrandTotal];
                csGrand.BackColor = Color.FromArgb(255, 255, 200);
                csGrand.ForeColor = Color.Black;
                #endregion

                #region [grd02_4 : 지역별현황]
                this.grd02_4.AllowEditing = false;
                this.grd02_4.AllowDragging = AllowDraggingEnum.None;
                this.grd02_4.Initialize();
                this.grd02_4.Cols.RemoveRange(1, this.grd02_4.Cols.Count - 1);
                this.grd02_4.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "생산지", "PROD_CUST3", "PROD_CUST3");
                this.grd02_4.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "지역", "CLAIM_REGIONNM", "CLAIM_REGIONNM");
                this.grd02_4.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "건수", "BAD_QTY", "BAD_QTY");
                this.grd02_4.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "금액", "BAD_AMT", "BAD_AMT");
                this.grd02_4.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "대상대수", "SAL_QTY3", "SAL_QTY3");
                this.grd02_4.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "불량율", "BAD_RATE", "BAD_RATE");
                this.grd02_4.Cols["BAD_QTY"].DataType = typeof(decimal);
                this.grd02_4.Cols["BAD_QTY"].Format = "#,###,###,##0";
                this.grd02_4.Cols["BAD_AMT"].DataType = typeof(decimal);
                this.grd02_4.Cols["BAD_AMT"].Format = "#,###,###,##0";
                this.grd02_4.Cols["SAL_QTY3"].DataType = typeof(decimal);
                this.grd02_4.Cols["SAL_QTY3"].Format = "#,###,###,##0";
                this.grd02_4.Cols["BAD_RATE"].DataType = typeof(decimal);
                this.grd02_4.Cols["BAD_RATE"].Format = "#,##0.00";
                csGrand = this.grd02_4.Styles[CellStyleEnum.GrandTotal];
                csGrand.BackColor = Color.FromArgb(255, 255, 200);
                csGrand.ForeColor = Color.Black;
                #endregion

                #region [grd02_5 : 지역별현황]
                this.grd02_5.AllowEditing = false;
                this.grd02_5.AllowDragging = AllowDraggingEnum.None;
                this.grd02_5.Initialize();
                this.grd02_5.Cols.RemoveRange(1, this.grd02_5.Cols.Count - 1);
                this.grd02_5.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "생산지", "PROD_CUST3", "PROD_CUST3");
                this.grd02_5.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "판매지", "SAL_NATION3", "SAL_NATION3");
                this.grd02_5.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "건수", "BAD_QTY", "BAD_QTY");
                this.grd02_5.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "금액", "BAD_AMT", "BAD_AMT");
                this.grd02_5.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "대상대수", "SAL_QTY3", "SAL_QTY3");
                this.grd02_5.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "불량율", "BAD_RATE", "BAD_RATE");
                this.grd02_5.Cols["BAD_QTY"].DataType = typeof(decimal);
                this.grd02_5.Cols["BAD_QTY"].Format = "#,###,###,##0";
                this.grd02_5.Cols["BAD_AMT"].DataType = typeof(decimal);
                this.grd02_5.Cols["BAD_AMT"].Format = "#,###,###,##0";
                this.grd02_5.Cols["SAL_QTY3"].DataType = typeof(decimal);
                this.grd02_5.Cols["SAL_QTY3"].Format = "#,###,###,##0";
                this.grd02_5.Cols["BAD_RATE"].DataType = typeof(decimal);
                this.grd02_5.Cols["BAD_RATE"].Format = "#,##0.00";
                csGrand = this.grd02_5.Styles[CellStyleEnum.GrandTotal];
                csGrand.BackColor = Color.FromArgb(255, 255, 200);
                csGrand.ForeColor = Color.Black;
                #endregion

                #region [chart 초기화]
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet dsChartLegend = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CHART_LEGEND"), set);
                this.InitChart(chart1, dsChartLegend.Tables[0]);
                this.InitChart(chart2, dsChartLegend.Tables[0]);

                #endregion

                this.pnl01_ViewC1.Dock = DockStyle.Fill;

                this.BtnReset_Click(null, null);
                //this.BtnQuery_Click(null, null);
                this.SetGridSizeAdjust();

                this.cbo01_BIZCD.SelectedIndexChanged += new EventHandler(cbo01_BIZCD_SelectedIndexChanged);
              
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        
        #endregion

        #region [공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                if (!this.IsQueryValid())
                    return;
                ck.Checked = true;
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD",           this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD",           this.cbo01_BIZCD.GetValue());
                paramSet.Add("PROD_CUST",       this.cbo01_PROD_CUST.GetValue());
                paramSet.Add("SAL_NATION",      this.cbo01_SAL_NATION.GetValue());
                paramSet.Add("SAL_REGION",      this.cbo01_SAL_REGION.GetValue());
                paramSet.Add("VINCD",           this.cbo01_VINCD.GetValue());
                paramSet.Add("PROD_SAL_DIV",    "PROD");
                paramSet.Add("PROD_SAL_SDATE",  this.dte01_PROD_SAL_SDATE.GetValue());
                paramSet.Add("PROD_SAL_EDATE",  this.dte01_PROD_SAL_EDATE.GetValue());
                paramSet.Add("PROD_VENDOR",     this.cbo01_PROD_VENDOR.GetValue());
                paramSet.Add("REPR_CONF_DIV",   "CONF");
                paramSet.Add("REPR_CONF_SDATE", this.dte01_REPR_CONF_SDATE.GetValue());
                paramSet.Add("REPR_CONF_EDATE", this.dte01_REPR_CONF_EDATE.GetValue());
                paramSet.Add("TYPE",            this.cbo01_TYPE.GetValue());
                paramSet.Add("USE_MONTH",       this.cbo01_USE_MONTH.GetValue());
                paramSet.Add("VINNO",           this.txt01_VINNO.GetValue());
                paramSet.Add("RONO",            this.txt01_RONO.GetValue());
                paramSet.Add("PNO",             this.txt01_PARTNO.GetValue());
                paramSet.Add("ISSUE",           this.txt01_ISSUE.GetValue());
                paramSet.Add("FILE_YN",         this.cbo01_FILENO.GetValue());
                paramSet.Add("LANG_SET",        this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);
                //1.클레임 현황 탭 페이지
                if (this.tabControl1.SelectedIndex == 0)
                {
                    DataSet source = _WSCOM.MultipleExecuteDataSet(new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CLAIM"), 
                                                                                  string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CLAIM_CHART") }, 
                                                                   paramSet);
                    
                    //PivotData
                    DataTable target = this.PivotData(source.Tables[0],
                                                      "DATA",
                                                      new string[] { "DIVNM1", "DIVNM2", "SEQ" },
                                                      new string[] { "YYYYMM" });
                    target.DefaultView.Sort = "SEQ ASC";
                    DataTable dtsource = target.DefaultView.ToTable();

                    dtsource.Columns["TOTAL"].SetOrdinal(3);
                    this.SetGridColumn(dtsource);

                    //DIVNM1, DIVNM2컬럼 헤더명을 "구분"으로
                    this.grd01.SetHeadTitle(0, "DIVNM1", this.GetLabel("DIVNM1"));
                    this.grd01.SetHeadTitle(0, "DIVNM2", this.GetLabel("DIVNM1"));
                                        
                    this.grd01.SetValue(dtsource);

                    //수동으로 merge 처리함.
                    this.SetGridMerge();
                   
                    this.chart1.DataSource = source.Tables[1];
                    this.chart1.DataBind();
                    this.chart2.DataSource = source.Tables[1];
                    this.chart2.DataBind();

                }
                //2.세부 현황 탭 페이지
                else if (this.tabControl1.SelectedIndex == 1)
                {
                    string[] procedure = new string[] { "APG_QA31431.INQUERY_PRESNM",           //현상별 현황
                                                        "APG_QA31431.INQUERY_USE_MONTH",        //사용기간별현황
                                                        "APG_QA31431.INQUERY_USE_DISTANCE",     //주행거리별 현황
                                                        "APG_QA31431.INQUERY_REGION",           //지역별 현황
                                                        "APG_QA31431.INQUERY_NATION"};          //국가별 현황
                   
                    DataSet source = _WSCOM.MultipleExecuteDataSet(procedure, paramSet);
                   
                    //그리드에 데이터 바인딩
                    this.grd02_1.SetValue(source.Tables[0]);
                    this.grd02_2.SetValue(source.Tables[1]);
                    this.grd02_3.SetValue(source.Tables[2]);
                    this.grd02_4.SetValue(source.Tables[3]);
                    this.grd02_5.SetValue(source.Tables[4]);

                    //총계행
                    this.grd02_1.Subtotal(AggregateEnum.Clear);
                    this.grd02_2.Subtotal(AggregateEnum.Clear);
                    this.grd02_3.Subtotal(AggregateEnum.Clear);
                    this.grd02_4.Subtotal(AggregateEnum.Clear);
                    this.grd02_5.Subtotal(AggregateEnum.Clear);
                    
                    //총계위치 설정 : 맨 위에
                    this.grd02_1.SubtotalPosition = SubtotalPositionEnum.AboveData;
                    this.grd02_2.SubtotalPosition = SubtotalPositionEnum.AboveData;
                    this.grd02_3.SubtotalPosition = SubtotalPositionEnum.AboveData;
                    this.grd02_4.SubtotalPosition = SubtotalPositionEnum.AboveData;
                    this.grd02_5.SubtotalPosition = SubtotalPositionEnum.AboveData;
                    
                    //grd02_1 : 현상별 현황 그리드 총계처리
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        this.grd02_1.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_1.Cols["BAD_QTY"].Index);
                        this.grd02_1.SetValue(this.grd02_1.Rows.Fixed, this.grd02_1.Cols["RATE"].Index, 100);
                        this.grd02_1.SetValue(this.grd02_1.Rows.Fixed, this.grd02_1.Cols["PRESNM"].Index, this.GetLabel("TOT2"));
                    }

                    //grd02_2 : 사용기간별 현황 그리드 총계처리
                    if (source.Tables[1].Rows.Count > 0)
                    {
                        this.grd02_2.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_2.Cols["BAD_QTY"].Index);
                        this.grd02_2.SetValue(this.grd02_2.Rows.Fixed, this.grd02_2.Cols["RATE"].Index, 100);
                        this.grd02_2.SetValue(this.grd02_2.Rows.Fixed, this.grd02_2.Cols["USE_MONTHNM"].Index, this.GetLabel("TOT2"));
                    }

                    //grd02_3 : 주행거리별 현황 그리드 총계처리
                    if (source.Tables[2].Rows.Count > 0)
                    {
                        this.grd02_3.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_3.Cols["BAD_QTY"].Index);
                        this.grd02_3.SetValue(this.grd02_3.Rows.Fixed, this.grd02_3.Cols["RATE"].Index, 100);
                        this.grd02_3.SetValue(this.grd02_3.Rows.Fixed, this.grd02_3.Cols["USE_DISTANCENM"].Index, this.GetLabel("TOT2"));
                    }
                    decimal badQty = 0;
                    decimal salQty = 0;

                    //grd02_4 : 지역별 현황 그리드 총계처리
                    if (source.Tables[3].Rows.Count > 0)
                    {
                        this.grd02_4.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_4.Cols["BAD_QTY"].Index);
                        this.grd02_4.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_4.Cols["BAD_AMT"].Index);
                        this.grd02_4.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_4.Cols["SAL_QTY3"].Index);
                        badQty = Convert.ToDecimal(this.grd02_4.GetValue(this.grd02_4.Rows.Fixed, "BAD_QTY"));
                        salQty = Convert.ToDecimal(this.grd02_4.GetValue(this.grd02_4.Rows.Fixed, "SAL_QTY3"));
                        if (salQty > 0)
                            this.grd02_4.SetValue(this.grd02_4.Rows.Fixed, this.grd02_4.Cols["BAD_RATE"].Index, Math.Round(badQty / salQty * 1000, 2));
                        else
                            this.grd02_4.SetValue(this.grd02_4.Rows.Fixed, this.grd02_4.Cols["BAD_RATE"].Index, 0);
                        this.grd02_4.SetValue(this.grd02_4.Rows.Fixed, this.grd02_4.Cols["PROD_CUST3"].Index, this.GetLabel("TOT2"));
                    }

                    //grd02_5 : 국가별 현황 그리드 총계처리
                    if (source.Tables[4].Rows.Count > 0)
                    {
                        this.grd02_5.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_5.Cols["BAD_QTY"].Index);
                        this.grd02_5.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_5.Cols["BAD_AMT"].Index);
                        this.grd02_5.Subtotal(AggregateEnum.Sum, -1, -1, this.grd02_5.Cols["SAL_QTY3"].Index);
                        badQty = Convert.ToDecimal(this.grd02_5.GetValue(this.grd02_5.Rows.Fixed, "BAD_QTY"));
                        salQty = Convert.ToDecimal(this.grd02_5.GetValue(this.grd02_5.Rows.Fixed, "SAL_QTY3"));
                        if (salQty > 0)
                            this.grd02_5.SetValue(this.grd02_5.Rows.Fixed, this.grd02_5.Cols["BAD_RATE"].Index, Math.Round(badQty / salQty * 1000, 2));
                        else
                            this.grd02_5.SetValue(this.grd02_5.Rows.Fixed, this.grd02_5.Cols["BAD_RATE"].Index, 0);
                        this.grd02_5.SetValue(this.grd02_5.Rows.Fixed, this.grd02_5.Cols["PROD_CUST3"].Index, this.GetLabel("TOT2"));
                    }
                }

                this.AfterInvokeServer();
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }          
        }

        #endregion

        #region [기타 컨트롤에 대한 이벤트 정의 ]
                
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 this.SetBindComboBox();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void chk01_ACC_YN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_ACC_YN.Checked)
            {
                DataSet source = this.GetTypeCode("QB");
                this.cbo01_USE_MONTH.DataBind(source.Tables[0], false);
            }
            else
            {
                DataSet source = this.GetTypeCode("QA");
                this.cbo01_USE_MONTH.DataBind(source.Tables[0], false);
            }
        }

        private void dte01_Leave(object sender, EventArgs e)
        {
            Ax.DEV.Utility.Controls.AxTextBox txt = (Ax.DEV.Utility.Controls.AxTextBox)sender;
            if (txt.GetValue().ToString().Length == 8)
            {
                DateTime CHK_DATE;

                if (DateTime.TryParse(Int32.Parse(txt.GetValue().ToString()).ToString("####-##-##"), out CHK_DATE) == false)
                {
                    txt.Focus();
                    txt.SetValue("");
                }
            }
            else if (txt.GetValue().ToString().Length != 0)
            {
                txt.Focus();
                txt.SetValue("");
            }
            else
            {
                txt.SetValue("");
            }
        }

        private void btn01_ViewC1_Click(object sender, EventArgs e)
        {
            this.pnl01_ViewC1.Visible = true;
            this.panel1.Visible = false;
            this.groupBox_search.Visible = false;
        }

        private void btn01_ViewC1_Close_Click(object sender, EventArgs e)
        {
            this.pnl01_ViewC1.Visible = false;
            this.panel1.Visible = true;
            this.groupBox_search.Visible = true;
        }
              
        private void chart1_Resize(object sender, EventArgs e)
        {
         
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        #endregion

        #region [사용자 정의 메서드]
        /// <summary>
        /// CHART 초기화
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="legend"></param>
        private void InitChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, DataTable legend)
        {
            try
            {

                chart.BackColor = Color.White;
                chart.Legends.Clear();
                chart.Legends.Add("legend1");
                chart.Legends["legend1"].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
                chart.Legends["legend1"].Enabled = true;
                chart.Legends["legend1"].Alignment = StringAlignment.Center;
                chart.Legends["legend1"].BackColor = Color.White;
                

                chart.Series.Clear();
                chart.Series.Add("SEQ_40");      //판매월 불량율(%)
                chart.Series.Add("SEQ_20");      //생산월 건수
                chart.Series.Add("SEQ_30");      //판매월 건수
                chart.Series.Add("SEQ_60");      //수리월 건수 추가 2016.10.05
                //chart.Series.Add("SEQ_70");      //발생월 건수 삭제 2016.10.05
                                

                
                //chart.Series.Add("SEQ_100");     //0~3M   불량율(%)
                //chart.Series.Add("SEQ_110");     //0~6M   불량율(%)
                //chart.Series.Add("SEQ_130");     //0~12M  불량율(%)
               // chart.Series.Add("SEQ_140");     //0~24M  불량율(%)

                //chart.ChartAreas[0].Position.Y = 1;
                //chart.ChartAreas[0].Position.Height = 95;
                //chart.ChartAreas[0].Position.Width = 98;
                //chart.ChartAreas[0].Position.X = 1;

                chart.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
                chart.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
                chart.ChartAreas[0].AxisY2.MajorGrid.LineWidth = 1;
                chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                //chart.ChartAreas[0].AxisY2.LabelStyle.Format = "#,###.##%";
                //chart.ChartAreas[0].AxisY2.LabelStyle.IsEndLabelVisible = true;


                chart.Series["SEQ_20"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line; // 20,30,60  Line Type 으로 변경 2016.10.05
                chart.Series["SEQ_30"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart.Series["SEQ_60"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line; // 수리월 추가 2016.10.05
                //chart.Series["SEQ_70"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column; // 발생월 삭제 2016.10.05
                chart.Series["SEQ_40"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                //chart.Series["SEQ_100"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart.Series["SEQ_110"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart.Series["SEQ_130"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart.Series["SEQ_140"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                chart.Series["SEQ_40"].Color = Color.LightGray;
                //chart.Series["SEQ_100"].Color = Color.FromArgb(34, 177, 76);
                //chart.Series["SEQ_110"].Color = Color.FromArgb(63, 72, 204);
                //chart.Series["SEQ_130"].Color = Color.FromArgb(163, 73, 164);

                chart.Series["SEQ_20"].BorderWidth = 2;
                chart.Series["SEQ_30"].BorderWidth = 2;
                chart.Series["SEQ_60"].BorderWidth = 2;

                chart.Series["SEQ_20"].MarkerSize = 7;
                chart.Series["SEQ_30"].MarkerSize = 7;
                chart.Series["SEQ_60"].MarkerSize = 7;

                //chart.Series["SEQ_40"].BorderWidth = 2;
                //chart.Series["SEQ_100"].BorderWidth = 2;
                //chart.Series["SEQ_110"].BorderWidth = 2;
                //chart.Series["SEQ_130"].BorderWidth = 2;

                chart.Series["SEQ_20"].Enabled = true;
                chart.Series["SEQ_30"].Enabled = true;
                chart.Series["SEQ_60"].Enabled = true;   // 수리월 추가 2016.10.05
                //chart.Series["SEQ_70"].Enabled = true;  // 발생월 삭제 2016.10.05
                chart.Series["SEQ_40"].Enabled = true;
                //chart.Series["SEQ_100"].Enabled = true;
                //chart.Series["SEQ_110"].Enabled = true;
                //chart.Series["SEQ_130"].Enabled = true;
                //chart.Series["SEQ_140"].Enabled = true;

                chart.Series["SEQ_20"].XValueMember = "YYMM";
                chart.Series["SEQ_20"].YValueMembers = "PROD_20_BAD_QTY";
                chart.Series["SEQ_30"].XValueMember = "YYMM";
                chart.Series["SEQ_30"].YValueMembers = "SALE_30_BAD_QTY";
                chart.Series["SEQ_60"].XValueMember = "YYMM";
                chart.Series["SEQ_60"].YValueMembers = "REPAIR_60_BAD_QTY";         // 수리건수 추가 2016.10.05
                //chart.Series["SEQ_70"].XValueMember = "YYMM";
                //chart.Series["SEQ_70"].YValueMembers = "CONF_70_BAD_QTY";         // 발생건수 삭제 2016.10.05
                chart.Series["SEQ_40"].XValueMember = "YYMM";
                chart.Series["SEQ_40"].YValueMembers = "SALE_40_BAD_RATE";
                //chart.Series["SEQ_100"].XValueMember = "YYMM";
                //chart.Series["SEQ_100"].YValueMembers = "QB05_100_BAD_RATE";
                //chart.Series["SEQ_110"].XValueMember = "YYMM";
                //chart.Series["SEQ_110"].YValueMembers = "QB06_110_BAD_RATE";
                //chart.Series["SEQ_130"].XValueMember = "YYMM";
                //chart.Series["SEQ_130"].YValueMembers = "QB08_130_BAD_RATE";
                //chart.Series["SEQ_140"].XValueMember = "YYMM";
                //chart.Series["SEQ_140"].YValueMembers = "QB09_140_BAD_RATE";

                chart.Series["SEQ_20"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                chart.Series["SEQ_30"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                chart.Series["SEQ_60"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;        // 수리건수 추가 2016.10.05
                //chart.Series["SEQ_70"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;      // 발생건수 삭제 2016.10.05
                chart.Series["SEQ_40"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                //chart.Series["SEQ_100"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                //chart.Series["SEQ_110"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                //chart.Series["SEQ_130"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                //chart.Series["SEQ_140"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;

                //chart.Series["SEQ_40"].IsValueShownAsLabel = true;

                chart.Series["SEQ_20"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart.Series["SEQ_30"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart.Series["SEQ_60"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;

                chart.Series["SEQ_40"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                //chart.Series["SEQ_100"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                //chart.Series["SEQ_110"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                //chart.Series["SEQ_130"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;

                chart.Series["SEQ_20"].ToolTip ="[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";
                chart.Series["SEQ_30"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";
                chart.Series["SEQ_60"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";    // 수리건수 추가 2016.10.05
                //chart.Series["SEQ_70"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";  // 발생건수 삭제 2016.10.05
                chart.Series["SEQ_40"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";
                //chart.Series["SEQ_100"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";
                //chart.Series["SEQ_110"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";
                //chart.Series["SEQ_130"].ToolTip = "[" + "#LEGENDTEXT" + "]\r\n" + "Month = #AXISLABEL" + ",\r\n" + "Qty = #VALY";

                chart.Series["SEQ_20"].LegendText = this.GetLegendText("20", legend);
                chart.Series["SEQ_30"].LegendText = this.GetLegendText("30", legend);
                chart.Series["SEQ_60"].LegendText = this.GetLegendText("60", legend);           // 수리건수 추가 2016.10.05
                //chart.Series["SEQ_70"].LegendText = this.GetLegendText("70", legend);         // 발생건수 삭제 2016.10.05
                chart.Series["SEQ_40"].LegendText = this.GetLegendText("40", legend);
                //chart.Series["SEQ_100"].LegendText = this.GetLegendText("100", legend);
                //chart.Series["SEQ_110"].LegendText = this.GetLegendText("110", legend);
                //chart.Series["SEQ_130"].LegendText = this.GetLegendText("130", legend);
                //chart.Series["SEQ_140"].LegendText = this.GetLegendText("140", legend);

                chart.Series["SEQ_20"].Legend = "legend1";
                chart.Series["SEQ_30"].Legend = "legend1";
                chart.Series["SEQ_60"].Legend = "legend1";  // 수리건수 추가 2016.10.05
                //chart.Series["SEQ_70"].Legend = "legend1";  // 발생건수 삭제 2016.10.05
                chart.Series["SEQ_40"].Legend = "legend1";
                //chart.Series["SEQ_100"].Legend = "legend1";
                //chart.Series["SEQ_110"].Legend = "legend1";
                //chart.Series["SEQ_130"].Legend = "legend1";
                //chart.Series["SEQ_140"].Legend = "legend1";

                chart.DataSource = null;

                if (chart == chart1)
                {
                    panel1.Visible = true;
                    for (int i = chart.Series.Count - 1; i >= 0; i--)
                    {
                        AxCheckBox chk = new AxCheckBox();
                        chk.Text = chart.Series[i].LegendText;
                        chk.Tag = i.ToString();
                        chk.Name = "chk_" + i;
                        chk.TextAlign = ContentAlignment.MiddleLeft;
                        chk.Dock = DockStyle.Left;
                        chk.AutoSize = true;                        
                        ar.Add(chk);
                        panel2.Controls.Add(chk);
                    }
                    AxCheckBox chk_all = new AxCheckBox();
                    chk_all.Text = "ALL";
                    chk_all.TextAlign = ContentAlignment.MiddleLeft;
                    chk_all.Dock = DockStyle.Left;
                    chk_all.AutoSize = true;
                    chk_all.CheckedChanged += new EventHandler(chk_all_CheckedChanged);
                    chk_all.Checked = true;
                    
                    panel2.Controls.Add(chk_all);
                }                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            string index = ((AxCheckBox)sender).Tag.ToString();
            chart1.Series[int.Parse(index)].Enabled = ((AxCheckBox)sender).Checked;

            bool flag = true;
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                if (!((AxCheckBox)ar[i]).Checked)
                {
                    flag  = false;
                    break;
                }
            }
            if (flag == false)
            {
                ck.CheckedChanged -= new EventHandler(chk_all_CheckedChanged);
                ck.Checked = false;
                ck.CheckedChanged += new EventHandler(chk_all_CheckedChanged);
            }
            else
            {
                ck.CheckedChanged -= new EventHandler(chk_all_CheckedChanged);
                ck.Checked = true;
                ck.CheckedChanged += new EventHandler(chk_all_CheckedChanged);
            }
        }

        void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            ck = (AxCheckBox)sender;
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                if (ck.Checked)
                {
                    chart1.Series[i].Enabled = ck.Checked;
                    if (((AxCheckBox)ar[i]).Checked == false)
                    {
                        ((AxCheckBox)ar[i]).CheckedChanged -= new EventHandler(chk_CheckedChanged);
                        ((AxCheckBox)ar[i]).Checked = ck.Checked;
                        ((AxCheckBox)ar[i]).CheckedChanged += new EventHandler(chk_CheckedChanged);
                    }
                }
                else
                {
                    chart1.Series[i].Enabled = ck.Checked;
                    if (((AxCheckBox)ar[i]).Checked == true)
                    {
                        ((AxCheckBox)ar[i]).CheckedChanged -= new EventHandler(chk_CheckedChanged);
                        ((AxCheckBox)ar[i]).Checked = ck.Checked;
                        ((AxCheckBox)ar[i]).CheckedChanged += new EventHandler(chk_CheckedChanged);
                    }
                }
            }
        }
        /// <summary>
        /// CHART에 표시할 LEGEND텍스트 가져오기
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetLegendText(string key, DataTable dt)
        {
            DataRow[] drs = dt.Select("SEQ='" + key + "'");
            if (drs.Length == 0)
                return "";
            else
            {
                //if (key.Equals("40") || key.Equals("22"))
                    return drs[0]["DIVNM1"] + " " + drs[0]["DIVNM2"].ToString();
                //else
                //    return drs[0]["DIVNM1"].ToString();
            }
        }
        /// <summary>
        /// DIVNM1, DIVNM2 컬럼 수동으로 MERGE처리
        /// </summary>
        private void SetGridMerge()
        {
            this.grd01.AllowMerging = AllowMergingEnum.Custom;
            this.grd01.MergedRanges.Clear();
            
            int ridx1 = 0;
            int ridx2 = 0;

            for (int r1 = 0; r1 < this.grd01.Rows.Count; r1++)
            {
               
                string strValue1 = this.grd01[r1, "DIVNM1"].ToString();
                string strValue2 = this.grd01[r1, "DIVNM2"].ToString();

                if (strValue1.Equals(strValue2))
                {
                    this.grd01.AddMerge(r1, r1, "DIVNM1", "DIVNM2");
                }

                ridx1 = r1;
                ridx2 = r1;

                if (ridx1 == 4)
                {
                    string aa = "1";
                }

                for (int r2 = r1 + 1; r2 < this.grd01.Rows.Count; r2++)
                {

                    strValue2 = this.grd01[r2, "DIVNM1"].ToString();
                    if (strValue1.Equals(strValue2))
                    {
                        ridx2 = r2;
                        continue;
                    }
                    else
                    {
                        break;
                    }                  
                }
                if (ridx1 != ridx2)
                {
                    this.grd01.AddMerge(ridx1, ridx2, "DIVNM1", "DIVNM1");
                    r1 = ridx2;// +1;
                }

               

            }
            
        }
        /// <summary>
        /// 그리드 컬럼 동적 생성
        /// </summary>
        /// <param name="source">동적 생성을 위한 기준 DataTable</param>
        private void SetGridColumn(DataTable source)
        {
            this.grd01.Cols.Count = this.grd01.Cols.Fixed + source.Columns.Count;
            for (int i = 0; i < source.Columns.Count; i++)
            {

                string[] header = source.Columns[i].ColumnName.Split(';');
                this.grd01.Cols[i + this.grd01.Cols.Fixed].Name = source.Columns[i].ColumnName;
                this.grd01.SetValue(0, i + this.grd01.Cols.Fixed, header[0]);

                this.grd01.Cols[i + this.grd01.Cols.Fixed].StyleFixedDisplay.TextAlign = TextAlignEnum.CenterCenter;

                if (header[0].Equals("DIVNM1"))
                {
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].Width = 70;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].StyleDisplay.TextAlign = TextAlignEnum.CenterCenter;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].AllowMerging = true;
                }
                else if (header[0].Equals("DIVNM2"))
                {
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].Width = 100;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].StyleDisplay.TextAlign = TextAlignEnum.CenterCenter;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].AllowMerging = true;
                }
                else if (header[0].Equals("SEQ"))
                {
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].Width = 100;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].StyleDisplay.TextAlign = TextAlignEnum.CenterCenter;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].Visible = false;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].AllowMerging = false;
                }
                else
                {
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].Width = 60;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].StyleDisplay.TextAlign = TextAlignEnum.CenterCenter;
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].DataType = typeof(decimal);
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].Format = "#,###,##0.##";
                    this.grd01.Cols[i + this.grd01.Cols.Fixed].AllowMerging = false;
                   
                }
                if (header[0].Length == 7 && header[0].IndexOf("-") >= 0)
                {
                    this.grd01.SetValue(0, i + this.grd01.Cols.Fixed, header[0].Substring(2).Replace("-", "."));
                }
            }



        }

        /// <summary>
        /// Pivot 처리
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="DataField"></param>
        /// <param name="RowFields"></param>
        /// <param name="ColumnFields"></param>
        /// <returns></returns>
        public DataTable PivotData(DataTable sourceTable, string DataField, string[] RowFields, string[] ColumnFields)
        {
            DataTable dt = new DataTable();
            string Separator = ";";
            var RowList = sourceTable.DefaultView.ToTable(true, RowFields).AsEnumerable().ToList();
            for (int index = RowFields.Length - 1; index >= 0; index--)
                RowList = RowList.OrderBy(x => x.Field<object>(RowFields[index])).ToList();
            // Gets the list of columns .(dot) separated.
            var ColList = (from x in sourceTable.AsEnumerable()
                           select new
                           {
                               Name = ColumnFields.Select(n => x.Field<object>(n))
                                   .Aggregate((a, b) => a += Separator + b.ToString())
                           })
                               .Distinct()
                               .OrderBy(m => m.Name);

            //dt.Columns.Add(RowFields);
            foreach (string s in RowFields)
            {
                dt.Columns.Add(s);
                dt.Columns[dt.Columns.Count - 1].DataType = sourceTable.Columns[s].DataType;
            }
            foreach (var col in ColList)
            {
                dt.Columns.Add(col.Name.ToString());  // Cretes the result columns.//
                dt.Columns[dt.Columns.Count - 1].DataType = typeof(decimal);
            }

            foreach (var RowName in RowList)
            {
                DataRow row = dt.NewRow();
                string strFilter = string.Empty;

                foreach (string Field in RowFields)
                {
                    row[Field] = RowName[Field];
                    strFilter += " and " + Field + " = '" + RowName[Field].ToString() + "'";
                }
                strFilter = strFilter.Substring(5);

                foreach (var col in ColList)
                {
                    string filter = strFilter;
                    string[] strColValues = col.Name.ToString().Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < ColumnFields.Length; i++)
                        filter += " and " + ColumnFields[i] + " = '" + strColValues[i] + "'";

                    DataRow[] FilteredRows = sourceTable.Select(filter);
                    object[] objList = FilteredRows.Select(x => x.Field<object>(DataField)).ToArray();

                    row[col.Name.ToString()] = (objList.Count() == 0) ? null : objList.Max();
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 화면 사이즈에 맞춰서 그리드 사이즈조정
        /// </summary>
        private void SetGridSizeAdjust()
        {
            int width = this.tbp01_QA31431_TP_2.Width;
            int height = this.tbp01_QA31431_TP_2.Height;

            this.pnl02_top.Height = height / 2;
            this.pnl02_1.Width = width / 3;
            this.pnl02_2.Width = width / 3;
            this.pnl02_4.Width = width / 2;
        }

        /// <summary>
        /// 사업장코드 변경시 해당 bizcd에 따른 콤보상자 재바인딩 처리.
        /// </summary>
        private void SetBindComboBox()
        {
            try
            {
                HEParameterSet param = new HEParameterSet();
                DataSet source = new DataSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                param.Add("LANG_SET", this.UserInfo.Language);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA21411, "INQUERY_PROD_CUST"), param);
                this.cbo01_PROD_CUST.DataBind(source.Tables[0], true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA21411, "INQUERY_SAL_NATION"), param);
                this.cbo01_SAL_NATION.DataBind(source.Tables[0], true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA21411, "INQUERY_VINCD"), param);
                this.cbo01_VINCD.DataBind(source.Tables[0], true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA21411, "INQUERY_PROD_VENDOR"), param);
                this.cbo01_PROD_VENDOR.DataBind(source.Tables[0], true);

                
                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA21411, "INQUERY_SAL_REGION"), param);
                this.cbo01_SAL_REGION.DataBind(source.Tables[0], true);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]
        /// <summary>
        /// 조회시 조회조건 필수 입력 여부 검사
        /// </summary>
        /// <returns></returns>
        private bool IsQueryValid()
        {
            try
            {
                if (this.GetByteCount(this.dte01_PROD_SAL_SDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_PROD_SAL_SDATE.Focus();
                    return false;
                }
                if (this.GetByteCount(this.dte01_PROD_SAL_EDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_PROD_SAL_EDATE.Focus();
                    return false;
                }
                if (this.GetByteCount(this.dte01_REPR_CONF_SDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_REPR_CONF_SDATE.Focus();
                    return false;
                }
                if (this.GetByteCount(this.dte01_REPR_CONF_EDATE.GetValue().ToString()) <= 0)
                {
                    //날짜 조건을 입력하여 주세요.
                    MsgCodeBox.Show("QA01-0012");
                    this.dte01_REPR_CONF_EDATE.Focus();
                    return false;
                }
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

       
        #endregion


        
    }
}
