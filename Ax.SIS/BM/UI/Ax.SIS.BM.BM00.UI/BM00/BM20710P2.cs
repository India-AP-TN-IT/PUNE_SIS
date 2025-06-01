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

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : xnote<br />
    /// - 작 성 일 : 2010-10-18 오후 2:08:37<br />
    /// - 주요 변경 사항
    ///     1) 2010-10-18 오후 2:08:37   xnote : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM20710P2 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IBM20710 _WSCOM;
        private AxClientProxy _WSCOM;

        public BM20710P2()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IBM20710>("BM00", "BM20710.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            if (!this.IsCreated)
            {
                txt01_LINECD.SetValid(10, AxTextBox.TextType.UAlphabet);
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "CODE", "LINECD","LINECD");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 200, "NAME", "LINENM","LINENM");

                this.IsCreated = true;
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
            return _WSCOM.ExecuteDataSet("APG_BM20710.GET_LINECD", set).Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("LINECD", this.txt01_LINECD.GetValue());
                paramSet.Add("LINENM", this.txt01_LINENM.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.GetLinecd(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet("APG_BM20710.GET_LINECD", paramSet);
                this.AfterInvokeServer();

                grd01.SetValue(source.Tables[0]);
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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
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
