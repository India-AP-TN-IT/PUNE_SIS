#region ▶ Description & History
/* 
 * 프로그램명 : PD30050 ALC 마스터 조회
 * 설      명 : 
 * 최초작성자 : 김선환
 * 최초작성일 : 2010-05-31 오전 11:02:35
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014-01-09    배명희     [#001] 조회조건 추가(시작일자, 고객사품목코드)
 *                                       [#002] 고객사ALC코드와 비교하기 기능 추가 
 *                                                  - CD0102와 비교해서 차이가 나는 아이템들은 붉은색 글자로 변경
 *                                                    (CORCD,BIZCD,VINCD,CUST_ITEMCD,WORK_DIR_DIV,ALCCD 기준으로 PARTNO가 차이나는 항목들)
 *                                       [#003] 그리드 더블클릭시 PM20031 프로그램 팝업 표시
 *              2014-01-15    배명희     [#004] 시작일자 조회조건 옵션으로 처리(체크박스 체크된 경우에만 날짜조건 적용되도록)                           
 *              2014-07-23    배명희     cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *                                       cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
 *              2014-10-14    진승모     다국어 적용
 *              2017-07~09    배명희     SIS 이관
 * 
 *  
 * 
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.SIS.CM.UI;


namespace Ax.SIS.PD.UI
{

    public partial class PD30050 : AxCommonBaseControl
    {
        //private IPD30050 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD30050";

        
        public PD30050()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD30050>("PM00", "PD30050.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
         
        }

        #region [ 초기화 작업 정의 ]

        private void PD30050_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;

                this.axDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "고객사모델", "MODELCD", "MODELCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "당사차종", "VINCD", "HANIL_VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "작업지시구분", "WORK_DIR_DIV", "WORK_DIR_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "고객사품목코드", "CUST_ITEMCD", "CUST_ITEMCD");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "대표ALC", "ALCCD_REP", "ALCCD_REP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "시작일자", "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "종료일자", "END_DATE", "END_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "USAGE", "USAGE", "USAGE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "BIZCD", "BIZCD", "BIZCD");  //[#002] CD0102 와 비교위해 컬럼 추가
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "CORCD", "CORCD", "CORCD");  //[#002] CD0102 와 비교위해 컬럼 추가

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CA", "WORK_DIR_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                CellStyle csRed = this.grd01.Styles.Add("csRed");
                csRed.ForeColor = Color.Red;

                CellStyle csDefault = this.grd01.Styles.Add("csDefault");
                csDefault.ForeColor = Color.Black;
 
                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);
             
                

                //[#004] 날짜 조건 설정.
                this.dte01_APPLY_BEG_DATE.Checked = false;
                this.dte01_APPLY_BEG_DATE.ShowCheckBox = true;
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
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue().ToString());
                
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("CUST_ITEMCD", this.txt01_CUST_ITEMCD.GetValue().ToString());  //[#001]거래처품목코드
                paramSet.Add("BEG_DATE", this.dte01_APPLY_BEG_DATE.Checked ? this.dte01_APPLY_BEG_DATE.GetDateText().ToString() : "");  //[#001]시작일자(>=) ,[#004] 체크된 경우에만 조건 적용

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                this.grd01.SetValue(source.Tables[0]);

                

                ShowDataCount(source);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                if (cdx01_VINCD.GetValue().ToString() == "" &&
                   txt01_PARTNO.GetValue().ToString() == "" && txt01_CUST_ITEMCD.GetValue().ToString() == "" )
                {
                    //MsgBox.Show("최소 1개이상의 조건을 입력해야 합니다.");
                    MsgCodeBox.Show("PD00-0100");
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion


       

        ////[#003] 선택한 데이터 PM20031화면 팝업으로 표시
        //private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (this.grd01.MouseRow >= this.grd01.Rows.Count || this.grd01.MouseRow < this.grd01.Rows.Fixed) return;

        //    try
        //    {

        //        int r = this.grd01.MouseRow;

        //        string ALCCD = this.grd01.GetValue(r, "ALCCD").ToString();
        //        string PARTNO = this.grd01.GetValue(r, "PARTNO").ToString();
        //        string WORK_DIR_DIV = this.grd01.GetValue(r, "WORK_DIR_DIV").ToString();
        //        string BEG_DATE = this.grd01.GetValue(r, "BEG_DATE").ToString();
        //        string END_DATE = this.grd01.GetValue(r, "END_DATE").ToString();
        //        string CUST_ITEMCD = this.grd01.GetValue(r, "CUST_ITEMCD").ToString();
        //        string USAGE = this.grd01.GetValue(r, "USAGE").ToString();
        //        string VINCD = this.grd01.GetValue(r, "VINCD").ToString();

        //        PD20031 pop = new PD20031(VINCD, WORK_DIR_DIV, CUST_ITEMCD, PARTNO, BEG_DATE, END_DATE, ALCCD, USAGE);
        //        this.ShowPopup(pop);
        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.Show(ex.Message);
        //    }
        //}
    }
}
    