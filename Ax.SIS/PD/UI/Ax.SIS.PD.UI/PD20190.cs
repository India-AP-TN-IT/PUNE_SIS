#region ▶ Description & History
/* 
* 프로그램명 : PD20190 장기적재 기준일 관리
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
    /// 장기적재 기준일 관리
    /// </summary>
    public partial class PD20190 : AxCommonBaseControl
    {
        //private IPD20190 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20190";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        //private IPDCOMMON_ERM _WSCOM_ERM;

        #region [ 초기화 작업 정의 ]

        public PD20190()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20190>("PD", "PD20190.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 080, "차종코드", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "차종", "VINCD_NAME", "VEHICLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 150, "장기기준일", "LONG_STOCK_DAY", "LONG_STOCK_DAY");

                #region

                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                //통합WCF
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_CARTYPE(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CARTYPE"), set).Tables[0];

                #endregion

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "LONG_STOCK_DAY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "VINCD_NAME");

                this.cbo01_VINCD.DataBind(source);

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
                set.Add("TYPECD", this.cbo01_VINCD.GetValue());

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
                    "CORCD", "BIZCD", "VINCD", "LONG_STOCK_DAY", "EMPNO");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["CORCD"] = this.UserInfo.CorporationCode;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                    rows["EMPNO"] = this.UserInfo.EmpNo;
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

                //MsgBox.Show("입력하신 장기적재 기준일 정보가 저장되었습니다.");
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
                    "CORCD", "BIZCD", "VINCD");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["CORCD"] = this.UserInfo.CorporationCode;
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

                //MsgBox.Show("선택하신 장기적재 기준일 정보가 삭제되었습니다");
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

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            this.GridCell_Changed(e);
        }

        private void grd01_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            this.GridCell_Changed(e);
        }

        #endregion

        #region [사용자 정의 메서드]

        ////2014.02.10 - MES0040 장기재고기준일자 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES0040", bizcd).Tables[0].Rows[0][0].ToString();
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

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                if (e.Row >= this.grd01.Rows.Fixed)
                {
                    if (e.Col == this.grd01.Cols["VINCD_NAME"].Index)
                    {
                        string VINCD_NAME = this.grd01.GetValue(e.Row, "VINCD_NAME").ToString();
                        this.grd01.SetValue(e.Row, "VINCD", VINCD_NAME);
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
                    //MsgBox.Show("저장할 장기적재 기준일 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string VINCD = this.grd01.GetValue(i, "VINCD").ToString();
                    string LONG_STOCK_DAY = this.grd01.GetValue(i, "LONG_STOCK_DAY").ToString();

                    if (this.GetByteCount(VINCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {차종}이 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[2].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(LONG_STOCK_DAY) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {장기기준일}이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008",  i.ToString(), this.grd01.Cols[3].Caption.ToString());
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 장기적재 기준일 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //MsgBox.Show("삭제할 장기적재 기준일 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                //if (MsgBox.Show("선택하신 장기적재 기준일 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
    }
}
