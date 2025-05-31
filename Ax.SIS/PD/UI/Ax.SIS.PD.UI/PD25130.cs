#region ▶ Description & History
/* 
 * 프로그램명 : 
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 2015-09-04 
 * 최종수정자 : 오세민
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-09-04      오세민     생성
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
    /// <b>작업 구분 코드 등록</b>
    /// </summary>
    public partial class PD25130 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD25130";

        public PD25130()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD", "CORCD");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "작업구분", "WORK_DIV","WORK_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "작업구분명", "WORK_DIVNM","WORK_DIVCD_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "작간접구분", "DIRE_DIV","DIRE_DIVNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "정렬순서", "SORT_SEQ", "SORT_SEQ");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetCorCD().Tables[0], "CORCD");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AF", "DIRE_DIV");

                this.cbo01_DIRE_DIV.DataBind("AF");
                this.cbo02_DIRE_DIV.DataBind("AF");

                this.SetRequired(this.lbl02_WORK_DIVCD);

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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "WORK_DIV", "WORK_DIVNM", "DIRE_DIV", "SORT_SEQ");

                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.txt02_WORK_DIV.GetValue(),
                    this.txt01_WORK_DIV_NM.GetValue(),
                    this.cbo02_DIRE_DIV.GetValue(),
                    this.nme02_SORT_SEQ.GetDBValue());

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}",PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                MsgCodeBox.Show("CD00-0009");//정상적으로 저장되었습니다.
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "WORK_DIV");

                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.txt02_WORK_DIV.GetValue());

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}",PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                MsgCodeBox.Show("CD00-0058"); //데이터가 삭제되었습니다.
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
                paramSet.Add("WORK_DIV", this.txt01_WORK_DIV.GetValue().ToString());
                paramSet.Add("DIRE_DIV", this.cbo01_DIRE_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}",PACKAGE_NAME, "INQUERY"), paramSet);
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
                this.txt02_WORK_DIV.Initialize();
                this.txt01_WORK_DIV_NM.Initialize();
                this.cbo02_DIRE_DIV.Initialize();
                this.txt02_WORK_DIV.SetReadOnly(false);
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

                this.txt02_WORK_DIV.SetValue(this.grd01.GetValue(row, "WORK_DIV"));
                this.txt01_WORK_DIV_NM.SetValue(this.grd01.GetValue(row, "WORK_DIVNM"));
                this.cbo02_DIRE_DIV.SetValue(this.grd01.GetValue(row, "DIRE_DIV"));
                this.txt02_WORK_DIV.SetReadOnly(true);
                this.nme02_SORT_SEQ.SetValue(this.grd01.GetValue(row, "SORT_SEQ").ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void txt02_WORK_DIV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            this.txt02_WORK_DIV.Focus();
        }
        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                DataRow row = source.Tables[0].Rows[0];

                string strNonOprCD = row["WORK_DIV"].ToString();
                string strNonOprNM = row["WORK_DIVNM"].ToString();

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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (this.txt02_WORK_DIV.ReadOnly == false)
                {
                    //MsgBox.Show("데이터 입력 대기 상태에서는 삭제 기능을 사용할 수 없습니다.");
                    MsgCodeBox.Show("PD00-0082");
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
