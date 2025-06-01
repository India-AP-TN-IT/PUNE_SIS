#region ▶ Description & History
/* 
 * 프로그램명 : QA30701 X-BAR R 관리 결과 조회(월별)
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
using System.Text;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>X-Bar R 관리 결과 조회(월별)</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-04-06 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30701 : AxCommonBaseControl
    {
        //private IQA30701 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;
        private int _SAMPLE_CNT;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30701";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 설정에 대한 정의 ]

        public QA30701()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30701>("QA02", "QA30701.svc", "CustomBinding");
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
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");// "차종코드";
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

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_TYPENM = _WSCOMBOBOX.Inquery_TYPENM();
                DataSet combo_source_TYPENM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPENM"), paramSet);

                this.pic02_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false,AxFlexGrid.FtextAlign.C, 040, "순번",         "SERIAL","SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종",         "VINCD","VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "품목",         "ITEMCD","ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명",         "MEAS_ITEMCD","ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "부위사진", "STD_PHOTO", "STD_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "측정기", "MEAS_INST", "MEAS_INST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "하한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "상한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "측정단위", "MEAS_UNIT", "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "업체명", "VENDCD", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "측정업체명", "VENDCD2", "VENDNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "측정자", "MEAS_POINT", "MEAS_POINT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "Gauge R&R", "GATE_RNR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "VAN 등록여부", "VAN_IF_YN", "VAN_IF_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 055, "CPK",          "CPK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "판정", "DECISION", "DECISION");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "이슈여부", "ISSUE_YN", "ISSUE_YN");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "이슈타입", "ISSUE_TYPE", "ISSUE_TYPE");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "시료수", "SAMPLE_CNT", "SAMPLE_CNT");
                

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
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CPK");
                this.grd01.Cols["STANDARD"].Format = "###,###,###,###.##";
                this.grd01.Cols["STD_MIN_MEAS"].Format = "###,###,###,###.##";
                this.grd01.Cols["STD_MAX_MEAS"].Format = "###,###,###,###.##";
                this.grd01.Cols["GATE_RNR"].Format = "###,###,###,###.##";
                this.grd01.Cols["CPK"].Format = "###,###,###,###.###";

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();

                this.grd02.Cols[0].Width = 140;

                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "01", "D_01");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "02", "D_02");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "03", "D_03");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "04", "D_04");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "05", "D_05");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "06", "D_06");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "07", "D_07");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "08", "D_08");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "09", "D_09");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "10", "D_10");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "11", "D_11");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "12", "D_12");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "13", "D_13");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "14", "D_14");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "15", "D_15");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "16", "D_16");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "17", "D_17");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "18", "D_18");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "19", "D_19");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "20", "D_20");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "21", "D_21");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "22", "D_22");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "23", "D_23");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "24", "D_24");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "25", "D_25");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "26", "D_26");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "27", "D_27");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "28", "D_28");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "29", "D_29");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "30", "D_30");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "31", "D_31");

                this.ControlSetting();

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
                this.pnl02_ERROR_VIEW.Visible = false;

                this._SERIAL = "";
                this._SAMPLE_CNT = 5;
                this.lbl02_ERROR_VIEW.Value = "";

                this.pic02_STD_PHOTO.Initialize();
                this.nme02_XCL.Initialize();
                this.nme02_XUCL.Initialize();
                this.nme02_XLCL.Initialize();
                this.nme02_RCL.Initialize();
                this.nme02_RUCL.Initialize();
                this.nme02_RLCL.Initialize();
                this.nme02_AVG.Initialize();
                this.nme02_A.Initialize();
                this.nme02_SU.Initialize();
                this.nme02_SL.Initialize();
                this.nme02_CP.Initialize();
                this.nme02_K.Initialize();
                this.nme02_CPK.Initialize();
                this.txt02_DECISION.Initialize();

                this.initialize_grd02();

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
                this.BtnReset_Click(null, null);

                string CORCD        = this._CORCD;
                string BIZCD        = this._BIZCD;
                string VINCD        = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD       = this.cdx01_ITEMCD.GetValue().ToString();
                string MEAS_ITEMCD  = this.cdx01_MEAS_ITEMCD.GetValue().ToString();
                string VENDCD       = this.cdx01_VENDCD.GetValue().ToString();
                string USE_YN       = this.cbo01_USE_YN.GetValue().ToString();
                string YYYYMM       = this.dte01_YYYYMM.GetDateText().Substring(0, 7);
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",        CORCD);
                set.Add("BIZCD",        BIZCD);
                set.Add("VINCD",        VINCD);
                set.Add("ITEMCD",       ITEMCD);
                set.Add("MEAS_ITEMCD",  MEAS_ITEMCD);
                set.Add("VENDCD",       VENDCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("YYYYMM",       YYYYMM);
                set.Add("PLANT_DIV",    PLANT_DIV);
                set.Add("LANG_SET",     this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

                this.grd01.SetValue(source);
                this.set_gridBackColorStyle();
                
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
                _SAMPLE_CNT = int.Parse(this.grd01.GetValue(row, "SAMPLE_CNT").ToString());

                int ISSUE_TYPE = Convert.ToInt32(this.grd01.GetValue(row, "ISSUE_TYPE").ToString(), 2);

                this.InqueryGrid();
                this.InqueryData();
                this.InqueryChart();
                this.InqueryError(ISSUE_TYPE);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void grd01_AfterSort(object sender, SortColEventArgs e)
        {
            try
            {
                this.set_gridBackColorStyle();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void InqueryError(int ISSUE_TYPE)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if ((ISSUE_TYPE & Convert.ToInt32("0000000001", 2)) == Convert.ToInt32("0000000001", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR1"));//("런의 길이가 7점 이상 연속 발생");

                if ((ISSUE_TYPE & Convert.ToInt32("0000000010", 2)) == Convert.ToInt32("0000000010", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR2"));//("경향이 7점 이상 연속 발생");

                if ((ISSUE_TYPE & Convert.ToInt32("0000000100", 2)) == Convert.ToInt32("0000000100", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR3"));//("한쪽에 점이 잇따라 발생(연속 11점 중 10점 이상)");

                if ((ISSUE_TYPE & Convert.ToInt32("0000001000", 2)) == Convert.ToInt32("0000001000", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR4"));//("한쪽에 점이 잇따라 발생(연속 17점 중 14점 이상)");

                if ((ISSUE_TYPE & Convert.ToInt32("0000010000", 2)) == Convert.ToInt32("0000010000", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR5"));//("한쪽에 점이 잇따라 발생(연속 20점 중 16점 이상)");

                if ((ISSUE_TYPE & Convert.ToInt32("0000100000", 2)) == Convert.ToInt32("0000100000", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR6"));//("관리한계에 근접 발생(연속 3점중 2점 이상)");

                if ((ISSUE_TYPE & Convert.ToInt32("0001000000", 2)) == Convert.ToInt32("0001000000", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR7"));//("관리한계에 근접 발생(연속 7점중 3점 이상)");

                if ((ISSUE_TYPE & Convert.ToInt32("0010000000", 2)) == Convert.ToInt32("0010000000", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR8"));//("관리한계에 근접 발생(연속 10점중 4점 이상)");

                if ((ISSUE_TYPE & Convert.ToInt32("0100000000", 2)) == Convert.ToInt32("0100000000", 2))
                    sb.AppendLine(this.GetLabel("QA30701_ERROR9"));//("관리한계선 초과 발생");

                if (sb.Length == 0) return;

                StringBuilder sb2 = new StringBuilder();

                sb2.AppendLine(this.GetLabel("QA30701_ERROR_TITLE"));//("    판정부적합조건    ");
                sb2.AppendLine();
                sb2.AppendLine("----------------------");
                sb2.AppendLine();

                this.lbl02_ERROR_VIEW.Value = string.Format("{0}{1}", sb2.ToString(), sb.ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_STD_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_STD_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_STD_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

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

        private void btn02_ERROR_VIEW_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl02_ERROR_VIEW.Visible = !this.pnl02_ERROR_VIEW.Visible;
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
                this.nme02_XCL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_XLCL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_XUCL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_RCL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_RLCL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_RUCL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;

                this.nme02_SU.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_SL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;

                this.nme02_AVG.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_A.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_CP.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_K.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_CPK.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;

                this.nme02_XCL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_XLCL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_XUCL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_RCL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_RLCL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_RUCL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;

                this.nme02_SU.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_SL.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;

                this.nme02_AVG.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_A.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_CP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_K.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_CPK.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;

                this.nme02_XCL.DisplayFormat.CustomFormat = "###,###,###,##0.0000";
                this.nme02_XLCL.DisplayFormat.CustomFormat = "###,###,###,##0.0000";
                this.nme02_XUCL.DisplayFormat.CustomFormat = "###,###,###,##0.0000";
                this.nme02_RCL.DisplayFormat.CustomFormat = "###,###,###,##0.0000";
                this.nme02_RLCL.DisplayFormat.CustomFormat = "###,###,###,##0.0000";
                this.nme02_RUCL.DisplayFormat.CustomFormat = "###,###,###,##0.0000";

                this.nme02_SU.DisplayFormat.CustomFormat = "###,###,###,##0.00";
                this.nme02_SL.DisplayFormat.CustomFormat = "###,###,###,##0.00";

                this.nme02_AVG.DisplayFormat.CustomFormat = "###,###,###,##0.000";
                this.nme02_A.DisplayFormat.CustomFormat = "###,###,###,##0.000";
                this.nme02_CP.DisplayFormat.CustomFormat = "###,###,###,##0.000";
                this.nme02_K.DisplayFormat.CustomFormat = "###,###,###,##0.000";
                this.nme02_CPK.DisplayFormat.CustomFormat = "###,###,###,##0.000";

                this.txt02_DECISION.TextAlign = HorizontalAlignment.Center;

                this.lbl02_X.Value = this.GetLabel("X_BAR_VERTICAL");// "X\r\n\r\n관\r\n리\r\n도";
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


                StringBuilder sb = new StringBuilder();
                sb.AppendLine(this.GetLabel("QA30701_MSG6"));
                sb.AppendLine(this.GetLabel("QA30701_MSG7"));
                sb.AppendLine(this.GetLabel("QA30701_MSG8"));
                sb.AppendLine(this.GetLabel("QA30701_MSG9"));
                //sb.AppendLine("");
                //sb.AppendLine("※ 판정기준 ※");
                //sb.AppendLine("");
                //sb.AppendLine(" * 제약사항");
                //sb.AppendLine("   점은 관리 한계선 이내일 것");
                //sb.AppendLine("   점의 배열에 습관성 없을 것");
                //sb.AppendLine("");
                //sb.AppendLine(" * 습관성 판정기준");
                //sb.AppendLine("   1. 런의 발생 (연속 7점 이상)");
                //sb.AppendLine("   2. 경향 발생 (연속 7점 이상)");
                //sb.AppendLine("   3. 중심선 한쪽에 다수 발생");
                //sb.AppendLine("      - 연속 11점중 10점 이상");
                //sb.AppendLine("      - 연속 17점중 14점 이상");
                //sb.AppendLine("      - 연속 20점중 16점 이상");
                //sb.AppendLine("   4. 관리한계선 근접 다수 발생");
                //sb.AppendLine("      - 연속  3점중 2점 이상");
                //sb.AppendLine("      - 연속  7점중 3점 이상");
                //sb.AppendLine("      - 연속 10점중 4점 이상");
                //sb.AppendLine("");
                //sb.AppendLine(" * 용어설명");
                //sb.AppendLine("   런  : 중심선 한쪽에 연속 발생");
                //sb.AppendLine("   경향: 연속 상향 또는 하향 발생");

                this.lbl01_ERROR_VIEW.Value = sb.ToString();
                lbl01_ERROR_VIEW.TextAlign = ContentAlignment.TopLeft;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryGrid()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("YYYYMM",       this.dte01_YYYYMM.GetDateText().Substring(0, 7));
                set.Add("LANG_SET",     this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Detail_Grid(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL_GRID"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count != 0)
                    this.grd02.SetValue(source);
                else
                {
                    initialize_grd02();
                    return;
                }

                this.grd02.SetValue(0, 0, this.GetLabel("D_TITLE"));//"시료군");
                this.grd02.SetValue(1, 0, this.GetLabel("DD"));//"일자");

                for (int i = 2; i <= _SAMPLE_CNT + 1; i++)
                    this.grd02.SetValue(i, 0, "X"+(i-1).ToString());

                this.grd02.SetValue(_SAMPLE_CNT + 2, 0, "X (" + this.GetLabel("AVERAGE") + ")"); //평균
                this.grd02.SetValue(_SAMPLE_CNT + 3, 0, "R (" + this.GetLabel("RANGE") + ")"); //범위

                this.grd02.Rows[1].StyleNew.BackColor = Color.Green;
                this.grd02.Rows[_SAMPLE_CNT + 2].StyleNew.BackColor = Color.GreenYellow;
                this.grd02.Rows[_SAMPLE_CNT + 3].StyleNew.BackColor = Color.Yellow;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryData()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("YYYYMM",       this.dte01_YYYYMM.GetDateText().Substring(0, 7));
                set.Add("LANG_SET",     this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Detail_Data(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL_DATA"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count != 0)
                {
                    DataRow row = source.Tables[0].Rows[0];

                    this.pic02_STD_PHOTO.Initialize();
                    if (row["STD_PHOTO"] != System.DBNull.Value)

                        this.pic02_STD_PHOTO.SetValue(row["STD_PHOTO"]);
                    this.nme02_XCL.SetValue(row["XCL"]);
                    this.nme02_XUCL.SetValue(row["X_UCL"]);
                    this.nme02_XLCL.SetValue(row["X_LCL"]);
                    this.nme02_RCL.SetValue(row["RCL"]);
                    this.nme02_RUCL.SetValue(row["R_UCL"]);
                    this.nme02_RLCL.SetValue(row["R_LCL"]);
                    this.nme02_AVG.SetValue(row["XCL"]);
                    this.nme02_A.SetValue(row["A"]);
                    this.nme02_SU.SetValue(row["STD_MAX_MEAS"]);
                    this.nme02_SL.SetValue(row["STD_MIN_MEAS"]);
                    this.nme02_CP.SetValue(row["CP"]);
                    this.nme02_K.SetValue(row["K"]);
                    this.nme02_CPK.SetValue(row["CPK"]);
                    this.txt02_DECISION.SetValue(row["DECISION"]);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryChart()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("YYYYMM",       this.dte01_YYYYMM.GetDateText().Substring(0, 7));
                set.Add("LANG_SET", this.UserInfo.Language);
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

                    //임시
                    //cht02_X.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["X_INTER"].ToString());
                    //cht02_R.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["R_INTER"].ToString());

                    this.cht02_X.DataSource = source.Tables[0];
                    this.cht02_X.DataBind();
                    this.cht02_R.DataSource = source.Tables[0];
                    this.cht02_R.DataBind();
                    
                    //2015.04.22 여백주기
                    cht02_X_COPY.ChartAreas[0].AxisY.Minimum = min - ((max - min) * 0.1);
                    cht02_X_COPY.ChartAreas[0].AxisY.Maximum = max + ((max - min) * 0.1);
                    //cht02_X_COPY.ChartAreas[0].AxisY.Minimum = double.Parse(source.Tables[0].Rows[0]["X_MIN"].ToString());
                    //cht02_X_COPY.ChartAreas[0].AxisY.Maximum = double.Parse(source.Tables[0].Rows[0]["X_MAX"].ToString());
                    //cht02_X_COPY.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["X_INTER"].ToString());
                    //cht02_R_COPY.ChartAreas[0].AxisY.Interval = double.Parse(source.Tables[0].Rows[0]["R_INTER"].ToString());

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
                    chart.ChartAreas[0].AxisX.ScaleView.Size = (dataCnt < 8) ? dataCnt : 8;

                chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 1;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void initialize_grd02()
        {
            try
            {
                this.grd02.InitializeDataSource();

                this.grd02.AddRow();
                this.grd02.AddRow();
                this.grd02.AddRow();
                this.grd02.AddRow();
                this.grd02.AddRow();
                this.grd02.AddRow();
                this.grd02.AddRow();
                this.grd02.AddRow();

                this.grd02.SetValue(0, 0, this.GetLabel("D_TITLE")); //시료군
                this.grd02.SetValue(1, 0, this.GetLabel("DD")); //일자
                this.grd02.SetValue(2, 0, "X1");
                this.grd02.SetValue(3, 0, "X2");
                this.grd02.SetValue(4, 0, "X3");
                this.grd02.SetValue(5, 0, "X4");
                this.grd02.SetValue(6, 0, "X5");
                this.grd02.SetValue(7, 0, "X ("+this.GetLabel("AVERAGE")+")");//평균
                this.grd02.SetValue(8, 0, "R (" + this.GetLabel("RANGE") + ")");//범위

                this.grd02.Rows[1].StyleNew.BackColor = Color.Green;
                this.grd02.Rows[7].StyleNew.BackColor = Color.GreenYellow;
                this.grd02.Rows[8].StyleNew.BackColor = Color.Yellow;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void groupBox2_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.panel3.Width = this.groupBox2_QA30701_MSG2.Width / 2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자정의메서드]
        private void set_gridBackColorStyle()
        {
            try
            {

                
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.Rows[i].StyleNew.Clear();
                    if (this.grd01.GetValue(i, "ISSUE_YN").ToString().Equals("Y"))
                        this.grd01.Rows[i].StyleNew.BackColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
