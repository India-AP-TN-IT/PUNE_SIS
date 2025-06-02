#region ▶ Description & History
/* 
 * 프로그램명 : QA20033 한도견본분류코드 등록
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

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>한도견본분류코드 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-31 오전 10:10:56<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-31 오전 10:10:56   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20033 : AxCommonBaseControl
    {
        //private IQA20033 _WSCOM;
        private String _CORCD;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20033";

        #region [ 초기화 작업 정의 ]

        public QA20033()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20033>("QA01", "QA20033.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;

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

                this.grd01_QA20033.AllowEditing = false;
                this.grd01_QA20033.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20033.Initialize();
                this.grd01_QA20033.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20033.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20033.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "분류코드", "CLASSCD", "CLASSCD");
                this.grd01_QA20033.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "분류명", "CLASSNM", "CLASSNM");
                this.grd01_QA20033.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "점검주기사용", "CHK_MGMTCYCLE_USE", "CHK_MGMTCYCLE_USE");
                this.grd01_QA20033.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "비고", "REMARK", "REMARK");
                this.grd01_QA20033.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 150, "PLANT_DIV", "PLANT_DIV", "PLANT_DIV");

                this.SetRequired(lbl01_BIZNM, lbl02_BIZNM, lbl02_CLASSCD, lbl02_CLASSNM);
                this.txt02_CLASSCD.SetValid(2, AxTextBox.TextType.UAlphabet);
                this.txt02_CLASSNM.SetValid(100, AxTextBox.TextType.Default);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo02_PLANT_DIV.SetReadOnly(true);

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
                foreach (Control ctl in groupBox_QA20033_MSG2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.txt02_CLASSCD.ReadOnly = false;

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
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
                string CLASSCD_CLASSNM = this.txt01_CLASSCD_CLASSNM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CLASSCD_CLASSNM", CLASSCD_CLASSNM);
                paramSet.Add("PLANT_DIV", cbo01_PLANT_DIV.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20033.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "CLASSCD", "CLASSNM", "CHK_MGMTCYCLE_USE", "REMARK","PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_CLASSCD.GetValue(),
                    this.txt02_CLASSNM.GetValue(),
                    this.chk02_SMPLCHK_MGMTCYCLE_USE.GetValue(),
                    this.txt02_REMARK.GetValue(),
                    this.cbo02_PLANT_DIV.GetValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("한도견본분류코드가 저장되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "CLASSCD","PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_CLASSCD.GetValue(),
                    this.cbo02_PLANT_DIV.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("한도견본분류코드가 삭제 되었습니다.");
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

        private void grd01_QA20033_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20033.SelectedRowIndex;

                if (Row >= this.grd01_QA20033.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20033.GetValue(Row, "BIZCD").ToString();
                    string CLASSCD = this.grd01_QA20033.GetValue(Row, "CLASSCD").ToString();
                    string CLASSNM = this.grd01_QA20033.GetValue(Row, "CLASSNM").ToString();
                    string CHK_MGMTCYCLE_USE = this.grd01_QA20033.GetValue(Row, "CHK_MGMTCYCLE_USE").ToString();
                    string REMARK = this.grd01_QA20033.GetValue(Row, "REMARK").ToString();
                    string PLANT_DIV = this.grd01_QA20033.GetValue(Row, "PLANT_DIV").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.txt02_CLASSCD.SetValue(CLASSCD);
                    this.txt02_CLASSNM.SetValue(CLASSNM);
                    this.chk02_SMPLCHK_MGMTCYCLE_USE.SetValue(CHK_MGMTCYCLE_USE);
                    this.txt02_REMARK.SetValue(REMARK);
                    this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);

                    this.cbo02_BIZCD.Enabled = false;
                    this.txt02_CLASSCD.ReadOnly = true;
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
                string CLASSCD = this.txt02_CLASSCD.GetValue().ToString();
                string CLASSNM = this.txt02_CLASSNM.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(CLASSCD) == 0)
                {
                    //MsgBox.Show("분류코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CLASSCD.Text);
                    return false;
                }

                if (this.GetByteCount(CLASSNM) == 0 || this.GetByteCount(CLASSNM) > 100)
                {
                    //MsgBox.Show("분류명 데이터 입력이 잘못되었습니다.(범위 : 1~100Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_CLASSNM.Text, "1~100Byte");
                    return false;
                }

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string CLASSCD = this.txt02_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(CLASSCD) == 0)
                {
                    //MsgBox.Show("분류코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CLASSCD.Text);
                    return false;
                }

                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
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
    }
}
