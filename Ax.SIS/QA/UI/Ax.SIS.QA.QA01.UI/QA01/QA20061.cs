#region ▶ Description & History
/* 
 * 프로그램명 : QA20061 보관위치관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-06-15      배명희      보관위치관리 신규 개발
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
using System.IO;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{

    public partial class QA20061 : AxCommonBaseControl
    {

        #region [ 변수 선언 및 생성자 ]
        
        
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20061";

        public QA20061()
        {
            InitializeComponent();        
            _WSCOM_N = new AxClientProxy();
        }

        #endregion


        #region [ UI 초기설정 ] 
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {                
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.grd01_QA20061.AllowEditing = false;
                this.grd01_QA20061.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20061.Initialize();
                this.grd01_QA20061.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "보관위치", "BODY_LOCATION", "BODY_LOCATION");
                this.grd01_QA20061.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 400, "보관위치명", "BODY_LOCATION_NM", "BODY_LOCATION_NM");
                this.grd01_QA20061.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "사용여부", "USE_YN", "USEYN");

                this.txt01_BODY_LOCATION.SetValid(10, AxTextBox.TextType.UAlphabet);
                this.txt02_BODY_LOCATION.SetValid(10, AxTextBox.TextType.UAlphabet);
                this.txt02_BODY_LOCATION_NM.SetValid(50, AxTextBox.TextType.Default);

                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.SetRequired(lbl02_BODY_LOCATION, lbl02_BODY_LOCATION_NM);

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
                this.Reset();
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
                this.BeforeInvokeServer(true);
                this.Query();
                this.AfterInvokeServer();

                this.Reset();

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
                DataSet source = AxFlexGrid.GetDataSourceSchema("BODY_LOCATION", "BODY_LOCATION_NM", "USE_YN", "USERID");

                

                source.Tables[0].Rows.Add(
                    this.txt02_BODY_LOCATION.GetValue(),
                    this.txt02_BODY_LOCATION_NM.GetValue(),
                    this.cbo02_USE_YN.GetValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.Query();

                //MsgBox.Show("정상적으로 저장되었습니다.
                MsgCodeBox.Show("CD00-0009");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("BODY_LOCATION");
                source.Tables[0].Rows.Add(                    
                    this.txt02_BODY_LOCATION.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.Query();
                this.Reset();

                //MsgBox.Show("정상적으로 삭제 되었습니다.");
                MsgCodeBox.Show("CD00-0010");
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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]
        
        private void grd01_QA20061_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20061.SelectedRowIndex;

                if (Row >= this.grd01_QA20061.Rows.Fixed)
                {
                    //하단 입력 컨트롤 영역 초기화
                    this.Reset();

                    string BODY_LOCATION = this.grd01_QA20061.GetValue(Row, "BODY_LOCATION").ToString();
                    string BODY_LOCATION_NM = this.grd01_QA20061.GetValue(Row, "BODY_LOCATION_NM").ToString();
                    string USE_YN = this.grd01_QA20061.GetValue(Row, "USE_YN").ToString();

                    this.txt02_BODY_LOCATION.SetValue(BODY_LOCATION);
                    this.txt02_BODY_LOCATION_NM.SetValue(BODY_LOCATION_NM);
                    this.cbo02_USE_YN.SetValue(USE_YN);

                    this.txt02_BODY_LOCATION.ReadOnly = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void Query()
        {
            try
            {
                string BODY_LOCATION = this.txt01_BODY_LOCATION.GetValue().ToString();
                string BODY_LOCATION_NM = this.txt01_BODY_LOCATION_NM.GetValue().ToString();
                string USE_YN = this.cbo01_USE_YN.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("BODY_LOCATION", BODY_LOCATION);
                paramSet.Add("BODY_LOCATION_NM", BODY_LOCATION_NM);
                paramSet.Add("USE_YN", USE_YN);
                paramSet.Add("LANG_SET", this.UserInfo.Language);


                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);


                this.grd01_QA20061.SetValue(source);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Reset()
        {
            try
            {
                foreach (Control ctl in grp01_QA20061_MSG2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.txt02_BODY_LOCATION.ReadOnly = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region [유효성 검사]

        private bool IsRemovable()
        {
            bool ret = false;
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("BODY_LOCATION", this.txt02_BODY_LOCATION.GetValue());


                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SUB"), paramSet);

                if (source.Tables[0].Rows.Count > 0 && Convert.ToInt32(source.Tables[0].Rows[0]["CNT"]) <= 0)
                {
                    ret = true;

                }
                else
                {
                    ret = false;
                    MsgCodeBox.Show("QA01-0056"); //사용중인 보관위치코드이므로 삭제할 수 없습니다.
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return ret;

        }


        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string BODY_LOCATION = this.txt02_BODY_LOCATION.GetValue().ToString();
                string BODY_LOCATION_NM = this.txt02_BODY_LOCATION_NM.GetValue().ToString();
                string USE_YN = this.cbo02_USE_YN.GetValue().ToString();

                if (this.GetByteCount(BODY_LOCATION) == 0 || this.GetByteCount(BODY_LOCATION) > 10)
                {
                    //MsgBox.Show("보관위치코드 입력이 잘못되었습니다.(범위 : 1~4Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_BODY_LOCATION.Text, "1~10Byte");
                    return false;
                }

                if (this.GetByteCount(BODY_LOCATION_NM) == 0 || this.GetByteCount(BODY_LOCATION_NM) > 50)
                {
                    //MsgBox.Show("보관위치명 입력이 잘못되었습니다.(범위 : 1~50Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_BODY_LOCATION_NM.Text, "1~50Byte");
                    return false;
                }

                if (this.GetByteCount(USE_YN) == 0)
                {
                    //MsgBox.Show("{0} 가(이) 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_USEYN.Text);
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
               
                string BODY_LOCATION = this.txt02_BODY_LOCATION.GetValue().ToString();


                if (this.GetByteCount(BODY_LOCATION) == 0 || this.GetByteCount(BODY_LOCATION) > 10)
                {
                    //MsgBox.Show("보관위치코드 입력이 잘못되었습니다.(범위 : 1~10Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_BODY_LOCATION.Text, "1~10Byte");
                    return false;
                }

                if (this.IsRemovable() == false)
                {
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
