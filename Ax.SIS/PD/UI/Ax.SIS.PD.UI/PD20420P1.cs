#region ▶ Description & History
/* 
 * 프로그램명 : PD20420P1 금형번호 헬퍼
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			    작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09      배명희         SIS 이관
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
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>금형번호 헬퍼</b>
    /// - 작 성 자 : 이현범<br />
    /// - 작 성 일 : 2016-09-22<br />
    /// </summary>
    public partial class PD20420P1 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IPM20042 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20420";

        public PD20420P1()
        {
            InitializeComponent();

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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "사업장", "BIZCD", "BIZNM2");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "금형번호", "MOLDNO", "MOLDNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "금형명",   "MOLDNM", "MOLDNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "차종", "VINNM", "VIN");

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            try
            {
                this.txt01_MOLDNO.SetValue(this._MOLDNO);
                this.txt01_MOLDNM.SetValue(this._MOLDNM);
            }
            catch
            {
                this.txt01_MOLDNO.SetValue("");
                this.txt01_MOLDNM.SetValue("");
            }

            //this.txt01_MOLDNO.SetValue(this.CodeBox.GetValue());
            //this.txt01_MOLDNM.SetValue(this.CodeBox.GetText());

            this.btn01_Inquery_Click(null, null);
        }


        #endregion
        
        #region [ Property ]

        private string _BIZCD;
        public string BIZCD
        {
            set
            {
                _BIZCD = value;
            }
        }

        private string _MOLDNO;
        public string MOLDNO
        {
            set
            {
                _MOLDNO = value;
            }
        }

        private string _MOLDNM;
        public string MOLDNM
        {
            set
            {
                _MOLDNM = value;
            }
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
            //return _WSCOM.Inquery_MOLDNO(set).Tables[0];
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_MOLDNO"), set).Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD", _BIZCD);
                set.Add("MOLDNO",   this.txt01_MOLDNO.GetValue());
                set.Add("MOLDNM",   this.txt01_MOLDNM.GetValue());
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

        private void txt01_MOLDNO_KeyUp(object sender, KeyEventArgs e)
        {
            //ColumnFilter cf = new ColumnFilter();
            //cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            //cf.ConditionFilter.Condition1.Parameter = this.txt01_MOLDNO.GetValue().ToString();
            //this.grd01.Cols["MOLDNO"].Filter = cf;
            //this.grd01.ApplyFilters();
        }

        private void txt01_MOLDNM_KeyUp(object sender, KeyEventArgs e)
        {
            //ColumnFilter cf = new ColumnFilter();
            //cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            //cf.ConditionFilter.Condition1.Parameter = this.txt01_MOLDNM.GetValue().ToString();
            //this.grd01.Cols["MOLDNM"].Filter = cf;
            //this.grd01.ApplyFilters();
        }

        #endregion
    }
}
