using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : xnote<br />
    /// - 작 성 일 : 2010-09-07 오후 2:54:11<br />
    /// - 주요 변경 사항
    ///     1) 2010-09-07 오후 2:54:11   xnote : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM20115P2 : AxCommonPopupControl
    {
        private AxClientProxy _WSCOM_N;
        private SortedList<string, object> _HEUserParameterDummy;

        public BM20115P2()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            _HEUserParameterDummy = new SortedList<string, object>();

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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "위치코드", "T_CODE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "위치명", "T_DESC");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "연관품번", "T_ETC1");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "연관품명", "T_ETC2");

                    IsCreated = true;
                }

                //  btn01_Inquery_Click(null, null);
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
            paramSet.Add("CORCD", this.HEUserParameterGetValue("CORCD"));
            paramSet.Add("BIZCD", this.HEUserParameterGetValue("BIZCD"));
            paramSet.Add("TY_CODE", "POSLIST");
            paramSet.Add("CODE", this.txt01_VENDCD.GetValue());
            paramSet.Add("DESC", "");

            paramSet.Add("LANG_SET", this.HEUserParameterGetValue("LANG_SET"));
            return _WSCOM_N.ExecuteDataSet("APG_BM20115.INQUERY_DLG", paramSet, "OUT_CURSOR").Tables[0];
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

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.HEUserParameterGetValue("CORCD"));
                paramSet.Add("BIZCD", this.HEUserParameterGetValue("BIZCD"));
                paramSet.Add("TY_CODE", "POSLIST");
                paramSet.Add("CODE", this.txt01_VENDCD.GetValue());
                paramSet.Add("DESC", "");
                paramSet.Add("LANG_SET", this.HEUserParameterGetValue("LANG_SET"));
                BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM20115.INQUERY_DLG", paramSet, "OUT_CURSOR");
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
