#region ▶ Description & History
/* 
 * 프로그램명 : QA20213 고객사 반송 불량 등록
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

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>고객사 반송 불량 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20213 : AxCommonBaseControl
    {
        //private IQA20213 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;
        private String _BIZCD_T;
        private String _RTN_DATE_T;
        private String _SAL_VENDCD_T;
        private String _PARTNO_T;
        private String _RTNNO;
        private String _GUBN;
        private String _PLANT_DIV;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20213";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20213()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20213>("QA01", "QA20213.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _BIZCD_T = "";
            _RTN_DATE_T = "";
            _SAL_VENDCD_T = "";
            _PARTNO_T = "";
            _RTNNO = "";
            _GUBN = "N";
            _PLANT_DIV = "";
        }

        public QA20213(string BIZCD, string RTN_DATE, string SAL_VENDCD, string PARTNO, string RTNNO, string PLANT_DIV)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20213>("QA01", "QA20213.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _BIZCD_T = BIZCD;
            _RTN_DATE_T = RTN_DATE;
            _SAL_VENDCD_T = SAL_VENDCD;
            _PARTNO_T = PARTNO;
            _RTNNO = RTNNO;
            _GUBN = "Y";
            _PLANT_DIV = PLANT_DIV;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox2.Text = this.GetLabel("QA20213_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20213_MSG2");
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
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);


                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                    this.cbo02_BIZCD.Enabled = false;
                }


                this.cdx01_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx01_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx02_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx02_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx02_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet source = this.GetTypeCode("A1", "F5");
                this.cbo02_JOB_TYPE.DataBind(source.Tables[0], true);
                this.cbo02_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_RTN_DIV.DataBind(source.Tables[1], true);
                this.cbo02_RTN_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx02_ALCCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ALCCD.PopupTitle = "ALC CODE";
                this.cdx02_ALCCD.CodeParameterName = "ALCCD_OF_CUSTCD";
                this.cdx02_ALCCD.NameParameterName = "ALCCD_OF_CUSTNM";
                this.cdx02_ALCCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ALCCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEParameterAdd("VINCD", "");
                this.cdx02_ALCCD.HEParameterAdd("ITEMCD", "");
                this.cdx02_ALCCD.HEParameterAdd("CUSTCD", this.cdx02_SAL_VENDCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = this.GetLabel("ASSYPNO");//"완제품코드";
                this.cdx02_PARTNO.CodeParameterName = "ASSYNO_OF_ALCCD";
                this.cdx02_PARTNO.NameParameterName = "ASSYNO_OF_ALCNM";
                this.cdx02_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_PARTNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEParameterAdd("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_PARTNO.HEParameterAdd("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_PARTNO.HEParameterAdd("VINCD", "");
                this.cdx02_PARTNO.HEParameterAdd("ITEMCD", "");
                this.cdx02_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA20213.AllowEditing = false;
                this.grd01_QA20213.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20213.Initialize();
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "반송일자", "RTN_DATE", "RET_DATE");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "반송번호", "RTNNO", "RETNO");
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "업무유형코드", "JOB_TYPE", "JOB_TYPE");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "업무유형", "JOB_TYPENM", "JOB_TYPENM");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "고객공장코드", "CUST_PLANT", "CUST_PLANT");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NAME", "PARTNONM", "PARTNM");
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "반송유형", "RTN_DIV", "RET_DIV");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "반송유형", "RTN_DIVNM", "RET_DIVNM");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "반송수량", "RTN_QTY", "RET_QTY");
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 80, "반송단가", "RTN_UCOST", "RET_UCOST");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "반송금액", "RTN_AMT", "RET_AMT");
                this.grd01_QA20213.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "고객사", "SAL_VENDCD","CUSTNM");
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "제품구분", "PRDT_DIV", "PRDT_DIVNM");
                this.grd01_QA20213.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "ALC CODE", "ALCCD");
                this.grd01_QA20213.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_QTY");
                this.grd01_QA20213.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_UCOST");
                this.grd01_QA20213.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_AMT");

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE, lbl02_BIZNM, lbl02_OCCUR_DATE, lbl02_CUSTNM, lbl02_JOB_TYPE, lbl02_ASSYPNO, lbl02_RET_QTY);

                this.cdx01_SAL_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.UserInfo.BusinessCode));

                this.BtnReset_Click(null, null);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                if (_GUBN == "Y")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD_T);
                    this.dte01_RTN_DATE.SetValue(_RTN_DATE_T);
                    this.cdx01_SAL_VENDCD.SetValue(_SAL_VENDCD_T);
                    this.txt01_PARTNO_PARTNONM.SetValue(_PARTNO_T);
                    this.cbo01_PLANT_DIV.SetValue(_PLANT_DIV);

                }

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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        if (ctl.Name != "cbo02_CUST_PLANT")
                        {
                            ((IAxControl)ctl).Initialize();
                        }
                        else
                        {
                            if (cbo02_CUST_PLANT.Items.Count != 0)
                            {
                                cbo02_CUST_PLANT.Initialize();
                            }
                        }
                    }
                }
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);

                this.nme02_RTN_QTY.SetValue("0");
                this.nme02_RTN_UCOST.SetValue("0");
                this.nme02_RTN_AMT.SetValue("0");

                this.cdx02_SAL_VENDCD.SetValue(this.cdx01_SAL_VENDCD.GetValue());

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }

                this.dte02_RTN_DATE.Enabled = true;
                this.cdx02_SAL_VENDCD.Enabled = true;

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
                string RTN_DATE = this.dte01_RTN_DATE.GetDateText().ToString();
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();
                string PARTNO_PARTNONM = this.txt01_PARTNO_PARTNONM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RTN_DATE", RTN_DATE);
                paramSet.Add("SAL_VENDCD", SAL_VENDCD);
                paramSet.Add("PARTNO_PARTNONM", PARTNO_PARTNONM);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("RTNNO", _RTNNO);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20213.SetValue(source);

                if (_GUBN == "Y")
                {
                    if (((DataTable)this.grd01_QA20213.DataSource).Rows.Count > 0)
                        this.grd_SELECT(this.grd01_QA20213.Rows.Fixed);

                    _GUBN = "";
                    _RTNNO = "";
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

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "RTNNO", "RTN_DATE", "JOB_TYPE", 
                    "PARTNO", "CUST_PLANT", "RTN_DIV", "RTN_QTY", "RTN_UCOST",
                    "SAL_VENDCD", "PRDT_DIV", "ALCCD", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_RTNNO.GetValue(),
                    this.dte02_RTN_DATE.GetDateText(),
                    this.cbo02_JOB_TYPE.GetValue(),
                    this.cdx02_PARTNO.GetValue(),
                    this.cbo02_CUST_PLANT.GetValue(),
                    this.cbo02_RTN_DIV.GetValue(),
                    this.nme02_RTN_QTY.GetDBValue(),
                    this.nme02_RTN_UCOST.GetDBValue(),
                    this.cdx02_SAL_VENDCD.GetValue(),
                    this.txt02_PRDT_DIV.GetValue(),
                    this.cdx02_ALCCD.GetValue(),
                    this.cbo01_PLANT_DIV.GetValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("고객사 반송 불량 등록이 저장되었습니다.");
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

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "RTNNO");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_RTNNO.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("고객사 반송 불량 등록이 삭제 되었습니다.");
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

        private void grd01_QA20213_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20213.SelectedRowIndex;
                
                if (Row >= this.grd01_QA20213.Rows.Fixed)
                {
                    this.grd_SELECT(Row);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_SAL_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
            this.SAL_VENDCD_SELECT();
        }

        private void cdx02_PARTNO_ButtonClickAfter(object sender, EventArgs args)
        {
            this.SUB_QUERT_VIEW();
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void dte02_RTN_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_SAL_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string RTN_DATE = this.dte02_RTN_DATE.GetDateText().ToString();
                string SAL_VENDCD = this.cdx02_SAL_VENDCD.GetValue().ToString();
                string CUST_PLANT = this.cbo02_CUST_PLANT.GetValue().ToString();
                string JOB_TYPE = this.cbo02_JOB_TYPE.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();
                string RTN_QTY = this.nme02_RTN_QTY.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(RTN_DATE) == 0)
                {
                    //MsgBox.Show("발생일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_OCCUR_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(SAL_VENDCD) == 0)
                {
                    //MsgBox.Show("고객사 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CUSTNM.Text);
                    return false;
                }

                if (this.GetByteCount(CUST_PLANT) == 0)
                {
                    //MsgBox.Show("고객사 공장 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CUST_PLANT"));
                    return false;
                }

                if (this.GetByteCount(JOB_TYPE) == 0)
                {
                    //MsgBox.Show("업무유형 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_JOB_TYPE.Text);
                    return false;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("완제품 PNO 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ASSYPNO.Text);
                    return false;
                }

                if (Int32.Parse(RTN_QTY) <= 0)
                {
                    //MsgBox.Show("반송수량 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_RET_QTY.Text);
                    return false;
                }

                if (this.nme02_RTN_QTY.GetValue().ToString() != "")
                {
                    this.nme02_RTN_AMT.SetValue(Int32.Parse(this.nme02_RTN_QTY.GetValue().ToString()) * Int32.Parse(this.nme02_RTN_UCOST.GetValue().ToString()));
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string RTNNO = this.txt02_RTNNO.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(RTNNO) == 0)
                {
                    //MsgBox.Show("번호 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_RETNO.Text);
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("VINCD", "");
                this.cdx02_PARTNO.HEUserParameterSetValue("ITEMCD", "");
                this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("VINCD", "");
                this.cdx02_ALCCD.HEUserParameterSetValue("ITEMCD", "");
                this.cdx02_ALCCD.HEUserParameterSetValue("CUSTCD", this.cdx02_SAL_VENDCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd_SELECT(int Row)
        {
            try
            {
                this.BtnReset_Click(null, null);

                string BIZCD = this.grd01_QA20213.GetValue(Row, "BIZCD").ToString();
                string RTN_DATE = this.grd01_QA20213.GetValue(Row, "RTN_DATE").ToString();
                string RTNNO = this.grd01_QA20213.GetValue(Row, "RTNNO").ToString();
                string SAL_VENDCD = this.grd01_QA20213.GetValue(Row, "SAL_VENDCD").ToString();
                string CUST_PLANT = this.grd01_QA20213.GetValue(Row, "CUST_PLANT").ToString();
                string PRDT_DIV = this.grd01_QA20213.GetValue(Row, "PRDT_DIV").ToString();
                string JOB_TYPE = this.grd01_QA20213.GetValue(Row, "JOB_TYPE").ToString();
                string ALCCD = this.grd01_QA20213.GetValue(Row, "ALCCD").ToString();
                string PARTNO = this.grd01_QA20213.GetValue(Row, "PARTNO").ToString();
                string RTN_QTY = this.grd01_QA20213.GetValue(Row, "RTN_QTY").ToString();
                string RTN_UCOST = this.grd01_QA20213.GetValue(Row, "RTN_UCOST").ToString();
                string RTN_AMT = this.grd01_QA20213.GetValue(Row, "RTN_AMT").ToString();
                string RTN_DIV = this.grd01_QA20213.GetValue(Row, "RTN_DIV").ToString();

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.dte02_RTN_DATE.SetValue(RTN_DATE);
                this.txt02_RTNNO.SetValue(RTNNO);
                this.cdx02_SAL_VENDCD.SetValue(SAL_VENDCD);
                this.SAL_VENDCD_SELECT();
                this.cbo02_CUST_PLANT.SetValue(CUST_PLANT);
                this.txt02_PRDT_DIV.SetValue(PRDT_DIV);
                this.cbo02_JOB_TYPE.SetValue(JOB_TYPE);
                this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("VINCD", "");
                this.cdx02_ALCCD.HEUserParameterSetValue("ITEMCD", "");
                this.cdx02_ALCCD.HEUserParameterSetValue("CUSTCD", this.cdx02_SAL_VENDCD.GetValue().ToString());
                this.cdx02_ALCCD.SetValue(ALCCD);
                this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("VINCD", "");
                this.cdx02_PARTNO.HEUserParameterSetValue("ITEMCD", "");
                this.cdx02_PARTNO.SetValue(PARTNO);
                this.nme02_RTN_QTY.SetValue(RTN_QTY);
                this.nme02_RTN_UCOST.SetValue(RTN_UCOST);
                this.nme02_RTN_AMT.SetValue(RTN_AMT);
                this.cbo02_RTN_DIV.SetValue(RTN_DIV);

                this.SUB_QUERT_VIEW();

                this.cbo02_BIZCD.Enabled = false;
                this.dte02_RTN_DATE.Enabled = false;
                this.cdx02_SAL_VENDCD.Enabled = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SAL_VENDCD_SELECT()
        {
            try
            {
                HEParameterSet paramSet_CUST_PLANT = new HEParameterSet();
                paramSet_CUST_PLANT.Add("CORCD", _CORCD);
                paramSet_CUST_PLANT.Add("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                paramSet_CUST_PLANT.Add("VENDORCD", this.cdx02_SAL_VENDCD.GetValue().ToString());
                paramSet_CUST_PLANT.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source_CUST_PLANT = _WSCOMBOBOX.Inquery_CUST_PLANT(paramSet_CUST_PLANT);
                DataSet source_CUST_PLANT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_CUST_PLANT"), paramSet_CUST_PLANT);
                this.cbo02_CUST_PLANT.DataBind(source_CUST_PLANT.Tables[0]);
                this.cbo02_CUST_PLANT.DropDownStyle = ComboBoxStyle.DropDownList;

                this.AfterInvokeServer();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void SUB_QUERT_VIEW()
        {
            try
            {
                HEParameterSet paramSet_VIN_ITEM_PRDTDIV = new HEParameterSet();
                paramSet_VIN_ITEM_PRDTDIV.Add("PARTNO", this.cdx02_PARTNO.GetValue().ToString());
                paramSet_VIN_ITEM_PRDTDIV.Add("LANG_SET", this.UserInfo.Language);

                HEParameterSet paramSet_UCOST_CUSTCD = new HEParameterSet();
                paramSet_UCOST_CUSTCD.Add("CORCD", _CORCD);
                paramSet_UCOST_CUSTCD.Add("JOB_TYPE", this.cbo02_JOB_TYPE.GetValue().ToString());
                paramSet_UCOST_CUSTCD.Add("CUSTCD", this.cdx02_SAL_VENDCD.GetValue().ToString());
                paramSet_UCOST_CUSTCD.Add("APP_SDATE", this.dte02_RTN_DATE.GetDateText().ToString());
                paramSet_UCOST_CUSTCD.Add("PARTNO", this.cdx02_PARTNO.GetValue().ToString());
                paramSet_UCOST_CUSTCD.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source_VIN_ITEM_PRDTDIV = _WSINQUERY.Inquery_VIN_ITEM_PRDTDIV(paramSet_VIN_ITEM_PRDTDIV);
                DataSet source_VIN_ITEM_PRDTDIV = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_VIN_ITEM_PRDTDIV"), paramSet_VIN_ITEM_PRDTDIV);
                if (source_VIN_ITEM_PRDTDIV.Tables[0].Rows.Count != 0)
                {
                    this.txt02_VINCD.SetValue(source_VIN_ITEM_PRDTDIV.Tables[0].Rows[0]["PARTDESC"].ToString());
                    this.lbl02_UNITEA.SetValue(source_VIN_ITEM_PRDTDIV.Tables[0].Rows[0]["UNIT"].ToString());
                    this.txt02_PRDT_DIV.SetValue(source_VIN_ITEM_PRDTDIV.Tables[0].Rows[0]["PRDT_DIV"].ToString());
                }

                //DataSet source_UCOST_CUSTCD = _WSINQUERY.Inquery_UCOST_CUSTCD(paramSet_UCOST_CUSTCD);
                DataSet source_UCOST_CUSTCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_UCOST_CUSTCD"), paramSet_UCOST_CUSTCD);
                if (source_UCOST_CUSTCD.Tables[0].Rows.Count != 0)
                {
                    this.nme02_RTN_UCOST.SetValue(source_UCOST_CUSTCD.Tables[0].Rows[0]["PART_UCOST"].ToString());
                }

                this.AfterInvokeServer();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }        
        }

        #endregion
    }
}
