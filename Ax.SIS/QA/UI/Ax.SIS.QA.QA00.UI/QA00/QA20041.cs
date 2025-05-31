#region ▶ Description & History
/* 
 * 프로그램명 : QA20041 업체별 분담율 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
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
    /// <b>업체별 분담율 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 3:52:42<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 3:52:42   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20041 : AxCommonBaseControl
    {
        //private IQA20041 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20041";

        #region [ 초기화 작업 정의 ]

        public QA20041()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20041>("QA00", "QA20041.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("QA20041_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20041_MSG2");

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

                this.cbo01_BIZCD.DataBind(this.GetBizCD(_CORCD).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(_CORCD).Tables[0], false);
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

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");// "품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx02_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx02_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx02_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_ITEMCD.SetCodePixedLength();

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_OCCUR_DIVCD.DataBind(this.GetTypeCode("C4").Tables[0], true);
                this.cbo01_OCCUR_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_OCCUR_DIVCD.DataBind(this.GetTypeCode("C4").Tables[0], true);
                this.cbo02_OCCUR_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA20041.AllowEditing = false;
                this.grd01_QA20041.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20041.Initialize();
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "순번", "SEQ", "SEQ_NO");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VIN");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINTYPE", "VIN");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 70, "품목", "ITEMCD", "ITEM");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 70, "품목", "ITEMTYPE", "ITEM");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품목명", "ITEMNM", "ITEMNM3");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "거래처코드", "VENDCD", "VENDORCD");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "거래처명", "VENDNM", "VENDORNM");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "분담율", "SHA_RATE", "SHA_RATE");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "발생구분코드", "OCCUR_DIVCD", "OCCUR_DIVCD");
                this.grd01_QA20041.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "발생구분코드", "OCCUR_DIVTYPE", "OCCUR_DIVCD");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "발생구분", "OCCUR_DIVNM", "OCCUR_DIV");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "원인부품", "APPLI_PART", "APPLI_PART");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "현상", "PRESCD", "PRESENT_SIT");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "생산시작일", "BEG_DATE", "PROD_BEG_DATE");
                this.grd01_QA20041.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "생산종료일", "END_DATE", "PROD_END_DATE");
                this.grd01_QA20041.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01_QA20041.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");
                this.SetRequired(lbl01_BIZNM2, lbl02_BIZNM2, lbl02_VIN, lbl02_ITEMNM4, lbl02_PROD_VENDOR, lbl02_OCCUR_DIV, lbl02_APPLI_PART, lbl02_PRESCD, lbl02_APPLY_BEG_DATE);
                this.txt01_APPLI_PART.SetValid(20, AxTextBox.TextType.UAlphabet);
                this.txt01_PRESCD.SetValid(4, AxTextBox.TextType.UAlphabet);
                this.txt02_APPLI_PART.SetValid(20, AxTextBox.TextType.UAlphabet);
                this.txt02_PRESCD.SetValid(4, AxTextBox.TextType.UAlphabet);

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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.dte02_END_DATE.SetFromEnd();

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.cdx02_VINCD.Enabled = true;
                this.cdx02_ITEMCD.Enabled = true;
                this.cdx02_VENDCD.Enabled = true;
                this.cbo02_OCCUR_DIVCD.Enabled = true;
                this.txt02_APPLI_PART.ReadOnly = false;
                this.txt02_PRESCD.ReadOnly = false;
                this.dte02_BEG_DATE.Enabled = true;
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
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx01_ITEMCD.GetValue().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string OCCUR_DIVCD = this.cbo01_OCCUR_DIVCD.GetValue().ToString();
                string APPLI_PART = this.txt01_APPLI_PART.GetValue().ToString();
                string PRESCD = this.txt01_PRESCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("OCCUR_DIVCD", OCCUR_DIVCD);
                paramSet.Add("APPLI_PART", APPLI_PART);
                paramSet.Add("PRESCD", PRESCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20041.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SEQ", "VINCD", "ITEMCD", "VENDCD", "SHA_RATE", "OCCUR_DIVCD", "APPLI_PART", "PRESCD", "BEG_DATE", "END_DATE");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_SEQ.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_ITEMCD.GetValue(),
                    this.cdx02_VENDCD.GetValue(),
                    this.txt02_SHA_RATE.GetValue(),
                    this.cbo02_OCCUR_DIVCD.GetValue(),
                    this.txt02_APPLI_PART.GetValue(),
                    this.txt02_PRESCD.GetValue(),
                    this.dte02_BEG_DATE.GetDateText(),
                    this.dte02_END_DATE.GetDateText()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("업체별 분담율이 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SEQ");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo01_BIZCD.GetValue(),
                    this.txt02_SEQ.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);
                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("업체별 분담율이 삭제 되었습니다.");
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

        private void grd01_QA20041_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20041.SelectedRowIndex;

                if (Row >= this.grd01_QA20041.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20041.GetValue(Row, "BIZCD").ToString();
                    string SHA_RATE = this.grd01_QA20041.GetValue(Row, "SHA_RATE").ToString();
                    string SEQ = this.grd01_QA20041.GetValue(Row, "SEQ").ToString();
                    string VINCD = this.grd01_QA20041.GetValue(Row, "VINCD").ToString();
                    string OCCUR_DIVCD = this.grd01_QA20041.GetValue(Row, "OCCUR_DIVCD").ToString();
                    string ITEMCD = this.grd01_QA20041.GetValue(Row, "ITEMCD").ToString();
                    string APPLI_PART = this.grd01_QA20041.GetValue(Row, "APPLI_PART").ToString();
                    string BEG_DATE = this.grd01_QA20041.GetValue(Row, "BEG_DATE").ToString();
                    string VENDCD = this.grd01_QA20041.GetValue(Row, "VENDCD").ToString();
                    string PRESCD = this.grd01_QA20041.GetValue(Row, "PRESCD").ToString();
                    string END_DATE = this.grd01_QA20041.GetValue(Row, "END_DATE").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.txt02_SHA_RATE.SetValue(SHA_RATE);
                    this.txt02_SEQ.SetValue(SEQ);
                    this.cdx02_VINCD.SetValue(VINCD);
                    this.cbo02_OCCUR_DIVCD.SetValue(OCCUR_DIVCD);
                    this.cdx02_ITEMCD.SetValue(ITEMCD);
                    this.txt02_APPLI_PART.SetValue(APPLI_PART);
                    this.dte02_BEG_DATE.SetValue(BEG_DATE);
                    this.cdx02_VENDCD.SetValue(VENDCD);
                    this.txt02_PRESCD.SetValue(PRESCD);
                    this.dte02_END_DATE.SetValue(END_DATE);

                    this.cbo02_BIZCD.Enabled = false;
                    this.cdx02_VINCD.Enabled = false;
                    this.cdx02_ITEMCD.Enabled = false;
                    this.cdx02_VENDCD.Enabled = false;
                    this.cbo02_OCCUR_DIVCD.Enabled = false;
                    this.txt02_APPLI_PART.ReadOnly = true;
                    this.txt02_PRESCD.ReadOnly = true;
                    this.dte02_BEG_DATE.Enabled = false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string OCCUR_DIVCD = this.cbo02_OCCUR_DIVCD.GetValue().ToString();
                string APPLI_PART = this.txt02_APPLI_PART.GetValue().ToString();
                string PRESCD = this.txt02_PRESCD.GetValue().ToString();
                string BEG_DATE = this.dte02_BEG_DATE.GetDateText().ToString();
                string END_DATE = this.dte02_END_DATE.GetDateText().ToString();
                string SEQ = this.txt02_SEQ.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZNM2"));
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("VINCD"));
                    return false;
                }

                if (this.GetByteCount(ITEMCD) == 0)
                {
                    //MsgBox.Show("품목코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("ITEMCD"));
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("거래처코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("VENDORCD"));

                    return false;
                }

                if (this.GetByteCount(OCCUR_DIVCD) == 0)
                {
                    //MsgBox.Show("발생구분코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("OCCUR_DIVCD"));
                    return false;
                }

                if (this.GetByteCount(APPLI_PART) == 0 || this.GetByteCount(APPLI_PART) > 20)
                {
                    //MsgBox.Show("발생구분코드 입력이 잘못되었습니다.(범위 : 1~20Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("OCCUR_DIVCD"), "1~20Byte");
                    return false;
                }

                if (this.GetByteCount(PRESCD) == 0 || this.GetByteCount(PRESCD) > 4)
                {
                    //MsgBox.Show("현상코드 입력이 잘못되었습니다.(범위 : 1~4Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("PRESCD"), "1~4Byte");
                    return false;
                }

                if (this.GetByteCount(BEG_DATE) == 8)
                {
                    //MsgBox.Show("적용시작일이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("APPLY_BEG_DATE"));
                    return false;
                }

                if (Int32.Parse(BEG_DATE.Replace("-", "")) > Int32.Parse(END_DATE.Replace("-", "")))
                {
                    //MsgBox.Show("적용종료일은 적용시작일보다 작을 수 없습니다.");
                    MsgCodeBox.Show("QA00-010");
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
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string OCCUR_DIVCD = this.cbo02_OCCUR_DIVCD.GetValue().ToString();
                string APPLI_PART = this.txt02_APPLI_PART.GetValue().ToString();
                string PRESCD = this.txt02_PRESCD.GetValue().ToString();
                string BEG_DATE = this.dte02_BEG_DATE.GetDateText().ToString();
                string SEQ = this.txt02_SEQ.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZNM2"));
                    return false;
                }

                if (this.GetByteCount(SEQ) == 0)
                {
                    //MsgBox.Show("올바르지 않는 데이터 입니다. 그리드에서 선택후 삭제 하시기 바랍니다.");
                    MsgCodeBox.Show("QA00-011");
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

    }
}
