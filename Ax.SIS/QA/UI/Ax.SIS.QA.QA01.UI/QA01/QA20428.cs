#region ▶ Description & History
/* 
 * 프로그램명 : QA20428 자체 Claim 등록
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
    /// <b>자체 Claim 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20428 : AxCommonBaseControl
    {
        //private IQA20428 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;

        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_QA20428";
        private string PACKAGE_NAME_INQUERY = "APG_QAINQUERY";
        private string PACKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20428()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20428>("QA01", "QA20428.svc", "CustomBinding");

            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");

            _WSCOM_N = new AxClientProxy();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox4.Text = this.GetLabel("QA20428_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20428_MSG2");  
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

                HEParameterSet paramSet_OCCUR_DIV = new HEParameterSet();
                paramSet_OCCUR_DIV.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source_OCCUR_DIV = _WSCOMBOBOX.Inquery_OCCUR_DIV(paramSet_OCCUR_DIV);
                DataSet source_OCCUR_DIV = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_COMBOBOX, "INQUERY_OCCUR_DIV"), paramSet_OCCUR_DIV);

                this.AfterInvokeServer();

                this.cbo01_OCCUR_DIV.DataBind(source_OCCUR_DIV.Tables[0], true);
                this.cbo01_OCCUR_DIV.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_OCCUR_DIV.DataBind(source_OCCUR_DIV.Tables[0], false);
                this.cbo02_OCCUR_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet source_XD0411 = this.GetTypeCode("FX", "A3", "A7");
                this.cbo02_MGRT_CNTT_DIV.DataBind(source_XD0411.Tables[0], true);
                this.cbo02_MGRT_CNTT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");// "귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

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

                this.cdx02_INSPECT_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_INSPECT_EMPNO.PopupTitle = this.GetLabel("INSPECT_CD");//"검사원코드";
                this.cdx02_INSPECT_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_INSPECT_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_ALCCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ALCCD.PopupTitle = "ALC CODE";
                this.cdx02_ALCCD.CodeParameterName = "ALCCD_OF_VINCD";
                this.cdx02_ALCCD.NameParameterName = "ALCCD_OF_VINNM";
                this.cdx02_ALCCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ALCCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("RCV_DATE", "");
                this.cdx02_ALCCD.HEParameterAdd("VINCD", "");
                this.cdx02_ALCCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_ASSYNO.HEPopupHelper = new QASubWindow();
                this.cdx02_ASSYNO.PopupTitle = this.GetLabel("ASSYPNO");//"완제품코드";
                this.cdx02_ASSYNO.CodeParameterName = "ASSYNO_OF_ALCCD";
                this.cdx02_ASSYNO.NameParameterName = "ASSYNO_OF_ALCNM";
                this.cdx02_ASSYNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ASSYNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYNO.HEParameterAdd("RCV_DATE", "");
                this.cdx02_ASSYNO.HEParameterAdd("ALCCD", "");
                this.cdx02_ASSYNO.HEParameterAdd("VINCD", "");
                this.cdx02_ASSYNO.HEParameterAdd("ITEMCD", "");
                this.cdx02_ASSYNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = this.GetLabel("PART_CODE");//"부품코드";
                this.cdx02_PARTNO.CodeParameterName = "PARTNO_OF_ASSYPNO";
                this.cdx02_PARTNO.NameParameterName = "PARTNO_OF_ASSYPNM";
                this.cdx02_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_PARTNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEParameterAdd("ASSYPNO", "");
                this.cdx02_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.pic02_DOCUMENT.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_DOCUMENT2.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01_QA20428.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd01_QA20428.AllowEditing = false;
                this.grd01_QA20428.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20428.Initialize(1, 1);
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발행번호", "OCCURNO", "OCCURNO");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "발생구분", "OCCUR_DIV", "OCCUR_DIV");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "발생구분", "OCCUR_DIVNM", "OCCUR_DIV");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "귀책업체", "VENDCD","IMPUT_VENDCD");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "완제품", "ASSY_PNO", "ASSYPNO");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "부품품번", "PARTNO", "PARTNO");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "불량유형", "DEFCD", "DEFCD");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "불량유형", "DEFNM", "DEFNM");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 40, "불량부위", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 60, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 20, "조치현황", "MGRT_CNTT_DIV", "MGRT_CNTT_DIV");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "조치현황", "MGRT_CNTT_DIVNM", "MGRT_CNTT_DIV");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기비용", "DEF_AMT", "DIS_AMOUNT");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "공수비용", "WORK_AMT", "WORK_AMT");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "합계금액", "SUMTOT", "TOTAL_AMT");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "업체확인서1", "DOCUMENT_NAME", "DOCUMENT_NAME");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "업체확인서2", "DOCUMENT_NAME2", "DOCUMENT_NAME2");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "작업자코드", "INSPECT_EMPNO", "WORK_EMPNO");
                this.grd01_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "작업자", "INSPECT_EMPNM", "WORK_EMPNO");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "작성일자", "DOC_DATE", "WRITE_DATE");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "발생시작일자", "OCCUR_BEG_DATE", "OCCUR_BEG_DATE");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "발생종료일자", "OCCUR_END_DATE", "OCCUR_END_DATE");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "LOTNO_FROM", "LOTNO_FROM");
                this.grd01_QA20428.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "LOTNO_TO", "LOTNO_TO");

                this.grd01_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd01_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_AMT");
                this.grd01_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_QA20428.AddMerge(0, 0, "VENDCD", "VENDNM");
                this.grd01_QA20428.AddMerge(0, 0, "DEFCD", "DEFNM");
                this.grd01_QA20428.AddMerge(0, 0, "DEFPOSCD", "DEFPOSNM");
                this.grd01_QA20428.AddMerge(0, 0, "MGRT_CNTT_DIV", "MGRT_CNTT_DIVNM");

                this.grd01_QA20428.SetHeadTitle(0, "VENDCD", this.GetLabel("IMPUT_VENDNM"));//"귀책업체");
                this.grd01_QA20428.SetHeadTitle(0, "DEFCD", this.GetLabel("DEF_TYPE"));//"불량유형");
                this.grd01_QA20428.SetHeadTitle(0, "DEFPOSCD", this.GetLabel("DEFPOSNM"));//"불량부위");
                this.grd01_QA20428.SetHeadTitle(0, "MGRT_CNTT_DIV", this.GetLabel("MGRT_CNTT_DIV"));//"조치현황");

                this.grd02_QA20428.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd02_QA20428.AllowEditing = true;
                this.grd02_QA20428.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20428.Initialize(2, 2);
                this.grd02_QA20428.AllowSorting = AllowSortingEnum.None;
                this.grd02_QA20428.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20428.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20428.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "발행번호", "OCCURNO", "OCCURNO");
                this.grd02_QA20428.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "순번", "OCCUR_SEQ", "SEQ_NO");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "불량세부내역", "DEF_DET_DESC", "DEF_DET_DESC");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "완제품정보", "ASSY_PNO", "ASSYPNO");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "완제품정보", "ASSY_PNM", "ASSYPNO");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "부품정보", "PARTNO", "PARTNO");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "부품정보", "PARTNM", "PARTNM");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "단가", "PART_UCOST", "PART_UCOST");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기수량", "DIS_QTY", "DIS_QTY");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기비용", "DIS_AMOUNT", "DIS_AMOUNT");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "선별수량", "WORK_QTY", "FETCH_QTY");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "인원", "WORK_PERSON", "PERSON");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "시간", "WORK_TIME", "TIME");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "임율", "WAGE_AMT", "WAGE_AMT");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "공수투입비용", "MAN_AMOUNT", "MAN_AMOUNT");
                this.grd02_QA20428.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "합계금액", "TOT_AMOUNT", "TOTAL_AMT");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_XD0411.Tables[1], "VINCD");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_XD0411.Tables[2], "INSTALL_POS");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_UCOST");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_QTY");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMOUNT");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_QTY");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_PERSON");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_TIME");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_AMT");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAN_AMOUNT");
                this.grd02_QA20428.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_AMOUNT");
                this.grd02_QA20428.Cols["PART_UCOST"].Format = "#,##0.0";
                this.grd02_QA20428.Cols["WAGE_AMT"].Format = "#,##0.0";
                this.grd02_QA20428.Cols["WORK_TIME"].Format = "#,##0.0";

                this.grd02_QA20428.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd02_QA20428.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd02_QA20428.AddMerge(0, 1, "OCCURNO", "OCCURNO");
                this.grd02_QA20428.AddMerge(0, 1, "OCCUR_SEQ", "OCCUR_SEQ");
                this.grd02_QA20428.AddMerge(0, 1, "DEF_DET_DESC", "DEF_DET_DESC");
                this.grd02_QA20428.AddMerge(0, 1, "WORK_DATE", "WORK_DATE");

                this.grd02_QA20428.AddMerge(0, 0, "VINCD", "DIS_AMOUNT");
                this.grd02_QA20428.AddMerge(0, 0, "WORK_QTY", "MAN_AMOUNT");

                this.grd02_QA20428.AddMerge(1, 1, "ASSY_PNO", "ASSY_PNM");
                this.grd02_QA20428.AddMerge(1, 1, "PARTNO", "PARTNM");

                this.grd02_QA20428.AddMerge(0, 1, "TOT_AMOUNT", "TOT_AMOUNT");

                this.grd02_QA20428.SetHeadTitle(0, "CORCD", this.GetLabel("CORCD"));//"법인코드");
                this.grd02_QA20428.SetHeadTitle(0, "BIZCD", this.GetLabel("BIZCD"));//"사업장코드");
                this.grd02_QA20428.SetHeadTitle(0, "OCCURNO", this.GetLabel("OCCURNO"));//"발행번호");
                this.grd02_QA20428.SetHeadTitle(0, "OCCUR_SEQ", this.GetLabel("SEQ_NO"));//"순번");
                this.grd02_QA20428.SetHeadTitle(0, "DEF_DET_DESC", this.GetLabel("DEF_DET_DESC"));//"불량세부내역");
                this.grd02_QA20428.SetHeadTitle(0, "WORK_DATE", this.GetLabel("WORK_DATE"));//"작업일자");

                this.grd02_QA20428.SetHeadTitle(0, "VINCD", this.GetLabel("ASSY_PART_DIS_AMT"));//"완제품/부품 폐기비용");
                this.grd02_QA20428.SetHeadTitle(1, "VINCD", this.GetLabel("VIN"));//"차종");
                this.grd02_QA20428.SetHeadTitle(1, "ALCCD", "ALC");
                this.grd02_QA20428.SetHeadTitle(1, "ASSY_PNO", this.GetLabel("ASSYPNO"));//"완제품정보");
                this.grd02_QA20428.SetHeadTitle(1, "INSTALL_POS", this.GetLabel("INSTALL_POS"));//"위치");
                this.grd02_QA20428.SetHeadTitle(1, "PARTNO", this.GetLabel("PARTNO"));//"부품정보");
                this.grd02_QA20428.SetHeadTitle(1, "PART_UCOST", this.GetLabel("PART_UCOST"));//"단가");
                this.grd02_QA20428.SetHeadTitle(1, "DIS_QTY", this.GetLabel("DIS_QTY"));//"폐기수량");
                this.grd02_QA20428.SetHeadTitle(1, "DIS_AMOUNT", this.GetLabel("DIS_AMOUNT"));//"폐기비용");

                this.grd02_QA20428.SetHeadTitle(0, "WORK_QTY", this.GetLabel("AMD_FETCH_WORK_RATE"));//"수정/선별 공수투입 비율");
                this.grd02_QA20428.SetHeadTitle(1, "WORK_QTY", this.GetLabel("FETCH_QTY"));//"선별수량");
                this.grd02_QA20428.SetHeadTitle(1, "DEF_QTY", this.GetLabel("DEF_QTY"));//"불량수량");
                this.grd02_QA20428.SetHeadTitle(1, "WORK_PERSON", this.GetLabel("PERSON"));//"인원");
                this.grd02_QA20428.SetHeadTitle(1, "WORK_TIME", this.GetLabel("TIME"));//"시간");
                this.grd02_QA20428.SetHeadTitle(1, "WAGE_AMT", this.GetLabel("WAGE_AMT"));//"임율");
                this.grd02_QA20428.SetHeadTitle(1, "MAN_AMOUNT", this.GetLabel("MAN_AMOUNT"));//"공수투입비용");

                this.grd02_QA20428.SetHeadTitle(0, "TOT_AMOUNT", this.GetLabel("TOTAL_AMT"));//"합계금액");

                this.SetRequired(lbl01_BIZNM, lbl01_WRITE_DATE, lbl02_BIZNM, lbl02_IMPUT_VENDNM, lbl02_OCCUR_DIV, lbl02_WRITE_DATE, lbl02_MGRT_CNTT_DIV);


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                this.grd02_QA20428_VIEW(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
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
                this.pic02_DOCUMENT.Initialize();
                this.pic02_DOCUMENT2.Initialize();
                this.grd02_QA20428.InitializeDataSource();
                this.nme02_SUMTOT.SetValue("0");

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.cdx02_VENDCD.Enabled = true;
                this.cbo02_OCCUR_DIV.Enabled = true;
                this.dte02_DOC_DATE.Enabled = true;
                this.cbo02_MGRT_CNTT_DIV.Enabled = true;

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
                string DOC_DATE = this.dte01_DOC_DATE.GetDateText().ToString();
                string OCCUR_DIV = this.cbo01_OCCUR_DIV.GetValue().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string OCCURNO = this.txt01_OCCURNO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DOC_DATE", DOC_DATE);
                paramSet.Add("OCCUR_DIV", OCCUR_DIV);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("OCCURNO", OCCURNO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA4020(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_AQA4020"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20428.SetValue(source);
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



                //APG_QA20428.SAVE_AQA4020 용(헤더)
                DataSet paramSet = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "OCCURNO", "OCCUR_DIV", "VENDCD", "OCCUR_BEG_DATE",
                    "OCCUR_END_DATE", "DEFCD", "DEFPOSCD", "SUMTOT", "DOC_DATE", 
                    "LOTNO_FROM", "LOTNO_TO", "MGRT_CNTT_DIV", "INSPECT_EMPNO", "PLANT_DIV");
                paramSet.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_OCCURNO.GetValue(),
                    this.cbo02_OCCUR_DIV.GetValue(),
                    this.cdx02_VENDCD.GetValue(),
                    this.dte02_OCCUR_BEG_DATE.GetDateText(),
                    this.dte02_OCCUR_END_DATE.GetDateText(),
                    this.cdx02_DEFCD.GetValue(),
                    this.cdx02_DEFPOSCD.GetValue(),
                    this.nme02_SUMTOT.GetDBValue(),
                    this.dte02_DOC_DATE.GetDateText(),
                    this.dte02_LOTNO_FROM.GetDateText(),
                    this.dte02_LOTNO_TO.GetDateText(),
                    this.cbo02_MGRT_CNTT_DIV.GetValue(),
                    this.cdx02_INSPECT_EMPNO.GetValue(),
                    this.cbo01_PLANT_DIV.GetValue());

                //APG_QA20428.SAVE_IMAGE 용(이미지)
                DataSet source_IMAGE = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "OCCURNO", "BLOB$DOCUMENT", "BLOB$DOCUMENT2", "LANG_SET");
                source_IMAGE.Tables[0].Rows.Add(
                    _CORCD,                                     
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_OCCURNO.GetValue(),                                    
                    this.pic02_DOCUMENT.GetValue(),             
                    this.pic02_DOCUMENT2.GetValue(),
                    this._LANG_SET
                );

                for (int i = this.grd02_QA20428.Rows.Count - 1; i >= this.grd02_QA20428.Rows.Fixed; i--)
                {
                    if (this.grd02_QA20428.GetValue(i, 0).ToString() == "D")
                    {
                        this.grd02_QA20428.Rows.Remove(i); 
                    }
                }

                //APG_QA20428.SAVE_AQA4021 용(디테일)
                DataSet save_QA4021 = this.grd02_QA20428.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD", "OCCURNO", "OCCUR_SEQ", "DEF_DET_DESC",
                    "WORK_DATE", "VINCD", "ALCCD", "ASSY_PNO", "INSTALL_POS",
                    "PARTNO", "PART_UCOST", "DIS_QTY", "DIS_AMOUNT", "WORK_QTY", 
                    "DEF_QTY", "WORK_PERSON", "WORK_TIME", "WAGE_AMT", "MAN_AMOUNT", 
                    "TOT_AMOUNT");

                for (int i = 0; i < save_QA4021.Tables[0].Rows.Count; i++)
                {
                    save_QA4021.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    save_QA4021.Tables[0].Rows[i]["BIZCD"] = this.cbo02_BIZCD.GetValue();
                    save_QA4021.Tables[0].Rows[i]["OCCUR_SEQ"] = i + 1;
                }

                //APG_QA20428.SAVE_OCCURNO, REMOVE_OCCURNO 용
                HEParameterSet setPK = new HEParameterSet();
                setPK.Add("CORCD", _CORCD);
                setPK.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                setPK.Add("OCCURNO", this.txt02_OCCURNO.GetValue());
                setPK.Add("DOC_DATE", this.dte02_DOC_DATE.GetDateText());

                //APG_QA20428.REMOVE_AQA4021 용 (디테일삭제)
                DataSet remove_QA4021 = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "OCCURNO");
                remove_QA4021.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_OCCURNO.GetValue());


                if (!IsSaveValid(save_QA4021)) return;

                this.BeforeInvokeServer(true);


                //_WSCOM.Save(paramSet, source_IMAGE, source_QA4021);
                //AQA4020, AQA4021
                //PK값 먼저 저장 처리
                DataSet source = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_OCCURNO"), setPK);
                string OCCURNO = source.Tables[0].Rows[0][0].ToString();

                //채번된 DPTNO값 넣어주기
                paramSet.Tables[0].Rows[0]["OCCURNO"] = OCCURNO;
                source_IMAGE.Tables[0].Rows[0]["OCCURNO"] = OCCURNO;
                foreach (DataRow dr in save_QA4021.Tables[0].Rows)
                {
                    dr["OCCURNO"] = OCCURNO;
                }
                setPK["OCCURNO"] = OCCURNO;
                remove_QA4021.Tables[0].Rows[0]["OCCURNO"] = OCCURNO;

                try
                {
                    //transaction 저장처리
                    _WSCOM_N.MultipleExecuteNonQueryTx(new string[] {string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_AQA4020"),
                                                                    string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_IMAGE"),
                                                                    string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_AQA4021"),
                                                                    string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_AQA4021")},
                                                       new DataSet[] { paramSet, source_IMAGE, remove_QA4021, save_QA4021 });

                }
                catch (Exception ex)
                { 
                    if (this.txt02_OCCURNO.IsEmpty)
                        _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_OCCURNO"), setPK);

                    throw ex;
                }

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("자체 Claim 등록이 저장 되었습니다.");
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

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "OCCURNO");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_OCCURNO.GetValue()
                );

                if (!IsDeleteValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("자체 Claim 등록이 삭제 되었습니다.");
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

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void grd01_QA20428_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20428.SelectedRowIndex;

                if (Row >= this.grd01_QA20428.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20428.GetValue(Row, "BIZCD").ToString();
                    string OCCUR_DIV = this.grd01_QA20428.GetValue(Row, "OCCUR_DIV").ToString();
                    string DOC_DATE = this.grd01_QA20428.GetValue(Row, "DOC_DATE").ToString();
                    string DEFCD = this.grd01_QA20428.GetValue(Row, "DEFCD").ToString();
                    string DEFPOSCD = this.grd01_QA20428.GetValue(Row, "DEFPOSCD").ToString();
                    string OCCURNO = this.grd01_QA20428.GetValue(Row, "OCCURNO").ToString();
                    string OCCUR_BEG_DATE = this.grd01_QA20428.GetValue(Row, "OCCUR_BEG_DATE").ToString();
                    string OCCUR_END_DATE = this.grd01_QA20428.GetValue(Row, "OCCUR_END_DATE").ToString();
                    string VENDCD = this.grd01_QA20428.GetValue(Row, "VENDCD").ToString();
                    string INSPECT_EMPNO = this.grd01_QA20428.GetValue(Row, "INSPECT_EMPNO").ToString();
                    string MGRT_CNTT_DIV = this.grd01_QA20428.GetValue(Row, "MGRT_CNTT_DIV").ToString();
                    string LOTNO_FROM = this.grd01_QA20428.GetValue(Row, "LOTNO_FROM").ToString();
                    string LOTNO_TO = this.grd01_QA20428.GetValue(Row, "LOTNO_TO").ToString();
                    string SUMTOT = this.grd01_QA20428.GetValue(Row, "SUMTOT").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.cbo02_OCCUR_DIV.SetValue(OCCUR_DIV);
                    this.dte02_DOC_DATE.SetValue(DOC_DATE);
                    this.cdx02_DEFCD.SetValue(DEFCD);
                    this.txt02_OCCURNO.SetValue(OCCURNO);
                    this.dte02_OCCUR_BEG_DATE.SetValue(OCCUR_BEG_DATE);
                    this.dte02_OCCUR_END_DATE.SetValue(OCCUR_END_DATE);
                    this.cdx02_VENDCD.SetValue(VENDCD);
                    this.cdx02_INSPECT_EMPNO.SetValue(INSPECT_EMPNO);
                    this.cdx02_DEFPOSCD.SetValue(DEFPOSCD);
                    this.cbo02_MGRT_CNTT_DIV.SetValue(MGRT_CNTT_DIV);
                    this.dte02_LOTNO_FROM.SetValue(LOTNO_FROM);
                    this.dte02_LOTNO_TO.SetValue(LOTNO_TO);
                    this.nme02_SUMTOT.SetValue(SUMTOT);

                    this.IMAGE_VIEW(BIZCD, OCCURNO);
                    this.grd02_QA20428_VIEW(BIZCD, OCCURNO);

                    this.cbo02_BIZCD.Enabled = false;
                    this.cdx02_VENDCD.Enabled = false;
                    this.cbo02_OCCUR_DIV.Enabled = false;
                    this.dte02_DOC_DATE.Enabled = false;
                    this.cbo02_MGRT_CNTT_DIV.Enabled = false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_DOCUMENT_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT, 0, _DOCUMENT.Length);
                    fs.Close();

                    this.pic02_DOCUMENT.SetValue(_DOCUMENT);
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

        private void btn01_DOCUMENT_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_DOCUMENT.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_DOCUMENT2_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT2 = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT2, 0, _DOCUMENT2.Length);
                    fs.Close();

                    this.pic02_DOCUMENT2.SetValue(_DOCUMENT2);
                }
                else
                {
                    this.pic02_DOCUMENT2.Initialize();
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

        private void btn01_DOCUMENT2_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_DOCUMENT2.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_ALCCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.grd02_QA20428_CODEBOX(cdx02_ALCCD, "ALCCD", "");
        }

        private void cdx02_ASSYNO_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                this.grd02_QA20428_CODEBOX(cdx02_ASSYNO, "ASSY_PNO", "ASSY_PNM");

                int iROW = this.grd02_QA20428.Row;

                HEParameterSet paramSet_UCOST_ASSYNO = new HEParameterSet();
                paramSet_UCOST_ASSYNO.Add("CORCD", _CORCD);
                paramSet_UCOST_ASSYNO.Add("DATE", this.grd02_QA20428.GetValue(iROW, "WORK_DATE"));
                paramSet_UCOST_ASSYNO.Add("ASSYNO", this.cdx02_ASSYNO.GetValue());
                paramSet_UCOST_ASSYNO.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source_UCOST_ASSYNO = _WSINQUERY.Inquery_UCOST_ASSYNO(paramSet_UCOST_ASSYNO);
                DataSet source_UCOST_ASSYNO = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_INQUERY, "INQUERY_UCOST_ASSYNO"), paramSet_UCOST_ASSYNO);

                this.AfterInvokeServer();

                if (source_UCOST_ASSYNO.Tables[0].Rows.Count != 0)
                {

                    decimal PART_UCOST = Convert.ToDecimal(source_UCOST_ASSYNO.Tables[0].Rows[0]["UCOST"].ToString());
                    this.grd02_QA20428.SetValue(iROW, "PART_UCOST", string.Format("{0:###,###,###,###,###,##0}", PART_UCOST));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

        }

        private void cdx02_PARTNO_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                this.grd02_QA20428_CODEBOX(cdx02_PARTNO, "PARTNO", "PARTNM");

                int iROW = this.grd02_QA20428.Row;

                HEParameterSet paramSet_UCOST_PARTNO = new HEParameterSet();
                paramSet_UCOST_PARTNO.Add("CORCD", _CORCD);
                paramSet_UCOST_PARTNO.Add("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                paramSet_UCOST_PARTNO.Add("VENDCD", this.cdx02_VENDCD.GetValue().ToString());
                paramSet_UCOST_PARTNO.Add("DATE", this.grd02_QA20428.GetValue(iROW, "WORK_DATE"));
                paramSet_UCOST_PARTNO.Add("PARTNO", this.grd02_QA20428.GetValue(iROW, "PARTNO"));
                paramSet_UCOST_PARTNO.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source_UCOST_PARTNO = _WSINQUERY.Inquery_UCOST_PARTNO(paramSet_UCOST_PARTNO);
                DataSet source_UCOST_PARTNO = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_INQUERY, "INQUERY_UCOST_PARTNO"), paramSet_UCOST_PARTNO);

                this.AfterInvokeServer();

                if (source_UCOST_PARTNO.Tables[0].Rows.Count != 0)
                {
                    decimal PART_UCOST = Convert.ToDecimal(source_UCOST_PARTNO.Tables[0].Rows[0]["UCOST"].ToString());
                    this.grd02_QA20428.SetValue(iROW, "PART_UCOST", string.Format("{0:###,###,###,###,###,##0}", PART_UCOST));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

        }

        private void grd02_QA20428_BeforeEdit(object sender, RowColEventArgs e)
        {
            //먼저 입력해야하는 항목 체크 추가 2013-04-15 (배명희)
            if (CheckInputValidation(e.Row, e.Col) == false)
            {
                e.Cancel = true;
            }
        }

        private void grd02_QA20428_AfterEdit(object sender, RowColEventArgs e)
        {
            string sText = this.grd02_QA20428.GetData(e.Row, e.Col).ToString();
            this.grd02_QA20428_Code_SELECT(e.Row, e.Col, sText);

            this.grd_AUTO(e.Row, e.Col);
        }

        private void pic02_DOCUMENT_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_DOCUMENT.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_DOCUMENT.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_DOCUMENT2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_DOCUMENT2.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_DOCUMENT2.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
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

        private void cdx02_INSPECT_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
        }
        
        #endregion

        #region [ 사용자 정의 메서드 ]

        private void IMAGE_VIEW(string BIZCD, string OCCURNO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCURNO", OCCURNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                if ((dr["DOCUMENT"]) != System.DBNull.Value)
                {
                    byte[] _DOCUMENT = null;
                    _DOCUMENT = (byte[])(dr["DOCUMENT"]);
                    this.pic02_DOCUMENT.SetValue(_DOCUMENT);
                }

                if ((dr["DOCUMENT2"]) != System.DBNull.Value)
                {
                    byte[] _DOCUMENT2 = null;
                    _DOCUMENT2 = (byte[])(dr["DOCUMENT2"]);
                    this.pic02_DOCUMENT2.SetValue(_DOCUMENT2);
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

        private void grd02_QA20428_VIEW(string BIZCD, string OCCURNO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCURNO", OCCURNO);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA4021(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_AQA4021"), paramSet);

                this.AfterInvokeServer();

                this.grd02_QA20428.SetValue(source);
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
                this.cdx02_INSPECT_EMPNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //2013.04.15 완제품 품번 입력시 작업일자 입력여부 체크 추가 (배명희)
        //           차후 다른 항목도 체크해야할 수도 있을 것 같음.
        //           현재는 완제품 품번입력시 작업일자 입력여부만 체크함
        private bool CheckInputValidation(int iROW, int iCOL)
        {
            if (iROW > 0)
            {
                switch (this.grd02_QA20428.Cols[iCOL].Name.ToString().ToUpper().Trim())
                {
                    case "ALCCD":
                        
                       


                        break;
                    case "ASSY_PNO":
                       
                      
                        if (this.grd02_QA20428.GetValue(iROW, "WORK_DATE").ToString().Equals(string.Empty))
                        {
                            //MsgBox.Show("작업일자를 먼저 입력해 주시기 바랍니다.");]
                            MsgCodeBox.Show("QA01-0026");
                            this.grd02_QA20428.Col = this.grd02_QA20428.Cols["WORK_DATE"].Index;
                            return false;
                        }

                       
                        break;
                    case "PARTNO":
                      
                        break;
                    default:
                        break;
                }
            }

            return true;
        }

        private void grd02_QA20428_Code_SELECT(int iROW, int iCOL, string sText)
        {
            if (iROW > 0)
            {
                switch (this.grd02_QA20428.Cols[iCOL].Name.ToString().ToUpper().Trim())
                {
                    case "ALCCD":
                        this.cdx02_ALCCD.Initialize();
                        this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                        this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", this.grd02_QA20428.GetValue(iROW, "WORK_DATE"));
                        this.cdx02_ALCCD.HEUserParameterSetValue("VINCD", this.grd02_QA20428.GetValue(iROW, "VINCD"));
                        this.cdx02_ALCCD.SetValue(sText);

                        break;
                    case "ASSY_PNO":
                        this.cdx02_ASSYNO.Initialize();
                        this.cdx02_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                        this.cdx02_ASSYNO.HEUserParameterSetValue("RCV_DATE", this.grd02_QA20428.GetValue(iROW, "WORK_DATE"));
                        this.cdx02_ASSYNO.HEUserParameterSetValue("ALCCD", this.grd02_QA20428.GetValue(iROW, "ALCCD"));
                        this.cdx02_ASSYNO.HEUserParameterSetValue("VINCD", this.grd02_QA20428.GetValue(iROW, "VINCD"));
                        this.cdx02_ASSYNO.HEUserParameterSetValue("ITEMCD", "");
                        this.cdx02_ASSYNO.SetValue(sText);

                        if (sText == "")
                        {
                            this.POPUP(cdx02_ASSYNO);
                        }

                        break;
                    case "PARTNO":
                        this.cdx02_PARTNO.Initialize();
                        this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                        this.cdx02_PARTNO.HEUserParameterSetValue("ASSYPNO", this.grd02_QA20428.GetValue(iROW, "ASSY_PNO"));
                        this.cdx02_PARTNO.SetValue(sText);

                        if (sText == "")
                        {
                            this.POPUP(cdx02_PARTNO);
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        private void POPUP(AxCodeBox ctl)
        {
            ctl.HEPopupHelper.Initialize_Helper(ctl);
            PopupHelper helper = new PopupHelper((AxCommonPopupControl)ctl.HEPopupHelper, ctl.PopupTitle);

            helper.ShowDialog();

            object data = helper.SelectedValue;
            if (data != null)
            {
                DataRow _SelectedPopupValue = (DataRow)data;
                ctl.SetValue(_SelectedPopupValue[ctl.CodeParameterName]);
            }

        }

        private void grd02_QA20428_CODEBOX(AxCodeBox codebox, string sCOL1, string sCOL2)
        {
            int iROW = this.grd02_QA20428.Row;
            int iCOL = this.grd02_QA20428.Col;

            this.grd02_QA20428.SetValue(iROW, sCOL1, codebox.GetValue().ToString());

            if (sCOL2 != "")
            {
                this.grd02_QA20428.SetValue(iROW, sCOL2, codebox.GetText().ToString());
            }
        }

        private void grd_AUTO(int ROW, int COL)
        {
            try
            {
                switch (this.grd02_QA20428.Cols[COL].Name.ToString().ToUpper().Trim())
                {
                    case "WORK_DATE":
                        this.grd02_QA20428.SetValue(ROW, "VINCD", "");
                        this.grd02_QA20428.SetValue(ROW, "ALCCD", "");
                        this.grd02_QA20428.SetValue(ROW, "ASSY_PNO", "");
                        this.grd02_QA20428.SetValue(ROW, "ASSY_PNM", "");
                        this.grd02_QA20428.SetValue(ROW, "INSTALL_POS", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNO", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNM", "");

                        HEParameterSet paramSet_PAY_RATE = new HEParameterSet();
                        paramSet_PAY_RATE.Add("CORCD", _CORCD);
                        paramSet_PAY_RATE.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                        paramSet_PAY_RATE.Add("YYYY", this.grd02_QA20428.GetValue(ROW, "WORK_DATE").ToString().Substring(0, 4));
                        paramSet_PAY_RATE.Add("LANG_SET", this.UserInfo.Language);

                        this.BeforeInvokeServer(true);

                        //DataSet source_PAY_RATE = _WSINQUERY.Inquery_PAY_RATE(paramSet_PAY_RATE);
                        DataSet source_PAY_RATE = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_INQUERY, "INQUERY_PAY_RATE"), paramSet_PAY_RATE);

                        this.AfterInvokeServer();

                        if (source_PAY_RATE.Tables[0].Rows.Count != 0)
                        {

                            decimal PAY_RATE = Convert.ToDecimal(source_PAY_RATE.Tables[0].Rows[0]["PAY_RATE"].ToString());
                            this.grd02_QA20428.SetValue(ROW, "WAGE_AMT", string.Format("{0:###,###,###,###,###,##0.0}", PAY_RATE));
                        }

                        break;
                    case "VINCD":
                        this.grd02_QA20428.SetValue(ROW, "ALCCD", "");
                        this.grd02_QA20428.SetValue(ROW, "ASSY_PNO", "");
                        this.grd02_QA20428.SetValue(ROW, "ASSY_PNM", "");
                        this.grd02_QA20428.SetValue(ROW, "INSTALL_POS", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNO", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNM", "");

                        break;
                    case "ALCCD":
                        this.grd02_QA20428.SetValue(ROW, "ASSY_PNO", "");
                        this.grd02_QA20428.SetValue(ROW, "ASSY_PNM", "");
                        this.grd02_QA20428.SetValue(ROW, "INSTALL_POS", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNO", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNM", "");

                        break;
                    case "ASSY_PNO":
                        this.grd02_QA20428.SetValue(ROW, "INSTALL_POS", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNO", "");
                        this.grd02_QA20428.SetValue(ROW, "PARTNM", "");

                        break;
                    default:
                        break;
                }

                decimal PART_UCOST = Convert.ToDecimal(this.grd02_QA20428.GetValue(ROW, "PART_UCOST").ToString());
                decimal DIS_QTY = Convert.ToDecimal(this.grd02_QA20428.GetValue(ROW, "DIS_QTY").ToString());

                decimal WORK_QTY = Convert.ToDecimal(this.grd02_QA20428.GetValue(ROW, "WORK_QTY").ToString());
                decimal WORK_PERSON = Convert.ToDecimal(this.grd02_QA20428.GetValue(ROW, "WORK_PERSON").ToString());
                decimal WORK_TIME = Convert.ToDecimal(this.grd02_QA20428.GetValue(ROW, "WORK_TIME").ToString());
                decimal WAGE_AMT = Convert.ToDecimal(this.grd02_QA20428.GetValue(ROW, "WAGE_AMT").ToString());

                this.grd02_QA20428.SetValue(ROW, "DIS_AMOUNT", string.Format("{0:###,###,###,###,###,##0.0}", Math.Round(PART_UCOST * DIS_QTY, 0)));
                this.grd02_QA20428.SetValue(ROW, "MAN_AMOUNT", string.Format("{0:###,###,###,###,###,##0.0}", Math.Round(WORK_PERSON * WORK_TIME * WAGE_AMT, 0)));

                this.grd02_QA20428.SetValue(ROW, "TOT_AMOUNT", string.Format("{0:###,###,###,###,###,##0.0}", Math.Round(PART_UCOST * DIS_QTY, 0) + Math.Round(WORK_PERSON * WORK_TIME * WAGE_AMT, 0)));

                decimal SUMTOT = 0;
                for (int i = 2; i < this.grd02_QA20428.Rows.Count; i++)
                {
                    SUMTOT = SUMTOT + Convert.ToDecimal(this.grd02_QA20428.GetValue(i, "TOT_AMOUNT").ToString());
                }

                this.nme02_SUMTOT.SetValue(SUMTOT);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

        }

        #endregion
        
        #region [유효성 검사]

        private bool IsSaveValid(DataSet set)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string OCCUR_DIV = this.cbo02_OCCUR_DIV.GetValue().ToString();
                string DOC_DATE = this.dte02_DOC_DATE.GetDateText().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string MGRT_CNTT_DIV = this.cbo02_MGRT_CNTT_DIV.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(OCCUR_DIV) == 0)
                {
                    //MsgBox.Show("발생구분이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_OCCUR_DIV.Text);
                    return false;
                }

                if (this.GetByteCount(DOC_DATE) == 0)
                {
                    //MsgBox.Show("작성일자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_WRITE_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("귀책업체가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_IMPUT_VENDNM.Text);
                    return false;
                }

                if (this.GetByteCount(MGRT_CNTT_DIV) == 0)
                {
                    //MsgBox.Show("조치현황이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_MGRT_CNTT_DIV.Text);
                    return false;
                }

                if (this.grd02_QA20428.Rows.Count - 1 < 1)
                {
                    //MsgBox.Show("자체 Claim 리스트의 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    
                    return false;
                }

                Decimal TOT = 0;
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    TOT = TOT + Decimal.Parse(set.Tables[0].Rows[i]["TOT_AMOUNT"].ToString());
                }

                this.nme02_SUMTOT.SetValue(TOT);

                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    if (this.GetByteCount(set.Tables[0].Rows[i]["DEF_DET_DESC"].ToString()) == 0)
                    {
                        //MsgBox.Show("자체 Claim 리스트의 불량세부내역(" + set.Tables[0].Rows[i]["OCCUR_SEQ"].ToString() + "번째줄) 데이터가 존재하지 않습니다.");
                        MsgCodeBox.ShowFormat("QA01-0023", set.Tables[0].Rows[i]["OCCUR_SEQ"].ToString());
                        return false;
                    }

                    if (this.GetByteCount(set.Tables[0].Rows[i]["WORK_DATE"].ToString()) == 0)
                    {
                        //MsgBox.Show("자체 Claim 리스트의 작업일자(" + set.Tables[0].Rows[i]["OCCUR_SEQ"].ToString() + "번째줄) 데이터가 존재하지 않습니다.");
                        MsgCodeBox.ShowFormat("QA01-0024", set.Tables[0].Rows[i]["OCCUR_SEQ"].ToString());
                        return false;
                    }

                    if (this.GetByteCount(set.Tables[0].Rows[i]["VINCD"].ToString()) == 0)
                    {
                        //MsgBox.Show("자체 Claim 리스트의 차종(" + set.Tables[0].Rows[i]["OCCUR_SEQ"].ToString() + "번째줄) 데이터가 존재하지 않습니다.");
                        MsgCodeBox.ShowFormat("QA01-0025", set.Tables[0].Rows[i]["OCCUR_SEQ"].ToString());
                        return false;
                    }
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

        private bool IsDeleteValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string OCCURNO = this.txt02_OCCURNO.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(OCCURNO) == 0)
                {
                    //MsgBox.Show("선택한 데이터가 없습니다.");
                    MsgCodeBox.Show("QA00-009");
                    return false;
                }
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                
    }
}
