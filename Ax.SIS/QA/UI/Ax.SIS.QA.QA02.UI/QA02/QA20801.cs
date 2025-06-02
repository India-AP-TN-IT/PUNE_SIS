#region ▶ Description & History
/* 
 * 프로그램명 : QA20801 관리 ITEM 기준 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
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

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b> 예방관리 ITEM 기준 등록</b>
    /// - 작 성 자 : 배명희<br />
    /// - 작 성 일 : 2014-10-06<br />
    /// </summary>
    public partial class QA20801 : AxCommonBaseControl
    {
        #region [필드에 대한 정의]
        
        private AxClientProxy _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;

        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        private string PAKAGE_NAME = "APG_QA20801";
        #endregion

        #region [초기화 설정에 대한 정의]

        public QA20801()
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

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();
                
                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("VENDNM");// "업체명";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                #endregion

                #region [콤보상자 세팅]

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.Enabled = (this.UserInfo.IsAdmin == "Y" ? true : false);
                this.cbo02_BIZCD.Enabled = (this.UserInfo.IsAdmin == "Y" ? true : false);

                //사용여부
                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_USE_YN.SetValue("Y"); //디폴트 yes 선택
                this.cbo02_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
               
                //측정단위
                HEParameterSet paramSet_MEAS_UNIT = new HEParameterSet();
                paramSet_MEAS_UNIT.Add("CLASS_ID", "FR");
                paramSet_MEAS_UNIT.Add("OBJECT_ID", "");
                paramSet_MEAS_UNIT.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD(paramSet_MEAS_UNIT);
                DataSet combo_source_MEAS_UNIT = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD"), paramSet_MEAS_UNIT);
                this.cbo02_MEAS_UNIT.DataBind(combo_source_MEAS_UNIT.Tables[0]);
                this.cbo02_MEAS_UNIT.DropDownStyle = ComboBoxStyle.DropDownList;


                //점검항목
                HEParameterSet paramSet_CHECK_ITEMCD = new HEParameterSet();
                paramSet_CHECK_ITEMCD.Add("CLASS_ID", "QQ");
                paramSet_CHECK_ITEMCD.Add("OBJECT_ID", "");
                paramSet_CHECK_ITEMCD.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD(paramSet_MEAS_UNIT);
                DataSet combo_source_CHECK_ITEMCD = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD"), paramSet_CHECK_ITEMCD);
                this.cbo02_CHECK_ITEMCD.DataBind(combo_source_CHECK_ITEMCD.Tables[0]);
                this.cbo02_CHECK_ITEMCD.DropDownStyle = ComboBoxStyle.DropDownList;


                //smis 전송대상
                this.cbo02_SMIS_TRANS.DataBind(combo_source_USE_YN, false);
                this.cbo02_SMIS_TRANS.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_SMIS_TRANS.SetValue("N"); //디폴트 yes 선택

                //HKMC유형(H: HMC, K: KIA)
                DataTable combo_source_HKMC = AxFlexGrid.GetDataSourceSchema("CODE", "NAME").Tables[0];                
                combo_source_HKMC.Rows.Add("H", "HMC");
                combo_source_HKMC.Rows.Add("K", "KIA");
                this.cbo02_SMIS_COMPANYTYPE.DataBind(combo_source_HKMC, true);
                this.cbo02_SMIS_COMPANYTYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                //라인코드
                this.txt02_SMIS_LINECD.SetValid(2, AxTextBox.TextType.UAlphabet);
                //공정코드
                this.txt02_SMIS_PROCESSCD.SetValid(2, AxTextBox.TextType.UAlphabet);
                //세부공정코드
                this.txt02_SMIS_EQPCD.SetValid(2, AxTextBox.TextType.UAlphabet);
                //부품코드
                this.txt02_SMIS_ITEMCD.SetValid(40, AxTextBox.TextType.UAlphabet);
                //중점관리항목코드
                this.txt02_SMIS_PMFCD.SetValid(6, AxTextBox.TextType.UAlphabet);
                //중점관리항목세부코드
                this.txt02_SMIS_PMFSUBCD.SetValid(3, AxTextBox.TextType.UAlphabet);

                DataTable source_SMIS_TRANS = AxFlexGrid.GetDataSourceSchema("CODE", "NAME").Tables[0];
                source_SMIS_TRANS.Rows.Add("Y", "●");
                source_SMIS_TRANS.Rows.Add("N", "");
                #endregion

                #region [그리드 세팅]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "관리번호", "SERIAL", "MGRTNO");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종",     "VINCD",        "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "점검항목", "CHECK_ITEMCD", "CHECK_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "색상",     "COLOR",        "CLR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "GRADE",    "GR",           "GRADE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "칼라코드", "COLORCD",      "COLORCD");                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "업체명",   "VENDCD",       "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "규격",     "STANDARD",     "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "규격이하", "STD_UNDER",    "STD_UNDER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 170, "주의관찰", "OBSERVED",     "OBSERVED");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "관리양호", "MGT_GOOD",     "MGT_GOOD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "규격이상", "STD_OVER",     "STD_OVER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "측정단위", "MEAS_UNITCD",  "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "SMIS전송대상", "SMIS_TRANS", "SMIS_TRANS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "사용여부", "USE_YN",       "USEYN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적용일자", "APP_DATE",     "APP_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "비고",     "REMARK",       "REMARK");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "APP_DATE");
                //그리드 컬럼 헤더 배경색 
                this.grd01.Styles.Add("csMGT_GOOD");
                this.grd01.Styles.Add("csOBSERVED");
                this.grd01.Styles.Add("csMGT_OUT");

                //그리드 콤보박스 설정
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_MEAS_UNIT.Tables[0], "MEAS_UNITCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_CHECK_ITEMCD.Tables[0], "CHECK_ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_SMIS_TRANS, "SMIS_TRANS");
                this.grd01.Cols["MEAS_UNITCD"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.Cols["VINCD"].TextAlign = TextAlignEnum.CenterCenter;

                
                #endregion


                //범위값 관련
                this.heLabel1.BackColor = Color.White;
                this.heLabel2.BackColor = Color.White;
                this.heLabel3.BackColor = Color.White;
                this.heLabel4.BackColor = Color.White;

                this.nme02_STD_UNDER_FROM.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_STD_UNDER_FROM.DataType = typeof(float);
                this.nme02_STD_UNDER_FROM.CustomFormat = "#,###.00";

                this.nme02_STD_UNDER_TO.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_STD_UNDER_TO.DataType = typeof(float);
                this.nme02_STD_UNDER_TO.CustomFormat = "#,###.00";

                this.nme02_OBSERVED_FROM.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_OBSERVED_FROM.DataType = typeof(float);
                this.nme02_OBSERVED_FROM.CustomFormat = "#,###.00";

                this.nme02_OBSERVED_TO.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_OBSERVED_TO.DataType = typeof(float);
                this.nme02_OBSERVED_TO.CustomFormat = "#,###.00";

                this.nme02_MGT_GOOD_FROM.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_MGT_GOOD_FROM.DataType = typeof(float);
                this.nme02_MGT_GOOD_FROM.CustomFormat = "#,###.00";

                this.nme02_MGT_GOOD_TO.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_MGT_GOOD_TO.DataType = typeof(float);
                this.nme02_MGT_GOOD_TO.CustomFormat = "#,###.00";

                this.nme02_STD_OVER_FROM.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_STD_OVER_FROM.DataType = typeof(float);
                this.nme02_STD_OVER_FROM.CustomFormat = "#,###.00";

                this.nme02_STD_OVER_TO.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_STD_OVER_TO.DataType = typeof(float);
                this.nme02_STD_OVER_TO.CustomFormat = "#,###.00";


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.SetRequired(lbl02_SAUP, lbl02_SMIS_TRANS);

                //this.cbo01_USE_YN.SetValue("Y");

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
                _SERIAL = "";
             
                this.cbo02_BIZCD.SetValue(_BIZCD);
                if (this.UserInfo.IsAdmin == "Y")
                    this.cbo02_BIZCD.SetReadOnly(false);

                this.cdx02_VENDCD.Initialize();               
                
                this.cbo02_USE_YN.SetValue("Y");
                this.txt02_STANDARD.Initialize();                
                this.cdx02_VINCD.Initialize();

                this.nme02_STD_UNDER_FROM.Initialize();
                this.nme02_STD_UNDER_TO.Initialize();

                this.cbo02_CHECK_ITEMCD.Initialize();
                
                this.nme02_OBSERVED_FROM.Initialize();
                this.nme02_OBSERVED_TO.Initialize();

                this.txt02_COLOR.Initialize();
                this.nme02_MGT_GOOD_FROM.Initialize();
                this.nme02_MGT_GOOD_TO.Initialize();

                this.txt02_GR.Initialize();
                this.nme02_STD_OVER_FROM.Initialize();
                this.nme02_STD_OVER_TO.Initialize();

                this.txt02_COLORCD.Initialize();
                this.cbo02_MEAS_UNIT.Initialize();

                this.dte02_APP_DATE.Initialize();
                this.txt02_REMARK.Initialize();


                this.cbo02_SMIS_TRANS.SetValue("N");                
                this.cbo02_SMIS_COMPANYTYPE.Initialize();
                this.txt02_SMIS_LINECD.Initialize();
                this.txt02_SMIS_PROCESSCD.Initialize();
                this.txt02_SMIS_EQPCD.Initialize();
                this.txt02_SMIS_ITEMCD.Initialize();
                this.txt02_SMIS_PMFCD.Initialize();
                this.txt02_SMIS_PMFSUBCD.Initialize();
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
            try
            {
                string CORCD        = this._CORCD;
                string BIZCD        = this._BIZCD;
                string VINCD        = this.cdx01_VINCD.GetValue().ToString();
                string VENDCD       = this.cdx01_VENDCD.GetValue().ToString();
                string USE_YN       = this.cbo01_USE_YN.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",        CORCD);
                set.Add("BIZCD",        BIZCD);
                set.Add("VINCD",        VINCD);
                set.Add("VENDCD",       VENDCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("LANG_SET",     _LANG_SET);
                set.Add("USER_ID",      this.UserInfo.UserID);
                set.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);
                
                //관리ITEM 기준 조회
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();
                //관리기준 범례 조회
                this.Query_CD4160(CORCD, BIZCD);
                
                

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
       /// 저장시 입력한 관리ITEM 기준 정보를 저장한다.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsSaveValid()) return;

                HEParameterSet param = new HEParameterSet();
                param.Add("LANG_SET", this.UserInfo.Language);

                if (_SERIAL.Length == 0)
                    _SERIAL = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SERIAL"), param).Tables[0].Rows[0]["SERIAL"].ToString();
                

                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SERIAL", "VENDCD", 
                                                    "REMARK", "USE_YN", "STANDARD", "APP_DATE", 
                                                    "VINCD", "STD_UNDER_FROM", "STD_UNDER_TO", 
                                                    "CHECK_ITEMCD", "CHECK_ITEMNM", "OBSERVED_FROM", "OBSERVED_TO", 
                                                    "COLOR", "MGT_GOOD_FROM", "MGT_GOOD_TO", 
                                                    "GR", "STD_OVER_FROM", "STD_OVER_TO", 
                                                    "COLORCD", "MEAS_UNITCD", "USER_ID", "PLANT_DIV",
                                                    "SMIS_TRANS", "SMIS_COMPANYTYPE", "SMIS_LINECD", "SMIS_PROCESSCD",
                                                    "SMIS_EQPCD", "SMIS_ITEMCD", "SMIS_PMFCD", "SMIS_PMFSUBCD");

                string CORCD = _CORCD;
                string BIZCD = _BIZCD;
                string SERIAL = _SERIAL;
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string REMARK = this.txt02_REMARK.GetValue().ToString();
                string USE_YN = this.cbo02_USE_YN.GetValue().ToString();
                string STANDARD = this.txt02_STANDARD.GetValue().ToString();
                string APP_DATE = this.dte02_APP_DATE.GetDateText().ToString();

                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string STD_UNDER_FROM = this.nme02_STD_UNDER_FROM.GetDBValue().ToString();
                string STD_UNDER_TO = this.nme02_STD_UNDER_TO.GetDBValue().ToString();

                string CHECK_ITEMCD = this.cbo02_CHECK_ITEMCD.GetValue().ToString();
                string CHECK_ITEMNM = this.cbo02_CHECK_ITEMCD.Text;
                string OBSERVED_FROM = this.nme02_OBSERVED_FROM.GetDBValue().ToString();
                string OBSERVED_TO = this.nme02_OBSERVED_TO.GetDBValue().ToString();

                string COLOR = this.txt02_COLOR.GetValue().ToString();
                string MGT_GOOD_FROM = this.nme02_MGT_GOOD_FROM.GetDBValue().ToString();
                string MGT_GOOD_TO = this.nme02_MGT_GOOD_TO.GetDBValue().ToString();

                string GR = this.txt02_GR.GetValue().ToString();
                string STD_OVER_FROM = this.nme02_STD_OVER_FROM.GetDBValue().ToString();
                string STD_OVER_TO = this.nme02_STD_OVER_TO.GetDBValue().ToString();

                string COLORCD = this.txt02_COLORCD.GetValue().ToString();
                string MEAS_UNIT = this.cbo02_MEAS_UNIT.GetValue().ToString();


                string SMIS_TRANS = this.cbo02_SMIS_TRANS.GetValue().ToString(); 
                string SMIS_COMPANYTYPE = this.cbo02_SMIS_COMPANYTYPE.GetValue().ToString(); 
                string SMIS_LINECD = this.txt02_SMIS_LINECD.GetValue().ToString();
                string SMIS_PROCESSCD = this.txt02_SMIS_PROCESSCD.GetValue().ToString();
                string SMIS_EQPCD = this.txt02_SMIS_EQPCD.GetValue().ToString();
                string SMIS_ITEMCD = this.txt02_SMIS_ITEMCD.GetValue().ToString(); 
                string SMIS_PMFCD = this.txt02_SMIS_PMFCD.GetValue().ToString();
                string SMIS_PMFSUBCD = this.txt02_SMIS_PMFSUBCD.GetValue().ToString();

                source.Tables[0].Rows.Add(
                    CORCD, BIZCD, SERIAL, VENDCD, REMARK, USE_YN, STANDARD, APP_DATE, 
                    VINCD, STD_UNDER_FROM, STD_UNDER_TO,
                    CHECK_ITEMCD, CHECK_ITEMNM, OBSERVED_FROM, OBSERVED_TO, 
                    COLOR, MGT_GOOD_FROM, MGT_GOOD_TO, 
                    GR, STD_OVER_FROM, STD_OVER_TO, 
                    COLORCD, MEAS_UNIT, this.UserInfo.UserID, this.cbo01_PLANT_DIV.GetValue().ToString(),
                    SMIS_TRANS, SMIS_COMPANYTYPE, SMIS_LINECD, SMIS_PROCESSCD,
                    SMIS_EQPCD, SMIS_ITEMCD, SMIS_PMFCD, SMIS_PMFSUBCD);

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(SERIAL);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 ITEM 기준 등록정보가 저장되었습니다.");
                MsgCodeBox.Show("QA02-0001");
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
        /// 삭제버튼 클릭시 현재 선택된 관리ITEM 기준 정보를 삭제한다.
        /// (측정결과 없는 항목만 삭제 가능)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsDeleteValid()) return;

                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("SERIAL");
                source.Tables[0].Rows.Add(_SERIAL);

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("선택하신 ITEM 기준 등록정보가 삭제되었습니다.");
                MsgCodeBox.Show("QA02-0002");
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

       //더블클릭시 해당 행의 내용을 하단 관리ITEM 기준 정보에 표시한다.
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;


                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                string SERIAL = this.grd01.GetValue(row, "SERIAL").ToString();


                this.BtnQuery_Click(SERIAL);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //조회조건 사업장  선택값 변경시 조회조건 차종의 입력값 초기화...(왜...하지..??)
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _BIZCD = this.cbo01_BIZCD.GetValue().ToString();

                this.cdx01_VINCD.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [기타 항목]

        /// <summary>
        /// 하단입력컨트롤에 상세 내용 바인딩
        /// </summary>
        /// <param name="SERIAL"></param>
        private void BtnQuery_Click(string SERIAL)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",    _CORCD);
                set.Add("BIZCD",    _BIZCD);
                set.Add("SERIAL",   SERIAL);
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("USER_ID",  this.UserInfo.UserID);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), set);

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                _SERIAL = row["SERIAL"].ToString();
                this.cdx02_VINCD.SetValue(          row["VINCD"]);
                this.cdx02_VENDCD.SetValue(row["VENDCD"]);
                this.txt02_REMARK.SetValue(row["REMARK"]);
                this.cbo02_USE_YN.SetValue(row["USE_YN"]);
                this.txt02_STANDARD.SetValue(row["STANDARD"]);
                this.dte02_APP_DATE.SetValue(row["APP_DATE"]);
                this.cdx02_VINCD.SetValue(row["VINCD"]);
                this.nme02_STD_UNDER_FROM.SetValue(row["STD_UNDER_FROM"]);
                this.nme02_STD_UNDER_TO.SetValue(row["STD_UNDER_TO"]);
                this.cbo02_CHECK_ITEMCD.SetValue(row["CHECK_ITEMCD"]);
                
                this.nme02_OBSERVED_FROM.SetValue(row["OBSERVED_FROM"]);
                this.nme02_OBSERVED_TO.SetValue(row["OBSERVED_TO"]);
                this.txt02_COLOR.SetValue(row["COLOR"]);
                this.nme02_MGT_GOOD_FROM.SetValue(row["MGT_GOOD_FROM"]);
                this.nme02_MGT_GOOD_TO.SetValue(row["MGT_GOOD_TO"]);
                this.txt02_GR.SetValue(row["GR"]);
                this.nme02_STD_OVER_FROM.SetValue(row["STD_OVER_FROM"]);
                this.nme02_STD_OVER_TO.SetValue(row["STD_OVER_TO"]);
                this.txt02_COLORCD.SetValue(row["COLORCD"]);
                this.cbo02_MEAS_UNIT.SetValue(row["MEAS_UNIT"]);
                this.cbo02_BIZCD.SetReadOnly(true);

                this.cbo02_SMIS_TRANS.SetValue(row["SMIS_TRANS"]);
                this.cbo02_SMIS_COMPANYTYPE.SetValue(row["SMIS_COMPANYTYPE"]);
                this.txt02_SMIS_LINECD.SetValue(row["SMIS_LINECD"]);
                this.txt02_SMIS_PROCESSCD.SetValue(row["SMIS_PROCESSCD"]);
                this.txt02_SMIS_EQPCD.SetValue(row["SMIS_EQPCD"]);
                this.txt02_SMIS_ITEMCD.SetValue(row["SMIS_ITEMCD"]);
                this.txt02_SMIS_PMFCD.SetValue(row["SMIS_PMFCD"]);
                this.txt02_SMIS_PMFSUBCD.SetValue(row["SMIS_PMFSUBCD"]);
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
                string VINCD = this.cdx02_VINCD.GetValue().ToString();

                if (VINCD.Length == 0)
                {
                    //MsgBox.Show("차종이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0003");
                    return false;
                }

                if (this.cbo02_USE_YN.ByteCount <= 0)
                {
                    //MsgBox.Show("사용여부가 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0004");
                    return false;
                }
                if (this.txt02_STANDARD.ByteCount <= 0)
                {
                    //MsgBox.Show("규격이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0005");
                    return false;
                }
               

                if (this.nme02_STD_UNDER_FROM.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("규격이하 시작값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0006");
                    return false;
                }
                if (this.nme02_STD_UNDER_TO.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("규격이하 종료값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0007");
                    return false;
                }
                if (this.cbo02_CHECK_ITEMCD.ByteCount <= 0)
                {
                    //MsgBox.Show("점검항목이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0008");
                    return false;
                }
                //if (this.txt02_CHECK_ITEMNM.ByteCount <= 0)
                //{
                //    //MsgBox.Show("점검항목이 입력되지 않았습니다.");
                //    MsgCodeBox.Show("QA02-0008");
                //    return false;
                //}
                if (this.nme02_OBSERVED_FROM.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("주의관찰 시작값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0009");
                    return false;
                }
                if (this.nme02_OBSERVED_TO.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("주의관찰 종료값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0010");
                    return false;
                }
                if (this.txt02_COLOR.ByteCount <= 0)
                {
                    //MsgBox.Show("색상 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0011");
                    return false;
                }
                if (this.nme02_MGT_GOOD_FROM.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("관리양호 시작값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0012");
                    return false;
                }
                if (this.nme02_MGT_GOOD_TO.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("관리양호 종료값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0013");
                    return false;
                }
                if (this.txt02_GR.ByteCount <= 0)
                {
                    //MsgBox.Show("grade가 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0014");
                    return false;
                }
                if (this.nme02_STD_OVER_FROM.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("규격이상 시작값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0015");
                    return false;
                }
                if (this.nme02_STD_OVER_TO.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("규격이상 종료값이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0016");
                    return false;
                }
                if (this.txt02_COLORCD.ByteCount <= 0)
                {
                    //MsgBox.Show("칼라코드가 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0017");
                    return false;
                }

                if (this.cbo02_SMIS_TRANS.ByteCount <= 0)
                { 
                    //MsgBox.Show("smis 전송대상 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_TRANS.Text);
                    return false;
                }

                if (this.cbo02_SMIS_TRANS.GetValue().ToString().Equals("Y"))
                { 
                    //전송대상이 yes이면 그다음 항목들 필수 체크  
                    if (this.cbo02_SMIS_COMPANYTYPE.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_COMPANYTYPE.Text);
                        return false;
                    }
                    if (this.txt02_SMIS_LINECD.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_LINECD.Text);
                        return false;
                    }
                    if (this.txt02_SMIS_PROCESSCD.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_PROCESSCD.Text);
                        return false;
                    }
                    if (this.txt02_SMIS_EQPCD.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_EQPCD.Text);
                        return false;
                    }
                    if (this.txt02_SMIS_ITEMCD.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_ITEMCD.Text);
                        return false;
                    }
                    if (this.txt02_SMIS_PMFCD.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_PMFCD.Text);
                        return false;
                    }
                    if (this.txt02_SMIS_PMFSUBCD.ByteCount <= 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SMIS_PMFSUBCD.Text);
                        return false;
                    }
                }
                
                //if (MsgBox.Show("입력하신 ITEM 기준 등록정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA02-0018", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                string exist;

                if (this.cbo02_BIZCD.Enabled)
                {
                    //MsgBox.Show("삭제할 ITEM 기준 등록정보가 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0019");
                    return false;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL", _SERIAL);
                set.Add("LANG_SET", this.UserInfo.Language);
                DataRow row = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_USED"), set).Tables[0].Rows[0];
                exist = row["EXIST"].ToString();

                if (exist.Equals("Y"))
                {
                    //MsgBox.Show("삭제할 ITEM 기준 등록정보가 사용중이어서 삭제할 수 없습니다.");
                    MsgCodeBox.Show("QA02-0020");
                    return false;
                }

                //if (MsgBox.Show("선택하신 ITEM 기준 등록정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA02-0021", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        #region [관리기준 범례 등록 관련 로직]

        #region [사용자 정의 메서드]

        /// <summary>
        /// 관리기준 범례 조회
        /// </summary>
        /// <param name="corcd"></param>
        /// <param name="bizcd"></param>
        private void Query_CD4160(string corcd, string bizcd)
        {
            HEParameterSet set2 = new HEParameterSet();
            set2.Add("CORCD", corcd);
            set2.Add("BIZCD", bizcd);
            set2.Add("LANG_SET", _LANG_SET);
            set2.Add("USER_ID", this.UserInfo.UserID);
            set2.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            DataSet source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CD4160"), set2);

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
        }

        /// <summary>
        /// Color를 hex코드로 반환
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string GetColorToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        #endregion

        #region [유효성 체크]
        /// <summary>
        /// 관리기준 범례등록 필수값 체크
        /// </summary>
        /// <returns></returns>
        private bool IsSaveValid_CD4160()
        {
            try
            {

                if (this.pnl03_MGT_GOOD_COLOR.BackColor == Color.Transparent)
                {
                    //MsgBox.Show("관리양호 색상이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0022");
                    return false;
                }
                if (this.txt03_MGT_GOOD_CNTT.ByteCount == 0)
                {
                    //MsgBox.Show("관리양호 관리내용이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0023");
                    return false;
                }

                if (this.pnl03_OBSERVED_COLOR.BackColor == Color.Transparent)
                {
                    //MsgBox.Show("주의관찰 색상이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0024");
                    return false;
                }
                if (this.txt03_OBSERVED_CNTT.ByteCount == 0)
                {
                    //MsgBox.Show("주의관찰 관리내용이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0025");
                    return false;
                }
                if (this.pnl03_MGT_OUT_COLOR.BackColor == Color.Transparent)
                {
                    //MsgBox.Show("관리이탈 색상이 선택되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0026");
                    return false;
                }
                if (this.txt03_MGT_OUT_CNTT.ByteCount == 0)
                {
                    //MsgBox.Show("관리이탈 관리내용이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0027");
                    return false;
                }

                if (this.txt03_CORR_REF_WORK.ByteCount == 0)
                {
                    //MsgBox.Show("이상 발생시 업무 대응 기준이 입력되지 않았습니다.");
                    MsgCodeBox.Show("QA02-0028");
                    return false;
                }


                //if (MsgBox.Show("입력하신 관리 기준 범례 등록정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA02-0029", MessageBoxButtons.OKCancel) != DialogResult.OK)
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


        #region [색상선택 버튼 클릭 이벤트]
        /// <summary>
        /// 관리양호 "색상변경"버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn03_CHANGE_MGT_GOOD_COLOR_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.pnl03_MGT_GOOD_COLOR.BackColor = cd.Color;
                Color c = cd.Color;
                
            }
        }

        /// <summary>
        /// 주의관찰 "색상변경"버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn03_CHANGE_OBSERVED_COLOR_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.pnl03_OBSERVED_COLOR.BackColor = cd.Color;
                Color c = cd.Color;

            }
        }

        /// <summary>
        /// 관리이탈 "색상변경"버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn03_CHANGE_MGT_OUT_COLOR_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.pnl03_MGT_OUT_COLOR.BackColor = cd.Color;
                Color c = cd.Color;

            }
        }

        #endregion

        #region [저장 버튼 클릭 이벤트]

        private void btn03_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (!IsSaveValid_CD4160()) return;

                //rtn = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                string CORCD = _CORCD;
                string BIZCD = _BIZCD;



                string MGT_GOOD_COLOR = this.GetColorToHex(this.pnl03_MGT_GOOD_COLOR.BackColor);
                string OBSERVED_COLOR = this.GetColorToHex(this.pnl03_OBSERVED_COLOR.BackColor);
                string MGT_OUT_COLOR = this.GetColorToHex(this.pnl03_MGT_OUT_COLOR.BackColor);

                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", 
                                                "MGT_GOOD_COLOR", "MGT_GOOD_CNTT",
                                                "OBSERVED_COLOR", "OBSERVED_CNTT",
                                                "MGT_OUT_COLOR", "MGT_OUT_CNTT", 
                                                "CORR_REF_WORK", "USER_ID", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    CORCD, BIZCD, 
                    MGT_GOOD_COLOR, this.txt03_MGT_GOOD_CNTT.GetValue(),
                    OBSERVED_COLOR, this.txt03_OBSERVED_CNTT.GetValue(),
                    MGT_OUT_COLOR, this.txt03_MGT_OUT_CNTT.GetValue(),
                    this.txt03_CORR_REF_WORK.GetValue(), this.UserInfo.UserID, this.cbo01_PLANT_DIV.GetValue().ToString()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_CD4160"), source);
                this.AfterInvokeServer();
                              
                //MsgBox.Show("입력하신 관리 기준 범례 등록 정보가 저장되었습니다.");
                MsgCodeBox.Show("QA02-0030");

                //재조회
                this.Query_CD4160(CORCD, BIZCD);
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

      
        #endregion

        private void btn01_SMIS_HISTORY_Click(object sender, EventArgs e)
        {
            if (_SERIAL.Length != 0)
            {
                QA20801P1 frm = new QA20801P1(_SERIAL, this.GetLabel("QA20801P1"));
                this.ShowPopup(frm);
            }
        }
    }
}
