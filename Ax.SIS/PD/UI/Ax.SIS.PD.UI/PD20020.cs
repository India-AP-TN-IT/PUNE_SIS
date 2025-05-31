#region ▶ Description & History
/* 
* 프로그램명 : PD20020 계측항목관리 - 사출SPC
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 계측 유형 관리 - 사출 SPC
    /// </summary>
    public partial class PD20020 : AxCommonBaseControl
    {
        //private IPD20020 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20020";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        //private IPDCOMMON_MES _WSCOM_MES;
        //private IPDCOMMON_ERM _WSCOM_ERM;

        #region [ 초기화 작업 정의 ]

        public PD20020()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD20020>("PD", "PD20020.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD");
                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 100, "계측 유형 코드", "INSPEC_DIV", "INSPEC_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "계측 유형 명칭", "INSPEC_DIVNM", "INSPEC_DIVNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "계측 항목 코드", "INSPEC_ITEMCD", "INSPEC_ITEMCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "계측 항목 명칭", "INSPEC_ITEMNM", "INSPEC_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "측정단위", "INSPEC_UNIT", "INSPEC_UNIT");

                #region

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);

                //통합WCF
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECDIV"), set).Tables[0];
                //DataTable source1 = _WSCOM_MES.INQUERY_COMBO_INSPECDIV(this.UserInfo.BusinessCode, set).Tables[0];
                

                #endregion

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source1, "INSPEC_DIVNM");

                this.cbo01_INSPEC_DIV.DataBind(source1);

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("INSPEC_DIV", this.cbo01_INSPEC_DIV.GetValue());
                set.Add("INSPEC_ITEMCD", this.txt01_INSPEC_ITEMCD.GetValue());
                set.Add("INSPEC_ITEMNM", this.txt01_INSPEC_ITEMNM.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "INSPEC_DIV", "INSPEC_ITEMCD", "INSPEC_ITEMNM", "INSPEC_UNIT", "EMPNO", "BIZCD");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝



                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 계측항목관리 정보가 저장되었습니다.");
                //저장되었습니다.
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

        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "INSPEC_DIV", "INSPEC_ITEMCD", "BIZCD");
                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 계측항목관리 정보가 삭제되었습니다");
                //삭제되었습니다.
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

        #region [ 기타 컨트롤 이벤트 ]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드]

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                if (e.Row >= this.grd01.Rows.Fixed)
                {
                    if (e.Col == this.grd01.Cols["INSPEC_DIVNM"].Index)
                    {
                        string INSPEC_DIVNM = this.grd01.GetValue(e.Row, "INSPEC_DIVNM").ToString();
                        this.grd01.SetValue(e.Row, "INSPEC_DIV", INSPEC_DIVNM);
                    }
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
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 계측항목 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string GROUP_CODE = this.grd01.GetValue(i, "INSPEC_DIV").ToString();
                    string INSPEC_ITEMCD = this.grd01.GetValue(i, "INSPEC_ITEMCD").ToString();
                    string INSPEC_ITEMNM = this.grd01.GetValue(i, "INSPEC_ITEMNM").ToString();

                    if (this.GetByteCount(GROUP_CODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측유형명칭}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols[3].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(GROUP_CODE) > 4)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측유형명칭}은 4byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols[3].Caption.ToString(), "4");
                        return false;
                    }

                    if (this.GetByteCount(INSPEC_ITEMCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측항목코드}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols[4].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(INSPEC_ITEMCD) > 10)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측항목코드}는 {10}byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols[4].Caption.ToString(), "10");
                        return false;
                    }

                    if (this.GetByteCount(INSPEC_ITEMNM) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측항목 명칭}이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols[5].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(INSPEC_ITEMNM) > 50)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측항목 명칭}은 {50}byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols[5].Caption.ToString(), "50");
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 계측항목 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 계측항목 정보가 존재하지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 계측항목 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //삭제하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        #region [미들서버에 코드정보 전송]
        ////2014.02.10 - MES0320 계측 항목 상세 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
                
        //        msg = _WSCOM_ERM.SyncMESIF("MES0320", bizcd).Tables[0].Rows[0][0].ToString();
        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0004");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0005");
        //                return false;
        //            }
        //            else
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show(msg);
        //                return false;
        //            }
        //        }

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    return true;
        //}
        #endregion
    }
}
