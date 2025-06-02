#region ▶ Description & History
/* 
* 프로그램명 : PD201A0 완제품 팔레트 관리
* 설     명 : 
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
    /// 통전 검사 항목 그룹
    /// </summary>
    public partial class PD201A0 : AxCommonBaseControl
    {
        //private IPD201A0 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD201A0";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxComboList grd_LINECD;

        #region [ 초기화 작업 정의 ]

        public PD201A0()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD201A0>("PD", "PD201A0.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");

            this.grd_LINECD = new AxComboList();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable CORCD = this.GetCorCD().Tables[0];
                DataTable BIZCD = this.GetBizCD(this.UserInfo.CorporationCode).Tables[0];

                this.grd_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_LINECD_BeforeOpen);
               
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "팔레트 ID", "LODTBL_NO", "LODTBL_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "적재수량", "LOAD_QTY", "LOAD_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "시작일자", "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "종료일자", "END_DATE", "END_DATE");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "팔레트명칭", "LODTBL_NM", "LODTBL_NM");  //팔레트명칭

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, CORCD, "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, BIZCD, "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LOAD_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.grd01.Cols["LINECD"].Editor = this.grd_LINECD;
                this.grd01.Cols["CORCD"].AllowMerging = true;
                this.grd01.Cols["BIZCD"].AllowMerging = true;

                this.cbo01_CORCD.DataBind(CORCD);
                this.cbo01_BIZCD.DataBind(BIZCD);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetReadOnly(true);

                this.chk01_GRID_MERGE_CheckedChanged(null, null);
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                if (bizcd == "") return;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                //this.ShowMessage(source.Tables[0].Rows.Count.ToString() + "건 조회 되었습니다.");
                //{0} 개의 데이터가 조회 되었습니다.
                //MsgCodeBox.ShowFormat("CD00-0078", source.Tables[0].Rows.Count.ToString());

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
                    "CORCD", "BIZCD", "LODTBL_NO", "LOAD_QTY", "LINECD", "BEG_DATE", "END_DATE", "LODTBL_NM", "EMPNO");
                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.cbo01_BIZCD.GetValue().ToString(), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.cbo01_BIZCD.GetValue().ToString());
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝
                
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 완제품 팔레트 정보가 저장되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "LODTBL_NO");

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.cbo01_BIZCD.GetValue().ToString(), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK =  this.DN_MESCODE(this.cbo01_BIZCD.GetValue().ToString());
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 완제품 팔레트 정보가 삭제되었습니다");
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
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "BIZCD", this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(i, "BEG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                    this.grd01.SetValue(i, "END_DATE", "9998-12-31");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                //통합WCF 변경
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];

                this.grd_LINECD.DataBind(source, "LINECD", "LINECD", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.chk01_GRID_MERGE.Checked)
                    this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                else
                    this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 완제품 팔레트 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string LODTBL_NO = this.grd01.GetValue(i, "LODTBL_NO").ToString();

                    if (this.GetByteCount(LODTBL_NO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {팔레트 ID} 가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["LODTBL_NO"].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(LODTBL_NO) > 12)
                    {
                        //MsgBox.Show(i + " 번째 행에 팔레트 ID는 12byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols["LODTBL_NO"].Caption.ToString(), "12");
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 완제품 팔레트 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //MsgBox.Show("삭제할 완제품 팔레트 정보가 존재하지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 완제품 팔레트 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        //#region [미들서버에 코드정보 전송]
        ////2014.02.10 - MES0200 완제품 적재대(아산) MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES0200", bizcd).Tables[0].Rows[0][0].ToString();

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
        //#endregion

        
    }
}
