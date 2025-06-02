#region ▶ Description & History
/* 
 * 프로그램명 : 서열자재 가입하 정보 조회
 * 설      명 : 
 * 최초작성자 : 홍정현
 * 최초작성일 : 2010-09-08
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		수정내용
 *				---------------------------------------------------------------------------------------------
 *				2010-10-05      김영우      레포팅기능 추가
 *				2010-10-06      김영우      레포팅기능 추가로 인한 MAT_ITEM 코드박스 추가
 *				2014-07-30      배명희      cdx01_MAT_ITEM 연결 팝업 변경 (MM20043P1 -> CM30010P1)
 *				
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using System.Drawing;
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    public partial class PD31030  : AxCommonBaseControl
    {
        private const string _DecimalFormat = "###,###,###,###,##0";

        private AxClientProxy _WSCOM;        
        private string  _LOGDIV = "EBA";
        private string _INQDIV = "01";

        public PD31030 ()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        private void PD31030_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody  = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                panel5.Visible = false;

                this.grd01.AllowFreezing = AllowFreezingEnum.Columns;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Visible = true;

                this.grd02.AllowFreezing = AllowFreezingEnum.Columns;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Visible = false;

                this.grd03.AllowFreezing = AllowFreezingEnum.Columns;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Visible = true;

                this.grd04.AllowFreezing = AllowFreezingEnum.Columns;
                this.grd04.AllowDragging = AllowDraggingEnum.None;
                this.grd04.Visible = false;

                this.rdo01_DETAILS.SetValue(true);
                this.rdo01_LOG_DIV_SEQ.SetValue(true);
                        
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_STD_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                cdx01_VENDCD.HEPopupHelper = new CM20017P1();
                cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                cdx01_VENDCD.CodeParameterName = "VENDCD";
                cdx01_VENDCD.NameParameterName = "VENDNM";
                cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);                

                this.grd01.AutoClipboard = true;
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "업체정보",      "VENDNM",           "VEND_INFO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "외작 Part No",  "PARTNO",          "SUBCON_PNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "물류구분",      "LOG_DIV",          "LOG_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "기초\r\n재고",  "BAS_INV_OK_QTY",   "BAS_INV_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "생산\r\n실적",  "MAT_REQ_QTY",      "PROD_RSLT_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "현재고",        "CUR_INV_OK_QTY",  "NOW_INV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "생산\r\n계획",  "RSLT_QTY_SUM",     "PROD_PLAN_LINE");            
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "발주",          "PO_QTY",         "PO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "납품",          "SUM_PLN1",       "DELI");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "입하",          "SUM_PLN2",       "ARRIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "과부족",        "EXCEED_PROD_QTY", "EXC_QTY");
                
                string strCha = this.GetLabel("CHA");//차
                
                for (int i = 1; i <= 60; i++)
                {
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, i + strCha, "PLN" + i + "_1");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, i + strCha, "PLN" + i + "_2");

                }



                this.RecoverMultiHeaderGrid01();
                this.grd01.Cols.Frozen = this.grd01.Cols["LOG_DIV"].Index;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "BAS_INV_OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAT_REQ_QTY");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_SUM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUR_INV_OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PO_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PLN1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PLN2");
                this.grd01.Cols["VENDNM"].TextAlign = TextAlignEnum.LeftTop;

                this.grd01.Cols["MAT_REQ_QTY"].Format = _DecimalFormat;
                this.grd01.Cols["PO_QTY"].Format = _DecimalFormat;
                this.grd01.Cols["SUM_PLN1"].Format = _DecimalFormat;
                this.grd01.Cols["SUM_PLN2"].Format = _DecimalFormat;
                this.grd01.Cols["EXCEED_PROD_QTY"].Format = _DecimalFormat;
                for (int i = 1; i <= 60; i++)
                {
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLN" + i + "_1");
                    this.grd01.Cols["PLN" + i + "_1"].Format = _DecimalFormat;
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLN" + i + "_2");
                    this.grd01.Cols["PLN" + i + "_2"].Format = _DecimalFormat;
                }

                this.grd02.AutoClipboard = true;
                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize(2, 2);
                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "업체정보",      "VENDNM",      "VEND_INFO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "위치",          "INSTALL_POS", "INSTALL_POS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "용기\r\n코드",  "MAT_ITEM",     "CONTCD_LINE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "외작 Part No",  "PARTNO",      "SUBCON_PNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Name",     "PARTNM",      "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "물류구분",       "LOG_DIV",     "LOG_DIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "대표\r\nALC",   "ALCCD",        "ALCCD_REP_LINE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "기초\r\n재고", "BAS_INV_OK_QTY","BAS_INV_LINE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "생산\r\n실적", "RSLT_QTY_SUM",   "PROD_RSLT_LINE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "현재고",      "CUR_INV_OK_QTY", "NOW_INV");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "합계",          "SUM_PROD_QTY",  "TOTAL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "주간",          "DAY_PROD_QTY",  "WORKSHIFT_0");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "야간",          "NIGHT_PROD_QTY", "WORKSHIFT_1");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "발주",          "SUM_PLN",        "PO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "납품",          "SUM_PLN1",       "DELI");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "입하",          "SUM_PLN2",       "ARRIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "과부족",        "EXCEED_PROD_QTY", "EXC_QTY");
                for (int i = 1; i <= 60; i++)
                {
                   
                        this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, i + strCha, "PLN" + i);
                        this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, i + strCha, "PLN" + i + "_1");
                        this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, i + strCha, "PLN" + i + "_2");
                   
                }

                for (int i = 1; i <= 60; i++)
                {
                    this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "ERM_ARRIV_TIME" + i, "ERM_ARRIV_TIME" + i);

                }
                

                this.RecoverMultiHeaderGrid02();
                this.grd02.Cols.Frozen = this.grd02.Cols["ALCCD"].Index;
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "BAS_INV_OK_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_SUM");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUR_INV_OK_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PROD_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "DAY_PROD_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "NIGHT_PROD_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PLN");

                this.grd02.Cols["VENDNM"].TextAlign = TextAlignEnum.LeftTop;
                this.grd02.Cols["INSTALL_POS"].TextAlign = TextAlignEnum.LeftCenter;
                this.grd02.Cols["MAT_ITEM"].TextAlign = TextAlignEnum.LeftCenter;

                this.grd02.Cols["SUM_PROD_QTY"].Format   = _DecimalFormat;
                this.grd02.Cols["DAY_PROD_QTY"].Format   = _DecimalFormat;
                this.grd02.Cols["NIGHT_PROD_QTY"].Format = _DecimalFormat;
                
                this.grd02.Cols["SUM_PLN"].Format        = _DecimalFormat;
                this.grd02.Cols["SUM_PLN1"].Format = _DecimalFormat;
                this.grd02.Cols["SUM_PLN2"].Format = _DecimalFormat;
                this.grd02.Cols["EXCEED_PROD_QTY"].Format = _DecimalFormat;
                for (int i = 1; i <= 60; i++)
                {
                    this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLN" + i);
                    this.grd02.Cols["PLN" + i].Format = _DecimalFormat;
                    this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLN" + i + "_1");
                    this.grd02.Cols["PLN" + i + "_1"].Format = _DecimalFormat;
                    this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLN" + i + "_2");
                    this.grd02.Cols["PLN" + i + "_2"].Format = _DecimalFormat;
                }

                this.grd03.AutoClipboard = true;
                this.grd03.AllowEditing = false;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Initialize(2, 2);
                this.grd03.AllowSorting = AllowSortingEnum.None;
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "업체정보", "VENDNM", "VEND_INFO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "외작 Part No", "PARTNO", "SUBCON_PNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "물류구분", "LOG_DIV", "LOG_DIV");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "기초\r\n재고", "BAS_INV_OK_QTY", "BAS_INV_LINE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "생산\r\n실적", "MAT_REQ_QTY", "PROD_RSLT_LINE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "현재고", "CUR_INV_OK_QTY", "NOW_INV");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "생산\r\n계획", "RSLT_QTY_SUM", "PROD_PLAN_LINE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "발주", "PO_QTY", "PO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "납품", "SUM_PLN1", "DELI");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "입하", "SUM_PLN2", "ARRIV");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "과부족", "EXCEED_PROD_QTY", "EXC_QTY");
                this.RecoverMultiHeaderGrid03();
                this.grd03.Cols.Frozen = this.grd03.Cols["LOG_DIV"].Index;
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "BAS_INV_OK_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAT_REQ_QTY");

                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_SUM");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUR_INV_OK_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "PO_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PLN1");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PLN2");
                this.grd03.Cols["VENDNM"].TextAlign = TextAlignEnum.LeftTop;
                this.grd03.Cols["MAT_REQ_QTY"].Format = _DecimalFormat;
                this.grd03.Cols["PO_QTY"].Format = _DecimalFormat;
                this.grd03.Cols["SUM_PLN1"].Format = _DecimalFormat;
                this.grd03.Cols["SUM_PLN2"].Format = _DecimalFormat;
                this.grd03.Cols["EXCEED_PROD_QTY"].Format = _DecimalFormat;

                this.grd04.AutoClipboard = true;
                this.grd04.AllowEditing = false;
                this.grd04.AllowDragging = AllowDraggingEnum.None;
                this.grd04.Initialize(2, 2);
                this.grd04.AllowSorting = AllowSortingEnum.None;
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "업체정보", "VENDNM", "VEND_INFO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "용기\r\n코드", "MAT_ITEM", "CONTCD_LINE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "외작 Part No", "PARTNO", "SUBCON_PNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Name", "PARTNM", "PARTNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "물류구분", "LOG_DIV", "LOG_DIV");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "기초\r\n재고", "BAS_INV_OK_QTY", "BAS_INV_LINE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "생산\r\n실적", "RSLT_QTY_SUM", "PROD_RSLT_LINE");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 050, "현재고", "CUR_INV_OK_QTY", "NOW_INV");

                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "합계", "SUM_PROD_QTY",    "TOTAL");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "주간", "DAY_PROD_QTY",    "WORKSHIFT_0");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "야간", "NIGHT_PROD_QTY", "WORKSHIFT_1");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "발주", "SUM_PLN",         "PO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "납품", "SUM_PLN1",        "DELI");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "입하", "SUM_PLN2",        "ARRIV");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "과부족", "EXCEED_PROD_QTY", "EXC_QTY");

                this.RecoverMultiHeaderGrid04();
                this.grd04.Cols.Frozen = this.grd04.Cols["LOG_DIV"].Index;
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "BAS_INV_OK_QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_SUM");

                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUR_INV_OK_QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PROD_QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "DAY_PROD_QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "NIGHT_PROD_QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_PLN");

                this.grd04.Cols["VENDNM"].TextAlign = TextAlignEnum.LeftTop;
                this.grd04.Cols["INSTALL_POS"].TextAlign = TextAlignEnum.LeftCenter;
                this.grd04.Cols["MAT_ITEM"].TextAlign = TextAlignEnum.LeftCenter;

                this.grd04.Cols["SUM_PROD_QTY"].Format = _DecimalFormat;
                this.grd04.Cols["DAY_PROD_QTY"].Format = _DecimalFormat;
                this.grd04.Cols["NIGHT_PROD_QTY"].Format = _DecimalFormat;

                this.grd04.Cols["SUM_PLN"].Format = _DecimalFormat;
                this.grd04.Cols["SUM_PLN1"].Format = _DecimalFormat;
                this.grd04.Cols["SUM_PLN2"].Format = _DecimalFormat;
                this.grd04.Cols["EXCEED_PROD_QTY"].Format = _DecimalFormat;


                this.grd05.AutoClipboard = true;
                this.grd05.AllowEditing = false;
                this.grd05.AllowDragging = AllowDraggingEnum.None;
                this.grd05.Initialize();
                this.grd05.AllowSorting = AllowSortingEnum.None;
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "라인코드", "LINECD", "LINECD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "위치", "INSTALL_POS","INSTALL_POS");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "업체명", "VENDCD", "VENDNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "용기\r\n코드", "MAT_ITEM", "CONTCD_LINE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "물류구분", "LOG_DIV", "LOG_DIV");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차수", "JIS_CNT", "CHASU");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "수량", "MAT_INPUT_QTY", "QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "입하시간", "ERM_ARRIV_TIME1", "ERM_ARRIV_TIME");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "각인\r\n순서", "RANK_TIME", "READ_RANK_LINE");

                this.grd05.Cols["ERM_ARRIV_TIME1"].Format = "yyyy-MM-dd HH:mm:ss"; 
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Date, "ERM_ARRIV_TIME1");
                this.grd05.Cols["ERM_ARRIV_TIME1"].Format = "yyyy-MM-dd HH:mm:ss" ;
                this.grd05.Cols["ERM_ARRIV_TIME1"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd05.Cols["JIS_CNT"].Format = _DecimalFormat;
                this.grd05.Cols["MAT_INPUT_QTY"].Format = _DecimalFormat;
                this.grd05.Cols["RANK_TIME"].Format = _DecimalFormat;
                this.grd05.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd05.Cols["LINECD"].AllowMerging = true;
                this.grd05.Cols["INSTALL_POS"].AllowMerging = true;
                this.grd05.Cols["VENDCD"].AllowMerging = true;
                this.grd05.Cols["MAT_ITEM"].AllowMerging = true;
                this.grd05.Cols["LOG_DIV"].AllowMerging = true;

                this.grd06.AutoClipboard = true;
                this.grd06.AllowEditing = false;
                this.grd06.AllowDragging = AllowDraggingEnum.None;
                this.grd06.Initialize();
                this.grd06.AllowSorting = AllowSortingEnum.None;
                
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "라인코드", "LINECD", "LINECD");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "업체명", "VENDCD", "VENDNM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "용기\r\n코드", "MAT_ITEM", "CONTCD_LINE");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "물류구분", "LOG_DIV", "LOG_DIV");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차수", "JIS_CNT", "CHASU");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "수량", "MAT_INPUT_QTY", "QTY");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "입하시간", "ERM_ARRIV_TIME1", "ERM_ARRIV_TIME");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "각인\r\n순서", "RANK_TIME", "READ_RANK_LINE");

                this.grd06.SetColumnType(AxFlexGrid.FCellType.Date, "ERM_ARRIV_TIME1");
                this.grd06.Cols["ERM_ARRIV_TIME1"].Format = "yyyy-MM-dd HH:mm:ss";
                this.grd06.Cols["ERM_ARRIV_TIME1"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd06.Cols["JIS_CNT"].Format = _DecimalFormat;
                this.grd06.Cols["MAT_INPUT_QTY"].Format = _DecimalFormat;
                this.grd06.Cols["RANK_TIME"].Format = _DecimalFormat;

                this.grd05.Rows[0].Height = this.grd05.Rows[0].Height + 10;
                this.grd06.Rows[0].Height = this.grd06.Rows[0].Height + 10;
                this.grd06.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd06.Cols["LINECD"].AllowMerging = true;
                this.grd06.Cols["INSTALL_POS"].AllowMerging = true;
                this.grd06.Cols["VENDCD"].AllowMerging = true;
                this.grd06.Cols["MAT_ITEM"].AllowMerging = true;
                this.grd06.Cols["LOG_DIV"].AllowMerging = true;

                this.grd07.AutoClipboard = true;
                this.grd07.AllowEditing = false;
                this.grd07.AllowDragging = AllowDraggingEnum.None;
                this.grd07.Initialize();
                this.grd07.AllowSorting = AllowSortingEnum.None;

                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "라인코드", "LINECD", "LINECD");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "업체정보", "VENDCD", "VEND_INFO");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "용기코드", "MAT_ITEM", "CONTCD");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "총\r\n계획량", "SUM_PLAN_QTY", "SUM_PLAN_QTY");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "입고\r\n필요량", "IN_REQ_QTY", "IN_REQ_QTY");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "누적\r\n입고량", "SUM_IN_QTY", "SUM_IN_QTY");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "입고율", "IN_RATE", "RCVRATE");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "여유\r\n재고량", "SPARE_INV", "SPARE_INV");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "상태", "COLOR_STATUS_COL", "STATE");
                this.grd07.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 060, "상태코드", "COLOR_STATUS", "STATUSCD");
                for (int i = 1; i <= 60; i++)
                {
                    this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, i + strCha, "PLAN" + i);                    
                    this.grd07.AddHiddenColumn("STATUS" + i);                    
                }
                this.grd07.Cols["SUM_PLAN_QTY"].Format = _DecimalFormat;
                this.grd07.Cols["IN_REQ_QTY"].Format = _DecimalFormat;
                this.grd07.Cols["SUM_IN_QTY"].Format = _DecimalFormat;
                this.grd07.Cols["SPARE_INV"].Format = _DecimalFormat;

                this.grd07.Rows[0].Height = this.grd07.Rows[0].Height + 10;
                this.grd07.Cols.Frozen = this.grd07.Cols["COLOR_STATUS"].Index;
                GridVisible(_LOGDIV, _INQDIV);

                this.SetRequired(this.lbl01_BIZNM2,  this.lbl01_STD_DATE);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = null;
                //차수 각인 따로 분리
                if (this.rdo01_CHASU.Checked || this.rdo01_READ.Checked) 
                {
                    HEParameterSet param = new HEParameterSet();
                    param.Add("CORCD", this.UserInfo.CorporationCode);
                    param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    param.Add("STD_DATE", this.dte01_STD_DATE.GetDateText());
                    param.Add("LINECD", this.cdx01_LINECD.GetValue());
                    param.Add("LANG_SET", this.UserInfo.Language);
                    param.Add("MAT_ITEM", string.Empty);
                    param.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                    param.Add("INQ_DIV", "EBD"); //아이디는 그냥 연속해서 쓴다.
                    param.Add("LOG_DIV", this.rdo01_CHASU.Checked? "1" : "2"); //1차수, 2각인
                    param.Add("PARTNO", this.txt01_PARTNO.GetValue());


                    this.BeforeInvokeServer(true);
                    source = _WSCOM.ExecuteDataSet("APG_PD31030.INQUERY", param);
                    if(this.rdo01_CHASU.Checked)
                        this.grd05.SetValue(source);
                    else
                        this.grd06.SetValue(source);
                }
                else if (this.rdo01_UNITED.Checked)
                {
                    HEParameterSet param = new HEParameterSet();
                    param.Add("CORCD", this.UserInfo.CorporationCode);
                    param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    param.Add("STD_DATE", this.dte01_STD_DATE.GetDateText());
                    param.Add("LINECD", this.cdx01_LINECD.GetValue());
                    param.Add("LANG_SET", this.UserInfo.Language);
                    param.Add("MAT_ITEM", string.Empty);
                    param.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                    param.Add("INQ_DIV", "EBE"); //아이디는 그냥 연속해서 쓴다.
                    param.Add("LOG_DIV", _LOGDIV); //1차수, 2각인
                    param.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    param.Add("SAFE_INV_TIME", (string.IsNullOrEmpty(this.no01_SAFE_INV_TIME.GetDBValue().ToString()))?"0":this.no01_SAFE_INV_TIME.GetDBValue());
                    this.BeforeInvokeServer(true);

                    source = _WSCOM.ExecuteDataSet("APG_PD31030.INQUERY", param);
                    this.grd07.SetValue(source);

                    for (int i = this.grd07.Rows.Fixed; i < this.grd07.Rows.Count; i++)
                    {
                        if (this.grd07.GetValue(i, "COLOR_STATUS").ToString().Equals("G"))
                        {
                            this.grd07.GetCellRange(i, this.grd07.Cols["COLOR_STATUS_COL"].Index, i, this.grd07.Cols["COLOR_STATUS_COL"].Index).StyleNew.BackColor = Color.Green;
                        }
                        else if (this.grd07.GetValue(i, "COLOR_STATUS").ToString().Equals("Y"))
                        {
                            this.grd07.GetCellRange(i, this.grd07.Cols["COLOR_STATUS_COL"].Index, i, this.grd07.Cols["COLOR_STATUS_COL"].Index).StyleNew.BackColor = Color.Yellow;
                        }
                        else if (this.grd07.GetValue(i, "COLOR_STATUS").ToString().Equals("R"))
                        {
                            this.grd07.GetCellRange(i, this.grd07.Cols["COLOR_STATUS_COL"].Index, i, this.grd07.Cols["COLOR_STATUS_COL"].Index).StyleNew.BackColor = Color.Red;
                        }
                        else
                        {
                            this.grd07.GetCellRange(i, this.grd07.Cols["COLOR_STATUS_COL"].Index, i, this.grd07.Cols["COLOR_STATUS_COL"].Index).StyleNew.BackColor = Color.Transparent;
                        }
                            
                        for (int j = 1; j <= 60; j++)
                        {
                            if (this.grd07.GetValue(i, "STATUS" + j).ToString().Equals("Y"))
                            {
                                this.grd07.GetCellRange(i, this.grd07.Cols["PLAN" + j].Index, i, this.grd07.Cols["PLAN" + j].Index).StyleNew.BackColor = Color.FromArgb(132, 229, 127); 
                            }
                    
                        }
                    }
                }
                else
                {

                    if (!this.IsQueryValid())
                        return;

                    string INQ_DIV = string.Format("{0}{1}", _LOGDIV,
                                                             _INQDIV.Equals("01") ? "" : "_SUM");

                    HEParameterSet param = new HEParameterSet();
                    param.Add("CORCD", this.UserInfo.CorporationCode);
                    param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    param.Add("STD_DATE", this.dte01_STD_DATE.GetDateText());
                    param.Add("LINECD", this.cdx01_LINECD.GetValue());
                    param.Add("LANG_SET", this.UserInfo.Language);
                    param.Add("MAT_ITEM", string.Empty);
                    param.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                    param.Add("INQ_DIV", INQ_DIV);
                    param.Add("LOG_DIV", _LOGDIV);
                    param.Add("PARTNO", this.txt01_PARTNO.GetValue());


                    this.BeforeInvokeServer(true);

                    //source = _WSCOM.Inquery(param);
                    source = _WSCOM.ExecuteDataSet("APG_PD31030.INQUERY", param);

                    if (_LOGDIV == "EBA")
                    {
                        if (_INQDIV.Equals("01"))
                        {
                            this.grd02.MergedRanges.Clear();
                            this.RecoverMultiHeaderGrid02();
                            this.grd02.SetValue(source);
                            //string[] sSumLable = new string[] { "계", "소계", "중계", "총계" };
                            string[] sSumLable = new string[] { this.GetLabel("SUM_AMT"), this.GetLabel("STOT"), this.GetLabel("MTOT"), this.GetLabel("TOT") };
                            this.grd02.setSumStyle(4, 7, AxFlexGrid.eSumStyle.RowColMode, sSumLable);
                            this.grd02.Visible = true;
                            this.grd01.Visible = false;
                        }
                        else
                        {
                            this.grd04.MergedRanges.Clear();
                            this.RecoverMultiHeaderGrid04();
                            this.grd04.SetValue(source);
                            //string[] sSumLable = new string[] { "계", "소계", "중계", "총계" };
                            string[] sSumLable = new string[] { this.GetLabel("SUM_AMT"), this.GetLabel("STOT"), this.GetLabel("MTOT"), this.GetLabel("TOT") };
                            this.grd04.setSumStyle(4, 7, AxFlexGrid.eSumStyle.RowColMode, sSumLable);
                            this.grd04.Visible = true;
                            this.grd03.Visible = false;
                            this.grd02.Visible = false;
                            this.grd01.Visible = false;
                        }
                    }
                    else
                    {
                        if (_INQDIV.Equals("01"))
                        {
                            this.grd01.MergedRanges.Clear();
                            this.RecoverMultiHeaderGrid01();
                            this.grd01.SetValue(source);
                            //string[] sSumLable = new string[] { "소계", "총계" };
                            string[] sSumLable = new string[] { this.GetLabel("STOT"), this.GetLabel("TOT") };
                            this.grd01.setSumStyle(2, 2, AxFlexGrid.eSumStyle.RowColMode, sSumLable);
                            this.grd02.Visible = false;
                            this.grd01.Visible = true;
                        }
                        else
                        {
                            this.grd03.MergedRanges.Clear();
                            this.RecoverMultiHeaderGrid03();
                            this.grd03.SetValue(source);
                            //string[] sSumLable = new string[] { "소계", "총계" };
                            string[] sSumLable = new string[] { this.GetLabel("STOT"), this.GetLabel("TOT") };
                            this.grd03.setSumStyle(2, 2, AxFlexGrid.eSumStyle.RowColMode, sSumLable);
                            this.grd03.Visible = true;
                            this.grd01.Visible = false;
                            this.grd02.Visible = false;
                            this.grd04.Visible = false;
                        }
                    }
                }
                
                this.ShowDataCount(source);
                this.AfterInvokeServer();
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
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.dte01_STD_DATE.Initialize();
                this.cdx01_LINECD.Initialize();                
                this.txt01_PARTNO.Initialize();                
                this.grd02.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]

        private void dte01_STD_DATE_CloseUp(object sender, EventArgs e)
        {
            this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_STD_DATE.GetDateText());
        }

        private void dte01_STD_DATE_Leave(object sender, EventArgs e)
        {
            this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_STD_DATE.GetDateText());
        }

        private void cbo01_BIZCD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_LINECD.Initialize();
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", ((AxComboBox)sender).GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsQueryValid()
        {
            try
            {
                if (this._LOGDIV == "EBA")
                {
                    if (Convert.ToString(this.cdx01_LINECD.GetValue()).Length == 0)
                    {
                        //MsgBox.Show("서열자재 투입 정보를 조회하기 위하여 라인코드를 입력하십시오.");
                        MsgCodeBox.Show("PD00-0057");
                        return false;
                    }
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsPrintValid(HEParameterSet param)
        {
            try
            {
                if (param != null && string.IsNullOrEmpty(Convert.ToString(param["LINECD"])))
                {
                    //MsgBox.Show("레포팅을 하기 위하여 라인코드를 입력하십시오.");
                    MsgCodeBox.Show("PD00-0058");
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

        #region [ 헬퍼 메소드 정의 ]

        private void RecoverMultiHeaderGrid02()
        {
            try
            {
                this.grd02.AddMerge(0, 1, "VENDNM",         "VENDNM");
                this.grd02.AddMerge(0, 1, "INSTALL_POS",    "INSTALL_POS");
                this.grd02.AddMerge(0, 1, "MAT_ITEM",       "MAT_ITEM");
                this.grd02.AddMerge(0, 1, "PARTNO",         "PARTNO");
                this.grd02.AddMerge(0, 1, "PARTNM",         "PARTNM");
                this.grd02.AddMerge(0, 1, "LOG_DIV",        "LOG_DIV");
                this.grd02.AddMerge(0, 1, "ALCCD",          "ALCCD");
                this.grd02.AddMerge(0, 1, "BAS_INV_OK_QTY", "BAS_INV_OK_QTY");
                this.grd02.AddMerge(0, 1, "RSLT_QTY_SUM",   "RSLT_QTY_SUM");
                this.grd02.AddMerge(0, 1, "CUR_INV_OK_QTY", "CUR_INV_OK_QTY");
                this.grd02.AddMerge(0, 0, "SUM_PROD_QTY",   "NIGHT_PROD_QTY");
                this.grd02.AddMerge(0, 0, "SUM_PLN",        "SUM_PLN2");
                this.grd02.AddMerge(0, 1, "EXCEED_PROD_QTY", "EXCEED_PROD_QTY");
                

                for (int i = 1; i <= 60; i++)
                {
                    this.grd02.AddMerge(0, 0, "PLN" + i, "PLN" + i + "_2");
                }


                //this.grd02.SetHeadTitle(0, "SUM_PROD_QTY", "생산투입계획량");
                this.grd02.SetHeadTitle(0, "SUM_PROD_QTY", this.GetLabel("PINPUT_PLAN_QTY"));
                //this.grd02.SetHeadTitle(1, "SUM_PROD_QTY",      "합계");
                this.grd02.SetHeadTitle(1, "SUM_PROD_QTY", this.GetLabel("TOTAL"));
                //this.grd02.SetHeadTitle(1, "DAY_PROD_QTY",      "주간");
                this.grd02.SetHeadTitle(1, "DAY_PROD_QTY", this.GetLabel("WORKSHIFT_0"));
                //this.grd02.SetHeadTitle(1, "NIGHT_PROD_QTY",    "야간");
                this.grd02.SetHeadTitle(1, "NIGHT_PROD_QTY", this.GetLabel("WORKSHIFT_1"));
                //this.grd02.SetHeadTitle(0, "SUM_PLN", "합계");
                this.grd02.SetHeadTitle(0, "SUM_PLN", this.GetLabel("TOTAL"));
                //this.grd02.SetHeadTitle(1, "SUM_PLN", "발주");
                this.grd02.SetHeadTitle(1, "SUM_PLN", this.GetLabel("PO"));
                //this.grd02.SetHeadTitle(1, "SUM_PLN1", "납품");
                this.grd02.SetHeadTitle(1, "SUM_PLN1", this.GetLabel("DELI"));
                //this.grd02.SetHeadTitle(1, "SUM_PLN2", "입하");
                this.grd02.SetHeadTitle(1, "SUM_PLN2", this.GetLabel("ARRIV"));
              
                for (int i = 1; i <= 60; i++)
                {
                    //this.grd02.SetHeadTitle(0, "PLN" + i, i + "차");
                    //this.grd02.SetHeadTitle(1, "PLN" + i, "발주");
                    //this.grd02.SetHeadTitle(1, "PLN" + i + "_1", "납품");
                    //this.grd02.SetHeadTitle(1, "PLN" + i + "_2", "입하");
                    this.grd02.SetHeadTitle(0, "PLN" + i, i + this.GetLabel("CHA"));
                    this.grd02.SetHeadTitle(1, "PLN" + i, this.GetLabel("PO"));
                    this.grd02.SetHeadTitle(1, "PLN" + i + "_1", this.GetLabel("DELI"));
                    this.grd02.SetHeadTitle(1, "PLN" + i + "_2", this.GetLabel("ARRIV"));
                 }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private void RecoverMultiHeaderGrid04()
        {
            try
            {
                this.grd04.AddMerge(0, 1, "VENDNM", "VENDNM");
                this.grd04.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd04.AddMerge(0, 1, "MAT_ITEM", "MAT_ITEM");
                this.grd04.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd04.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd04.AddMerge(0, 1, "LOG_DIV", "LOG_DIV");
                this.grd04.AddMerge(0, 1, "BAS_INV_OK_QTY", "BAS_INV_OK_QTY");
                this.grd04.AddMerge(0, 1, "RSLT_QTY_SUM", "RSLT_QTY_SUM");
                this.grd04.AddMerge(0, 1, "CUR_INV_OK_QTY", "CUR_INV_OK_QTY");
                this.grd04.AddMerge(0, 0, "SUM_PROD_QTY", "NIGHT_PROD_QTY");
                this.grd04.AddMerge(0, 0, "SUM_PLN", "SUM_PLN2");
                this.grd04.AddMerge(0, 1, "EXCEED_PROD_QTY", "EXCEED_PROD_QTY");


                //this.grd04.SetHeadTitle(0, "SUM_PROD_QTY", "생산투입계획량");
                //this.grd04.SetHeadTitle(1, "SUM_PROD_QTY", "합계");
                //this.grd04.SetHeadTitle(1, "DAY_PROD_QTY", "주간");
                //this.grd04.SetHeadTitle(1, "NIGHT_PROD_QTY", "야간");
                //this.grd04.SetHeadTitle(0, "SUM_PLN", "합계");
                //this.grd04.SetHeadTitle(1, "SUM_PLN", "발주");
                //this.grd04.SetHeadTitle(1, "SUM_PLN1", "납품");
                //this.grd04.SetHeadTitle(1, "SUM_PLN2", "입하");
                this.grd04.SetHeadTitle(0, "SUM_PROD_QTY", this.GetLabel("PINPUT_PLAN_QTY"));
                this.grd04.SetHeadTitle(1, "SUM_PROD_QTY", this.GetLabel("TOTAL"));
                this.grd04.SetHeadTitle(1, "DAY_PROD_QTY", this.GetLabel("WORKSHIFT_0"));
                this.grd04.SetHeadTitle(1, "NIGHT_PROD_QTY", this.GetLabel("WORKSHIFT_1"));
                this.grd04.SetHeadTitle(0, "SUM_PLN", this.GetLabel("TOTAL"));
                this.grd04.SetHeadTitle(1, "SUM_PLN", this.GetLabel("PO"));
                this.grd04.SetHeadTitle(1, "SUM_PLN1", this.GetLabel("DELI"));
                this.grd04.SetHeadTitle(1, "SUM_PLN2", this.GetLabel("ARRIV"));

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private void RecoverMultiHeaderGrid01()
        {
            try
            {
                this.grd01.AddMerge(0, 1, "VENDNM", "VENDNM");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "LOG_DIV", "LOG_DIV");
                this.grd01.AddMerge(0, 1, "BAS_INV_OK_QTY", "BAS_INV_OK_QTY");
                this.grd01.AddMerge(0, 1, "RSLT_QTY_SUM", "RSLT_QTY_SUM");
                this.grd01.AddMerge(0, 1, "CUR_INV_OK_QTY", "CUR_INV_OK_QTY");
                this.grd01.AddMerge(0, 1, "MAT_REQ_QTY", "MAT_REQ_QTY");
                
                this.grd01.AddMerge(0, 1, "PO_QTY", "PO_QTY");               
                this.grd01.AddMerge(0, 0, "SUM_PLN1", "SUM_PLN2");
                this.grd01.AddMerge(0, 1, "EXCEED_PROD_QTY", "EXCEED_PROD_QTY");


                for (int i = 1; i <= 60; i++)
                {
                    this.grd01.AddMerge(0, 0, "PLN" + i+ "_1", "PLN" + i + "_2");
                }



                this.grd01.SetHeadTitle(0, "SUM_PLN1", this.GetLabel("TOTAL")); //"합계");
                this.grd01.SetHeadTitle(1, "SUM_PLN1", this.GetLabel("DELI")); //"납품");
                this.grd01.SetHeadTitle(1, "SUM_PLN2", this.GetLabel("ARRIV"));//"입하");

                for (int i = 1; i <= 60; i++)
                {
                    this.grd01.SetHeadTitle(0, "PLN" + i + "_1", i +this.GetLabel("CHA"));// "차");            
                    this.grd01.SetHeadTitle(1, "PLN" + i + "_1", this.GetLabel("DELI")); //"납품");
                    this.grd01.SetHeadTitle(1, "PLN" + i + "_2", this.GetLabel("ARRIV"));//"입하");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private void RecoverMultiHeaderGrid03()
        {
            try
            {
                this.grd03.AddMerge(0, 1, "VENDNM", "VENDNM");
                this.grd03.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd03.AddMerge(0, 1, "LOG_DIV", "LOG_DIV");
                this.grd03.AddMerge(0, 1, "BAS_INV_OK_QTY", "BAS_INV_OK_QTY");
                this.grd03.AddMerge(0, 1, "RSLT_QTY_SUM", "RSLT_QTY_SUM");
                this.grd03.AddMerge(0, 1, "CUR_INV_OK_QTY", "CUR_INV_OK_QTY");
                this.grd03.AddMerge(0, 1, "MAT_REQ_QTY", "MAT_REQ_QTY");

                this.grd03.AddMerge(0, 1, "PO_QTY", "PO_QTY");
                this.grd03.AddMerge(0, 0, "SUM_PLN1", "SUM_PLN2");
                this.grd03.AddMerge(0, 1, "EXCEED_PROD_QTY", "EXCEED_PROD_QTY");

                this.grd03.SetHeadTitle(0, "SUM_PLN1", this.GetLabel("TOTAL"));//"합계");
                this.grd03.SetHeadTitle(1, "SUM_PLN1", this.GetLabel("DELI"));//"납품");
                this.grd03.SetHeadTitle(1, "SUM_PLN2", this.GetLabel("ARRIV"));//"입하");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }


        #endregion

        private void GridVisible(string LOGDIV, string INQDIV)
        {
            try
            {
                this.grd01.Visible = false;
                this.grd02.Visible = false;
                this.grd03.Visible = false;
                this.grd04.Visible = false;
                this.grd05.Visible = false;
                this.grd06.Visible = false;
                this.grd07.Visible = false;

                AxFlexGrid _grd01 = _INQDIV.Equals("01") ? this.grd01 : this.grd03;
                AxFlexGrid _grd02 = _INQDIV.Equals("01") ? this.grd02 : this.grd04; 

                if (LOGDIV != "EBA")
                {
                    _grd01.Visible = true;
                    _grd02.Visible = false;
                    this.lbl01_LINECD.Image = null;
                    this.cdx01_LINECD.SetReadOnly(true);                    
                }
                else
                {
                    _grd01.Visible = false;
                    _grd02.Visible = true;
                    this.cdx01_LINECD.SetReadOnly(false);                    
                    this.lbl01_VENDCD.Image = null;                 
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private void rdi01_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            if (this.rdo01_CHASU.Checked == true)
            {
                DisableDiv(false, "1");
            }
            else if (this.rdo01_READ.Checked == true)
            {
                DisableDiv(false, "2");
            }
            else if (this.rdo01_UNITED.Checked == true) //통합
            {
                DisableDiv(false, "4");
                panel5.Visible = true;
            }
            else
            {
                DisableDiv(true, "3");

                _LOGDIV = this.rdo01_LOG_DIV_SEQ.Checked ? "EBA" : _LOGDIV;                
                _LOGDIV = this.rdo03_LOG_DIV_NSEQ.Checked ? "EBC" : _LOGDIV;
                _INQDIV = this.rdo01_DETAILS.Checked ? "01" : _INQDIV;
                _INQDIV = this.rdo02_SUMMARY.Checked ? "02" : _INQDIV;

                this.GridVisible(_LOGDIV, _INQDIV);                
            }
        }

        private void DisableDiv(bool flag, string type)
        {
            rdo01_LOG_DIV_SEQ.Enabled = flag;            
            rdo03_LOG_DIV_NSEQ.Enabled = flag;
            if (flag == false) //차수 각인일경우
            {
                this.grd01.Visible = flag;
                this.grd02.Visible = flag;
                this.grd03.Visible = flag;
                this.grd04.Visible = flag;
                if(type.Equals("1"))
                {
                    this.grd05.Visible = true;
                    this.grd06.Visible = false;
                    this.grd07.Visible = false;
                }
                else if (type.Equals("2"))
                {
                    this.grd05.Visible = false;
                    this.grd06.Visible = true;
                    this.grd07.Visible = false;
                }
                else if (type.Equals("4"))
                {
                    this.grd05.Visible = false;
                    this.grd06.Visible = false;
                    this.grd07.Visible = true;
                }
            }
        }

        private void grd02_MouseEnterCell(object sender, RowColEventArgs e)
        {
            try
            {
                int row = grd02.MouseRow;
                int col = grd02.MouseCol;

                if (row < grd02.Rows.Fixed) return;
                
                if (grd02.SelectedRowIndex < 1) return;
                if (grd02[1, col] == null) return;
                //if (this.grd02.GetValue(row, "PARTNO").Equals("계")
                //    && !(grd02[0, col].ToString().Equals("입하") && grd02[1, col].ToString().Equals("입하"))  //그리드 머지가 된 상황에서 
                //    && grd02[1, col].ToString().Equals("입하"))
                if (this.grd02.GetValue(row, "PARTNO").Equals(this.GetLabel("SUM_AMT"))
                    && !(grd02[0, col].ToString().Equals(this.GetLabel("ARRIV")) && grd02[1, col].ToString().Equals(this.GetLabel("ARRIV")))  //그리드 머지가 된 상황에서 
                    && grd02[1, col].ToString().Equals(this.GetLabel("ARRIV")))
                {
                    string tooltip = this.grd02.GetValue(row, "ERM_ARRIV_TIME" + grd02[0, col].ToString().Replace(this.GetLabel("CHA"), "")).ToString();
                    tlt01.SetToolTip(this.grd02, tooltip);
                }
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }
    }
}
