#region ▶ Description & History
/* 
 * 프로그램명 : QA20031 자격증 마스터 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-27      배명희      통합WCF로 변경 
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
    /// <b>자격증 마스터 관리</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 7:09:42<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 7:09:42   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20031 : AxCommonBaseControl
    {
        //private IQA20031 _WSCOM;
        private String _CORCD;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20031";

        #region [ 초기화 작업 정의 ]

        public QA20031()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20031>("QA01", "QA20031.svc", "CustomBinding");
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

                this.grd01_QA20031.AllowEditing = false;
                this.grd01_QA20031.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20031.Initialize();
                this.grd01_QA20031.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20031.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "자격코드", "LICENSECD", "LICENSECD");
                this.grd01_QA20031.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 500, "자격명", "LICENSENM", "LICENSENM");

                this.SetRequired(lbl02_LICENSECD, lbl02_LICENSENM);
                this.txt02_LICENSECD.SetValid(4, AxTextBox.TextType.UAlphabet);
                this.txt02_LICENSENM.SetValid(150, AxTextBox.TextType.Default);

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
                foreach (Control ctl in groupBox_QA20031_MSG2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.txt02_LICENSECD.ReadOnly = false;
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
                string LICENSECD = this.txt01_LICENSECD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("LICENSECD", LICENSECD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20031.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "LICENSECD", "LICENSENM");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.txt02_LICENSECD.GetValue(),
                    this.txt02_LICENSENM.GetValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("자격증 코드가 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "LICENSECD");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.txt02_LICENSECD.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("자격증 코드가 삭제 되었습니다.");
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

        private void grd01_QA20031_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20031.SelectedRowIndex;

                if (Row >= this.grd01_QA20031.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string LICENSECD = this.grd01_QA20031.GetValue(Row, "LICENSECD").ToString();
                    string LICENSENM = this.grd01_QA20031.GetValue(Row, "LICENSENM").ToString();

                    this.txt02_LICENSECD.SetValue(LICENSECD);
                    this.txt02_LICENSENM.SetValue(LICENSENM);

                    this.txt02_LICENSECD.ReadOnly = true;
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
                string LICENSECD = this.txt02_LICENSECD.GetValue().ToString();
                string LICENSENM = this.txt02_LICENSENM.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD")); 
                    return false;
                }

                if (this.GetByteCount(LICENSECD) == 0 || this.GetByteCount(LICENSECD) > 4)
                {
                    //MsgBox.Show("자격코드 입력이 잘못되었습니다.(범위 : 1~4Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_LICENSECD.Text, "1~4Byte");
                    return false;
                }

                if (this.GetByteCount(LICENSENM) == 0 || this.GetByteCount(LICENSENM) > 20)
                {
                    //MsgBox.Show("자격명 입력이 잘못되었습니다.(범위 : 1~20Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_LICENSENM.Text, "1~20Byte");
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
                string LICENSECD = this.txt02_LICENSECD.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));  
                    return false;
                }

                if (this.GetByteCount(LICENSECD) == 0 || this.GetByteCount(LICENSECD) > 4)
                {
                    //MsgBox.Show("자격코드 입력이 잘못되었습니다.(범위 : 1~4Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_LICENSECD.Text, "1~4Byte");
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
