#region ▶ Description & History
/* 
 * 프로그램명 : PD25240 일일비가동 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
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
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>일일비가동 현황</b>    
    /// </summary>
    public partial class PD25240 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD25240";

        public PD25240()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPMCommon>("PM", "PMCommon.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if(this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "사업장번호", "BIZCD");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "비가동번호", "NON_OPRNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "발생일자", "OCCUR_DATE", "OCCUR_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "라인명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "비가동코드", "NON_OPRCD","NON_OPRCD");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "발생시간", "OCCUR_TIME","OCCUR_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "정지분", "OCCUR_MM", "OCCUR_MM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "인원", "PERSON", "PERSON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "정지시간합", "STOP_TIME_SUM","STOP_TIME_SUM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "내용", "DET_DESC", "CNTT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "손실공수", "STOP_MH_SUM", "LOSS_MH_SUM");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "노무비", "WORK_PAY", "ZZHR01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "생산금액", "PRDT_AMT", "PROD_AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "계", "TOT_AMT", "SUM_AMT");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "귀책부서", "REP_DEPTNM", "IMPUT_DEPT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "비고", "REMARK", "REMARK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "귀책부서코드", "REP_DEPT");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("NON_OPRNO");
                this.grd01.AddHiddenColumn("REP_DEPT");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_PAY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PRDT_AMT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_AMT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");

                this.cdx01_REP_DEPT.HEPopupHelper = new PD25240P1();
                this.cdx01_REP_DEPT.PopupTitle = this.GetLabel("DEPARTCD");// "부서코드";
                this.cdx01_REP_DEPT.CodeParameterName = "LINECD";
                this.cdx01_REP_DEPT.NameParameterName = "LINENM";
                this.cdx01_REP_DEPT.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_REP_DEPT.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_REP_DEPT.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);                
                this.cdx01_REP_DEPT.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetDateText());
                this.cdx01_REP_DEPT.SetCodePixedLength();
                //this.cdx01_REP_DEPT.NameTextBoxReadOnly = true;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("APG_PD25240.GET_NON_OPRCD"), set);
                this.cbo01_NON_OPRCD.DataBind(source.Tables[0]);

                this.SetRequired(this.lbl02_NON_OPRNO);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("NON_OPRNO", this.txt02_NON_OPRNO.GetValue());
                paramSet.Add("LINECD", this.cdx01_REP_DEPT.GetValue());
                paramSet.Add("REMARK", this.txt01_REMARK.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                if (!IsSaveValid(paramSet)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx("APG_PD25240.SAVE", paramSet);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 자료가 정상적으로 저장되었습니다");
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다.
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
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("NON_OPRNO", this.txt02_NON_OPRNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                if (!IsDeleteValid(paramSet)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteDataSet("APG_PD25240.REMOVE", paramSet);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 비가동코드가 정상적으로 삭제되었습니다");
                MsgCodeBox.Show("CD00-0010");//정상적으로 삭제되었습니다.
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("OCCUR_DATE", this.dtp01_BEG_DATE.GetDateText());
                paramSet.Add("OPT", this.chk01_WHOLE_MONTH.GetValue());
                paramSet.Add("NON_OPRCD", this.cbo01_NON_OPRCD.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //HE.Framework.ServiceModel.AxClientProxy proxy = new Framework.ServiceModel.AxClientProxy();

                DataSet source = _WSCOM.ExecuteDataSet("APG_PD25240.INQUERY", paramSet);
                //DataSet source = proxy.ExecuteDataSet("PKG_PD25240.INQUERY", paramSet);
                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);
                this.AfterInvokeServer();
                this.BtnReset_Click(null, null);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt02_NON_OPRNO.Initialize();
                this.txt01_REMARK.Initialize();
                this.cdx01_REP_DEPT.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                if (row < 1)
                {
                    //MsgBox.Show("조회된 데이터가 없습니다.");
                    MsgCodeBox.Show("CD00-0039"); //조회된 데이터가 없습니다.
                    return;
                }

                this.txt02_NON_OPRNO.SetValue(this.grd01.GetValue(row, "NON_OPRNO"));
                if (!(this.grd01.SelectedDataRow["REP_DEPT"].ToString() == string.Empty))
                {
                    this.cdx01_REP_DEPT.SetValue(this.grd01.GetValue(row, "REP_DEPT").ToString());
                }
                else
                {
                    this.cdx01_REP_DEPT.Initialize();
                }

                this.txt01_REMARK.SetValue(this.grd01.GetValue(row, "REMARK"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(HEParameterSet set)
        {
            try
            {                

                string strNON_OPRNO = set["NON_OPRNO"].ToString();
                string strREP_DEPT = set["LINECD"].ToString();

                if (this.GetByteCount(strNON_OPRNO) == 0)
                {
                    //MsgBox.Show("저장할 대상이 없습니다.");
                    MsgCodeBox.Show("COM-00020");// 저장할 대상 Data가 없습니다.@@@
                    return false;
                }

                if (this.GetByteCount(strNON_OPRNO) == 0 )
                {
                    //MsgBox.Show("부서코드를 등록하세요."); //{0}이 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0082", this.lbl02_NON_OPRNO.Text);
                    return false;
                }

                if (this.GetByteCount(strREP_DEPT) > 100)
                {
                    //MsgBox.Show("비가동명 100Byte를 넘을 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0081", this.lbl01_IMPUT_DEPT.Text, "100Byte"); //{0}는 {1}를 넘을 수 없습니다. @@@
                    return false;
                }

                //if (MsgBox.Show("입력하신 비가동코드를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("COM-00909", MessageBoxButtons.OKCancel) != DialogResult.OK) //저장하시겠습니까? @@@
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(HEParameterSet set)
        {
            try
            {
                if (this.GetByteCount(set["NON_OPRNO"].ToString()) == 0 )
                if (this.txt02_NON_OPRNO.ReadOnly == false)
                {
                    //MsgBox.Show("삭제할 대상이 없습니다.");
                    MsgCodeBox.Show("COM-00023"); //삭제할 대상 Data가 없습니다.
                    return false;
                }
                
                //if (MsgBox.Show("선택하신 비가동코드를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion



    }
}
