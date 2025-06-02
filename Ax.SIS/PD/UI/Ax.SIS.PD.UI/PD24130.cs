#region ▶ Description & History
/* 
 * 프로그램명 : 완제품 실사 창고재고 초기화
 * 설      명 : 라인별 장착위치 기준으로 재고 초기화
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 진승모
 * 최종수정일 : 2014-10-13
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2013-12-11	  오세민		장착위치 구분 추가
 *				
 * 1. 2013-12-11 기본 라인별 초기화 였으나 아산에 김학수SW, 박재만DR 요청으로 장착위치 기준으로 부분 실사 기능 요청
 * 
 *              2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2014-10-13    진승모     다국어 적용
 *              2017-07~09    배명희     SIS 이관              
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>완제품 실사 창고재고 초기화 프로그램 클래스</b>
    /// </summary>
    public partial class PD24130 : AxCommonBaseControl
    {
        //private IPM24130 _WSCOM;
        private string PACKAGE_NAME = "APG_PD24130";
        public PD24130()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPM24130>("PM04", "PM24130.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// Shown 이벤트를 통해 초기화 작업을 수행한다.
        /// </summary>
        /// <param name="sender">객체</param>
        /// <param name="e">이벤트</param>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.grd01.Initialize();
                this.grd01.AllowEditing = false;

                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 080, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "저장위치", "STR_LOC", "STR_LOC");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 090, "적재위치", "LODTBL_NO", "LOAD_LOC");                
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 080, "수량", "QTY", "QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetStrLoc(), "STR_LOC");
                this.grd01.Cols["QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.cdx01_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", System.DateTime.Now.ToString("yyyy-MM-dd"));  //디폴트 현재날짜 넘김.(2013-05-30)
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                ////HE.ERM.PM.PM02.UI.PM22110P frm = new HE.ERM.PM.PM02.UI.PM22110P();
                ////this.cdx01_LINECD.HEPopupHelper = frm;
                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx01_LINECD.PopupTitle = "라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", System.DateTime.Now.ToString("yyyy-MM-dd"));  //디폴트 현재날짜 넘김.(2013-05-30)

                this.cbo01_INSTALL_POS.DataBind("A7");


                this.cdx01_STR_LOC.HEPopupHelper = new CM30040P1(); //new PM20015P1();
                this.cdx01_STR_LOC.PopupTitle = this.GetLabel("STR_LOC");
                this.cdx01_STR_LOC.CodeParameterName = "STR_LOC";
                this.cdx01_STR_LOC.NameParameterName = "STR_LOCNM";
                this.cdx01_STR_LOC.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_STR_LOC.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_LINECD);
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
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());                
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString().Length > 0 ? this.cbo01_INSTALL_POS.GetValue().ToString().Substring(2) : this.cbo01_INSTALL_POS.GetValue());
                paramSet.Add("STR_LOC", this.cdx01_STR_LOC.GetValue());
                paramSet.Add("LODTBL_NO", this.cbo01_LODTBL_NO.GetValue());
                this.BeforeInvokeServer(true);
                DataSet source;
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                }
                //DataSet source = _WSCOM.Inquery(paramSet, this.cbo01_BIZCD.GetValue().ToString());
                
                //사업장에 따라 저장위치 다르므로, 조회시 그리드 콤보 다시 바인딩함.
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetStrLoc(), "STR_LOC");

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

        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {                
                if(axTextBox1.Text != DateTime.Now.ToString("ddMM"))
                {
                    MsgBox.Show("Password Error!!", "Error");
                    return;
                }
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString().Length > 0 ? this.cbo01_INSTALL_POS.GetValue().ToString().Substring(2) : this.cbo01_INSTALL_POS.GetValue());
                paramSet.Add("STR_LOC", this.cdx01_STR_LOC.GetValue());
                paramSet.Add("LODTBL_NO", this.cbo01_LODTBL_NO.GetValue());
                if (!IsProcess(paramSet)) return;

                this.BeforeInvokeServer(true);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROCESS"), paramSet);
                }
                this.AfterInvokeServer(); 
                #region "기존코드"
                //_WSCOM.Process(paramSet, this.cbo01_BIZCD.GetValue().ToString());

                ////MES Oracle용(울산만 적용)
                //if (this.cbo01_BIZCD.GetValue().Equals("5210"))
                //    _WSCOM.Process2(paramSet);
                
                #endregion

                //MsgBox.Show("창고 재고를 정리가 정상적으로 처리 되었습니다.");
                MsgCodeBox.Show("CD00-0013");
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

        private bool IsProcess(HEParameterSet set)
        {
            //if (MsgBox.Show("완제품 실사용 창고재고 정리를 처리하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0021", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;
            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }
                
        //2013-05-30 완/반제품 구분 선택 추가
        private void rdo01_PRDT_DIV_A_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo01_PRDT_DIV_A.Checked)
            {
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");   //완제품
            }
            else
            {
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");   //반제품
            }
        }

        //저장위치
        private void cdx01_STR_LOC_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //라인코드 입력시 해당 적재위치를 콤보상자에 표시한다.(코드 입력)
        private void cdx01_LINECD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.SetComboLODTBL_NO(this.cdx01_LINECD.GetValue().ToString());
        }

        //라인코드 입력시 해당 적재위치를 콤보상자에 표시한다.(팝업에서 선택)
        private void cdx01_LINECD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.SetComboLODTBL_NO(this.cdx01_LINECD.GetValue().ToString());
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        /// <summary>
        /// 저장위치 목록 조회(콤보상자용)
        /// </summary>
        /// <returns></returns>
        private DataTable GetStrLoc()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("STR_LOC", string.Empty);
                set.Add("STR_LOCNM", string.Empty);
                set.Add("LANG_SET", this.UserInfo.Language);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet("APG_CM30040.INQUERY", set);
                    source.Tables[0].Columns["STR_LOC"].SetOrdinal(0);
                    source.Tables[0].Columns["STR_LOCNM"].SetOrdinal(1);
                    return source.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //라인코드에 해당하는 적재위치 조회(FROM MES2011)
        private void SetComboLODTBL_NO(string linecd)
        {
            if (linecd.Equals(string.Empty))
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("LODTBL_NO", "LODTBL_NM");
                this.cbo01_LODTBL_NO.DataBind(source.Tables[0], true);
                //this.cbo01_LODTBL_NO.InitializeDataSource();                
            }
            else
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("LINECD", linecd);
                DataSet source = new DataSet();
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LODTBL_NO"), set);
                }
                this.cbo01_LODTBL_NO.DataBind(source.Tables[0], true);


            }
        }

        #endregion


    }
}
