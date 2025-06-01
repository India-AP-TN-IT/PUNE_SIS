using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>품번 헬퍼</b>
    /// - 작 성 자 : 홍정현<br />
    /// - 작 성 일 : 2010-06-21<br />
    /// </summary>
    public partial class PD30010P1 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IPM20042 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD30010";
        

        public PD30010P1()
        {
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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "품명", "PARTNM", "PARTNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINCD", "CARTYPETITLE");

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

          

            //this.btn01_Inquery_Click(null, null);
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
                if (this.txt01_PARTNO.IsEmpty && this.txt01_PARTNM.IsEmpty)
                {
                    //최소 1개이상의 조건을 입력해야 합니다.
                    MsgCodeBox.Show("PD00-0100");
                    return ;
                }
                HEParameterSet set = new HEParameterSet();
                //set.Add("PRDT_DIV", this.CodeBox.HEUserParameterGetValue("PRDT_DIV"));
                //set.Add("MIPV_DIV", this.CodeBox.HEUserParameterGetValue("MIPV_DIV"));
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
