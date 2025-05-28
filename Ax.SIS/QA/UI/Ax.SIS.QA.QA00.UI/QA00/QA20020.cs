#region ▶ Description & History
/* 
 * 프로그램명 : QA20020 불량유형별 코드 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>불량유형별 코드 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오전 10:39:43<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오전 10:39:43   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20020 : AxCommonBaseControl
    {
        //private IQA20020 _WSCOM;
        private String _CORCD;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20020";
        

        #region [ 초기화 작업 정의 ]

        public QA20020()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20020>("QA00", "QA20020.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("DEFKIND_LIST");
                

                _CORCD = this.UserInfo.CorporationCode;

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;


                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("A", "ALL");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");


                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_USE_YN.SetValue("Y");

                this.grd01_QA20020.AllowEditing = false;
                this.grd01_QA20020.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20020.Initialize();

                this.grd01_QA20020.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20020.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "불량유형코드", "DEFKINDCD", "DEFKINDCD");
                this.grd01_QA20020.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "불량유형명", "DEFKINDNM", "DEFKINDNM");
                this.grd01_QA20020.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd01_QA20020.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "사용유무", "USE_YN", "USE_YN3");
                
                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion


        #region [ 공통 버튼에 대한 이벤트 정의 ]
               
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            this.grd01_QA20020.InitializeDataSource();
        }
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                
                string DEFCD_DEFNM = this.txt01_DEFCD_DEFNM.GetValue().ToString();
                string USE_YN = this.cbo01_USE_YN.GetValue().ToString();
                
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);                
                paramSet.Add("DEFKINDCD_DEFKINDNM", DEFCD_DEFNM);
                paramSet.Add("USE_YN", USE_YN);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20020.SetValue(source);
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

        //protected override void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
               
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        
        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
              
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}
        

        #endregion

        #region [ 기타 이벤트 정의 ]

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
               
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
              

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        #region [사용자 정의 메서드]

       
        #endregion

    }
}
