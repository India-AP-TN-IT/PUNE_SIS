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
    public partial class PD31350P1 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IPM20042 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD31350";
        

        public PD31350P1()
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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "CONTCD", "CONTCD", "CONTCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "용기명", "CONTNM", "CONTNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "단위", "UNIT", "UNIT");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "적입량", "PACK_QTY", "UNIT_PACK_QTY_SIM");

                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PACK_QTY");
                    this.grd01.Cols["PACK_QTY"].Format = "#,###,###,###,##0";
                    this.IsCreated = true;

                }

                this.btn01_Inquery_Click(null, null);
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
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CONTCD"), set).Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD"));
                set.Add("VENDCD", this.CodeBox.HEUserParameterGetValue("VENDCD"));
                set.Add("INPUT_DATE", this.CodeBox.HEUserParameterGetValue("INPUT_DATE"));
                set.Add("CONTCD",   this.txt01_CONTCD.GetValue());
                set.Add("CONTNM",   this.txt01_CONTNM.GetValue());
                set.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));

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

    
        #endregion
    }
}
