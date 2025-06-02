#region ▶ Description & History
/* 
 * 프로그램명 : QA20703 이상발생원인/조치내용 등록
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
using System.IO;
using C1.Win.C1FlexGrid;
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>이상발생원인/조치내용등록</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-03-30 오후 5:29:52<br />
    /// </summary>
    public partial class QA20703 : AxCommonBaseControl
    {
        //private IQA20703 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SEQ;
        private string _SERIAL;
        private byte[] _FILE;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20703";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [초기화 작업에 대한 정의]

        public QA20703()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20703>("QA02", "QA20703.svc", "CustomBinding");
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
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");// "차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();

                this.cdx01_MEAS_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_MEAS_ITEMCD.PopupTitle = this.GetLabel("ITEMNM3");//"품명";
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
                
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 000, "순번", "SERIAL", "SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "품목", "ITEMCD", "ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명", "MEAS_ITEMCD", "ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "부위사진", "STD_PHOTO", "STD_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "측정기", "MEAS_INST", "MEAS_INST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "하한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "상한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "측정단위", "MEAS_UNIT", "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "업체명", "VENDCD", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "측정업체명", "VENDCD2", "VENDNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "측정자", "MEAS_POINT", "MEAS_POINT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "Gauge R&R",    "GATE_RNR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "VAN 등록여부", "VAN_IF_YN", "VAN_IF_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 055, "CPK",          "CPK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "판정", "DECISION", "DECISION");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "이슈여부", "ISSUE_YN", "ISSUE_YN");

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

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "차종", "VINCD", "VIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품목", "ITEMCD", "ITEM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명", "MEAS_ITEMCD", "ITEMNM3");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "일자",             "MEAS_DATE","DD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 000, "순번", "SEQ", "SEQ_NO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 270, "이상발생원인", "ISSUE_CNTT", "ISSUE_CNTT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 270, "조치내용", "MGRT_CNTT", "MGRT_CNTT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "첨부사진", "ATT_PHOTO", "ATT_PHOTO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "첨부파일", "ATT_FILE", "ATT_FILE");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_TYPENM.Tables[0], "MEAS_ITEMCD");
                this.grd02.Cols["MEAS_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "MEAS_DATE");
                

                this.txt02_ATT_FILENAME.SetReadOnly(true);

                this.pic02_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_ATT_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

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
                _SEQ = "";
                _SERIAL = "";

                this.grd02.InitializeDataSource();
                this.pic02_STD_PHOTO.Initialize();

                this.InputBoxReset();
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
                set.Add("PLANT_DIV",    PLANT_DIV);
                set.Add("LANG_SET",     this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

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
                if (!this.IsSaveVaild()) return;

                string MEAS_DATE    = this.dte02_MEAS_DATE.GetDateText().ToString();
                string ISSUE_CNTT	= this.txt02_ISSUE_CNTT.GetValue().ToString();
                string MGRT_CNTT	= this.txt02_MGRT_CNTT.GetValue().ToString();
                string ATT_FILENAME = this.txt02_ATT_FILENAME.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("MEAS_DATE", "ISSUE_CNTT", "MGRT_CNTT", "BLOB$ATT_PHOTO", "ATT_FILENAME", "BLOB$ATT_FILE", "SEQ", "SERIAL");

                source.Tables[0].Rows.Add(
                    MEAS_DATE,
                    ISSUE_CNTT,
                    MGRT_CNTT,
                    this.pic02_ATT_PHOTO.GetValue(),
                    ATT_FILENAME,
                    _FILE,
                    _SEQ,
                    _SERIAL
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.InqueryGrid();
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("입력하신 이상발생원인/조치내용 정보가 저장되었습니다.");
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
                //this.IsDeleteVaild();
                if (!this.IsDeleteVaild()) return;

                string SERIAL       = this._SERIAL;
                string MEAS_DATE    = this.dte02_MEAS_DATE.GetDateText().ToString();

                DataSet source = this.GetDataSourceSchema("SERIAL", "MEAS_DATE", "SEQ");
                source.Tables[0].Rows.Add(SERIAL, MEAS_DATE, _SEQ);

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.InqueryGrid();
                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("선택하신 이상발생원인/조치내용 정보가 삭제되었습니다.");
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

        private void dte02_MEAS_DATE_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool change_month = false;

                string date = this.dte02_MEAS_DATE.GetDateText().ToString();
                change_month = this.dte02_MEAS_DATE.Value.Month != this.dte01_YYYYMM.Value.Month;

                if (change_month)
                {
                    this.dte01_YYYYMM.SetValue(date);
                }
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
                this.dte02_MEAS_DATE.SetValue(date);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_ATT_PHOTO_INSERT_Click(object sender, EventArgs e)
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

                    this.pic02_ATT_PHOTO.SetValue(_PHOTO);
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

        private void btn02_ATT_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_ATT_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_DWN_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsDwnVaild();

                if (_FILE != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + this.txt02_ATT_FILENAME.GetValue().ToString();

                    int ArraySize = _FILE.GetUpperBound(0);
                    FileStream stream = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(_FILE, 0, ArraySize + 1);
                    stream.Close();

                    System.Diagnostics.Process.Start(FILE_NAME);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_REG_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                this.IsRegVaild();

                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    _FILE = new byte[(int)fs.Length];
                    fs.Read(_FILE, 0, _FILE.Length);
                    fs.Close();

                    string filename = ((string[])file.SafeFileName.Split('\\'))[((string[])file.SafeFileName.Split('\\')).Length -1];

                    this.txt02_ATT_FILENAME.SetValue(filename);
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

        private void btn02_REM_Click(object sender, EventArgs e)
        {
            this.txt02_ATT_FILENAME.Initialize();
            _FILE = null;
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

        private void pic02_ATT_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_ATT_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_ATT_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
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

                _SERIAL      = this.grd01.GetValue(row, "SERIAL").ToString();

                this.InqueryGrid();
                this.InqueryPhoto();
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
        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;

                this.InputBoxReset();

                int row = this.grd02.SelectedRowIndex;
                if (row < this.grd02.Rows.Fixed) return;

                string MEAS_DATE = this.grd02.GetValue(row, "MEAS_DATE").ToString();
                _SEQ             = this.grd02.GetValue(row, "SEQ").ToString();
                this.InqueryDetailData(MEAS_DATE);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_NEW_Click(object sender, EventArgs e)
        {
            this.InputBoxReset();
        }
        #endregion

        #region [유효성 검사]

        private bool IsSaveVaild()
        {
            try
            {
                if (_SERIAL.Length == 0)
                {
                    //MsgBox.Show("저장할 기준 정보가 선택되지 않았습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                //if (MsgBox.Show("입력하신 이상발생원인/조치내용 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private bool IsDeleteVaild()
        {
            try
            {
                if (_SERIAL.Length == 0)
                {
                    //MsgBox.Show("삭제할 기준 정보가 선택되지 않았습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                if (this.dte02_MEAS_DATE.Enabled)
                {

                    MsgCodeBox.Show("QA02-0042");
                    //MsgBox.Show("삭제할 이상발생원인/조치내용 정보가 선택되지 않았습니다.");
                    return false;
                }

                //if (MsgBox.Show("선택하신 이상발생원인/조치내용 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private bool IsRegVaild()
        {
            try
            {
                if (_FILE != null)
                {
                    //if (MsgBox.Show("기 등록된 파일을 삭제하고 \r\n\r\n새로운 파일을 등록하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    //    return false;
                    if (MsgCodeBox.ShowFormat("QA02-0043", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDwnVaild()
        {
            try
            {
                if (_FILE == null)
                {
                    //MsgBox.Show("조회할 파일이 없습니다.");
                    MsgCodeBox.Show("QA02-0044");
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

       
        #region [ 사용자 정의 메서드 ]

        private void InqueryPhoto()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",        _SERIAL);
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

        private void InqueryGrid()
        {
            try
            {
                this.btn02_PHOTO_DELETE.SetReadOnly(false);
                this.btn02_PHOTO_INSERT.SetReadOnly(false);
                this.btn02_FILENO_VIEW.SetReadOnly(false);
                this.btn02_FILE_SEARCH.SetReadOnly(false);
                this.btn02_AFILE_DATA1_DELETE.SetReadOnly(false);

                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("YYYYMM",       this.dte01_YYYYMM.GetDateText().Substring(0,7));
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Detail_Grid(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL_GRID"), set);
                this.AfterInvokeServer();

                this.grd02.SetValue(source);
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
                this.dte02_MEAS_DATE.SetReadOnly(true);

                this.btn02_PHOTO_DELETE.SetReadOnly(false);
                this.btn02_PHOTO_INSERT.SetReadOnly(false);
                this.btn02_FILENO_VIEW.SetReadOnly(false);
                this.btn02_FILE_SEARCH.SetReadOnly(false);
                this.btn02_AFILE_DATA1_DELETE.SetReadOnly(false);

                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       _SERIAL);
                set.Add("MEAS_DATE",    MEAS_DATE);
                set.Add("SEQ",          _SEQ);
                set.Add("LANG_SET",     this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Detail(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                this.dte02_MEAS_DATE.SetValue(row["MEAS_DATE"]);
                this.txt02_ATT_FILENAME.SetValue(row["ATT_FILENAME"]);
                this.txt02_ISSUE_CNTT.SetValue(row["ISSUE_CNTT"]);
                this.txt02_MGRT_CNTT.SetValue(row["MGRT_CNTT"]);

                this.pic02_ATT_PHOTO.Initialize();
                if (row["ATT_PHOTO"] != System.DBNull.Value)
                    this.pic02_ATT_PHOTO.SetValue(row["ATT_PHOTO"]);

                _FILE = (row["ATT_FILE"] == DBNull.Value)
                    ? null : (byte[])row["ATT_FILE"];
                    
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        protected void InputBoxReset()
        {
            _FILE = null;
            _SEQ = "";

            this.dte02_MEAS_DATE.SetReadOnly(false);

            this.txt02_ATT_FILENAME.Initialize();
            this.txt02_ISSUE_CNTT.Initialize();
            this.txt02_MGRT_CNTT.Initialize();
            this.pic02_ATT_PHOTO.Initialize();
            this.dte02_MEAS_DATE.SetValue(string.Format("{0}-01", this.dte01_YYYYMM.GetDateText().Substring(0, 7)));

            this.btn02_PHOTO_DELETE.SetReadOnly(true);
            this.btn02_PHOTO_INSERT.SetReadOnly(false);
            this.btn02_FILENO_VIEW.SetReadOnly(true);
            this.btn02_FILE_SEARCH.SetReadOnly(false);
            this.btn02_AFILE_DATA1_DELETE.SetReadOnly(true);
        }

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
