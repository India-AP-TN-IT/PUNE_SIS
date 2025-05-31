#region ▶ Description & History
/* 
 * 프로그램명 : QA30711 X-BAR R 관리 결과 조회(월별)
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
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>X-Bar R 관리 결과 조회(월별)</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2011-04-06 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30711 : AxCommonBaseControl
    {
        //private IQA30711 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private string _SERIAL;


        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30711";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 설정에 대한 정의 ]

        public QA30711()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30711>("QA02", "QA30711.svc", "CustomBinding");
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
                //this._buttonsControl.BtnReset.Visible = true;
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

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDNM");//"업체명";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

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
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                HEParameterSet paramSet_INSPECT_UNIT = new HEParameterSet();
                paramSet_INSPECT_UNIT.Add("CLASS_ID", "IU");
                paramSet_INSPECT_UNIT.Add("GROUPCD",  "BCD");
                paramSet_INSPECT_UNIT.Add("LANG_SET", _LANG_SET);

                //DataSet combo_source_MEAS_UNIT = _WSCOMBOBOX.Inquery_TYPECD_GROUP(paramSet_INSPECT_UNIT);
                DataSet combo_source_MEAS_UNIT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPECD_GROUP"), paramSet_INSPECT_UNIT);
                
                //DataSet combo_source_TYPENM = _WSCOMBOBOX.Inquery_TYPENM();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", _LANG_SET);
                DataSet combo_source_TYPENM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_TYPENM"), paramSet);

                //this.pic02_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false,AxFlexGrid.FtextAlign.C, 040, "순번",         "SERIAL","SEQ_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종",         "VINCD","VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "품목",         "ITEMCD","ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품목명",         "MEAS_ITEMCD","ITEMNM3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "부위사진", "STD_PHOTO", "STD_PHOTO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "관리항목", "MGRT_ITEMNM", "MGRT_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "측정기", "MEAS_INST", "MEAS_INST");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "하한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "상한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "측정단위", "MEAS_UNIT", "MEAS_UNITNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "업체명", "VENDCD", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "측정업체명", "VENDCD2", "VENDNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "측정자", "MEAS_POINT", "MEAS_POINT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "Gauge R&R", "GATE_RNR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "VAN 등록여부", "VAN_IF_YN", "VAN_IF_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "CPK",          "CPK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "판정", "DECISION", "DECISION");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "이슈여부", "ISSUE_YN", "ISSUE_YN");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "이슈타입", "ISSUE_TYPE", "ISSUE_TYPE");
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

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();

                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "측정일자", "MEAS_DATE", "MEAS_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "순번", "MEAS_SEQ", "SEQ_NO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "규격", "STANDARD", "STANDARD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "상한치", "STD_MIN_MEAS", "STD_MIN_MEAS");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "하한치", "STD_MAX_MEAS", "STD_MAX_MEAS");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "측정치", "MEAS_METER", "MEAS_METER2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "측정자", "MEAS_NAME", "MEAS_POINT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "측정시간", "MEAS_TIME", "MIX_TIME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "검사상태", "INSPECT_STATUS", "INSPECT_STATUS");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "조치상태", "RESOLVE_STATUS", "RESOLVE_STATUS");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "STANDARD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "STD_MIN_MEAS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "STD_MAX_MEAS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "MEAS_METER");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "MEAS_DATE");
                this.grd02.Cols["STANDARD"].Format = "###,###,###,###.##";
                this.grd02.Cols["STD_MIN_MEAS"].Format = "###,###,###,###.##";
                this.grd02.Cols["STD_MAX_MEAS"].Format = "###,###,###,###.##";
                this.grd02.Cols["MEAS_METER"].Format = "###,###,###,###.##";

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
                this._SERIAL = "";
                this.grd02.InitializeDataSource();
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

                string CORCD        = this._CORCD;
                string BIZCD        = this._BIZCD;
                string VINCD        = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD       = this.cdx01_ITEMCD.GetValue().ToString();
                string MEAS_ITEMCD  = this.cdx01_MEAS_ITEMCD.GetValue().ToString();
                string VENDCD       = this.cdx01_VENDCD.GetValue().ToString();
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
                set.Add("VENDCD",       VENDCD);
                set.Add("USE_YN",       USE_YN);
                set.Add("SDATE",        SDATE);
                set.Add("EDATE",        EDATE);
                set.Add("PLANT_DIV", PLANT_DIV);
                set.Add("LANG_SET",  _LANG_SET);
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

                _SERIAL = this.grd01.GetValue(row, "SERIAL").ToString();

                this.InqueryGrid();
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
                set.Add("SDATE", this.dte01_SDATE.GetDateText());
                set.Add("EDATE", this.dte01_EDATE.GetDateText());
                set.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Detail_Grid(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL_GRID"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count != 0)
                {
                    this.grd02.SetValue(source);

                    for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                    {
                        string strRST = "";
                        strRST = this.grd02.Rows[i]["RESOLVE_STATUS"].ToString().Equals("") ? "" : this.grd02.Rows[i]["RESOLVE_STATUS"].ToString();

                        if (strRST.Equals("미처리"))
                            this.grd02.GetCellRange(i, this.grd02.Cols.Fixed, i, this.grd02.Cols.Count - this.grd02.Cols.Fixed).StyleNew.BackColor = Color.Red;
                    }
                }
                else
                {
                    this.grd02.InitializeDataSource();
                    return;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
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
