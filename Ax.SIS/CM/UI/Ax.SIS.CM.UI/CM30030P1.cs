#region ▶ Description & History
/* 
 * 프로그램명 : 라인코드 팝업 화면
 * 설      명 : 기존의 생산관리에서 주로 사용하던 팝업 개편.
 * 최초작성자 : 배명희
 * 최초작성일 : 2014-07-22
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-22	    배명희		최초 개발
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.CM.UI
{
    /// <summary>
    /// <b>라인 코드 조회</b>
    /// <remarks>
    /// this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new Ax.SIS.PM.PM03.UI.PM33250P1();
    /// this.cdx01_LINECD.PopupTitle = "라인코드";
    /// this.cdx01_LINECD.CodeParameterName = "LINECD";
    /// this.cdx01_LINECD.NameParameterName = "LINENM";
    /// this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
    /// this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
    /// this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
    /// this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
    /// this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
    /// this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_FROM_DATE.GetValue());
    /// </remarks>
    /// 
    /// </summary>
    public partial class CM30030P1 : AxCommonPopupControl, IAxPopupHelper
    {
        //private ICM20020 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_CM30030";
        string _title = "";

        #region [ 생성자 정의 ]

        public CM30030P1(string title)
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<ICM20020>("CM", "CM20020.svc", "CustomBinding");
            _title = title;
        }

        public CM30030P1()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<ICM20020>("CM", "CM20020.svc", "CustomBinding");
            _title = "";
        }

        #endregion

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
                    this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 100, "라인코드", "LINECD", "LINECD");
                    this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 230, "라인명", "LINENM", "LINENM");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 1, "제품구분", "PRDT_DIV", "PRDT_DIV");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 1, "장착위치", "INSTALL_POS", "INSTALL_POS");
                    this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 080, "공장구분", "PLANT_DIVNM", "PLANT_DIV");
                    this.grd01.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 120, "저장위치", "STR_LOCNM", "STR_LOC");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "장착위치 통합", "INSTALL_POS_INTE_YN", "INSTALL_POS_INTE_YN");
                    this.grd01.AddHiddenColumn("STR_LOC");
                    this.grd01.AddHiddenColumn("PLANT_DIV");
                    this.IsCreated = true;
                }

                if (((Form)this.Parent).Text.Equals(string.Empty))
                {                
                    if (_title.Equals(string.Empty))
                        ((Form)this.Parent).Text = this.GetLabel(this.Name);
                    else
                        ((Form)this.Parent).Text = _title;
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
            //return _WSCOM.Inquery_LINECD(set).Tables[0];
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set, "OUT_CURSOR").Tables[0];
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
                set.Add("PRDT_DIV", this.CodeBox.HEUserParameterGetValue("PRDT_DIV"));
                set.Add("LINECD_DIV",   this.CodeBox.HEUserParameterGetValue("LINECD_DIV"));
                set.Add("DATE",         this.CodeBox.HEUserParameterGetValue("DATE"));
                set.Add("PLANT_DIV",    this.CodeBox.HEUserParameterGetValue("PLANT_DIV"));
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

                this.SelectedData = this.grd01.SelectedDataRowMultiLang;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void txt01_LINECD_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.grd01.Cols.Contains("LINECD") == true)
            {
                ColumnFilter cf = new ColumnFilter();
                cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
                cf.ConditionFilter.Condition1.Parameter = this.txt01_LINECD.GetValue().ToString();
                this.grd01.Cols["LINECD"].Filter = cf;
                this.grd01.ApplyFilters();
            }
        }

        private void txt01_LINENM_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.grd01.Cols.Contains("LINENM") == true)
            {
                ColumnFilter cf = new ColumnFilter();
                cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
                cf.ConditionFilter.Condition1.Parameter = this.txt01_LINENM.GetValue().ToString();
                this.grd01.Cols["LINENM"].Filter = cf;
                this.grd01.ApplyFilters();
            }
        }

        #endregion
    }
}
