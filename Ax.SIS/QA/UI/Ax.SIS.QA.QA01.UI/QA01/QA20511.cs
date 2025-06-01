#region ▶ Description & History
/* 
 * 프로그램명 : QA20511 품질 AUDIT 등록
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
 *				2015-07-27      배명희      통합WCF로 변경 
 * 
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using System.IO;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>품질 AUDIT 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 7:09:42<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 7:09:42   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20511 : AxCommonBaseControl
    {
        //private IQA20511 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private String _BIZCD_T;
        private String _PPT_DATE_FROM_T;
        private String _PPT_DATE_TO_T;
        private String _VENDCD_T;
        private String _AUDIT_TYPE_T;
        private String _VINCD_T;
        private String _FILENO_T;
        private String _GUBN;
        private String _PLANT_DIV;


        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20511";

        #region [ 초기화 작업 정의 ]

        public QA20511()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20511>("QA01", "QA20511.svc", "CustomBinding");

            _BIZCD_T = "";
            _PPT_DATE_FROM_T = "";
            _PPT_DATE_TO_T = "";
            _VENDCD_T = "";
            _AUDIT_TYPE_T = "";
            _VINCD_T = "";
            _FILENO_T = "";
            _GUBN = "N";
            _PLANT_DIV = "";

            _WSCOM_N = new AxClientProxy();
        }

        public QA20511(string BIZCD, string PPT_DATE_FROM, string PPT_DATE_TO, string VENDCD, string AUDIT_TYPE, string VINCD, string FILENO, string PLANT_DIV)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20511>("QA01", "QA20511.svc", "CustomBinding");

            _BIZCD_T = BIZCD;
            _PPT_DATE_FROM_T = PPT_DATE_FROM;
            _PPT_DATE_TO_T = PPT_DATE_TO;
            _VENDCD_T = VENDCD;
            _AUDIT_TYPE_T = AUDIT_TYPE;
            _VINCD_T = VINCD;
            _FILENO_T = FILENO;
            _GUBN = "Y";
            _PLANT_DIV=PLANT_DIV;

            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
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

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");// "차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"협력사코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                if (VENDCD == "")
                {
                    VENDCD = "";
                }
                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = "PART NO";
                this.cdx02_PARTNO.CodeParameterName = "PARTNO_OF_VENDCD";
                this.cdx02_PARTNO.NameParameterName = "PARTNO_OF_VENDNM";
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
                //this.cdx02_DEFCD.CodePixedLength = 5;
                this.cdx02_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx02_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx02_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx02_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet source = this.GetTypeCode("F6", "FT", "FB", "F1");
                this.cbo01_AUDIT_TYPE.DataBind(source.Tables[0], true);
                this.cbo01_AUDIT_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_AUDIT_TYPE.DataBind(source.Tables[0], true);
                this.cbo02_AUDIT_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_DEF_PLACECD.DataBind(source.Tables[1], true);
                this.cbo02_DEF_PLACECD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_MGRT_CNTTCD.DataBind(source.Tables[2], true);
                this.cbo02_MGRT_CNTTCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_VER_4M_TYPE.DataBind(source.Tables[3], true);
                this.cbo02_VER_4M_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA20511.AllowEditing = false;
                this.grd01_QA20511.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20511.Initialize();
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "문서그룹", "FILENO","DOC_GROUP");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 75, "업무유형", "AUDIT_TYPE", "JOB_TYPE");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "업무유형", "AUDIT_TYPENM", "JOB_TYPE");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "발표일자", "PPT_DATE", "PPT_DATE");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 30, "S", "SEQ");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "첨부", "FILE_CNT", "ATTACHMENT");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 60, "불량장소", "DEF_PLACECD", "DEF_PLACE");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "불량장소", "DEF_PLACENM", "DEF_PLACE");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "협력사", "VENDCD", "COOPER_NM");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "협력사", "VENDNM", "COOPER_NM");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VIN");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "불량명", "DEFCD", "DEFNM");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량명", "DEFNM", "DEFNM");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "부위명", "DEFPOSCD", "DEFPOSNM");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "부위명", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "4M구분", "VER_4M_TYPE", "VER_4M_TYPE");
                this.grd01_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "조치내용", "MGRT_CNTTCD", "MGRT_CNTTNM");
                this.grd01_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "조치내용", "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd01_QA20511.SetColumnType(AxFlexGrid.FCellType.Decimal, "FILE_CNT");
                this.grd01_QA20511.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01_QA20511.SetColumnType(AxFlexGrid.FCellType.ComboBox, "F1", "VER_4M_TYPE");
                this.grd01_QA20511.SetColumnType(AxFlexGrid.FCellType.Date, "PPT_DATE");
                this.grd02_QA20511.AllowEditing = false;
                this.grd02_QA20511.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20511.Initialize();
                this.grd02_QA20511.AllowSorting = AllowSortingEnum.None;
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 55, "문서그룹", "FILENO", "DOC_GROUP");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 50, "업무유형", "AUDIT_TYPE", "JOB_TYPE");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "업무유형", "AUDIT_TYPENM", "JOB_TYPE");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "발표일자", "PPT_DATE", "PPT_DATE");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 30, "S", "SEQ");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "첨부", "FILE_CNT", "ATTACHMENT");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "불량장소", "DEF_PLACECD", "DEF_PLACE");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "불량장소", "DEF_PLACENM", "DEF_PLACE");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "협력사", "VENDCD", "COOPER_NM");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "협력사", "VENDNM", "COOPER_NM");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VIN");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "불량명", "DEFCD", "DEFNM");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량명", "DEFNM", "DEFNM");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "부위명", "DEFPOSCD", "DEFPOSNM");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "부위명", "DEFPOSNM", "DEFPOSNM");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "4M구분", "VER_4M_TYPE", "VER_4M_TYPE");
                this.grd02_QA20511.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "조치내용", "MGRT_CNTTCD", "MGRT_CNTTNM");
                this.grd02_QA20511.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "조치내용", "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd02_QA20511.SetColumnType(AxFlexGrid.FCellType.Decimal, "FILE_CNT");
                this.grd02_QA20511.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd02_QA20511.SetColumnType(AxFlexGrid.FCellType.ComboBox, "F1", "VER_4M_TYPE");
                this.grd02_QA20511.SetColumnType(AxFlexGrid.FCellType.Date, "PPT_DATE");
                
                this.grd03_QA20511.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd03_QA20511.AllowEditing = false;
                this.grd03_QA20511.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA20511.Initialize();
                this.grd03_QA20511.AllowSorting = AllowSortingEnum.None;
                this.grd03_QA20511.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03_QA20511.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd03_QA20511.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "문서그룹", "FILENO", "DOC_GROUP");
                this.grd03_QA20511.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "문서순번", "FILE_SEQ", "DOC_SEQ");
                this.grd03_QA20511.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "경로", "FILE_PATH", "FILE_PATH");
                this.grd03_QA20511.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "파일명", "FILE_NAME", "FILE_NAME5");
                this.grd03_QA20511.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "용량(KB)", "FILE_SIZE", "FILE_SIZE2");
                this.grd03_QA20511.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "첨부", "FILE_FIND", "ATTACHMENT");
                this.grd03_QA20511.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "첨부", "FILE_REMOVE", "ATTACHMENT");
                this.grd03_QA20511.SetColumnType(AxFlexGrid.FCellType.Decimal, "FILE_SIZE");

                this.grd03_QA20511.AddMerge(0, 0, "FILE_FIND", "FILE_REMOVE");

                this.grd03_QA20511.SetHeadTitle(0, "FILE_FIND", this.GetLabel("ATTACH_FILE_PROCESS"));//"첨부파일처리");

                this.SetRequired(lbl01_BIZNM, lbl01_ATN_QUITT_TERM, lbl02_BIZNM, lbl02_PPT_DATE, lbl02_JOB_TYPE, lbl02_COOPER_NM);

                this.BtnReset_Click(null, null);


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                if (_GUBN == "Y")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD_T);
                    this.dte01_PPT_DATE_FROM.SetValue(_PPT_DATE_FROM_T);
                    this.dte01_PPT_DATE_TO.SetValue(_PPT_DATE_TO_T);
                    this.cdx01_VENDCD.SetValue(_VENDCD_T);
                    this.cbo01_AUDIT_TYPE.SetValue(_AUDIT_TYPE_T);
                    this.cdx01_VINCD.SetValue(_VINCD_T);
                    this.txt01_FILENO.SetValue(_FILENO_T);
                    this.cbo01_PLANT_DIV.SetValue(_PLANT_DIV);
                }

                //this.dte01_PPT_DATE_FROM.SetMMFromStart();
                this.dte01_PPT_DATE_FROM.SetValue(this.dte01_PPT_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");


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
                        ((IAxControl)ctl).Initialize();
                    }
                }
                
                foreach (Control ctl in groupBox_main_Sub.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.dte02_PPT_DATE.Initialize();
                this.txt02_SEQ.Initialize();
                this.cbo02_AUDIT_TYPE.Initialize();

                this.grd02_QA20511.InitializeDataSource();
                this.grd03_QA20511.InitializeDataSource();

                this.txt02_ALCCD.Visible = false;
                this.lbl02_ALC.Visible = false;
                this.QA20511_Rows_Add("");

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }

                this.dte02_PPT_DATE.Enabled = true;

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
                string PPT_DATE_FROM = this.dte01_PPT_DATE_FROM.GetDateText().ToString();
                string PPT_DATE_TO = this.dte01_PPT_DATE_TO.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string AUDIT_TYPE = this.cbo01_AUDIT_TYPE.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string FILENO = this.txt01_FILENO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PPT_DATE_FROM", PPT_DATE_FROM);
                paramSet.Add("PPT_DATE_TO", PPT_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("AUDIT_TYPE", AUDIT_TYPE);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("FILENO", FILENO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("GUBN", "1");
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20511.SetValue(source);

                if (_GUBN == "Y")
                {
                    if (((DataTable)this.grd01_QA20511.DataSource).Rows.Count > 0)
                        this.grd_SELECT(this.grd01_QA20511.Rows.Fixed);

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

                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PPT_DATE = this.dte02_PPT_DATE.GetDateText().ToString();


                HEParameterSet setPK = new HEParameterSet();
                setPK.Add("CORCD", _CORCD);
                setPK.Add("BIZCD", BIZCD);
                setPK.Add("PPT_DATE", PPT_DATE);
                setPK.Add("FILENO", this.txt02_FILENO.GetValue());
                setPK.Add("LANG_SET", this.UserInfo.Language);

                #region 헤더(QA5010) 데이터 추출

                DataSet source_QA5010 = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "PPT_DATE", "SEQ", "AUDIT_TYPE",
                    "VENDCD", "PARTNO", "DEF_QTY", "DEF_PLACECD", "DEFCD", "DEFPOSCD", "MGRT_CNTTCD", "VER_4M_TYPE", "FILENO", "WORK_EMPNO", "PLANT_DIV");

                int y = 0;
                for (int i = 1; i < grd02_QA20511.Rows.Count; i++)
                {
                    if (grd02_QA20511.GetValue(i, 0).ToString() != "D")
                    {
                        y = y + 1;
                        source_QA5010.Tables[0].Rows.Add(
                            _CORCD,
                            grd02_QA20511.GetValue(i, "BIZCD"),
                            grd02_QA20511.GetValue(i, "PPT_DATE"),
                            y,
                            grd02_QA20511.GetValue(i, "AUDIT_TYPE"),
                            grd02_QA20511.GetValue(i, "VENDCD"),
                            grd02_QA20511.GetValue(i, "PARTNO"),
                            grd02_QA20511.GetValue(i, "DEF_QTY"),
                            grd02_QA20511.GetValue(i, "DEF_PLACECD"),
                            grd02_QA20511.GetValue(i, "DEFCD"),
                            grd02_QA20511.GetValue(i, "DEFPOSCD"),
                            grd02_QA20511.GetValue(i, "MGRT_CNTTCD"),
                            grd02_QA20511.GetValue(i, "VER_4M_TYPE"),
                            grd02_QA20511.GetValue(i, "FILENO"),
                            this.UserInfo.EmpNo,
                            this.cbo01_PLANT_DIV.GetValue().ToString());
                    }
                }

                for (int i = 0; i < source_QA5010.Tables[0].Rows.Count; i++)
                {
                    source_QA5010.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    source_QA5010.Tables[0].Rows[i]["SEQ"] = i + 1;
                    source_QA5010.Tables[0].Rows[i]["WORK_EMPNO"] = this.UserInfo.EmpNo;
                    source_QA5010.Tables[0].Rows[i]["PLANT_DIV"] = this.cbo01_PLANT_DIV.GetValue().ToString();
                }


                DataSet remove_QA5010 = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "FILENO");



                #endregion

                #region 디테일(QA5011) 데이터 추출

                DataSet Save_QA5011 = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "FILENO", "FILE_SEQ", "FILE_NAME", "BLOB$FILE_DATA", "WORK_EMPNO");

                DataSet Remove_QA5011 = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "FILENO", "FILE_SEQ");

                for (int i = 0; i < grd03_QA20511.Rows.Count; i++)
                {
                    if (grd03_QA20511.GetValue(i, 0).ToString() == "D")
                    {
                        Remove_QA5011.Tables[0].Rows.Add(
                            _CORCD,
                            this.cbo02_BIZCD.GetValue().ToString(),
                            grd03_QA20511.GetValue(i, "FILENO"),
                            i
                        );
                    }
                    else if (grd03_QA20511.GetValue(i, 0).ToString() == "N" || grd03_QA20511.GetValue(i, 0).ToString() == "U")
                    {
                        Save_QA5011.Tables[0].Rows.Add(
                            _CORCD,
                            this.cbo02_BIZCD.GetValue().ToString(),
                            grd03_QA20511.GetValue(i, "FILENO"),
                            i,
                            grd03_QA20511.GetValue(i, "FILE_NAME"),
                            this.FILE_OPEN(grd03_QA20511.GetValue(i, "FILE_PATH").ToString()),
                            this.UserInfo.EmpNo
                        );
                    }
                }

                #endregion

                if (!IsSaveValid(source_QA5010, Save_QA5011, Remove_QA5011)) return;

                this.BeforeInvokeServer(true);

                //PK값 먼저 저장 처리
                DataSet source = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_FILENO"), setPK);
                string FILENO = source.Tables[0].Rows[0]["FILENO"].ToString();


                //채번된 DPTNO값 넣어주기
                remove_QA5010.Tables[0].ImportRow(source.Tables[0].Rows[0]);
                foreach (DataRow dr in source_QA5010.Tables[0].Rows)
                {
                    dr["FILENO"] = FILENO;
                }
                foreach (DataRow dr in Save_QA5011.Tables[0].Rows)
                {
                    dr["FILENO"] = FILENO;
                }
                foreach (DataRow dr in Remove_QA5011.Tables[0].Rows)
                {
                    dr["FILENO"] = FILENO;
                }


                try
                {
                    //transaction 저장처리
                    if (this.txt02_FILENO.IsEmpty)
                    {
                        //신규등록인 경우
                        _WSCOM_N.MultipleExecuteNonQueryTx(new string[] {string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA5010"),
                                                                         string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA5011")},
                                                           new DataSet[] { source_QA5010, Save_QA5011});
                    }
                    else
                    {
                        //기존 수정인 경우
                        _WSCOM_N.MultipleExecuteNonQueryTx(new string[] {string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA5010"),
                                                                         string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA5010"),
                                                                         string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA5011"),
                                                                         string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA5011")},
                                                           new DataSet[] { remove_QA5010, source_QA5010, Save_QA5011, Remove_QA5011 });
                    }
                }
                catch (Exception ex)
                {

                    if (this.txt02_FILENO.IsEmpty) //신규모드였던 경우, 등록했던 데이터 삭제처리.
                        _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_FILENO"), remove_QA5010);

                    throw ex;
                }

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("품질 AUDIT 등록이 저장되었습니다.");
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

        //기존 소스 주석처리
        //protected override void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
        //        {
        //            //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
        //            MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
        //            return;
        //        }

        //        string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
        //        string PPT_DATE = this.dte02_PPT_DATE.GetValue().ToString();
        //        string FILENO = this.txt02_FILENO.GetValue().ToString();

        //        HEParameterSet paramSet = new HEParameterSet();
        //        paramSet.Add("CORCD", _CORCD);
        //        paramSet.Add("BIZCD", BIZCD);
        //        paramSet.Add("PPT_DATE", PPT_DATE);
        //        paramSet.Add("FILENO", FILENO);
        //        paramSet.Add("LANG_SET", this.UserInfo.Language);

        //        DataSet source_QA5010 = AxFlexGrid.GetDataSourceSchema(
        //            "CORCD", "BIZCD", "PPT_DATE", "SEQ", "AUDIT_TYPE",
        //            "VENDCD", "PARTNO", "DEF_QTY", "DEF_PLACECD", "DEFCD", "DEFPOSCD", "MGRT_CNTTCD", "VER_4M_TYPE", "FILENO", "WORK_EMPNO","PLANT_DIV");

        //        int y = 0;
        //        for (int i = 1; i < grd02_QA20511.Rows.Count; i++)
        //        {
        //            if (grd02_QA20511.GetValue(i, 0).ToString() != "D")
        //            {
        //                y = y + 1;
        //                source_QA5010.Tables[0].Rows.Add(
        //                    _CORCD, 
        //                    grd02_QA20511.GetValue(i,"BIZCD"), 
        //                    grd02_QA20511.GetValue(i,"PPT_DATE"),
        //                    y, 
        //                    grd02_QA20511.GetValue(i,"AUDIT_TYPE"),
        //                    grd02_QA20511.GetValue(i,"VENDCD"), 
        //                    grd02_QA20511.GetValue(i,"PARTNO"), 
        //                    grd02_QA20511.GetValue(i,"DEF_QTY"), 
        //                    grd02_QA20511.GetValue(i,"DEF_PLACECD"),
        //                    grd02_QA20511.GetValue(i,"DEFCD"),
        //                    grd02_QA20511.GetValue(i,"DEFPOSCD"),
        //                    grd02_QA20511.GetValue(i,"MGRT_CNTTCD"),
        //                    grd02_QA20511.GetValue(i,"VER_4M_TYPE"),
        //                    grd02_QA20511.GetValue(i,"FILENO"),
        //                    this.UserInfo.EmpNo,
        //                    this.cbo01_PLANT_DIV.GetValue().ToString());
        //            }
        //        }

        //        for (int i = 0; i < source_QA5010.Tables[0].Rows.Count; i++)
        //        {
        //            source_QA5010.Tables[0].Rows[i]["CORCD"] = _CORCD;
        //            source_QA5010.Tables[0].Rows[i]["SEQ"] = i + 1;
        //            source_QA5010.Tables[0].Rows[i]["WORK_EMPNO"] = this.UserInfo.EmpNo;
        //            source_QA5010.Tables[0].Rows[i]["PLANT_DIV"] = this.cbo01_PLANT_DIV.GetValue().ToString();
        //        }

        //        DataSet Save_QA5011 = AxFlexGrid.GetDataSourceSchema(
        //            "CORCD", "BIZCD", "FILENO", "FILE_SEQ", "FILE_NAME", "BLOB$FILE_DATA", "WORK_EMPNO");

        //        DataSet Remove_QA5011 = AxFlexGrid.GetDataSourceSchema(
        //            "CORCD", "BIZCD", "FILENO", "FILE_SEQ");

        //        for (int i = 0; i < grd03_QA20511.Rows.Count; i++)
        //        {
        //            if (grd03_QA20511.GetValue(i, 0).ToString() == "D")
        //            {
        //                Remove_QA5011.Tables[0].Rows.Add(
        //                    _CORCD,
        //                    this.cbo02_BIZCD.GetValue().ToString(),
        //                    grd03_QA20511.GetValue(i, "FILENO"),
        //                    i
        //                );
        //            }
        //            else if (grd03_QA20511.GetValue(i, 0).ToString() == "N" || grd03_QA20511.GetValue(i, 0).ToString() == "U")
        //            {
        //                Save_QA5011.Tables[0].Rows.Add(
        //                    _CORCD,
        //                    this.cbo02_BIZCD.GetValue().ToString(),
        //                    grd03_QA20511.GetValue(i, "FILENO"),
        //                    i,
        //                    grd03_QA20511.GetValue(i, "FILE_NAME"),
        //                    this.FILE_OPEN(grd03_QA20511.GetValue(i, "FILE_PATH").ToString()),
        //                    this.UserInfo.EmpNo
        //                );
        //            }
        //        }

        //        if (!IsSaveValid(source_QA5010, Save_QA5011, Remove_QA5011)) return;

        //        this.BeforeInvokeServer(true);

        //        DataSet FILENO_source = _WSCOM.Save(paramSet, source_QA5010);

        //        for (int i = 0; i < Save_QA5011.Tables[0].Rows.Count; i++)
        //        {
        //            Save_QA5011.Tables[0].Rows[i]["FILENO"] = FILENO_source.Tables[0].Rows[0]["FILENO"].ToString();
        //        }

        //        for (int i = 0; i < Remove_QA5011.Tables[0].Rows.Count; i++)
        //        {
        //            Remove_QA5011.Tables[0].Rows[i]["FILENO"] = FILENO_source.Tables[0].Rows[0]["FILENO"].ToString();
        //        }

        //        for (int i = 0; i < Save_QA5011.Tables[0].Rows.Count; i++)
        //        {
        //            //_WSCOM.Save_IMAGE_SAVE(Save_QA5011);
        //            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA5011"), Save_QA5011);
        //        }

        //        for (int i = 0; i < Remove_QA5011.Tables[0].Rows.Count; i++)
        //        {
        //            //_WSCOM.Save_IMAGE_REMOVE(Remove_QA5011);
        //            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA5011"), Remove_QA5011);
        //        }

        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);
        //        this.BtnReset_Click(null, null);

        //        MsgCodeBox.Show("CD00-0071");
        //        //MsgBox.Show("품질 AUDIT 등록이 저장되었습니다.");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

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
                string FILENO = this.txt02_FILENO.GetValue().ToString();

                DataSet source_Remove = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "FILENO");

                source_Remove.Tables[0].Rows.Add(
                    _CORCD,
                    BIZCD,
                    FILENO
                );

                if (!IsRemoveValid(source_Remove)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source_Remove);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source_Remove);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("품질 AUDIT 등록이 삭제 되었습니다.");
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

        private void grd01_QA20511_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20511.SelectedRowIndex;

                if (Row >= this.grd01_QA20511.Rows.Fixed)
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

        private void grd02_QA20511_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd02_QA20511.SelectedRowIndex;

                if (Row >= this.grd02_QA20511.Rows.Fixed)
                {
                    string FILENO = this.grd02_QA20511.GetValue(Row, "FILENO").ToString();
                    string BIZCD = this.grd02_QA20511.GetValue(Row, "BIZCD").ToString();
                    string PPT_DATE = this.grd02_QA20511.GetValue(Row, "PPT_DATE").ToString();
                    string SEQ = this.grd02_QA20511.GetValue(Row, "SEQ").ToString();
                    string AUDIT_TYPE = this.grd02_QA20511.GetValue(Row, "AUDIT_TYPE").ToString();
                    string VENDCD = this.grd02_QA20511.GetValue(Row, "VENDCD").ToString();
                    string PARTNO = this.grd02_QA20511.GetValue(Row, "PARTNO").ToString();
                    string DEF_QTY = this.grd02_QA20511.GetValue(Row, "DEF_QTY").ToString();
                    string DEFCD = this.grd02_QA20511.GetValue(Row, "DEFCD").ToString();
                    string DEFPOSCD = this.grd02_QA20511.GetValue(Row, "DEFPOSCD").ToString();
                    string DEF_PLACECD = this.grd02_QA20511.GetValue(Row, "DEF_PLACECD").ToString();
                    string MGRT_CNTTCD = this.grd02_QA20511.GetValue(Row, "MGRT_CNTTCD").ToString();
                    string VER_4M_TYPE = this.grd02_QA20511.GetValue(Row, "VER_4M_TYPE").ToString();

                    this.txt02_FILENO.SetValue(FILENO);
                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.dte02_PPT_DATE.SetValue(PPT_DATE);
                    this.txt02_SEQ.SetValue(SEQ);
                    this.cbo02_AUDIT_TYPE.SetValue(AUDIT_TYPE);
                    this.cdx02_VENDCD.SetValue(VENDCD);
                    this.chk02_ALL_PARTNO.SetValue(false);
                    this.txt02_ALCCD.SetValue("");
                    this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                    this.cdx02_PARTNO.HEUserParameterSetValue("VENDCD", "");
                    this.cdx02_PARTNO.SetValue(PARTNO);
                    this.nme02_DEF_QTY.SetValue(DEF_QTY);
                    this.cbo02_DEF_PLACECD.SetValue(DEF_PLACECD);
                    this.cdx02_DEFCD.SetValue(DEFCD);
                    this.cdx02_DEFPOSCD.SetValue(DEFPOSCD);
                    this.cbo02_MGRT_CNTTCD.SetValue(MGRT_CNTTCD);
                    this.cbo02_VER_4M_TYPE.SetValue(VER_4M_TYPE);

                    this.cbo02_BIZCD.Enabled = false;
                    this.dte02_PPT_DATE.Enabled = false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd03_QA20511_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int iROW = this.grd03_QA20511.Row;
                int iCOL = this.grd03_QA20511.Col;

                if (iROW > 0)
                {
                    switch (this.grd03_QA20511.Cols[iCOL].Name.ToString().ToUpper().Trim())
                    {
                        case "FILE_FIND":
                            OpenFileDialog file = new OpenFileDialog();
                            if (file.ShowDialog() == DialogResult.OK)
                            {
                                this.grd03_QA20511.SetValue(iROW, "FILE_PATH", file.FileName);
                                this.grd03_QA20511.SetValue(iROW, "FILE_NAME", file.FileName.Substring(file.FileName.LastIndexOf("\\")+1));
                                this.grd03_QA20511.SetValue(iROW, "FILE_SIZE", (int)file.OpenFile().Length / 1024);
                                this.grd03_QA20511.SetValue(iROW, 0, "U");
                            }

                            break;
                        case "FILE_REMOVE":
                            this.grd03_QA20511.SetValue(iROW, "FILE_PATH", "");
                            this.grd03_QA20511.SetValue(iROW, "FILE_NAME", "");
                            this.grd03_QA20511.SetValue(iROW, "FILE_SIZE", "");
                            this.grd03_QA20511.SetValue(iROW, 0, "D");

                            break;
                        case "FILE_NAME":
                            if (this.grd03_QA20511.GetValue(iROW, "FILE_NAME").ToString() != "")
                            {
                                string CORCD = this.grd03_QA20511.GetValue(iROW, "CORCD").ToString();
                                string BIZCD = this.grd03_QA20511.GetValue(iROW, "BIZCD").ToString();
                                string FILENO = this.grd03_QA20511.GetValue(iROW, "FILENO").ToString();
                                string FILE_SEQ = this.grd03_QA20511.GetValue(iROW, "FILE_SEQ").ToString();

                                HEParameterSet paramSet = new HEParameterSet();
                                paramSet.Add("CORCD", CORCD);
                                paramSet.Add("BIZCD", BIZCD);
                                paramSet.Add("FILENO", FILENO);
                                paramSet.Add("FILE_SEQ", iROW);
                                paramSet.Add("LANG_SET", this.UserInfo.Language);

                                this.BeforeInvokeServer(true);

                                //DataSet source = _WSCOM.Inquery_GET_FILE(paramSet);
                                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE"), paramSet);

                                this.AfterInvokeServer();

                                if (source.Tables[0].Rows.Count > 0)
                                {
                                    DataRow dr = source.Tables[0].Rows[0];

                                    if ((dr["FILE_DATA"]) != System.DBNull.Value)
                                    {
                                        byte[] _FILE_DATA = null;
                                        _FILE_DATA = (byte[])(dr["FILE_DATA"]);

                                        string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["FILE_NAME"].ToString();
                                        System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                                        TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                                        TEMP_FILE.Close();
                                        TEMP_FILE.Dispose();

                                        System.Diagnostics.Process.Start(FILE_NAME);
                                    }
                                }
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk02_ALL_PARTNO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk02_ALL_PARTNO.Checked == true)
            {
                this.txt02_ALCCD.Visible = true;
                this.lbl02_ALC.Visible = true;
            }
            else
            {
                this.txt02_ALCCD.Visible = false;
                this.lbl02_ALC.Visible = false;
            }
            this.txt02_ALCCD.SetValue("");
        }

        private void btn02_ADD_Click(object sender, EventArgs e)
        {
            if (!IsINValid()) return;

            int Row = 0;
            if (this.txt02_SEQ.GetValue().ToString() != "")
            {
                Row = int.Parse(this.txt02_SEQ.GetValue().ToString());
                this.grd02_QA20511.SetValue(Row, 0, "U");
            }
            else
            {
                Row = grd02_QA20511.Rows.Count;
                this.grd02_QA20511.Rows.Add();
                this.grd02_QA20511.SetValue(Row, 0, "N");
            }

            this.grd02_QA20511.SetValue(Row, "CORCD", _CORCD);
            this.grd02_QA20511.SetValue(Row, "BIZCD", this.cbo02_BIZCD.GetValue());
            this.grd02_QA20511.SetValue(Row, "FILENO", this.txt02_FILENO.GetValue());
            this.grd02_QA20511.SetValue(Row, "AUDIT_TYPE", this.cbo02_AUDIT_TYPE.GetValue());
            this.grd02_QA20511.SetValue(Row, "AUDIT_TYPENM", this.cbo02_AUDIT_TYPE.GetText());
            this.grd02_QA20511.SetValue(Row, "PPT_DATE", this.dte02_PPT_DATE.GetDateText());
            this.grd02_QA20511.SetValue(Row, "SEQ", Row);
            this.grd02_QA20511.SetValue(Row, "DEF_PLACECD", this.cbo02_DEF_PLACECD.GetValue());
            this.grd02_QA20511.SetValue(Row, "DEF_PLACENM", this.cbo02_DEF_PLACECD.GetText());
            this.grd02_QA20511.SetValue(Row, "VENDCD", this.cdx02_VENDCD.GetValue());
            this.grd02_QA20511.SetValue(Row, "VENDNM", this.cdx02_VENDCD.GetText());
            this.grd02_QA20511.SetValue(Row, "PARTNO", this.cdx02_PARTNO.GetValue());
            this.grd02_QA20511.SetValue(Row, "PARTNM", this.cdx02_PARTNO.GetText());
            this.grd02_QA20511.SetValue(Row, "DEF_QTY", this.nme02_DEF_QTY.GetValue());
            this.grd02_QA20511.SetValue(Row, "DEFCD", this.cdx02_DEFCD.GetValue());
            this.grd02_QA20511.SetValue(Row, "DEFNM", this.cdx02_DEFCD.GetText());
            this.grd02_QA20511.SetValue(Row, "DEFPOSCD", this.cdx02_DEFPOSCD.GetValue());
            this.grd02_QA20511.SetValue(Row, "DEFPOSNM", this.cdx02_DEFPOSCD.GetText());
            this.grd02_QA20511.SetValue(Row, "MGRT_CNTTCD", this.cbo02_MGRT_CNTTCD.GetValue());
            this.grd02_QA20511.SetValue(Row, "MGRT_CNTTNM", this.cbo02_MGRT_CNTTCD.GetText());
            this.grd02_QA20511.SetValue(Row, "VER_4M_TYPE", this.cbo02_VER_4M_TYPE.GetValue());
            
            this.grd02_QA20511.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
            CellRange cr = new CellRange();
            cr = grd02_QA20511.GetCellRange(Row, grd02_QA20511.Cols.Fixed, Row, grd02_QA20511.Cols.Count - grd02_QA20511.Cols.Fixed);
            cr.Style = grd02_QA20511.Styles["COLOR_B"];

            if(this.GetByteCount(this.txt02_SEQ.GetValue().ToString()) == 0)
            {
                this.btn02_CLEAR_Click(null, null);
            }
        }

        private void btn02_REMOVE_Click(object sender, EventArgs e)
        {
            if (!IsOUTValid()) return;

            int Row = int.Parse(this.txt02_SEQ.GetValue().ToString());

            this.grd02_QA20511.SetValue(Row, 0, "D");

            this.grd02_QA20511.Styles.Add("COLOR_R").BackColor = Color.FromArgb(255, 200, 200);
            CellRange cr = new CellRange();
            cr = grd02_QA20511.GetCellRange(Row, grd02_QA20511.Cols.Fixed, Row, grd02_QA20511.Cols.Count - grd02_QA20511.Cols.Fixed);
            cr.Style = grd02_QA20511.Styles["COLOR_R"];
        }
        
        private void btn02_CLEAR_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in groupBox_main_Sub.Controls)
            {
                if (ctl is IAxControl)
                {
                    ((IAxControl)ctl).Initialize();
                }
            }

            this.txt02_SEQ.Initialize();
            this.dte02_PPT_DATE.Enabled = true;
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }
    
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source1, DataSet source2, DataSet source3)
        {
            try
            {
                if (source1.Tables[0].Rows.Count + source2.Tables[0].Rows.Count + source3.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("변경된 데이터가 없습니다.");
                    MsgCodeBox.Show("QA01-0021");
                    return false;
                }

                for (int i = 0; i < source2.Tables[0].Rows.Count; i++)
                {
                    if (((byte[])source2.Tables[0].Rows[i]["$FILE_DATA"]).Length > 15000000)
                    {
                        //MsgBox.Show("[" + source2.Tables[0].Rows[i]["FILE_NAME"].ToString() + "] 파일이 허용용량(15000 KBytes)을 초과 하였습니다. ");
                        MsgCodeBox.ShowFormat("QA01-0029", source2.Tables[0].Rows[i]["FILE_NAME"].ToString());
                        return false;
                    }
                }

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
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

        private bool IsRemoveValid(DataSet source)
        {
            try
            {
                string FILENO = this.txt02_FILENO.GetValue().ToString();

                if (this.GetByteCount(FILENO) == 0)
                {
                    //MsgBox.Show("선택된 데이터가 없습니다.");
                    MsgCodeBox.Show("QA01-0030");
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

        private bool IsINValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string PPT_DATE = this.dte02_PPT_DATE.GetDateText().ToString();
                string AUDIT_TYPE = this.cbo02_AUDIT_TYPE.GetValue().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));                    
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(PPT_DATE) == 0)
                {
                    //MsgBox.Show("발표일자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_PPT_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(AUDIT_TYPE) == 0)
                {
                    //MsgBox.Show("업무유형이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_JOB_TYPE.Text);
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("협력사가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_COOPER_NM.Text);
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

        private bool IsOUTValid()
        {
            try
            {
                string SEQ = this.txt02_SEQ.GetValue().ToString();

                if (this.GetByteCount(SEQ) == 0)
                {
                    //MsgBox.Show("데이터를 선택 하지 않았습니다.");
                    MsgCodeBox.Show("QA01-0030");
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
        
        #region [ 사용자 정의 메서드 ]

        private byte[] FILE_OPEN(string FILE_NAME)
        {
            FileStream fs = null;

            try
            {
                if (System.IO.File.Exists(FILE_NAME))
                {
                    fs = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.Read);
                    byte[] FILE_DATE = new byte[(int)fs.Length];
                    fs.Read(FILE_DATE, 0, FILE_DATE.Length);
                    fs.Close();

                    return FILE_DATE;
                }
                else
                {
                    return null;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void grd_SELECT(int Row)
        {
            try
            {
                string BIZCD = this.grd01_QA20511.GetValue(Row, "BIZCD").ToString();
                string FILENO = this.grd01_QA20511.GetValue(Row, "FILENO").ToString();
                this.txt02_FILENO.SetValue(FILENO);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PPT_DATE_FROM", "");
                paramSet.Add("PPT_DATE_TO", "");
                paramSet.Add("VENDCD", "");
                paramSet.Add("AUDIT_TYPE", "");
                paramSet.Add("VINCD", "");
                paramSet.Add("FILENO", FILENO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("GUBN", "");

                HEParameterSet paramSet_FILE_VIEW = new HEParameterSet();
                paramSet_FILE_VIEW.Add("CORCD", _CORCD);
                paramSet_FILE_VIEW.Add("BIZCD", BIZCD);
                paramSet_FILE_VIEW.Add("FILENO", FILENO);
                paramSet_FILE_VIEW.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
                this.grd02_QA20511.SetValue(source);

                //DataSet source_FILE_VIEW = _WSCOM.Inquery_FILE_VIEW(paramSet_FILE_VIEW);
                DataSet source_FILE_VIEW = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_FILE_VIEW"), paramSet_FILE_VIEW);

                this.AfterInvokeServer();

                this.grd03_QA20511.InitializeDataSource();
                this.QA20511_Rows_Add(FILENO);

                for (int i = 0; i < source_FILE_VIEW.Tables[0].Rows.Count; i++)
                {
                    int SEQ_CNT = int.Parse(source_FILE_VIEW.Tables[0].Rows[i]["FILE_SEQ"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "CORCD", source_FILE_VIEW.Tables[0].Rows[i]["CORCD"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "BIZCD", source_FILE_VIEW.Tables[0].Rows[i]["BIZCD"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "FILENO", source_FILE_VIEW.Tables[0].Rows[i]["FILENO"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "FILE_PATH", source_FILE_VIEW.Tables[0].Rows[i]["FILE_PATH"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "FILE_NAME", source_FILE_VIEW.Tables[0].Rows[i]["FILE_NAME"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "FILE_SIZE", ((Decimal)source_FILE_VIEW.Tables[0].Rows[i]["FILE_SIZE"]).ToString("#,##0"));
                    this.grd03_QA20511.SetValue(SEQ_CNT, "FILE_FIND", source_FILE_VIEW.Tables[0].Rows[i]["FILE_FIND"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, "FILE_REMOVE", source_FILE_VIEW.Tables[0].Rows[i]["FILE_REMOVE"].ToString());
                    this.grd03_QA20511.SetValue(SEQ_CNT, 0, SEQ_CNT);
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

        private void cdx_SETTING()
        {
            try
            {
                this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("VENDCD", this.cdx02_VENDCD.GetValue().ToString());
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void QA20511_Rows_Add(string FILENO)
        {

            for (int i = 1; i <= 5; i++)
            {
                this.grd03_QA20511.Rows.Add();
                this.grd03_QA20511.SetValue(i, "CORCD", _CORCD);
                this.grd03_QA20511.SetValue(i, "BIZCD", this.cbo02_BIZCD.GetValue());
                this.grd03_QA20511.SetValue(i, "FILENO", FILENO);
                this.grd03_QA20511.SetValue(i, "FILE_FIND", this.GetLabel("FILE_FIND"));//"찾아보기");
                this.grd03_QA20511.SetValue(i, "FILE_REMOVE", this.GetLabel("AFILE_DATA1_DELETE"));//"제거");
                this.grd03_QA20511.SetValue(i, 0, i);
            }
        }
        
        #endregion

    }
}
