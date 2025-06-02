#region ▶ Description & History
/* 
 * 프로그램명 : PD20102 생산 PARTNO 일괄등록
 * 설      명 : 
 * 최초작성자 : 김선환
 * 최초작성일 : 2010-07-23 
 * 최종수정자 : 오세민
 * 최종수정일 : 
 * 수정  내용 : 품번 공백 제거 쿼리 수정
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2010-07-23		김선환		최초 개발
 *				2014-07-23      배명희      cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *				                            cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
 *				2017-07~09      배명희      SIS 이관(구.PM20016)
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.ServiceModel;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.IO;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 생산 PARTNO 일괄등록    
    /// </summary>
    public partial class PD20102 : AxCommonBaseControl
    {
        //private IPM20016 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20102";        

        private const string _ExcelProvider
            = @"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=""Excel 12.0;HDR=YES;"";Data Source={0}";

        private const string _ExcelSQL
            = @"SELECT UCASE(TRIM([PARTNO])) AS PARTNO,
                       TRIM([SAF_INV_QTY]) AS SAF_INV_QTY,
                       UCASE(TRIM([LINECD])) AS LINECD,
                       UCASE(TRIM([ALCCD])) AS ALCCD,
                       UCASE(TRIM([SEMI_DIV])) AS SEMI_DIV,
                       UCASE(TRIM([LEVCD])) AS LEVCD,
                       UCASE(TRIM([WARN_LEV_TYPE])) AS WARN_LEV_TYPE,
                       UCASE(TRIM([SPEA_TYPE])) AS SPEA_TYPE,
                       UCASE(TRIM([LOGICD])) AS LOGICD,
                       UCASE(TRIM([IMPACT_PAD])) AS IMPACT_PAD,
                       UCASE(TRIM([AREA])) AS AREA,
                       UCASE(TRIM([LHD_RHD_DIV])) AS LHD_RHD_DIV,
                       UCASE(TRIM([CPNL_DIV])) AS CPNL_DIV, 
                       UCASE(TRIM([IMS_YN])) AS IMS_YN,
                       UCASE(TRIM([CURTAIN_TYPE])) AS CURTAIN_TYPE,
                       UCASE(TRIM([EXPORT_DIV])) AS EXPORT_DIV,                       
                       UCASE(TRIM([INSIDE_HANDLE_TYPE])) AS INSIDE_HANDLE_TYPE,
                       UCASE(TRIM([ELEC_PASS_YN])) AS ELEC_PASS_YN,
                       UCASE(TRIM([EMBLEM_TYPE])) AS AREST_EM_TYPE,
                       UCASE(TRIM([IHDL_HOUSG_COLOR])) AS IHDL_HOUSG_COLOR,
                       UCASE(TRIM([GARNISH])) AS GARNISH,
                       UCASE(TRIM([TWT_SPKR_YN])) AS TWT_SPKR_YN,
                       UCASE(TRIM([MID_SPKR_YN])) AS MID_SPKR_YN,
                       UCASE(TRIM([MOOD_LAMP_YN])) AS MOOD_LAMP_YN,
                       UCASE(TRIM([SPKR_GRILL])) AS SPKR_GRILL,
                       UCASE(TRIM([KEY_COL])) AS KEY_COL,
                       UCASE(TRIM([MAP_PKT_YN])) AS MAP_PKT_YN,
                       UCASE(TRIM([TWT_SPKR_TYPE])) AS TWT_SPKR_TYPE,
                       UCASE(TRIM([UPPR_TRIM_TYPE])) AS UPPR_TRIM_TYPE,
                       UCASE(TRIM([MIRROR_CVR_YN])) AS MIRROR_CVR_YN,
                       UCASE(TRIM([UPPR_RAIL_YN])) AS UPPR_RAIL_YN,
                       UCASE(TRIM([CPNL_COLOR])) AS CPNL_COLOR,
                       UCASE(TRIM([GARNISH_COLOR])) AS GARNISH_COLOR,
                       UCASE(TRIM([UPPR_TRIM_COLOR])) AS UPPR_TRIM_COLOR,
                       UCASE(TRIM([AREST_STITCH_COLOR])) AS AREST_STITCH_COLOR,
                       UCASE(TRIM([BPR_GRILL])) AS BPR_GRILL,
                       UCASE(TRIM([BPR_LAMP])) AS BPR_LAMP,
                       UCASE(TRIM([BPR_PIER])) AS BPR_PIER,
                       UCASE(TRIM([TYPE])) AS TYPE,
                       UCASE(TRIM([CAMERA])) AS CAMERA,
                       UCASE(TRIM([RGRILL])) AS RGRILL,
                       UCASE(TRIM([SWITCH])) AS SWITCH
                  FROM [{0}$] 
                 WHERE [PARTNO] IS NOT NULL";
        /*    = @"SELECT [PARTNO],
                       [SAF_INV_QTY],
                       [LINECD],
                       [ALCCD],
                       CASE WHEN [SEMI_DIV] IS NULL THEN [SEMI_DIV]
                            ELSE 'AP' + [SEMI_DIV] END AS SEMI_DIV,
                       'A6' + [LEVCD] AS LEVCD,
                       CASE WHEN [WARN_LEV_TYPE] IS NULL THEN [WARN_LEV_TYPE]
                            ELSE 'A9' + [WARN_LEV_TYPE] END AS WARN_LEV_TYPE,
                       CASE WHEN [SPEA_TYPE] IS NULL THEN [SPEA_TYPE]
                            ELSE 'A8' + [SPEA_TYPE] END AS SPEA_TYPE,
                       [LOGICD],
                       CASE WHEN [IMPACT_PAD] IS NULL THEN [IMPACT_PAD]
                            ELSE 'CD' + [IMPACT_PAD] END AS IMPACT_PAD,
                       [AREA]
                  FROM [{0}$]
                 WHERE [PARTNO] IS NOT NULL";*/

        public PD20102()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM20016>("PM00", "PM20016.svc", "CustomBinding");
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

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", GetLabel("PARTNO"));                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "안전재고수량", "SAF_INV_QTY", "SAF_INV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "ALC CODE", "ALCCD", "ALCCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "반제품유형", "SEMI_DIV", "SEMI_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "레벨코드", "LEVCD", "LEVCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "경고라벨타입", "WARN_LEV_TYPE", "WARN_LEV_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "스피커타입", "SPEA_TYPE", "SPEA_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "물류용기코드", "LOGICD", "LOG_CONTCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 090, "IMPACT PAD", "IMPACT_PAD", "IMPACT_PAD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "AREA", "AREA", "AREA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LHD/RHD구분", "LHD_RHD_DIV", "LHD_RHD_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "C/PNL사양구분", "CPNL_DIV", "CPNL_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "C/PNL 색상", "CPNL_COLOR", "CPNL_COLOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "IMS유무", "IMS_YN", "IMS_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "커튼사양", "CURTAIN_TYPE", "CURTAIN_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "수출구분", "EXPORT_DIV", "EXPORT_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "인사이드핸들(I/HDL)", "INSIDE_HANDLE_TYPE", "INSIDE_HANDLE_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "통전검사패스", "ELEC_PASS_YN", "ELEC_PASS_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 190, "EMBLEM", "AREST_EM_TYPE", "AREST_EM_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "A/REST 색상", "AREST_STITCH_COLOR", "AREST_STITCH_COLOR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "I/HDL HOUS'G 색상", "IHDL_HOUSG_COLOR", "IHDL_HOUSG_COLOR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "GARNISH", "GARNISH", "GARNISH");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "GARNISH 색상", "GARNISH_COLOR", "GARNISH_COLOR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "TWT SPKR", "TWT_SPKR_YN", "TWT_SPKR_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "MID SPKR", "MID_SPKR_YN", "MID_SPKR_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "무드램프", "MOOD_LAMP_YN", "MOOD_LAMP_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "SPKR GRILL", "SPKR_GRILL", "SPKR_GRILL");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "KEY COLOR", "KEY_COL", "KEY_COL");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "맵포켓유무", "MAP_PKT_YN", "MAP_PKT_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "TWT SPKR 사양", "TWT_SPKR_TYPE", "TWT_SPKR_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "UPPR TRIM", "UPPR_TRIM_TYPE", "UPPR_TRIM_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "UPPR 색상", "UPPR_TRIM_COLOR", "UPPR_TRIM_COLOR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "MIRROR COVER", "MIRROR_CVR_YN", "MIRROR_COVER_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "UPPR RAIL", "UPPR_RAIL_YN", "UPPR_RAIL_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "BUMPER GRILL", "BPR_GRILL", "BPR_GRILL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "BUMPER LAMP", "BPR_LAMP", "BPR_LAMP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "BUMPER PIER", "BPR_PIER", "BPR_PIER");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "TYPE", "TYPE", "TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "CAMERA", "CAMERA", "CAMERA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "RGRILL", "RGRILL", "RGRILL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "SWITCH", "SWITCH", "SWITCH");

                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AP", "SEMI_DIV");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A6", "LEVCD");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A9", "WARN_LEV_TYPE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A8", "SPEA_TYPE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CD", "IMPACT_PAD");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GD", "LHD_RHD_DIV");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GE", "CPNL_DIV");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GF", "CURTAIN_TYPE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GG", "EXPORT_DIV");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GK", "AREST_EM_TYPE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GJ", "IHDL_HOUSG_COLOR");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GL", "GARNISH");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GM", "SPKR_GRILL");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GN", "TWT_SPKR_TYPE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GR", "UPPR_TRIM_TYPE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GS", "CPNL_COLOR");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GT", "GARNISH_COLOR");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GU", "UPPR_TRIM_COLOR");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GV", "AREST_STITCH_COLOR");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "품번", "PARTNO", "PARTNOTITLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "안전재고수량", "SAF_INV_QTY", "SAF_INV_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "라인코드", "LINECD", "LINECD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적용시작일", "BEG_DATE", "APPLY_BEG_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적용종료일", "END_DATE", "APPLY_END_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "ALC CODE", "ALCCD", "ALCCODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "반제품유형", "SEMI_DIV", "SEMI_DIV");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "레벨코드", "LEVCD", "LEVCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "경고라벨타입", "WARN_LEV_TYPE", "WARN_LEV_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "스피커타입", "SPEA_TYPE", "SPEA_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "물류용기코드", "LOGICD", "LOG_CONTCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 090, "IMPACT PAD", "IMPACT_PAD", "IMPACT_PAD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "AREA", "AREA", "AREA");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LHD/RHD구분", "LHD_RHD_DIV", "LHD_RHD_DIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "C/PNL사양구분", "CPNL_DIV", "CPNL_DIV");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "C/PNL 색상", "CPNL_COLOR", "CPNL_COLOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "IMS유무", "IMS_YN", "IMS_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "커튼사양", "CURTAIN_TYPE", "CURTAIN_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "수출구분", "EXPORT_DIV", "EXPORT_DIV");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "인사이드핸들(I/HDL)", "INSIDE_HANDLE_TYPE", "INSIDE_HANDLE_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "통전검사패스", "ELEC_PASS_YN", "ELEC_PASS_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 190, "EMBLEM", "AREST_EM_TYPE", "AREST_EM_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "A/REST 색상", "AREST_STITCH_COLOR", "AREST_STITCH_COLOR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "I/HDL HOUS'G 색상", "IHDL_HOUSG_COLOR", "IHDL_HOUSG_COLOR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "GARNISH", "GARNISH", "GARNISH");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "GARNISH 색상", "GARNISH_COLOR", "GARNISH_COLOR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "TWT SPKR", "TWT_SPKR_YN", "TWT_SPKR_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "MID SPKR", "MID_SPKR_YN", "MID_SPKR_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "무드램프", "MOOD_LAMP_YN", "MOOD_LAMP_YN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "SPKR GRILL", "SPKR_GRILL", "SPKR_GRILL");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "KEY COLOR", "KEY_COL", "KEY_COL");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "맵포켓유무", "MAP_PKT_YN", "MAP_PKT_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "TWT SPKR사양", "TWT_SPKR_TYPE", "TWT_SPKR_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "UPPR TRIM", "UPPR_TRIM_TYPE", "UPPR_TRIM_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "UPPR 색상", "UPPR_TRIM_COLOR", "UPPR_TRIM_COLOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "MIRROR COVER", "MIRROR_CVR_YN", "MIRROR_COVER_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "UPPR RAIL", "UPPR_RAIL_YN", "UPPR_RAIL_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "BUMPER GRILL", "BPR_GRILL", "BPR_GRILL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "BUMPER LAMP", "BPR_LAMP", "BPR_LAMP");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "BUMPER PIER", "BPR_PIER", "BPR_PIER");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "TYPE", "TYPE", "TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "CAMERA", "CAMERA", "CAMERA");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "RGRILL", "RGRILL", "RGRILL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "SWITCH", "SWITCH", "SWITCH");  

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AP", "SEMI_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A6", "LEVCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A9", "WARN_LEV_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A8", "SPEA_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CD", "IMPACT_PAD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GD", "LHD_RHD_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GE", "CPNL_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GF", "CURTAIN_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GG", "EXPORT_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GH", "INSIDE_HANDLE_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GK", "AREST_EM_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GJ", "IHDL_HOUSG_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GL", "GARNISH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GM", "SPKR_GRILL");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GN", "TWT_SPKR_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GR", "UPPR_TRIM_TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GS", "CPNL_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GT", "GARNISH_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GU", "UPPR_TRIM_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GV", "AREST_STITCH_COLOR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GY", "BPR_GRILL");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "GW", "BPR_LAMP");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "YA", "TYPE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "YB", "CAMERA");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "YC", "RGRILL");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "YD", "SWITCH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);

                //this.cdx01_ITEMCD.HEPopupHelper = new CM30010P1("A4", true, true, this.cdx01_ITEMCD);                

                cbo01_PRDT_DIV.DataBind("A0", true);
                this.dtp01_END_DATE.SetFromEnd();

                this.SetRequired(this.lbl01_VINCD, this.lbl01_PRDTDIV);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue
                (
                    AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD", "PARTNO", "SAF_INV_QTY", "LINECD", "BEG_DATE", "END_DATE", "ALCCD", "SEMI_DIV", 
                    "LEVCD", "WARN_LEV_TYPE", "SPEA_TYPE", "LOGICD", "IMPACT_PAD", "AREA", 
                    "LHD_RHD_DIV", "CPNL_DIV", "IMS_YN", "CURTAIN_TYPE", "EXPORT_DIV", "USER_ID","INSIDE_HANDLE_TYPE","ELEC_PASS_YN",
                    "AREST_EM_TYPE", "IHDL_HOUSG_COLOR", "GARNISH", "TWT_SPKR_YN", "MID_SPKR_YN", "MOOD_LAMP_YN","SPKR_GRILL", "KEY_COL",
                    "MAP_PKT_YN", "TWT_SPKR_TYPE", "UPPR_TRIM_TYPE", "CPNL_COLOR", "GARNISH_COLOR", "UPPR_TRIM_COLOR", "AREST_STITCH_COLOR",
                    "BPR_GRILL", "BPR_LAMP", "BPR_PIER", "TYPE", "CAMERA", "RGRILL", "SWITCH"
                );

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["CORCD"] = this.UserInfo.CorporationCode;
                    rows["BIZCD"] = this.cbo01_BIZCD.GetValue();
                    rows["BEG_DATE"] = this.dtp01_BEG_DATE.GetDateText();
                    rows["END_DATE"] = this.dtp01_END_DATE.GetDateText();
                    rows["USER_ID"] = this.UserInfo.EmpNo;
                }

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                }
                this.AfterInvokeServer();


                //메세지 코드 처리
                //MsgBox.Show("입력하신 생산품번이 일괄등록 되었습니다.");
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.

                this.grd02.SetValue(source.Tables[0]);
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
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText().ToString());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue().ToString());
                //paramSet.Add("ITEMCD", this.cdx01_ITEMCD.GetValue().ToString());
                paramSet.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);
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
                this.grd02.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void btn01_EXCEL_FILE_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                this.txt01_EXCEL_FILE.SetValue(ofdExcel.FileName);

                string connectionString = String.Format(_ExcelProvider, ofdExcel.FileName);
                OleDbConnection conn = new OleDbConnection(connectionString);

                using (conn)
                {
                    conn.Open();
                    DataTable worksheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    DataTable dtSheet = new DataTable();
                    dtSheet.Columns.Add("SHEET_CODE");
                    dtSheet.Columns.Add("SHEET_NAME");
                    for (int i = 0; i < worksheets.Rows.Count; i++)
                    {
                        DataRow row = dtSheet.NewRow();
                        string sheetName = worksheets.Rows[i]["TABLE_NAME"].ToString();
                        if (sheetName.IndexOf('$') == -1)
                            continue;

                        sheetName = sheetName.Substring(0, sheetName.Length - 1);
                        row["SHEET_CODE"] = sheetName;
                        row["SHEET_NAME"] = sheetName;

                        dtSheet.Rows.Add(row);
                    }

                    this.cbo01_EXCEL_SHEET.DataBind(dtSheet, false);


                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.grd01.InitializeDataSource();
            }
        }

        private void btn01_EXCEL_LOAD_Click(object sender, EventArgs e)
        {
            // Note :
            // 엑셀 파일의 첫번째 행을 HEADER 로 인식한다.
            // 엑셀 파일 첫번째 행에는 반드시 아래와 같은 HEADER 정보가 명시되어야하며 오타는 에러로 처리한다.
            //  - ALCCD
            //  - PARTNO
            //  - USAGE
            // 순서는 관계없으며 HEADER 정보가 일치하지 않을 시 예외가 발생하여 엑셀파일을 읽을 수 없다.
            try
            {
                if (cbo01_EXCEL_SHEET.ByteCount == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("시트를 선택하지 않았습니다.");
                    MsgCodeBox.Show("PD00-0071");
                    return;
                }

                string connectionString = String.Format(_ExcelProvider, ofdExcel.FileName);
                OleDbConnection conn = new OleDbConnection(connectionString);
                using (conn)
                {
                    conn.Open();
                    DataTable worksheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string commandString = String.Format(_ExcelSQL, this.cbo01_EXCEL_SHEET.GetValue().ToString());
                    OleDbCommand cmd = new OleDbCommand(commandString, conn);
                    OleDbDataAdapter dapt = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dapt.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["PARTNO"] = dt.Rows[i]["PARTNO"].ToString().Replace(" ", "");
                    }

                    this.grd01.SetValue(dt);

                    IsSaveValid(null);
                }
            }
            catch (OleDbException)
            {
                //메세지 코드 처리
                //MsgBox.Show("선택하신 시트는 생산품번 일괄등록을 위한 올바른 형식의 시트가 아닙니다.\r\n\r\nPARTNO, SAF_INV_QTY, LINECD, ALCCD, SEMI_DIV, LEVCD, WARN_LEV_TYPE, SPEA_TYPE 정보가 \r\n\r\n존재하는 시트를 선택하십시오.");
                MsgCodeBox.Show("PD00-0072");
                
                this.grd01.InitializeDataSource();
            }
        }

        private void btn01_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = this.GetLabel("CD0021_ALL_RGST"); // "제조품번일괄등록";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls;*.xlsx|All files (*.*)|*.*";

            string filePath = null;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                File.WriteAllBytes(@filePath, Ax.SIS.PD.UI.Properties.Resources.제조품번일괄등록);
                MsgCodeBox.Show("CD00-0009");
            }
            else
            {
                return;
            }


        }

        #endregion

        #region [ 유효성 검사 ]

        public bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source != null && source.Tables[0].Rows.Count == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("저장할 생산품번 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다.
                    return false;
                }
                if (GetByteCount(this.cdx01_VINCD.GetValue().ToString()) == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("차종을 입력하여 주십시요");
                    MsgCodeBox.Show("PD00-0073");
                    return false;
                }
                //if (GetByteCount(this.cdx01_ITEMCD.GetValue().ToString()) == 0)
                //{
                //    //메세지 코드 처리
                //    //MsgBox.Show("품목을 입력하여 주십시요");
                //    MsgCodeBox.Show("PM00-0006");
                //    return false;
                //}
                if (GetByteCount(this.cbo01_PRDT_DIV.GetValue().ToString()) == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("제품구분을 입력하여 주십시요");
                    MsgCodeBox.Show("PD00-0074");
                    return false;
                }               

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("VINCD", this.cdx01_VINCD.GetValue());
                //set.Add("ITEMCD", this.cdx01_ITEMCD.GetValue());
                set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());                

                DataSet source02 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CODE"), set, "OUT_CURSOR_SEMI_DIV", "OUT_CURSOR_LEVCD", "OUT_CURSOR_WARN_LEV_TYPE", "OUT_CURSOR_SPEA_TYPE", "OUT_CURSOR_LINECD", "OUT_CURSOR_PARTNO");
                DataTable dtSEMI_DIV = source02.Tables[0];
                DataTable dtPARTNO = source02.Tables[5];
                DataTable dtLINECD = source02.Tables[4];


                System.Collections.Generic.Dictionary<string, DataTable> _TypeCode = new System.Collections.Generic.Dictionary<string, DataTable>();


                _TypeCode.Add("PARTNO", source02.Tables[5]); 
                _TypeCode.Add("LINECD", source02.Tables[4]);
                _TypeCode.Add("SEMI_DIV", GetTypeCode("AP").Tables[0]);
                _TypeCode.Add("LEVCD", GetTypeCode("A6").Tables[0]);
                _TypeCode.Add("WARN_LEV_TYPE", GetTypeCode("A9").Tables[0]);
                _TypeCode.Add("SPEA_TYPE", GetTypeCode("A8").Tables[0]);                                                                
                _TypeCode.Add("LHD_RHD_DIV", GetTypeCode("GD").Tables[0]);
                _TypeCode.Add("CPNL_DIV", GetTypeCode("GE").Tables[0]);
                _TypeCode.Add("CURTAIN_TYPE", GetTypeCode("GF").Tables[0]);
                _TypeCode.Add("EXPORT_DIV", GetTypeCode("GG").Tables[0]);
                _TypeCode.Add("INSIDE_HANDLE_TYPE", GetTypeCode("GH").Tables[0]);
                _TypeCode.Add("IHDL_HOUSG_COLOR", GetTypeCode("GJ").Tables[0]);
                _TypeCode.Add("AREST_EM_TYPE", GetTypeCode("GK").Tables[0]);
                _TypeCode.Add("GARNISH", GetTypeCode("GL").Tables[0]);
                _TypeCode.Add("SPKR_GRILL", GetTypeCode("GM").Tables[0]);
                _TypeCode.Add("TWT_SPKR_TYPE", GetTypeCode("GN").Tables[0]);
                _TypeCode.Add("UPPR_TRIM_TYPE", GetTypeCode("GR").Tables[0]);

                //_TypeCode.Add("CPNL_COLOR", GetTypeCode("GS").Tables[0]);
                //_TypeCode.Add("GARNISH_COLOR", GetTypeCode("GT").Tables[0]);
                //_TypeCode.Add("UPPR_TRIM_COLOR", GetTypeCode("GU").Tables[0]);
                //_TypeCode.Add("AREST_STITCH_COLOR", GetTypeCode("GV").Tables[0]);


                foreach (KeyValuePair<string, DataTable> key in _TypeCode)
                    key.Value.Columns[0].ColumnName = "CODE";

                CellStyle csError = this.grd01.Styles.Add("ErrorStyle");
                csError.BackColor = Color.Red;
                csError.ForeColor = Color.White;
                
                int iErrCnt = 0;
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    foreach (KeyValuePair<string, DataTable> pair in _TypeCode)
                    {
                        string value = this.grd01[i, pair.Key].ToString();
                        DataRow[] dr = pair.Value.Select("CODE ='" + value + "' ");
                        if (pair.Key.Equals("PARTNO") || pair.Key.Equals("LINECD"))
                        {
                            
                            if (this.GetByteCount(value) == 0 || dr.Length == 0)
                            {
                                this.grd01.SetCellStyle(i, this.grd01.Cols[pair.Key].Index, csError);
                                iErrCnt++;
                                
                            }
                        }
                        else
                        {
                            if (this.GetByteCount(value) != 0 && dr.Length == 0)
                            {
                                this.grd01.SetCellStyle(i, this.grd01.Cols[pair.Key].Index, csError);
                                iErrCnt++;
                                
                            }
                        }
                         
                    }
                    
                }
                if (source != null)
                {
                    if (iErrCnt > 0)
                    {
                        //MsgBox.Show("저장에 실패하였습니다." + "총 " + iErrCnt + "건의 이상 데이터가 발견되었습니다."); //@@@@                        
                        MsgCodeBox.ShowFormat("PD00-0075", iErrCnt);
                        return false;
                    }
                    //저장하시겠습니까?
                    //if (MsgBox.Show("입력하신 생산품번 정보를 일괄등록 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return false;
                }
                else
                {
                    if (iErrCnt > 0)
                    {
                        //MsgBox.Show("총 " + iErrCnt + "건의 이상 데이터가 발견되었습니다."); //@@@@                        
                        MsgCodeBox.ShowFormat("PD00-0076", iErrCnt);
                        return false;
                    }
                }
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        public bool IsQueryValid()
        {
            try
            {
                if (GetByteCount(this.cdx01_VINCD.GetValue().ToString()) == 0)
                {

                    //메세지 코드 처리
                    //MsgBox.Show("차종을 입력하여 주십시요");
                    MsgCodeBox.Show("PD00-0073");
                    return false;
                }
                
                if (GetByteCount(this.cbo01_PRDT_DIV.GetValue().ToString()) == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("제품구분을 입력하여 주십시요");
                    MsgCodeBox.Show("PD00-0074");
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
    }
}
