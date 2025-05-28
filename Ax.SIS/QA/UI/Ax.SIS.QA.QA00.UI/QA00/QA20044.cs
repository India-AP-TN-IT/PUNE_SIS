#region ▶ Description & History
/* 
 * 프로그램명 : QA20044 클레임 국가 코드 관리
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
    /// <b>클레임 국가 코드 관리</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 4:13:36<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 4:13:36   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20044 : AxCommonBaseControl
    {
        //private IQA20044 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20044";

        #region [ 초기화 작업 정의 ]

        public QA20044()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20044>("QA00", "QA20044.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("QA20044_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20044_MSG2"); 

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

                this.cdx01_CLAIM_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_CLAIM_VENDCD.PopupTitle = this.GetLabel("CUSTCD");// "고객코드";
                this.cdx01_CLAIM_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_CLAIM_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_CLAIM_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_CLAIM_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_CLAIM_VENDCD.PopupTitle = this.GetLabel("CUSTCD");//"고객코드";
                this.cdx02_CLAIM_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx02_CLAIM_VENDCD.NameParameterName = "CUSTNM";
                this.cdx02_CLAIM_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_INS_NATIONCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INS_NATIONCD.PopupTitle = this.GetLabel("NATIONCD");//"국가코드";
                this.cdx01_INS_NATIONCD.CodeParameterName = "XD_CODE";
                this.cdx01_INS_NATIONCD.NameParameterName = "XD_NAME";
                this.cdx01_INS_NATIONCD.HEParameterAdd("XD_CLASS", "I3");
                this.cdx01_INS_NATIONCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_INS_NATIONCD.HEParameterAdd("USE_YN", "");
                this.cdx01_INS_NATIONCD.HEParameterAdd("GROUPCD", "");

                this.cdx02_INS_NATIONCD.HEPopupHelper = new QASubWindow();
                this.cdx02_INS_NATIONCD.PopupTitle = this.GetLabel("NATIONCD");//"국가코드";
                this.cdx02_INS_NATIONCD.CodeParameterName = "XD_CODE";
                this.cdx02_INS_NATIONCD.NameParameterName = "XD_NAME";
                this.cdx02_INS_NATIONCD.HEParameterAdd("XD_CLASS", "I3");
                this.cdx02_INS_NATIONCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_INS_NATIONCD.HEParameterAdd("USE_YN", "");
                this.cdx02_INS_NATIONCD.HEParameterAdd("GROUPCD", "");

                this.grd01_QA20044.AllowEditing = false;
                this.grd01_QA20044.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20044.Initialize();
                this.grd01_QA20044.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20044.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 140, "내부국가코드", "INS_NATIONCD", "INS_NATIONCD");
                this.grd01_QA20044.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "내부국가코드", "INS_NATIONTYPE", "INS_NATIONCD");
                this.grd01_QA20044.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "내부국가명", "INS_NATIONNM", "INS_NATIONNM");
                this.grd01_QA20044.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "고객사코드", "CLAIM_VENDCD", "CUSTCD");
                this.grd01_QA20044.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "고객사명", "CLAIM_VENDNM", "CUSTNM2");
                this.grd01_QA20044.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "클레임국가코드", "CLAIM_NATIONCD", "CLAIM_NATIONCD");
                this.grd01_QA20044.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "클레임국가명", "CLAIM_NATIONNM", "CLAIM_NATIONNM");

                this.SetRequired(lbl01_CUSTNM, lbl02_CUSTNM, lbl02_CLAIM_NATIONCD, lbl02_INS_NATIONCD, lbl02_CLAIM_NATIONNM);
                this.txt02_CLAIM_NATIONCD.SetValid(4, AxTextBox.TextType.UAlphabet);

                this.cdx01_CLAIM_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.UserInfo.BusinessCode));

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

                this.cdx02_CLAIM_VENDCD.SetValue(this.cdx01_CLAIM_VENDCD.GetValue());

                this.cdx02_CLAIM_VENDCD.Enabled = true;
                this.txt02_CLAIM_NATIONCD.ReadOnly = false;
                this.cdx02_INS_NATIONCD.Enabled = true;

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

                string INS_NATIONCD = this.cdx01_INS_NATIONCD.GetValue().ToString();
                string CLAIM_VENDCD = this.cdx01_CLAIM_VENDCD.GetValue().ToString();
                string CLAIM_NATIONCD = this.txt01_CLAIM_NATIONCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("INS_NATIONCD", INS_NATIONCD);
                paramSet.Add("CLAIM_VENDCD", CLAIM_VENDCD);
                paramSet.Add("CLAIM_NATIONCD", CLAIM_NATIONCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20044.SetValue(source);
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
                    "CORCD", "INS_NATIONCD", "CLAIM_VENDCD", "CLAIM_NATIONCD", "CLAIM_NATIONNM");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cdx02_INS_NATIONCD.GetValue(),
                    this.cdx02_CLAIM_VENDCD.GetValue(),
                    this.txt02_CLAIM_NATIONCD.GetValue(),
                    this.txt02_CLAIM_NATIONNM.GetValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("클레임 국가 코드가 저장되었습니다.");
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
                    "CORCD", "INS_NATIONCD", "CLAIM_VENDCD", "CLAIM_NATIONCD");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cdx02_INS_NATIONCD.GetValue(),
                    this.cdx02_CLAIM_VENDCD.GetValue(),
                    this.txt02_CLAIM_NATIONCD.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);
                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("클레임 국가 코드가 삭제 되었습니다.");
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

        private void grd01_QA20044_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20044.SelectedRowIndex;

                if (Row >= this.grd01_QA20044.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string CLAIM_VENDCD = this.grd01_QA20044.GetValue(Row, "CLAIM_VENDCD").ToString();
                    string CLAIM_NATIONCD = this.grd01_QA20044.GetValue(Row, "CLAIM_NATIONCD").ToString();
                    string INS_NATIONCD = this.grd01_QA20044.GetValue(Row, "INS_NATIONCD").ToString();
                    string CLAIM_NATIONNM = this.grd01_QA20044.GetValue(Row, "CLAIM_NATIONNM").ToString();

                    this.cdx02_CLAIM_VENDCD.SetValue(CLAIM_VENDCD);
                    this.txt02_CLAIM_NATIONCD.SetValue(CLAIM_NATIONCD);
                    this.cdx02_INS_NATIONCD.SetValue(INS_NATIONCD);
                    this.txt02_CLAIM_NATIONNM.SetValue(CLAIM_NATIONNM);

                    this.cdx02_CLAIM_VENDCD.Enabled = false;
                    this.txt02_CLAIM_NATIONCD.ReadOnly = true;
                    this.cdx02_INS_NATIONCD.Enabled = false;
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
                string CLAIM_VENDCD = this.cdx02_CLAIM_VENDCD.GetValue().ToString();
                string INS_NATIONCD = this.cdx02_INS_NATIONCD.GetValue().ToString();
                string CLAIM_NATIONCD = this.txt02_CLAIM_NATIONCD.GetValue().ToString();
                string CLAIM_NATIONNM = this.txt02_CLAIM_NATIONNM.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(CLAIM_VENDCD) == 0)
                {
                    //MsgBox.Show("고객사코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CUSTCD"));
                    return false;
                }

                if (this.GetByteCount(INS_NATIONCD) == 0)
                {
                    //MsgBox.Show("내부국가코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("INS_NATIONCD"));
                    return false;
                }

                if (this.GetByteCount(CLAIM_NATIONCD) == 0 || this.GetByteCount(CLAIM_NATIONCD) > 4)
                {
                    //MsgBox.Show("클레임국가코드 입력이 잘못되었습니다.(범위 : 1~4Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("CLAIM_NATIONCD"), "1~4Byte");
                    return false;
                }

                if (this.GetByteCount(CLAIM_NATIONNM) == 0 || this.GetByteCount(CLAIM_NATIONNM) > 50)
                {
                    //MsgBox.Show("클레임국가명코드 입력이 잘못되었습니다.(범위 : 1~50Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("CLAIM_NATIONNM"), "1~50Byte");
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
                string CLAIM_VENDCD = this.cdx02_CLAIM_VENDCD.GetValue().ToString();
                string INS_NATIONCD = this.cdx02_INS_NATIONCD.GetValue().ToString();
                string CLAIM_NATIONCD = this.txt02_CLAIM_NATIONCD.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(CLAIM_VENDCD) == 0)
                {
                    //MsgBox.Show("고객사코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CUSTCD"));
                    return false;
                }

                if (this.GetByteCount(INS_NATIONCD) == 0)
                {
                    //MsgBox.Show("내부국가코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("INS_NATIONCD"));
                    return false;
                }

                if (this.GetByteCount(CLAIM_NATIONCD) == 0 || this.GetByteCount(CLAIM_NATIONCD) > 4)
                {
                    //MsgBox.Show("클레임국가코드 입력이 잘못되었습니다.(범위 : 1~4Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("CLAIM_NATIONCD"), "1~4Byte");
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

        private bool IsSelectValid()
        {
            try
            {
                string CLAIM_VENDCD = this.cdx01_CLAIM_VENDCD.GetValue().ToString();

                if (this.GetByteCount(CLAIM_VENDCD) == 0)
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
                this.cdx01_INS_NATIONCD.HEUserParameterSetValue("XD_CLASS", "I3");
                this.cdx01_INS_NATIONCD.HEUserParameterSetValue("USE_YN", "");
                this.cdx01_INS_NATIONCD.HEUserParameterSetValue("GROUPCD", "");
                this.cdx02_INS_NATIONCD.HEUserParameterSetValue("XD_CLASS", "I3");
                this.cdx02_INS_NATIONCD.HEUserParameterSetValue("USE_YN", "");
                this.cdx02_INS_NATIONCD.HEUserParameterSetValue("GROUPCD", "");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
