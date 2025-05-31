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
    public partial class BM20115P3 : AxCommonPopupControl
    
    {
        private AxClientProxy _WSCOM_N;
        private SortedList<string, object> _HEUserParameterDummy;

        public BM20115P3()
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

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "품명", "PARTNM");

                    IsCreated = true;
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
            paramSet.Add("CORCD", this.HEUserParameterGetValue("CORCD"));
            paramSet.Add("BIZCD", this.HEUserParameterGetValue("BIZCD"));
            paramSet.Add("VINCD", this.HEUserParameterGetValue("VINCD"));
            paramSet.Add("ITEMCD", this.HEUserParameterGetValue("ITEMCD"));
            paramSet.Add("INSTALL_POS", this.HEUserParameterGetValue("INSTALL_POS"));
            paramSet.Add("ASSY_COL", this.HEUserParameterGetValue("ASSY_COL"));
            paramSet.Add("KEY_COL", this.HEUserParameterGetValue("KEY_COL"));
            paramSet.Add("ETC1", this.HEUserParameterGetValue("ETC1"));
            paramSet.Add("ETC2", this.HEUserParameterGetValue("ETC2"));
            paramSet.Add("ETC3", this.HEUserParameterGetValue("ETC3"));
            paramSet.Add("ETC4", this.HEUserParameterGetValue("ETC4"));
            paramSet.Add("ETC5", this.HEUserParameterGetValue("ETC5"));
            paramSet.Add("ETC6", this.HEUserParameterGetValue("ETC6"));
            paramSet.Add("ETC7", this.HEUserParameterGetValue("ETC7"));
            paramSet.Add("ETC8", this.HEUserParameterGetValue("ETC8"));
            paramSet.Add("ETC9", this.HEUserParameterGetValue("ETC9"));
            paramSet.Add("ETC10", this.HEUserParameterGetValue("ETC10"));
            paramSet.Add("ETC11", this.HEUserParameterGetValue("ETC11"));
            paramSet.Add("ETC12", this.HEUserParameterGetValue("ETC12"));
            paramSet.Add("ETC13", this.HEUserParameterGetValue("ETC13"));
            paramSet.Add("ETC14", this.HEUserParameterGetValue("ETC14"));
            paramSet.Add("ETC15", this.HEUserParameterGetValue("ETC15"));
            return _WSCOM_N.ExecuteDataSet("APG_BM20115.COLOR_CHART_DET", paramSet, "OUT_CURSOR").Tables[0];
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
                paramSet.Add("VINCD", this.HEUserParameterGetValue("VINCD"));
                paramSet.Add("ITEMCD", this.HEUserParameterGetValue("ITEMCD"));
                paramSet.Add("INSTALL_POS", this.HEUserParameterGetValue("INSTALL_POS"));
                paramSet.Add("ASSY_COL", this.HEUserParameterGetValue("ASSY_COL"));
                paramSet.Add("KEY_COL", this.HEUserParameterGetValue("KEY_COL"));
                paramSet.Add("ETC1", this.HEUserParameterGetValue("ETC1"));
                paramSet.Add("ETC2", this.HEUserParameterGetValue("ETC2"));
                paramSet.Add("ETC3", this.HEUserParameterGetValue("ETC3"));
                paramSet.Add("ETC4", this.HEUserParameterGetValue("ETC4"));
                paramSet.Add("ETC5", this.HEUserParameterGetValue("ETC5"));
                paramSet.Add("ETC6", this.HEUserParameterGetValue("ETC6"));
                paramSet.Add("ETC7", this.HEUserParameterGetValue("ETC7"));
                paramSet.Add("ETC8", this.HEUserParameterGetValue("ETC8"));
                paramSet.Add("ETC9", this.HEUserParameterGetValue("ETC9"));
                paramSet.Add("ETC10", this.HEUserParameterGetValue("ETC10"));
                paramSet.Add("ETC11", this.HEUserParameterGetValue("ETC11"));
                paramSet.Add("ETC12", this.HEUserParameterGetValue("ETC12"));
                paramSet.Add("ETC13", this.HEUserParameterGetValue("ETC13"));
                paramSet.Add("ETC14", this.HEUserParameterGetValue("ETC14"));
                paramSet.Add("ETC15", this.HEUserParameterGetValue("ETC15"));
                DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM20115.COLOR_CHART_DET", paramSet, "OUT_CURSOR");
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
