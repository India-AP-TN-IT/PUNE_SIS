#region ▶ Description & History
/* 
 * 프로그램명 : PD35330 공수일지 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2015-09-24    오세민   
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;

namespace Ax.SIS.PD.UI
{
    public partial class PD35330 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD35330";
        public PD35330()
        {
            InitializeComponent();
            //_WSCOM = new AxClientProxy("HANILDEV");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                
                //this.grd01.AllowEditing = false;
                //this.grd01.Initialize(1,1, false);
                this.grd01.Initialize();
                this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange;
                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "원소속라인", "LINECD", "LINE4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "SHIFT", "SHIFT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "사번", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "이름", "NAME_KOR", "HR_NAME");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "출근", "TM_START", "ATTEND");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "퇴근", "TM_CLOSE", "QUITT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "실출근", "ATTEN_TIME","ATTEND2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "실퇴근", "QUITT_TIME", "QUITT2");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "작업라인", "WORK_LINECD", "WORK_LINENM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "작업구분", "WORK_DIV", "WORK_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업명", "WORK_DIVNM", "WORK_NAME");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "시작시간", "BEG_HHMM", "BEG_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "종료시간", "END_HHMM", "END_TIME");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "정취시간", "WORK_TIME", "ATN_QUITT_TM_A10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "연장시간", "EXTRA_TIME", "EXTN_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "사고시간", "NON_TIME", "NON_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "실근무시간", "REAL_WORK_TIME", "REAL_WORK_TIME");
                

                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "REAL_WORK_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "EXTRA_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "NON_TIME");
                this.grd01.Cols["REAL_WORK_TIME"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["WORK_TIME"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["EXTRA_TIME"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["NON_TIME"].Format = "#,###,###,###,###,##0";

                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "EI", "SHIFT");
                

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new ZZPM25110P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_WORKDATE2);
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
            this.grd01.InitializeDataSource();            
            
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                string procedure = this.chk01_LINE_SUM.Checked ? "INQUERY_SUMMARY" : "INQUERY";
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, procedure), paramSet);
                this.AfterInvokeServer();

                BtnReset_Click(null, null);

                grd01.MergedRanges.Clear();
                this.grd01.SetValue(source.Tables[0]);

                if (this.chk01_LINE_SUM.Checked)
                {
                    //라인별 합계 조회시
                    string[] labels = new string[] { "Sub Total", "Mid Total", "Total"};
                    grd01.setSumStyle(3, this.grd01.Cols["EMPNO"].Index, AxFlexGrid.eSumStyle.RowColMode, labels);
                }
                else
                {
                    grd01.setSumStyle(4, this.grd01.Cols["EMPNO"].Index, AxFlexGrid.eSumStyle.RowColMode);
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

        #region [ 유효성 검사 ]

        #endregion

        #region [ 기타 이벤트 정의 ]
        
        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }
        
        #endregion

        #region [ 사용자 정의 메서드 ] 
        
        private void SetGridMerge()
        {
            this.grd01.AddMerge(0, 0, "WORK_TIME", "STOP_TOTAL");
            this.grd01.SetHeadTitle(0, "WORK_TIME", this.GetLabel("WORK_TIME_MIN")); //"가동공수/MIN");

            this.grd01.AddMerge(0, 2, "DIRE_DIV", "DIRE_DIV");
            this.grd01.AddMerge(0, 2, "WORK_DIV", "WORK_DIV");

            this.grd01.AddMerge(1, 1, "WORK_TIME", "WORK_TIME2");
            this.grd01.SetHeadTitle(1, "WORK_TIME", this.GetLabel("WORK_TIME2"));// "취업공수");
            this.grd01.AddMerge(1, 2, "WORK_TOTAL", "WORK_TOTAL");
            this.grd01.SetHeadTitle(1, "WORK_TOTAL", this.GetLabel("TOT2")); //"계");

            this.grd01.AddMerge(1, 1, "STOP_TIME1", "STOP_TIME6");
            this.grd01.SetHeadTitle(1, "STOP_TIME1", this.GetLabel("STOP_TIME1"));// "비가동공수");
            this.grd01.AddMerge(1, 2, "STOP_TOTAL", "STOP_TOTAL");
            this.grd01.SetHeadTitle(1, "STOP_TOTAL", this.GetLabel("TOT2")); //"계");

            this.grd01.AddMerge(0, 2, "TOTAL1", "TOTAL1");
            this.grd01.AddMerge(0, 2, "RUN_TIME", "RUN_TIME");
            this.grd01.AddMerge(0, 2, "RUN_TIME2", "RUN_TIME2");

        }
        
        #endregion

    }
}
