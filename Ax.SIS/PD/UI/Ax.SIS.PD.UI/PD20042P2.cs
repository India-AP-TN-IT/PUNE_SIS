#region ▶ Description & History
/* 
* 프로그램명 : PD20042P2 품번헬버
* 설      명 : 
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
using C1.Win.C1FlexGrid;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// <b>품번 헬퍼</b>
    /// - 작 성 자 : 홍정현<br />
    /// - 작 성 일 : 2010-06-21<br />
    /// </summary>
    public partial class PD20042P2 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IPM20042 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20042";
        private Boolean _AutoLink = true;

        public PD20042P2()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPM20042>("PM00", "PM20042.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
        }

        public PD20042P2(Boolean AutoLink)
        {
            _AutoLink = AutoLink;
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPM20042>("PM00", "PM20042.svc", "CustomBinding");
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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO", "PARTNOTITLE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품명", "PARTNM", "PARTNONM");

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            if (_AutoLink)
            {
                this.txt01_PARTNO.SetValue(this.CodeBox.GetValue());
                this.txt01_PARTNM.SetValue(this.CodeBox.GetText());
            }

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
            //return _WSCOM.Inquery_PARTNO(set).Tables[0];
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PARTNO"), set).Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("PARTNO",   this.txt01_PARTNO.GetValue());
                set.Add("PARTNM",   this.txt01_PARTNM.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);
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

        private void txt01_PARTNO_KeyUp(object sender, KeyEventArgs e)
        {
            ColumnFilter cf = new ColumnFilter();
            cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            cf.ConditionFilter.Condition1.Parameter = this.txt01_PARTNO.GetValue().ToString();
            this.grd01.Cols["PARTNO"].Filter = cf;
            this.grd01.ApplyFilters();
        }

        private void txt01_PARTNM_KeyUp(object sender, KeyEventArgs e)
        {
            ColumnFilter cf = new ColumnFilter();
            cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            cf.ConditionFilter.Condition1.Parameter = this.txt01_PARTNM.GetValue().ToString();
            this.grd01.Cols["PARTNM"].Filter = cf;
            this.grd01.ApplyFilters();
        }

        #endregion
    }
}
