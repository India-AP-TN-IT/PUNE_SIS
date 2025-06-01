
#region ▶ Description & History
/* 
 * 프로그램명 : PD30101 생산 PARTNO 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23      배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *                                         cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *                                         cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
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

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>생산PART-NO 조회</b>
    /// - 작 성 자 : 김선환<br />
    /// - 작 성 일 : 2010-05-18 오전 10:25:42<br />
    /// </summary>
    public partial class PD30101 : AxCommonBaseControl
    {
        //private IPD30101 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD30101";

        public PD30101()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD30101>("PM00", "PD30101.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
        }

        #region [ 초기화 작업 정의 ]

        private void PD30101_Load(object sender, EventArgs e)
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
                this.cbo01_SAUP.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "제품구분", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "사업부문", "ENTER_DEPT", "ENTER_DEPT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "품목", "ITEMCD", "ITEMCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "Type", "TYPECD", "TYPECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "LEVEL", "LEVCD", "LEVCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "도면승인일", "DRAW_APR_DATE", "DRAW_APR_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "EONO", "EONO", "EONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "경고라벨", "WARN_LEV_TYPE", "WARN_LEV_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "스피커", "SPEA_TYPE", "SPEA_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "안전재고", "SAF_INV_QTY", "SAF_INV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "반재품유형", "SEMI_DIV", "SEMI_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "LINECD", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "LINE명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "IMPACT PAD", "IMPACT_PAD", "IMPACT_PAD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "LHD/RHD구분", "LHD_RHD_DIV", "LHD_RHD_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "CPNL 구분", "CPNL_DIV", "CPNL_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "IMS 유무", "IMS_YN", "IMS_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "커튼타입", "CURTAIN_TYPE", "CURTAIN_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "수출구분", "EXPORT_DIV", "EXPORT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/HDL 타입", "INSIDE_HANDLE_TYPE", "INSIDE_HANDLE_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "통전유무", "ELECT_PASS_YN", "ELEC_PASS_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "I/HDL 하우징 컬러", "IHDL_HOUSG_COLOR", "IHDL_HOUSG_COLOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "암레스트타입", "AREST_EM_TYPE", "AREST_EM_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "가니쉬", "GARNISH", "GARNISH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "TWT SPKR 유무", "TWT_SPKR_YN", "TWT_SPKR_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "TWT SPKR 타입", "TWT_SPKR_TYPE", "TWT_SPKR_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "MID SPKR", "MID_SPKR_YN", "MID_SPKR_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "무드램프", "MOOD_LAMP_YN", "MOOD_LAMP_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "스피커그릴", "SPKR_GRILL", "SPKR_GRILL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "KEY COLOR", "KEY_COL", "KEY_COL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "맵포켓유무", "MAP_PKT_YN", "MAP_PKT_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "UPPR TRIM", "UPPR_TRIM_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "MIRROR COVER", "MIRROR_CVR_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "UPPR RAIL", "UPPR_RAIL_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "STR LOC", "STR LOC");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A0", "PRDT_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AO", "ENTER_DEPT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A5", "TYPECD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A6", "LEVCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A9", "WARN_LEV_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A8", "SPEA_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AP", "SEMI_DIV");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CD", "IMPACT_PAD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GD", "LHD_RHD_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GE", "CPNL_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GF", "CURTAIN_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GG", "EXPORT_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GH", "INSIDE_HANDLE_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GK", "AREST_EM_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GL", "GARNISH");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GM", "SPKR_GRILL");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GN", "TWT_SPKR_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GR", "UPPR_TRIM_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DRAW_APR_DATE");
                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);

                //this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3");
                //this.cdx01_VINCD.CodeParameterName = "CODE";
                //this.cdx01_VINCD.NameParameterName = "CODENAME";
                //this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.HEUserParameterSetValue("CLASS_ID", "A3");
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";
                //this.cdx01_VINCD.HEPopupHelper = new CM20011P1();
                //this.cdx01_VINCD.PopupTitle = "차종코드";
                //this.cdx01_VINCD.CodeParameterName = "VINCD";
                //this.cdx01_VINCD.NameParameterName = "VINCDNM";
                //this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";

                this.cdx01_ITEMCD.HEPopupHelper = new CM30010P1("A4", true, true, this.cdx01_ITEMCD);
                
                //this.cdx01_ITEMCD.HEPopupHelper = new CM30010P1("A4");
                //this.cdx01_ITEMCD.CodeParameterName = "CODE";
                //this.cdx01_ITEMCD.NameParameterName = "CODENAME";
                //this.cdx01_ITEMCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_ITEMCD.HEUserParameterSetValue("CLASS_ID", "A4");
                //this.cdx01_ITEMCD.SetCodePixedLength();
                //this.cdx01_ITEMCD.PrefixCode = "A4";
                //this.cdx01_ITEMCD.HEPopupHelper = new CM20011P2();
                //this.cdx01_ITEMCD.PopupTitle = "품목코드";
                //this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                //this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                //this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx01_ITEMCD.SetCodePixedLength();
                //this.cdx01_ITEMCD.PrefixCode = "A4";

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx01_LINECD.PopupTitle = "대표 라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");

                cbo01_PRDT_DIV.DataBind("A0", true);
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
                if (!this.IsQueryValid())
                    return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_SAUP.GetValue().ToString());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue().ToString());
                paramSet.Add("ITEMCD", this.cdx01_ITEMCD.GetValue().ToString());
                paramSet.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("ALCCD", this.txt01_ALCCD.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void cdx01_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsQueryValid()
        {
            try
            {
                if(this.cdx01_VINCD.ByteCount    == 0 &&
                   this.cdx01_ITEMCD.ByteCount   == 0 &&
                   this.cbo01_PRDT_DIV.ByteCount == 0 &&
                   this.cdx01_LINECD.ByteCount   == 0 &&
                   this.txt01_PARTNO.ByteCount   == 0 &&
                   this.txt01_ALCCD.ByteCount    == 0)
                {
                    //MsgBox.Show("검색조건을 입력하지 않았습니다. 하나 이상의 검색 조건을 입력하십시오.");
                    MsgCodeBox.Show("PD00-0070");
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
    }
}
