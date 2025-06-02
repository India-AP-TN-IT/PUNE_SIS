#region ▶ Description & History
/* 
 * 프로그램명 : PD40151 창고 재고 손망실 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-22    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *				2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>        
    /// </summary>
    public partial class PD40151 : AxCommonBaseControl
    {
        //private IPD40151 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40151";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40151()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPD40151>("PD", "PD40151.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
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

                this.grd01.Initialize();
                this.grd01.AllowEditing = true;
                
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 070, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD", "ALC");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 080, "LOTNO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 160, "재고상태", "INV_STATUS", "INV_STATUS");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "입고일자", "IN_READ_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "입고시간", "IN_READ_TIME", "RCV_TIME1");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "출고일자", "OUT_DATE", "OUT_DATE");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "공장", "PLANT", "PLANT");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "라인", "LINE", "LINE");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "SEQ NO", "SEQNO", "SEQNO");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_READ_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OUT_DATE");
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");

                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx01_LINECD.PopupTitle = "라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));   //라인코드
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                //this.cbo01_INSTALL_POS.DataBind("A7", true);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();
                this.cbo01_INSTALL_POS.DataBind(source2.Tables[0], this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명

                this._buttonsControl.BtnDownload.Visible = false;

                dtp01_INSPEC_SDATE.SetValue(DateTime.Now);
                this.SetRequired(lbl01_BIZNM2, lbl02_LINECD, lbl06_PROD_DATE);
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
                if (!this.IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("ALCCD", this.txt01_ALCCD.GetValue());
                paramSet.Add("SPRODDATE", dtp01_INSPEC_SDATE.GetDateText().Substring(0, 7) + "-01");
                paramSet.Add("EPRODDATE", dtp01_INSPEC_SDATE.GetDateText().Substring(0, 7) + "-31");
                paramSet.Add("LANG_SET", this.UserInfo.Language);               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet, "OUT_CURSOR");

                this.grd01.SetValue(source.Tables[0]);
                this.grd01.setAlternateRowStyle("ALCCD");
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
        
        #endregion

        #region [ 유효성 체크 ]
        private bool IsQueryValid()
        {
            try
            {
                //if (this.tabControl1.SelectedIndex == 0)
                //{
                //    if (cdx01_LINECD.ByteCount == 0)
                //    {
                //        //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                //        MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text); // this.GetLabel("LINECD"));
                //        return false;
                //    }
                //    //저장위치 필수 조건에서 제외함.2017-11-03
                //    //if (this.cdx01_STR_LOC.IsEmpty)
                //    //{
                //    //    //{0} 가(이) 입력되지 않았습니다.
                //    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_STR_LOC.Text);
                //    //    return false;
                //    //}
                //}
                //else if (this.tabControl1.SelectedIndex == 1)
                //{
                //    //if (cdx02_LINECD.ByteCount == 0)
                //    //{
                //    //    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                //    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LINECD.Text);  //this.GetLabel("LINECD"));
                //    //    return false;
                //    //}
                //}
                if (this.cdx01_LINECD.ByteCount == 0)
                {
                    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LINECD.Text); // this.GetLabel("LINECD"));
                    return false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        #endregion
    }
}
