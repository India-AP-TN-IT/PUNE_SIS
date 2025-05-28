#region ▶ Description & History
/* 
 * 프로그램명 : PD40460 HI 자재입고 조회 & 손망실 처리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
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
using C1.Win.C1FlexGrid;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 반제품 계측 이상조치현황 
    /// </summary>
    public partial class PD40460 : AxCommonBaseControl
    {
        //private IPD40460 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40460";
        public PD40460()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40460>("PD", "PD40460_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.Initialize(1, 1);
                this.grd01.AllowDragging = AllowDraggingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "모듈구분", "MAT_DIV", "MAT_DIV3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "각인일자", "IN_READ_DATE", "IN_READ_DATE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "각인시간", "IN_READ_TIME", "IN_READ_TIME2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "자재LOTNO", "MAT_LOTNO", "MAT_LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재P/NO", "PARTNO", "MAT_PARTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "재고상태", "INV_STATUS", "INV_STATUS");

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;

                this.grd02.Initialize(1, 1);
                this.grd02.AllowDragging = AllowDraggingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "모듈구분", "MAT_DIV", "MAT_DIV3");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재P/NO", "PARTNO", "MAT_PARTENO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "재고수량", "MAT_LOTNO", "INV_QTY1");

                this.grd02.CurrentContextMenu.Items[0].Visible = false;
                this.grd02.CurrentContextMenu.Items[1].Visible = false;
                this.grd02.CurrentContextMenu.Items[2].Visible = false;

                this.rdo01_NORMAL_IN_QTY.Checked = true;

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
                string rdpChk = string.Empty;
                if (rdo01_NORMAL_IN_QTY.Checked) rdpChk = "I0";
                if (rdo01_LOSS.Checked) rdpChk = "X";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("INV_STATUS", rdpChk);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR", "OUT_CURSOR2");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.grd02.SetValue(source.Tables[1]);
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

        #region [ 기타 이벤트 정의 ]

        private void btn03_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                "CORCD", "MAT_LOTNO");

                set.Tables[0].Rows.Add();

                if (!IsSaveValid(set)) return;

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), set);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                MsgCodeBox.Show("CD00-0009");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void rdo01_NOMAL_QTY_Click(object sender, EventArgs e)
        {
            AxRadioButton ck = (AxRadioButton)sender;
            if (ck.Checked)
                BtnQuery_Click(null, null);
        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                //if (MsgBox.Show("창고정보를 초기화 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0097", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                    return false;

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
