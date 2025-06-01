#region ▶ Description & History
/* 
 * 프로그램명 : QA30222 완제품 파견 불량 조회
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
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>완제품 파견불량 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:47:08<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:47:08   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30222 : AxCommonBaseControl
    {
        //private IQA30222 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30222";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA30222()
        {
            InitializeComponent();

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

                this.cdx01_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx01_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//;"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();


                this.cdx01_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx01_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx01_DEFCD.CodeParameterName = "DEFCD";
                this.cdx01_DEFCD.NameParameterName = "DEFNM";
                this.cdx01_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                //this.cdx01_DEFCD.CodePixedLength = 5;
                this.cdx01_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx01_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx01_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx01_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet source = this.GetTypeCode("FY", "FZ");
                this.cbo01_MGRT_CD.DataBind(source.Tables[0], true);
                this.cbo01_MGRT_CD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_IMPUT_DIVCD.DataBind(source.Tables[1], true);
                this.cbo01_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_ITEM_DIV.DataBind("4I", true);

                this.grd01_QA30222.AllowEditing = false;
                this.grd01_QA30222.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30222.Initialize();
                this.grd01_QA30222.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "고객사코드", "SAL_VENDCD","CUSTCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "고객사명", "SAL_VENDNM","CUSTNM");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "고객공장", "CUST_PLANT", "CUST_PLANT");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Job Type", "JOB_TYPENM");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "PROC_DATE","OCCUR_DATE");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "Item Div", "ITEM_DIVNM");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "A'SSY NO", "ASSYPNO");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "A'SSY NAME", "ASSYPNM");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "PART NAME", "PARTNM", "PARTNM");
                this.grd01_QA30222.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "조치구분코드", "MGRT_CD", "MGRT_CD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "조치구분", "MGRT_NM", "MGRT_NM");
                this.grd01_QA30222.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "귀책구분코드", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "귀책구분", "IMPUT_DIVNM", "IMPUT_DIVNM");
                this.grd01_QA30222.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "귀책업체코드", "IMPUT_VENDCD", "IMPUT_VENDCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "귀책업체", "IMPUT_VENDNM", "IMPUT_VENDNM");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "Def Qty.", "DIS_QTY");
                this.grd01_QA30222.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 60, "U/Cost", "DIS_UCOST");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "Def Amt.", "DIS_AMT");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "Currency", "COINCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Def Code", "DEFCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Def Name", "DEFNM");
                this.grd01_QA30222.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "Def PosCd", "DEFPOSCD");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "Def Pos", "DEFPOSNM");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "원인품번", "APPLY_PARTNO", "APPLY_PARTNO");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "Shift", "DN_DIV");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "파견번호", "DPTNO", "DPTNO");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Plant Div", "PLANT_DIV");
                this.grd01_QA30222.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Remark", "REMARK");

                this.grd01_QA30222.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_QTY");
                this.grd01_QA30222.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_UCOST");
                this.grd01_QA30222.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMT");
                this.grd01_QA30222.Cols["DIS_QTY"].Format = "#,###,##0";
                this.grd01_QA30222.Cols["DIS_UCOST"].Format = "#,###,##0.##";
                this.grd01_QA30222.Cols["DIS_AMT"].Format = "#,###,##0.##";

                this.grd01_QA30222.Cols["PROC_DATE"].Format = "yyyy-MM-dd";
                this.grd01_QA30222.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE);

                this.cdx01_SAL_VENDCD.SetValue(this.GetSysEnviroment("SALES", "VENDCD_" + this.UserInfo.BusinessCode));
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true);

                this.BtnReset_Click(null, null);

                this.dte01_PROC_DATE_FROM.SetValue(this.dte01_PROC_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");

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
                this.grd01_QA30222.InitializeDataSource();

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
                if (!IsSelectValid()) return;

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string PROC_DATE_FROM = this.dte01_PROC_DATE_FROM.GetDateText().ToString();
                string PROC_DATE_TO = this.dte01_PROC_DATE_TO.GetDateText().ToString();
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();
                string CUST_PLANT = this.cbo01_CUST_PLANT.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEM_DIV = this.cbo01_ITEM_DIV.GetValue().ToString();
                string DEFCD = this.cdx01_DEFCD.GetValue().ToString();
                string DEFPOSCD = this.cdx01_DEFPOSCD.GetValue().ToString();
                string MGRT_CD = this.cbo01_MGRT_CD.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo01_IMPUT_DIVCD.GetValue().ToString();
                string PARTNO_PARTNONM = this.txt01_PARTNO_PARTNONM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE_FROM", PROC_DATE_FROM);
                paramSet.Add("PROC_DATE_TO", PROC_DATE_TO);
                paramSet.Add("SAL_VENDCD", SAL_VENDCD);
                paramSet.Add("CUST_PLANT", CUST_PLANT);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEM_DIV", ITEM_DIV);
                paramSet.Add("DEFCD", DEFCD);
                paramSet.Add("DEFPOSCD", DEFPOSCD);
                paramSet.Add("MGRT_CD", MGRT_CD);
                paramSet.Add("IMPUT_DIVCD", IMPUT_DIVCD);
                paramSet.Add("PARTNO_PARTNONM", PARTNO_PARTNONM);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30222.SetValue(source);
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

        #region [유효성 검사]

        private bool IsSelectValid()
        {
            try
            {
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

        private void cdx01_SAL_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cbo02_CUST_PLANT_View();
        }

        private void grd01_QA30222_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30222.SelectedRowIndex;

                if (Row >= this.grd01_QA30222.Rows.Fixed)
                {
                    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                    string SAL_VENDCD = this.grd01_QA30222.GetValue(Row, "SAL_VENDCD").ToString();
                    string CUST_PLANT = this.grd01_QA30222.GetValue(Row, "CUST_PLANT").ToString();
                    string PROC_DATE = this.grd01_QA30222.GetValue(Row, "PROC_DATE").ToString();
                    string IMPUT_VENDCD = this.grd01_QA30222.GetValue(Row, "IMPUT_VENDCD").ToString();
                    string PARTNO = this.grd01_QA30222.GetValue(Row, "PARTNO").ToString();
                    string DPTNO = this.grd01_QA30222.GetValue(Row, "DPTNO").ToString();
                    string PLANT_DIV = this.grd01_QA30222.GetValue(Row, "PLANT_DIV").ToString();

                    ShowPopup(new QA20212(BIZCD, SAL_VENDCD, CUST_PLANT, PROC_DATE, IMPUT_VENDCD, string.Empty, DPTNO, PLANT_DIV));
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

        private void cbo02_CUST_PLANT_View()
        {
            try
            {
                HEParameterSet paramSet_CUST_PLANT = new HEParameterSet();
                paramSet_CUST_PLANT.Add("CORCD", _CORCD);
                paramSet_CUST_PLANT.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet_CUST_PLANT.Add("VENDORCD", this.cdx01_SAL_VENDCD.GetValue().ToString());
                paramSet_CUST_PLANT.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                DataSet source_CUST_PLANT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_CUST_PLANT"), paramSet_CUST_PLANT);

                this.cbo01_CUST_PLANT.DataBind(source_CUST_PLANT.Tables[0]);
                this.cbo01_CUST_PLANT.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
 }
}
