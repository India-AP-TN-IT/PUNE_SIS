#region ▶ Description & History
/* 
 * 프로그램명 : QA20123 공정불량생산 등록자료 판정
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
    /// <b>공정불량생산 등록자료 판정</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:43:10<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:43:10   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20123 : AxCommonBaseControl
    {
        //private IQA20123 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;
        private String _LANG_SET;
        private String _BIZCD;
        private String _RCV_DATE;
        private String _VENDCD;
        private String _NOTENO;
        private String _Change_CHK;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20123";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20123()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20123>("QA00", "QA20123.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _BIZCD = "";
            _RCV_DATE = "";
            _VENDCD = "";
            _NOTENO = "";
        }

        public QA20123(string BIZCD, string RCV_DATE, string VENDCD, string NOTENO)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20123>("QA00", "QA20123.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _BIZCD = BIZCD;
            _RCV_DATE = RCV_DATE;
            _VENDCD = VENDCD;
            _NOTENO = NOTENO;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grp01_QA20123_MSG1.Text = this.GetLabel("QA20123_MSG1");
                this.grp01_QA20123_MSG2.Text = this.GetLabel("QA20123_MSG2");   
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

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.17 공장구분 조회조건 추가
                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.17 공장구분 입력항목 추가
                //if (this.cbo01_BIZCD.GetValue().Equals("5220"))    //2013.04.17 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                {
                    this.cbo02_PLANT_DIV.SetReadOnly(true);
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                }

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEF_PNO.HEPopupHelper = new QASubWindow();
                this.cdx02_DEF_PNO.PopupTitle = this.GetLabel("PARTNO_INFO");//"PART NO 정보";
                this.cdx02_DEF_PNO.CodeParameterName = "PARTNO_OF_ASSYPNO";
                this.cdx02_DEF_PNO.NameParameterName = "PARTNO_OF_ASSYPNM";
                this.cdx02_DEF_PNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEF_PNO.HEParameterAdd("BIZCD", "");
                this.cdx02_DEF_PNO.HEParameterAdd("ASSYPNO", "");
                this.cdx02_DEF_PNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_INSPECT_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_INSPECT_EMPNO.PopupTitle = this.GetLabel("INSPECT_CD");//"검사원코드";
                this.cdx02_INSPECT_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_INSPECT_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("LANG_SET", this.cbo01_BIZCD.GetValue().ToString());

                this.grd01_QA20123.AllowEditing = false;
                this.grd01_QA20123.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20123.Initialize();
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "발생일자", "RCV_DATE", "OCCUR_DATE");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "발생장소코드", "DEF_PLACECD", "DEF_PLACECD");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생장소", "DEF_PLACENM", "DEF_PLACENM");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "업체", "VENDCD", "VENDNM");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "LINE", "LINECD", "LINECD");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "DEF_PNO", "DEF_PNO");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NAME", "DEF_PNONM", "DEF_PNONM");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "번호", "NOTENO", "NOTENO");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 90, "번호", "REF_NOTENO", "REF_NOTENO");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "ASS'Y NO", "ASSYPNO");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "재사용", "MAT_REUSE_YN", "MAT_REUSE_YN");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 50, "귀책구분코드", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "귀책구분", "IMPUT_DIVNM", "IMPUT_DIVNM");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "Usage", "USAGE");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "생산작업자사번", "PROD_REG_EMPNO", "WORK_EMPNO");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "생산작업자", "PROD_REG_EMPNM", "WORK_EMPNO");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "SHIFT", "DN_DIV", "SHIFT");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "SHIFT", "DN_DIVNM", "SHIFT");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "검사원", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "UNIT", "UNIT");
                this.grd01_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "UNIT", "UNITNM");

                //this.grd01_QA20123.AddColumn(false, false, HEFlexGrid.FtextAlign.L, 100, "공장구분", "PLANT_DIV", "PLANT_DIV");  //공장구분 추가
                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA20123.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;


                this.grd01_QA20123.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");

                this.grd02_QA20123.AllowEditing = false;
                this.grd02_QA20123.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20123.Initialize();
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "발생일자", "RCV_DATE", "OCCUR_DATE");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "발생장소코드", "DEF_PLACECD", "DEF_PLACECD");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생장소", "DEF_PLACENM", "DEF_PLACENM");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "업체", "PROD_VENDCD", "VENDNM");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "생산귀책업체", "PROD_VENDNM", "PROD_VENDNM");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "LINE", "LINECD", "LINECD");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD", "ALCCD");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "DEF_PNO", "DEF_PNO");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "PART NAME", "DEF_PNONM", "DEF_PNONM");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "번호", "NOTENO", "NOTENO");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "ASS'Y NO", "ASSYPNO");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "Usage", "USAGE");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "귀책구분", "IMPUT_DIVCD", "IMPUT_DIVNM");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "불량내용코드", "DEFCD", "DEFCD");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "불량내용", "DEFNM", "DEFNM");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "불량부위코드", "DEFPOSCD", "DEFPOSCD");
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "생산작업자사번", "PROD_REG_EMPNO", "WORK_EMPNO");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "생산작업자", "PROD_REG_EMPNM", "WORK_EMPNO");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "SHIFT", "DN_DIV", "SHIFT");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "SHIFT", "DN_DIVNM", "SHIFT");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "검사원", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "UNIT", "UNIT");
                this.grd02_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "UNIT", "UNITNM");

                //this.grd02_QA20123.AddColumn(false, false, HEFlexGrid.FtextAlign.L, 100, "공장구분", "PLANT_DIV", "PLANT_DIV"); //공장구분 추가
                this.grd02_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd02_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd02_QA20123.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd02_QA20123.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd02_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, "F4", "IMPUT_DIVCD");

                this.grd03_QA20123.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA20123.Initialize();
                this.grd03_QA20123.AllowSorting = AllowSortingEnum.None;
                this.grd03_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "법인코드", "CORCD", "CORCD");
                this.grd03_QA20123.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "사업장", "BIZCD", "BIZCD");
                this.grd03_QA20123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "번호", "NOTENO", "NOTENO");
                this.grd03_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "결정귀책업체", "VENDCD", "IMPUT_VENDNM");
                this.grd03_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "귀책구분", "IMPUT_DIVCD", "IMPUT_DIVNM");
                this.grd03_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "불량내용", "DEFCD", "DEFNM");
                this.grd03_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "불량부위", "DEFPOSCD", "DEFPOSCD");
                this.grd03_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd03_QA20123.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "재사용유무", "MAT_REUSE_YN", "MAT_REUSE_YN");

                DataSet source = this.GetTypeCode("F4");
                
                DataTable combo_source_MAT_REUSE_YN = new DataTable();
                combo_source_MAT_REUSE_YN.Columns.Add("CODE");
                combo_source_MAT_REUSE_YN.Columns.Add("NAME");
                combo_source_MAT_REUSE_YN.Rows.Add("Y", this.GetLabel("POSSIBLE"));
                combo_source_MAT_REUSE_YN.Rows.Add("N", this.GetLabel("IMPOSSIBLE"));

                HEParameterSet paramSet_DEFCD = new HEParameterSet();
                paramSet_DEFCD.Add("CORCD", _CORCD);
                paramSet_DEFCD.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet_DEFCD.Add("LANG_SET", _LANG_SET);

                HEParameterSet paramSet_DEFPOSCD = new HEParameterSet();
                paramSet_DEFPOSCD.Add("CORCD", _CORCD);
                paramSet_DEFPOSCD.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet_DEFPOSCD.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);
                
                //DataSet combo_source_DEFCD = _WSCOMBOBOX.Inquery_DEFCD(paramSet_DEFCD);
                //DataSet combo_source_DEFPOSCD = _WSCOMBOBOX.Inquery_DEFPOSCD(paramSet_DEFPOSCD);
                DataSet combo_source_DEFCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_DEFCD"), paramSet_DEFCD);
                DataSet combo_source_DEFPOSCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_DEFPOSCD"), paramSet_DEFPOSCD);
                
                this.AfterInvokeServer();

                this.grd03_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "IMPUT_DIVCD");
                this.grd03_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_MAT_REUSE_YN, "MAT_REUSE_YN");
                this.grd03_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_DEFCD.Tables[0], "DEFCD");
                this.grd03_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_DEFPOSCD.Tables[0], "DEFPOSCD");

                this.pic01_DEF_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE, lbl02_DEF_PNO, lbl02_PROD_VENDNM, lbl02_DEF_QTY, lbl02_USAGE, lbl02_WORK_EMPNO, lbl02_INSPECT_EMPNO, lbl02_PLANT_DIV);

                if (_NOTENO != "")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD);
                    this.dte01_RCV_DATE.SetValue(_RCV_DATE);
                    this.cdx01_VENDCD.SetValue(_VENDCD);
                    this.txt01_NOTENO.SetValue(_NOTENO);
                }

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                if (_NOTENO != "")
                {
                    this.grd(1);
                }
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
                foreach (Control ctl in panel10.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
                this.pic01_DEF_PHOTO.Initialize();
                this.grd03_QA20123.InitializeDataSource();
                _Change_CHK = "N";

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
                string RCV_DATE = this.dte01_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string NOTENO = this.txt01_NOTENO.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.18 공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("NOTENO", NOTENO);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.18 공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source_QA1060 = _WSCOM.Inquery_QA1060(paramSet);
                DataSet source_QA1060 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1060"), paramSet);
                this.grd01_QA20123.SetValue(source_QA1060);

                //DataSet source_QA1061 = _WSCOM.Inquery_QA1061(paramSet);
                DataSet source_QA1061 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1061"), paramSet);
                this.grd02_QA20123.SetValue(source_QA1061);
                _Change_CHK = "N";

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

                string REF_NOTENO = this.txt02_REF_NOTENO.GetValue().ToString();
                string ASSYPNO = this.txt02_ASSYPNO.GetValue().ToString();
                string DEF_PNO = this.cdx02_DEF_PNO.GetValue().ToString();
                string VENDCD = this.txt02_VENDCD.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetDBValue().ToString();
                string UNIT = this.lbl02_UNIT.GetValue().ToString();
                string PROD_REG_EMPNO = this.txt02_PROD_REG_EMPNM.GetValue().ToString();
                string PROD_REG_EMPNM = this.txt02_PROD_REG_EMPNO.GetValue().ToString();
                string DN_DIV = this.txt02_DN_DIVNM.GetValue().ToString();
                string INSPECT_EMPNO = this.cdx02_INSPECT_EMPNO.GetValue().ToString();
                string RCV_DATE = this.txt02_RCV_DATE.GetValue().ToString();

                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString();          ////공장구분 추가 2013.04.18

                DataSet source_SAVE = this.grd03_QA20123.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "NOTENO", "VENDCD", "IMPUT_DIVCD",
                    "DEFCD", "DEFPOSCD", "DEF_QTY", "MAT_REUSE_YN", "GUBN", "REF_NOTENO", "ASSYPNO", "DEF_PNO", "PROD_REG_EMPNO", "DN_DIV", "INSPECT_EMPNO", "RCV_DATE","PLANT_DIV");

                for (int i = 0; i < source_SAVE.Tables[0].Rows.Count; i++)
                {
                    source_SAVE.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    source_SAVE.Tables[0].Rows[i]["BIZCD"] = this.cbo01_BIZCD.GetValue().ToString();
                    source_SAVE.Tables[0].Rows[i]["GUBN"] = "U";
                    source_SAVE.Tables[0].Rows[i]["REF_NOTENO"] = REF_NOTENO;
                    source_SAVE.Tables[0].Rows[i]["ASSYPNO"] = ASSYPNO;
                    source_SAVE.Tables[0].Rows[i]["DEF_PNO"] = DEF_PNO;
                    source_SAVE.Tables[0].Rows[i]["PROD_REG_EMPNO"] = PROD_REG_EMPNO;
                    source_SAVE.Tables[0].Rows[i]["DN_DIV"] = DN_DIV;
                    source_SAVE.Tables[0].Rows[i]["INSPECT_EMPNO"] = INSPECT_EMPNO;
                    source_SAVE.Tables[0].Rows[i]["RCV_DATE"] = RCV_DATE;
                    source_SAVE.Tables[0].Rows[i]["PLANT_DIV"] = PLANT_DIV; ///공장구분 추가 2013.04.18
                }

                DataSet source_Remove = this.grd03_QA20123.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "NOTENO", "VENDCD", "IMPUT_DIVCD",
                    "DEFCD", "DEFPOSCD", "DEF_QTY", "MAT_REUSE_YN", "GUBN", "REF_NOTENO", "ASSYPNO", "DEF_PNO", "PROD_REG_EMPNO", "DN_DIV", "INSPECT_EMPNO", "RCV_DATE");

                for (int i = 0; i < source_Remove.Tables[0].Rows.Count; i++)
                {
                    source_Remove.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    source_Remove.Tables[0].Rows[i]["BIZCD"] = this.cbo01_BIZCD.GetValue().ToString();
                    source_Remove.Tables[0].Rows[i]["GUBN"] = "D";
                    source_Remove.Tables[0].Rows[i]["REF_NOTENO"] = REF_NOTENO;
                    source_Remove.Tables[0].Rows[i]["ASSYPNO"] = ASSYPNO;
                    source_Remove.Tables[0].Rows[i]["DEF_PNO"] = DEF_PNO;
                    source_Remove.Tables[0].Rows[i]["PROD_REG_EMPNO"] = PROD_REG_EMPNO;
                    source_Remove.Tables[0].Rows[i]["DN_DIV"] = DN_DIV;
                    source_Remove.Tables[0].Rows[i]["INSPECT_EMPNO"] = INSPECT_EMPNO;
                    source_Remove.Tables[0].Rows[i]["RCV_DATE"] = RCV_DATE;
                }

                DataSet source_IMAGE = this.GetDataSourceSchema("CORCD", "BIZCD", "REF_NOTENO", "BLOB$DEF_PHOTO");
                source_IMAGE.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo01_BIZCD.GetValue(),
                    REF_NOTENO,
                    this.pic01_DEF_PHOTO.GetValue()
                );
                
                if (!IsSaveValid(source_SAVE, source_Remove)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source_SAVE);
                //_WSCOM.Save(source_Remove);
                //_WSCOM.Save_IMAGE(source_IMAGE);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"),source_SAVE);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"),source_Remove);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_IMAGE"), source_IMAGE);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("공정불량생산 등록자료 판정이 저장되었습니다.");
                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
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

                DataSet source_QA1061 = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "REF_NOTENO");
                source_QA1061.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo01_BIZCD.GetValue(),
                    this.txt02_REF_NOTENO.GetValue()
                );

                if (!IsRemoveValid(source_QA1061)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source_QA1061);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source_QA1061);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("공정불량생산 등록자료 판정이 삭제 되었습니다.");
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

        private void grd01_QA20123_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20123.SelectedRowIndex;

                if (Row >= this.grd01_QA20123.Rows.Fixed)
                {
                    this.grd(Row);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_QA20123_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd02_QA20123.SelectedRowIndex;

                if (Row >= this.grd02_QA20123.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd02_QA20123.GetValue(Row, "BIZCD").ToString();
                    string NOTENO = this.grd02_QA20123.GetValue(Row, "NOTENO").ToString();
                    string ASSYPNO = this.grd02_QA20123.GetValue(Row, "ASSYPNO").ToString();
                    string DEF_PNO = this.grd02_QA20123.GetValue(Row, "DEF_PNO").ToString();
                    string VENDCD = this.grd02_QA20123.GetValue(Row, "PROD_VENDCD").ToString();
                    string VENDNM = this.grd02_QA20123.GetValue(Row, "PROD_VENDNM").ToString();
                    string DEF_QTY = this.grd02_QA20123.GetValue(Row, "DEF_QTY").ToString();
                    string UNIT = this.grd02_QA20123.GetValue(Row, "UNIT").ToString();
                    string UNITNM = this.grd02_QA20123.GetValue(Row, "UNITNM").ToString();
                    string PROD_REG_EMPNO = this.grd02_QA20123.GetValue(Row, "PROD_REG_EMPNO").ToString();
                    string PROD_REG_EMPNM = this.grd02_QA20123.GetValue(Row, "PROD_REG_EMPNM").ToString();
                    string DN_DIV = this.grd02_QA20123.GetValue(Row, "DN_DIV").ToString();
                    string DN_DIVNM = this.grd02_QA20123.GetValue(Row, "DN_DIVNM").ToString();
                    string INSPECT_EMPNO = this.grd02_QA20123.GetValue(Row, "INSPECT_EMPNO").ToString();
                    string RCV_DATE = this.grd02_QA20123.GetValue(Row, "RCV_DATE").ToString();

                    string PLANT_DIV = this.grd02_QA20123.GetValue(Row, "PLANT_DIV").ToString();        //공장구분

                    this.txt02_NOTENO.SetValue("");
                    this.txt02_REF_NOTENO.SetValue(NOTENO);
                    this.txt02_ASSYPNO.SetValue(ASSYPNO);
                    this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", BIZCD);
                    this.cdx02_DEF_PNO.HEUserParameterSetValue("ASSYPNO", ASSYPNO);
                    this.cdx02_DEF_PNO.SetValue(DEF_PNO);
                    this.txt02_VENDCD.SetValue(VENDCD);
                    this.txt02_VENDNM.SetValue(VENDNM);
                    this.nme02_DEF_QTY.SetValue(DEF_QTY);
                    this.txt02_UNIT.SetValue(UNIT);
                    this.lbl02_UNIT.SetValue(UNITNM);
                    this.txt02_PROD_REG_EMPNO.SetValue(PROD_REG_EMPNO);
                    this.txt02_PROD_REG_EMPNM.SetValue(PROD_REG_EMPNM);
                    this.txt02_DN_DIV.SetValue(DN_DIV);
                    this.txt02_DN_DIVNM.SetValue(DN_DIVNM);
                    this.cdx02_INSPECT_EMPNO.SetValue(INSPECT_EMPNO);
                    this.txt02_RCV_DATE.SetValue(RCV_DATE);

                    this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);    //공장구분

                    this.SELECT_VENDCD_OF_PARTNO();

                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("REF_NOTENO", NOTENO);
                    paramSet.Add("LANG_SET", this.UserInfo.Language);
                    this.BeforeInvokeServer(true);

                    //DataSet source = _WSCOM.Inquery_QA1060_DETAIL(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1060_DETAIL"), paramSet);

                    this.AfterInvokeServer();

                    source.Tables[0].Rows.Add(_CORCD, BIZCD, "", VENDCD, "", "", "", DEF_QTY, "");
                    this.grd03_QA20123.SetValue(source);
                    this.grd03_QA20123.SetValue(1, 0, "N");
                    IMAGE_VIEW(BIZCD, NOTENO);
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

        private void btn01_DEF_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DEF_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_DEF_PHOTO, 0, _DEF_PHOTO.Length);
                    fs.Close();

                    this.pic01_DEF_PHOTO.SetValue(_DEF_PHOTO);
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

        private void btn01_DEF_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_DEF_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_DEF_PNO_ButtonClickAfter(object sender, EventArgs args)
        {
            this.SELECT_VENDCD_OF_PARTNO();
        }

        private void cdx02_DEF_PNO_TextChanged(object sender, EventArgs e)
        {
            _Change_CHK = "Y";
        }

        private void cdx02_INSPECT_EMPNO_TextChanged(object sender, EventArgs e)
        {
            _Change_CHK = "Y";
        }

        private void pic01_DEF_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_DEF_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_DEF_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void txt02_ASSYPNO_ValueChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_INSPECT_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue().ToString());
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source_Save, DataSet source_Remove)
        {
            try
            {
                string DEF_PNO = this.cdx02_DEF_PNO.GetValue().ToString();
                string VENDCD = this.txt02_VENDCD.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();
                string USAGE = this.txt02_USAGE.GetValue().ToString();
                string PROD_REG_EMPNM = this.txt02_PROD_REG_EMPNM.GetValue().ToString();
                string INSPECT_EMPNO = this.cdx02_INSPECT_EMPNO.GetValue().ToString();

                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString();      //공장구분 추가

                if (this.GetByteCount(DEF_PNO) == 0)
                {
                    //MsgBox.Show("PART NO가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_DEF_PNO.Text);
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("생산귀책업체가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_PROD_VENDNM.Text);
                    return false;
                }

                //공장구분 입력 여부 체크
                if (this.GetByteCount(PLANT_DIV) == 0)
                {
                    //MsgBox.Show("공장구분이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_PLANT_DIV.Text);
                    return false;
                }

                if (Int32.Parse(DEF_QTY) <= 0)
                {
                    //MsgBox.Show("총불량수량이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_DEF_QTY.Text);
                    return false;
                }

                if (this.GetByteCount(USAGE) == 0)
                {
                    //MsgBox.Show("Usage가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_USAGE.Text);
                    return false;
                }

                if (this.GetByteCount(PROD_REG_EMPNM) == 0)
                {
                    //MsgBox.Show("생산작업자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_WORK_EMPNO.Text);
                    return false;
                }

                if (this.GetByteCount(INSPECT_EMPNO) == 0)
                {
                    //MsgBox.Show("검사원이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_INSPECT_EMPNO.Text);
                    return false;
                }

                if (_Change_CHK == "Y")
                {
                    if (this.grd03_QA20123.Rows.Count - 1 < 1)
                    {
                        //MsgBox.Show("판정 리스트의 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-016");
                        return false;
                    }
                }
                else
                {
                    if (source_Remove.Tables[0].Rows.Count < 1 && source_Save.Tables[0].Rows.Count < 1)
                    {
                        //MsgBox.Show("변경된 판정 데이터가 없어 저장할 수 없습니다.");
                        MsgCodeBox.Show("QA00-017");
                        return false;
                    }
                }

                int TOTAL = 0;
                for (int i = 1; i < this.grd03_QA20123.Rows.Count; i++)
                {
                    if (this.grd03_QA20123.GetValue(i, 0).ToString() != "D")
                    {
                        TOTAL = TOTAL + Int32.Parse(this.grd03_QA20123.GetValue(i, "DEF_QTY").ToString());
                    }
                }

                if (TOTAL != Int32.Parse(DEF_QTY))
                {
                    //MsgBox.Show("판정 리스트의 불량 수량 합계가 총불량수량과 상이하여 저장할수 없습니다.");
                    MsgCodeBox.Show("QA00-018");
                    return false;
                }

                for (int i = 0; i < source_Save.Tables[0].Rows.Count; i++)
                {
                    if (this.GetByteCount(source_Save.Tables[0].Rows[i]["VENDCD"].ToString()) == 0)
                    {
                        //MsgBox.Show("판정 리스트의 결정귀책업체 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-019");
                        return false;
                    }

                    if (this.GetByteCount(source_Save.Tables[0].Rows[i]["IMPUT_DIVCD"].ToString()) == 0)
                    {
                        //MsgBox.Show("판정 리스트의 귀책구분 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-020");
                        return false;
                    }

                    if (this.GetByteCount(source_Save.Tables[0].Rows[i]["DEF_QTY"].ToString()) == 0)
                    {
                        //MsgBox.Show("판정 리스트의 불량수량 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-021");
                        return false;
                    }

                    if (this.GetByteCount(source_Save.Tables[0].Rows[i]["MAT_REUSE_YN"].ToString()) == 0)
                    {
                        //MsgBox.Show("판정 리스트의 재사용유무 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-022");
                        return false;
                    }
                }

                for (int i = 0; i < source_Remove.Tables[0].Rows.Count; i++)
                {
                    if (this.GetByteCount(source_Remove.Tables[0].Rows[i]["NOTENO"].ToString()) == 0)
                    {
                        //MsgBox.Show("판정 리스트의 번호 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-023");
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

        private bool IsRemoveValid(DataSet source)
        {
            try
            {
                if (this.GetByteCount(this.txt02_REF_NOTENO.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("판정 리스트의 번호 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("QA00-023");
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
                this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEUserParameterSetValue("ASSYPNO", this.txt02_ASSYPNO.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                //if (this.cbo01_BIZCD.GetValue().Equals("5220"))    //2013.04.18 공장구분 기본값 설정
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

        private void SELECT_VENDCD_OF_PARTNO()
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string PARTNO = this.cdx02_DEF_PNO.GetValue().ToString();
                string ASSYPNO = this.txt02_ASSYPNO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("ASSYPNO", ASSYPNO);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_VENDCD_OF_PARTNO(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VENDCD_OF_PARTNO"), paramSet);

                this.txt02_VINCD_ITEMCD.SetValue("Vehicle : " + source.Tables[0].Rows[0]["VINCD"].ToString() + " / Item : " + source.Tables[0].Rows[0]["ITEMCD"].ToString());
                this.txt02_USAGE.SetValue(source.Tables[0].Rows[0]["ACM_USG"].ToString());

                HEParameterSet paramSet_VENDCD = new HEParameterSet();
                paramSet_VENDCD.Add("CORCD", _CORCD);
                paramSet_VENDCD.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet_VENDCD.Add("PARTNO", PARTNO);
                paramSet_VENDCD.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source = _WSCOMBOBOX.Inquery_VENDCD(paramSet_VENDCD);
                DataSet combo_source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_VENDCD"), paramSet_VENDCD);

                this.AfterInvokeServer();

                this.grd03_QA20123.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source.Tables[0], "VENDCD");
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
        
        private void grd(int Row)
        {
            try
            {
                this.BtnReset_Click(null, null);

                this.BeforeInvokeServer(true);

                string BIZCD = this.grd01_QA20123.GetValue(Row, "BIZCD").ToString();
                string NOTENO = this.grd01_QA20123.GetValue(Row, "NOTENO").ToString();
                string REF_NOTENO = this.grd01_QA20123.GetValue(Row, "REF_NOTENO").ToString();

                HEParameterSet paramSet_QA1061 = new HEParameterSet();
                paramSet_QA1061.Add("CORCD", _CORCD);
                paramSet_QA1061.Add("BIZCD", BIZCD);
                paramSet_QA1061.Add("RCV_DATE", "");
                paramSet_QA1061.Add("VENDCD", "");
                paramSet_QA1061.Add("NOTENO", REF_NOTENO);
                paramSet_QA1061.Add("LANG_SET", _LANG_SET);

                //DataSet source_QA1061 = _WSCOM.Inquery_QA1061(paramSet_QA1061);
                DataSet source_QA1061 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1061"), paramSet_QA1061);

                string ASSYPNO = this.grd01_QA20123.GetValue(Row, "ASSYPNO").ToString();
                string DEF_PNO = this.grd01_QA20123.GetValue(Row, "DEF_PNO").ToString();
                string VENDCD = source_QA1061.Tables[0].Rows[0]["PROD_VENDCD"].ToString();
                string VENDNM = source_QA1061.Tables[0].Rows[0]["PROD_VENDNM"].ToString();
                string DEF_QTY = source_QA1061.Tables[0].Rows[0]["DEF_QTY"].ToString();
                string UNIT = source_QA1061.Tables[0].Rows[0]["UNIT"].ToString();
                string UNITNM = source_QA1061.Tables[0].Rows[0]["UNITNM"].ToString();
                string PROD_REG_EMPNO = source_QA1061.Tables[0].Rows[0]["PROD_REG_EMPNO"].ToString();
                string PROD_REG_EMPNM = source_QA1061.Tables[0].Rows[0]["PROD_REG_EMPNM"].ToString();
                string DN_DIV = source_QA1061.Tables[0].Rows[0]["DN_DIV"].ToString();
                string DN_DIVNM = source_QA1061.Tables[0].Rows[0]["DN_DIVNM"].ToString();
                string INSPECT_EMPNO = this.grd01_QA20123.GetValue(Row, "INSPECT_EMPNO").ToString();
                string RCV_DATE = this.grd01_QA20123.GetValue(Row, "RCV_DATE").ToString();

                string PLANT_DIV = source_QA1061.Tables[0].Rows[0]["PLANT_DIV"].ToString(); //공장구분 추가

                this.txt02_NOTENO.SetValue(NOTENO);
                this.txt02_REF_NOTENO.SetValue(REF_NOTENO);
                this.txt02_ASSYPNO.SetValue(ASSYPNO);
                this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", BIZCD);
                this.cdx02_DEF_PNO.HEUserParameterSetValue("ASSYPNO", ASSYPNO);
                this.cdx02_DEF_PNO.SetValue(DEF_PNO);
                this.txt02_VENDCD.SetValue(VENDCD);
                this.txt02_VENDNM.SetValue(VENDNM);
                this.nme02_DEF_QTY.SetValue(DEF_QTY);
                this.txt02_UNIT.SetValue(UNIT);
                this.lbl02_UNIT.SetValue(UNITNM);
                this.txt02_PROD_REG_EMPNO.SetValue(PROD_REG_EMPNO);
                this.txt02_PROD_REG_EMPNM.SetValue(PROD_REG_EMPNM);
                this.txt02_DN_DIV.SetValue(DN_DIV);
                this.txt02_DN_DIVNM.SetValue(DN_DIVNM);
                this.cdx02_INSPECT_EMPNO.SetValue(INSPECT_EMPNO);
                this.txt02_RCV_DATE.SetValue(RCV_DATE);

                this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);            //공장구분 추가

                HEParameterSet paramSet_QA1060_DETAIL = new HEParameterSet();
                paramSet_QA1060_DETAIL.Add("CORCD", _CORCD);
                paramSet_QA1060_DETAIL.Add("BIZCD", BIZCD);
                paramSet_QA1060_DETAIL.Add("REF_NOTENO", REF_NOTENO);
                paramSet_QA1060_DETAIL.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source_QA1060_DETAIL = _WSCOM.Inquery_QA1060_DETAIL(paramSet_QA1060_DETAIL);
                DataSet source_QA1060_DETAIL = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1060_DETAIL"), paramSet_QA1060_DETAIL);
                this.grd03_QA20123.SetValue(source_QA1060_DETAIL);
                this.AfterInvokeServer();
                this.SELECT_VENDCD_OF_PARTNO();
                IMAGE_VIEW(BIZCD, REF_NOTENO);
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

        private void IMAGE_VIEW(string BIZCD, string REF_NOTENO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("REF_NOTENO", REF_NOTENO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count != 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    if ((dr["DEF_PHOTO"]) != System.DBNull.Value)
                    {
                        byte[] _DEF_PHOTO = null;
                        _DEF_PHOTO = (byte[])(dr["DEF_PHOTO"]);
                        this.pic01_DEF_PHOTO.SetValue(_DEF_PHOTO);
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
        
        #endregion

    }
}
