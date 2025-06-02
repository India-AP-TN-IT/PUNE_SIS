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
    /// - 작 성 자 : 이태호br />
    /// - 작 성 일 : 2010-06-04 오전 8:46:28<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-04 오전 8:46:28   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM20710P1 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IBM20710 _WSCOM;
        private AxClientProxy _WSCOM;
        private AxTextBox _Revision;
        private bool m_bAutoExpl = false;
        public BM20710P1()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IBM20710>("BM00", "BM20710.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        public BM20710P1(AxTextBox revision, bool autoExpl = false)
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IBM20710>("BM00", "BM20710.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
            _Revision = revision;
            m_bAutoExpl = autoExpl;
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    txt01_PARTCD.SetValid(14, AxTextBox.TextType.UAlphabet);
                    this.grd01.AllowEditing = false;
                    this.grd01.Initialize();

                    this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "P/NO", "PARTNO", "PARTNO3");
                    this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 200, "Part Name", "PARTNM", "ITEMNM4");
                    this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 30, "Rev", "REVISION");

                    this.IsCreated = true;
                }

                this.txt01_PARTCD.SetValue(this.CodeBox.GetValue());
                this.txt01_PARTNM.SetValue(this.CodeBox.GetText());

                this.btn01_Inquery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.CodeBox.HEUserParameterGetValue("CORCD"));
                paramSet.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD"));
                paramSet.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));
                paramSet.Add("PARTNO", this.txt01_PARTCD.GetValue());
                paramSet.Add("PARTNM", this.txt01_PARTNM.GetValue());
                paramSet.Add("LINECD", this.CodeBox.HEUserParameterGetValue("LINECD"));
                paramSet.Add("AUTO_YN", m_bAutoExpl ? "Y" : "N");
            
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.GetPartList(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet("APG_BM20710.GET_PARTLIST", paramSet);
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

        #region [ 유효성 검사 ]

        private bool IsQueryValid(HEParameterSet set)
        {
            if (set["PARTNO"].ToString().Length == 0 && set["PARTNM"].ToString().Length == 0)
            {
                //MsgBox.Show("조회하실 부품번호 혹은 부품명을 입력해주세요!");
                MsgCodeBox.Show("@@");
                return false;
            }

            return true;
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
            if (_Revision != null)
            {
                bool exists = false;
                for (int i = 0; i < set.Keys.Count; i++)
                    if (set.Keys[i].ToString().Equals("REVISION"))
                    {
                        exists = true;
                        break;
                    }

                if (exists)
                    set["REVISION"] = _Revision.GetValue().ToString();
                else
                    set.Add("REVISION", _Revision.GetValue().ToString());
            }

            return _WSCOM.ExecuteDataSet("APG_BM20710.GET_PARTLIST", set).Tables[0];
        }

        #endregion

    }
}
