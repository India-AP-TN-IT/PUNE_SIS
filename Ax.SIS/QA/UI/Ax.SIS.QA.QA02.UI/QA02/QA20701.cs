#region ▶ Description & History
/* 
 * 프로그램명 : QA20701 X-BAR R 관리 ITEM 기준 등록
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
using System.IO;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>X BAR R 관리 ITEM 기준 등록</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-03-30 오후 5:29:52<br />
    /// </summary>
    public partial class QA20701 : AxCommonBaseControl
    {
        //private IQA20701 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20701";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [초기화 작업에 대한 정의]

        public QA20701()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20701>("QA02", "QA20701.svc", "CustomBinding");
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
                this.groupBox3.Text = this.GetLabel("QA20701_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20701_MSG2");

                //btn01_PHOTO_INSERT.Text = this.GetLabel("INSPECT_STD_PHOTO_INSERT");
                //btn01_PHOTO_DELETE.Text = this.GetLabel("INSPECT_STD_PHOTO_DELETE");

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                //this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                #region [코드박스 세팅]

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

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD"); //"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ITEMCD.PopupTitle = this.GetLabel("ITEMCD"); //"품목코드";
                this.cdx02_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx02_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx02_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_ITEMCD.SetCodePixedLength();

                this.cdx02_MEAS_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_MEAS_ITEMCD.PopupTitle = this.GetLabel("ITEMNM3"); //"품명";
                this.cdx02_MEAS_ITEMCD.CodeParameterName = "CODE";
                this.cdx02_MEAS_ITEMCD.NameParameterName = "NAME";
                this.cdx02_MEAS_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_MEAS_ITEMCD.HEParameterAdd("BIZCD", _BIZCD);
                this.cdx02_MEAS_ITEMCD.HEParameterAdd("VINCD", this.cdx02_VINCD.GetValue());
                this.cdx02_MEAS_ITEMCD.HEParameterAdd("ITEMCD", this.cdx02_ITEMCD.GetValue());
                this.cdx02_MEAS_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("VENDNM"); //"업체명";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VENDCD2.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD2.PopupTitle = this.GetLabel("VENDNM2"); //"측정업체명";
                this.cdx02_VENDCD2.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD2.NameParameterName = "VENDNM";
                this.cdx02_VENDCD2.HEParameterAdd("LANG_SET", _LANG_SET);

                #endregion

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = this.UserInfo.IsAdmin == "Y";
                this.cbo02_BIZCD.Enabled = this.UserInfo.IsAdmin == "Y";

                //PLANT
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo02_PLANT_DIV.SetReadOnly(true);


                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_VAN_IF_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_VAN_IF_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                HEParameterSet paramSet_INSPECT_UNIT = new HEParameterSet();
                paramSet_INSPECT_UNIT.Add("CLASS_ID", "IU");
                paramSet_INSPECT_UNIT.Add("GROUPCD",  "BCD");
                paramSet_INSPECT_UNIT.Add("LANG_SET", _LANG_SET);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", _LANG_SET);


                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD_GROUP(paramSet_INSPECT_UNIT);
                DataSet combo_source_MEAS_UNIT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD_GROUP"), paramSet_INSPECT_UNIT);

                //DataSet combo_source_TYPENM = _WSCOMBOBOX.Inquery_TYPENM();
                DataSet combo_source_TYPENM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPENM"), paramSet);

                this.cbo02_MEAS_UNIT.DataBind(combo_source_MEAS_UNIT.Tables[0]);
                this.cbo02_MEAS_UNIT.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo02_USE_OBJECT.DataBind("PS", false);
                this.cbo02_USE_OBJECT.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_USE_OBJECT.DataBind("PS");
                this.cbo01_USE_OBJECT.DropDownStyle = ComboBoxStyle.DropDownList;

                this.pic02_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 040, "순번", "SERIAL", "SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "품목", "ITEMCD", "ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명", "MEAS_ITEMCD", "ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "부위사진", "STD_PHOTO", "STD_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "측정기", "MEAS_INST", "MEAS_INST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "하한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "상한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "측정단위", "MEAS_UNIT", "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "업체명", "VENDCD", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "측정업체명", "VENDCD2", "VENDNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "측정자", "MEAS_POINT", "MEAS_POINT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "Gauge R&R",    "GATE_RNR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "시료수", "SAMPLE_CNT", "SAMPLE_CNT"); //*체크
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "구분", "USE_OBJECT", "DIVISION"); 
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "VAN 등록여부", "VAN_IF_YN", "VAN_IF_YN"); //*체크
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "사용유무", "USE_YN", "USE_YN3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "비고", "REMARK", "REMARK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "등록일자", "REG_DATE", "REG_DATE");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 0, "공장구분", "PLANT_DIV");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "PS", "USE_OBJECT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_TYPENM.Tables[0], "MEAS_ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_MEAS_UNIT.Tables[0], "MEAS_UNIT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetVendCD(this.UserInfo.CorporationCode).Tables[0], "VENDCD2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STANDARD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STD_MIN_MEAS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STD_MAX_MEAS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "GATE_RNR");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "REG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SAMPLE_CNT");
                this.grd01.Cols["STANDARD"].Format = "###,###,###,###.##";
                this.grd01.Cols["STD_MIN_MEAS"].Format = "###,###,###,###.##";
                this.grd01.Cols["STD_MAX_MEAS"].Format = "###,###,###,###.##";
                this.grd01.Cols["GATE_RNR"].Format = "###,###,###,###.##";

                this.lbl02_STD_PHOTO.Value = this.GetLabel("STD_PHOTO_LINE");// "부위\r\n사진";

                this.SetRequired(lbl02_BIZNM, lbl02_VIN, lbl02_ITEM, lbl02_ITEMNM3);

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
                _SERIAL = "";
                this.txt02_MEAS_INST.Initialize();
                this.txt02_MEAS_POINT.Initialize();
                this.txt02_MGRT_ITEMNM.Initialize();
                this.txt02_REMARK.Initialize();
                this.cbo02_BIZCD.SetValue(_BIZCD);
                this.cbo02_MEAS_UNIT.Initialize();
                this.cbo02_USE_YN.SetValue("Y");
                this.cbo02_VAN_IF_YN.SetValue("Y");
                this.nme02_SAMPLE_CNT.Value = 5;
                this.cdx02_VINCD.Initialize();
                this.cdx02_ITEMCD.Initialize();
                this.cdx02_MEAS_ITEMCD.Initialize();
                this.cdx02_VENDCD.Initialize();
                this.cdx02_VENDCD2.Initialize();
                this.dte02_REG_DATE.Initialize();
                this.nme02_GATE_RNR.Initialize();
                this.nme02_STANDARD.Initialize();
                this.nme02_STD_MAX_MEAS.Initialize();
                this.nme02_STD_MIN_MEAS.Initialize();
                this.pic02_STD_PHOTO.Initialize();

                if (this.UserInfo.IsAdmin == "Y")
                    this.cbo02_BIZCD.SetReadOnly(false);
                this.cdx02_VINCD.SetReadOnly(false);
                this.cdx02_ITEMCD.SetReadOnly(false);
                this.cdx02_MEAS_ITEMCD.SetReadOnly(false);
                this.cbo02_USE_OBJECT.SetValue("PSM");

                if (this.UserInfo.PlantDiv.Equals("U902")) this.cbo02_PLANT_DIV.SetReadOnly(true);
                else this.cbo02_PLANT_DIV.SetReadOnly(false);
                this.cbo02_PLANT_DIV.SetValue(this.cbo01_PLANT_DIV.GetValue());
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
                string USE_OBJECT = this.cbo01_USE_OBJECT.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",        CORCD);
                set.Add("BIZCD",        BIZCD);
                set.Add("VINCD",        VINCD);
                set.Add("ITEMCD",       ITEMCD);
                set.Add("MEAS_ITEMCD",  MEAS_ITEMCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("USE_OBJECT", USE_OBJECT);
                set.Add("PLANT_DIV", PLANT_DIV);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsSaveValid()) return;

                if (_SERIAL.Length == 0)
                {

                    HEParameterSet set = new HEParameterSet();                    
                    set.Add("LANG_SET", this.UserInfo.Language);
                    //_SERIAL = _WSCOM.Inquery_Serial().Tables[0].Rows[0]["SERIAL"].ToString();
                    _SERIAL = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SERIAL"), set).Tables[0].Rows[0]["SERIAL"].ToString();
                }
                string CORCD        = _CORCD;
                string BIZCD        = _BIZCD;
                string SERIAL       = _SERIAL;
                string VINCD        = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD       = this.cdx02_ITEMCD.GetValue().ToString();
                string MEAS_ITEMCD  = this.cdx02_MEAS_ITEMCD.GetValue().ToString();
                string MGRT_ITEMNM  = this.txt02_MGRT_ITEMNM.GetValue().ToString();
                string STANDARD     = this.nme02_STANDARD.GetDBValue().ToString();
                string STD_MIN_MEAS = this.nme02_STD_MIN_MEAS.GetDBValue().ToString();
                string STD_MAX_MEAS = this.nme02_STD_MAX_MEAS.GetDBValue().ToString();
                string GATE_RNR     = this.nme02_GATE_RNR.GetDBValue().ToString();
                string MEAS_UNIT    = this.cbo02_MEAS_UNIT.GetValue().ToString();
                string MEAS_INST    = this.txt02_MEAS_INST.GetValue().ToString();
                string VAN_IF_YN    = this.cbo02_VAN_IF_YN.GetValue().ToString();
                string VENDCD       = this.cdx02_VENDCD.GetValue().ToString();
                string VENDCD2      = this.cdx02_VENDCD2.GetValue().ToString();
                string MEAS_POINT   = this.txt02_MEAS_POINT.GetValue().ToString();
                string REMARK       = this.txt02_REMARK.GetValue().ToString();
                string USE_YN       = this.cbo02_USE_YN.GetValue().ToString();
                Byte[] STD_PHOTO    = (Byte[])this.pic02_STD_PHOTO.GetValue();
                string SAMPLE_CNT   = this.nme02_SAMPLE_CNT.Value.ToString();
                string USE_OBJECT = this.cbo02_USE_OBJECT.GetValue().ToString();
                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString();

                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SERIAL", "VINCD", "ITEMCD", "MEAS_ITEMCD", "MGRT_ITEMNM", "STANDARD", "STD_MIN_MEAS", "STD_MAX_MEAS", "GATE_RNR", "MEAS_UNIT", "MEAS_INST", "VAN_IF_YN", "VENDCD", "VENDCD2", "MEAS_POINT", "REMARK", "USE_YN", "BLOB$STD_PHOTO", "SAMPLE_CNT", "USE_OBJECT", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    CORCD, BIZCD, SERIAL, VINCD, ITEMCD, MEAS_ITEMCD, MGRT_ITEMNM, STANDARD, STD_MIN_MEAS, STD_MAX_MEAS, GATE_RNR, MEAS_UNIT, MEAS_INST, VAN_IF_YN, VENDCD, VENDCD2, MEAS_POINT, REMARK, USE_YN, STD_PHOTO, SAMPLE_CNT, USE_OBJECT, PLANT_DIV
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(SERIAL);

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 ITEM 기준 등록정보가 저장되었습니다.");
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

                DataSet source =
                    AxFlexGrid.GetDataSourceSchema("SERIAL");
                source.Tables[0].Rows.Add(_SERIAL);

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("선택하신 ITEM 기준 등록정보가 삭제되었습니다.");
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

        private void cdx02_MEAS_ITEMCD_ButtonClickBefore(object sender, EventArgs args)
        {               
            this.cdx02_MEAS_ITEMCD.HEUserParameterSetValue("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue());
        }

        private void btn01_PHOTO_REG_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image files (jpg, gif, bmp, png)|*.jpg;*.gif;*.bmp;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic02_STD_PHOTO.SetValue(_PHOTO);
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

        private void btn01_PHOTO_REM_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_STD_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_PARTNO_PHOTO_Click(object sender, EventArgs e)
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

        private void cdx02_VINCD_ITEM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx02_MEAS_ITEMCD.Initialize();

                this.cdx02_MEAS_ITEMCD.HEUserParameterSetValue("CORCD",     _CORCD);
                this.cdx02_MEAS_ITEMCD.HEUserParameterSetValue("BIZCD",     _BIZCD);
                this.cdx02_MEAS_ITEMCD.HEUserParameterSetValue("VINCD",     this.cdx02_VINCD.GetValue());
                this.cdx02_MEAS_ITEMCD.HEUserParameterSetValue("ITEMCD",    this.cdx02_ITEMCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_MEAS_ITEMCD_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                DataRow row = this.cdx02_MEAS_ITEMCD.SelectedPopupValue;
                if(row != null) this.cdx02_VENDCD.SetValue(row["VENDCD"].ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        } 

        #endregion

        #region [기타 항목]

        private void BtnQuery_Click(string SERIAL)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",        SERIAL);
                set.Add("LANG_SET",  this.UserInfo.Language);

                //DataSet source = _WSCOM.Inquery_Detail(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), set);

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                _SERIAL = row["SERIAL"].ToString();
                this.cdx02_VINCD.SetValue(          row["VINCD"]);
                this.cdx02_ITEMCD.SetValue(         row["ITEMCD"]);
                this.cdx02_MEAS_ITEMCD.SetValue(    row["MEAS_ITEMCD"]);
                this.txt02_MGRT_ITEMNM.SetValue(    row["MGRT_ITEMNM"]);
                this.nme02_STANDARD.SetValue(       row["STANDARD"]);
                this.nme02_STD_MIN_MEAS.SetValue(   row["STD_MIN_MEAS"]);
                this.nme02_STD_MAX_MEAS.SetValue(   row["STD_MAX_MEAS"]);
                this.nme02_GATE_RNR.SetValue(       row["GATE_RNR"]);
                this.cbo02_MEAS_UNIT.SetValue(      row["MEAS_UNIT"]);
                this.txt02_MEAS_INST.SetValue(      row["MEAS_INST"]);
                this.cbo02_VAN_IF_YN.SetValue(      row["VAN_IF_YN"]);
                this.cdx02_VENDCD.SetValue(         row["VENDCD"]);
                this.cdx02_VENDCD2.SetValue(        row["VENDCD2"]);
                this.txt02_MEAS_POINT.SetValue(     row["MEAS_POINT"]);
                this.txt02_REMARK.SetValue(         row["REMARK"]);
                this.cbo02_USE_YN.SetValue(         row["USE_YN"]);
                this.nme02_SAMPLE_CNT.Value = int.Parse(row["SAMPLE_CNT"].ToString());
                this.cbo02_USE_OBJECT.SetValue(row["USE_OBJECT"]);
                this.cbo02_PLANT_DIV.SetValue(row["PLANT_DIV"]);

                this.pic02_STD_PHOTO.Initialize();
                if (row["STD_PHOTO"] != System.DBNull.Value)
                    this.pic02_STD_PHOTO.SetValue(      row["STD_PHOTO"]);

                this.cbo02_BIZCD.SetReadOnly(true);
                this.cdx02_VINCD.SetReadOnly(true);
                this.cdx02_ITEMCD.SetReadOnly(true);
                this.cdx02_MEAS_ITEMCD.SetReadOnly(true);
                this.cbo02_PLANT_DIV.SetReadOnly(true);
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
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string MEAS_ITEMCD = this.cdx02_MEAS_ITEMCD.GetValue().ToString();

                if (VINCD.Length == 0)
                {
                    //MsgBox.Show("차종이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_VIN.Text);
                    return false;
                }

                if (ITEMCD.Length == 0)
                {
                    //MsgBox.Show("품목이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ITEM.Text);
                    return false;
                }

                if (MEAS_ITEMCD.Length == 0)
                {
                    //MsgBox.Show("품명이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ITEMNM3.Text);
                    return false;
                }

                //if (MsgBox.Show("입력하신 ITEM 기준 등록정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                string exist1;
                string exist2;

                if (!this.cdx02_VINCD.ReadOnly)
                {
                    //MsgBox.Show("삭제할 ITEM 기준 등록정보가 선택되지 않았습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL", _SERIAL);
                set.Add("LANG_SET", this.UserInfo.Language);

                //DataRow row = _WSCOM.Inquery_Used(set).Tables[0].Rows[0];
                DataRow row = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_USED"), set).Tables[0].Rows[0];
                exist1 = row["EXIST1"].ToString();
                exist2 = row["EXIST2"].ToString();

                if (exist1.Equals("Y") || exist2.Equals("Y"))
                {
                    //MsgBox.Show("삭제할 ITEM 기준 등록정보가 사용중이어서 삭제할 수 없습니다.");
                    MsgCodeBox.Show("QA02-0020");                    
                    return false;
                }
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                //if (MsgBox.Show("선택하신 ITEM 기준 등록정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        } 

        #endregion

    }
}
