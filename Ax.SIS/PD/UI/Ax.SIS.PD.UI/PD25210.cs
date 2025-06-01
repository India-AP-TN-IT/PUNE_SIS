#region ▶ Description & History
/* 
 * 프로그램명 : 
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 2014-10-08 
 * 최종수정자 : 진승모
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014-10-08    진승모     다국어 적용   
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
using HE.Framework.ServiceModel;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>비가동 코드 등록</b>
    /// - 작 성 자 : 김선환<br />
    /// - 작 성 일 : 2010-07-14 오전 10:43:28<br />
    /// </summary>
    public partial class PD25210 : AxCommonBaseControl
    {
        //private IPD25210 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD25210";

        public PD25210()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD25210>("PM05", "PD25210.svc", "CustomBinding");
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

                this.cbo01_BIZCD.SelectedIndexChanged += new EventHandler(cbo01_BIZCD_SelectedIndexChanged);
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "비가동코드", "NON_OPRCD", "NON_OPRCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "비가동명", "NON_OPRNM", "NON_OPRNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "비가동그룹코드", "NON_GROUPCD", "NON_GROUPCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "상태코드", "STACD", "STATUSCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "삭제여부", "DELETE_YN", "DEL_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "FG_LINE", "FG_LINE", "FG_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "SFG_LINE", "SFG_LINE", "SFG_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "INJ_LINE", "INJ_LINE", "INJ_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "PAINT_LINE", "PAINT_LINE", "PAINT_LINE");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetCorCD().Tables[0], "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CC", "STACD");

                this.cbo01_STACD.DataBind("CC");
                this.cbo02_STACD.DataBind("CC");
                this.txt02_NON_GROUPCD.SetReadOnly(true);
                this.txt02_NON_OPRCD.SetReadOnly(true);

                this.SetRequired(this.lbl02_NON_OPRCD);

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
                
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "NON_OPRCD", "NON_OPRNM", "STACD", "FG_LINE", "SFG_LINE", "INJ_LINE", "PAINT_LINE");

                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbo01_BIZCD.GetValue(),
                    this.txt02_NON_OPRCD.GetValue(),
                    this.txt02_NON_OPRNM.GetValue(),
                    this.cbo02_STACD.GetValue(),
                    this.chk01_OPTION1_PD25210.Checked == true ? "Y" : "",
                    this.chk01_OPTION2_PD25210.Checked == true ? "Y" : "",
                    this.chk01_OPTION3_PD25210.Checked == true ? "Y" : "",
                    this.chk01_OPTION4_PD25210.Checked == true ? "Y" : ""
                    );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 비가동코드가 정상적으로 저장되었습니다");
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

        //삭제기능 없어짐
        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //삭제 임시 막음. 
        //        MsgCodeBox.Show("CD00-0026"); //--삭제 권한이 없습니다.
        //        return;

        //        DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "NON_OPRCD");

        //        source.Tables[0].Rows.Add(
        //            this.UserInfo.CorporationCode,
        //            this.cbo01_BIZCD.GetValue(),
        //            this.txt02_NON_OPRCD.GetValue());

        //        if (!IsDeleteValid(source)) return;

        //        this.BeforeInvokeServer(true);
        //        //_WSCOM.Remove(source);
        //        _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
        //        this.AfterInvokeServer();

        //        this.BtnReset_Click(null, null);
        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("선택하신 비가동코드가 정상적으로 삭제되었습니다");
        //        MsgCodeBox.Show("CD00-0072");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
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
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("NON_OPRCD", this.txt01_NON_OPRCD.GetValue().ToString());
                paramSet.Add("NON_GROUPCD", string.Empty);
                paramSet.Add("STACD", this.cbo01_STACD.GetValue().ToString());
                paramSet.Add("DELETE_YN", this.chk01DELETE_YN.Checked? "Y" : "N");
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
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
                this.txt02_NON_OPRCD.Initialize();
                this.txt02_NON_OPRNM.Initialize();
                this.cbo02_STACD.Initialize();                
                this.txt02_NON_GROUPCD.Initialize();

                this.chk01_OPTION1_PD25210.Checked = false;

                this.chk01_OPTION2_PD25210.Checked = false;

                this.chk01_OPTION3_PD25210.Checked = false;

                this.chk01_OPTION4_PD25210.Checked = false;
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
                    MsgCodeBox.Show("CD00-0039");
                    return;
                }

                this.txt02_NON_OPRCD.SetValue(this.grd01.GetValue(row, "NON_OPRCD"));
                this.txt02_NON_OPRNM.SetValue(this.grd01.GetValue(row, "NON_OPRNM"));
                this.cbo02_STACD.SetValue(this.grd01.GetValue(row, "STACD"));
                this.txt02_NON_GROUPCD.SetValue(this.grd01.GetValue(row, "NON_GROUPCD"));
                if(this.grd01.GetValue(row,"FG_LINE").ToString() == "Y")
                {
                    this.chk01_OPTION1_PD25210.Checked = true;
                }
                else{
                    this.chk01_OPTION1_PD25210.Checked = false;
                }
                if (this.grd01.GetValue(row, "SFG_LINE").ToString() == "Y")
                {
                    this.chk01_OPTION2_PD25210.Checked = true;
                }
                else
                {
                    this.chk01_OPTION2_PD25210.Checked = false;
                }
                if (this.grd01.GetValue(row, "INJ_LINE").ToString() == "Y")
                {
                    this.chk01_OPTION3_PD25210.Checked = true;
                }
                else
                {
                    this.chk01_OPTION3_PD25210.Checked = false;
                }
                if (this.grd01.GetValue(row, "PAINT_LINE").ToString() == "Y")
                {
                    this.chk01_OPTION4_PD25210.Checked = true;
                }
                else
                {
                    this.chk01_OPTION4_PD25210.Checked = false;
                }
                this.txt02_NON_OPRCD.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void txt02_NON_OPRCD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            this.txt02_NON_OPRCD.Focus();
        }

        private void txt02_NON_OPRCD_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.GetByteCount(this.txt02_NON_OPRCD.GetValue().ToString()) == 0)
                {
                    return;
                }

                if (this.txt02_NON_OPRCD.ReadOnly)
                {
                    return;
                }

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("NON_OPRCD", this.txt02_NON_OPRCD.GetValue().ToString());
                

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Detail(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), paramSet);

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow row = source.Tables[0].Rows[0];

                    this.txt02_NON_OPRCD.SetValue(row["NON_OPRCD"]);
                    this.txt02_NON_OPRNM.SetValue(row["NON_OPRNM"]);
                    this.cbo02_STACD.SetValue(row["STACD"]);
                    this.txt02_NON_GROUPCD.SetValue(row["NON_GROUPCD"]);
                    this.txt02_NON_OPRCD.SetReadOnly(true);
                }
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

        void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.grd01.InitializeDataSource();
            this.BtnReset_Click(null, null);
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                DataRow row = source.Tables[0].Rows[0];

                string strNonOprCD = row["NON_OPRCD"].ToString();
                string strNonOprNM = row["NON_OPRNM"].ToString();

                if (this.GetByteCount(strNonOprCD) == 0)
                {
                    //MsgBox.Show("비가동코드를 입력하여 주십시요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("NON_OPRCD"));
                    return false;
                }

                if (this.GetByteCount(strNonOprCD) > 4)
                {
                    //MsgBox.Show("비가동코드는 4Byte를 넘을 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.GetLabel("NON_OPRCD"), "4");
                    return false;
                }

                if (this.GetByteCount(strNonOprNM) > 100)
                {
                    //MsgBox.Show("비가동명 100Byte를 넘을 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.GetLabel("NON_OPRNM"), "100");
                    return false;
                }

                //if (MsgBox.Show("입력하신 비가동코드를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private void grd01_Click(object sender, EventArgs e)
        {

        }

        //private bool IsDeleteValid(DataSet source)
        //{
        //    try
        //    {
        //        if (this.txt02_NON_OPRCD.ReadOnly == false)
        //        {
        //            //MsgBox.Show("데이터 입력 대기 상태에서는 삭제 기능을 사용할 수 없습니다.");
        //            MsgCodeBox.Show("PM00-0049");
        //            return false;
        //        }

        //        //if (MsgBox.Show("선택하신 비가동코드를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //            return false;

        //        return true;
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //    }

        //    return false;
        //}

        #endregion

    }
}
