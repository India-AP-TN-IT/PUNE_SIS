#region ▶ Description & History
/* 
 * 프로그램명 : QA30223 고객사 반송 불량 조회
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
 *				2015-07-28      배명희      통합WCF로 변경 (저장 로직은 기존 로직 그대로)
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
    /// <b>고객사 반송 불량 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오후 12:05:49<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오후 12:05:49   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30223 : AxCommonBaseControl
    {
        //private IQA30223 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30223";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA30223()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30223>("QA01", "QA30223.svc", "CustomBinding");
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
                this.cdx01_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");// "고객사코드";
                this.cdx01_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD_OF_VINCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMCD_OF_VINNM";
                this.cdx01_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_ITEMCD.HEParameterAdd("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet source = this.GetTypeCode("A1", "F5");
                this.cbo01_RTN_DIV.DataBind(source.Tables[0], true);
                this.cbo01_RTN_DIV.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_JOB_TYPE.DataBind(source.Tables[1], true);
                this.cbo01_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA30223.AllowEditing = false;
                this.grd01_QA30223.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30223.Initialize();
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "반송일자", "RTN_DATE", "RET_DATE");
                this.grd01_QA30223.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "고객사코드", "VENDCD","CUSTCD");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "고객사", "VENDNM","CUSTNM");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "고객공장", "CUST_PLANT", "CUST_PLANT");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "차종", "VINCD","VIN");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD","ITEM");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "PARTNO","PARTNO");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NAME", "PARTNM","PARTNM");
                this.grd01_QA30223.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "반송유형", "RTN_DIV", "RET_DIV");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "반송유형", "RTN_DIVNM", "RET_DIV");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "반송수량", "RTN_QTY","RET_QTY");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "반송금액", "RTN_AMT","RET_AMT");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "반송번호", "RTNNO", "RETNO");
                this.grd01_QA30223.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "업무유형코드", "JOB_TYPE", "JOB_TYPE");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "업무유형", "JOB_TYPENM", "JOB_TYPENM");
                this.grd01_QA30223.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "제품구분코드", "PRDT_DIV", "PRDT_DIVCD");
                this.grd01_QA30223.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "제품구분", "PRDT_DIVNM", "PRDT_DIVNM");
                this.grd01_QA30223.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 200, "PLANT_DIV", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA30223.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_QTY");
                this.grd01_QA30223.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_AMT");

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE, lbl01_CUSTNM);

                this.cdx01_SAL_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.UserInfo.BusinessCode));


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.BtnReset_Click(null, null);

                //this.dte01_RTN_DATE_FROM.SetMMFromStart();
                this.dte01_RTN_DATE_FROM.SetValue(this.dte01_RTN_DATE_FROM.GetDateText().Substring(0, 8) + "01");

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
                this.grd01_QA30223.InitializeDataSource();
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
                string RTN_DATE_FROM = this.dte01_RTN_DATE_FROM.GetDateText();
                string RTN_DATE_TO = this.dte01_RTN_DATE_TO.GetDateText();
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();
                string CUST_PLANT = this.cbo01_CUST_PLANT.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx01_ITEMCD.GetValue().ToString();
                string RTN_DIV = this.cbo01_RTN_DIV.GetValue().ToString();
                string JOB_TYPE = this.cbo01_JOB_TYPE.GetValue().ToString();
                string PARTNO_PARTNONM = this.txt01_PARTNO_PARTNONM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RTN_DATE_FROM", RTN_DATE_FROM);
                paramSet.Add("RTN_DATE_TO", RTN_DATE_TO);
                paramSet.Add("SAL_VENDCD", SAL_VENDCD);
                paramSet.Add("CUST_PLANT", CUST_PLANT);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("RTN_DIV", RTN_DIV);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("PARTNO_PARTNONM", PARTNO_PARTNONM);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30223.SetValue(source);
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
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();

                if (this.GetByteCount(SAL_VENDCD) == 0)
                {
                    //MsgBox.Show("고객사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl01_CUSTNM.Text);
                    return false;
                }

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

        private void cdx01_ITEMCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_QA30223_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30223.SelectedRowIndex;

                if (Row >= this.grd01_QA30223.Rows.Fixed)
                {
                    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                    string SAL_VENDCD = this.grd01_QA30223.GetValue(Row, "VENDCD").ToString();
                    string RTN_DATE = this.grd01_QA30223.GetValue(Row, "RTN_DATE").ToString();
                    string PARTNO = this.grd01_QA30223.GetValue(Row, "PARTNO").ToString();
                    string RTNNO = this.grd01_QA30223.GetValue(Row, "RTNNO").ToString();
                    string PLANT_DIV = this.grd01_QA30223.GetValue(Row, "PLANT_DIV").ToString();

                    ShowPopup(new QA20213(BIZCD, RTN_DATE, SAL_VENDCD, PARTNO, RTNNO, PLANT_DIV));
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
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

                //DataSet source_CUST_PLANT = _WSCOMBOBOX.Inquery_CUST_PLANT(paramSet_CUST_PLANT);
                DataSet source_CUST_PLANT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_CUST_PLANT"), paramSet_CUST_PLANT);

                this.AfterInvokeServer();

                this.cbo01_CUST_PLANT.DataBind(source_CUST_PLANT.Tables[0]);
                this.cbo01_CUST_PLANT.DropDownStyle = ComboBoxStyle.DropDownList;
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
