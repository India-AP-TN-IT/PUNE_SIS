#region ▶ Description & History
/* 
 * 프로그램명 : QA30131 무검사 시행결정 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-24      배명희      통합WCF로 변경 
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

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>무검사 시행결정 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:22:28<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:22:28   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30131 : AxCommonBaseControl
    {
        //private IQA30131 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30131";

        #region [ 초기화 작업 정의 ]

        public QA30131()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30131>("QA00", "QA30131.svc", "CustomBinding");
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
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");// "차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INSPECT_CLASSCD.PopupTitle = this.GetLabel("QA_INSPECT_BASECODE");//"검사코드";
                this.cdx01_INSPECT_CLASSCD.CodeParameterName = "INSPECT_CLASSCD";
                this.cdx01_INSPECT_CLASSCD.NameParameterName = "INSPECT_CLASSNM";
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");
                this.cdx01_INSPECT_CLASSCD.SetCodePixedLength();

                DataTable combo_source_INSPECT_YN = new DataTable();
                combo_source_INSPECT_YN.Columns.Add("CODE");
                combo_source_INSPECT_YN.Columns.Add("NAME");
                combo_source_INSPECT_YN.Rows.Add("Y", this.GetLabel("INSPECT_Y"));
                combo_source_INSPECT_YN.Rows.Add("N", this.GetLabel("INSPECT_N"));
                this.cbo01_INSPECT_YN.DataBind(combo_source_INSPECT_YN, true);
                this.cbo01_INSPECT_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source_SELECT_GUBN = new DataTable();
                combo_source_SELECT_GUBN.Columns.Add("CODE");
                combo_source_SELECT_GUBN.Columns.Add("NAME");
                combo_source_SELECT_GUBN.Rows.Add("1", this.GetLabel("INSPECT_CD_SUMMARY"));//"검사코드별집계");
                combo_source_SELECT_GUBN.Rows.Add("2", this.GetLabel("ITEMDETAIL"));//"품목상세");
                this.cbo01_SELECT_GUBN.DataBind(combo_source_SELECT_GUBN, false);
                this.cbo01_SELECT_GUBN.DropDownStyle = ComboBoxStyle.DropDownList;

                //공장구분-------------------------------------------------------------------------
                DataTable source = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in source.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(source, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                //---------------------------------------------------------------------------------


                this.grd01_QA30131.AllowEditing = false;
                this.grd01_QA30131.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30131.Initialize();
                this.grd01_QA30131.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30131.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VINCD");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD", "ITEM");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "위치", "POSCD", "INSTALL_POS");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "검사명", "INSPECT_CLASSNM", "QA_INSPECT_BASENAME");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "불량건수", "DEF_NOCASE", "DEF_NOCASE");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "무검사", "INSPECT_N", "INSPECT_N");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "유검사", "INSPECT_Y", "INSPECT_Y");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "상시검사", "ALWAYS_YNNM", "ALWAYS_YNNM");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "전환시작일", "CONV_BEG_DATE", "CONV_BEG_DATE");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "전환종료일", "CONV_END_DATE", "CONV_END_DATE");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "선정시작일", "SELECT_BEG_DATE", "SELECT_BEG_DATE");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "선정종료일", "SELECT_END_DATE", "SELECT_END_DATE");
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "최종발생일", "CONV_DATE", "CONV_DATE");
                
                this.grd01_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "PLANT_DIV");
                this.grd01_QA30131.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_NOCASE");
                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_BEG_DATE");
                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_END_DATE");
                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "SELECT_BEG_DATE");
                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "SELECT_END_DATE");
                this.grd01_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_DATE");

                this.grd02_QA30131.AllowEditing = false;
                this.grd02_QA30131.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30131.Initialize();
                this.grd02_QA30131.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA30131.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VINCD");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD", "ITEMCD");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "위치", "POSCD", "INSTALL_POS");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "검사명", "INSPECT_CLASSNM", "QA_INSPECT_BASENAME");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMNM", "ITEMNM3");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "불량건수", "DEF_NOCASE", "DEF_NOCASE");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "무검사", "INSPECT_N", "INSPECT_N");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "유검사", "INSPECT_Y", "INSPECT_Y");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "상시검사", "ALWAYS_YNNM", "ALWAYS_YNNM");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "전환시작일", "CONV_BEG_DATE", "CONV_BEG_DATE");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "전환종료일", "CONV_END_DATE", "CONV_END_DATE");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "선정시작일", "SELECT_BEG_DATE", "SELECT_BEG_DATE");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "선정종료일", "SELECT_END_DATE", "SELECT_END_DATE");
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "최종발생일", "CONV_DATE", "CONV_DATE");
                
                this.grd02_QA30131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "PLANT_DIV");
                this.grd02_QA30131.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_NOCASE");
                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_BEG_DATE");
                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_END_DATE");
                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "SELECT_BEG_DATE");
                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "SELECT_END_DATE");
                this.grd02_QA30131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_DATE");
                this.SetRequired(lbl01_BIZNM, lbl01_SELECT_GUBN, lbl01_CONV_DATE);

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
                this.grd01_QA30131.InitializeDataSource();
                this.grd02_QA30131.InitializeDataSource();

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
                string SELECT_GUBN = this.cbo01_SELECT_GUBN.GetValue().ToString();
                if (SELECT_GUBN != "")
                {
                    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                    string CONV_DATE = this.dte01_CONV_DATE.GetDateText().ToString();
                    string VINCD = this.cdx01_VINCD.GetValue().ToString();
                    string INSPECT_YN = this.cbo01_INSPECT_YN.GetValue().ToString();
                    string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();
                    string PARTNO_PARTNM = this.txt01_PARTNO_PARTNM.GetValue().ToString();

                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("CONV_DATE", CONV_DATE);
                    paramSet.Add("VINCD", VINCD);
                    paramSet.Add("INSPECT_YN", INSPECT_YN);
                    paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);

                    if (SELECT_GUBN == "2")
                    {
                        paramSet.Add("PARTNO_PARTNM", PARTNO_PARTNM);
                    }

                    paramSet.Add("LANG_SET", _LANG_SET);
                    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());

                    this.BeforeInvokeServer(true);

                    if (SELECT_GUBN == "1")
                    {
                        //DataSet source = _WSCOM.Inquery_TOTAL(paramSet);
                        DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_TOTAL"), paramSet);
                        this.grd01_QA30131.SetValue(source);
                    }
                    else
                    {
                        //DataSet source = _WSCOM.Inquery_DETAIL(paramSet);
                        DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);
                        this.grd02_QA30131.SetValue(source);
                    }

                    this.AfterInvokeServer();
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


        #region [ 기타 이벤트 정의 ]

        private void cbo01_SELECT_GUBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SELECT_GUBN = this.cbo01_SELECT_GUBN.GetValue().ToString();

            if (SELECT_GUBN == "1")
            {
                this.grd01_QA30131.Visible = true;
                this.grd02_QA30131.Visible = false;
            }
            else
            {
                this.grd01_QA30131.Visible = false;
                this.grd02_QA30131.Visible = true;
            }

        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx01_VINCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_VINCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("ITEMCD", "");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
