#region ▶ Description & History
/* 
 * 프로그램명 : PD20101 생산 PART-NO 정보 관리
 * 설     명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2012-06-12
 * 최종수정자 :
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2012-06-12	    오세민		최초 개발
 *				2014-07-22      배명희      cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *				2014-07-23      배명희      cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *				                            cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
 *			    2017-07~09   배명희      SIS 이관(구.PM20015)
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// <b>생산 PART-NO 정보 관리</b>
    /// </summary>
    public partial class PD20101 : AxCommonBaseControl
    {
        //private IPM20015 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD20101";
        private string _CORCD = "";
        private string _BIZCD = "";

        public PD20101()
        {
            InitializeComponent();

           //_WSCOM = ClientFactory.CreateChannel<IPM20015>("PM00", "PM20015.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

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

                /* Note : 유형코드 정리
                 *  0.  A0 : 제품구분     ( PRDT_DIV )
                 *  1.  A2 : 내외작구분   ( MIPV_DIV )
                 *  2.  AO : 사업부구분   ( ENTER_DEPT )
                 *  3.  A3 : 차종코드     ( VINCD )
                 *  4.  A4 : 품목코드     ( ITEMCD )
                 *  5.  A7 : 장착위치     ( INSTALL_POS )
                 *  6.  A9 : 경고라벨타입 ( WARN_LEV_TYPE )
                 *  7.  A8 : 스피커타입   ( SPEA_TYPE )
                 *  8.  A6 : 레벨코드     ( LEVCD )
                 *  9.  AP : 반제품유형   ( SEMI_DIV )
                 *  10. AQ : 단위         ( UNIT ) */

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNONM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "제품구분", "PRDT_DIV", "PRDTDIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "내외작구분", "MIPV_DIV", "MIPV_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "사업부", "ENTER_DEPT", "ENTERDEPT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "품목", "ITEMCD", "ITEM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "위치코드", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "Type", "TYPECD", "CTYPE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "도면승인일자", "DRAW_APR_DATE", "DRAW_APR_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "EO No", "EONO", "EONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "중량", "WEIGHT", "CASE_WEIGHT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "부품 Size", "PART_SIZE", "PART_SIZE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "단위", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "Trans", "TRANS", "TRANS2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "등록자", "INSERT_ID", "REG_EMP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "등록일시", "INSERT_DATE", "REG_DATETIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "수정자", "UPDATE_ID", "AMD_EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "수정일시", "UPDATE_DATE", "UPDATE_DATE2");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A0", "PRDT_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A2", "MIPV_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AO", "ENTER_DEPT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A5", "TYPECD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AQ", "UNIT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DRAW_APR_DATE");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNOTITLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNONM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "라인코드", "LINECD", "LINECD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 120, "안전재고수량", "SAF_INV_QTY", "SAF_INV_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "ALC CODE", "ALCCD", "ALCCODE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "경고라벨타입", "WARN_LEV_TYPE", "WARN_LEV_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "스피커타입", "SPEA_TYPE", "SPEA_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "반제품유형", "SEMI_DIV", "SEMI_DIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적용시작일", "BEG_DATE", "APPLY_BEG_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적용종료일", "END_DATE", "APPLY_END_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "물류용기코드", "LOGICD", "LOG_CONTCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "레벨코드", "LEVCD", "LEVELCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 090, "Impact Pad", "IMPACT_PAD", "IMPACT_PAD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 090, "AREA", "AREA", "AREA");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LHD/RHD구분", "LHD_RHD_DIV", "LHD_RHD_DIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "C/PNL사양구분", "CPNL_DIV", "CPNL_DIV");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "C/PNL 색상", "CPNL_COLOR", "CPNL_COLOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "IMS유무", "IMS_YN", "IMS_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "커튼사양", "CURTAIN_TYPE", "CURTAIN_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "수출구분", "EXPORT_DIV", "EXPORT_DIV");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "인사이드핸들", "INSIDE_HANDLE_TYPE", "INSIDE_HANDLE_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "통전검사패스", "ELEC_PASS_YN", "ELEC_PASS_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "A/REST엠블렘사양", "AREST_EM_TYPE", "AREST_EM_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "A/REST 색상", "AREST_STITCH_COLOR", "AREST_STITCH_COLOR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "I/HDL HOUS'G 색상", "IHDL_HOUSG_COLOR", "IHDL_HOUSG_COLOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "GARNISH", "GARNISH", "GARNISH");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "GARNISH 색상", "GARNISH_COLOR", "GARNISH_COLOR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "TWT SPKR유무", "TWT_SPKR_YN", "TWT_SPKR_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "TWT SPKR 타입", "TWT_SPKR_TYPE", "TWT_SPKR_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "MID SPKR유무", "MID_SPKR_YN", "MID_SPKR_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "무드램프", "MOOD_LAMP_YN", "MOOD_LAMP_YN");
              //  this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 180, "무드램프", "FOOT_LAMP_YN", "FOOT_LAMP_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "SPKR GRILL", "SPKR_GRILL", "SPKR_GRILL");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "KEY COLOR", "KEY_COL", "KEY_COL");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "맵포켓유무", "MAP_PKT_YN", "MAP_PKT_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "UPPR TRIM", "UPPR_TRIM_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "UPPR 색상", "UPPR_TRIM_COLOR", "UPPR_TRIM_COLOR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "MIRROR COVER", "MIRROR_CVR_YN", "MIRROR_COVER_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "UPPR RAIL", "UPPR_RAIL_YN", "UPPR_RAIL_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "STR LOC", "STR_LOC", "STR_LOC");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 180, "품번단위수량", "UNIT_QTY", "UNIT_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "BUMPER GRILL", "BPR_GRILL", "BPR_GRILL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "BUMPER LAMP", "BPR_LAMP", "BPR_LAMP");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "BUMPER PIER", "BPR_PIER", "BPR_PIER");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "TYPE", "TYPE", "TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "CAMERA", "CAMERA", "CAMERA");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "R/GRILL", "RGRILL", "RGRILL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "SWITCH", "SWITCH", "SWITCH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "ARM_REST", "ARM_REST", "ARM_REST");
                             
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "등록자", "INSERT_ID", "REG_EMP");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "등록일시", "INSERT_DATE", "REG_DATETIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "수정자", "UPDATE_ID", "AMD_EMPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "수정일시", "UPDATE_DATE", "UPDATE_DATE2");                

                this.grd02.AddHiddenColumn("CORCD");
                this.grd02.AddHiddenColumn("BIZCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A9", "WARN_LEV_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A8", "SPEA_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AP", "SEMI_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A6", "LEVCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CD", "IMPACT_PAD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GS", "CPNL_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GT", "GARNISH_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GU", "UPPR_TRIM_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GV", "AREST_STITCH_COLOR");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.cbo01_PRDT_DIV.DataBind("A0");
                this.cbo01_INSTALL_POS.DataBind("A7");
                this.cbo01_WARN_LEV_TYPE.DataBind("A9");
                this.cbo01_SPEA_TYPE.DataBind("A8");
                this.cbo01_LEVELCD.DataBind("A6");
                this.cbo01_SEMI_DIV.DataBind("AP");
                this.cbo01_IMPACT_PAD.DataBind("CD");
                this.cbo01_LHD_RHD_DIV.DataBind("GD");
                this.cbo01_CPNL_DIV.DataBind("GE");
                this.cbo01_CURTAIN_TYPE.DataBind("GF");
                this.cbo01_EXPORT_DIV.DataBind("GG");
                this.cbo01_INSIDE_HANDLE_TYPE.DataBind("GH");
                this.cbo01_AREST_EM_TYPE.DataBind("GK");
                this.cbo01_IHDL_HOUSG_COLOR.DataBind("GJ");
                this.cbo01_GARNISH.DataBind("GL");
                this.cbo01_SPKR_GRILL.DataBind("GM");
                this.cbo01_TWT_SPKR_TYPE.DataBind("GN");
                this.cbo01_UPPR_TRIM_TYPE.DataBind("GR");
                this.cbo01_CPNL_COLOR.DataBind("GS");
                this.cbo01_GARNISH_COLOR.DataBind("GT");
                this.cbo01_UPPR_TRIM_COLOR.DataBind("GU");
                this.cbo01_AREST_STITCH_COLOR.DataBind("GV");
                this.cbo01_GRILL.DataBind("GY");
                this.cbo01_LAMP.DataBind("GW");
                this.cbo01_TYPE.DataBind("YA");
                this.cbo01_CAMERA.DataBind("YB");
                this.cbo01_RGRILL.DataBind("YC");
                this.cbo01_SWITCH.DataBind("YD");
                this.cbo01_ARM_RST.DataBind("AR");
                
                DataSet ds01 = this.GetDataSourceSchema("Code", "CodeValue");
                ds01.Tables[0].Rows.Add("N", "Non IMS");
                ds01.Tables[0].Rows.Add("Y", "IMS");
                this.cbo01_IMS_YN.DataBind(ds01.Tables[0], true);

                DataSet ds02 = this.GetDataSourceSchema("Code", "CodeValue");                
                ds02.Tables[0].Rows.Add("Y",this.GetLabel("EXIST")); // "유");
                ds02.Tables[0].Rows.Add("N", this.GetLabel("NOT_EXIST"));// "무");
                this.cbo01_TWT_SPKR_YN.DataBind(ds02.Tables[0], true);
                this.cbo01_MID_SPKR_YN.DataBind(ds02.Tables[0], true);
                this.cbo01_MOOD_LAMP_YN.DataBind(ds02.Tables[0], true);
               // this.cbo01_FOOT_LAMP_YN.DataBind(ds02.Tables[0], true);
                this.cbo01_MAP_PKT_YN.DataBind(ds02.Tables[0], true);
                this.cbo01_MIRROR_CVR_YN.DataBind(ds02.Tables[0], true);
                this.cbo01_UPPR_RAIL_YN.DataBind(ds02.Tables[0], true);
                this.cbo01_BPR_PIER.DataBind(ds02.Tables[0], true);

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);

                //this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3");
                //this.cdx01_VINCD.CodeParameterName = "CODE";
                //this.cdx01_VINCD.NameParameterName = "CODENAME";
                //this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.HEUserParameterSetValue("CLASS_ID", "A3");
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";
                //this.cdx01_VINCD.HEPopupHelper = new CM20011P1();//new PM20011P1();
                //this.cdx01_VINCD.PopupTitle         = "차종코드";
                //this.cdx01_VINCD.CodeParameterName  = "VINCD";
                //this.cdx01_VINCD.NameParameterName  = "VINCDNM";
                //this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
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
                //this.cdx01_ITEMCD.HEPopupHelper = new CM20011P2(); //new PM20011P2();
                //this.cdx01_ITEMCD.PopupTitle        = "품목코드";
                //this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                //this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                //this.cdx01_ITEMCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_ITEMCD.SetCodePixedLength();
                //this.cdx01_ITEMCD.PrefixCode = "A4";

                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1(); //new PM20015P1();
                //this.cdx01_LINECD.PopupTitle        = "대표 라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD",    this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD",    this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                //this.cdx01_LINECD.SetCodePixedLength();


                //this.cdx01_LINECD.HEPopupHelper = new CM30010P1("AD4", true, true, this.cdx01_LINECD);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("REP_LINECD"));//"대표 라인코드"); //new PM20015P1()
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                this.cdx01_LINECD.SetCodePixedLength();

                this.txt02_PARTNO.SetReadOnly(true);
                this.txt01_PARTNM.SetReadOnly(true);

                this.dtp01_END_DATE.SetFromEnd();

                this.SetRequired(this.lbl02_PARTNOTITLE, this.lbl01_LINECD);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema
                (
                    "CORCD",         "BIZCD",     "PARTNO", "SAF_INV_QTY", "LINECD",    
                    "BEG_DATE",      "END_DATE",  "ALCCD",  "SEMI_DIV",    "LEVCD",
                    "WARN_LEV_TYPE", "SPEA_TYPE", "LOGICD", "IMPACT_PAD", "AREA",
                    "LHD_RHD_DIV", "CPNL_DIV", "IMS_YN", "CURTAIN_TYPE", "EXPORT_DIV",
                    "INSIDE_HANDLE_TYPE", "ELEC_PASS_YN", "USER_ID", "IHDL_HOUSG_COLOR",
                    "AREST_EM_TYPE", "GARNISH", "TWT_SPKR_YN", "MID_SPKR_YN", "MOOD_LAMP_YN", //"FOOT_LAMP_YN",
                    "SPKR_GRILL", "KEY_COL", "MAP_PKT_YN","TWT_SPKR_TYPE","UPPR_TRIM_TYPE",
                    "MIRROR_CVR_YN", "UPPR_RAIL_YN", "CPNL_COLOR", "GARNISH_COLOR", "UPPR_TRIM_COLOR", 
                    "AREST_STITCH_COLOR", "UNIT_QTY", "BPR_GRILL", "BPR_LAMP", "BPR_PIER", "TYPE", "CAMERA", "RGRILL", "SWITCH","ARM_REST"
                );

                if (_CORCD.Length == 0 || _BIZCD.Length == 0)
                {
                    _CORCD = this.UserInfo.CorporationCode;
                    _BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                }

                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.txt02_PARTNO.GetValue(),
                    this.NME01_SAF_INV_QTY.GetDBValue(),
                    this.cdx01_LINECD.GetValue(),
                    this.dtp01_BEG_DATE.GetDateText(),
                    this.dtp01_END_DATE.GetDateText(),
                    this.txt01_ALCCD.GetValue(),
                    this.cbo01_SEMI_DIV.GetValue(),
                    this.cbo01_LEVELCD.GetValue(),
                    this.cbo01_WARN_LEV_TYPE.GetValue(),
                    this.cbo01_SPEA_TYPE.GetValue(),
                    this.txt01_LOG_CONTCD.GetValue(),
                    this.cbo01_IMPACT_PAD.GetValue(),
                    this.txt01_AREA.GetValue(),
                    this.cbo01_LHD_RHD_DIV.GetValue(),
                    this.cbo01_CPNL_DIV.GetValue(),
                    this.cbo01_IMS_YN.GetValue(),
                    this.cbo01_CURTAIN_TYPE.GetValue(),
                    this.cbo01_EXPORT_DIV.GetValue(),
                    this.cbo01_INSIDE_HANDLE_TYPE.GetValue(),
                    this.chk01_ELEC_PASS_YN.Checked ? "Y" : "N",
                    this.UserInfo.EmpNo,
                    this.cbo01_IHDL_HOUSG_COLOR.GetValue(),
                    this.cbo01_AREST_EM_TYPE.GetValue(),
                    this.cbo01_GARNISH.GetValue(),
                    this.cbo01_TWT_SPKR_YN.GetValue(),
                    this.cbo01_MID_SPKR_YN.GetValue(),
                    this.cbo01_MOOD_LAMP_YN.GetValue(),
                  //  this.cbo01_FOOT_LAMP_YN.GetValue(),
                    this.cbo01_SPKR_GRILL.GetValue(),            //2013.11.29 spkr_grill 누락건 추가함.
                    this.txt01_KEY_COL.GetValue(),
                    this.cbo01_MAP_PKT_YN.GetValue(),
                    this.cbo01_TWT_SPKR_TYPE.GetValue(),
                    this.cbo01_UPPR_TRIM_TYPE.GetValue(),
                    this.cbo01_MIRROR_CVR_YN.GetValue(),
                    this.cbo01_UPPR_RAIL_YN.GetValue(),
                    this.cbo01_CPNL_COLOR.GetValue(),
                    this.cbo01_GARNISH_COLOR.GetValue(),
                    this.cbo01_UPPR_TRIM_COLOR.GetValue(),
                    this.cbo01_AREST_STITCH_COLOR.GetValue(),
                    this.NME01_UNIT_QTY.GetDBValue(),
                    this.cbo01_GRILL.GetValue(),
                    this.cbo01_LAMP.GetValue(),
                    this.cbo01_BPR_PIER.GetValue(),
                    this.cbo01_TYPE.GetValue(),
                    this.cbo01_CAMERA.GetValue(),
                    this.cbo01_RGRILL.GetValue(),
                    this.cbo01_SWITCH.GetValue(),
                    this.cbo01_ARM_RST.GetValue()

                );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                //this.BeforeInvokeServer(true);
                //_WSCOM.Save_MES(source);
                //this.AfterInvokeServer();

                this.grd01_DoubleClick(null, null);

                //메세지 코드 처리
                //MsgBox.Show("입력하신 PART-NO 정보가 저장되었습니다");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema
                (
                    "PARTNO", 
                    "BIZCD", 
                    "CORCD"
                );
                source.Tables[0].Rows.Add
                (
                    this.txt02_PARTNO.GetValue(), 
                    _BIZCD, 
                    _CORCD
                );

                if (!this.IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.grd01_DoubleClick(null, null);

                //메세지 코드 처리
                //MsgBox.Show("선택하신 PART-NO 정보가 삭제되었습니다");
                MsgCodeBox.Show("CD00-0072");
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsInqueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("VINCD",       this.cdx01_VINCD.GetValue().ToString());
                paramSet.Add("ITEMCD",      this.cdx01_ITEMCD.GetValue().ToString());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());
                paramSet.Add("PRDT_DIV",    this.cbo01_PRDT_DIV.GetValue().ToString());
                paramSet.Add("PARTNO",      this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("LANG_SET",    this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet dsInqueryMaster = _WSCOM.Inquery_Master(paramSet);
                DataSet dsInqueryMaster = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_MASTER"), paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(dsInqueryMaster);

                ShowDataCount(dsInqueryMaster);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
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
                _CORCD = "";
                _BIZCD = "";
                this.grd02.InitializeDataSource();
                this.txt02_PARTNO.Initialize();
                this.txt01_PARTNM.Initialize();
                this.txt01_LOG_CONTCD.Initialize();
                this.cdx01_LINECD.Initialize();
                this.NME01_SAF_INV_QTY.Initialize();
                this.NME01_UNIT_QTY.Initialize();  
                this.txt01_ALCCD.Initialize();
                this.cbo01_WARN_LEV_TYPE.Initialize();
                this.cbo01_SPEA_TYPE.Initialize();
                this.cbo01_LEVELCD.Initialize();
                this.cbo01_SEMI_DIV.Initialize();
                this.cbo01_IMPACT_PAD.Initialize();
                this.dtp01_BEG_DATE.SetMMFromStart();
                this.dtp01_END_DATE.SetFromEnd();
                this.cbo01_LHD_RHD_DIV.Initialize();
                this.cbo01_CPNL_DIV.Initialize();
                this.cbo01_IMS_YN.Initialize();
                this.cbo01_CURTAIN_TYPE.Initialize();
                this.cbo01_EXPORT_DIV.Initialize();
                this.cbo01_INSIDE_HANDLE_TYPE.Initialize();
                this.cbo01_IHDL_HOUSG_COLOR.Initialize();
                this.cbo01_AREST_EM_TYPE.Initialize();
                this.cbo01_GARNISH.Initialize();
                this.cbo01_TWT_SPKR_YN.Initialize();
                this.cbo01_MID_SPKR_YN.Initialize();
                this.cbo01_MOOD_LAMP_YN.Initialize();
            //    this.cbo01_FOOT_LAMP_YN.Initialize();
                this.cbo01_SPKR_GRILL.Initialize();
                this.cbo01_MAP_PKT_YN.Initialize();
                this.cbo01_TWT_SPKR_TYPE.Initialize();
                this.cbo01_UPPR_TRIM_TYPE.Initialize();
                this.cbo01_CPNL_COLOR.Initialize();
                this.cbo01_GARNISH_COLOR.Initialize();
                this.cbo01_UPPR_TRIM_COLOR.Initialize();
                this.cbo01_AREST_STITCH_COLOR.Initialize();
                this.cbo01_GRILL.Initialize();
                this.cbo01_LAMP.Initialize();
                this.cbo01_BPR_PIER.Initialize();
                this.cbo01_TYPE.Initialize();
                this.cbo01_CAMERA.Initialize();
                this.cbo01_RGRILL.Initialize();
                this.cbo01_SWITCH.Initialize();
                this.cbo01_ARM_RST.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("BIZCD",    this.cbo01_BIZCD.GetValue());
                paramSet.Add("CORCD",    this.UserInfo.CorporationCode);
                paramSet.Add("PARTNO",   this.grd01.GetValue(row,"PARTNO"));
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet dsInqueryDetail = _WSCOM.Inquery_Detail(paramSet);
                DataSet dsInqueryDetail = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), paramSet);
                this.grd02.SetValue(dsInqueryDetail);
                ShowDataCount(dsInqueryDetail);

                this.txt02_PARTNO.SetValue(this.grd01.GetValue(row, "PARTNO").ToString());
                this.txt01_PARTNM.SetValue(this.grd01.GetValue(row, "PARTNM").ToString());
                this.txt01_ALCCD.SetValue("");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd02.SelectedRowIndex;

                if (row < 1) return;

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.cbo01_BIZCD.GetValue().ToString();

                this.txt02_PARTNO.SetValue(this.grd02.GetValue(row, "PARTNO").ToString());
                this.txt01_PARTNM.SetValue(this.grd02.GetValue(row, "PARTNM").ToString());
                this.cdx01_LINECD.SetValue(this.grd02.GetValue(row, "LINECD").ToString());
                this.NME01_SAF_INV_QTY.SetValue(this.grd02.GetValue(row, "SAF_INV_QTY").ToString());
                this.txt01_ALCCD.SetValue(this.grd02.GetValue(row, "ALCCD").ToString());
                this.cbo01_WARN_LEV_TYPE.SetValue(this.grd02.GetValue(row, "WARN_LEV_TYPE").ToString());
                this.cbo01_SPEA_TYPE.SetValue(this.grd02.GetValue(row, "SPEA_TYPE").ToString());
                this.cbo01_SEMI_DIV.SetValue(this.grd02.GetValue(row, "SEMI_DIV").ToString());
                this.dtp01_BEG_DATE.SetValue(this.grd02.GetValue(row, "BEG_DATE").ToString());
                this.dtp01_END_DATE.SetValue(this.grd02.GetValue(row, "END_DATE").ToString());
                this.txt01_LOG_CONTCD.SetValue(this.grd02.GetValue(row, "LOGICD").ToString());
                this.cbo01_LEVELCD.SetValue(this.grd02.GetValue(row, "LEVCD").ToString());
                this.cbo01_IMPACT_PAD.SetValue(this.grd02.GetValue(row, "IMPACT_PAD").ToString());
                this.txt01_AREA.SetValue(this.grd02.GetValue(row, "AREA").ToString());
                this.cbo01_LHD_RHD_DIV.SetValue(this.grd02.GetValue(row, "LHD_RHD_DIV").ToString());
                this.cbo01_CPNL_DIV.SetValue(this.grd02.GetValue(row, "CPNL_DIV").ToString());
                this.cbo01_IMS_YN.SetValue(this.grd02.GetValue(row, "IMS_YN").ToString());
                this.cbo01_CURTAIN_TYPE.SetValue(this.grd02.GetValue(row, "CURTAIN_TYPE").ToString());
                this.cbo01_EXPORT_DIV.SetValue(this.grd02.GetValue(row, "EXPORT_DIV").ToString());
                this.cbo01_INSIDE_HANDLE_TYPE.SetValue(this.grd02.GetValue(row, "INSIDE_HANDLE_TYPE").ToString());
                this.chk01_ELEC_PASS_YN.Checked = this.grd02.GetValue(row, "ELEC_PASS_YN").Equals("Y") ? true : false;
                this.cbo01_IHDL_HOUSG_COLOR.SetValue(this.grd02.GetValue(row, "IHDL_HOUSG_COLOR").ToString());
                this.cbo01_AREST_EM_TYPE.SetValue(this.grd02.GetValue(row, "AREST_EM_TYPE").ToString());
                this.cbo01_GARNISH.SetValue(this.grd02.GetValue(row, "GARNISH").ToString());
                this.cbo01_TWT_SPKR_YN.SetValue(this.grd02.GetValue(row, "TWT_SPKR_YN").ToString());
                this.cbo01_MID_SPKR_YN.SetValue(this.grd02.GetValue(row, "MID_SPKR_YN").ToString());
                this.cbo01_MOOD_LAMP_YN.SetValue(this.grd02.GetValue(row, "MOOD_LAMP_YN").ToString());
                //this.cbo01_FOOT_LAMP_YN.SetValue(this.grd02.GetValue(row, "FOOT_LAMP_YN").ToString());
                this.cbo01_SPKR_GRILL.SetValue(this.grd02.GetValue(row, "SPKR_GRILL").ToString());
                this.cbo01_MAP_PKT_YN.SetValue(this.grd02.GetValue(row, "MAP_PKT_YN").ToString());
                this.cbo01_TWT_SPKR_TYPE.SetValue(this.grd02.GetValue(row, "TWT_SPKR_TYPE").ToString());
                this.cbo01_UPPR_TRIM_TYPE.SetValue(this.grd02.GetValue(row, "UPPR_TRIM_TYPE").ToString());
                this.cbo01_CPNL_COLOR.SetValue(this.grd02.GetValue(row, "CPNL_COLOR").ToString());
                this.cbo01_GARNISH_COLOR.SetValue(this.grd02.GetValue(row, "GARNISH_COLOR").ToString());
                this.cbo01_UPPR_TRIM_COLOR.SetValue(this.grd02.GetValue(row, "UPPR_TRIM_COLOR").ToString());
                this.cbo01_AREST_STITCH_COLOR.SetValue(this.grd02.GetValue(row, "AREST_STITCH_COLOR").ToString());
                this.NME01_UNIT_QTY.SetValue(this.grd02.GetValue(row, "UNIT_QTY").ToString());
                this.cbo01_GRILL.SetValue(this.grd02.GetValue(row, "BPR_GRILL").ToString());
                this.cbo01_LAMP.SetValue(this.grd02.GetValue(row, "BPR_LAMP").ToString());
                this.cbo01_BPR_PIER.SetValue(this.grd02.GetValue(row, "BPR_PIER").ToString());
                this.cbo01_TYPE.SetValue(this.grd02.GetValue(row, "TYPE").ToString());
                this.cbo01_CAMERA.SetValue(this.grd02.GetValue(row, "CAMERA").ToString());
                this.cbo01_RGRILL.SetValue(this.grd02.GetValue(row, "RGRILL").ToString());
                this.cbo01_SWITCH.SetValue(this.grd02.GetValue(row, "SWITCH").ToString());
                this.cbo01_ARM_RST.SetValue(this.grd02.GetValue(row, "ARM_REST").ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());            
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                DataRow row = source.Tables[0].Rows[0];

                string   LINECD = this.cdx01_LINECD.GetValue().ToString();
                string   PARTNO     = row["PARTNO"].ToString();
                string   LOGICD     = row["LOGICD"].ToString();
                //string   ALCCD      = this.txt01_ALCCD.GetValue().ToString();
                DateTime dtBEG_DATE = DateTime.Parse(dtp01_BEG_DATE.GetValue().ToString());
                DateTime dtEND_DATE = DateTime.Parse(dtp01_END_DATE.GetValue().ToString());

                if (this.GetByteCount(LINECD) == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("라인CODE를 입력하지 않았습니다.");
                    MsgCodeBox.Show("PD00-0065");
                    return false;
                }

                //if (this.GetByteCount(ALCCD) == 0)
                //{
                //    //메세지 코드 처리
                //    //MsgBox.Show("ALC CODE를 입력하지 않았습니다.");
                //    MsgCodeBox.Show("PD00-0066");
                //    return false;
                //}

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("PART-NO를 입력하지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("PARTNO"));
                    return false;
                }

                if (this.GetByteCount(PARTNO) > 20)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("PART-NO는 20Byte를 넘을 수 없습니다.");
                    MsgCodeBox.Show("PD00-0067");
                    return false;
                }

                if (this.GetByteCount(LOGICD) > 10)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("물류용기코드는 10Byte를 넘을 수 없습니다.");
                    MsgCodeBox.Show("PD00-0068");
                    return false;
                }

                if (dtBEG_DATE > dtEND_DATE)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("시작일자는 종료일자보다 클 수 없습니다.");
                    MsgCodeBox.Show("PD00-0069");
                    return false;
                }

                if(Convert.ToInt32(this.NME01_UNIT_QTY.GetDBValue()) < 1)
                {
                    this.NME01_UNIT_QTY.SetValue(1);
                }

                //메세지 코드 처리
                //if (MsgBox.Show("입력하신 PART-NO 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)

                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                DataRow row = source.Tables[0].Rows[0];

                string PARTNO = row["PARTNO"].ToString();

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("삭제할 PART-NO 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //메세지 코드 처리
                //if (MsgBox.Show("선택하신 PART-NO 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private bool IsInqueryValid()
        {
            try
            {
                if (this.cdx01_VINCD.ByteCount > 0)
                    return true;

                if (this.cdx01_ITEMCD.ByteCount > 0)
                    return true;

                if (this.cbo01_INSTALL_POS.ByteCount > 0)
                    return true;

                if (this.cbo01_PRDT_DIV.ByteCount > 0)
                    return true;

                if (this.txt01_PARTNO.ByteCount > 0)
                    return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }


            //메세지 코드 처리
            //MsgBox.Show("검색조건이 입력 되지 안았습니다. 하나 이상의 검색조건을 입력하십시오.");
            MsgCodeBox.Show("PD00-0070");
            return false;
        }

        #endregion

        private void axLabel1_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
