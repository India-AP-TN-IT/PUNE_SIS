#region ▶ Description & History
/* 
 * 프로그램명 : QA20111 수입 입고 불량발생 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
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
using System.IO;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>수입 입고 불량발생 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:34:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:34:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20111 : AxCommonBaseControl
    {
        //private IQA20111 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private String _DELETE_CHK;
        private String _BIZCD_T;
        private String _RCV_DATE_T;
        private String _VENDCD_T;
        private String _DEFNO_T;
        private String _GUBN;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20111";

        #region [ 초기화 작업 정의 ]

        public QA20111()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20111>("QA00", "QA20111.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _DELETE_CHK = "N";
            _BIZCD_T = "";
            _RCV_DATE_T = "";
            _VENDCD_T = "";
            _DEFNO_T = "";
            _GUBN = "N";
        }

        public QA20111(string BIZCD, string RCV_DATE, string VENDCD, string DEFNO)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20111>("QA00", "QA20111.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _DELETE_CHK = "N";
            _BIZCD_T = BIZCD;
            _RCV_DATE_T = RCV_DATE;
            _VENDCD_T = VENDCD;
            _DEFNO_T = DEFNO;
            _GUBN = "Y";
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.groupBox3.Text = this.GetLabel("QA20111_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20111_MSG2"); 

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
                
                
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가
                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.15 공장구분 조회조건 추가
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))     //2013.04.15 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");                    
                //}
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);

                //2015.06.29 공장구분 - 두서공장 사람인 경우 두서공장 고정(변경 불가) 처리
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                {
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                    this.cbo02_PLANT_DIV.SetReadOnly(true);
                }

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

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = this.GetLabel("PARTNO_INFO");//"품번정보";
                this.cdx02_PARTNO.CodeParameterName = "PARTNO_OF_INSPECTCD";
                this.cdx02_PARTNO.NameParameterName = "PARTNO_OF_INSPECTNM";
                this.cdx02_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_PARTNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEParameterAdd("VENDCD", this.cdx02_VENDCD.GetValue().ToString());
                this.cdx02_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_PARTNO.CodePixedLength = 20;

                this.cdx02_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx02_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx02_DEFCD.CodeParameterName = "DEFCD";
                this.cdx02_DEFCD.NameParameterName = "DEFNM";
                this.cdx02_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);
                //this.cdx02_DEFCD.CodePixedLength = 5;

                this.cdx02_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx02_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx02_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx02_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_MGRT_CNTTCD.HEPopupHelper = new QASubWindow();
                this.cdx02_MGRT_CNTTCD.PopupTitle = this.GetLabel("MGRT_CNTTCD");//"조치내용코드";
                this.cdx02_MGRT_CNTTCD.CodeParameterName = "XD_CODE";
                this.cdx02_MGRT_CNTTCD.NameParameterName = "XD_NAME";
                this.cdx02_MGRT_CNTTCD.HEParameterAdd("XD_CLASS", "FB");
                this.cdx02_MGRT_CNTTCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_MGRT_CNTTCD.HEParameterAdd("USE_YN", "");
                this.cdx02_MGRT_CNTTCD.HEParameterAdd("GROUPCD", "");

                this.cdx02_INSPECT_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_INSPECT_EMPNO.PopupTitle = this.GetLabel("INSPECT_CD");//"검사원코드";
                this.cdx02_INSPECT_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_INSPECT_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_MODULE_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_MODULE_VENDCD.PopupTitle = this.GetLabel("MODULE_VENDCD");//"모듈협력사";
                this.cdx02_MODULE_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_MODULE_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_MODULE_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_MODULE_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_MODULE_INSPECT_CLASSCD.PopupTitle = this.GetLabel("MODULE_ITEM");//"모듈부품";
                this.cdx02_MODULE_INSPECT_CLASSCD.CodeParameterName = "MODULE_INSPECT_CLASSCD";
                this.cdx02_MODULE_INSPECT_CLASSCD.NameParameterName = "ITEMNM";
                this.cdx02_MODULE_INSPECT_CLASSCD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_MODULE_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx02_MODULE_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx02_MODULE_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");

                //6자리로 고정함.  2018.01.25
                //this.cdx02_MODULE_INSPECT_CLASSCD.SetCodePixedLength();
                this.cdx02_MODULE_INSPECT_CLASSCD.CodePixedLength = 6; 

                this.cdx02_MODULE_INSPECT_CLASSCD.SetCodePixedLength();
                this.cdx02_MODULE_INSPECT_CLASSCD.ButtonClickBefore += new AxCodeBox.CButtonClickEventHandler(cdx02_MODULE_INSPECT_CLASSCD_ButtonClickBefore);

                DataSet source = this.GetTypeCode("A1", "FT");
                this.cbo02_JOB_TYPE.DataBind(source.Tables[0], false);
                this.cbo02_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                for(int i=source.Tables[1].Rows.Count-1;i>=0;i--)
                {
                    switch (source.Tables[1].Rows[i]["TYPECD"].ToString())
                    {
                        case "B":
                            source.Tables[1].Rows[i].Delete();
                            break;
                        case "C":
                            source.Tables[1].Rows[i].Delete();
                            break;
                        default:
                            break;
                    }
                }

                this.cbo02_DEF_PLACECD.DataBind(source.Tables[1], false);
                this.cbo02_DEF_PLACECD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.pic02_INSPECT_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_OK_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_DEF_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01_QA20111.AllowEditing = false;
                this.grd01_QA20111.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20111.Initialize();
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE", "OCCUR_DATE");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "발생장소코드", "DEF_PLACECD", "OCCUR_PLACECD2");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "발생장소", "DEF_PLACENM", "OCCUR_PLACECD");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "협력사코드", "VENDCD", "COOPER_CODE");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "협력사", "VENDNM", "COOPER_NM");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "차종", "VINCD", "VIN");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINTYPE", "VIN");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO_TITLE");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNONM", "PARTNMTITLE");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "번호", "DEFNO", "NUMBER");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY", "QTY");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량내용코드", "DEFCD", "DEF_CNTT_CD");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량내용", "DEFNM", "DEF_CNTT");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량부위코드", "DEFPOSCD", "DEFPOSCD2");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량부위", "DEFPOSNM", "DEFPOSNM2");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "조치내용코드", "MGRT_CNTTCD", "MGRT_CNTTCD");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "조치내용", "MGRT_CNTTNM", "MGRT_CNTT");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "업무유형", "JOB_TYPE", "JOB_TYPE2");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "단가", "UCOST", "UCOST");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "검사원", "INSPECT_EMPNO", "INSPECT_NAME");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "회신요구일", "REPLY_DEM_DATE", "REPLY_DEM_DATE");
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "LOTNO", "LOTNO");
                this.grd01_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "공장구분", "PLANT_DIV", "PLANT_DIV"); //2013.04.15 공장구분 추가 (배명희)
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "모듈협력사", "MODULE_VENDCD", "MODULE_VENDCD"); //2016.03.29 모듈협력사 추가 (이현범)
                this.grd01_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "모듈부품", "MODULE_INSPECT_CLASSCD", "MODULE_INSPECT_CLASSCD"); //2016.03.29 모듈부품 추가 (이현범)
                this.grd01_QA20111.AddHiddenColumn("ITEMNM");
                this.grd01_QA20111.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01_QA20111.SetColumnType(AxFlexGrid.FCellType.Date, "REPLY_DEM_DATE");
                this.grd01_QA20111.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA20111.SetColumnType(AxFlexGrid.FCellType.Decimal, "UCOST");
                this.grd01_QA20111.SetColumnType(AxFlexGrid.FCellType.ComboBox,"U9", "PLANT_DIV",true);

                this.grd02_QA20111.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20111.Initialize();
                this.grd02_QA20111.AllowSorting = AllowSortingEnum.None;
                this.grd02_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "불량번호", "DEFNO", "DEFNO");
                this.grd02_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "검사분류코드", "INSPECT_CLASSCD", "INSPECT_CLASSCD");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "순번", "INSPECT_SEQ", "SEQ_NO");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "검사내용", "INSPECT_ITEMNM", "INSPECT_CONTENT");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "표준", "INSPECT_STD_MEAS", "INSPECT_STD_MEAS3");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "상한", "INSPECT_MAX_MEAS", "INSPECT_MAX_MEAS3");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "하한", "INSPECT_MIN_MEAS", "INSPECT_MIN_MEAS3");
                this.grd02_QA20111.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "검사주기코드", "INSPECT_CYCCD", "INSPECT_CYCCD");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "주기", "INSPECT_CYCNM", "INSPECT_CYCNM2");
                this.grd02_QA20111.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "합격", "OK_YN", "PASS");
                this.grd02_QA20111.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "필수", "MAND_INPUT_ITEM_YN", "MAND_INPUT_ITEM");
                this.grd02_QA20111.SetColumnType(AxFlexGrid.FCellType.Check, "OK_YN");
                this.grd02_QA20111.SetColumnType(AxFlexGrid.FCellType.Int, "INSPECT_SEQ");
                this.grd02_QA20111.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_STD_MEAS");
                this.grd02_QA20111.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MAX_MEAS");
                this.grd02_QA20111.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MIN_MEAS");
                this.grd02_QA20111.CurrentContextMenu.Items[0].Visible = false;
                this.grd02_QA20111.CurrentContextMenu.Items[1].Visible = false;
                this.grd02_QA20111.CurrentContextMenu.Items[2].Visible = false;
                this.grd02_QA20111.CurrentContextMenu.Items[3].Visible = false;
                this.SetRequired(lbl01_BIZNM2, lbl01_OCCR_DATE, lbl02_BIZNM2, lbl02_OCCR_DATE, lbl02_COOPER_NM, lbl02_PARTNO, lbl02_JOB_TYPE2, lbl02_DEF_QTY, lbl02_INSPECT_NAME, lbl02_PLANT_DIV);

                this.BtnReset_Click(null, null);

                if (_GUBN == "Y")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD_T);
                    this.dte01_RCV_DATE.SetValue(_RCV_DATE_T);
                    this.cdx01_VENDCD.SetValue(_VENDCD_T);
                    this.txt01_DEFNO.SetValue(_DEFNO_T);
                }

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
                foreach (Control ctl in panel_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.pic02_INSPECT_STD_PHOTO.Initialize();
                this.pic02_OK_PHOTO.Initialize();
                this.pic02_DEF_PHOTO.Initialize();
                this.grd02_QA20111.InitializeDataSource();

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.dte02_RCV_DATE.Enabled = true;
                this.cdx02_VENDCD.Enabled = true;
                this.cdx02_PARTNO.Enabled = true;

                this.cdx_SETTING();

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);

                this.nme02_DEF_QTY.SetValue(0);
                this.nme02_DEF_QTY.Text = "0";
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))     //2013.04.15 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}
                this.nme02_UCOST.SetValue(0);
                this.nme02_DEF_AMT.SetValue(0);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
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


        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string RCV_DATE = this.dte01_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string DEFNO = this.txt01_DEFNO.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString(); //공장구분 항목 추가 2013.04.15 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("DEFNO", DEFNO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);   //공장구분 조회조건 추가 2013.04.15(배명희)

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA1020(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1020"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20111.SetValue(source);

                _DELETE_CHK = "N";

                if (_GUBN == "Y")
                {
                    if (((DataTable)this.grd01_QA20111.DataSource).Rows.Count > 0)
                        this.grd_SELECT(this.grd01_QA20111.Rows.Fixed);

                    _GUBN = "";
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

                string DEFNO = this.txt02_DEFNO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                paramSet.Add("DEFNO", this.txt02_DEFNO.GetValue());
                paramSet.Add("RCV_DATE", this.dte02_RCV_DATE.GetDateText());
                paramSet.Add("VENDCD", this.cdx02_VENDCD.GetValue());
                paramSet.Add("PARTNO", this.cdx02_PARTNO.GetValue());
                paramSet.Add("LOTNO", this.dte02_LOTNO.GetDateText());
                paramSet.Add("DEF_QTY", this.nme02_DEF_QTY.GetDBValue());
                paramSet.Add("UCOST", this.nme02_UCOST.GetDBValue());
                paramSet.Add("INSPECT_EMPNO", this.cdx02_INSPECT_EMPNO.GetValue());
                paramSet.Add("REPLY_DEM_DATE", this.dte02_REPLY_DEM_DATE.GetDateText());
                paramSet.Add("DEF_PLACECD", this.cbo02_DEF_PLACECD.GetValue());
                paramSet.Add("MGRT_CNTTCD", this.cdx02_MGRT_CNTTCD.GetValue());
                paramSet.Add("DEFCD", this.cdx02_DEFCD.GetValue());
                paramSet.Add("DEFPOSCD", this.cdx02_DEFPOSCD.GetValue());
                paramSet.Add("JOB_TYPE", this.cbo02_JOB_TYPE.GetValue());

                paramSet.Add("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue()); //공장구분 항목 추가 2013.04.15 (배명희)
                paramSet.Add("MODULE_VENDCD", this.cdx02_MODULE_VENDCD.GetValue()); //모듈협력사 항목 추가 2016.03.29 (이현범)
                paramSet.Add("MODULE_INSPECT_CLASSCD", this.cdx02_MODULE_INSPECT_CLASSCD.GetValue()); //모듈부품 항목 추가 2016.03.29 (이현범)

                if (!IsSaveValid()) return;

                UCOST_VIEW();

                this.AfterInvokeServer();

                //DataSet source = _WSCOM.Save_QA1020(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA1020"), paramSet);

                string TEMP_DEFNO = source.Tables[0].Rows[0][0].ToString();

                if (TEMP_DEFNO != "")
                {
                    DEFNO = TEMP_DEFNO;
                }

                DataSet source_IMAGE = this.GetDataSourceSchema("CORCD", "BIZCD", "DEFNO", "BLOB$OK_PHOTO", "BLOB$DEF_PHOTO");
                source_IMAGE.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo01_BIZCD.GetValue(),
                    DEFNO,
                    this.pic02_OK_PHOTO.GetValue(),
                    this.pic02_DEF_PHOTO.GetValue()
                );

                DataSet source_QA1030 = this.grd02_QA20111.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD", "DEFNO", "INSPECT_CLASSCD", "INSPECT_SEQ", "OK_YN");

                for (int i = 0; i < source_QA1030.Tables[0].Rows.Count; i++)
                {
                    source_QA1030.Tables[0].Rows[i]["DEFNO"] = DEFNO;
                }

                //_WSCOM.Save_QA1030(source_QA1030);
                //_WSCOM.Save_IMAGE(source_IMAGE);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA1030"), source_QA1030);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_IMAGE"), source_IMAGE);

                _DELETE_CHK = "N";

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("수입 입고 불량발생 등록이 저장 되었습니다.");
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

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "DEFNO");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_DEFNO.GetValue()
                );

                if (!IsRemoveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove_QA1030(source);
                //_WSCOM.Remove_QA1020(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA1030"), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA1020"), source);

                _DELETE_CHK = "N";

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("수입 입고 불량발생 등록이 삭제 되었습니다.");
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

        void cdx02_MODULE_INSPECT_CLASSCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                AxCommonPopupControl pop = (AxCommonPopupControl)this.cdx02_MODULE_INSPECT_CLASSCD.HEPopupHelper;
                pop.Width = 770;
                pop.Height = 450;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_QA20010_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20111.SelectedRowIndex;

                if (Row >= this.grd01_QA20111.Rows.Fixed)
                {
                    this.grd_SELECT(Row);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_MGRT_CNTTCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_INSPECT_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_DEFCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_DEFPOSCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_LIST_SELECT_Click(object sender, EventArgs e)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string DEFNO = this.txt02_DEFNO.GetValue().ToString();
                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();
                string UCOST = this.nme02_UCOST.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();

                if (String.IsNullOrEmpty(DEF_QTY))
                {
                    // 100012 / M0510-G2000T9Y;
                    this.nme02_DEF_QTY.SetValue(0);
                    this.nme02_DEF_QTY.Text = "0";
                    DEF_QTY = "0";
                }

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZNM2"));
                    return;
                }

                if (this.GetByteCount(RCV_DATE) == 0)
                {
                    //MsgBox.Show("발생일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("OCCUR_DATE"));
                    return;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("협력사 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("COOPER_NM"));
                    return;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("PART NO 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("PARTNO"));
                    return;
                }

                if (Convert.ToDouble(DEF_QTY) == 0)
                {
                    //MsgBox.Show("불량수량 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("DEF_QTY"));
                    return;
                }

                if (this.GetByteCount(JOB_TYPE) == 0)
                {
                    //MsgBox.Show("업무유형 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("JOB_TYPE2"));
                    return;
                }

                this.BeforeInvokeServer(true);

                HEParameterSet paramSet = new HEParameterSet();
                DataSet source = new DataSet(); 

                if (DEFNO != "")
                {
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("DEFNO", DEFNO);
                    paramSet.Add("LANG_SET", _LANG_SET);
                    //source = _WSCOM.Inquery_QA1030(paramSet);
                    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1030"), paramSet);
                    this.grd02_QA20111.SetValue(source);
                }
                else
                {
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("PARTNO", PARTNO);
                    paramSet.Add("LANG_SET", _LANG_SET);
                    //source = _WSCOM.Inquery_CD0024(paramSet);
                    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CD0024"), paramSet);
                    this.grd02_QA20111.SetValue(source);
                    for(int i = 1;i<this.grd02_QA20111.Rows.Count;i++)
                    {
                        this.grd02_QA20111.SetValue(i, 0, "N");

                        if (i == 1)
                        {
                            if ((source.Tables[0].Rows[0]["INSPECT_STD_PHOTO"]) != System.DBNull.Value)
                            {
                                byte[] _INSPECT_STD_PHOTO = null;
                                _INSPECT_STD_PHOTO = (byte[])(source.Tables[0].Rows[0]["INSPECT_STD_PHOTO"]);
                                this.pic02_INSPECT_STD_PHOTO.SetValue(_INSPECT_STD_PHOTO);
                            }
                        }
                    }
                }
                this.AfterInvokeServer();
                UCOST_VIEW();

                
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

        private void pic02_INSPECT_STD_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_INSPECT_STD_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_INSPECT_STD_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_OK_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_OK_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_OK_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_DEF_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_DEF_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_DEF_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_MODULE_INSPECT_CLASSCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_MODULE_INSPECT_CLASSCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void btn02_OK_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _OK_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_OK_PHOTO, 0, _OK_PHOTO.Length);
                    fs.Close();

                    this.pic02_OK_PHOTO.SetValue(_OK_PHOTO);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn02_OK_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_OK_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_DEF_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DEF_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_DEF_PHOTO, 0, _DEF_PHOTO.Length);
                    fs.Close();

                    this.pic02_DEF_PHOTO.SetValue(_DEF_PHOTO);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn02_DEF_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_DEF_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string DEFNO = this.dte02_RCV_DATE.GetDateText().ToString();
                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();
                string UCOST = this.nme02_UCOST.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();
                string DEF_AMT = this.nme02_DEF_AMT.GetValue().ToString();
                string INSPECT_EMPNO = this.cdx02_INSPECT_EMPNO.GetValue().ToString();

                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString(); //공장구분 항목 추가 2013.04.15 (배명희)

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZNM2"));
                    return false;
                }

                //공장구분 항목 추가 2013.04.15 (배명희)
                if (this.GetByteCount(PLANT_DIV) == 0)
                {
                    //MsgBox.Show("공장구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("PLANT_DIV"));
                    return false;
                }

                if (this.GetByteCount(RCV_DATE) == 0)
                {
                    //MsgBox.Show("발생일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("OCCUR_DATE"));
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("협력사 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("COOPER_NM"));
                    return false;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("PART NO 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("PARTNO"));
                    return false;
                }

                if (this.GetByteCount(JOB_TYPE) == 0)
                {
                    //MsgBox.Show("업무유형 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("JOB_TYPE2"));
                    return false;
                }

                //if (Int32.Parse(UCOST) <= 0)
                //{
                //    MsgBox.Show("단가 데이터가 입력되지 않았습니다.");
                //    return false;
                //}

                if (this.GetByteCount(DEF_QTY) == 0)
                {
                    //MsgBox.Show("불량수량 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("DEF_QTY"));
                    return false;
                }

                //if (Int32.Parse(DEF_AMT) == 0)
                //{
                //    MsgBox.Show("금액 데이터가 입력되지 않았습니다.");
                //    return false;
                //}

                if (this.GetByteCount(INSPECT_EMPNO) == 0)
                {
                    //MsgBox.Show("검사원 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("INSPECT_NAME"));
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

        private bool IsRemoveValid()
        {
            try
            {
                if (_DELETE_CHK == "N")
                {
                    //MsgBox.Show("삭제를 위해서는 데이터를 조회하여 삭제 하시기 바랍니다.");
                    MsgCodeBox.Show("QA00-014");
                    return false;
                }

                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string DEFNO = this.dte02_RCV_DATE.GetDateText().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZNM2"));
                    return false;
                }

                if (this.GetByteCount(DEFNO) == 0)
                {
                    //MsgBox.Show("불량번호 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("DEFNO"));
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
                this.cdx02_MGRT_CNTTCD.HEUserParameterSetValue("XD_CLASS", "FB");
                this.cdx02_MGRT_CNTTCD.HEUserParameterSetValue("USE_YN", "");
                this.cdx02_MGRT_CNTTCD.HEUserParameterSetValue("GROUPCD", "");
                this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("VENDCD", this.cdx02_VENDCD.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_MODULE_INSPECT_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))    //2013.04.17 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}

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
                string BIZCD = this.grd01_QA20111.GetValue(Row, "BIZCD").ToString();
                string RCV_DATE = this.grd01_QA20111.GetValue(Row, "RCV_DATE").ToString();
                string DEFNO = this.grd01_QA20111.GetValue(Row, "DEFNO").ToString();
                string LOTNO = this.grd01_QA20111.GetValue(Row, "LOTNO").ToString();
                string VENDCD = this.grd01_QA20111.GetValue(Row, "VENDCD").ToString();
                string PARTNO = this.grd01_QA20111.GetValue(Row, "PARTNO").ToString();
                string JOB_TYPE = this.grd01_QA20111.GetValue(Row, "JOB_TYPE").ToString();
                string UCOST = this.grd01_QA20111.GetValue(Row, "UCOST").ToString();
                string DEF_QTY = this.grd01_QA20111.GetValue(Row, "DEF_QTY").ToString();
                string DEF_PLACECD = this.grd01_QA20111.GetValue(Row, "DEF_PLACECD").ToString();
                string DEFCD = this.grd01_QA20111.GetValue(Row, "DEFCD").ToString();
                string DEFPOSCD = this.grd01_QA20111.GetValue(Row, "DEFPOSCD").ToString();
                string MGRT_CNTTCD = this.grd01_QA20111.GetValue(Row, "MGRT_CNTTCD").ToString();
                string INSPECT_EMPNO = this.grd01_QA20111.GetValue(Row, "INSPECT_EMPNO").ToString();
                string REPLY_DEM_DATE = this.grd01_QA20111.GetValue(Row, "REPLY_DEM_DATE").ToString();

                string PLANT_DIV = this.grd01_QA20111.GetValue(Row, "PLANT_DIV").ToString(); //2013.04.15 공장구분 추가 (배명희)
                string MODULE_VENDCD = this.grd01_QA20111.GetValue(Row, "MODULE_VENDCD").ToString(); //2016.03.29 모듈협력사 추가 (이현범)
                string MODULE_INSPECT_CLASSCD = this.grd01_QA20111.GetValue(Row, "MODULE_INSPECT_CLASSCD").ToString(); //2016.03.29 모듈부품 추가 (이현범)
                string ITEMNM = this.grd01_QA20111.GetValue(Row, "ITEMNM").ToString(); //2016.03.29 모듈부품 추가 (이현범)

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.dte02_RCV_DATE.SetValue(RCV_DATE);
                this.txt02_DEFNO.SetValue(DEFNO);
                this.dte02_LOTNO.SetValue(LOTNO);
                this.cdx02_VENDCD.SetValue(VENDCD);
                cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                cdx02_PARTNO.HEUserParameterSetValue("VENDCD", this.cdx02_VENDCD.GetValue().ToString());
                this.cdx02_PARTNO.SetValue(PARTNO);
                this.cbo02_JOB_TYPE.SetValue(JOB_TYPE);
                this.nme02_UCOST.SetValue(UCOST);
                this.nme02_DEF_QTY.SetValue(DEF_QTY);
                this.nme02_DEF_AMT.SetValue(Convert.ToDouble(UCOST) * Convert.ToDouble(DEF_QTY));
                this.cbo02_DEF_PLACECD.SetValue(DEF_PLACECD);
                this.cdx02_DEFCD.SetValue(DEFCD);
                this.cdx02_DEFPOSCD.SetValue(DEFPOSCD);
                this.cdx02_MGRT_CNTTCD.SetValue(MGRT_CNTTCD);
                this.cdx02_INSPECT_EMPNO.SetValue(INSPECT_EMPNO);
                this.dte02_REPLY_DEM_DATE.SetValue(REPLY_DEM_DATE);

                this.cbo02_PLANT_DIV.SetValue(PLANT_DIV); //2013.04.15 공장구분 추가 (배명희)
                this.cdx02_MODULE_VENDCD.SetValue(MODULE_VENDCD);
                cdx02_MODULE_INSPECT_CLASSCD.HEUserParameterSetValue("BIZCD", BIZCD);
                cdx02_MODULE_INSPECT_CLASSCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                cdx02_MODULE_INSPECT_CLASSCD.HEUserParameterSetValue("PLANT_DIV", PLANT_DIV);
                this.cdx02_MODULE_INSPECT_CLASSCD.SetValue(MODULE_INSPECT_CLASSCD);
                this.cdx02_MODULE_INSPECT_CLASSCD.SetText(ITEMNM);

                btn02_LIST_SELECT_Click(null, null);
                IMAGE_VIEW(BIZCD, DEFNO);

                this.cbo02_BIZCD.Enabled = false;
                this.dte02_RCV_DATE.Enabled = false;
                this.cdx02_VENDCD.Enabled = false;
                this.cdx02_PARTNO.Enabled = false;

                _DELETE_CHK = "Y";
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void UCOST_VIEW()
        {
            try
            {
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();
                string UCOST = this.nme02_UCOST.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();

                if (String.IsNullOrEmpty(DEF_QTY))
                {
                    // 100012 / M0510-G2000T9Y;
                    this.nme02_DEF_QTY.SetValue(0);
                    this.nme02_DEF_QTY.Text = "0";
                    DEF_QTY = "0";
                }

                if (BIZCD != "" && RCV_DATE != "" && VENDCD != "" && PARTNO != "" && JOB_TYPE != "" && DEF_QTY != "")
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("RCV_DATE", RCV_DATE);
                    paramSet.Add("VENDCD", VENDCD);
                    paramSet.Add("PARTNO", PARTNO);
                    paramSet.Add("JOB_TYPE", JOB_TYPE);
                    paramSet.Add("LANG_SET", this.UserInfo.Language);
                    //DataSet source = _WSCOM.Inquery_UCOST_VIEW(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_UCOST_VIEW"), paramSet);

                    this.nme02_UCOST.SetValue(source.Tables[0].Rows[0]["UCOST"].ToString());
                    this.nme02_DEF_AMT.SetValue(Convert.ToDouble(source.Tables[0].Rows[0]["UCOST"].ToString()) * Convert.ToDouble(DEF_QTY));
                }
                else
                {
                    this.nme02_UCOST.SetValue("0");
                    this.nme02_DEF_AMT.SetValue("0");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void IMAGE_VIEW(string BIZCD, string DEFNO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DEFNO", DEFNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                if ((dr["OK_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _OK_PHOTO = null;
                    _OK_PHOTO = (byte[])(dr["OK_PHOTO"]);
                    this.pic02_OK_PHOTO.SetValue(_OK_PHOTO);
                }

                if ((dr["DEF_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _DEF_PHOTO = null;
                    _DEF_PHOTO = (byte[])(dr["DEF_PHOTO"]);
                    this.pic02_DEF_PHOTO.SetValue(_DEF_PHOTO);
                }

                if ((dr["INSPECT_STD_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _INSPECT_STD_PHOTO = null;
                    _INSPECT_STD_PHOTO = (byte[])(dr["INSPECT_STD_PHOTO"]);
                    this.pic02_INSPECT_STD_PHOTO.SetValue(_INSPECT_STD_PHOTO);
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

        #endregion

    }
}
