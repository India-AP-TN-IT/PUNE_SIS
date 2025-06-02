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
    /// <b>공정코드 팝업</b>
    /// - 작 성 자 : 이명희<br />
    /// - 작 성 일 : 2015-01-07<br />
    /// - 주요 변경 사항
    ///     1) 2015-01-07   이명희 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM20020P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;

        public BM20020P1()
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
                    this.grd01.Initialize();
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_공정코드", "PROCCD", "PROCCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "_공정명", "PROCNM", "PROCNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_공정구분", "PROC_DIV", "PROCESS_DIV");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "_공정적용일", "BEG_DATE", "PROC_APP_DATE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "_공정폐쇄일", "END_DATE", "PROC_END_DATE");

                    this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "BV", "PROC_DIV");

                    this.grd01.Cols["BEG_DATE"].Format = "yyyy-MM-dd";
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                    this.grd01.Cols["END_DATE"].Format = "yyyy-MM-dd";
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                    this.IsCreated = true;
                }

                this.txt01_PROCCD.SetValue(this.CodeBox.GetValue());
                this.txt01_PROCNM.SetValue(this.CodeBox.GetText());

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
            return _WSCOM.ExecuteDataSet("APG_BM20020.INQUERY_PROCMASTER", set).Tables[0];
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
                paramSet.Add("PROCCD", txt01_PROCCD.GetValue());
                paramSet.Add("PROCNM", txt01_PROCNM.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_BM20020.INQUERY_PROCMASTER", paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
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
