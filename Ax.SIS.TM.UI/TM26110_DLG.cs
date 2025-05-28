using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using System.Collections.Generic;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : xnote<br />
    /// - 작 성 일 : 2010-09-07 오후 2:54:11<br />
    /// - 주요 변경 사항
    ///     1) 2010-09-07 오후 2:54:11   xnote : 최초 클래스 생성<br />
    /// </summary>
    public partial class TM26110_DLG : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM_N;
        private SortedList<string, object> _HEUserParameterDummy;
             
        private string m_TY = "";
        public string TY
        {
            get
            {
                return m_TY;
            }
            set { m_TY = value; }
        }
        public TM26110_DLG(string ty, string codeTitle, string descTitle, string codeText, string descText)
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            _HEUserParameterDummy = new SortedList<string, object>();
            lbl01_VENDCD.SetValue(codeTitle);
            lbl01_VENDNM.SetValue(descTitle);
            txt01_VENDCD.SetValue(codeText);
            txt01_VENDNM.SetValue(descText);
            m_TY = ty;
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!IsCreated)
                {
                    this.grd01.Initialize();
                    this.grd01.AllowEditing = false;

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, lbl01_VENDCD.GetValue().ToString(), "CD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, lbl01_VENDNM.GetValue().ToString(), "NM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PHONE", "MPHONE");
                    IsCreated = true;
                }

                if (this.CodeBox != null)
                {
                    this.txt01_VENDCD.SetValue(this.CodeBox.GetValue());
                    this.txt01_VENDNM.SetValue(this.CodeBox.GetText());
                }
                btn01_Inquery_Click(null, null);
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
            paramSet.Add("CORCD", set["CORCD"]);
            paramSet.Add("BIZCD", set["BIZCD"]);
            paramSet.Add("TY", m_TY);
            paramSet.Add("CD", set["CD"]);
            paramSet.Add("NM", set["NM"]);

            return _WSCOM_N.ExecuteDataSet("APG_TM26110.GET_DLG", paramSet, "OUT_CURSOR").Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

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
        private string GetCORCD()
        {
            if(this._HEUserParameterDummy.Count>0)
            {
                return HEUserParameterGetValue("CORCD").ToString();
            }
            else if(this.CodeBox!=null)
            {
                return this.CodeBox.HEUserParameterGetValue("CORCD").ToString();
            }
            return "";
        }
        private string GetBIZCD()
        {
            if (this._HEUserParameterDummy.Count > 0)
            {
                return HEUserParameterGetValue("BIZCD").ToString();
            }
            else if (this.CodeBox != null)
            {
                return this.CodeBox.HEUserParameterGetValue("BIZCD").ToString();
            }
            return "";
        }
        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", GetCORCD());
                paramSet.Add("BIZCD", GetBIZCD());
                paramSet.Add("TY", m_TY);
                paramSet.Add("CD", this.txt01_VENDCD.GetValue());
                paramSet.Add("NM", this.txt01_VENDNM.GetValue());
                BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet("APG_TM26110.GET_DLG", paramSet, "OUT_CURSOR");
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

        #endregion

        #region [ 기타 Method ]

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
