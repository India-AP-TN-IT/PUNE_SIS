#region ▶ Description & History
/* 
 * 프로그램명 : PD40510 금형타발실적 조회
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
    /// 통전검사 이력 조회
    /// </summary>
    public partial class PD40510 : AxCommonBaseControl
    {
        //private IPD40510 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40510";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        #region [ 초기화 작업 정의 ]

        public PD40510()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD40510>("PD", "PD40510.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "실적일자", "IN_DATE", "RSLT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 200, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "금형명", "MOLDNM", "MOLDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "CAVITY", "CAVITY", "CAVITY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "타발수", "SHOTCNT", "SHOTCNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "차종코드", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM");                

                this.grd01.Cols["LINECD"].AllowMerging = true;
                this.grd01.Cols["IN_DATE"].AllowMerging = true;
                this.grd01.Cols["MOLDNO"].AllowMerging = true;
                this.grd01.Cols["MOLDNM"].AllowMerging = true;
                this.grd01.Cols["CAVITY"].AllowMerging = true;
                this.grd01.Cols["VINCD"].AllowMerging = true;
                this.grd01.Cols["SHOTCNT"].AllowMerging = true;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SHOTCNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CAVITY");
                /*
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, HEFlexGrid.FtextAlign.C, 100, "LOT NO", "LOTNO");
                this.grd02.AddColumn(true, true, HEFlexGrid.FtextAlign.L, 120, "품번", "PARTNO");
                */
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
                //this.cbl01_INSTALL_POS.DataBind(source1.Tables[0], "타입코드;타입명", "C;L");

                this.cbl01_INSTALL_POS.DataBind(source1.Tables[0], GetLabel("TYPE_CD") + ";" + GetLabel("TYPE_NM"), "C;L");

                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                String region = "";

                if (bizcd == "5220")
                {
                    region = "A02";
                }
                else if(bizcd == "5210")
                {
                    region = "A01";
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("IN_DATE", this.dtp01_BEG_INSPEC_DATE.GetDateText());
                set.Add("IN_DATE2", this.dtp01_END_INSPEC_DATE.GetDateText());
                set.Add("MOLDNO", this.txt01_MOLDNO.GetValue());
                set.Add("REGION", region);
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");


                this.grd01.SetValue(source);
                //this.grd02.InitializeDataSource();
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

                //this.cbl01_LINECD.DataBind(source1.Tables[0], "라인코드;라인명", "C;L");
                this.cbl01_LINECD.DataBind(source1.Tables[0], GetLabel("LINECD")+";"+GetLabel("LINENM"), "C;L");
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
                /*
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                
                string CORCD = this.UserInfo.CorporationCode;
                string BIZCD = bizcd;
                string LINECD = this.grd01.GetValue(row, "LINECD").ToString();
                string MOLDNO = this.grd01.GetValue(row, "MOLDNO").ToString();
                string IN_DATE = this.grd01.GetValue(row, "IN_DATE").ToString();
                string PARTNO = this.grd01.GetValue(row, "PARTNO").ToString();


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("LINECD", LINECD);
                set.Add("MOLDNO", MOLDNO);
                set.Add("IN_DATE", IN_DATE);
                set.Add("PARTNO", PARTNO);

                DataSet source = _WSCOM.INQUERY_DETAIL(bizcd, set);

                this.grd02.SetValue(source);
                 */
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
