#region ▶ Description & History
/* 
 * 프로그램명 : QA20601 공정순회검사일보 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-29      배명희      통합WCF로 변경 
 *				2017-10-23      배명희      코드박스 (작성자) 사업장 파라메터 초기 설정값 주기
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
using System.IO;
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>공정 순회검사결과 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-08-24 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20601 : AxCommonBaseControl
    {
        //private IQA20601 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;
        private String _LANG_SET;
        private String CORCD_T;
        private String BIZCD_T;
        private String OCCUR_DATE_T;
        private String INSPECT_CLASSCD_T;
        private String PLANT_DIV_T;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20601";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [초기화 작업에 대한 정의]

        public QA20601()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20601>("QA02", "QA20601.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");


            CORCD_T = "";
            BIZCD_T = "";
            OCCUR_DATE_T = "";
            INSPECT_CLASSCD_T = "";
            PLANT_DIV_T = "";

            _WSCOM_N = new AxClientProxy();
        }

        public QA20601(string CORCD, string BIZCD, string OCCUR_DATE, string INSPECT_CLASSCD,  string PLANT_DIV)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20601>("QA02", "QA20601.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");


            CORCD_T = CORCD;
            BIZCD_T = BIZCD;
            OCCUR_DATE_T = OCCUR_DATE;
            INSPECT_CLASSCD_T = INSPECT_CLASSCD;
            PLANT_DIV_T = PLANT_DIV;

            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox1.Text = this.GetLabel("QA20601_MSG1");
                this.groupBox2.Text = this.GetLabel("QA20601_MSG2");
                this.groupBox4.Text = this.GetLabel("QA20601_MSG3");

                this.tabPage1.Text =this.GetLabel("QA20601_MSG4");
                this.tabPage2.Text = this.GetLabel("QA20601_MSG5");
                this.tabPage3.Text = this.GetLabel("QA20601_MSG6");

                btn01_ISSUE_PHOTO1_COMMIT.Text = this.GetLabel("INSPECT_STD_PHOTO_INSERT");
                btn01_ISSUE_PHOTO1_REMOVE.Text = this.GetLabel("INSPECT_STD_PHOTO_DELETE");

                btn01_ISSUE_PHOTO2_COMMIT.Text = this.GetLabel("INSPECT_STD_PHOTO_INSERT");
                btn01_ISSUE_PHOTO2_REMOVE.Text = this.GetLabel("INSPECT_STD_PHOTO_DELETE");

                btn01_ISSUE_PHOTO3_COMMIT.Text = this.GetLabel("INSPECT_STD_PHOTO_INSERT");
                btn01_ISSUE_PHOTO3_REMOVE.Text = this.GetLabel("INSPECT_STD_PHOTO_DELETE");

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

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }
                this.cbo01_BIZCD.SelectedValueChanged += new EventHandler(cbo01_BIZCD_SelectedValueChanged);
                //this.cdx01_DAY_WORKER.HEPopupHelper = new QASubWindow();
                //this.cdx01_DAY_WORKER.PopupTitle = this.GetLabel("EMPNO");// "사원코드";
                //this.cdx01_DAY_WORKER.CodeParameterName = "EMPNO";
                //this.cdx01_DAY_WORKER.NameParameterName = "EMPNONM";
                //this.cdx01_DAY_WORKER.HEParameterAdd("CORCD", _CORCD);
                //this.cdx01_DAY_WORKER.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx01_DAY_WORKER.HEPopupHelper = new QASubWindow();
                this.cdx01_DAY_WORKER.PopupTitle = this.GetLabel("EMPNO");
                this.cdx01_DAY_WORKER.CodeParameterName = "INSPECT_EMPNO";
                this.cdx01_DAY_WORKER.NameParameterName = "INSPECT_EMPNONM";
                this.cdx01_DAY_WORKER.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DAY_WORKER.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_DAY_WORKER.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                //this.cdx01_NIGHT_WORKER.HEPopupHelper = new QASubWindow();
                //this.cdx01_NIGHT_WORKER.PopupTitle = this.GetLabel("EMPNO");//"사원코드";
                //this.cdx01_NIGHT_WORKER.CodeParameterName = "EMPNO";
                //this.cdx01_NIGHT_WORKER.NameParameterName = "EMPNONM";
                //this.cdx01_NIGHT_WORKER.HEParameterAdd("CORCD", _CORCD);
                //this.cdx01_NIGHT_WORKER.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx01_NIGHT_WORKER.HEPopupHelper = new QASubWindow();
                this.cdx01_NIGHT_WORKER.PopupTitle = this.GetLabel("EMPNO");
                this.cdx01_NIGHT_WORKER.CodeParameterName = "INSPECT_EMPNO";
                this.cdx01_NIGHT_WORKER.NameParameterName = "INSPECT_EMPNONM";
                this.cdx01_NIGHT_WORKER.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_NIGHT_WORKER.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_NIGHT_WORKER.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx01_DAY_WORKER2.HEPopupHelper = new QASubWindow();
                //this.cdx01_DAY_WORKER2.PopupTitle = this.GetLabel("EMPNO");//"사원코드";
                //this.cdx01_DAY_WORKER2.CodeParameterName = "EMPNO";
                //this.cdx01_DAY_WORKER2.NameParameterName = "EMPNONM";
                //this.cdx01_DAY_WORKER2.HEParameterAdd("CORCD", _CORCD);
                //this.cdx01_DAY_WORKER2.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx01_DAY_WORKER2.HEPopupHelper = new QASubWindow();
                this.cdx01_DAY_WORKER2.PopupTitle = this.GetLabel("EMPNO");
                this.cdx01_DAY_WORKER2.CodeParameterName = "INSPECT_EMPNO";
                this.cdx01_DAY_WORKER2.NameParameterName = "INSPECT_EMPNONM";
                this.cdx01_DAY_WORKER2.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DAY_WORKER2.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_DAY_WORKER2.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx01_NIGHT_WORKER2.HEPopupHelper = new QASubWindow();
                //this.cdx01_NIGHT_WORKER2.PopupTitle = this.GetLabel("EMPNO");//"사원코드";
                //this.cdx01_NIGHT_WORKER2.CodeParameterName = "EMPNO";
                //this.cdx01_NIGHT_WORKER2.NameParameterName = "EMPNONM";
                //this.cdx01_NIGHT_WORKER2.HEParameterAdd("CORCD", _CORCD);
                //this.cdx01_NIGHT_WORKER2.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx01_NIGHT_WORKER2.HEPopupHelper = new QASubWindow();
                this.cdx01_NIGHT_WORKER2.PopupTitle = this.GetLabel("EMPNO");
                this.cdx01_NIGHT_WORKER2.CodeParameterName = "INSPECT_EMPNO";
                this.cdx01_NIGHT_WORKER2.NameParameterName = "INSPECT_EMPNONM";
                this.cdx01_NIGHT_WORKER2.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_NIGHT_WORKER2.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_NIGHT_WORKER2.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                DataSet source = this.GetTypeCode("FB","SB");

                HEParameterSet paramSet_DEFCD = new HEParameterSet();
                paramSet_DEFCD.Add("CORCD", _CORCD);
                paramSet_DEFCD.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet_DEFCD.Add("LANG_SET", _LANG_SET);

                HEParameterSet paramSet_JUD_RSLT = new HEParameterSet();
                paramSet_JUD_RSLT.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet combo_source_DEFCD = _WSCOMBOBOX.Inquery_DEFCD(paramSet_DEFCD);
                DataSet combo_source_DEFCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_DEFCD"), paramSet_DEFCD);

                //DataSet combo_source_JUD_RSLT = _WSCOMBOBOX.Inquery_JUD_RSLT(paramSet_JUD_RSLT);
                DataSet combo_source_JUD_RSLT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_JUD_RSLT"), paramSet_JUD_RSLT);

                this.AfterInvokeServer();
                #region [ grd01 ]
                this.grd01_QA20601.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
                this.grd01_QA20601.AllowEditing = false;
                this.grd01_QA20601.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20601.Initialize(2,2);
                this.grd01_QA20601.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "등록일자", "OCCUR_DATE", "REG_DATE");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD", "VIN");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "차종", "VINNM", "VIN");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "품목", "ITEMCD", "ITEM");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMNM", "ITEM");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMNM2", "ITEMNM3");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "일보작성", "DAY_ILBO_YN", "DAY_ILBO_YN");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "일보작성", "NIGHT_ILBO_YN", "DAY_ILBO_YN");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "작성여부(주간)", "DAY_AM_WRITE_YN", "SHIFT1");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "작성여부(주간)", "DAY_PM_WRITE_YN", "SHIFT2");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "작성여부(야간)", "NIGHT_AM_WRITE_YN", "SHIFT3");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 210, "작성여부(야간)", "NIGHT_PM_WRITE_YN", "NIGHT_AM_WRITE_YN");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "이상발생", "ISSUE_YN", "ISSUE_YN");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "기타사항", "ETC_YN", "ETC_YN");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "사진첨부", "PHOTO_YN", "PHOTO_YN");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "작성자(주간)", "DAY_WORKER", "SHIFT1");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "작성자(주간)", "DAY_WORKER2", "SHIFT2");
                this.grd01_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "작성자(야간)", "NIGHT_WORKER", "SHIFT3");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 130, "작성자(야간)", "NIGHT_WORKER2", "NIGHT_WORKER");
                this.grd01_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 130, "공장구분", "PLANT_DIV", "PLANT_DIV");


                this.grd01_QA20601.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01_QA20601.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01_QA20601.AddMerge(0, 1, "OCCUR_DATE", "OCCUR_DATE");
                this.grd01_QA20601.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd01_QA20601.AddMerge(0, 1, "VINNM", "VINNM");
                this.grd01_QA20601.AddMerge(0, 1, "ITEMCD", "ITEMCD");
                this.grd01_QA20601.AddMerge(0, 1, "ITEMNM", "ITEMNM");
                this.grd01_QA20601.AddMerge(0, 1, "ITEMNM2", "ITEMNM2");
                this.grd01_QA20601.AddMerge(0, 1, "INSPECT_CLASSCD", "INSPECT_CLASSCD");
                this.grd01_QA20601.AddMerge(0, 0, "DAY_ILBO_YN", "NIGHT_ILBO_YN");
                this.grd01_QA20601.AddMerge(0, 0, "DAY_AM_WRITE_YN", "NIGHT_PM_WRITE_YN");
                //this.grd01_QA20601.AddMerge(0, 0, "NIGHT_AM_WRITE_YN", "NIGHT_PM_WRITE_YN");
                this.grd01_QA20601.AddMerge(0, 1, "ISSUE_YN", "ISSUE_YN");
                this.grd01_QA20601.AddMerge(0, 1, "ETC_YN", "ETC_YN");
                this.grd01_QA20601.AddMerge(0, 1, "PHOTO_YN", "PHOTO_YN");
                this.grd01_QA20601.AddMerge(0, 0, "DAY_WORKER", "NIGHT_WORKER2");
                this.grd01_QA20601.AddMerge(0, 1, "PLANT_DIV", "PLANT_DIV");

                this.grd01_QA20601.SetHeadTitle(0, "CORCD", this.GetLabel("CORCD"));//"법인코드");
                this.grd01_QA20601.SetHeadTitle(0, "BIZCD", this.GetLabel("BIZCD"));//"사업장코드");
                this.grd01_QA20601.SetHeadTitle(0, "OCCUR_DATE", this.GetLabel("REG_DATE"));//"등록일자");
                this.grd01_QA20601.SetHeadTitle(0, "VINCD", this.GetLabel("VIN"));//"차종");
                this.grd01_QA20601.SetHeadTitle(0, "VINNM", this.GetLabel("VIN"));//"차종");
                this.grd01_QA20601.SetHeadTitle(0, "ITEMCD", this.GetLabel("ITEM"));//"품목");
                this.grd01_QA20601.SetHeadTitle(0, "ITEMNM", this.GetLabel("ITEM"));//"품목");
                this.grd01_QA20601.SetHeadTitle(0, "ITEMNM2", this.GetLabel("ITEMNM3"));//"품명");
                this.grd01_QA20601.SetHeadTitle(0, "INSPECT_CLASSCD", this.GetLabel("QA_INSPECT_BASECODE"));//"검사코드");
                this.grd01_QA20601.SetHeadTitle(0, "DAY_ILBO_YN", this.GetLabel("DAY_ILBO_YN"));//"일보작성");
                this.grd01_QA20601.SetHeadTitle(1, "DAY_ILBO_YN", this.GetLabel("DTIME_CNT"));//"주간");
                this.grd01_QA20601.SetHeadTitle(1, "NIGHT_ILBO_YN", this.GetLabel("NTIME_CNT"));//"야간");
                this.grd01_QA20601.SetHeadTitle(0, "DAY_AM_WRITE_YN", this.GetLabel("DAY_ILBO_YN"));//"일보작성");
                this.grd01_QA20601.SetHeadTitle(1, "DAY_AM_WRITE_YN", this.GetLabel("1SHIFT"));//"오전");
                this.grd01_QA20601.SetHeadTitle(1, "DAY_PM_WRITE_YN", this.GetLabel("2SHIFT"));//"오후");
                //this.grd01_QA20601.SetHeadTitle(0, "NIGHT_AM_WRITE_YN", this.GetLabel("NIGHT_AM_WRITE_YN"));//"작성여부(야간)");
                this.grd01_QA20601.SetHeadTitle(1, "NIGHT_AM_WRITE_YN", this.GetLabel("3SHIFT"));//"오전");
                this.grd01_QA20601.SetHeadTitle(1, "NIGHT_PM_WRITE_YN", this.GetLabel("TIME_DIVPM"));//"오후");
                this.grd01_QA20601.SetHeadTitle(0, "ISSUE_YN", this.GetLabel("ISSUE_YN"));//"이상발생");
                this.grd01_QA20601.SetHeadTitle(0, "ETC_YN", this.GetLabel("ETC_YN"));//"기타사항");
                this.grd01_QA20601.SetHeadTitle(0, "PHOTO_YN", this.GetLabel("PHOTO_YN"));//"사진첨부");
                this.grd01_QA20601.SetHeadTitle(0, "DAY_WORKER", this.GetLabel("WRITE_EMP"));//"작성자");
                this.grd01_QA20601.SetHeadTitle(1, "DAY_WORKER", this.GetLabel("1SHIFT"));//"주간(오전)");
                this.grd01_QA20601.SetHeadTitle(1, "DAY_WORKER2", this.GetLabel("2SHIFT"));//"주간(오후)");
                this.grd01_QA20601.SetHeadTitle(1, "NIGHT_WORKER", this.GetLabel("3SHIFT"));//"야간(오전)");
                this.grd01_QA20601.SetHeadTitle(1, "NIGHT_WORKER2", this.GetLabel("NIGHT_PM"));//"야간(오후)");

                #endregion

                #region [ grd02 ]
                this.grd02_QA20601.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
                this.grd02_QA20601.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20601.Initialize();
                this.grd02_QA20601.AllowSorting = AllowSortingEnum.None;
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "NO", "SEQ", "NO");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "등록일자", "OCCUR_DATE", "REG_DATE");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd02_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "순번", "INSPECT_SEQ", "SEQ_NO");
                this.grd02_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 320, "외관검사 점검항목", "INSPECT_ITEMNM", "EXT_INSPECT_CHKITEM");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 160, "주야코드", "DN_DIVCD", "DN_DIVCD");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "주야", "DN_DIVNM", "DAY_NGT_DIV");
                this.grd02_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "구분코드", "AMPM_DIVCD", "AMPM_DIVCD");
                this.grd02_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "구분", "AMPM_DIVNM", "DIVISION");
                this.grd02_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "FRT_LH", "FRT_LH");
                this.grd02_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "FRT_RH", "FRT_RH");
                this.grd02_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "RR_LH", "RR_LH");
                this.grd02_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "RR_RH", "RR_RH");
                this.grd02_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "3DR_LH", "DR3_LH");
                this.grd02_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "3DR_RH", "DR3_RH");
                this.grd02_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "문제점", "DEFCD", "DEFCD");
                this.grd02_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "조치결과", "MGRT_CNTTCD", "MGRT_RESULT");
                this.grd02_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "기타문제점", "ETC_ISSUE_REMARK", "ETC_ISSUE_REMARK");
                this.grd02_QA20601.Cols["OCCUR_DATE"].Format = "yyyy-MM-dd";
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_DATE");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "SEQ");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "FRT_LH");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "FRT_RH");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "RR_LH");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "RR_RH");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "DR3_LH");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "DR3_RH");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "MGRT_CNTTCD");
                this.grd02_QA20601.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_DEFCD.Tables[0], "DEFCD");
                this.grd02_QA20601.CurrentContextMenu.Items[0].Visible = false;
                this.grd02_QA20601.CurrentContextMenu.Items[1].Visible = false;
                this.grd02_QA20601.CurrentContextMenu.Items[2].Visible = false;
                this.grd02_QA20601.CurrentContextMenu.Items[3].Visible = false;
                this.grd02_QA20601.Cols["CORCD"].AllowMerging = true;
                this.grd02_QA20601.Cols["BIZCD"].AllowMerging = true;
                this.grd02_QA20601.Cols["SEQ"].AllowMerging = true;
                this.grd02_QA20601.Cols["OCCUR_DATE"].AllowMerging = true;
                this.grd02_QA20601.Cols["INSPECT_CLASSCD"].AllowMerging = true;
                this.grd02_QA20601.Cols["INSPECT_SEQ"].AllowMerging = true;
                this.grd02_QA20601.Cols["INSPECT_ITEMNM"].AllowMerging = true;
                this.grd02_QA20601.Cols["DN_DIVCD"].AllowMerging = true;
                this.grd02_QA20601.Cols["DN_DIVNM"].AllowMerging = true;
                this.grd02_QA20601.Cols["CORCD"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["BIZCD"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["SEQ"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["OCCUR_DATE"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["INSPECT_CLASSCD"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["INSPECT_SEQ"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["INSPECT_ITEMNM"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["DN_DIVCD"].Style.BackColor = Color.White;
                this.grd02_QA20601.Cols["DN_DIVNM"].Style.BackColor = Color.White;
                #endregion

                #region [ grd03 ]

                this.grd03_QA20601.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
                this.grd03_QA20601.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA20601.Initialize();
                this.grd03_QA20601.AllowSorting = AllowSortingEnum.None;
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "등록일자", "OCCUR_DATE", "REG_DATE");
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "검사순번", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd03_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "치수검사 점검항목", "INSPECT_ITEMNM", "SPC_INSEPCT_CHKITEM");
                this.grd03_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "표준치수", "INSPECT_STD_MEAS", "INSPECT_STD_MEAS2");
                this.grd03_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "상한치", "INSPECT_MAX_MEAS", "INSPECT_MAX_MEAS2");
                this.grd03_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "하한치", "INSPECT_MIN_MEAS", "INSPECT_MIN_MEAS2");
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "주야코드", "DN_DIVCD", "DN_DIVCD");
                this.grd03_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "주야", "DN_DIVNM", "DAY_NGT_DIV");

                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "초품", "X1", "BEGIN_PRODUCT");
                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "중품", "X2", "MIDDLE_PRODUCT");
                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "종품", "X3", "LAST_PRODUCT");
                this.grd03_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "X4", "X4");
                this.grd03_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "X5", "X5");
                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "판정", "JUD_CD", "JUD_CD");
                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "문제점", "DEFCD", "DEFCD");
                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "조치결과", "MGRT_CNTTCD", "MGRT_RESULT");
                this.grd03_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "기타문제점", "ETC_ISSUE_REMARK", "ETC_ISSUE_REMARK");
                this.grd03_QA20601.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_STD_MEAS");
                this.grd03_QA20601.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MAX_MEAS");
                this.grd03_QA20601.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MIN_MEAS");
                //this.grd03_QA20601.SetColumnType(HEFlexGrid.FCellType.Decimal, "X1");
                //this.grd03_QA20601.SetColumnType(HEFlexGrid.FCellType.Decimal, "X2");
                //this.grd03_QA20601.SetColumnType(HEFlexGrid.FCellType.Decimal, "X3");
                //this.grd03_QA20601.SetColumnType(HEFlexGrid.FCellType.Decimal, "X4");
                //this.grd03_QA20601.SetColumnType(HEFlexGrid.FCellType.Decimal, "X5");
                this.grd03_QA20601.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_JUD_RSLT.Tables[0], "JUD_CD");
                this.grd03_QA20601.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "MGRT_CNTTCD");
                this.grd03_QA20601.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_DEFCD.Tables[0], "DEFCD");
                this.grd03_QA20601.Cols["INSPECT_STD_MEAS"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["INSPECT_MAX_MEAS"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["INSPECT_MIN_MEAS"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["X1"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["X2"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["X3"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["X4"].Format = "#,##0.00";
                this.grd03_QA20601.Cols["X5"].Format = "#,##0.00";
                this.grd03_QA20601.CurrentContextMenu.Items[0].Visible = false;
                this.grd03_QA20601.CurrentContextMenu.Items[1].Visible = false;
                this.grd03_QA20601.CurrentContextMenu.Items[2].Visible = false;
                this.grd03_QA20601.CurrentContextMenu.Items[3].Visible = false;
                this.grd03_QA20601.Cols["CORCD"].AllowMerging = true;
                this.grd03_QA20601.Cols["BIZCD"].AllowMerging = true;
                this.grd03_QA20601.Cols["OCCUR_DATE"].AllowMerging = true;
                this.grd03_QA20601.Cols["INSPECT_CLASSCD"].AllowMerging = true;
                this.grd03_QA20601.Cols["INSPECT_SEQ"].AllowMerging = true;
                this.grd03_QA20601.Cols["INSPECT_ITEMNM"].AllowMerging = true;
                this.grd03_QA20601.Cols["INSPECT_STD_MEAS"].AllowMerging = true;
                this.grd03_QA20601.Cols["INSPECT_MAX_MEAS"].AllowMerging = true;
                this.grd03_QA20601.Cols["INSPECT_MIN_MEAS"].AllowMerging = true;
                this.grd03_QA20601.Rows.DefaultSize = this.grd03_QA20601.Rows.DefaultSize + 5;

                #endregion

                this.grd04_QA20601.AllowDragging = AllowDraggingEnum.None;
                this.grd04_QA20601.Initialize();
                this.grd04_QA20601.AllowSorting = AllowSortingEnum.None;
                this.grd04_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd04_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "등록일자", "OCCUR_DATE", "REG_DATE");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발생일자", "PROC_DATE", "OCCUR_DATE");
                this.grd04_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "불량번호", "DPTNO", "DEFECT_NOTENO");
                this.grd04_QA20601.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량_SEQ", "DPT_SEQ", "BAD_SEQ");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "A'SSY NO", "ASSYPNO");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "A'SSY NAME", "ASSYPNM");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "폐기수량", "DIS_QTY", "DIS_QTY");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "수정수량", "AMD_QTY", "AMD_QTY");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량내용", "DEFNM", "DEFNM");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "조치구분", "MGRT_NM", "MGRT_NM");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "귀책구분", "IMPUT_DIVNM", "IMPUT_DIV");
                this.grd04_QA20601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "IMPUT_VENDNM", "IMPUT_VENDNM");
                this.grd04_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "고품접수", "RET_PRDT_YN", "RET_PRDT_YN");
                this.grd04_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "조치확인", "CHK_MGRT_YN", "CHK_MGRT_YN");
                this.grd04_QA20601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "조치결과", "MGRT_CLASSCD", "MGRT_RESULT");
                this.grd04_QA20601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");

                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_DATE");
                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");
                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.Check, "RET_PRDT_YN");
                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.Check, "RET_PRDT_YN");
                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "DIS_QTY");
                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.Int, "AMD_QTY");
                this.grd04_QA20601.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "MGRT_CLASSCD");
                this.grd04_QA20601.CurrentContextMenu.Items[0].Visible = false;
                this.grd04_QA20601.CurrentContextMenu.Items[1].Visible = false;
                this.grd04_QA20601.CurrentContextMenu.Items[2].Visible = false;
                this.grd04_QA20601.CurrentContextMenu.Items[3].Visible = false;

                this.pic01_FRT_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_RR_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_ETC_3DR_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_ISSUE_PHOTO1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_ISSUE_PHOTO2.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_ISSUE_PHOTO3.SizeMode = PictureBoxSizeMode.Zoom;

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.BtnReset_Click(null, null);

                if (INSPECT_CLASSCD_T != "")
                {
                    this.cbo01_BIZCD.SetValue(BIZCD_T);
                    this.dte01_OCCUR_DATE.SetValue(OCCUR_DATE_T);
                    this.cbo01_PLANT_DIV.SetValue(PLANT_DIV_T);
                }

                //파견불량현황탭은 불필요함.
                this.tabControl1.TabPages.Remove(tabPage3);

                this.BtnQuery_Click(null, null);
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
                this.grd01_QA20601.Rows[0].Height = 20;
                this.grd01_QA20601.Rows[1].Height = 20; 

                this.grd02_QA20601.InitializeDataSource();
                this.grd03_QA20601.InitializeDataSource();
                this.grd04_QA20601.InitializeDataSource();

                this.pic01_FRT_PHOTO.Initialize();
                this.pic01_RR_PHOTO.Initialize();
                this.pic01_ETC_3DR_PHOTO.Initialize();
                this.pic01_ISSUE_PHOTO1.Initialize();
                this.pic01_ISSUE_PHOTO2.Initialize();
                this.pic01_ISSUE_PHOTO3.Initialize();

                this.cdx01_DAY_WORKER.Initialize();
                this.cdx01_DAY_WORKER2.Initialize();
                this.cdx01_NIGHT_WORKER.Initialize();
                this.cdx01_NIGHT_WORKER2.Initialize();

                this.txt02_OCCUR_DATE.Initialize();
                this.txt02_INSPECT_CLASSCD.Initialize();
                this.txt02_PID.Initialize();
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

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string OCCUR_DATE = this.dte01_OCCUR_DATE.GetDateText().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();                

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCUR_DATE", OCCUR_DATE);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_MAIN(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MAIN"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20601.SetValue(source);

                if (INSPECT_CLASSCD_T != "")
                {
                    this.grd01_QA20601_VIEW(CORCD_T, BIZCD_T, OCCUR_DATE_T, INSPECT_CLASSCD_T, PLANT_DIV_T);
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

                string PID = this.txt02_PID.GetValue().ToString();
                if (PID != "")
                {
                    //MsgBox.Show("결재진행 및 결재완료 항목을 저장 할 수 없습니다.");
                    MsgCodeBox.Show("QA02-0040");
                    return;
                }

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string OCCUR_DATE= this.txt02_OCCUR_DATE.GetValue().ToString();
                string INSPECT_CLASSCD= this.txt02_INSPECT_CLASSCD.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                if (this.GetByteCount(INSPECT_CLASSCD) != 0)
                {
                    DataSet source_SAVE_QA6010 = this.GetDataSourceSchema(
                        "CORCD", "BIZCD", "OCCUR_DATE", "INSPECT_CLASSCD", "DAY_WORKER", "DAY_WORKER2",
                        "NIGHT_WORKER", "NIGHT_WORKER2", "BLOB$ISSUE_PHOTO1", "BLOB$ISSUE_PHOTO2", "BLOB$ISSUE_PHOTO3");
                    source_SAVE_QA6010.Tables[0].Rows.Add(
                        _CORCD,
                        BIZCD,
                        OCCUR_DATE,
                        INSPECT_CLASSCD,
                        this.cdx01_DAY_WORKER.GetValue(),
                        this.cdx01_DAY_WORKER2.GetValue(),
                        this.cdx01_NIGHT_WORKER.GetValue(),
                        this.cdx01_NIGHT_WORKER2.GetValue(),
                        this.pic01_ISSUE_PHOTO1.GetValue(),
                        this.pic01_ISSUE_PHOTO2.GetValue(),
                        this.pic01_ISSUE_PHOTO3.GetValue()
                    );

                    DataSet source_SAVE_QA6020 = this.grd02_QA20601.GetValue(AxFlexGrid.FActionType.All,
                        "CORCD", "BIZCD", "OCCUR_DATE", "INSPECT_CLASSCD", "INSPECT_SEQ",
                        "DN_DIVCD", "AMPM_DIVCD", "FRT_LH", "FRT_RH", "RR_LH",
                        "RR_RH", "DR3_LH", "DR3_RH", "DEF_QTY", "DEFCD",
                        "MGRT_CNTTCD", "ETC_ISSUE_REMARK");

                    source_SAVE_QA6020.Tables[0].Rows[0].Delete();

                    DataSet source_SAVE_QA6030 = this.grd03_QA20601.GetValue(AxFlexGrid.FActionType.All,
                        "CORCD", "BIZCD", "OCCUR_DATE", "INSPECT_CLASSCD", "INSPECT_SEQ",
                        "DN_DIVCD", "X1", "X2", "X3", "X4",
                        "X5", "JUD_CD", "DEFCD", "MGRT_CNTTCD", "ETC_ISSUE_REMARK");

                    DataSet source_SAVE_QA6040 = this.grd04_QA20601.GetValue(AxFlexGrid.FActionType.All,
                        "CORCD", "BIZCD", "OCCUR_DATE", "INSPECT_CLASSCD", "DPTNO",
                        "RET_PRDT_YN", "CHK_MGRT_YN", "MGRT_CLASSCD");

                    if (!IsSaveValid(source_SAVE_QA6010, source_SAVE_QA6020, source_SAVE_QA6030, source_SAVE_QA6040)) return;

                    this.BeforeInvokeServer(true);

                    //_WSCOM.Save(source_SAVE_QA6010, source_SAVE_QA6020, source_SAVE_QA6030, source_SAVE_QA6040);
                    string[] procedures = new string[] {string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA6010"), 
                                                        string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA6020"), 
                                                        string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA6030"),
                                                        string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA6040")};
                    DataSet[] datasets = new DataSet[] { source_SAVE_QA6010, source_SAVE_QA6020, source_SAVE_QA6030, source_SAVE_QA6040 };
                    _WSCOM_N.MultipleExecuteNonQueryTx(procedures, datasets);
                  

                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);

                    this.txt02_OCCUR_DATE.SetValue(OCCUR_DATE);
                    this.txt02_INSPECT_CLASSCD.SetValue(INSPECT_CLASSCD);

                    this.INQUERY_QA6010_VIEW(_CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD);
                    this.INQUERY_QA6020_VIEW(_CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD);
                    this.INQUERY_QA6030_VIEW(_CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD);
                    this.INQUERY_QA6040_VIEW(_CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD, PLANT_DIV);

                    //MsgBox.Show("공정 순회검사결과가 저장되었습니다.");
                    MsgCodeBox.Show("CD00-0071");
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

                string PID = this.txt02_PID.GetValue().ToString();
                if (PID != "")
                {
                    //MsgBox.Show("결재진행 및 결재완료 항목을 삭제 할 수 없습니다.");
                    MsgCodeBox.Show("QA02-0039");
                    return;
                }

                string INSPECT_CLASSCD = this.txt02_INSPECT_CLASSCD.GetValue().ToString();
                if (this.GetByteCount(INSPECT_CLASSCD) != 0)
                {
                    DataSet source = AxFlexGrid.GetDataSourceSchema(
                        "CORCD", "BIZCD", "OCCUR_DATE", "INSPECT_CLASSCD");
                    source.Tables[0].Rows.Add(
                        _CORCD,
                        this.cbo01_BIZCD.GetValue(),
                        this.txt02_OCCUR_DATE.GetValue(),
                        INSPECT_CLASSCD
                    );

                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);

                    //_WSCOM.Remove(source);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "DELETE"), source);

                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);
                    this.BtnReset_Click(null, null);

                    //MsgBox.Show("정상적으로 삭제 되었습니다.");
                    MsgCodeBox.Show("CD00-0072");
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
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source1, DataSet source2, DataSet source3, DataSet source4)
        {

            try
            {
                string DAY_WORKER = this.cdx01_DAY_WORKER.GetValue().ToString();
                string DAY_WORKER2 = this.cdx01_DAY_WORKER2.GetValue().ToString();
                string NIGHT_WORKER = this.cdx01_NIGHT_WORKER.GetValue().ToString();
                string NIGHT_WORKER2 = this.cdx01_NIGHT_WORKER2.GetValue().ToString();

                if (this.GetByteCount(DAY_WORKER) + this.GetByteCount(DAY_WORKER2) + this.GetByteCount(NIGHT_WORKER) + this.GetByteCount(NIGHT_WORKER2) == 0)
                {
                    //MsgBox.Show("작업자가 적어도 1명이상 선택 되어야 합니다.");
                    MsgCodeBox.Show("QA02-0041");

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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
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

        #region [ 기타 이벤트 정의 ]

        void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_DAY_WORKER.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_DAY_WORKER2.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_NIGHT_WORKER.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_NIGHT_WORKER2.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_QA20601_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20601.SelectedRowIndex;

                if (Row >= this.grd01_QA20601.Rows.Fixed)
                {
                    string CORCD = this.grd01_QA20601.GetValue(Row, "CORCD").ToString();
                    string BIZCD = this.grd01_QA20601.GetValue(Row, "BIZCD").ToString();
                    string OCCUR_DATE = this.grd01_QA20601.GetValue(Row, "OCCUR_DATE").ToString();
                    string INSPECT_CLASSCD = this.grd01_QA20601.GetValue(Row, "INSPECT_CLASSCD").ToString();
                    string PLANT_DIV = this.grd01_QA20601.GetValue(Row, "PLANT_DIV").ToString();
                    this.BtnReset_Click(null, null);

                    this.grd01_QA20601_VIEW(CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD, PLANT_DIV);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ISSUE_PHOTO1_COMMIT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic01_ISSUE_PHOTO1.SetValue(_PHOTO);
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

        private void btn01_ISSUE_PHOTO1_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_ISSUE_PHOTO1.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ISSUE_PHOTO2_COMMIT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic01_ISSUE_PHOTO2.SetValue(_PHOTO);
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

        private void btn01_ISSUE_PHOTO2_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_ISSUE_PHOTO2.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ISSUE_PHOTO3_COMMIT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic01_ISSUE_PHOTO3.SetValue(_PHOTO);
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

        private void btn01_ISSUE_PHOTO3_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_ISSUE_PHOTO3.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd03_QA20601_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                int Row = this.grd03_QA20601.SelectedRowIndex;
                int Col = this.grd03_QA20601.Col;

                if (Row >= this.grd03_QA20601.Rows.Fixed)
                {
                    this.grd03_QA20601.SetValue(Row, "JUD_CD", "");

                    decimal INSPECT_MAX_MEAS = Decimal.Parse(this.grd03_QA20601.GetValue(Row, "INSPECT_MAX_MEAS").ToString());
                    decimal INSPECT_MIN_MEAS = Decimal.Parse(this.grd03_QA20601.GetValue(Row, "INSPECT_MIN_MEAS").ToString());

                    bool bCHK = true;
                    int value_cnt = 0;

                    for (int i = 1; i <= 5; i++)
                    {
                        string x_value = this.grd03_QA20601.GetValue(Row, "X" + i.ToString()).ToString();

                        if (x_value.Length == 0) continue;

                        value_cnt++;

                        decimal X = Decimal.Parse(x_value);
                        if (INSPECT_MAX_MEAS >= X && INSPECT_MIN_MEAS <= X)
                        {
                            bCHK = true;
                        }
                        else
                        {
                            bCHK = false;
                            break;
                        }
                    }

                    if (value_cnt == 0) return;

                    if (bCHK)
                    {
                        this.grd03_QA20601.SetValue(Row, "JUD_CD", "Y");
                    }
                    else
                    {
                        this.grd03_QA20601.SetValue(Row, "JUD_CD", "N");
                    }
                
                
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_QA20601_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                int Row = this.grd02_QA20601.SelectedRowIndex;

                if (Row >= this.grd02_QA20601.Rows.Fixed)
                {
                    decimal FRT_LH = Decimal.Parse(this.grd02_QA20601.GetValue(Row, "FRT_LH").ToString());
                    decimal FRT_RH = Decimal.Parse(this.grd02_QA20601.GetValue(Row, "FRT_RH").ToString());
                    decimal RR_LH = Decimal.Parse(this.grd02_QA20601.GetValue(Row, "RR_LH").ToString());
                    decimal RR_RH = Decimal.Parse(this.grd02_QA20601.GetValue(Row, "RR_RH").ToString());
                    decimal DR3_LH = Decimal.Parse(this.grd02_QA20601.GetValue(Row, "DR3_LH").ToString());
                    decimal DR3_RH = Decimal.Parse(this.grd02_QA20601.GetValue(Row, "DR3_RH").ToString());

                    this.grd02_QA20601.SetValue(Row, "DEF_QTY", FRT_LH + FRT_RH + RR_LH + RR_RH + DR3_LH + DR3_RH);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_FRT_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_FRT_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_FRT_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_RR_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_RR_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_RR_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_ETC_3DR_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_ETC_3DR_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_ETC_3DR_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_ISSUE_PHOTO1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_ISSUE_PHOTO1.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_ISSUE_PHOTO1.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_ISSUE_PHOTO2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_ISSUE_PHOTO2.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_ISSUE_PHOTO2.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_ISSUE_PHOTO3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_ISSUE_PHOTO3.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_ISSUE_PHOTO3.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_DAY_WORKER_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
        }

        private void cdx01_DAY_WORKER2_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
        }

        private void cdx01_NIGHT_WORKER_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
        }

        private void cdx01_NIGHT_WORKER2_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
        }
        
        #endregion

        #region [ 사용자 정의 메서드 ]

        private void grd01_QA20601_VIEW(string CORCD, string BIZCD, string OCCUR_DATE, string INSPECT_CLASSCD, string PLANT_DIV)
        {
            try
            {
                this.txt02_OCCUR_DATE.SetValue(OCCUR_DATE);
                this.txt02_INSPECT_CLASSCD.SetValue(INSPECT_CLASSCD);

                this.INQUERY_QA6010_VIEW(CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD);
                this.INQUERY_QA6020_VIEW(CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD);
                this.INQUERY_QA6030_VIEW(CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD);
                this.INQUERY_QA6040_VIEW(CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD, PLANT_DIV);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void INQUERY_QA6010_VIEW(string CORCD, string BIZCD, string OCCUR_DATE, string INSPECT_CLASSCD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCUR_DATE", OCCUR_DATE);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA6010(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA6010"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                if ((dr["FRT_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _FRT_PHOTO = null;
                    _FRT_PHOTO = (byte[])(dr["FRT_PHOTO"]);
                    this.pic01_FRT_PHOTO.SetValue(_FRT_PHOTO);
                }

                if ((dr["RR_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _RR_PHOTO = null;
                    _RR_PHOTO = (byte[])(dr["RR_PHOTO"]);
                    this.pic01_RR_PHOTO.SetValue(_RR_PHOTO);
                }

                if ((dr["ETC_3DR_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _ETC_3DR_PHOTO = null;
                    _ETC_3DR_PHOTO = (byte[])(dr["ETC_3DR_PHOTO"]);
                    this.pic01_ETC_3DR_PHOTO.SetValue(_ETC_3DR_PHOTO);
                }

                if ((dr["ISSUE_PHOTO1"]) != System.DBNull.Value)
                {
                    byte[] _ISSUE_PHOTO1 = null;
                    _ISSUE_PHOTO1 = (byte[])(dr["ISSUE_PHOTO1"]);
                    this.pic01_ISSUE_PHOTO1.SetValue(_ISSUE_PHOTO1);
                }

                if ((dr["ISSUE_PHOTO2"]) != System.DBNull.Value)
                {
                    byte[] _ISSUE_PHOTO2 = null;
                    _ISSUE_PHOTO2 = (byte[])(dr["ISSUE_PHOTO2"]);
                    this.pic01_ISSUE_PHOTO2.SetValue(_ISSUE_PHOTO2);
                }

                if ((dr["ISSUE_PHOTO3"]) != System.DBNull.Value)
                {
                    byte[] _ISSUE_PHOTO3 = null;
                    _ISSUE_PHOTO3 = (byte[])(dr["ISSUE_PHOTO3"]);
                    this.pic01_ISSUE_PHOTO3.SetValue(_ISSUE_PHOTO3);
                }

                this.cdx01_DAY_WORKER.SetValue(dr["DAY_WORKER"].ToString());
                this.cdx01_DAY_WORKER2.SetValue(dr["DAY_WORKER2"].ToString());
                this.cdx01_NIGHT_WORKER.SetValue(dr["NIGHT_WORKER"].ToString());
                this.cdx01_NIGHT_WORKER2.SetValue(dr["NIGHT_WORKER2"].ToString());
                this.txt02_PID.SetValue(dr["PID"].ToString());
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

        private void INQUERY_QA6020_VIEW(string CORCD, string BIZCD, string OCCUR_DATE, string INSPECT_CLASSCD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCUR_DATE", OCCUR_DATE);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA6020(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA6020"), paramSet);

                this.AfterInvokeServer();

                this.grd02_QA20601.SetValue(source);
                this.grd_COROL(grd02_QA20601);

                if (this.grd02_QA20601.Rows.Count >= 4)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        this.grd02_QA20601.Rows[i].AllowEditing = false;
                    }
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

        private void grd_COROL(AxFlexGrid grd)
        {
            grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(247, 185, 56);

            CellRange cr = new CellRange();
            for (int i = 1; i < grd.Rows.Count; i++)
            {
                switch (grd.GetValue(i, "INSPECT_SEQ").ToString())
                {
                    case "0":
                        cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                        cr.Style = grd.Styles["COLOR_B"];
                        break;
                    default:
                        break;
                }
            }
        }

        private void INQUERY_QA6030_VIEW(string CORCD, string BIZCD, string OCCUR_DATE, string INSPECT_CLASSCD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCUR_DATE", OCCUR_DATE);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA6030(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA6030"), paramSet);

                this.AfterInvokeServer();

                this.grd03_QA20601.SetValue(source);
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

        private void INQUERY_QA6040_VIEW(string CORCD, string BIZCD, string OCCUR_DATE, string INSPECT_CLASSCD, string PLANT_DIV)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCUR_DATE", OCCUR_DATE);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("MODE", "1");
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA6040(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA6040"), paramSet);

                this.AfterInvokeServer();

                this.grd04_QA20601.SetValue(source);
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
