#region ▶ Description & History
/* 
 * 프로그램명 : 라인코드 팝업 화면
 * 설     명 : 생산관리 프로그램 주로 사용
 * 최초작성자 : 오세민
 * 최초작성일 : 2012-01-03
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2012-01-03	오세민		최초 개발
 *				2017-07~09    배명희     SIS 이관
 *				
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
    /// <b>대표 라인 코드</b>
    /// <remarks>
    /// this.cdx01_LINECD.HEPopupHelper = new CM20020P1(); //new HE.ERM.PM.PM03.UI.PM33250P1();
    /// this.cdx01_LINECD.PopupTitle = "라인코드";
    /// this.cdx01_LINECD.CodeParameterName = "LINECD";
    /// this.cdx01_LINECD.NameParameterName = "LINENM";
    /// this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
    /// this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
    /// this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
    /// this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
    /// this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_FROM_DATE.GetValue());
    /// </remarks>
    /// 
    /// </summary>
    public partial class PD25240P1 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD25240";		

        public PD25240P1()
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
                if (!this.IsCreated)
                {
                    this.grd01.AllowEditing = false;
                    this.grd01.Initialize();
                    this.grd01.AllowFiltering = true;
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "부서코드", "LINECD", "LINECD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "부서명", "LINENM", "LINENM");

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            this.txt01_LINECD.SetValue(this.CodeBox.GetValue());
            this.txt01_LINENM.SetValue(this.CodeBox.GetText());

            this.btn01_Inquery_Click(null, null);
        }

        #endregion

        #region IHEPopupHelper 멤버

        public object SelectedValue
        {
            get { return this.SelectedData; }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "Inquery_LINECODE"),set).Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",    this.CodeBox.HEUserParameterGetValue("CORCD"));
                set.Add("BIZCD",    this.CodeBox.HEUserParameterGetValue("BIZCD"));
                set.Add("LINECD",   this.txt01_LINECD.GetValue());
                set.Add("LINENM",   this.txt01_LINENM.GetValue());
                set.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));                
                set.Add("DATE", this.CodeBox.HEUserParameterGetValue("DATE"));                
                this.BeforeInvokeServer(true);
                DataTable table = this.GetDataSource(set);
                this.AfterInvokeServer();

                this.grd01.SetValue(table);
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

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.grd01.SelectedDataRow;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void txt01_LINECD_KeyUp(object sender, KeyEventArgs e)
        {
            //ColumnFilter cf = new ColumnFilter();
            //cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            //cf.ConditionFilter.Condition1.Parameter = this.txt01_LINECD.GetValue().ToString();
            //this.grd01.Cols["LINECD"].Filter = cf;
            //this.grd01.ApplyFilters();
        }

        private void txt01_LINENM_KeyUp(object sender, KeyEventArgs e)
        {
            //ColumnFilter cf = new ColumnFilter();
            //cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            //cf.ConditionFilter.Condition1.Parameter = this.txt01_LINENM.GetValue().ToString();
            //this.grd01.Cols["LINENM"].Filter = cf;
            //this.grd01.ApplyFilters();
        }

        #endregion
    }
}
 