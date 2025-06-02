using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// <b>외작 PART NO 헬퍼</b>
    /// - 작 성 자 : 홍정현<br />
    /// - 작 성 일 : 2010-08-09<br />
    /// </summary>
    public partial class XM30410P1 : AxCommonPopupControl, IAxPopupHelper
    {        
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30410";
        public XM30410P1()
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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "PART NO", "PARTNO", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 340, "PART NAME", "PARTNM", "PARTNM");

                    this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);                    

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            this.txt01_PARTNO.SetValue(this.CodeBox.GetValue());
            this.txt01_PARTNM.SetValue(this.CodeBox.GetText());

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
            //return _WSCOM.Inquery_OUT_PARTNO(set).Tables[0];
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PARTNO"), set).Tables[0];
        }

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("PARTNO",   this.txt01_PARTNO.GetValue());
                set.Add("PARTNM",   this.txt01_PARTNM.GetValue());                
                set.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);
                this.grd01.SetValue(table);
                this.AfterInvokeServer();
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
                if (this.grd01.Row < this.grd01.Rows.Fixed) return;

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
