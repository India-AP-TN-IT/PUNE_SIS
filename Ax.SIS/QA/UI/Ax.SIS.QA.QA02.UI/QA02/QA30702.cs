#region ▶ Description & History
/* 
 * 프로그램명 : QA30702 X-BAR R 관리 결과 조회(기간별)
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
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>X-Bar R 관리 결과 조회(월별)</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-04-06 오후 5:29:52<br />
    /// </summary>
    public partial class QA30702 : AxCommonBaseControl
    {
        //private IQA30702 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30702";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 설정에 대한 정의 ]

        public QA30702()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30702>("QA02", "QA30702.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();

                this.cdx01_MEAS_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_MEAS_ITEMCD.PopupTitle = this.GetLabel("ITEMNM3");//"품명";
                this.cdx01_MEAS_ITEMCD.CodeParameterName = "CODE";
                this.cdx01_MEAS_ITEMCD.NameParameterName = "NAME";
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("BIZCD", _BIZCD);
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("VINCD", this.cdx01_VINCD.GetValue());
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("ITEMCD", this.cdx01_ITEMCD.GetValue());
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDNM");//"업체명";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = this.UserInfo.IsAdmin == "Y";

                //PLANT
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                HEParameterSet paramSet_INSPECT_UNIT = new HEParameterSet();
                paramSet_INSPECT_UNIT.Add("CLASS_ID", "IU");
                paramSet_INSPECT_UNIT.Add("GROUPCD",  "BCD");
                paramSet_INSPECT_UNIT.Add("LANG_SET", _LANG_SET);

                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD_GROUP(paramSet_INSPECT_UNIT);
                DataSet combo_source_MEAS_UNIT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD_GROUP"), paramSet_INSPECT_UNIT);

                //DataSet combo_source_TYPENM = _WSCOMBOBOX.Inquery_TYPENM();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", _LANG_SET);
                DataSet combo_source_TYPENM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPENM"), paramSet);

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 040, "순번", "SERIAL", "SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "품목", "ITEMCD", "ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명", "MEAS_ITEMCD", "ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "부위사진", "STD_PHOTO", "STD_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "측정기", "MEAS_INST", "MEAS_INST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "하한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 110, "상한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "측정단위", "MEAS_UNIT", "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "업체명", "VENDCD", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "측정업체명", "VENDCD2", "VENDNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "측정자", "MEAS_POINT", "MEAS_POINT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "Gauge R&R",    "GATE_RNR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 160, "VAN 등록여부", "VAN_IF_YN", "VAN_IF_YN");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_TYPENM.Tables[0], "MEAS_ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_MEAS_UNIT.Tables[0], "MEAS_UNIT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STANDARD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STD_MIN_MEAS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STD_MAX_MEAS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "GATE_RNR");
                this.grd01.Cols["STANDARD"].Format = "###,###,###,###.##";
                this.grd01.Cols["STD_MIN_MEAS"].Format = "###,###,###,###.##";
                this.grd01.Cols["STD_MAX_MEAS"].Format = "###,###,###,###.##";
                this.grd01.Cols["GATE_RNR"].Format = "###,###,###,###.##";

                this.ControlSetting();
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-") + "01");

                this.cbo01_USE_YN.SetValue("Y");

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this._SERIAL = "";

                this.cht02_R.DataSource = new DataTable();
                this.cht02_R.DataBind();

                this.cht02_X.DataSource = new DataTable();
                this.cht02_X.DataBind();

                this.cht02_R_COPY.DataSource = new DataTable();
                this.cht02_R_COPY.DataBind();

                this.cht02_X_COPY.DataSource = new DataTable();
                this.cht02_X_COPY.DataBind();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string CORCD        = this._CORCD;
                string BIZCD        = this._BIZCD;
                string VINCD        = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD       = this.cdx01_ITEMCD.GetValue().ToString();
                string MEAS_ITEMCD  = this.cdx01_MEAS_ITEMCD.GetValue().ToString();
                string VENDCD       = this.cdx01_VENDCD.GetValue().ToString();
                string USE_YN       = this.cbo01_USE_YN.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",        CORCD);
                set.Add("BIZCD",        BIZCD);
                set.Add("VINCD",        VINCD);
                set.Add("ITEMCD",       ITEMCD);
                set.Add("MEAS_ITEMCD",  MEAS_ITEMCD);
                set.Add("VENDCD",       VENDCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("PLANT_DIV", PLANT_DIV);
                set.Add("LANG_SET",  this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
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
        
        #endregion

        #region [컨트롤 이벤트]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _BIZCD = this.cbo01_BIZCD.GetValue().ToString();

                this.cdx01_VINCD.Initialize();
                this.cdx01_ITEMCD.Initialize();
                this.cdx01_MEAS_ITEMCD.Initialize();

                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("CORCD", _CORCD);
                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("BIZCD", _BIZCD);
                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue());
                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("ITEMCD", this.cdx01_ITEMCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_VINCD_ITEM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_MEAS_ITEMCD.Initialize();

                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("CORCD",     _CORCD);
                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("BIZCD",     _BIZCD);
                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("VINCD",     this.cdx01_VINCD.GetValue());
                this.cdx01_MEAS_ITEMCD.HEUserParameterSetValue("ITEMCD",    this.cdx01_ITEMCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                if (e.Button != MouseButtons.Left) return;

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                _SERIAL = this.grd01.GetValue(row, "SERIAL").ToString();

                this.InqueryChart();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_CLS_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl_VIEW.Visible = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_VIEW_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl_VIEW.Visible = true;
                this.panel12.Size = new Size(this.pnl_VIEW.Size.Width, this.pnl_VIEW.Size.Height / 2);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [기타 이벤트]

        private void ControlSetting()
        {
            try
            {
                this.lbl02_X.Value = this.GetLabel("X_BAR_VERTICAL");//"X\r\n\r\n관\r\n리\r\n도";
                this.lbl02_R.Value = this.GetLabel("R-BAR-VERTICAL");//"R\r\n\r\n관\r\n리\r\n도";

                this.lbl02_X_COPY.Value = this.GetLabel("X_BAR_VERTICAL");//"X\r\n\r\n관\r\n리\r\n도";
                this.lbl02_R_COPY.Value = this.GetLabel("R-BAR-VERTICAL");//"R\r\n\r\n관\r\n리\r\n도";

                cht02_X.Legends[0].Enabled = false;
                cht02_X.ChartAreas[0].AxisX.IsMarginVisible = false;
                cht02_X.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;
                cht02_X.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                cht02_X.Series["UCL"].BorderWidth = 2;
                cht02_X.Series["LCL"].BorderWidth = 2;
                cht02_X.Series["XCL"].BorderWidth = 2;
                cht02_X.Series["UCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                cht02_X.Series["LCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

                cht02_R.Legends[0].Enabled = false;
                cht02_R.ChartAreas[0].AxisX.IsMarginVisible = false;
                cht02_R.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;
                cht02_R.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                cht02_R.Series["UCL"].BorderWidth = 2;
                cht02_R.Series["LCL"].BorderWidth = 2;
                cht02_R.Series["RCL"].BorderWidth = 2;
                cht02_R.Series["UCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                cht02_R.Series["LCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

                cht02_X_COPY.Legends[0].Enabled = true;
                cht02_X_COPY.ChartAreas[0].AxisX.IsMarginVisible = false;
                cht02_X_COPY.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;
                cht02_X_COPY.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                cht02_X_COPY.Series["UCL"].BorderWidth = 2;
                cht02_X_COPY.Series["LCL"].BorderWidth = 2;
                cht02_X_COPY.Series["XCL"].BorderWidth = 2;
                cht02_X_COPY.Series["UCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                cht02_X_COPY.Series["LCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

                cht02_R_COPY.Legends[0].Enabled = true;
                cht02_R_COPY.ChartAreas[0].AxisX.IsMarginVisible = false;
                cht02_R_COPY.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;
                cht02_R_COPY.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                cht02_R_COPY.Series["UCL"].BorderWidth = 2;
                cht02_R_COPY.Series["LCL"].BorderWidth = 2;
                cht02_R_COPY.Series["RCL"].BorderWidth = 2;
                cht02_R_COPY.Series["UCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                cht02_R_COPY.Series["LCL"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

                //2015.04.22 차트 레이아웃 다듬기
                cht02_X.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
                cht02_X_COPY.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
                cht02_R.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
                cht02_R_COPY.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
                cht02_X.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                cht02_X_COPY.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                cht02_R.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                cht02_R_COPY.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                cht02_X.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                cht02_X_COPY.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                cht02_R.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                cht02_R_COPY.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;


                this.pnl_VIEW.Dock = DockStyle.Fill;
                this.pnl_VIEW.Visible = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryChart()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("SDATE",        this.dte01_SDATE.GetDateText());
                set.Add("EDATE",        this.dte01_EDATE.GetDateText());
                set.Add("LANG_SET",     this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Chart(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CHART"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count != 0)
                {
                    //2015.04.22 여백주기
                    double min = double.Parse(source.Tables[0].Rows[0]["X_MIN"].ToString());
                    double max = double.Parse(source.Tables[0].Rows[0]["X_MAX"].ToString());

                    cht02_X.ChartAreas[0].AxisY.Minimum = min - ((max - min) * 0.1);
                    cht02_X.ChartAreas[0].AxisY.Maximum = max + ((max - min) * 0.1);
                    //cht02_X.ChartAreas[0].AxisY.Minimum = double.Parse(source.Tables[0].Rows[0]["X_MIN"].ToString());
                    //cht02_X.ChartAreas[0].AxisY.Maximum = double.Parse(source.Tables[0].Rows[0]["X_MAX"].ToString());

                    cht02_X.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["X_INTER"].ToString());

                    cht02_R.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["R_INTER"].ToString());

                    this.cht02_X.DataSource = source.Tables[0];
                    this.cht02_X.DataBind();
                    this.cht02_R.DataSource = source.Tables[0];
                    this.cht02_R.DataBind();

                    //2015.04.22 여백주기                    
                    cht02_X_COPY.ChartAreas[0].AxisY.Minimum = min - ((max - min) * 0.1);
                    cht02_X_COPY.ChartAreas[0].AxisY.Maximum = max + ((max - min) * 0.1);
                    //cht02_X_COPY.ChartAreas[0].AxisY.Minimum = double.Parse(source.Tables[0].Rows[0]["X_MIN"].ToString());
                    //cht02_X_COPY.ChartAreas[0].AxisY.Maximum = double.Parse(source.Tables[0].Rows[0]["X_MAX"].ToString());

                    cht02_X_COPY.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["X_INTER"].ToString());

                    cht02_R_COPY.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["R_INTER"].ToString());

                    this.cht02_X_COPY.DataSource = source.Tables[0];
                    this.cht02_X_COPY.DataBind();
                    this.cht02_R_COPY.DataSource = source.Tables[0];
                    this.cht02_R_COPY.DataBind();


                    initChartScroll(this.cht02_R, source.Tables[0].Rows.Count - 1);
                    initChartScroll(this.cht02_R_COPY, source.Tables[0].Rows.Count - 1);
                    initChartScroll(this.cht02_X, source.Tables[0].Rows.Count - 1);
                    initChartScroll(this.cht02_X_COPY, source.Tables[0].Rows.Count - 1);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        //2015.04.22 차트에 스크롤 넣기
        private void initChartScroll(System.Windows.Forms.DataVisualization.Charting.Chart chart, int dataCnt)
        {
            try
            {
                chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                chart.ChartAreas[0].AxisX.ScrollBar.Size = 10;
                chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;

                if (chart.Name.IndexOf("COPY") > -1)
                    chart.ChartAreas[0].AxisX.ScaleView.Size = (dataCnt < 16) ? dataCnt : 16;
                else
                    chart.ChartAreas[0].AxisX.ScaleView.Size = (dataCnt < 12) ? dataCnt : 12;

                chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 1;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}
