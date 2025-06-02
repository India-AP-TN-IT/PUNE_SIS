#region ▶ Description & History
/* 
 * 프로그램명 : QA20712 X-BAR R 관리 결과 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-29      배명희      통합WCF로 변경 
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
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>X BAR R 관리 ITEM 관리 결과 등록</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-03-30 오후 5:29:52<br />
    /// </summary>
    public partial class QA20712 : AxCommonBaseControl
    {
        //private IQA20712 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _SERIAL;
        private bool _FLAG = false;
        private int _SAMPLE_CNT;
        private string _MEAS_UNIT;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20712";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업에 대한 정의 ]

        public QA20712()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20712>("QA02", "QA20712.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                this.groupBox3.Text = this.GetLabel("QA20712_MSG1");
                this.groupBox_main.Text = this.GetLabel("QQA20712_MSG2");
                this.groupBox2.Text = this.GetLabel("QA20712_MSG3");
                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                //this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD"); //"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD"); //"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();

                this.cdx01_MEAS_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_MEAS_ITEMCD.PopupTitle = this.GetLabel("ITEMNM3"); //"품명";
                this.cdx01_MEAS_ITEMCD.CodeParameterName = "CODE";
                this.cdx01_MEAS_ITEMCD.NameParameterName = "NAME";
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("BIZCD", _BIZCD);
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("VINCD", this.cdx01_VINCD.GetValue());
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("ITEMCD", this.cdx01_ITEMCD.GetValue());
                this.cdx01_MEAS_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);

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
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source_MEAS = new DataTable();
                combo_source_MEAS.Columns.Add("CODE");
                combo_source_MEAS.Columns.Add("NAME");
                combo_source_MEAS.Rows.Add("1", "OK");
                combo_source_MEAS.Rows.Add("0", "NG");

                for (int i = 1; i < 21; i++)
                {
                    string nme_name = string.Format("cbo02_METER{0:D2}", i);
                    AxComboBox cbo = (AxComboBox)this.groupBox2.Controls[nme_name];
                    cbo.DataBind(combo_source_MEAS);

                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                }

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
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 000, "순번", "SERIAL", "SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "품목", "ITEMCD", "ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명", "MEAS_ITEMCD", "ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "부위사진", "STD_PHOTO", "STD_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "측정기", "MEAS_INST", "MEAS_INST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 070, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "하한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "상한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "측정단위", "MEAS_UNIT", "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "업체명", "VENDCD", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "측정업체명", "VENDCD2", "VENDNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "측정자", "MEAS_POINT", "MEAS_POINT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "Gauge R&R", "GATE_RNR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "VAN 등록여부", "VAN_IF_YN", "VAN_IF_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "CPK",          "CPK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "판정", "DECISION", "DECISION");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "이슈여부", "ISSUE_YN", "ISSUE_YN");
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

                DateTime dt = DateTime.Now;
                //dt = dt.AddHours(dt.Hour * -1);
                //dt = dt.AddHours(8);
                //dt = dt.AddMinutes(dt.Minute * -1);
                //dt = dt.AddMilliseconds(dt.Millisecond * -1);

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.AllowSorting = AllowSortingEnum.None;

                this.grd02.Cols[0].Width = 100;

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

                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "01", "T_01");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "02", "T_02");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "03", "T_03");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "04", "T_04");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "05", "T_05");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "06", "T_06");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "07", "T_07");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "08", "T_08");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "09", "T_09");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "10", "T_10");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "11", "T_11");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "12", "T_12");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "13", "T_13");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "14", "T_14");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "15", "T_15");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "16", "T_16");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "17", "T_17");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "18", "T_18");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "19", "T_19");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "20", "T_20");

                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 050, "MEAS_NAME", "MEAS_NAME");

                //this.lbl02_DATA.Value = "데\r\n이\r\n터";

                foreach (Control ctl in groupBox2.Controls)
                {
                    if (ctl.Name.Substring(0, 3).Equals("nme"))
                    {
                        ((AxNumericEdit)ctl).DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                        ((AxNumericEdit)ctl).EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                        ((AxNumericEdit)ctl).CustomFormat = "###,###,###,###.##";
                    }
                }

                this.cbo01_USE_YN.SetValue("Y");

                this.SetRequired(lbl02_MEAS_POINT);

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
                if (_FLAG == false)
                {
                    _SERIAL = "";
                    _MEAS_UNIT = "";
                    _SAMPLE_CNT = 5;

                    this.pic02_STD_PHOTO.Initialize();
                    this.dte02_DD.SetValue(string.Format("{0}-01", this.dte01_YYYYMM.GetDateText().Substring(0, 7)));

                    this.Initialize_Nme02();

                    this.initialize_grd02();
                }
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
                string USE_YN       = this.cbo01_USE_YN.GetValue().ToString();
                string YYYYMM       = this.dte01_YYYYMM.GetDateText().Substring(0, 7);
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",        CORCD);
                set.Add("BIZCD",        BIZCD);
                set.Add("VINCD",        VINCD);
                set.Add("ITEMCD",       ITEMCD);
                set.Add("MEAS_ITEMCD",  MEAS_ITEMCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("YYYYMM",       YYYYMM);
                set.Add("PLANT_DIV", PLANT_DIV);
                set.Add("LANG_SET",  this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsSaveValid()) return;

                string SERIAL       = this._SERIAL;
                string MEAS_DATE    = this.dte02_DD.GetDateText().ToString();
                string MEAS_NAME    = this.txt02_MEAS_NAME.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("MEAS_DATE", "SERIAL", "MEAS_SEQ", "MEAS_METER", "MEAS_NAME", "MEAS_TIME");

                for (int i = 1; i <= _SAMPLE_CNT; i++)
                {
                    string dte_name = string.Format("dte02_MEAS_TIME{0:D2}", i);
                    AxDateEdit dte = (AxDateEdit)this.groupBox2.Controls[dte_name];

                    if (_MEAS_UNIT.Equals("IUOKNG"))
                    {
                        string cbo_name = string.Format("cbo02_METER{0:D2}", i);
                        AxComboBox nme = (AxComboBox)this.groupBox2.Controls[cbo_name];

                        if (nme.GetValue().ToString().Length > 0)
                            source.Tables[0].Rows.Add(MEAS_DATE, SERIAL, i, nme.GetValue(), MEAS_NAME, dte.GetValue().ToString().Replace(":", ""));
                    }
                    else
                    {
                        string nme_name = string.Format("nme02_METER{0:D2}", i);
                        AxNumericEdit nme = (AxNumericEdit)this.groupBox2.Controls[nme_name];

                        if (nme.GetValue().ToString().Length > 0 && double.Parse(nme.GetValue().ToString()) > 0)
                            source.Tables[0].Rows.Add(MEAS_DATE, SERIAL, i, nme.GetDBValue(), MEAS_NAME, dte.GetValue().ToString().Replace(":", ""));
                    }
                }

                if (source.Tables[0].Rows.Count == 0) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.InqueryGrid();
                _FLAG = true;
                this.BtnQuery_Click(null, null);
                _FLAG = false;

                //MsgBox.Show("입력하신 측정 데이터 정보가 저장 되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsDeleteValid()) return;

                string SERIAL       = this._SERIAL;
                string MEAS_DATE    = this.dte02_DD.GetDateText().ToString();

                DataSet source = this.GetDataSourceSchema("SERIAL", "MEAS_DATE");
                source.Tables[0].Rows.Add(SERIAL, MEAS_DATE);

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.InqueryGrid();
                this.Initialize_Nme02();

                _FLAG = true;
                this.BtnQuery_Click(null, null);
                _FLAG = false;

                //MsgBox.Show("선택하신 측정 데이터 정보가 삭제 되었습니다.");
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

        #region [컨트롤 이벤트]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                if (e.Button != MouseButtons.Left) return;

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                _SERIAL       = this.grd01.GetValue(row, "SERIAL").ToString();
                _MEAS_UNIT    = this.grd01.GetValue(row, "MEAS_UNIT").ToString();
                _SAMPLE_CNT   = int.Parse(this.grd01.GetValue(row, "SAMPLE_CNT").ToString());

                for (int i = 1; i <= 20; i++)
                {
                    string cbo_name1 = string.Format("cbo02_METER{0:D2}", i);
                    AxComboBox cbo = (AxComboBox)this.groupBox2.Controls[cbo_name1];

                    cbo.Visible = _MEAS_UNIT.Equals("IUOKNG");

                    string nme_name2 = string.Format("nme02_METER{0:D2}", i);
                    AxNumericEdit nme = (AxNumericEdit)this.groupBox2.Controls[nme_name2];

                    nme.Visible = !_MEAS_UNIT.Equals("IUOKNG");

                    if (_MEAS_UNIT.Equals("IUOKNG"))
                        cbo.SetReadOnly(i > _SAMPLE_CNT);
                    else
                        nme.SetReadOnly(i > _SAMPLE_CNT);

                    string dte_name = string.Format("dte02_MEAS_TIME{0:D2}", i);
                    AxDateEdit dte = (AxDateEdit)this.groupBox2.Controls[dte_name];

                    dte.SetReadOnly(i > _SAMPLE_CNT);
                }

                this.InqueryGrid();
                this.InqueryPhoto();
                this.InqueryDetailData(this.dte02_DD.GetDateText().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;

                int row = this.grd02.SelectedRowIndex;
                if (row < this.grd02.Rows.Fixed) return;
                int col = this.grd02.ColSel;

                string date = this.grd02.GetValue(1, col).ToString();

                if (date.Length == 0)
                    this.dte02_DD.SetValue(this.dte01_YYYYMM.GetDateText().Substring(0, 7) + "-01");
                else
                    this.dte02_DD.SetValue(this.dte01_YYYYMM.GetDateText().Substring(0, 5) + date);

                this.txt02_MEAS_NAME.SetValue(this.grd02.GetValue(1, "MEAS_NAME").ToString());
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

        private void dte01_YYYYMM_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string date = string.Format("{0}-01", this.dte01_YYYYMM.GetDateText().Substring(0, 7));
                this.dte02_DD.SetValue(date);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void dte02_DD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool change_month = false;

                string date = this.dte02_DD.GetDateText().ToString();
                change_month = this.dte02_DD.Value.Month != this.dte01_YYYYMM.Value.Month;

                if (change_month)
                {
                    this.dte01_YYYYMM.SetValue(date);
                    Initialize_Nme02();
                }

                this.InqueryDetailData(date);
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

        #endregion

        #region [기타 이벤트]

        private void InqueryGrid()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("YYYYMM",       this.dte01_YYYYMM.GetDateText().Substring(0, 7));
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = new DataSet();

                if (!string.IsNullOrEmpty(_SERIAL))
                {
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.Inquery_Detail_Grid(set);
                    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL_GRID"), set);
                    this.AfterInvokeServer();

                    this.grd02.SetValue(source);
                }
                else
                {
                    initialize_grd02();
                    return;
                }

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.grd02.SetValue(0, 0, this.GetLabel("D_TITLE"));//"시료군");
                    this.grd02.SetValue(1, 0, this.GetLabel("DD"));//"일자");

                    for (int i = 2; i <= _SAMPLE_CNT + 1; i++)
                        this.grd02.SetValue(i, 0, "X" + (i - 1).ToString());

                    this.grd02.SetValue(_SAMPLE_CNT + 2, 0, "X (" + this.GetLabel("AVERAGE") + ")");//평균
                    this.grd02.SetValue(_SAMPLE_CNT + 3, 0, "R (" + this.GetLabel("RANGE") + ")");//범위

                    this.grd02.Rows[1].StyleNew.BackColor = Color.Green;
                    this.grd02.Rows[_SAMPLE_CNT + 2].StyleNew.BackColor = Color.GreenYellow;
                    this.grd02.Rows[_SAMPLE_CNT + 3].StyleNew.BackColor = Color.Yellow;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryPhoto()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL", _SERIAL);
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Photo(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PHOTO"), set);
                this.AfterInvokeServer();

                this.pic02_STD_PHOTO.Initialize();

                if (source.Tables[0].Rows.Count > 0)
                    if (source.Tables[0].Rows[0]["STD_PHOTO"] != System.DBNull.Value)
                        this.pic02_STD_PHOTO.SetValue(source.Tables[0].Rows[0]["STD_PHOTO"]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryDetailData(string MEAS_DATE)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL", _SERIAL);
                set.Add("MEAS_DATE",    MEAS_DATE);
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source = _WSCOM.Inquery_Detail_Data(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL_DATA"), set);

                //if (source.Tables[0].Rows.Count == 0)
                //{
                    this.Initialize_Nme02();
                //    return;
                //}

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];
                
                for (int i = 1; i <= _SAMPLE_CNT; i++)
                {
                    if (_MEAS_UNIT.Equals("IUOKNG"))
                    {
                        string cbo_name = string.Format("cbo02_METER{0:D2}", i);
                        string col_name = string.Format("MEAS_METER{0:D2}", i);
                        AxComboBox cbo = (AxComboBox)this.groupBox2.Controls[cbo_name];

                        cbo.SetValue(row[col_name]);
                    }
                    else
                    {
                        string nme_name = string.Format("nme02_METER{0:D2}", i);
                        string col_name = string.Format("MEAS_METER{0:D2}", i);
                        AxNumericEdit nme = (AxNumericEdit)this.groupBox2.Controls[nme_name];

                        nme.SetValue(row[col_name]);
                    }

                    string dte_name = string.Format("dte02_MEAS_TIME{0:D2}", i);
                    string col_name2 = string.Format("MEAS_TIME{0:D2}", i);
                    AxDateEdit dte = (AxDateEdit)this.groupBox2.Controls[dte_name];

                    if (!row[col_name2].ToString().Equals("") && row[col_name2] != null)
                        dte.SetValue(DateTime.Parse(row[col_name2].ToString().Substring(0, 2) + ":" + row[col_name2].ToString().Substring(2, 2)).ToString("yyyyMMddHHmmss"));
                }

                this.txt02_MEAS_NAME.SetValue(source.Tables[0].Rows[0]["MEAS_NAME"]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Initialize_Nme02()
        {
            try
            {
                this.txt02_MEAS_NAME.Initialize();
                for (int i = 1; i <= 20; i++)
                {
                    string cbo_name1 = string.Format("cbo02_METER{0:D2}", i);
                    AxComboBox cbo = (AxComboBox)this.groupBox2.Controls[cbo_name1];

                    cbo.Initialize();
                    cbo.Visible = _MEAS_UNIT.Equals("IUOKNG");

                    string nme_name2 = string.Format("nme02_METER{0:D2}", i);
                    AxNumericEdit nme = (AxNumericEdit)this.groupBox2.Controls[nme_name2];

                    nme.Initialize();
                    nme.Visible = !_MEAS_UNIT.Equals("IUOKNG");

                    string dte_name1 = string.Format("dte02_MEAS_TIME{0:D2}", i);
                    AxDateEdit dte = (AxDateEdit)this.groupBox2.Controls[dte_name1];

                    dte.Initialize();
                    dte.SetValue(DateTime.Parse("00:00").ToString("yyyyMMddHHmmss"));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
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

                this.grd02.SetValue(0, 0, this.GetLabel("D_TITLE"));
                this.grd02.SetValue(1, 0, this.GetLabel("DD"));
                this.grd02.SetValue(2, 0, "X1");
                this.grd02.SetValue(3, 0, "X2");
                this.grd02.SetValue(4, 0, "X3");
                this.grd02.SetValue(5, 0, "X4");
                this.grd02.SetValue(6, 0, "X5");
                this.grd02.SetValue(7, 0, "X (" + this.GetLabel("AVERAGE") + ")");
                this.grd02.SetValue(8, 0, "R (" + this.GetLabel("RANGE") + ")");

                this.grd02.Rows[1].StyleNew.BackColor = Color.Green;
                this.grd02.Rows[7].StyleNew.BackColor = Color.GreenYellow;
                this.grd02.Rows[8].StyleNew.BackColor = Color.Yellow;
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
                if (_SERIAL.Length == 0)
                {
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                if (GetByteCount(this.txt02_MEAS_NAME.GetValue().ToString()) == 0)
                {
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("MEAS_POINT"));
                    return false;
                }

                //if (MsgBox.Show("입력하신 측정 데이터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
            }

            return false;
        }

        private bool IsDeleteValid()
        {
            try
            {
                if (_SERIAL.Length == 0)
                {
                    //MsgBox.Show("삭제할 X-Bar R 관리 기준 정보가 선택되지 않았습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 측정 데이터 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
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
