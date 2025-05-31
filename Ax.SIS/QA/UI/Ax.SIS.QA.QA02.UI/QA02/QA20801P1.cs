#region ▶ Description & History
/* 
 * 프로그램명 : QA20801P1 거래처조회 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2016-12-12      이재한      신규생성
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using System.IO;
using HE.Framework.ServiceModel;
using System.Drawing;

using System.Collections;
using System.Text.RegularExpressions;

namespace Ax.SIS.QA.QA02.UI
{
  
    public partial class QA20801P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA20801";
        private bool _isLoadCompleted = false;
        private string _SERIAL = string.Empty;
        private string _title = string.Empty;
        public QA20801P1(string serial, string title)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _SERIAL = serial;
            _title = title;
        }

     

        #region [ IHEPopupHelper 멤버 ]

        public object SelectedValue
        {
            get
            {
                return this.SelectedData;
            }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            this.CodeBox_HEParameterSetSetting(ref set);
            return this.CodeBox_GetDataSourceChange(_WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SMIS_HISTORY"), set));
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// [ 화면 초기 설정 ]
        /// </summary>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.txt01_SERIAL.SetReadOnly(true);

                ((Form)this.Parent).Text = _title;       
                
                if (!this.IsCreated)
                {
             
                    #region [ 거래처조회 그리드 설정 ]

                    // 그리드 설정
                    this.grd01.AllowEditing = false;

                    this.grd01.Initialize();
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 230, "REFID", "REFID");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "고객사전송시간", "CUST_SEND_DATE", "CUST_SEND_DATE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "RCV_DATE", "DD");          
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "LOTNO", "LOTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "측정결과", "MEAS_METER", "MEAS_METER"); 


                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                    

                    this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                    this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;                    
                    this.grd01.AllowSorting = AllowSortingEnum.SingleColumn;
                    
                    
                 
                    #endregion

                    #region [ 기타 설정 ]

                    this.IsCreated = true;

                    //if (this._SEARCH_CODE != string.Empty)
                    //{

                    //}

                    //_isbinding = false;

                    _isLoadCompleted = true;

                    #endregion
                }

                this.txt01_SERIAL.SetValue(_SERIAL);
                this.btn01_QUERY_Click(null, null);
              
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion



        private void btn01_QUERY_Click(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("SERIAL", this.txt01_SERIAL.GetValue());

                //if (!IsQueryValid_01(paramSet)) return;

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SMIS_HISTORY"), paramSet);

                this.grd01.SetValue(source);
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

      

    }
}
