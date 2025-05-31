#region ▶ Description & History
/* 
 * 프로그램명 : QA30802 측정 결과 조회 (기간별)
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2015-07-29      배명희      통합WCF로 변경 
 *				2017-07-13      배명희      점검항목 유형코드화(QQ) 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Drawing;
using C1.Win.C1Chart;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b> 측정결과 조회 기간별</b>
    /// - 작 성 자 : 배명희<br />
    /// - 작 성 일 : 2014-10-08<br />
    /// </summary>
    public partial class QA30802 : AxCommonBaseControl
    {
        #region [필드에 대한 정의]
        
        private AxClientProxy _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        private string PAKAGE_NAME = "APG_QA30802";
        private string PAKAGE_NAME_QA20801 = "APG_QA20801";
        #endregion

        #region [초기화 설정에 대한 정의]

        public QA30802()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.heDockingTab1.LinkPanel = this.panel2;
                this.heDockingTab1.LinkBody = this.panel1;

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                #region [코드박스 세팅]

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VIN");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDNM");//"업체명";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

              
                #endregion

                #region [콤보상자 세팅]

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);              
                this.cbo01_BIZCD.Enabled = (this.UserInfo.IsAdmin == "Y" ? true : false);
                
                //사용여부
                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                
               
                
                #endregion

                #region [그리드 세팅]
                
                #region [grd01 관리item 기준 목록 그리드 세팅]

                HEParameterSet paramSet_MEAS_UNIT = new HEParameterSet();
                paramSet_MEAS_UNIT.Add("CLASS_ID", "FR");
                paramSet_MEAS_UNIT.Add("OBJECT_ID", "");
                paramSet_MEAS_UNIT.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD(paramSet_MEAS_UNIT);          
                DataSet combo_source_MEAS_UNIT = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD"), paramSet_MEAS_UNIT);

                //점검항목
                HEParameterSet paramSet_CHECK_ITEMCD = new HEParameterSet();
                paramSet_CHECK_ITEMCD.Add("CLASS_ID", "QQ");
                paramSet_CHECK_ITEMCD.Add("OBJECT_ID", "");
                paramSet_CHECK_ITEMCD.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD(paramSet_MEAS_UNIT);
                DataSet combo_source_CHECK_ITEMCD = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD"), paramSet_CHECK_ITEMCD);

                DataTable source_SMIS_TRANS = AxFlexGrid.GetDataSourceSchema("CODE", "NAME").Tables[0];
                source_SMIS_TRANS.Rows.Add("Y", "●");
                source_SMIS_TRANS.Rows.Add("N", "");

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "관리번호",    "SERIAL",       "MGRTNO");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종",     "VINCD",        "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "점검항목", "CHECK_ITEMCD", "CHECK_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "색상",     "COLOR",        "CLR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "GRADE",    "GR",           "GRADE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "칼라코드", "COLORCD",      "COLORCD");                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "업체명",   "VENDCD",       "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "규격",     "STANDARD",     "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "규격이하", "STD_UNDER",    "STD_UNDER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "주의관찰", "OBSERVED",     "OBSERVED");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "관리양호", "MGT_GOOD",     "MGT_GOOD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "규격이상", "STD_OVER",     "STD_OVER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "측정단위", "MEAS_UNITCD",  "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "SMIS전송대상", "SMIS_TRANS", "SMIS_TRANS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "사용여부", "USE_YN",       "USEYN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "적용일자", "APP_DATE",     "APP_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "비고",     "REMARK",       "REMARK");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "STD_OVER_FROM", "STD_OVER_FROM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "STD_OVER_TO", "STD_OVER_TO");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "MGT_GOOD_FROM", "MGT_GOOD_FROM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "MGT_GOOD_TO", "MGT_GOOD_TO");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "OBSERVED_FROM", "OBSERVED_FROM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "OBSERVED_TO", "OBSERVED_TO");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "STD_UNDER_FROM", "STD_UNDER_FROM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 000, "STD_UNDER_TO", "STD_UNDER_TO");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "APP_DATE");


                //그리드 컬럼 헤더 배경색 (관리기준 범례(CD4160)에서 지정한 색으로)
                this.grd01.Styles.Add("csMGT_GOOD");
                this.grd01.Styles.Add("csOBSERVED");
                this.grd01.Styles.Add("csMGT_OUT");

                //그리드 콤보박스 설정
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_MEAS_UNIT.Tables[0], "MEAS_UNITCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_CHECK_ITEMCD.Tables[0], "CHECK_ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_SMIS_TRANS, "SMIS_TRANS");
                #endregion

                #region [grd03 이상발생 조치결과 그리드 세팅]

                this.grd03.AllowEditing = false;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Initialize();
                this.grd03.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 000, "순번", "SERIAL", "SERIAL");

                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "일자", "RCV_DATE", "DD");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "LOT NO", "LOTNO", "LOTNO");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "색상", "COLOR", "CLR");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "GRADE", "GR", "GRADE");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "칼라코드", "COLORCD", "COLORCD");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "업체명", "VENDCD", "VENDNM");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "이상발생 조치 결과", "MGRT_RESULT", "ERR_MGRT_RESULT");

                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD");
                this.grd03.ExtendLastCol = true;
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                #endregion

                #endregion

                #region [차트 세팅]
                //차트 시리즈 클리어
                //this.c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
                this.c1Chart1.ChartArea.Margins.Left = 60;
                this.c1Chart1.ChartArea.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None;
                this.c1Chart1.ToolTip.Enabled = true;
                this.c1Chart1.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None;

                #endregion

                this.cbo01_BIZCD.SelectedIndexChanged += new EventHandler(cbo01_BIZCD_SelectedIndexChanged);


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.Query_CD4160(_CORCD, _BIZCD);


                this.BtnReset_Click(null, null);
              
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [공통 버튼에 대한 이벤트 정의 ]

        /// <summary>
        /// 입력 컨트롤 초기화 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
              
               //초기화
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_EDATE.SetMMFromEnd();
                this.cdx01_VENDCD.Initialize();
                this.cbo01_USE_YN.SetValue("Y");

                //관리item기준 목록 초기화
                this.grd01.InitializeDataSource();

                //차트초기화
                this.c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
                this.c1Chart1.ChartLabels.LabelsCollection.Clear();

                //이상발생 조치결과 그리드 초기화
                this.grd03.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            string CORCD = this._CORCD;
            string BIZCD = this._BIZCD;

            //관리item 기준 목록 조회
            this.Query_CD4150();


            //차트초기화
            this.c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
            this.c1Chart1.ChartLabels.LabelsCollection.Clear();
        
            //이상발생 조치결과 그리드 초기화
            this.grd03.InitializeDataSource();
     
        }
       
        #endregion

        #region [컨트롤 이벤트]

        /// <summary>
        /// 더블클릭시 해당 SERIAL 기준으로 
        /// 예방관리도(차트)표시하고, 측정 데이터 그리드와 이상발생 조치결과 그리드를 바인딩 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;


                //this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                //차트초기화
                this.c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
                this.c1Chart1.ChartLabels.LabelsCollection.Clear();

                string SERIAL = this.grd01.GetValue(row, "SERIAL").ToString();

                this.BtnQuery_Click(SERIAL);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                //this.cdx02_INSPECT_EMPNO.HEUserParameterSetValue("BIZCD", _BIZCD);
                this.Query_CD4160(_CORCD, _BIZCD);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void c1Chart1_SizeChanged(object sender, EventArgs e)
        {
            QA30801.RepositionLabel((C1Chart)sender);
        }

        #endregion
        
        #region [조회]

        /// <summary>
        /// 관리ITEM 기준 목록 조회(grd01)
        /// </summary>
        private void Query_CD4150()
        {
            try
            {
                string CORCD = this._CORCD;
                string BIZCD = this._BIZCD;
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string USE_YN = this.cbo01_USE_YN.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("VINCD", VINCD);
                set.Add("VENDCD", VENDCD);
                set.Add("SDATE", this.dte01_SDATE.GetDateText());
                set.Add("EDATE", this.dte01_EDATE.GetDateText());
                set.Add("USE_YN", USE_YN);
                set.Add("LANG_SET", _LANG_SET);
                set.Add("USER_ID", this.UserInfo.UserID);
                set.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //관리ITEM 기준 조회
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);
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
        /// 측정 데이터 등록 정보 및 이상발생 조치결과 그리드 바인딩(grd02, grd03)
        /// </summary>
        /// <param name="SERIAL"></param>
        private void BtnQuery_Click(string SERIAL)
        {
            try
            {
                _SERIAL = SERIAL;

                HEParameterSet set = new HEParameterSet();
            
                set.Add("SERIAL",   SERIAL);
                set.Add("SDATE", this.dte01_SDATE.GetDateText());
                set.Add("EDATE", this.dte01_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet chart = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CHART"), set);

                QA30801.BindSeries(c1Chart1, 0, chart.Tables[0].DefaultView, "MEAS_METER", "RCV_DATE");

                // Define each of the letter grades
                string[] zoneName = new String[] { "STD_OVER", "MGT_GOOD", "OBSERVED", "STD_UNDER" };
                string[] zoneLetter = new String[] {this.grd01.GetValue(0, "STD_OVER").ToString(), 
                                                    this.grd01.GetValue(0, "MGT_GOOD").ToString(), 
                                                    this.grd01.GetValue(0, "OBSERVED").ToString(), 
                                                    this.grd01.GetValue(0, "STD_UNDER").ToString() };
                Color[] zoneColor = new Color[]
			    {
				    this.pnl03_MGT_OUT_COLOR.BackColor, this.pnl03_MGT_GOOD_COLOR.BackColor, this.pnl03_OBSERVED_COLOR.BackColor, this.pnl03_MGT_OUT_COLOR.BackColor
			    };

                double[] zoneFrom = new double[]{ Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "STD_OVER_FROM")),
                                                Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "MGT_GOOD_FROM")),
                                                Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "OBSERVED_FROM")),
                                                Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "STD_UNDER_FROM"))};
                double[] zoneTo = new double[]{ Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "STD_OVER_TO")),
                                                Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "MGT_GOOD_TO")),
                                                Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "OBSERVED_TO")),
                                                Convert.ToDouble(this.grd01.GetValue(this.grd01.Row, "STD_UNDER_TO"))};

                QA30801.SetChartZone(c1Chart1, zoneName, zoneLetter, zoneColor, zoneFrom, zoneTo);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MGRT_RESULT"), set);
             
                this.grd03.SetValue(source);
              
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        /// <summary>
        /// 관리기준 범례 조회
        /// </summary>
        /// <param name="corcd"></param>
        /// <param name="bizcd"></param>
        private void Query_CD4160(string corcd, string bizcd)
        {
            try
            {
                this.BeforeInvokeServer();
                HEParameterSet set2 = new HEParameterSet();
                set2.Add("CORCD", corcd);
                set2.Add("BIZCD", bizcd);
                set2.Add("LANG_SET", this.UserInfo.Language);
                set2.Add("USER_ID", this.UserInfo.UserID);
                set2.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                DataSet source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA20801, "INQUERY_CD4160"), set2);

                if (source2.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source2.Tables[0].Rows[0];
                   
                    this.pnl03_MGT_GOOD_COLOR.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["MGT_GOOD_COLOR"].ToString());
                    this.pnl03_OBSERVED_COLOR.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["OBSERVED_COLOR"].ToString());
                    this.pnl03_MGT_OUT_COLOR.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["MGT_OUT_COLOR"].ToString());

                    this.grd01.Rows[0].StyleNew.Clear();

                    CellStyle cs = this.grd01.Styles["csMGT_GOOD"];
                    cs.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["MGT_GOOD_COLOR"].ToString());
                    this.grd01.SetCellStyle(0, this.grd01.Cols["MGT_GOOD"].Index, cs);

                    cs = this.grd01.Styles["csOBSERVED"];
                    cs.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["OBSERVED_COLOR"].ToString());
                    this.grd01.SetCellStyle(0, this.grd01.Cols["OBSERVED"].Index, cs);

                    cs = this.grd01.Styles["csMGT_OUT"];
                    cs.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["MGT_OUT_COLOR"].ToString());
                    this.grd01.SetCellStyle(0, this.grd01.Cols["STD_UNDER"].Index, cs);
                    this.grd01.SetCellStyle(0, this.grd01.Cols["STD_OVER"].Index, cs);
                }
                else
                {
            
                    this.pnl03_MGT_GOOD_COLOR.BackColor = Color.Transparent;
                    this.pnl03_OBSERVED_COLOR.BackColor = Color.Transparent;
                    this.pnl03_MGT_OUT_COLOR.BackColor = Color.Transparent;


                    CellStyle cs = this.grd01.Styles["csMGT_GOOD"];
                    cs.BackColor = this.grd01.Styles.Fixed.BackColor;
                    this.grd01.SetCellStyle(0, this.grd01.Cols["MGT_GOOD"].Index, cs);

                    cs = this.grd01.Styles["csOBSERVED"];
                    cs.BackColor = this.grd01.Styles.Fixed.BackColor;
                    this.grd01.SetCellStyle(0, this.grd01.Cols["OBSERVED"].Index, cs);

                    cs = this.grd01.Styles["csMGT_OUT"];
                    cs.BackColor = this.grd01.Styles.Fixed.BackColor;
                    this.grd01.SetCellStyle(0, this.grd01.Cols["STD_UNDER"].Index, cs);
                    this.grd01.SetCellStyle(0, this.grd01.Cols["STD_OVER"].Index, cs);


                }
                this.AfterInvokeServer();
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
    }
}
