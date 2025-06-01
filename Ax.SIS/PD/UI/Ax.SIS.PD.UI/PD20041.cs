#region ▶ Description & History
/* 
* 프로그램명 : PD20041 사출금형관리
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관(구.PM20041)
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
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// <b>금형번호</b>
    /// </summary>
    public partial class PD20041 : AxCommonBaseControl
    {
        //private IPD20041 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20041";

        private string _CORCD = "";
        private string _BIZCD = "";

        public PD20041()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20041>("PM00", "PD20041.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "금형명", "MOLDNM", "MOLDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "삭제여부", "DELETE_YN", "DEL_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  80, "MC/POS", "MCPOS", "MC_POS");// Add 2019-06-25
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "UPH", "UPH", "UPH");
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("REP_LINECD");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.cdx01_REP_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_REP_LINECD.CodeParameterName = "LINECD";
                this.cdx01_REP_LINECD.NameParameterName = "LINENM";
                this.cdx01_REP_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_REP_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_REP_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_REP_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
                this.cdx01_REP_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_REP_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv);
                this.cdx01_REP_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.txt02_MOLDNO.SetReadOnly(true); 

                this.SetRequired(this.lbl02_MOLDNO);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "MOLDNO", "MOLDNM","REP_LINECD","LANG_SET","USERID", "MCPOS","UPH");

                if (_CORCD.Length == 0 || _BIZCD.Length == 0)
                {
                    _CORCD = this.UserInfo.CorporationCode;
                    _BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                }

                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.txt02_MOLDNO.GetValue(),
                    this.txt02_MOLDNM.GetValue(),
                    this.cdx01_REP_LINECD.GetValue(),
                    this.UserInfo.Language,
                    this.UserInfo.UserID,
                    this.txt01_MCPOS.GetValue(),
                    this.axTextBox1.GetValue()
                );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 금형번호 정보가 저장되었습니다");
                // 저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        //삭제기능 없어짐.
        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "MOLDNO");
        //        source.Tables[0].Rows.Add
        //        (
        //            _CORCD, 
        //            _BIZCD,
        //            this.txt02_MOLDNO.GetValue()
        //        );

        //        if (!this.IsDeleteValid(source)) return;

        //        this.BeforeInvokeServer(true);
        //        //_WSCOM.Remove(source);
        //        _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("선택하신 금형번호 정보가 삭제되었습니다");
        //        // 삭제되었습니다.
        //        MsgCodeBox.Show("CD00-0072");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                
                set.Add("CORCD",  this.UserInfo.CorporationCode);
                set.Add("BIZCD",  this.cbo01_BIZCD.GetValue());
                set.Add("MOLDNO", this.txt01_MOLDNO.GetValue());
                set.Add("MOLDNM", this.txt01_MOLDNM.GetValue());
                set.Add("DELETE_YN", this.chk01DELETE_YN.Checked ? "Y" : "N");
                this.BeforeInvokeServer(true);
                //DataSet dsInquery = _WSCOM.Inquery(set);
                DataSet dsInquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.grd01.SetValue(dsInquery);
                ShowDataCount(dsInquery);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
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
                _CORCD = "";
                _BIZCD = "";
                this.txt02_MOLDNO.Initialize();
                this.txt02_MOLDNM.Initialize();
                this.cdx01_REP_LINECD.Initialize();
                this.txt01_MCPOS.Initialize();
                this.axTextBox1.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;

                _CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                _BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();

                this.txt02_MOLDNO.SetValue(this.grd01.GetValue(row, "MOLDNO"));
                this.txt02_MOLDNM.SetValue(this.grd01.GetValue(row, "MOLDNM"));

                this.txt02_MOLDNO.SetReadOnly(true);

                this.cdx01_REP_LINECD.SetValue(this.grd01[row, "REP_LINECD"].ToString());
                this.txt01_MCPOS.SetValue(this.grd01.GetValue(row, "MCPOS"));
                this.axTextBox1.SetValue(this.grd01.GetValue(row, "UPH"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
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
                    //MsgBox.Show("저장할 금형번호 정보가 존재하지 않습니다.");
                    // 저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                DataRow row = source.Tables[0].Rows[0];

                string MOLDNO = row["MOLDNO"].ToString();
                string MOLDNM = row["MOLDNM"].ToString();
                string MCPOS = row["MCPOS"].ToString();

                if (MOLDNO.Length == 0)
                {
                    //MsgBox.Show("금형번호를 입력하지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("MOLDNO"));

                    return false;
                }

                if (this.GetByteCount(MOLDNO) > 20)
                {
                    //MsgBox.Show("금형번호는 10Byte 이상 입력할 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.GetLabel("MOLDNO"), "20");

                    return false;
                }

                if (this.GetByteCount(MOLDNM) > 50)
                {
                    //MsgBox.Show("금형명은 50Byte 이상 입력할 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.GetLabel("MOLDNM"), "50");
                    return false;
                }

                //if (MsgBox.Show("입력하신 금형번호 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                // 저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                if (this.GetByteCount(MCPOS) > 10)
                {
                    MsgCodeBox.ShowFormat("CD00-0116", this.GetLabel("MCPOS"), "10");
                    return false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        //삭제기능 제거
        //private bool IsDeleteValid(DataSet source)
        //{
        //    try
        //    {
        //        HEParameterSet set = new HEParameterSet();
        //        set.Add("CORCD", this.UserInfo.CorporationCode);
        //        set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
        //        set.Add("MOLDNO", this.txt01_MOLDNO.GetValue());

        //        //DataSet dsChecked = _WSCOM.Inquery_CHECKED(set);
        //        DataSet dsChecked = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CHECKED"), set, "OUT_CURSOR_PM2020", "OUT_CURSOR_PM2030");

        //        if (!this.txt02_MOLDNO.ReadOnly)
        //        {
        //            //MsgBox.Show("데이터 입력 대기 상태에서는 삭제 기능을 사용할 수 없습니다.");
        //            // 데이터 입력 대기 상태에서는 삭제 기능을 사용할 수 없습니다.
        //            MsgCodeBox.Show("PM00-0049");
        //            return false;
        //        }

        //        if (source.Tables[0].Rows.Count == 0)
        //        {
        //            //MsgBox.Show("삭제할 금형번호가 존재하지 않습니다.");
        //            // 삭제할 {0}가 존재하지 않습니다.
        //            MsgCodeBox.ShowFormat("PM00-0098", this.GetLabel(""));
        //            return false;
        //        }

        //        if (this.txt02_MOLDNO.ByteCount == 0)
        //        {
        //            //MsgBox.Show("삭제할 금형번호가 존재하지 않습니다.");
        //            // 삭제할 {0}가 존재하지 않습니다.
        //            MsgCodeBox.ShowFormat("PM00-0098", this.GetLabel(""));
        //            return false;
        //        }

        //        if (dsChecked.Tables[0].Rows.Count > 0)
        //        {
        //            //MsgBox.Show("금형별 제품정보에서 사용중인 데이터 입니다.");
        //            // {0}에서 사용중인 데이터 입니다.
        //            MsgCodeBox.ShowFormat("PM00-0099", this.GetLabel("PD20042"));
        //            return false;
        //        }

        //        if (dsChecked.Tables[1].Rows.Count > 0)
        //        {
        //            //MsgBox.Show("설비호기별 금형관리에서 사용중인 데이터 입니다.");
        //            // {0}에서 사용중인 데이터 입니다.
        //            MsgCodeBox.ShowFormat("PM00-0099", this.GetLabel("PD20043"));
        //            return false;
        //        }

        //        //if (MsgBox.Show("선택하신 금형번호 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        // 삭제하시겠습니까?
        //        if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //            return false;
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.Message);
        //        return false;
        //    }

        //    return true;
        //}

        #endregion
    }
}
