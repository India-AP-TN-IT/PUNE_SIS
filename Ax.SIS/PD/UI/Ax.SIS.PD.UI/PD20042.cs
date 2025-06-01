#region ▶ Description & History
/* 
* 프로그램명 : PD20042 금형별 제품정보
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관(구.PM20042)
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
    /// <b>금형별 제품정보</b>
    /// - 작 성 자 : 홍정현<br />
    /// - 작 성 일 : 2010-06-21<br />
    /// </summary>
    public partial class PD20042 : AxCommonBaseControl
    {
        //private IPD20042 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20042";

        private string _CORCD = "";
        private string _BIZCD = "";

        public PD20042()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20042>("PM00", "PD20042.svc", "CustomBinding");
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
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품명", "PARTNM", "PARTNONM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Usage", "USAGE", "");
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");

                this.cbo01_SAUP.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_SAUP.SetReadOnly(false);
                else
                    this.cbo01_SAUP.SetReadOnly(true);

                this.cdx01_MOLDNO.HEPopupHelper     = new PD20042P1();
                this.cdx01_MOLDNO.PopupTitle        = this.GetLabel("MOLDNO");
                this.cdx01_MOLDNO.CodeParameterName = "MOLDNO";
                this.cdx01_MOLDNO.NameParameterName = "MOLDNM";
                this.cdx01_MOLDNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_MOLDNO.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());

                
                this.cdx01_PARTNO.HEPopupHelper     = new PD20042P2();
                this.cdx01_PARTNO.PopupTitle        = this.GetLabel("PARTNO");
                this.cdx01_PARTNO.CodeParameterName = "PARTNO";
                this.cdx01_PARTNO.NameParameterName = "PARTNM";
                this.cdx01_PARTNO.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_PARTNO.CodePixedLength = 20;
                label1.Text = "";
                this.SetRequired(this.lbl02_MOLDNO, this.lbl01_PARTNO, this.lbl01_USAGE);
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
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "MOLDNO", "PARTNO", "USAGE");

                if (_CORCD.Length == 0 || _BIZCD.Length == 0)
                {
                    _CORCD = this.UserInfo.CorporationCode;
                    _BIZCD = this.cbo01_SAUP.GetValue().ToString();
                }

                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.label1.Text,
                    this.cdx01_PARTNO.GetValue(),
                    this.nme01_USAGE.GetDBValue()
                );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 금형별 제품 정보가 저장되었습니다");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "MOLDNO", "PARTNO");
                source.Tables[0].Rows.Add
                (
                    _CORCD, 
                    _BIZCD,
                    this.label1.Text,
                    this.cdx01_PARTNO.GetValue()
                );

                if (!this.IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 금형별 제품 정보가 삭제되었습니다");
                // 삭제되었습니다.
                MsgCodeBox.Show("CD00-0072");
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                
                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD",    this.cbo01_SAUP.GetValue());
                set.Add("MOLDNO",   this.cdx01_MOLDNO.GetValue());
                set.Add("PARTNO",   this.txt01_PARTNO.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

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
                this.label1.Text = "";
                this.cdx01_PARTNO.Initialize();
                this.nme01_USAGE.Initialize();

                this.cdx01_PARTNO.SetReadOnly(false);
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

                this.label1.Text= this.grd01.GetValue(row, "MOLDNO").ToString();
                this.cdx01_PARTNO.SetValue(this.grd01.GetValue(row, "PARTNO"));
                this.nme01_USAGE.SetValue(this.grd01.GetValue(row, "USAGE"));

                this.cdx01_PARTNO.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_SAUP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_MOLDNO.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
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
                    //MsgBox.Show("저장할 금형별 제품 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                DataRow row    = source.Tables[0].Rows[0];
                string  MOLDNO = row["MOLDNO"].ToString();
                string  PARTNO = row["PARTNO"].ToString();
                string  USAGE  = row["USAGE"].ToString();

                if (this.GetByteCount(MOLDNO) == 0)
                {
                    //MsgBox.Show("금형번호가 입력되지 않았습니다.");
                    // {0}가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("MOLDNO"));
                    return false;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("품번이 입력되지 않았습니다.");
                    // {0}가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("PARTNO"));
                    return false;
                }

                if (this.GetByteCount(USAGE) == 0)
                {
                    //MsgBox.Show("USAGE 가 입력되지 않았습니다.");
                    // {0}가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("USAGE"));
                    return false;
                }

                int iUSAGE = Int32.Parse(USAGE);
                if (iUSAGE < 0)
                {
                    //MsgBox.Show("USAGE 는 음수가 될 수 없습니다.");
                    MsgCodeBox.Show("PD00-0060");
                    return false;
                }

                //if (MsgBox.Show("입력하신 금형별 제품 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                // 저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                

                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 금형번호 정보가 존재하지 않습니다.");
                    // 삭제할 {0}가 존재하지 않습니다.
                    MsgCodeBox.ShowFormat("PD00-0061", this.GetLabel("MOLDNO"));
                    return false;
                }

                //if (MsgBox.Show("선택하신 금형번호 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                // 삭제하시겠습니까?
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        private void axButton1_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Do you want to import the SAP Mold Data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    this.BeforeInvokeServer(true);
                    //_WSCOM.Save(source);
                    HEParameterSet set = new HEParameterSet();

                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_SAUP.GetValue());
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "IMPORT_SAP_DATA"), set);
                    

                    this.BtnQuery_Click(null, null);
                }catch
                {

                }
                finally
                {
                    this.AfterInvokeServer();
                }
            }
        }

    }
}
