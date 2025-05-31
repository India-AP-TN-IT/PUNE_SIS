#region ▶ Description & History
/* 
 * 프로그램명 : 완(반)제품 폐기 불량 등록
 * 설      명 : 
 * 최초작성자 : 이대형
 * 최초작성일 : 2010-05-11 오후 2:43:10
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		수정내용
 *				---------------------------------------------------------------------------------------------
 *				2014-07-29      배명희      IsSaveValid    - "DEF_UCOST" 값에 ""이 들어오는 경우 "0"으로 설정하여 유효성 체크 로직 처리.
 *				                            btnSave_Click  - "DIS_UCOST", "DEF_UCOST" 값에 ""이 들어오는 경우 "0"으로 설정하여 저장 로직 처리.
 *				2015-07-23      배명희      통합WCF로 변경 
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

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>완(반)제품 폐기 불량 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:43:10<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:43:10   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20211 : AxCommonBaseControl
    {
        //private IQA20211 _WSCOM;
        //private IQA20212 _WSCOM_QA20212;
        private String _CORCD;
        private String _LANG_SET;
        private String _BIZCD_T;
        private String _PROC_DATE_T;
        private String _IMPUT_VENDCD_T;
        private String _PARTNO_PARTNM_T;
        private String _GUBN;
        private String _DEFNO_T;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20211";
        private string PAKAGE_NAME_QA20212 = "APG_QA20212";

        #region [ 초기화 작업 정의 ]

        public QA20211()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20211>("QA00", "QA20211.svc", "CustomBinding");
            //_WSCOM_QA20212 = ClientFactory.CreateChannel<IQA20212>("QA01", "QA20212.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            _BIZCD_T = "";
            _PROC_DATE_T = "";
            _IMPUT_VENDCD_T = "";
            _PARTNO_PARTNM_T = "";
            _GUBN = "N";
            _DEFNO_T = "";
        }

        public QA20211(string BIZCD, string PROC_DATE, string IMPUT_VENDCD, string PARTNO_PARTNM, string DEFNO)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20211>("QA00", "QA20211.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            _BIZCD_T = BIZCD;
            _PROC_DATE_T = PROC_DATE;
            _IMPUT_VENDCD_T = IMPUT_VENDCD;
            _PARTNO_PARTNM_T = PARTNO_PARTNM;
            _GUBN = "Y";
            _DEFNO_T = DEFNO;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox4.Text = this.GetLabel("QA20211_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20211_MSG2");

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                    this.cbo02_BIZCD.Enabled = false;
                }


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.19 공장구분 조회조건 추가
                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.19 공장구분 입력항목 추가
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))    //2013.04.19 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}
                //2015.07.01 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                {
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                    this.cbo02_PLANT_DIV.SetReadOnly(true);
                }


                this.cdx01_IMPUT_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_IMPUT_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");// "귀책업체코드";
                this.cdx01_IMPUT_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_IMPUT_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_IMPUT_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_IMPUT_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_IMPUT_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx02_IMPUT_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_IMPUT_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_IMPUT_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx02_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx02_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx02_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ALCCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ALCCD.PopupTitle = "ALC CODE";
                this.cdx02_ALCCD.CodeParameterName = "ALCCD_OF_ITEMCD";
                this.cdx02_ALCCD.NameParameterName = "ALCCD_OF_ITEMNM";
                this.cdx02_ALCCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ALCCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("RCV_DATE", this.dte02_PROC_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEParameterAdd("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("ITEMCD", this.cdx02_ITEMCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_ASSYNO.HEPopupHelper = new QASubWindow();
                this.cdx02_ASSYNO.PopupTitle = this.GetLabel("ASSYCD");//"완제품코드";
                this.cdx02_ASSYNO.CodeParameterName = "ASSYNO_OF_ALCCD";
                this.cdx02_ASSYNO.NameParameterName = "ASSYNO_OF_ALCNM";
                this.cdx02_ASSYNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ASSYNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("RCV_DATE", this.dte02_PROC_DATE.GetDateText().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("ITEMCD", this.cdx02_ITEMCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("LANG_SET", _LANG_SET);
                //this.cdx02_ASSYNO.CodePixedLength = 20;

                this.cdx02_DEF_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_DEF_PARTNO.PopupTitle = this.GetLabel("DIS_PARTNO");//"폐기품번";
                this.cdx02_DEF_PARTNO.CodeParameterName = "PARTNO_OF_VENDCD";
                this.cdx02_DEF_PARTNO.NameParameterName = "PARTNO_OF_VENDNM";
                this.cdx02_DEF_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEF_PARTNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PARTNO.HEParameterAdd("VENDCD", string.Empty);                
                this.cdx02_DEF_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);
                //this.cdx02_DEF_PARTNO.CodePixedLength = 20;

                this.cdx02_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("LINECD");//"라인코드";
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_LINECD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_LINECD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());

                this.cdx02_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx02_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx02_DEFCD.CodeParameterName = "DEFCD";
                this.cdx02_DEFCD.NameParameterName = "DEFNM";
                this.cdx02_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx02_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx02_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx02_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet source = this.GetTypeCode("FY", "F4", "A1");
                this.cbo02_MGRT_DIV.DataBind(source.Tables[0], true);
                this.cbo02_MGRT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet dsSHIFT = AxFlexGrid.GetDataSourceSchema("CODE", "TEXT");
                dsSHIFT.Tables[0].Rows.Add("1", "1");
                dsSHIFT.Tables[0].Rows.Add("2", "2");
                dsSHIFT.Tables[0].Rows.Add("3", "3");
                this.cbo02_DN_DIV.DataBind(dsSHIFT.Tables[0], false);
                this.cbo02_DN_DIV.DropDownStyle = ComboBoxStyle.DropDownList;
                
                this.cbo02_IMPUT_DIVCD.DataBind(source.Tables[1], false);
                this.cbo02_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_JOB_TYPE.DataBind(source.Tables[2], true);
                this.cbo01_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_JOB_TYPE.DataBind(source.Tables[2], true);
                this.cbo02_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA20211.AllowEditing = false;
                this.grd01_QA20211.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20211.Initialize();
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD","BIZCD");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "발생일자", "PROC_DATE","OCCUR_DATE");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "불량번호", "DEFNO", "DEFNO");                
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 30, "차종", "VINCD","VIN");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD","ITEM");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "업무유형", "JOB_TYPENM", "JOB_TYPENM");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD", "ALCCD");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "A'SSY NO", "ASSYNO");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "업체", "IMPUT_VENDCD", "IMPUT_VENDCD");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "귀책업체명", "INPUT_VENDNM", "IMPUT_VENDNM");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 120, "라인명", "LINECD", "LINECD");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "라인명", "LINENM", "LINENM");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 140, "불량내용", "DEFCD", "DEFCD");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 60, "불량부위", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "조치구분", "MGRT_DIV", "MGRT_CD");               
                
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "SHIFT", "DN_DIV", "SHIFT");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "귀책구분코드", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01_QA20211.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "PRDT_DIV", "PRDT_DIV");
                //this.grd01_QA20211.AddColumn(false, false, HEFlexGrid.FtextAlign.L, 100, "공장구분", "PLANT_DIV", "PLANT_DIV");  //공장구분
                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA20211.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA20211.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA20211.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01_QA20211.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA20211.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE, lbl02_BIZNM, lbl02_OCCUR_DATE, lbl02_VINCD, lbl02_ITEMCD, lbl02_JOB_TYPE, lbl02_ASSYPNO, lbl02_MGRT_CD, lbl02_IMPUT_VENDNM, lbl02_DEF_PNO, lbl02_SHIFT, lbl02_IMPUT_DIVCD, lbl02_PLANT_DIV);

                this.BtnReset_Click(null, null);

                if (_GUBN == "Y")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD_T);
                    this.dte01_PROC_DATE.SetValue(_PROC_DATE_T);
                    this.cdx01_IMPUT_VENDCD.SetValue(_IMPUT_VENDCD_T);
                    this.txt01_PARTNO_PARTNM.SetValue(_PARTNO_PARTNM_T);
                }
                this.dte01_PROC_DATE.SetValue(DateTime.Now);
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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        if (ctl.Name.Equals("cbo02_PLANT_DIV")) continue;
                        ((IAxControl)ctl).Initialize();
                    }
                }
                
                this.nme02_DEF_QTY.SetValue("0");
             
                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                this.dte02_PROC_DATE.Enabled = true;
                this.cdx02_VINCD.Enabled = true;
                this.cdx02_ITEMCD.Enabled = true;
                this.cbo02_JOB_TYPE.Enabled = true;
                this.cdx02_ALCCD.Enabled = true;
                this.cdx02_ASSYNO.Enabled = true;

                this.cdx_SETTING();
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
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string PROC_DATE = this.dte01_PROC_DATE.GetDateText().ToString();
                string IMPUT_VENDCD = this.cdx01_IMPUT_VENDCD.GetValue().ToString();
                string JOB_TYPE = this.cbo01_JOB_TYPE.GetValue().ToString();
                string PARTNO_PARTNM = this.txt01_PARTNO_PARTNM.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();      //공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE", PROC_DATE);
                paramSet.Add("IMPUT_VENDCD", IMPUT_VENDCD);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("PARTNO_PARTNM", PARTNO_PARTNM);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("DEFNO", _DEFNO_T);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                               //공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source_QA2010 = _WSCOM.Inquery_QA2010(paramSet);
                DataSet source_QA2010 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA2010"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20211.SetValue(source_QA2010);

                if (_GUBN == "Y")
                {
                    if (((DataTable)this.grd01_QA20211.DataSource).Rows.Count > 0)
                        this.grd_SELECT(this.grd01_QA20211.Rows.Fixed);

                    _GUBN = "";
                    _DEFNO_T = "";
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

        protected override void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                base.BtnClose_Click(sender, e);
                ((Form)this.Parent).Close();
            }
            catch
            {
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
                {
                    //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
                    MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
                    return;
                }

                string IMPUT_VENDCD = this.cdx02_IMPUT_VENDCD.GetValue().ToString(); 
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PROC_DATE = this.dte02_PROC_DATE.GetDateText().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();
                string ALCCD = this.cdx02_ALCCD.GetValue().ToString();
                string MGRT_DIV = this.cbo02_MGRT_DIV.GetValue().ToString();
                string DEFNO = this.txt02_DEFNO.GetValue().ToString();                
                string ASSYNO = this.cdx02_ASSYNO.GetValue().ToString();
                string PARTNO = this.cdx02_DEF_PARTNO.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetDBValue().ToString();                
              
                string LINECD = this.cdx02_LINECD.GetValue().ToString();
              
                string DEFCD = this.cdx02_DEFCD.GetValue().ToString();
                string DEFPOSCD = this.cdx02_DEFPOSCD.GetValue().ToString();
                string DN_DIV = this.cbo02_DN_DIV.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo02_IMPUT_DIVCD.GetValue().ToString();
                string PRDT_DIV = this.txt02_PRDT_DIV.GetValue().ToString();

                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString();              //공장구분 추가

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "DEFNO", "PROC_DATE", "LINECD",
                    "JOB_TYPE", "ASSYNO", "PARTNO", "DEFCD", "DEFPOSCD",
                     "DN_DIV", "ALCCD", "DEF_QTY", "IMPUT_DIVCD", "PRDT_DIV",
                     "MGRT_DIV", "IMPUT_VENDCD", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD, BIZCD, DEFNO, PROC_DATE,
                    LINECD, JOB_TYPE, ASSYNO, PARTNO, DEFCD,
                    DEFPOSCD, DN_DIV, ALCCD, DEF_QTY, 
                    IMPUT_DIVCD, PRDT_DIV, MGRT_DIV, 
                    IMPUT_VENDCD, PLANT_DIV                                          //공장구분 추가
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("완(반)제품 폐기 불량 등록이 저장되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
                {
                    //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
                    MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
                    return;
                }

                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string DEFNO = this.txt02_DEFNO.GetValue().ToString();

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "DEFNO");
                source.Tables[0].Rows.Add(
                    _CORCD, BIZCD, DEFNO
                );

                if (!IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("완(반)제품 폐기 불량 등록이 삭제 되었습니다.");
                MsgCodeBox.Show("CD00-0072");
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

        private void grd01_QA20211_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20211.SelectedRowIndex;

                if (Row >= this.grd01_QA20211.Rows.Fixed)
                {
                    this.grd_SELECT(Row);
                }
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
        
        private void cdx02_ASSYNO_ButtonClickAfter(object sender, EventArgs args)
        {
            this.grd02_QA20211_View();
        }

        private void grd02_QA20211_View()
        {
            try
            {
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PROC_DATE = this.dte02_PROC_DATE.GetDateText().ToString();
                string ASSYNO = this.cdx02_ASSYNO.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE", PROC_DATE);
                paramSet.Add("ASSYNO", ASSYNO);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_ASSYNO_PRDT_DIV_UCOST(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_ASSYNO_PRDT_DIV"), paramSet);

                this.AfterInvokeServer();

                //this.grd02_QA20211.SetValue(source);

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.txt02_PRDT_DIV.SetValue(source.Tables[0].Rows[0]["PRDT_DIV"].ToString());
                    
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

     

        private void cbo02_MGRT_DIV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                
                
                string cbo02_MGRT_DIV = this.cbo02_MGRT_DIV.GetValue().ToString();

                //this.grd02_QA20211_View();

                if (cbo02_MGRT_DIV == "FYB") //폐기선택시 
                {                       
                    this.cdx02_DEF_PARTNO.SetValue(cdx02_ASSYNO.GetValue().ToString());
                   
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

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void dte02_PROC_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VINCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VINCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ITEMCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ITEMCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PROC_DATE = this.dte02_PROC_DATE.GetDateText().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();
                string ASSYNO = this.cdx02_ASSYNO.GetValue().ToString();
                string MGRT_DIV = this.cbo02_MGRT_DIV.GetValue().ToString();
                string PARTNO = this.cdx02_DEF_PARTNO.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();
                string DN_DIV = this.cbo02_DN_DIV.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo02_IMPUT_DIVCD.GetValue().ToString();

                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString();      //공장구분
                string IMPUT_VENDCD = this.cdx02_IMPUT_VENDCD.GetValue().ToString(); 
              

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(PROC_DATE) == 0)
                {
                    //MsgBox.Show("발생일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_OCCUR_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_VINCD.Text);
                    return false;
                }

                if (this.GetByteCount(ITEMCD) == 0)
                {
                    //MsgBox.Show("품목 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ITEMCD.Text);
                    return false;
                }

                if (this.GetByteCount(JOB_TYPE) == 0)
                {
                    //MsgBox.Show("업무유형 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_JOB_TYPE.Text);
                    return false;
                }

                if (this.GetByteCount(ASSYNO) == 0)
                {
                    //MsgBox.Show("완제품 PNO 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ASSYPNO.Text);
                    return false;
                }

                if (this.GetByteCount(MGRT_DIV) == 0)
                {
                    //MsgBox.Show("조치구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_MGRT_CD.Text);
                    return false;
                }

                if (this.GetByteCount(IMPUT_VENDCD) == 0)
                {
                    //MsgBox.Show("귀책업체 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_IMPUT_VENDNM.Text);
                    return false;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("불량품번 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_DEF_PNO.Text);
                    return false;
                }

                if (Int32.Parse(DEF_QTY) <= 0)
                {
                    //MsgBox.Show("불량수량과 수정수량중 하나에는 데이터가 입력되어야 합니다.");
                    //MsgCodeBox.Show("QA00-024");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_DEF_QTY.Text);
                    return false;
                }

               
                if (this.GetByteCount(DN_DIV) == 0)
                {
                    //MsgBox.Show("주야구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_SHIFT.Text);
                    return false;
                }

                if (this.GetByteCount(IMPUT_DIVCD) == 0)
                {
                    //MsgBox.Show("귀책구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_IMPUT_DIVCD.Text);
                    return false;
                }

                //공장구분추가
                if (this.GetByteCount(PLANT_DIV) == 0)
                {
                    //MsgBox.Show("공장구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_PLANT_DIV.Text);
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsRemoveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string DEFNO = this.txt02_DEFNO.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(DEFNO) == 0)
                {
                    //MsgBox.Show("삭제할 데이터를 선택 하지 않았습니다.");
                    MsgCodeBox.Show("QA01-0015");
                    return false;
                }


                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void cdx_SETTING()
        {
            try
            {
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", this.dte02_PROC_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("ITEMCD", this.cdx02_ITEMCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("RCV_DATE", this.dte02_PROC_DATE.GetDateText().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("ITEMCD", this.cdx02_ITEMCD.GetValue().ToString());
                
                this.cdx02_DEF_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))    //2013.04.18 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd_SELECT(int Row)
        {
            try
            {
                this.BtnReset_Click(null, null);

                string BIZCD = this.grd01_QA20211.GetValue(Row, "BIZCD").ToString();
                string PROC_DATE = this.grd01_QA20211.GetValue(Row, "PROC_DATE").ToString();
                string VINCD = this.grd01_QA20211.GetValue(Row, "VINCD").ToString();
                string ITEMCD = this.grd01_QA20211.GetValue(Row, "ITEMCD").ToString();
                string JOB_TYPE = this.grd01_QA20211.GetValue(Row, "JOB_TYPE").ToString();
                string ALCCD = this.grd01_QA20211.GetValue(Row, "ALCCD").ToString();
                string ASSYNO = this.grd01_QA20211.GetValue(Row, "ASSYNO").ToString();
                string MGRT_DIV = this.grd01_QA20211.GetValue(Row, "MGRT_DIV").ToString();
                
                string DEFNO = this.grd01_QA20211.GetValue(Row, "DEFNO").ToString();
                
                string IMPUT_VENDCD = this.grd01_QA20211.GetValue(Row, "IMPUT_VENDCD").ToString();
                string IMPUT_VENDNM = this.grd01_QA20211.GetValue(Row, "INPUT_VENDNM").ToString();
                string PARTNO = this.grd01_QA20211.GetValue(Row, "PARTNO").ToString();
                string PARTNM = this.grd01_QA20211.GetValue(Row, "PARTNM").ToString();
                string DEF_QTY = this.grd01_QA20211.GetValue(Row, "DEF_QTY").ToString();
                
                
                
                string LINECD = this.grd01_QA20211.GetValue(Row, "LINECD").ToString();
                
                string DEFCD = this.grd01_QA20211.GetValue(Row, "DEFCD").ToString();
                string DEFPOSCD = this.grd01_QA20211.GetValue(Row, "DEFPOSCD").ToString();
                string DN_DIV = this.grd01_QA20211.GetValue(Row, "DN_DIV").ToString();
                string IMPUT_DIVCD = this.grd01_QA20211.GetValue(Row, "IMPUT_DIVCD").ToString();
                string PRDT_DIV = this.grd01_QA20211.GetValue(Row, "PRDT_DIV").ToString();

                string PLANT_DIV = this.grd01_QA20211.GetValue(Row, "PLANT_DIV").ToString();        //공장구분 추가

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.dte02_PROC_DATE.SetValue(PROC_DATE);
                this.cdx02_VINCD.SetValue(VINCD);
                this.cdx02_ITEMCD.SetValue(ITEMCD);
                this.cbo02_JOB_TYPE.SetValue(JOB_TYPE);
                this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", this.dte02_PROC_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("ITEMCD", this.cdx02_ITEMCD.GetValue().ToString());
                this.cdx02_ALCCD.SetValue(ALCCD);
                this.cdx02_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("RCV_DATE", this.dte02_PROC_DATE.GetDateText().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("VINCD", this.cdx02_VINCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEUserParameterSetValue("ITEMCD", this.cdx02_ITEMCD.GetValue().ToString());
                this.cdx02_ASSYNO.SetValue(ASSYNO);
                this.cbo02_MGRT_DIV.SetValue(MGRT_DIV);
                //this.nme02_DIS_UCOST.SetValue(DIS_UCOST);
                this.txt02_DEFNO.SetValue(DEFNO);
                
                this.cdx02_IMPUT_VENDCD.SetValue(IMPUT_VENDCD);
                
                this.cdx02_DEF_PARTNO.SetValue(PARTNO);
                this.nme02_DEF_QTY.SetValue(DEF_QTY);
                //this.nme02_DEF_UCOST.SetValue(DEF_UCOST);
                //this.nme02_AMD_QTY.SetValue(AMD_QTY);
                //this.nme02_DEF_AMT.SetValue(DEF_AMT);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_LINECD.SetValue(LINECD);
                //this.txt02_USAGE.SetValue(USAGE);
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.SetValue(DEFCD);
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.SetValue(DEFPOSCD);
                this.cbo02_DN_DIV.SetValue(DN_DIV);
                this.cbo02_IMPUT_DIVCD.SetValue(IMPUT_DIVCD);
                this.txt02_PRDT_DIV.SetValue(PRDT_DIV);

                this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);       //공장구분 추가

                this.cbo02_BIZCD.Enabled = false;
                this.dte02_PROC_DATE.Enabled = false;
                this.cdx02_VINCD.Enabled = false;
                this.cdx02_ITEMCD.Enabled = false;
                this.cbo02_JOB_TYPE.Enabled = false;
                this.cdx02_ALCCD.Enabled = false;
                this.cdx02_ASSYNO.Enabled = false;

                
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
