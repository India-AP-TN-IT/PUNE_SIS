#region ▶ Description & History
/* 
 * 프로그램명 : QA20021P1
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-12-13      배명희      통합WCF로 변경 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using System.Drawing;

namespace Ax.SIS.QA.QA09.UI
{
    /// <summary>
    /// <b>검사코드 팝업창</b>    
    /// </summary>
    public partial class QASubWindow_DEFCD : AxCommonPopupControl, IAxPopupHelper
    {
        //private IQASubWindow _WSCOM;
        private string _TITLE;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME_SUBWINDOW = "APG_QASUBWINDOW";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        
        #region [ 생성자 정의 ]

        public QASubWindow_DEFCD()
            : base()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQASubWindow>("QA09", "QASubWindow.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            _TITLE = this.CodeBox.CodeParameterName;

            try
            {
                if (!this.IsCreated)
                {
                    SubWindow_Setting();

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            this.txt01_CODE.SetValue(this.CodeBox.GetValue());
            this.txt01_NAME.SetValue(this.CodeBox.GetText());

            this.btn01_Inquery_Click(null, null);
        }

        #endregion

        #region [ IHEPopupHelper 멤버 ]

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
            DataTable dt = new DataTable();

            //dt = _WSCOM.Inquery_DEFCD(set).Tables[0];
            dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_DEFCD"), set).Tables[0];
            
            return dt;
        }

        public DataTable GetDataSourceLeft(HEParameterSet set)
        {
            DataTable dt = new DataTable();

            //dt = _WSCOM.Inquery_DEFCD(set).Tables[0];
            dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_SUBWINDOW, "INQUERY_DEFKINDCD"), set).Tables[0];

            return dt;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("DEFKINDCD", this.cbo01_DEFKINDCD.GetValue());
                set.Add("DEFCD", this.txt01_CODE.GetValue());
                set.Add("DEFNM", this.txt01_NAME.GetValue());
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                set.Add("LANG_SET", this.UserInfo.Language);

                lbl01_CODE.Value = this.GetLabel("DEFCD");       // "불량코드";
                lbl01_NAME.Value = this.GetLabel("DEFNM");       // "불량명";

                this.BeforeInvokeServer(true);

                DataTable tableLeft = this.GetDataSourceLeft(set);

                set.Add("USE_YN", "Y");
                DataTable table = this.GetDataSource(set);
                
                this.AfterInvokeServer();

                this.grdLeft.SetValue(tableLeft);
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


        private void grdLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int rowIdx = this.grdLeft.MouseRow;
                int colIdx = this.grdLeft.MouseCol;
                if (rowIdx < this.grdLeft.Rows.Fixed || rowIdx >= this.grdLeft.Rows.Count) return;
                if (colIdx < this.grdLeft.Cols.Fixed || colIdx >= this.grdLeft.Cols.Count) return;

                string DEFKINDCD = this.grdLeft.GetValue(rowIdx, "DEFKINDCD").ToString();
                HEParameterSet set = new HEParameterSet();

                set.Add("DEFKINDCD", DEFKINDCD);
                set.Add("DEFCD", this.txt01_CODE.GetValue());
                set.Add("DEFNM", this.txt01_NAME.GetValue());
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD").ToString());
                set.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);
                

                this.AfterInvokeServer();

                
                this.grd01.SetValue(table);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }


        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void SubWindow_Setting()
        {
            lbl01_NAME.Visible = true;
            txt01_NAME.Visible = true;



            this.grdLeft.AllowEditing = false;
            this.grdLeft.Initialize();

            this.grdLeft.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "불량유형코드", "DEFKINDCD", "DEFKINDCD");
            this.grdLeft.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "불량유형명", "DEFKINDNM", "DEFKINDNM");
            this.grdLeft.Cols[0].Visible = false;
            this.grdLeft.Styles.Fixed.BackColor = Color.FromArgb(190, 220, 255);

            this.grd01.AllowEditing = false;
            this.grd01.Initialize();


            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "불량내용코드", "DEFCD", "DEFCD");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "불량내용명", "DEFNM", "DEFNM");

            DataTable dt = this.getDEFKINDCD();
            this.cbo01_DEFKINDCD.DataBind(dt, true);

        }

        #endregion



        #region [사용자 정의 메서드]

        private DataTable getDEFKINDCD()
        {
            DataTable source = new DataTable();
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("LANG_SET", this.UserInfo.Language);


                //DataSet source = _WSCOM.Inquery(paramSet);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_DEFKINDCD"), paramSet).Tables[0];

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            return source;
        }

        #endregion

       

    }
}
