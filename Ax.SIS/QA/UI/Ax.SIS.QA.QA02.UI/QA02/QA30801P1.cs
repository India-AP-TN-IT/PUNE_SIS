#region ▶ Description & History
/* 
 * 프로그램명 : QA30801P1 수지 LOTNO 조회 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				------------------------------------------------------------------------------------------------------------------------------------- 
 *				2017-07-14      배명희      신규생성
 *				2017-07-17      배명희      조회조건 추가(LOTNO, 품번, 생산기간)
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
using Ax.SIS.QA.QA09.UI;

namespace Ax.SIS.QA.QA02.UI
{
    public partial class QA30801P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA30801";
        private bool _isLoadCompleted = false;
        private string _CORCD = "";
        private string _BIZCD = "";
        private string _VENDCD = "";

        #region [ 초기화 설정에 대한 정의 ]

        public QA30801P1(string corcd, string bizcd, string vendcd)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

            this._CORCD = corcd;
            this._BIZCD = bizcd;
            this._VENDCD = vendcd;            
        }


        /// <summary>
        /// [ 화면 초기 설정 ]
        /// </summary>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    ((Form)this.Parent).Text = this.GetLabel("QA30801P1");


                    this.cbo01_BIZCD.DataBind(this.GetBizCD(this._CORCD).Tables[0], false);
                    this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;


                    this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                    this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDNM");//업체명
                    this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                    this.cdx01_VENDCD.NameParameterName = "VENDNM";
                    this.cdx01_VENDCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                    // 그리드 설정
                    this.grd01.AllowEditing = false;
                    //this.grd01.Initialize(1,1);

                    this.grd01.Initialize();
                    this.grd01.ExtendLastCol = true;
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "LOTNO", "MAT_LOTNO", "LOTNO_TITLE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "MAT_PRDT_DATE", "PROD_DATE"); 
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 190, "품번", "PARTNO", "PARTNOTITLE");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MAT_PRDT_DATE");
                    //생산기간 최근6개월
                    this.dte01_PRDT_DATE_FROM.SetValue(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd"));
                    this.dte01_PRDT_DATE_TO.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                 
                    this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                    this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                    this.grd01.AllowSorting = AllowSortingEnum.SingleColumn;
                    this.grd01.InitializeDataSource();
         



                    #region [ 기타 설정 ]

                    this.IsCreated = true;

                    this.cbo01_BIZCD.SetValue(_BIZCD);
                    this.cdx01_VENDCD.SetValue(_VENDCD);

                    this.cbo01_BIZCD.SetReadOnly(true);
                    this.cdx01_VENDCD.SetReadOnly(true);

                    
                    _isLoadCompleted = true;

                    #endregion
                }

                btn01_Inquery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

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
            return this.CodeBox_GetDataSourceChange(_WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LOTNO_LIST"), set));
        }

        #endregion

        #region [ 그리드 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 그리드 마우스 더블클릭 이벤트 ]
        /// </summary>
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    //if (grd.SelectedRowIndex < grd.Rows.Fixed) return;
                    if (grd.MouseRow < grd.Rows.Fixed) return;

                    ArrayList values = new ArrayList();
                    DataTable source = new DataTable();

                    for (int i = grd.Cols.Fixed; i < grd.Cols.Count; i++)
                    {
                        source.Columns.Add(grd.Cols[i].Name);
                        values.Add(grd.GetValue(grd.Row, grd.Cols[i].Name));
                    }

                    source.Rows.Add(values.ToArray());

                    this.SelectedData = source.Rows[0];
                    ((Form)this.Parent).Close();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

       
        /// <summary>
        /// [ 팝업조회 버튼 클릭 이벤트 ]
        /// </summary>
        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            Query_01(sender, null);
            this.btn01_INQUERY.Focus();
        }

        #endregion

        #region [ 사용자 정의 method ]

        /// <summary>
        /// [ 팝업 조회 함수 ]
        /// </summary>
        private void Query_01(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this._CORCD);
                paramSet.Add("BIZCD", this._BIZCD);
                paramSet.Add("VENDCD", this._VENDCD);                
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("PRDT_DATE_FROM", this.dte01_PRDT_DATE_FROM.GetDateText());
                paramSet.Add("PRDT_DATE_TO", this.dte01_PRDT_DATE_TO.GetDateText());     
                this.BeforeInvokeServer(true);                
                DataTable source = this.GetDataSource(paramSet);
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

        #endregion

    }
}
