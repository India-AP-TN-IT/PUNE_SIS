using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;
using Ax.SIS.QA.QA09.UI;


namespace Ax.SIS.QA.QA02.UI
{
    public partial class QA35010 : AxCommonBaseControl//, IMenuHelper
    {

        #region [ 필드정의 ]
        
        private AxClientProxy _WSCOM;
        private string hour = DateTime.Now.Hour.ToString();
        private bool _isLoadComplete = false;
        //※※※ 파라메터 전달 MENU 오픈 1 → EventHandler 선언
        public event EventHandler UI_Ready;        
        public string YYYY = string.Empty;

        #endregion


        #region [초기화 설정에 대한 정의]

        public QA35010()
        {
            _WSCOM = new AxClientProxy();
            InitializeComponent();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDNM");//"업체명";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                tabPage3.Text = this.GetLabel("EI31070_MSG1");
                lbl01_EI31070_TITLE3.Font = new System.Drawing.Font("맑은 고딕", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));//2014-11-25                
                lbl01_CHT_TITLE1.Text = this.GetLabel("EI31070_CHT_TITLE1");
                lbl01_CHT_TITLE2.Text = this.GetLabel("EI31070_CHT_TITLE2");
                this.grd03.Initialize(1, 1);
                this.grd03.AllowSorting = AllowSortingEnum.None;
                this.grd03.AutoClipboard = true;
                this.grd03.AllowEditing = false;
                this.grd03.HighLight = HighLightEnum.Never;
                this.grd03.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                grd03.Styles.Remove(this.grd03.Styles["Selected"]);  

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "", "DIV");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_1MONTH"), "M01");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_2MONTH"), "M02");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_3MONTH"), "M03");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_4MONTH"), "M04");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_5MONTH"), "M05");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_6MONTH"), "M06");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_7MONTH"), "M07");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_8MONTH"), "M08");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_9MONTH"), "M09");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_10MONTH"), "M10");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_11MONTH"), "M11");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_12MONTH"), "M12");
                this.grd03.Cols["M01"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M02"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M03"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M04"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M05"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M06"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M07"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M08"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M09"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M10"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M11"].Format = "###,###,###,##0.##";
                this.grd03.Cols["M12"].Format = "###,###,###,##0.##";

                this.grd03.Cols[0].Visible = false;

                this.grd01.Initialize(1, 1);
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AutoClipboard = true;
                this.grd01.AllowEditing = false;
                //this.grd01.Enabled = false;
                this.grd01.Cols[0].Visible = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "NO", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_VEHICLE"), "VEHICLE"); //차종
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, this.GetLabel("EI31070_PARTNAME"), "PARTNAME"); //부품명
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, this.GetLabel("EI31070_PRESNM"), "PRESNM"); //현상명
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, this.GetLabel("EI31070_CNT"), "CNT"); //발생건수
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, this.GetLabel("EI31070_VENDNM"), "VENDNM");//협력사

                this.grd03.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                this.grd03.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                this.grd03.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                this.grd03.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                this.grd01.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                this.grd01.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                this.grd01.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                this.grd01.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                ComponentDataInit();
                this.SetRequired(this.lbl01_EI31070_BIZCD, this.lbl01_EI31070_DATE);
                GridDesignSetting();

                //this.BtnReset_Click(null, null);
                this.cbo01_CORCD.DataBind_CORCD(false);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                
                this.cbo01_year.SetValue(DateTime.Now.ToString("yyyy")); // 2015-01-26

                this.grd03_Resize(null, null);
                _isLoadComplete = true;
                //※※※ 파라메터 전달 MENU 오픈 2 → 이벤트 추가
                //if (UI_Ready != null) UI_Ready(this, e);
                if (UI_Ready != null)
                {
                    UI_Ready(this, e);
                }
                else
                {
                    this.BtnQuery_Click(null, null);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }        

        #region [ 초기화 관련 사용자 정의 method ]

        //※※※ 파라메터 전달 MENU 오픈 3 → public 메서드 추가(타화면에서 메뉴를 open했을때의 특정처리)
        public void extraSearch(HEParameterSet param)
        {
            this.cbo01_CORCD.SetValue(param["CORCD"]);
            if (string.IsNullOrEmpty(param["BIZCD"].ToString()))
            {
                this.cbo01_BIZCD.SelectedIndex = 0;
            }
            else
            {
                this.cbo01_BIZCD.SetValue(param["BIZCD"]);
            }
            this.cbo01_year.SetValue(param["DATE"].ToString().Substring(0, 4)); // 2015-01-26            
            BtnQuery_Click(null, null);
        }
        
        private void GridDesignSetting()
       {


           this.grd03.Rows[0].Height = 27;
           this.grd03.Rows.DefaultSize = 26;

           grd03.Styles.Alternate.BackColor = Color.White;
           grd03.Rows[0].StyleNew.BackColor = Color.FromArgb(70, 84, 113);
           grd03.Rows[0].StyleNew.ForeColor = Color.White;
           //grd03.Rows[0].StyleNew.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
           grd03.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));//2014-11-25
           grd03.Styles.Normal.Border.Color = Color.Black;
           grd03.Rows[0].StyleFixedDisplay.Border.Color = Color.Black;

           this.grd03.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;

           grd01.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));//2014-11-25
           grd01.Styles.Normal.Border.Color = Color.Gray;
           grd01.Styles.Alternate.BackColor = Color.White;
           grd01.Styles.Fixed.ForeColor = Color.White;
           grd01.Styles.Fixed.Border.Color = Color.White;
           grd01.Styles.Fixed.BackColor = Color.FromArgb(64, 64, 64);
           grd01.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
           this.grd01.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;

       }

        private void ComponentDataInit()
        {
            // 2015-01-26
            DataTable dt = new DataTable();
            DataRow addrow = null;
            dt.Columns.Add("KEY");
            dt.Columns.Add("VALUE");
            int current_year = DateTime.Today.Year;
            DateTime fixedYear = new DateTime(2014, 1, 1);

            for (int i = int.Parse(fixedYear.ToString("yyyy")); i <= current_year; i++)
            {
                addrow = dt.NewRow();
                addrow["KEY"] = i;
                addrow["VALUE"] = i;
                dt.Rows.Add(addrow);
            }
            this.cbo01_year.DataBind(dt, false);
        }

        #endregion
        
        #endregion


        #region [ 공통 버튼에 대한 이벤트 정의 ]

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.BeforeInvokeServer(true);

                string MM = ChartSettting();                
                GridDesignSetting();
                ShowBottomChart(MM, int.Parse(MM), 1);                
                
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

        /// <summary>
        /// 하단의 챠트
        /// </summary>
        private void ShowBottomChart(string month, int setColorCols, int add)
        {

            try
            {
                grd03.Styles.Remove(grd03.Styles.Add("COLOR"));
                //2014-11-25   
                C1.Win.C1FlexGrid.CellStyle cs = grd03.Styles.Add("COLOR");      //특정 row에 포멧 , align 재지정                                                                     
                cs.ForeColor = Color.Black;// Color.Blue;
                cs.BackColor = Color.FromArgb(200, 206, 222); ;// Color.LightGreen;
                if (setColorCols > 0)
                {
                    grd03.SetCellStyle(1, setColorCols + add, grd03.Styles["COLOR"]); // 2015-01-26
                    grd03.SetCellStyle(2, setColorCols + add, grd03.Styles["COLOR"]); // 2015-01-26
                    grd03.SetCellStyle(3, setColorCols + add, grd03.Styles["COLOR"]); // 2015-01-26
                    grd03.SetCellStyle(4, setColorCols + add, grd03.Styles["COLOR"]); // 2015-01-26
                }
                               
                grd03.Refresh();

                this.BeforeInvokeServer(true);
                HEParameterSet paramSet2 = new HEParameterSet();
                paramSet2.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet2.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet2.Add("YYYYMM", YYYY + "-" + (setColorCols >= 10 ? setColorCols.ToString() : "0" + setColorCols));
                paramSet2.Add("LANG_SET", this.UserInfo.Language);
                paramSet2.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                DataSet source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA35010", "INQUERY_BOTTOM"), paramSet2);
                

                lbl01_EI31070_TITLE3.Text = string.Format(this.GetLabel("EI31070_TITLE3"),  Regex.Replace(month, @"\D", "")); //00월 세부 현황                

                grd01.BeginUpdate();
                grd01.SetValue(source2.Tables[0]);
                grd01_Resize(grd01, null);
                grd01.EndUpdate();                
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

        private string ChartSettting()
        {
            
            cht01.ChartAreas["ChartArea1"].Position.Width = 100;
            //cht01.ChartAreas["ChartArea1"].Position.Height = 84;
            cht01.ChartAreas["ChartArea1"].Position.Height = 100;
            cht01.ChartAreas["ChartArea1"].Position.X = 0;
            cht01.ChartAreas["ChartArea1"].InnerPlotPosition.X = 6;            

            cht01.ChartAreas[0].AxisX.Title = this.GetLabel("EI31070_MONTH");
            cht01.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht01.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25            
            cht01.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht01.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht01.Series[0].Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht01.Series[1].Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25

            cht02.ChartAreas[0].AxisX.Title = this.GetLabel("EI31070_MONTH");
            cht02.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht02.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25            
            cht02.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht02.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht02.Series[0].Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25
            cht02.Series[1].Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))); //2014-11-25

            cht01.ChartAreas["ChartArea1"].Position.Width = 100;
            cht01.ChartAreas["ChartArea1"].Position.Height = 100;
            cht01.ChartAreas["ChartArea1"].Position.X = 0;
            cht01.ChartAreas["ChartArea1"].InnerPlotPosition.X = 8;
            cht01.ChartAreas["ChartArea1"].InnerPlotPosition.Y = 6;

            cht01.ChartAreas[0].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.None;
            cht01.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            cht01.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            cht01.ChartAreas[0].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            //cht01.ChartAreas[0].AxisY.IsStartedFromZero = false;
            cht01.Series[0].Color = Color.FromArgb(0, 0, 255); //목표
            cht01.Series[0].MarkerColor = Color.FromArgb(0, 0, 255); //목표            
            cht01.Series[0].SmartLabelStyle.CalloutLineColor = Color.FromArgb(0, 0, 255); //목표            
            cht01.Series[0].IsValueShownAsLabel = false;
            cht01.Series[0].ChartType = SeriesChartType.Spline;

            cht01.Series[1].Color = Color.FromArgb(0, 176, 80); //실적
            cht01.Series[1].MarkerColor = Color.FromArgb(0, 176, 80); //실적            
            cht01.Series[1].ChartType = SeriesChartType.Spline;
            cht01.Series[1].SmartLabelStyle.CalloutLineColor = Color.FromArgb(0, 176, 80); //실적

            cht02.ChartAreas["ChartArea1"].Position.Width = 100;
            cht02.ChartAreas["ChartArea1"].Position.Height = 100;
            cht02.ChartAreas["ChartArea1"].Position.X = 0;
            cht02.ChartAreas["ChartArea1"].InnerPlotPosition.X = 8;
            cht02.ChartAreas["ChartArea1"].InnerPlotPosition.Y = 10;

            cht02.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            cht02.ChartAreas[0].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            cht02.ChartAreas[0].AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.None;
            cht02.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            //cht02.ChartAreas[0].AxisY.IsStartedFromZero = false;


            cht02.Series[0].Color = Color.FromArgb(0, 0, 255); //목표
            cht02.Series[0].MarkerColor = Color.FromArgb(0, 0, 255); //목표
            cht02.Series[0].MarkerSize = 0;
            cht02.Series[0].IsValueShownAsLabel = false;
            cht02.Series[0].ChartType = SeriesChartType.Column;
            cht02.Series[0].SmartLabelStyle.CalloutLineColor = Color.FromArgb(0, 0, 255); //목표

            cht02.Series[1].Color = Color.FromArgb(0, 176, 80); //실적
            cht02.Series[1].MarkerColor = Color.FromArgb(0, 176, 80); //실적
            cht02.Series[1].MarkerSize = 0;
            cht02.Series[1].ChartType = SeriesChartType.Column;
            cht02.Series[1].SmartLabelStyle.CalloutLineColor = Color.FromArgb(0, 176, 80); //실적

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            paramSet.Add("YYYY", this.cbo01_year.GetValue());
            paramSet.Add("LANG_SET", this.UserInfo.Language);
            paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
            DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA35010", "INQUERY_CHART"), paramSet);
            DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA35010", "INQUERY_TOP"), paramSet);

            cht01.DataSource = source.Tables[0];
            cht01.DataBind();

            string MM = string.Empty;            
            for (int i = 2; i < source1.Tables[0].Columns.Count; i++)
            {
                YYYY = source1.Tables[0].Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(source1.Tables[0].Rows[4][i].ToString()))
                {
                    MM = source1.Tables[0].Columns[i].ColumnName.Replace("M", "");                    
                }
            }

            if (source1.Tables[0].Rows.Count == 5)
            {
                source1.Tables[0].Rows[4].Delete();
                source1.Tables[0].AcceptChanges();
            }

            if (MM.Equals("DIV")) MM = "00";
            if (string.IsNullOrEmpty(MM)) MM = "00";

            DataTable dt1 = source.Tables[0].Copy();
            dt1.Columns.Remove("TARGET_COUNT");
            dt1.Columns.Remove("RESULT_COUNT");

            DataTable dt2 = source.Tables[0].Copy();
            dt2.Columns.Remove("TARGET_PPM");
            dt2.Columns.Remove("RESULT_PPM");
            cht01.DataSource = dt1;
            cht01.DataBind();
            cht02.DataSource = dt2;
            cht02.DataBind();

            cht01.ChartAreas[0].AxisY.Minimum = 0;
            //cht01.ChartAreas[0].AxisY.Maximum = 110;
            //cht01.ChartAreas[0].AxisY.Interval = 2;

            //cht02.ChartAreas[0].AxisY.Interval = 30;  

            for (int i = 0; i < cht01.Series[1].Points.Count; i++)
            {
                if (cht01.Series[1].Points[i].YValues[0] < cht01.Series[0].Points[i].YValues[0])
                {
                    cht01.Series[1].Points[i].MarkerColor = System.Drawing.Color.Green;
                    cht01.Series[1].Points[i].LabelForeColor = Color.Green;
                    //cht01.Series[1].Points[i].Label = "▼" + cht01.Series[1].Points[i].YValues[0].ToString();
                }
                else if (cht01.Series[1].Points[i].YValues[0] > cht01.Series[0].Points[i].YValues[0])
                {
                    cht01.Series[1].Points[i].MarkerColor = System.Drawing.Color.Red;
                    cht01.Series[1].Points[i].LabelForeColor = Color.Red;
                    cht01.Series[1].Points[i].Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
                    //cht01.Series[1].Points[i].Label = "▲" + cht01.Series[1].Points[i].YValues[0].ToString();
                }
                else
                {
                    cht01.Series[1].Points[i].MarkerColor = System.Drawing.Color.Blue;
                    cht01.Series[1].Points[i].LabelForeColor = Color.Blue;
                }
            }

            for (int i = 0; i < cht02.Series[1].Points.Count; i++)
            {
                if (cht02.Series[1].Points[i].YValues[0] < cht02.Series[0].Points[i].YValues[0])
                {
                    cht02.Series[1].Points[i].MarkerColor = System.Drawing.Color.Green;
                    cht02.Series[1].Points[i].LabelForeColor = Color.Green;
                    //cht02.Series[1].Points[i].Label = "▼" + cht02.Series[1].Points[i].YValues[0].ToString();
                }
                else if (cht02.Series[1].Points[i].YValues[0] > cht02.Series[0].Points[i].YValues[0])
                {
                    cht02.Series[1].Points[i].MarkerColor = System.Drawing.Color.Red;
                    cht02.Series[1].Points[i].LabelForeColor = Color.Red;
                    cht02.Series[1].Points[i].Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
                    //cht02.Series[1].Points[i].Label = "▲" + cht02.Series[1].Points[i].YValues[0].ToString();
                }
                else
                {
                    cht02.Series[1].Points[i].MarkerColor = System.Drawing.Color.Blue;
                    cht02.Series[1].Points[i].LabelForeColor = Color.Blue;
                }
            }

            grd03.BeginUpdate();
            grd03.SetValue(source1.Tables[0]);

            grd03.SetCellImage(1, 1, Properties.Resources.blue_bar);//2014-11-25
            grd03.SetCellImage(2, 1, Properties.Resources.BLUE_STRAIGHT_BAR2);//2014-11-25
            grd03.SetCellImage(3, 1, Properties.Resources.GREEN_bar);//2014-11-25
            grd03.SetCellImage(4, 1, Properties.Resources.GREEM_STRAIGHT_BAR2);//2014-11-25

            Font ft = new Font("맑은 고딕", (grd03.Font.Size * 0.75F), System.Drawing.FontStyle.Bold);
            C1.Win.C1FlexGrid.CellStyle cs2 = grd03.Styles.Add("ChangeSize");
            cs2.Font = ft;
            cs2.ForeColor = Color.Black;
            grd03.SetCellStyle(1, 1, grd03.Styles["ChangeSize"]);
            grd03.SetCellStyle(2, 1, grd03.Styles["ChangeSize"]);
            grd03.SetCellStyle(3, 1, grd03.Styles["ChangeSize"]);
            grd03.SetCellStyle(4, 1, grd03.Styles["ChangeSize"]);

            grd03.EndUpdate();
            return MM;
        }
 
        #endregion


        #region [ 기타 컨트롤 이벤트 정의]

        private void grd01_Resize(object sender, EventArgs e)
        {
            AxFlexGrid grd = (AxFlexGrid)sender;
            try
            {
                int Cols = grd.Cols.Count - 6;
                int rows = grd.Rows.Count;
                int gridheight = grd.Height;

                if (Cols >= 1)
                {
                    Decimal gridWidth = (decimal.Parse(grd.Width.ToString()) - 85 - 150) / Cols;

                    Decimal gridHeight = (decimal.Parse(gridheight.ToString())) / (rows);

                    for (int i = 1; i <= Cols + 5; i++)
                    {
                        if (i == 1)
                            grd.Cols[i].Width = 85;
                        else if (i == 2)
                            grd.Cols[i].Width = 150;
                        else if (i == 3)
                            grd.Cols[i].Width = (int.Parse(gridWidth.ToString()) - 2) / 3;
                        else if (i == 6)
                            grd.Cols[i].Width = (int.Parse(gridWidth.ToString()) - 2) / 3;
                        else if (i == 5)
                            grd.Cols[i].Width = (int.Parse(gridWidth.ToString()) - 2) / 3;
                        else
                            grd.Cols[i].Width = (int.Parse(gridWidth.ToString()) - 2) / 3;
                    } 

                    for (int j = 0; j < rows; j++)
                    {

                        if (j == 0) grd.Rows[j].Height = (grd.Height - (int.Parse(Math.Round(gridHeight).ToString()) * (rows - 1)) - 2);
                        else grd.Rows[j].Height = int.Parse(Math.Round(gridHeight).ToString());
                    }

                    //grd.Refresh();
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }

        private void grd03_Resize(object sender, EventArgs e)
        {
            try
            {
                AxFlexGrid grd = this.grd03;
                panel9.Padding = new Padding(Convert.ToInt32(Math.Round(panel9.Width * 0.06).ToString()), 0, 0, 0);

                int Cols = grd.Cols.Count - 1;
                int gridTotalWidth = 0;
                Decimal test = (panel9.Width - (panel9.Padding.Left)) / 13;

                for (int i = 1; i <= Cols; i++)
                {
                    grd.Cols[i].Width = Convert.ToInt32(Math.Round(test).ToString()) + 1;
                    gridTotalWidth = gridTotalWidth + grd.Cols[i].Width;
                }

                grd.Width = gridTotalWidth+2;

                if (Cols > 1)
                {
                    Decimal halfColumnWidth = grd.Cols[1].Width / 2;
                    int leftPadding = panel9.Padding.Left - Convert.ToInt32(Math.Round(halfColumnWidth));

                    panel9.Padding = new Padding(leftPadding, 0, 0, 0);
                }
                grd.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void grd03_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (grd03.MouseRow < grd03.Rows.Fixed) return;

                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (grd03.Col == grd03.Cols["M01"].Index || grd03.Col == grd03.Cols["M02"].Index
                        || grd03.Col == grd03.Cols["M03"].Index
                        || grd03.Col == grd03.Cols["M04"].Index
                        || grd03.Col == grd03.Cols["M05"].Index
                        || grd03.Col == grd03.Cols["M06"].Index
                        || grd03.Col == grd03.Cols["M07"].Index
                        || grd03.Col == grd03.Cols["M08"].Index
                        || grd03.Col == grd03.Cols["M09"].Index
                        || grd03.Col == grd03.Cols["M10"].Index
                        || grd03.Col == grd03.Cols["M11"].Index
                        || grd03.Col == grd03.Cols["M12"].Index)
                    {
                        if (grd03.SelectedRowIndex < 1) return;
                        string month = this.grd03.GetValue(0, grd03.Col).ToString();
                        ShowBottomChart(month, grd03.Col - 1, 1);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void chart1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Call Hit Test Method
            HitTestResult result = cht01.HitTest(e.X, e.Y);
            if ((result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel) && result.PointIndex != -1)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
                    var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                    var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                    // check if the cursor is really close to the point (2 pixels around the point)
                    if (Math.Abs(e.X - pointXPixel) < 25 && Math.Abs(e.Y - pointYPixel) < 25)
                    {
                        //MsgBox.Show(prop.XValue +"," + prop.YValues[0]);
                        ShowBottomChart(this.grd03.GetValue(0, (int)prop.XValue + 1).ToString(), (int)prop.XValue, 1);
                    }
                }
            }
        }

        private void chart1_Customize(object sender, EventArgs e)
        {
            foreach (var label in cht01.ChartAreas[0].AxisY.CustomLabels)
            {
                if (decimal.Parse(label.Text.Replace(",", "").Replace(".", "").Replace(" ", "")) < 0)
                    label.Text = string.Empty;
            }
        }

        private void QA35010_Resize(object sender, EventArgs e)
        {
            panel5.Height = (int)(panel3.Height * 0.7);   
        }

        #endregion              

        
    }
}
