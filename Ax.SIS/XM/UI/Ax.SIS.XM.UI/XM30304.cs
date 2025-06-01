#region ▶ Description & History
/* 
 * 프로그램명 : 프로그램 사용현황 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : ㅂ명희
 * 최종수정일 : 2013-11-12
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2013-11-12	    배명희		등록일자, 수정일자 정보 추가
 *				
 *              2013-11-12      배명희      [#001] 사번/파트 팝업 조회 기능 추가, 그리드 상단에 총 합계 추가. *           
 *                                          [#002] 미사용제외 기능 추가 - 체크하면 사용하지 않는 데이터는 화면에 미 표시
 *                                          [#003] 사용자별로 프로그램 사용현황 조회 기능 추가.(사번별 건수)
 *                                          [#004] 화면 로드시 기본 조회 기능 제거함. (2014.04.23)
 *              2014-07-08      배명희      프로그램 아이디 변경(X60020 -> XM30303)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 공통컨트롤로 전환
 *              2014-07-15      배명희      사용자별 조회시 모듈정보(대메뉴) 외에 하위 "중메뉴" 조건도 추가.
 *              2014-07-21      배명희      사용자별 조회 그리드(GRD02) USERID, NAME_KOR 컬럼 allowMerging = true 처리함.
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거        
 *              2014-08-13      배명희     사용자별 조회 그리드(GRD02)에 소속(DEPTNM)항목 추가, AllowMerging = true처리.
 *              2014-08-14      배명희     사용자별 조회 그리드(GRD02)에 소속별 소계 추가. 고정컬럼 스타일의 BORDER COLOR 변경(색이 너무 연해서)
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
 * 
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// DB Monitoring
    /// </summary>
    public partial class XM30304 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public XM30304()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 설정 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 210, "Resource Name", "RESOURCE_NAME", "RESOURCE_NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "Current Utilization", "CURRENT_UTILIZATION", "CURRENT_UTILIZATION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "Initial Allocation", "INITIAL_ALLOCATION", "INITIAL_ALLOCATION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "Limit Value", "LIMIT_VALUE", "LIMIT_VALUE");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                //this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Tablespace Name", "TABLESPACE_NAME", "TABLESPACE_NAME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "AMOUNT(MB)", "AMOUNT", "AMOUNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "USED(MB)", "USED", "USED");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "FREE(MB)", "FREE", "FREE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "USED(%)", "USED_PERCENT", "USED_PERCENT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "FREE(%)", "FREE_PERCENT", "FREE_PERCENT");

                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;             
                this.grd02.AllowMerging = AllowMergingEnum.RestrictCols;


                this.BtnQuery_Click(null, null);
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

        #region [ 공통 버튼 클릭 이벤트 ]
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                HEParameterSet set = new HEParameterSet();
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source1 = _WSCOM.ExecuteDataSet("APG_XM30304.INQUIRY_INSTANCE", set);
                this.AfterInvokeServer();

                if (source1.Tables[0].Rows.Count > 0)
                {
                    DataRow row = source1.Tables[0].Rows[0];
                    txt01_INSTANCE_NAME.Text = row["INSTANCE_NAME"].ToString();
                    txt01_HOST_NAME.Text = row["HOST_NAME"].ToString();
                    txt01_STATUS.Text = row["STATUS"].ToString();
                    txt01_VERSION.Text = row["VERSION"].ToString();
                }

                if (tabControl1.SelectedIndex == 0) // Resource  
                {
                    set = new HEParameterSet();

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(set);
                    DataSet source2 = _WSCOM.ExecuteDataSet("APG_XM30304.INQUIRY_RESOURCE", set);
                    this.AfterInvokeServer();

                    this.grd01.SetValue(source2); 
                }
                else // Tablespace 
                {

                    set = new HEParameterSet();

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(set);
                    DataSet source3 = _WSCOM.ExecuteDataSet("APG_XM30304.INQUIRY_TABLESPACE", set);
                    this.AfterInvokeServer();

                    this.grd02.SetValue(source3); 
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
        

        #region [ 기타 컨트롤 이벤트 ]


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BtnQuery_Click(null, null);
        }

        #endregion
        

    }
}
