#region ▶ Description & History
/* 
 * 프로그램명 : QA20046 임율관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-08-11      배명희      신규개발
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

    public partial class QA20046 : AxCommonBaseControl
    {
        //private IQA20046 _WSCOM;
     
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20046";
        
        #region [ 초기화 작업 정의 ]

        public QA20046()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20046>("QA00", "QA20046.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
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
                this.cbo01_BIZCD.SelectedValueChanged += new EventHandler(cbo01_BIZCD_SelectedValueChanged);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "년도", "YYYY", "YYYY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "업종코드", "JOB_CODE", "JOB_CODE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "임율비용", "PAY_AMT", "PAY_AMNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 160, "간접경비율", "EXP_RATE", "EXP_RATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 200, "일반관리비율", "GEN_RATE", "GEN_RATE");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PAY_AMT");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "EXP_RATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "GEN_RATE");

                this.grd01.Cols["PAY_AMT"].Format = "###,###,###,###,###,##0";
                this.grd01.Cols["EXP_RATE"].Format = "###,##0.00";
                this.grd01.Cols["GEN_RATE"].Format = "###,##0.00";

                this.SetRequired(lbl02_YYYY, lbl01_BIZNM2, lbl02_BIZNM2);

                this.txt02_YYYY.SetValid(AxTextBox.TextType.OnlyNumber);
                this.txt02_YYYY.MaxLength = 4;

                this.txt02_JOB_CODE.SetReadOnly(true);
                this.txt02_JOB_CODE.SetValue("T");

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
                if (this.cbo01_BIZCD.GetValue() != null)
                    this.cbo02_BIZCD.SetValue(this.cbo01_BIZCD.GetValue());
                else
                    this.cbo02_BIZCD.Initialize();

                this.txt02_YYYY.Initialize();
                this.nme02_PAY_AMT.Initialize();
                this.nme02_EXP_RATE.Initialize();
                this.nme02_GEN_RATE.Initialize();

                this.cbo02_BIZCD.SetReadOnly(false);
                this.txt02_YYYY.SetReadOnly(false);
                
                this.txt02_JOB_CODE.SetValue("T");                

                                
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
                
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", BIZCD);
                
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "YYYY", "JOB_CODE", "PAY_AMT", "EXP_RATE", "GEN_RATE");
                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_YYYY.GetValue(),
                    this.txt02_JOB_CODE.GetValue(),
                    this.nme02_PAY_AMT.GetDBValue(),
                    this.nme02_EXP_RATE.GetDBValue(),
                    this.nme02_GEN_RATE.GetDBValue()
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "YYYY");
                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_YYYY.GetValue()                    
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("삭제 되었습니다.");
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

        #region [기타 컨트롤에 대한 이벤트 정의]


        void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            //조회조건 사업장 변경시 재조회 및 입력 컨트롤 초기화
            this.BtnQuery_Click(null, null);
            this.BtnReset_Click(null, null);
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01.SelectedRowIndex;

                if (Row >= this.grd01.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01.GetValue(Row, "BIZCD").ToString();
                    string YYYY = this.grd01.GetValue(Row, "YYYY").ToString();
                    string JOB_CODE = this.grd01.GetValue(Row, "JOB_CODE").ToString();
                    string PAY_AMT = this.grd01.GetValue(Row, "PAY_AMT").ToString();
                    string EXP_RATE = this.grd01.GetValue(Row, "EXP_RATE").ToString();
                    string GEN_RATE = this.grd01.GetValue(Row, "GEN_RATE").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.txt02_YYYY.SetValue(YYYY);
                    this.txt02_JOB_CODE.SetValue(JOB_CODE);

                    this.nme02_PAY_AMT.SetValue(PAY_AMT);
                    this.nme02_EXP_RATE.SetValue(EXP_RATE);
                    this.nme02_GEN_RATE.SetValue(GEN_RATE);

                    this.cbo02_BIZCD.SetReadOnly(true);
                    this.txt02_YYYY.SetReadOnly(true);

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
            
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string YYYY = this.txt02_YYYY.GetValue().ToString();
            
            
            if (this.GetByteCount(BIZCD) == 0)
            {
                //MsgBox.Show("사업장이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM2.Text);
                return false;
            }

            if (this.GetByteCount(YYYY) == 0)
            {
                //MsgBox.Show("년도 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_YYYY.Text);
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
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string YYYY = this.txt02_YYYY.GetValue().ToString();
            

            if (this.GetByteCount(BIZCD) == 0)
            {
                //MsgBox.Show("사업장이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM2.Text);
                return false;
            }

            if (this.GetByteCount(YYYY) == 0)
            {
                //MsgBox.Show("년도 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_YYYY.Text);
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
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("고객사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl01_BIZNM2.Text);
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
