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
using System.Collections.Generic;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-06-09 오전 11:58:51<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-09 오전 11:58:51   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM10010P0 : AxCommonPopupControl, IAxPopupHelper
    {
        //private IBM20420 _WSCOM;
        private AxClientProxy _WSCOM;
        private SortedList<string, object> _HEUserParameterDummy;
        public BM10010P0()
        {
            InitializeComponent();
            _HEUserParameterDummy = new SortedList<string, object>();
            //_WSCOM = ClientFactory.CreateChannel<IBM20420>("BM00", "BM20420.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!IsCreated)
                {
                    txt01_PARTCD.SetValid(30, AxTextBox.TextType.UAlphabet);

                    this.grd01.AllowEditing = false;
                    this.grd01.PopMenuVisible = false;
                    this.grd01.Initialize();

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PART NO.", "PARTNO","PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "DESC", "PARTNM", "PARTNAME");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "Rev", "REVISION");

                    this.IsCreated = true;
                }

                this.txt01_PARTCD.SetValue(HEUserParameterGetValue("PARTNO"));
                this.txt01_PARTNM.SetValue("");

                this.btn01_Inquery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
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
            HEParameterSet paramSet = new HEParameterSet();

            paramSet.Add("CORCD", HEUserParameterGetValue("CORCD"));
            paramSet.Add("BIZCD", HEUserParameterGetValue("BIZCD"));
            paramSet.Add("PARTNO", HEUserParameterGetValue("PARTNO"));
            paramSet.Add("PARTNM","");
            paramSet.Add("STD_DATE", HEUserParameterGetValue("STD_DATE"));
            return _WSCOM.ExecuteDataSet("APG_BM10010.GET_PARTLIST", paramSet).Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 처리 ]
        
        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try{
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", HEUserParameterGetValue("CORCD"));
                paramSet.Add("BIZCD", HEUserParameterGetValue("BIZCD"));
                paramSet.Add("PARTNO", txt01_PARTCD.GetValue());
                paramSet.Add("PARTNM", txt01_PARTNM.GetValue());
                paramSet.Add("STD_DATE", HEUserParameterGetValue("STD_DATE"));

                if (!IsQueryValid(paramSet)) return;
            
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.GetPartList(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet("APG_BM10010.GET_PARTLIST", paramSet);
                this.AfterInvokeServer();
                
                this.grd01.SetValue(source.Tables[0]);
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
            if (set["PARTNO"].ToString().Trim().Length == 0 && set["PARTNM"].ToString().Trim().Length == 0)
            {
                MsgBox.Show("부품번호 혹은 부품명을 입력해주세요!");
                //MsgCodeBox.ShowFormat("CD00-0082", this.GetLabel("@@"));
                return false;
            }
            return true;
        }
        public void HEUserParameterSetValue(string key, object value)
        {
            if (_HEUserParameterDummy.Keys.Contains(key) == true)
                _HEUserParameterDummy[key] = value;
            else
                _HEUserParameterDummy.Add(key, value);
        }

        public object HEUserParameterGetValue(string key)
        {
            return (_HEUserParameterDummy[key] == null) ? null : _HEUserParameterDummy[key];
        }
        #endregion
    }
}
