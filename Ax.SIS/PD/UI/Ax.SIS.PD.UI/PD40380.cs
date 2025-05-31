#region ▶ Description & History
/* 
 * 프로그램명 : PD40380 통전검사 이력조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2013-09-04              #001 사업장, 검사일자, 라인코드 필수입력 표시 & 조회시 필수입력 체크 로직 추가.
 *				2017-07~09    배명희     SIS 이관
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
    /// 통전검사 이력 조회
    /// </summary>
    public partial class PD40380 : AxCommonBaseControl
    {
        //private IPD40380 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40380";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40380()
        {
            InitializeComponent();

            //_WSCOM  = ClientFactory.CreateChannel<IPD40380>("PD", "PD40380_N.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40380>("PD", "PD40380.svc", "CustomBinding");

                //}
                //else
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40380>("PD", "PD40380_N.svc", "CustomBinding");
                //}
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "검사횟수", "INSPEC_CNT", "INSPEC_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "검사결과", "RSLT_INSPEC", "INSPECT_RSLT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "실적일자", "RSLT_DATE", "RSLT_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "검사코드", "INSPECCD", "INSPECCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "통전 항목명", "ET_DESC", "ET_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "순서", "WORK_CNT", "WORK_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "SHIFT", "SHIFT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "결과", "RESULT", "RESULT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "검사자", "EMPNO", "WORKER_NM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사자명", "EMPNM", "WORKER_NAME");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "A0A");

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();
                this.cbl01_INSTALL_POS.DataBind(source1.Tables[0], this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명

                this.SetRequired(lbl01_BIZNM2, lbl02_INSPECT_DATE, lbl03_LINE);  //#001 필수입력 표시
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
                if (!this.IsQueryValid()) return;   //조회시 필수입력 체크 로직 추가

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("BEG_INSPEC_DATE", this.dtp01_BEG_INSPEC_DATE.GetDateText());
                set.Add("END_INSPEC_DATE", this.dtp01_END_INSPEC_DATE.GetDateText());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.grd01.SetValue(source);
                this.grd02.InitializeDataSource();
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

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                this.cbl01_LINECD.DataBind(source1.Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                
                string CORCD = this.UserInfo.CorporationCode;
                string BIZCD = bizcd;
                string LINECD = this.grd01.GetValue(row, "LINECD").ToString();
                string LOTNO = this.grd01.GetValue(row, "LOTNO").ToString();


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("LINECD", LINECD);
                set.Add("LOTNO", LOTNO);

                //DataSet source = _WSCOM.INQUERY_DETAIL(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR");

                this.grd02.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion


        #region [ 유효성 체크 ]
        
        //#001 조회시 필수입력 체크 로직 추가
        private bool IsQueryValid()
        {
            if (this.cbo01_BIZCD.GetValue().ToString().Length == 0)
            {
                //MsgBox.Show("사업장을 선택하세요.");
                MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("BIZNM2"));
                return false;
            }

            if (this.dtp01_BEG_INSPEC_DATE.GetDateText().ToString().Length == 0)
            {
                //MsgBox.Show("검사일자 시작일을 선택하세요.");
                MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("INSPECT_DATE"));
                return false;
            }

            if (this.dtp01_END_INSPEC_DATE.GetDateText().ToString().Length == 0)
            {
                //MsgBox.Show("검사일자 종료일을 선택하세요.");
                MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("INSPECT_DATE"));
                return false;
            }

            if (this.cbl01_LINECD.GetValue().ToString().Length == 0)
            {
                //MsgBox.Show("라인코드를 선택하세요.");
                MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINECD"));
                return false;
            }
            return true;
        }
        
        #endregion
    }
}
