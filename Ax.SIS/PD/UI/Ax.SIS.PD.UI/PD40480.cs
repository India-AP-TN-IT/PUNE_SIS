#region ▶ Description & History
/* 
 * 프로그램명 : PD40480 쿼리 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 장기 재고 조회 
    /// </summary>
    public partial class PD40480 : AxCommonBaseControl
    {
        //private IPD40340 _WSCOM;
        private AxClientProxy _WSCOM_N;

        public PD40480()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40340>("PD", "PD40340_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                this.BeforeInvokeServer(true);
                DataTable dt = _WSCOM_N.ExecuteDataSet("$SQL$BEGIN OPEN :OUT_CURSOR FOR " + heTextBox1.GetValue().ToString() + ";  END;", paramSet).Tables[0];
                this.grd01.Clear(C1.Win.C1FlexGrid.ClearFlags.All);
                if (dt.Rows.Count > 0)
                {

                    for (int c = 0; c < dt.Columns.Count; c++)
                    {

                        this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, dt.Columns[c].ColumnName, dt.Columns[c].ColumnName);
                    }
                    this.grd01.DataSource = dt;
                }
                else
                {
                    this.grd01.DataSource = null;
                }
                
           
                
                
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

        #endregion

    }
}
