#region ▶ Description & History
/* 
 * 프로그램명 : PD31110 시트창고 입출고 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
 
    public partial class PD31110 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD31110";

        public PD31110()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        private void PD31110_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody  = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "실적일자", "STD_DATE", "RSLT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "입출구분", "INOUT_DIV", "INOUT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업시간", "PROC_TIME", "WORK_TIME_1");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                
                DataSet ds03 = this.GetDataSourceSchema("Code", "CodeValue");
                ds03.Tables[0].Rows.Add("1", this.GetLabel("RCV")); //"입고");//@@@
                ds03.Tables[0].Rows.Add("2", this.GetLabel("OUT"));//"출고");//@@@
                this.cbo01_INOUT_DIV.DataBind(ds03.Tables[0], true);

                this.dte01_BEG_DATE.SetMMFromStart();

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD",    this.cbo01_BIZCD.GetValue());
                set.Add("BEG_DATE", this.dte01_BEG_DATE.GetDateText());
                set.Add("END_DATE", this.dte01_END_DATE.GetDateText());
                set.Add("INOUT_DIV", this.cbo01_INOUT_DIV.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                
                DataSet dsInquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.grd01.SetValue(dsInquery);
                ShowDataCount(dsInquery);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        #endregion
    }
}
