#region ▶ Description & History
/* 
 * 프로그램명 : QA30703 이상발생원인/조치내용 조회
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
 *				2015-07-29      배명희      통합WCF로 변경 
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using System.IO;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>X-Bar R 관리 결과 조회(월별)</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-04-06 오후 5:29:52<br />
    /// </summary>
    public partial class QA30703 : AxCommonBaseControl
    {
        //private IQA30703 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30703";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 설정에 대한 정의 ]

        public QA30703()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30703>("QA02", "QA30703.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                this._buttonsControl.BtnReset.Visible = false;
                this._buttonsControl.BtnSave.Visible = false;
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

                this.cbo01_BIZCD.Enabled = (this.UserInfo.IsAdmin == "Y");

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
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", _LANG_SET);
                //DataSet combo_source_TYPENM = _WSCOMBOBOX.Inquery_TYPENM();
                DataSet combo_source_TYPENM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPENM"), paramSet);

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 040, "순번", "SERIAL", "SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 085, "품목", "ITEMCD", "ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명", "MEAS_ITEMCD", "ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "일자",             "MEAS_DATE","DD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "이상발생원인", "ISSUE_CNTT", "ISSUE_CNTT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 260, "조치내용", "MGRT_CNTT", "MGRT_CNTT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "첨부사진", "ATT_PHOTO", "ATT_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "첨부파일", "ATT_FILE", "ATT_FILE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_TYPENM.Tables[0], "MEAS_ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MEAS_DATE");
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-") + "01");

                this.cbo01_USE_YN.SetValue("Y");

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

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
                string SDATE        = this.dte01_SDATE.GetDateText().ToString();
                string EDATE        = this.dte01_EDATE.GetDateText().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",        CORCD);
                set.Add("BIZCD",        BIZCD);
                set.Add("VINCD",        VINCD);
                set.Add("ITEMCD",       ITEMCD);
                set.Add("MEAS_ITEMCD",  MEAS_ITEMCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("SDATE",        SDATE);
                set.Add("EDATE",        EDATE);
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
        #endregion

        #region [컨트롤 이벤트]

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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                if (e.Button != MouseButtons.Left) return;

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                int col = this.grd01.ColSel;
                
                string SERIAL		    = this.grd01.GetValue(row, "SERIAL").ToString();
                string MEAS_DATE        = this.grd01.GetValue(row, "MEAS_DATE").ToString();

                if (col == this.grd01.Cols["ATT_PHOTO"].Index && this.grd01.GetValue(row, col).ToString().Equals("O"))
                {
                    this.InqueryPhoto(SERIAL, MEAS_DATE);
                }

                if (col == this.grd01.Cols["ATT_FILE"].Index && this.grd01.GetValue(row, col).ToString().Equals("O"))
                {
                    this.InqueryFile(SERIAL, MEAS_DATE);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [기타 이벤트]

        private void InqueryPhoto(string SERIAL, string MEAS_DATE)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL",       SERIAL);
                set.Add("MEAS_DATE",    MEAS_DATE);
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source = _WSCOM.Inquery_Photo(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PHOTO"), set);

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                byte[] photo = (row["ATT_PHOTO"] == DBNull.Value) ? null : (byte[])row["ATT_PHOTO"];

                string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";

                int ArraySize = photo.GetUpperBound(0);
                FileStream stream = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(photo, 0, ArraySize + 1);
                stream.Close();

                System.Diagnostics.Process.Start(FILE_NAME);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void InqueryFile(string SERIAL, string MEAS_DATE)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SERIAL", SERIAL);
                set.Add("MEAS_DATE", MEAS_DATE);
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source = _WSCOM.Inquery_File(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_FILE"), set);

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                byte[] file = (row["ATT_FILE"] == DBNull.Value) ? null : (byte[])row["ATT_FILE"];

                string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + row["ATT_FILENAME"].ToString();

                int ArraySize = file.GetUpperBound(0);
                FileStream stream = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(file, 0, ArraySize + 1);
                stream.Close();

                System.Diagnostics.Process.Start(FILE_NAME);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
