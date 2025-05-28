#region ▶ Description & History
/* 
 * 프로그램명 : QA20023 불량부위 관리
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

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>불량부위관리</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 10:39:43<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 10:39:43   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20023 : AxCommonBaseControl
    {
        //private IQA20023 _WSCOM;
        private String _CORCD;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20023";

        #region [ 초기화 작업 정의 ]

        public QA20023()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20023>("QA00", "QA20023.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("QA20021_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20021_MSG2");  

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

                
                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("A", "ALL");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");

                DataTable combo_source_INJECTION_USE_YN = new DataTable();
                combo_source_INJECTION_USE_YN.Columns.Add("CODE");
                combo_source_INJECTION_USE_YN.Columns.Add("NAME");
                combo_source_INJECTION_USE_YN.Rows.Add("Y", "YES");
                combo_source_INJECTION_USE_YN.Rows.Add("N", "NO");

                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_USE_YN.SetValue("Y");

                this.cbo01_INJECTION_USE_YN.DataBind(combo_source_INJECTION_USE_YN.Copy());
                this.cbo01_DTRIM_USE_YN.DataBind(combo_source_INJECTION_USE_YN.Copy());

                this.grd01_QA20023.AllowEditing = false;
                this.grd01_QA20023.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20023.Initialize();
                this.grd01_QA20023.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");                
                this.grd01_QA20023.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "부위코드", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA20023.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 500, "부위명", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA20023.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd01_QA20023.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "사용유무", "USE_YN", "USE_YN3");
                this.grd01_QA20023.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "사출불량 적용여부", "INJECTION_USE_YN", "INJECTION_USE_YN");
                this.grd01_QA20023.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 220, "조립공정 적용여부", "DTRIM_USE_YN", "DTRIM_USE_YN");

                this.grd01_QA20023.SetColumnType(AxFlexGrid.FCellType.Int, "SORT_SEQ");

                this.SetRequired(lbl02_DEFPOSCD, lbl02_DEFPOSNM);
                this.txt02_DEFPOSCD.SetValid(5, AxTextBox.TextType.UAlphabet);
                this.txt02_DEFPOSNM.SetValid(50, AxTextBox.TextType.Default);

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

                
                this.txt02_DEFPOSCD.ReadOnly = false;
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
                
                string DEFPOSCD_DEFPOSNM = this.txt01_DEFPOSCD_DEFPOSNM.GetValue().ToString();
                string USE_YN = this.cbo01_USE_YN.GetValue().ToString();
                string INJECTION_USE_YN = this.cbo01_INJECTION_USE_YN.GetValue().ToString();
                string DTRIM_USE_YN = this.cbo01_DTRIM_USE_YN.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);                
                paramSet.Add("DEFPOSCD_DEFPOSNM", DEFPOSCD_DEFPOSNM);
                paramSet.Add("USE_YN", USE_YN);
                paramSet.Add("INJECTION_USE_YN", INJECTION_USE_YN);
                paramSet.Add("DTRIM_USE_YN", DTRIM_USE_YN);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20023.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "DEFPOSCD", "DEFPOSNM", "SORT_SEQ", "USE_YN", "INJECTION_USE_YN", "DTRIM_USE_YN", "LANG_SET");
                source.Tables[0].Rows.Add(
                    _CORCD,                    
                    this.txt02_DEFPOSCD.GetValue(),
                    this.txt02_DEFPOSNM.GetValue(),
                    this.nme02_SORT_SEQ.GetDBValue(),
                    this.chk02_USEYN2.GetValue(),
                    this.chk02_INJECTION_USE_YN.GetValue(),
                    this.chk02_DTRIM_USE_YN.GetValue(),
                    this.UserInfo.Language
                );

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("불량부위코드가 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "DEFPOSCD");
                source.Tables[0].Rows.Add(
                    _CORCD,                    
                    this.txt02_DEFPOSCD.GetValue()
                );

                if (!IsDeleteValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);
                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("불량부위코드가 삭제 되었습니다.");
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

        private void grd01_QA20023_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int Row = this.grd01_QA20023.SelectedRowIndex;
                if (Row >= this.grd01_QA20023.Rows.Fixed)
                {
                    
                    string DEFPOSCD = this.grd01_QA20023.GetValue(Row, "DEFPOSCD").ToString();
                    string DEFPOSNM = this.grd01_QA20023.GetValue(Row, "DEFPOSNM").ToString();
                    string SORT_SEQ = this.grd01_QA20023.GetValue(Row, "SORT_SEQ").ToString();
                    string USE_YN = this.grd01_QA20023.GetValue(Row, "USE_YN").ToString();
                    string INJECTION_USE_YN = this.grd01_QA20023.GetValue(Row, "INJECTION_USE_YN").ToString();
                    string DTRIM_USE_YN = this.grd01_QA20023.GetValue(Row, "DTRIM_USE_YN").ToString();

                    
                    this.txt02_DEFPOSCD.SetValue(DEFPOSCD);
                    this.txt02_DEFPOSNM.SetValue(DEFPOSNM);
                    this.nme02_SORT_SEQ.SetValue(SORT_SEQ);
                    this.chk02_USEYN2.SetValue(USE_YN);
                    this.chk02_INJECTION_USE_YN.SetValue(INJECTION_USE_YN);
                    this.chk02_DTRIM_USE_YN.SetValue(DTRIM_USE_YN);

                    
                    this.txt02_DEFPOSCD.ReadOnly = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string CORCD = _CORCD;
                
                string DEFPOSCD = this.txt02_DEFPOSCD.GetValue().ToString();
                string DEFPOSNM = this.txt02_DEFPOSNM.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }


                if (this.GetByteCount(DEFPOSCD) == 0 || this.GetByteCount(DEFPOSCD) > 5)
                {
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("DEFPOSCD"), "1~5Byte");
                    //MsgBox.Show("불량부위코드 입력이 잘못되었습니다.(범위 : 1~5Byte)");
                    return false;
                }

                if (this.GetByteCount(DEFPOSNM) == 0 || this.GetByteCount(DEFPOSNM) > 20)
                {
                    //MsgBox.Show("불량부위명 입력이 잘못되었습니다.(범위 : 1~20Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("DEFPOSNM"), "1~20Byte");
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

        private bool IsDeleteValid()
        {
            try
            {
                string CORCD = _CORCD;
                
                string DEFPOSCD = this.txt02_DEFPOSCD.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }


                if (this.GetByteCount(DEFPOSCD) == 0 || this.GetByteCount(DEFPOSCD) > 5)
                {
                    //MsgBox.Show("불량부위코드 입력이 잘못되었습니다.(범위 : 1~5Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("DEFPOSCD"), "1~5Byte");
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

    }
}
