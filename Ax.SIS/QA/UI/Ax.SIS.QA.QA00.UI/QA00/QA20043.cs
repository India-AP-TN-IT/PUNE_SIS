#region ▶ Description & History
/* 
 * 프로그램명 : QA20043 외주 => MIP 항목 관리
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
    /// <b>외주 => MIP 항목 관리</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 4:09:46<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 4:09:46   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20043 : AxCommonBaseControl
    {
        //private IQA20043 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20043";

        #region [ 초기화 작업 정의 ]

        public QA20043()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20043>("QA00", "QA20043.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("QA20043_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20043_MSG2");   

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

                this.grd01_QA20043.AllowEditing = false;
                this.grd01_QA20043.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20043.Initialize();
                this.grd01_QA20043.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20043.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20043.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD", "VIN");
                this.grd01_QA20043.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "차종", "VINTYPE", "VIN");
                this.grd01_QA20043.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "품명", "ITEMCD", "ITEMNM4");
                this.grd01_QA20043.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "품명", "ITEMTYPE", "ITEMNM4");
                this.grd01_QA20043.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 500, "품목명", "ITEMNM", "ITEMNM3");
                this.grd01_QA20043.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적용시작일", "BEG_DATE", "APPLY_BEG_DATE");
                this.grd01_QA20043.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적용종료일", "END_DATE", "APPLY_END_DATE");

                this.SetRequired(lbl01_BIZNM2, lbl02_BIZNM2, lbl02_VIN, lbl02_ITEMNM4, lbl02_APPLY_BEG_DATE);

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

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20043.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "VINCD", "ITEMCD", "BEG_DATE", 
                    "END_DATE");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_ITEMCD.GetValue(),
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
                //MsgBox.Show("외주 => MIP 항목이 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "VINCD", "ITEMCD", "BEG_DATE");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_ITEMCD.GetValue(),
                    this.dte02_BEG_DATE.GetDateText()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);
                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("외주 => MIP 항목이 삭제 되었습니다.");
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

        private void grd01_QA20043_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20043.SelectedRowIndex;

                if (Row >= this.grd01_QA20043.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20043.GetValue(Row, "BIZCD").ToString();
                    string VINCD = this.grd01_QA20043.GetValue(Row, "VINCD").ToString();
                    string BEG_DATE = this.grd01_QA20043.GetValue(Row, "BEG_DATE").ToString();
                    string ITEMCD = this.grd01_QA20043.GetValue(Row, "ITEMCD").ToString();
                    string END_DATE = this.grd01_QA20043.GetValue(Row, "END_DATE").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.cdx02_VINCD.SetValue(VINCD);
                    this.dte02_BEG_DATE.SetValue(BEG_DATE);
                    this.cdx02_ITEMCD.SetValue(ITEMCD);
                    this.dte02_END_DATE.SetValue(END_DATE);

                    this.cbo02_BIZCD.Enabled = false;
                    this.cdx02_VINCD.Enabled = false;
                    this.cdx02_ITEMCD.Enabled = false;
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
                string BEG_DATE = this.dte02_BEG_DATE.GetDateText().ToString();
                string END_DATE = this.dte02_END_DATE.GetDateText().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZNM2"));
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("VINCD"));
                    return false;
                }

                if (this.GetByteCount(ITEMCD) == 0)
                {
                    //MsgBox.Show("품목코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("ITEMCD"));
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
                string BEG_DATE = this.dte02_BEG_DATE.GetDateText().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZNM2"));
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("VINCD"));
                    return false;
                }

                if (this.GetByteCount(ITEMCD) == 0)
                {
                    //MsgBox.Show("품목코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("ITEMCD"));
                    return false;
                }

                if (this.GetByteCount(BEG_DATE) == 8)
                {
                    //MsgBox.Show("적용시작일이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("APPLY_BEG_DATE"));
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
