#region ▶ Description & History
/* 
 * 프로그램명 : QA30801 측정 결과 등록 (월별)
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
 *              2017-07-13      배명희      점검항목 유형코드화(QQ)
 *              2017-07-13      배명희      측정치 입력후 포커스 이동시 판정처리 로직 추가.
 *              2017-07-14      배명희      LOTNO 조회 기능 추가(QA30801P1팝업 표시)
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
using System.ComponentModel;
using System.Collections;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b> 측정결과 등록(월별)</b>
    /// - 작 성 자 : 배명희<br />
    /// - 작 성 일 : 2014-10-07<br />
    /// </summary>
    public partial class QA30801 : AxCommonBaseControl
    {
        #region [필드에 대한 정의]
        
        private AxClientProxy _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;

        //측정결과 판정을 위한 기준 정보
        private string _CHECK_ITEMCD;
        private string _STD_UNDER_TO;
        private string _STD_UNDER_FROM;
        //LOTNO 목록 조회를 위한 선택된 사출수지 물성검사 기준표 정보
        private string _SELECTED_BIZCD;
        private string _SELECTED_CORCD;
        private string _SELECTED_VENDCD;



        private string PAKAGE_NAME = "APG_QA30801";
        private string PAKAGE_NAME_QA20801 = "APG_QA20801";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #endregion

        #region [초기화 설정에 대한 정의]

        public QA30801()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                #region [코드박스 세팅]

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDNM");//"업체명";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_INSPECT_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_INSPECT_EMPNO.PopupTitle = this.GetLabel("INSPECT_CD");// "검사원코드";
                this.cdx02_INSPECT_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_INSPECT_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);
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

                //측정결과 OK/NG
                DataTable combo_source_JUD_RESULT = new DataTable();
                combo_source_JUD_RESULT.Columns.Add("CODE");
                combo_source_JUD_RESULT.Columns.Add("NAME");
                combo_source_JUD_RESULT.Rows.Add("OK", "OK");
                combo_source_JUD_RESULT.Rows.Add("NG", "NG");
                this.cbo02_JUD_RESULT.DataBind(combo_source_JUD_RESULT);
                this.cbo02_JUD_RESULT.DropDownStyle = ComboBoxStyle.DropDownList;

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
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "관리번호", "SERIAL", "MGRTNO");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종",     "VINCD",        "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "점검항목", "CHECK_ITEMCD", "CHECK_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "색상",     "COLOR",        "CLR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "GRADE",    "GR",           "GRADE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "칼라코드", "COLORCD",      "COLORCD");                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "업체명",   "VENDCD",       "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "규격",     "STANDARD",     "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "규격이하", "STD_UNDER",    "STD_UNDER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "주의관찰", "OBSERVED",     "OBSERVED");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "관리양호", "MGT_GOOD",     "MGT_GOOD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "규격이상", "STD_OVER",     "STD_OVER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "측정단위", "MEAS_UNITCD",  "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "SMIS전송대상", "SMIS_TRANS", "SMIS_TRANS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "사용여부", "USE_YN",       "USEYN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "적용일자", "APP_DATE",     "APP_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "비고",     "REMARK",       "REMARK");

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

                #region [grd02 측정 데이터 등록 정보 그리드 세팅]
                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.SelectionMode = SelectionModeEnum.Column;

                #endregion

                #region [grd03 이상발생 조치결과 그리드 세팅]

                this.grd03.AllowEditing = false;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Initialize();
                this.grd03.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 000, "순번", "SERIAL", "SERIAL");

                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "일자", "RCV_DATE", "DD");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "LOT NO", "LOTNO", "LOTNO");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "색상", "COLOR", "CLR");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "GRADE", "GR", "GRADE");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "칼라코드", "COLORCD", "COLORCD");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "업체명", "VENDCD", "VENDNM");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "이상발생 조치 결과", "MGRT_RESULT", "ERR_MGRT_RESULT");
                
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD");
                this.grd03.ExtendLastCol = true;    
                #endregion

                #endregion

                #region [관리기준 범례 기준 영역]
                this.txt03_CORR_REF_WORK.SetReadOnly(true);
                this.txt03_MGT_GOOD_CNTT.SetReadOnly(true);
                this.txt03_MGT_OUT_CNTT.SetReadOnly(true);
                this.txt03_OBSERVED_CNTT.SetReadOnly(true);
                #endregion

                #region [차트 세팅]

                //차트 시리즈 클리어
                //c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
                c1Chart1.ChartArea.Margins.Left = 60;
                this.c1Chart1.ChartArea.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None;
                //this.c1Chart1.ChartLabels.LabelsCollection.Clear();
                this.c1Chart1.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None;
                this.c1Chart1.ToolTip.Enabled = true;

                #endregion

                //측정결과
                this.nme02_MEAS_METER.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_MEAS_METER.DataType = typeof(float);
                this.nme02_MEAS_METER.CustomFormat = "#,###.00";


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                
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
              
                //측정결과 등록 입력란 초기화
                this.dte02_RCV_DATE.Initialize();
                this.txt02_LOTNO.Initialize();
                this.nme02_MEAS_METER.Initialize();             
                this.cdx02_INSPECT_EMPNO.Initialize();
                this.txt02_MGRT_RESULT.Initialize();
                this.cbo02_JUD_RESULT.Initialize();

                this.dte02_RCV_DATE.SetReadOnly(false);
                this.txt02_LOTNO.SetReadOnly(false);

                

                //차트초기화
                this.c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
                this.c1Chart1.ChartLabels.LabelsCollection.Clear();
              
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

            //관리기준 범례 조회
            this.Query_CD4160(CORCD, BIZCD);

            //차트초기화
            this.c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
            this.c1Chart1.ChartLabels.LabelsCollection.Clear();

            //측정 데이터 등록 정보 그리드 초기화
            this.grd02.InitializeDataSource();
            //이상발생 조치결과 그리드 초기화
            this.grd03.InitializeDataSource();
     
        }
                
        /// <summary>
        /// 저장시 입력한 측정결과 등록 정보를 저장한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsSaveValid()) return;

            
                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("SERIAL", "RCV_DATE", "LOTNO", "INSPECT_EMPNO",
                                                    "MEAS_METER", "JUD_RESULT", "MGRT_RESULT", "USER_ID");

              
                string SERIAL = _SERIAL;

                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string LOTNO = this.txt02_LOTNO.GetValue().ToString();
                string MEAS_METER = this.nme02_MEAS_METER.GetDBValue().ToString();
                string MGRT_RESULT = this.txt02_MGRT_RESULT.GetValue().ToString();
                string INSPECT_EMPNO = this.cdx02_INSPECT_EMPNO.GetValue().ToString();
                string JUD_RESULT = this.cbo02_JUD_RESULT.GetValue().ToString();

                source.Tables[0].Rows.Add(
                    SERIAL, RCV_DATE, LOTNO, INSPECT_EMPNO,
                    MEAS_METER, JUD_RESULT, MGRT_RESULT, this.UserInfo.UserID);

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_MEAS_METER"), source);
                this.AfterInvokeServer();
                                
               
                this.BtnQuery_Click(SERIAL);
                
                //MsgBox.Show("입력하신 측정결과 등록정보가 저장되었습니다.");
                MsgCodeBox.Show("QA02-0031");
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
        /// 삭제버튼 클릭시 현재 선택된 측정결과 정보를 삭제한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsDeleteValid()) return;

                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("SERIAL", "RCV_DATE", "LOTNO");
                source.Tables[0].Rows.Add(_SERIAL,
                                        this.dte02_RCV_DATE.GetDateText().ToString(),
                                        this.txt02_LOTNO.GetValue().ToString());

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_MEAS_METER"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(_SERIAL);

                //MsgBox.Show("선택하신 측정결과 등록정보가 삭제되었습니다.");
                MsgCodeBox.Show("QA02-0032");
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


                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                string SERIAL = this.grd01.GetValue(row, "SERIAL").ToString();

                //판정 기준정보 가져오기
                this.GetACD4150Info(SERIAL);
                

                this.BtnQuery_Click(SERIAL);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 더블 클릭시 하단의 측정결과 등록 입력 컨트롤에 일자,LOTNO, 측정결과, 검사자, 이상발생 조치결과를 표시한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;


                this.BtnReset_Click(null, null);

                
                int col = this.grd02.MouseCol;
                if (col <= this.grd02.Cols.Fixed) return;

                string RCV_DATE = this.grd02.GetValue(Convert.ToInt32(RowIdx.Date) + this.grd02.Rows.Fixed, col).ToString();
                string LOTNO = this.grd02.GetValue(Convert.ToInt32(RowIdx.Lotno) + this.grd02.Rows.Fixed, col).ToString();
                
                this.BtnQuery_QA6070(_SERIAL, RCV_DATE, LOTNO);
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
                this.cdx02_INSPECT_EMPNO.HEUserParameterSetValue("BIZCD", _BIZCD);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
                
        private void c1Chart1_SizeChanged(object sender, EventArgs e)
        {
            RepositionLabel((C1Chart)sender);
        }

        private void cdx02_INSPECT_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
        }
              
        //lotno 조회 팝업
        private void btn02_VIEW_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(this._SELECTED_VENDCD )) return;

                QA30801P1 form = new QA30801P1(this._SELECTED_CORCD, this._SELECTED_BIZCD, this._SELECTED_VENDCD);
                //form.ShowDialog();
                this.ShowPopup(form);

                if (form.SelectedValue != null)
                {
                    DataRow dr = (DataRow)form.SelectedValue;
                    this.txt02_LOTNO.SetValue(dr["MAT_LOTNO"].ToString());
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
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
                set.Add("USE_YN", USE_YN);
                set.Add("LANG_SET", _LANG_SET);
                set.Add("USER_ID", this.UserInfo.UserID);
                set.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //관리ITEM 기준 조회
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_QA20801, "INQUERY"), set);

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
                    this.txt03_CORR_REF_WORK.SetValue(dr["CORR_REF_WORK"]);
                    this.txt03_MGT_GOOD_CNTT.SetValue(dr["MGT_GOOD_CNTT"]);
                    this.txt03_OBSERVED_CNTT.SetValue(dr["OBSERVED_CNTT"]);
                    this.txt03_MGT_OUT_CNTT.SetValue(dr["MGT_OUT_CNTT"]);
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
                    this.txt03_CORR_REF_WORK.Initialize();
                    this.txt03_MGT_GOOD_CNTT.Initialize();
                    this.txt03_OBSERVED_CNTT.Initialize();
                    this.txt03_MGT_OUT_CNTT.Initialize();
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
                set.Add("YYYYMM", this.dte01_WRITE_MONTH.GetDateText().Substring(0,7));
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet pivot = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MEAS_LIST"), set);

                BindSeries(c1Chart1, 0, pivot.Tables[0].DefaultView, "MEAS_METER", "RCV_DATE");

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

                SetChartZone(c1Chart1, zoneName, zoneLetter, zoneColor, zoneFrom, zoneTo);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MGRT_RESULT"), set);
                this.SetPivot(pivot.Tables[0]);
                this.grd03.SetValue(source);
              
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //판정 기준 정보 가져오기
        private void GetACD4150Info(string serial)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("SERIAL", serial);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_JUDGE_INFO"), set);

                if (source.Tables[0].Rows.Count > 0)
                {
                    this._CHECK_ITEMCD = source.Tables[0].Rows[0]["CHECK_ITEMCD"].ToString();
                    this._STD_UNDER_FROM = source.Tables[0].Rows[0]["STD_UNDER_FROM"].ToString();
                    this._STD_UNDER_TO = source.Tables[0].Rows[0]["STD_UNDER_TO"].ToString();

                    this._SELECTED_BIZCD = source.Tables[0].Rows[0]["BIZCD"].ToString();
                    this._SELECTED_CORCD = source.Tables[0].Rows[0]["CORCD"].ToString();
                    this._SELECTED_VENDCD = source.Tables[0].Rows[0]["VENDCD"].ToString(); 
                }
                else
                {
                    this._CHECK_ITEMCD = string.Empty;
                    this._STD_UNDER_FROM = string.Empty;
                    this._STD_UNDER_TO = string.Empty;
                    this._SELECTED_BIZCD = string.Empty;
                    this._SELECTED_CORCD = string.Empty;
                    this._SELECTED_VENDCD = string.Empty;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 하단입력컨트롤에 상세 내용 바인딩(입력컨트롤)
        /// </summary>
        /// <param name="SERIAL"></param>
        private void BtnQuery_QA6070(string SERIAL, string RCV_DATE, string LOTNO)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("SERIAL", SERIAL);
                set.Add("RCV_DATE", RCV_DATE);
                set.Add("LOTNO", LOTNO);
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MEAS_METER"), set);

                if (source.Tables[0].Rows.Count <= 0)
                    BtnReset_Click(null, null);
                else
                {
                    DataRow dr = source.Tables[0].Rows[0];
                    this.dte02_RCV_DATE.SetValue(dr["RCV_DATE"]);
                    this.txt02_LOTNO.SetValue(dr["LOTNO"]);
                    this.txt02_MGRT_RESULT.SetValue(dr["MGRT_RESULT"]);
                    this.cdx02_INSPECT_EMPNO.SetValue(dr["INSPECT_EMPNO"]);
                    this.nme02_MEAS_METER.SetValue(dr["MEAS_METER"]);
                    this.cbo02_JUD_RESULT.SetValue(dr["JUD_RESULT"]);


                    this.dte02_RCV_DATE.SetReadOnly(true);
                    this.txt02_LOTNO.SetReadOnly(true);

                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private enum RowIdx { Date = 0, Lotno = 1, Value = 2, Judge_Result = 3, Inspector = 4 };
        
        /// <summary>
        /// 측정 데이터 등록 정보 그리드(grd02)에 바인딩하기 위해 데이터 조정
        /// </summary>
        /// <param name="dt"></param>
        private void SetPivot(DataTable dt)
        {
            DataTable pivot = new DataTable();
            pivot.Columns.Add("header");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pivot.Columns.Add("col" + (i).ToString());
            }
            for (int i = 0; i <= 4 ; i++)
            {
                DataRow dr = pivot.NewRow();
                pivot.Rows.Add(dr);                
            }

            System.Globalization.DateTimeFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime rcv_date =Convert.ToDateTime(dt.Rows[i]["RCV_DATE"]);

                pivot.Rows[Convert.ToInt32(RowIdx.Date)]["col" + i.ToString()] = rcv_date.ToString(format.ShortDatePattern);
                pivot.Rows[Convert.ToInt32(RowIdx.Lotno)]["col" + i.ToString()] = dt.Rows[i]["LOTNO"].ToString();
                pivot.Rows[Convert.ToInt32(RowIdx.Value)]["col" + i.ToString()] = dt.Rows[i]["MEAS_METER"].ToString();
                pivot.Rows[Convert.ToInt32(RowIdx.Judge_Result)]["col" + i.ToString()] = dt.Rows[i]["JUD_RESULT"].ToString();                
                pivot.Rows[Convert.ToInt32(RowIdx.Inspector)]["col" + i.ToString()] = dt.Rows[i]["INSPECT_EMPNO"].ToString();
            }

            this.grd02.Cols.Count = this.grd02.Cols.Fixed;
            for (int i = 0; i < pivot.Columns.Count; i++)
            {
                this.grd02.Cols.Count = i + this.grd02.Cols.Fixed + 1;
                this.grd02.Cols[i + this.grd02.Cols.Fixed].Name = pivot.Columns[i].ColumnName;
                this.grd02.Cols[i + this.grd02.Cols.Fixed].Width = 120;
                this.grd02.Cols[i + this.grd02.Cols.Fixed].TextAlign = TextAlignEnum.CenterCenter;
                
            }
            pivot.Rows[0]["header"] = this.GetLabel("DD");//일자
            pivot.Rows[1]["header"] = this.GetLabel("LOTNO");//"LOT NO";
            pivot.Rows[2]["header"] = this.GetLabel("MEAS_METER2");// "측정치";
            pivot.Rows[3]["header"] = this.GetLabel("MEAS_METER");// "측정결과"(판정);
            pivot.Rows[4]["header"] = this.GetLabel("INSPECTOR_0");// "검사자";

            this.grd02.Cols[1].Style.BackColor = this.grd02.Styles.Fixed.BackColor;
            this.grd02.Cols[1].Style.Border.Color = this.grd02.Styles.Fixed.Border.Color;


            this.grd02.SetValue(pivot);
            

            this.grd02.Rows[0].Visible = false;
            this.grd02.Cols[0].Visible = false;
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                if (_SERIAL.Length <= 0)
                {
                    //MsgBox.Show("관리item기준이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0033");
                    return false;
                }

                if (txt02_LOTNO.ByteCount <= 0)
                {
                    //MsgBox.Show("lotno 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0034");
                    return false;
                }
                if (nme02_MEAS_METER.GetValue().ToString().Length <= 0)
                {
                    //MsgBox.Show("측정결과 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0035");
                    return false;
                }
                if (cdx02_INSPECT_EMPNO.GetValue().ToString().Length <= 0)
                {
                    //MsgBox.Show("검사자가 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0036");
                    return false;
                }

                if (cbo02_JUD_RESULT.GetValue().ToString().Length <= 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0080", this.GetLabel("MEAS_METER")); //{0}가(이) 선택되지 않았습니다.
                    return false;
                }

                //if (MsgBox.Show("입력하신 측정 결과 등록정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA02-0037", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid()
        {
            try
            {
                if (_SERIAL.Length <= 0)
                {
                    //MsgBox.Show("관리item기준이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0033");
                    return false;
                }

                //if (MsgBox.Show("선택하신 측정 결과 등록정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA02-0038", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [차트 관련 static 메서드]
        /// <summary>
        /// CHART zone 설정
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="legend"></param>
        public static void SetChartZone(C1Chart chart, string[] zoneName, string[] zoneLetter, Color[] zoneColor, double[] zoneFrom, double[] zoneTo)
        {
            try
            {
                chart.ChartArea.PlotArea.AlarmZones.Clear();
                //chart.ChartGroups[0].ChartData.MinY = 0;
                //chart.ChartGroups[0].ChartData.MaxY = 50;


                // Add and show the alarm zones               
                for (int i = 0; i < 4; i++)
                {
                    AlarmZone zone = chart.ChartArea.PlotArea.AlarmZones.AddNewZone();

                    zone.Name = zoneName[i];
                    zone.BackColor = zoneColor[i];
                    zone.UpperExtent = zoneTo[i];
                    zone.LowerExtent = zoneFrom[i];
                    zone.Visible = true;

                }
                chart.ChartArea.AxisY.ForeColor = Color.Black;
                chart.ChartArea.AxisX.ForeColor = Color.Black;
                chart.ChartArea.AxisY.Max = zoneTo[0];
                chart.ChartArea.AxisY.Min = zoneFrom[3];
                chart.ChartArea.AxisY.GridMajor.Thickness = 1;
                chart.ChartArea.AxisY.GridMajor.Pattern = LinePatternEnum.Dot;
                chart.ChartArea.AxisY.GridMajor.Color = Color.Black;
                chart.ChartArea.AxisX.GridMajor.Thickness = 1;
                chart.ChartArea.AxisX.GridMajor.Pattern = LinePatternEnum.Solid;
                chart.ChartArea.AxisX.GridMajor.Color = Color.Black;

                AddLegends(chart, zoneColor, zoneLetter, zoneName);

            }

            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 영역설명 레이블 추가
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="zcolor"></param>
        /// <param name="zoneLetter"></param>
        /// <param name="zoneName"></param>
        public static void AddLegends(C1Chart chart, Color[] zcolor, string[] zoneLetter, string[] zoneName)
        {
            //// Add the chart labels.  They will be positioned later
            chart.ChartLabels.DefaultLabelStyle.BackColor = chart.Style.BackColor;
            chart.ChartLabels.DefaultLabelStyle.Font = new Font("Courier New", 8, FontStyle.Regular);

            for ( int i=chart.ChartLabels.LabelsCollection.Count-1; i>=0; i--)
            {
                C1.Win.C1Chart.Label lbl = chart.ChartLabels.LabelsCollection[i];
                if (lbl.Name.StartsWith("ALARM_"))
                {
                    chart.ChartLabels.LabelsCollection.RemoveAt(i);
                }
            }                       

            C1.Win.C1Chart.Label lab = null;
            for (int i = 0; i < 4; i++)
            {
                lab = chart.ChartLabels.LabelsCollection.AddNewLabel();
                lab.Name = "ALARM_" + i.ToString();
                lab.Text = zoneLetter[i];
                lab.Style.BackColor = Color.FromArgb(0,  zcolor[i]);
                //lab.Style.BackColor = zcolor[i];
                lab.AttachMethod = AttachMethodEnum.Coordinate;
                lab.Visible = true;
                lab.Style.VerticalAlignment = AlignVertEnum.Center;
                
            }
            
            RepositionLabel(chart);

            //// reposition the legend and labels
            //if (chart.ChartLabels == null || chart.ChartLabels.LabelsCollection.Count < 4)
            //    return;

            //chart.GetImage();

            //PlotArea plota = chart.ChartArea.PlotArea;
          
            //for (int i = 0; i < 4; i++)
            //{
            //    C1.Win.C1Chart.Label lab2 = chart.ChartLabels[i];
            //    AlarmZone zone = plota.AlarmZones[zoneName[i]];
            //    int x = 0;
            //    int y2 = 0;
            //    int y1 = 0;
            //    chart.ChartGroups.Group0.DataCoordToCoord(0, zone.UpperExtent, ref x, ref y2);
            //    chart.ChartGroups.Group0.DataCoordToCoord(0, zone.LowerExtent, ref x, ref y1);
            //    //lab2.AttachMethodData.X = x;// plota.Location.X - chart.ChartArea.Margins.Left - chart.ChartArea.Location.X;//labP.X;//plota.Location.X;//
            //    //lab2.AttachMethodData.Y = y + (lab2.Size.Height / 2);// labP.Y;
            //    lab2.AttachMethodData.X = 20;// plota.Location.X - chart.ChartArea.Margins.Left - chart.ChartArea.Location.X;//labP.X;//plota.Location.X;//
            //    lab2.AttachMethodData.Y = (y1 + y2) / 2;// +(lab2.Size.Height / 2);// labP.Y;
            //}

        }


        // copy data from a data source to the chart
        // c1c          chart
        // series       index of the series to bind (0-based, will add if necessary)
        // datasource   datasource object (cannot be DataTable, DataView is OK)
        // field        name of the field that contains the y values
        // labels       name of the field that contains the x labels
        public static void BindSeries(C1Chart c1c, int series, object dataSource, string field, string labels)
        {
            // check data source object
            ITypedList il = (ITypedList)dataSource;
            IList list = (IList)dataSource;
            if (list == null || il == null)
                throw new ApplicationException("Invalid DataSource object.");

            // add series if necessary
            ChartDataSeriesCollection coll = c1c.ChartGroups[0].ChartData.SeriesList;
            while (series >= coll.Count)
                coll.AddNewSeries();

            coll[0].LineStyle.Pattern = LinePatternEnum.Solid;
            coll[0].LineStyle.Color = Color.DarkBlue;
            coll[0].SymbolStyle.Color = Color.DarkBlue;
            coll[0].SymbolStyle.Shape = SymbolShapeEnum.Dot;
            coll[0].LineStyle.Thickness = 1;


            // copy series data
            if (list.Count == 0) return;

            PointF[] data = (PointF[])Array.CreateInstance(typeof(PointF), list.Count);
            PropertyDescriptorCollection pdc = il.GetItemProperties(null);
            PropertyDescriptor pd = pdc[field];
            if (pd == null)
                throw new ApplicationException(string.Format("Invalid field name used for Y values ({0}).", field));

            int i;
          
            string[] x = (string[])Array.CreateInstance(typeof(string), list.Count);
            double[] y = (double[])Array.CreateInstance(typeof(double), list.Count);
            for (i = 0; i < list.Count; i++)
            {

                x[i] = pd.GetValue(list[i]).ToString();
                y[i] = double.Parse(pd.GetValue(list[i]).ToString());
            }
            coll[series].X.CopyDataIn(x);
            coll[series].Y.CopyDataIn(y);
            coll[series].Label = field;
            coll[series].TooltipText = "측정값 = {#YVAL}";

            DataLabel dlab = coll[series].DataLabel;
            dlab.Compass = LabelCompassEnum.Auto;
            dlab.Offset = -2;
            dlab.Text = "{#YVAL}";
            dlab.Style.BackColor = Color.Transparent;
            dlab.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None;
            dlab.Visible = true;

            // copy series labels
            if (labels != null && labels.Length > 0)
            {
                pd = pdc[labels];
                if (pd == null)
                    throw new ApplicationException(string.Format("Invalid field name used for X values ({0}).", labels));
                Axis ax = c1c.ChartArea.AxisX;
                ax.ValueLabels.Clear();
                for (i = 0; i < list.Count; i++)
                {
                    string label = pd.GetValue(list[i]).ToString();
                    ax.ValueLabels.Add(i, label);
                }
                ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;
            }
        }

        /// <summary>
        /// 레이블 위치 조정
        /// </summary>
        /// <param name="chart"></param>
        public static void RepositionLabel(C1Chart chart)
        {
            if (chart.ChartLabels == null || chart.ChartLabels.LabelsCollection.Count < 4)
                return;

            chart.GetImage();




            PlotArea plota = chart.ChartArea.PlotArea;

            //if (c1Chart1.ChartLabels.LabelsCollection.Count != 4) return;
            //PlotArea plota = c1Chart1.ChartArea.PlotArea;

            for (int i = 0; i < 4; i++)
            {
                C1.Win.C1Chart.Label lab2 = chart.ChartLabels[i];


                AlarmZone zone = plota.AlarmZones[i];
                int x = 0;
                int y2 = 0;
                int y1 = 0;
                chart.ChartGroups.Group0.DataCoordToCoord(0, zone.UpperExtent, ref x, ref y2);
                chart.ChartGroups.Group0.DataCoordToCoord(0, zone.LowerExtent, ref x, ref y1);
                //lab2.AttachMethodData.X = x;// plota.Location.X - chart.ChartArea.Margins.Left - chart.ChartArea.Location.X;//labP.X;//plota.Location.X;//
                //lab2.AttachMethodData.Y = y + (lab2.Size.Height / 2);// labP.Y;
                lab2.AttachMethodData.X = 20;// plota.Location.X - chart.ChartArea.Margins.Left - chart.ChartArea.Location.X;//labP.X;//plota.Location.X;//
                lab2.AttachMethodData.Y = (y1 + y2) / 2;// +(lab2.Size.Height / 2);// labP.Y;


            }

        }

        #endregion

        #region [결과값 입력 후 판정 처리]

        private void nme02_MEAS_METER_Leave(object sender, EventArgs e)
        {
            //포커스 이동시 판정 처리.
            if (this.nme02_MEAS_METER.Text == null || string.IsNullOrEmpty(this.nme02_MEAS_METER.Text))
            {
                this.cbo02_JUD_RESULT.SetValue(string.Empty);
                return;
            }

            if (this._CHECK_ITEMCD != "QQ1" && this._CHECK_ITEMCD != "QQ2")
            {
                this.cbo02_JUD_RESULT.SetValue(string.Empty); 
                return;
            }


            decimal meas_meter = Convert.ToDecimal(this.nme02_MEAS_METER.Text); 
            if (this._CHECK_ITEMCD.Equals("QQ1"))
            {
                //용융지수인 경우
                //STD_UNDER_TO 이상이면 OK, 미만이면  NG
                decimal std_under_to = Convert.ToDecimal(this._STD_UNDER_TO);
                if (meas_meter >= std_under_to)
                    this.cbo02_JUD_RESULT.SetValue("OK");
                else
                    this.cbo02_JUD_RESULT.SetValue("NG");
            }
            else
            {
                //수분함량인 경우
                //STD_UNDER_FROM 미만이면 OK, 이상이면  NG
                decimal std_under_from = Convert.ToDecimal(this._STD_UNDER_FROM);
                if (meas_meter < std_under_from)
                    this.cbo02_JUD_RESULT.SetValue("OK");
                else
                    this.cbo02_JUD_RESULT.SetValue("NG");
            }

            
            
        }

        //Enter키 입력시 파정 처리해줌.
        private void nme02_MEAS_METER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.nme02_MEAS_METER_Leave(null, null);
            }
        }

        #endregion


    }
}
