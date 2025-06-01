#region ▶ Description & History
/* 
 * 프로그램명 : QA20214 고객사 입고 불량 등록
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
    /// <b>고객사 입고 불량 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20214 : AxCommonBaseControl
    {
        //private IQA20214 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private String _GENERATER;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20214";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        //private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20214()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20214>("QA01", "QA20214.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.groupBox2.Text = this.GetLabel("QA20214_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20214_MSG2");

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;
                _GENERATER = "";

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


                this.cdx01_CUSTCD.HEPopupHelper = new QASubWindow();
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx01_CUSTCD.CodeParameterName = "CUSTCD";
                this.cdx01_CUSTCD.NameParameterName = "CUSTNM";
                this.cdx01_CUSTCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_CUSTCD.HEPopupHelper = new QASubWindow();
                this.cdx02_CUSTCD.PopupTitle = this.GetLabel("CUSTCD");//"고객사코드";
                this.cdx02_CUSTCD.CodeParameterName = "CUSTCD";
                this.cdx02_CUSTCD.NameParameterName = "CUSTNM";
                this.cdx02_CUSTCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");// "귀책업체코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                //this.cdx02_RCPT_EMPNO.HEPopupHelper = new QASubWindow();
                //this.cdx02_RCPT_EMPNO.PopupTitle = this.GetLabel("REC_EMP");// "접수자";
                //this.cdx02_RCPT_EMPNO.CodeParameterName = "EMPNO";
                //this.cdx02_RCPT_EMPNO.NameParameterName = "EMPNONM";
                //this.cdx02_RCPT_EMPNO.HEParameterAdd("LANG_SET", _LANG_SET);
                //this.cdx02_RCPT_EMPNO.HEParameterAdd("CORCD", _CORCD);

                this.cdx02_RCPT_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_RCPT_EMPNO.PopupTitle = this.GetLabel("REC_EMP");
                this.cdx02_RCPT_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_RCPT_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_RCPT_EMPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_RCPT_EMPNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_RCPT_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx02_DEFCD.PopupTitle = this.GetLabel("DEFCD");//"불량코드";
                this.cdx02_DEFCD.CodeParameterName = "DEFCD";
                this.cdx02_DEFCD.NameParameterName = "DEFNM";                
                this.cdx02_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFCD.HEParameterAdd("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = this.GetLabel("PARTNO_TITLE");//"품번";
                this.cdx02_PARTNO.CodeParameterName = "ASSYNO_OF_ALCCD";
                this.cdx02_PARTNO.NameParameterName = "ASSYNO_OF_ALCNM";
                this.cdx02_PARTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_PARTNO.HEParameterAdd("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_PARTNO.HEParameterAdd("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_PARTNO.HEParameterAdd("ALCCD", "");
                this.cdx02_PARTNO.HEParameterAdd("VINCD", "");
                this.cdx02_PARTNO.HEParameterAdd("ITEMCD", "");
                this.cdx02_PARTNO.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_PARTNO.Initialize();


                this.txt02_RTNNO.SetReadOnly(true);
                this.nme02_RTN_QTY.DataType = typeof(decimal);

                DataSet source = this.GetTypeCode("Z6", "Z7");
                this.cbo02_RTN_AREA.DataBind(source.Tables[0], true);
                this.cbo02_RTN_AREA.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_CNTTCD.DataBind(source.Tables[1], true);
                this.cbo02_CNTTCD.DropDownStyle = ComboBoxStyle.DropDownList;

                           
                this.grd01_QA20214.AllowEditing = false;
                this.grd01_QA20214.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20214.Initialize();
                this.grd01_QA20214.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20214.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD","BIZCD");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "등록일자", "RCV_DATE", "REG_DATE");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "반송번호", "RTNNO", "RETNO");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "고객사코드", "CUSTCD", "CUSTCD");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "고객사명", "CUSTNM", "CUSTNM");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RTN_DATE","OCCUR_DATE");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMNM","ITEM");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNAME", "PARTNM");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "불량코드", "DEFCD", "DEFCD");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량유형", "DEFNM", "DEFNM");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "RTN_QTY", "DEF_QTY");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "발생장소", "RTN_AREANM", "RTN_AREANM");
                this.grd01_QA20214.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "발생장소", "RTN_AREA", "RTN_AREA");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "조치내용", "CNTTCDNM", "MGRT_CNTT");
                this.grd01_QA20214.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "조치내용", "CNTTCD", "MGRT_CNTT");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "LOT NO", "LOTNO");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "시스템", "GENERATER", "SYSTEM");
                this.grd01_QA20214.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");

                
                this.grd01_QA20214.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 80, "VENDCD", "VENDCD");
                this.grd01_QA20214.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 80, "RCPT_EMPNO", "RCPT_EMPNO");
                this.grd01_QA20214.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_QTY");
                this.grd01_QA20214.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01_QA20214.SetColumnType(AxFlexGrid.FCellType.Date, "RTN_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_REG_DATE, 
                                lbl02_BIZNM,  lbl02_LOTNO,
                                lbl02_REG_DATE, lbl02_OCCUR_DATE, lbl02_PARTNO, 
                                lbl02_RTN_AREA, lbl02_DEF_QTY, lbl02_MGRT_CNTT, 
                                lbl02_CUSTNM, lbl02_REC_EMP);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


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
                _GENERATER = "";

                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }

                this.txt02_RTNNO.Initialize();
                this.txt02_RTNNO.SetReadOnly(true);

                this.dte02_LOTNO.Initialize();
                this.cdx02_VENDCD.Initialize();
                this.dte02_RCV_DATE.Initialize();
                this.dte02_RTN_DATE.Initialize();

                this.cdx02_PARTNO.Initialize();
                this.cbo02_RTN_AREA.Initialize();
                this.nme02_RTN_QTY.SetValue("0");

                this.cdx02_DEFCD.Initialize();
                this.cbo02_CNTTCD.Initialize();
                this.cdx02_CUSTCD.Initialize();
                this.cdx02_RCPT_EMPNO.Initialize();
                this.txt02_REMARK.Initialize();
                this.lbl02_UNITEA.SetValue("EA");
                this.grd01_QA20214.Row = -1;

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
                string RCV_DATE = this.dte01_RCV_DATE.GetDateText().ToString();
                string CUSTCD = this.cdx01_CUSTCD.GetValue().ToString();
                string PARTNO_PARTNM = this.txt01_PARTNO_PARTNONM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("CUSTCD", CUSTCD);
                paramSet.Add("PARTNO_PARTNM", PARTNO_PARTNM);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
              
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20214.SetValue(source);

                this.BtnReset_Click(null, null);
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
                    "CORCD", "BIZCD", "RTNNO", "RCV_DATE", "RTN_DATE", "CUSTCD", 
                    "PARTNO", "RTN_QTY", "DEFCD", "LOTNO", "RCPT_EMPNO", "VENDCD",
                    "RTN_AREA", "CNTTCD", "REMARK", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_RTNNO.GetValue(),
                    this.dte02_RCV_DATE.GetDateText(),
                    this.dte02_RTN_DATE.GetDateText(),
                    this.cdx02_CUSTCD.GetValue(),
                    this.cdx02_PARTNO.GetValue(),
                    this.nme02_RTN_QTY.GetDBValue(),
                    this.cdx02_DEFCD.GetValue(),
                    this.dte02_LOTNO.GetDateText(),
                    this.cdx02_RCPT_EMPNO.GetValue(),
                    this.cdx02_VENDCD.GetValue(),                                     
                    this.cbo02_RTN_AREA.GetValue(),
                    this.cbo02_CNTTCD.GetValue(),
                    this.txt02_REMARK.GetValue(),
                    this.cbo01_PLANT_DIV.GetValue().ToString()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("고객사 입고 불량 등록이 저장되었습니다.");
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

                //MsgBox.Show("고객사 입고 불량 등록이 삭제 되었습니다.");
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
        
        #region [ 기타 컨트롤에 대한 이벤트 정의]

        private void grd01_QA20214_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20214.SelectedRowIndex;
                
                if (Row >= this.grd01_QA20214.Rows.Fixed)
                {
                    this.grd_SELECT(Row);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
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
  
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cdx02_RCPT_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD =  this.cbo02_BIZCD.GetValue().ToString();
                string RTNNO = this.txt02_RTNNO.GetValue().ToString();
                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string RTN_DATE = this.dte02_RTN_DATE.GetDateText().ToString();
                string CUSTCD = this.cdx02_CUSTCD.GetValue().ToString();
                string PARTNO = this.cdx02_PARTNO.GetValue().ToString();
                string RTN_QTY = this.nme02_RTN_QTY.GetValue().ToString();
                string DEFCD = this.cdx02_DEFCD.GetValue().ToString();
                string LOTNO = this.dte02_LOTNO.GetDateText().ToString();
                string RCPT_EMPNO = this.cdx02_RCPT_EMPNO.GetValue().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string RTN_AREA = this.cbo02_RTN_AREA.GetValue().ToString();
                string CNTTCD = this.cbo02_CNTTCD.GetValue().ToString();
                string REMARK = this.txt02_REMARK.GetValue().ToString();

                if (_GENERATER.Equals("GQMS"))
                {
                    //MsgBox.Show("GQMS 시스템에서 등록한 내용은 수정/삭제가 불가 합니다.");
                    MsgCodeBox.Show("QA01-0019");
                    return false;
                }

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

                if (this.GetByteCount(LOTNO) == 0)
                {
                    //MsgBox.Show("LOT NO 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_LOTNO.Text);
                    return false;
                }


                if (this.GetByteCount(RCV_DATE) == 0)
                {
                    //MsgBox.Show("등록일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_REG_DATE.Text);
                    return false;
                }


                if (this.GetByteCount(RTN_DATE) == 0)
                {
                    //MsgBox.Show("발생일자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_OCCUR_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(RTN_AREA) == 0)
                {
                    //MsgBox.Show("발생장소 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_RTN_AREA.Text);
                    return false;
                }

                if (Int32.Parse(RTN_QTY) <= 0)
                {
                    //MsgBox.Show("불량수량 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_DEF_QTY.Text);
                    return false;
                }

                if (this.GetByteCount(CNTTCD) == 0)
                {
                    //MsgBox.Show("조치내용 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_MGRT_CNTT.Text);
                    return false;
                }
                if (this.GetByteCount(CUSTCD) == 0)
                {
                    //MsgBox.Show("고객사 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CUSTNM.Text);
                    return false;
                }

                if (this.GetByteCount(RCPT_EMPNO) == 0)
                {
                    //MsgBox.Show("접수자 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_REC_EMP.Text);
                    return false;
                }

                if (this.GetByteCount(REMARK) > 4000)
                {
                    //MsgBox.Show("비고 데이터를 4000bytes 이하로 입력해 주세요.");
                    MsgCodeBox.Show("QA01-0020");
                    return false;
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


                if (_GENERATER.Equals("GQMS"))
                {
                    //MsgBox.Show("GQMS 시스템에서 등록한 내용은 수정/삭제가 불가 합니다.");
                    MsgCodeBox.Show("QA01-0019");
                    return false;
                }

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
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
        
        #region [ 사용자 정의 메서드 정의]

        private void grd_SELECT(int Row)
        {
            try
            {
                
                this.BtnReset_Click(null, null);
                this.BeforeInvokeServer(true);

                _GENERATER = this.grd01_QA20214.GetValue(Row, "GENERATER").ToString();

                this.cbo02_BIZCD.SetValue(this.grd01_QA20214.GetValue(Row, "BIZCD"));
                this.txt02_RTNNO.SetValue(this.grd01_QA20214.GetValue(Row, "RTNNO"));
                this.dte02_LOTNO.SetValue(this.grd01_QA20214.GetValue(Row, "LOTNO"));
                this.cdx02_VENDCD.SetValue(this.grd01_QA20214.GetValue(Row, "VENDCD"));
                this.dte02_RTN_DATE.SetValue(this.grd01_QA20214.GetValue(Row, "RTN_DATE"));
                this.dte02_RCV_DATE.SetValue(this.grd01_QA20214.GetValue(Row, "RCV_DATE")); 
                this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_PARTNO.SetValue(this.grd01_QA20214.GetValue(Row, "PARTNO"));
                this.cbo02_RTN_AREA.SetValue(this.grd01_QA20214.GetValue(Row, "RTN_AREA"));
                this.nme02_RTN_QTY.SetValue(this.grd01_QA20214.GetValue(Row, "RTN_QTY"));
                this.cdx02_DEFCD.SetValue(this.grd01_QA20214.GetValue(Row, "DEFCD"));
                this.cbo02_CNTTCD.SetValue(this.grd01_QA20214.GetValue(Row, "CNTTCD"));
                this.cdx02_CUSTCD.SetValue(this.grd01_QA20214.GetValue(Row, "CUSTCD"));
                this.cdx02_RCPT_EMPNO.SetValue(this.grd01_QA20214.GetValue(Row, "RCPT_EMPNO"));
                this.txt02_REMARK.SetValue(this.grd01_QA20214.GetValue(Row, "REMARK"));
                this.AfterInvokeServer();
                this.SUB_QUERT_VIEW();

                this.cbo02_BIZCD.Enabled = false;
                this.txt02_RTNNO.Enabled = false;

                

                this.grd01_QA20214.Row = Row;
                this.grd01_QA20214.Focus();
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx_SETTING()
        {
            try
            {
                
                this.cdx02_PARTNO.HEUserParameterSetValue("RCV_DATE", this.dte02_RTN_DATE.GetDateText().ToString());
                this.cdx02_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
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
                

                //DataSet source_VIN_ITEM_PRDTDIV = _WSINQUERY.Inquery_VIN_ITEM_PRDTDIV(paramSet_VIN_ITEM_PRDTDIV);
                DataSet source_VIN_ITEM_PRDTDIV = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_VIN_ITEM_PRDTDIV"), paramSet_VIN_ITEM_PRDTDIV);
                if (source_VIN_ITEM_PRDTDIV.Tables[0].Rows.Count != 0)
                {
                    this.lbl02_UNITEA.SetValue(source_VIN_ITEM_PRDTDIV.Tables[0].Rows[0]["UNIT"].ToString());
                }

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

               

    }
}
