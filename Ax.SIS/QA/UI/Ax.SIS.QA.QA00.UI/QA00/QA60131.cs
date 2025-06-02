#region ▶ Description & History
/* 
 * 프로그램명 : QA60131 무검사시행전산화결정 배포
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-24      배명희      통합WCF로 변경
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
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>유무검사 수동판정</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-20 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-20 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA60131 : AxCommonBaseControl
    {
        //private IQA60131 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA60131";

        #region [ 초기화 작업 정의 ]

        public QA60131()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA60131>("QA00", "QA60131.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                //this._buttonsControl.BtnProcess.Visible = true;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");// "차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.grd01_QA60131.AllowEditing = false;
                this.grd01_QA60131.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grd01_QA60131.Initialize();
                this.grd01_QA60131.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA60131.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VINCD");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD", "ITEM");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "위치", "POSCD", "INSTALL_POS");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "검사명", "INSPECT_CLASSNM", "QA_INSPECT_BASENAME");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "불량건수", "DEF_NOCASE", "DEF_NOCASE");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "무검사", "INSPECT_N", "INSPECT_N");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "유검사", "INSPECT_Y", "INSPECT_Y");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "상시검사", "ALWAYS_YNNM", "ALWAYS_YNNM");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "전환시작일", "CONV_BEG_DATE", "CONV_BEG_DATE");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "전환종료일", "CONV_END_DATE", "CONV_END_DATE");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "선정시작일", "SELECT_BEG_DATE", "SELECT_BEG_DATE");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "선정종료일", "SELECT_END_DATE", "SELECT_END_DATE");
                this.grd01_QA60131.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "최종발생일", "CONV_DATE", "CONV_DATE");


                this.grd01_QA60131.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_NOCASE");
                this.grd01_QA60131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_BEG_DATE");
                this.grd01_QA60131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_END_DATE");
                this.grd01_QA60131.SetColumnType(AxFlexGrid.FCellType.Date, "SELECT_BEG_DATE");
                this.grd01_QA60131.SetColumnType(AxFlexGrid.FCellType.Date, "SELECT_END_DATE");
                this.grd01_QA60131.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_DATE");

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.SetRequired(lbl01_BIZNM, lbl01_STD_DATE, lbl01_CYCLE);

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
                    this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                    grd01_QA60131.InitializeDataSource();
                }

                this.nme01_CYCLE.SetValue("3");

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
                string CONV_DATE = this.dte01_CONV_DATE.GetDateText().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CONV_DATE", CONV_DATE);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
                this.grd01_QA60131.SetValue(source);


                this.AfterInvokeServer();
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

        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "VINCD", "CONV_DATE", "CYCLE", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo01_BIZCD.GetValue(),
                    this.cdx01_VINCD.GetValue(),
                    this.dte01_CONV_DATE.GetDateText(),
                    this.nme01_CYCLE.GetDBValue(),
                    this.cbo01_PLANT_DIV.GetValue()
                );

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Execute(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "EXECUTE"), source);
                
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("처리가 완료되었습니다.");                
                MsgCodeBox.Show("CD00-0105");
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

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string CONV_DATE = this.dte01_CONV_DATE.GetDateText().ToString();
                string CYCLE = this.nme01_CYCLE.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");                    
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(CONV_DATE) == 0)
                {
                    //MsgBox.Show("기준일자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_STD_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(CYCLE) == 0)
                {
                    //MsgBox.Show("적용개월이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_CYCLE.Text);
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

        #endregion
    }
}
