#region ▶ Description & History
/* 
 * 프로그램명 : QA20045 주행거리 관리
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
    /// <b>주행거리 관리</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 4:14:53<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 4:14:53   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20045 : AxCommonBaseControl
    {
        //private IQA20045 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20045";

        #region [ 초기화 작업 정의 ]

        public QA20045()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20045>("QA00", "QA20045.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("QA20045_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20045_MSG2"); 

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

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객코드";
                this.cdx01_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_NATIONCD.HEPopupHelper = new QASubWindow();
                this.cdx01_NATIONCD.PopupTitle = this.GetLabel("NATIONCD");//"국가코드";
                this.cdx01_NATIONCD.CodeParameterName = "XD_CODE";
                this.cdx01_NATIONCD.NameParameterName = "XD_NAME";
                this.cdx01_NATIONCD.HEParameterAdd("XD_CLASS", "I3");
                this.cdx01_NATIONCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_NATIONCD.HEParameterAdd("USE_YN", "");
                this.cdx01_NATIONCD.HEParameterAdd("GROUPCD", "");

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객코드";
                this.cdx02_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx02_VENDCD.NameParameterName = "CUSTNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_NATIONCD.HEPopupHelper = new QASubWindow();
                this.cdx02_NATIONCD.PopupTitle = this.GetLabel("NATIONCD");//"국가코드";
                this.cdx02_NATIONCD.CodeParameterName = "XD_CODE";
                this.cdx02_NATIONCD.NameParameterName = "XD_NAME";
                this.cdx02_NATIONCD.HEParameterAdd("XD_CLASS", "I3");
                this.cdx02_NATIONCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_NATIONCD.HEParameterAdd("USE_YN", "");
                this.cdx02_NATIONCD.HEParameterAdd("GROUPCD", "");

                this.grd01_QA20045.AllowEditing = false;
                this.grd01_QA20045.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20045.Initialize();
                this.grd01_QA20045.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20045.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20045.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "고객사", "VENDCD", "CUSTNM");
                this.grd01_QA20045.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "차종코드", "VINCD", "VINCD");
                this.grd01_QA20045.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "차종코드", "VINTYPE", "VINCD");
                this.grd01_QA20045.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "차종명", "VINNM", "VINNM");
                this.grd01_QA20045.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "국가코드", "CLAIM_NATIONCD", "NATIONCD");
                this.grd01_QA20045.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "국가", "CLAIM_NATIONNM", "NATION");
                this.grd01_QA20045.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "주행거리(Km)", "TRAVEL_DST", "TRAVEL_DST_UNIT");
                this.grd01_QA20045.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "사용개월(월)", "USE_MM", "USE_MM2");
                this.grd01_QA20045.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "생산시점", "PROD_MSTONE", "PROD_MSTONE");
                this.grd01_QA20045.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "종료시점", "END_DATE", "END_DATE5");

                this.grd01_QA20045.SetColumnType(AxFlexGrid.FCellType.Decimal, "TRAVEL_DST");
                this.grd01_QA20045.SetColumnType(AxFlexGrid.FCellType.Decimal, "USE_MM");

                this.SetRequired(lbl01_BIZNM2, lbl01_CUSTNM, lbl02_BIZNM2, lbl02_PROD_DATE, lbl02_END_DATE, lbl02_CUSTNM, lbl02_VIN, lbl02_USE_MM, lbl02_NATION, lbl02_TRAVEL_DST);

                this.cdx01_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.cbo01_BIZCD.GetValue().ToString()));

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
                this.cbo02_BIZCD.SetValue(this.cbo01_BIZCD.GetValue().ToString());
                this.cdx02_VENDCD.SetValue(this.cdx01_VENDCD.GetValue().ToString());

                this.dte02_END_DATE.SetFromEnd();

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.cdx02_VENDCD.Enabled = true;
                this.cdx02_VINCD.Enabled = true;
                this.cdx02_NATIONCD.Enabled = true;
                this.dte02_PROD_MSTONE.Enabled = true;
                this.nme02_USE_MM.ReadOnly = false;
                this.nme02_TRAVEL_DST.ReadOnly = false;

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
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string NATIONCD = this.cdx01_NATIONCD.GetValue().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("NATIONCD", NATIONCD);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20045.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "VINCD", "NATIONCD", "VENDCD", "PROD_MSTONE", "END_DATE", "USE_MM", "TRAVEL_DST");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_NATIONCD.GetValue(),
                    this.cdx02_VENDCD.GetValue(),
                    this.dte02_PROD_MSTONE.GetDateText(),
                    this.dte02_END_DATE.GetDateText(),
                    this.nme02_USE_MM.GetDBValue(),
                    this.nme02_TRAVEL_DST.GetDBValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("주행거리가 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "VINCD", "NATIONCD", "VENDCD", "PROD_MSTONE");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_NATIONCD.GetValue(),
                    this.cdx02_VENDCD.GetValue(),
                    this.dte02_PROD_MSTONE.GetDateText()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("주행거리가 삭제 되었습니다.");
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

        private void grd01_QA20045_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20045.SelectedRowIndex;

                if (Row >= this.grd01_QA20045.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20045.GetValue(Row, "BIZCD").ToString();
                    string VENDCD = this.grd01_QA20045.GetValue(Row, "VENDCD").ToString();
                    string VINCD = this.grd01_QA20045.GetValue(Row, "VINCD").ToString();
                    string NATIONCD = this.grd01_QA20045.GetValue(Row, "CLAIM_NATIONCD").ToString();
                    string PROD_MSTONE = this.grd01_QA20045.GetValue(Row, "PROD_MSTONE").ToString();
                    string END_DATE = this.grd01_QA20045.GetValue(Row, "END_DATE").ToString();
                    string USE_MM = this.grd01_QA20045.GetValue(Row, "USE_MM").ToString();
                    string TRAVEL_DST = this.grd01_QA20045.GetValue(Row, "TRAVEL_DST").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.cdx02_VENDCD.SetValue(VENDCD);
                    this.cdx02_VINCD.SetValue(VINCD);
                    this.cdx02_NATIONCD.SetValue(NATIONCD);
                    this.dte02_PROD_MSTONE.SetValue(PROD_MSTONE);
                    this.dte02_END_DATE.SetValue(END_DATE);
                    this.nme02_USE_MM.SetValue(USE_MM);
                    this.nme02_TRAVEL_DST.SetValue(TRAVEL_DST);

                    this.cbo02_BIZCD.Enabled = false;
                    this.cdx02_VENDCD.Enabled = false;
                    this.cdx02_VINCD.Enabled = false;
                    this.cdx02_NATIONCD.Enabled = false;
                    this.dte02_PROD_MSTONE.Enabled = false;
                    this.nme02_USE_MM.ReadOnly = true;
                    this.nme02_TRAVEL_DST.ReadOnly = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cdx02_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.cbo02_BIZCD.GetValue().ToString()));
        }

        private void cbo01_BIZCD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cdx01_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.cbo01_BIZCD.GetValue().ToString()));
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            string CORCD = _CORCD;
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
            string VINCD = this.cdx02_VINCD.GetValue().ToString();
            string NATIONCD = this.cdx02_NATIONCD.GetValue().ToString();
            string PROD_MSTONE = this.dte02_PROD_MSTONE.GetDateText().ToString();
            string END_DATE = this.dte02_END_DATE.GetDateText().ToString();
            string USE_MM = this.nme02_USE_MM.GetValue().ToString();
            string TRAVEL_DST = this.nme02_TRAVEL_DST.GetValue().ToString();

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

            if (this.GetByteCount(VENDCD) == 0)
            {
                //MsgBox.Show("고객사코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CUSTCD"));
                return false;
            }

            if (this.GetByteCount(VINCD) == 0)
            {
                //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("VINCD"));
                return false;
            }

            if (this.GetByteCount(NATIONCD) == 0)
            {
                //MsgBox.Show("국가코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("NATIONCD"));
                return false;
            }

            if (this.GetByteCount(PROD_MSTONE) == 8)
            {
                //MsgBox.Show("생산일자가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("PROD_DATE"));
                return false;
            }

            if (this.GetByteCount(END_DATE) == 8)
            {
                //MsgBox.Show("종료일자가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("END_DATE"));
                return false;
            }

            if (Int32.Parse(PROD_MSTONE.Replace("-", "")) > Int32.Parse(END_DATE.Replace("-", "")))
            {
                //MsgBox.Show("종료일자는 생산일자보다 작을 수 없습니다.");
                MsgCodeBox.Show("QA00-012");
                return false;
            }

            if (Int32.Parse(USE_MM) <= 0)
            {
                //MsgBox.Show("사용개월이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("USE_MM"));
                return false;
            }

            if (Int32.Parse(TRAVEL_DST) <= 0)
            {
                //MsgBox.Show("주행거리가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("TRAVEL_DST"));
                return false;
            }

            try
            {
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
            string CORCD = _CORCD;
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
            string VINCD = this.cdx02_VINCD.GetValue().ToString();
            string NATIONCD = this.cdx02_NATIONCD.GetValue().ToString();
            string PROD_MSTONE = this.dte02_PROD_MSTONE.GetDateText().ToString();
            string END_DATE = this.dte02_END_DATE.GetDateText().ToString();
            string USE_MM = this.nme02_USE_MM.GetValue().ToString();
            string TRAVEL_DST = this.nme02_TRAVEL_DST.GetValue().ToString();

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

            if (this.GetByteCount(VENDCD) == 0)
            {
                //MsgBox.Show("고객사코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CUSTCD"));
                return false;
            }

            if (this.GetByteCount(VINCD) == 0)
            {
                //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("VINCD"));
                return false;
            }

            if (this.GetByteCount(NATIONCD) == 0)
            {
                //MsgBox.Show("국가코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("NATIONCD"));
                return false;
            }

            if (this.GetByteCount(PROD_MSTONE) == 8)
            {
                //MsgBox.Show("생산일자가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("PROD_DATE"));
                return false;
            }

            try
            {
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

        private bool IsSelectValid()
        {
            try
            {
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("고객사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CUSTCD"));
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

        #region [ 사용자 정의 메서드 ] 

        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_NATIONCD.HEUserParameterSetValue("XD_CLASS", "I3");
                this.cdx01_NATIONCD.HEUserParameterSetValue("USE_YN", "");
                this.cdx01_NATIONCD.HEUserParameterSetValue("GROUPCD", "");
                this.cdx02_NATIONCD.HEUserParameterSetValue("XD_CLASS", "I3");
                this.cdx02_NATIONCD.HEUserParameterSetValue("USE_YN", "");
                this.cdx02_NATIONCD.HEUserParameterSetValue("GROUPCD", "");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
