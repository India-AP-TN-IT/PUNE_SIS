#region ▶ Description & History
/* 
 * 프로그램명 : QA30431 HMC, KIA Claim 종합 현황 조회
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-28      배명희      통합WCF로 변경
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>유,무검사 종합현황 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:22:28<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:22:28   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30431 : AxCommonBaseControl
    {
        //private IQA30431 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private ICommon _WSCOM_CM;
        private String Get_VIEW_VINCD;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30431";

        #region [ 초기화 작업 정의 ]

        public QA30431()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30431>("QA01", "QA30431.svc", "CustomBinding");
            //_WSCOM_CM = ClientFactory.CreateChannel<ICommon>("CM", "COMMON.svc", "CustomBinding");

            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
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
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                this.cdx01_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");// "고객사코드";
                this.cdx01_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);


                this.grd01_11.AllowEditing = false;
                this.grd01_11.AllowDragging = AllowDraggingEnum.None;
                this.grd01_11.Initialize();
                this.grd01_11.AllowSorting = AllowSortingEnum.None;
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "지역", "OCCUR_DIV", "REGION");
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "구분", "OCCUR_TYPE", "GBN");
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "접수건수", "QTY", "RECEIPT_CNTT");
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "부품비", "PART_COST", "PART_COST");
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd01_11.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "합계(원)", "SUMTOT", "SUMTOT_WON");
                this.grd01_11.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_11.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd01_11.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd01_11.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");
                this.grd01_11.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_12.AllowEditing = false;
                this.grd01_12.AllowDragging = AllowDraggingEnum.None;
                this.grd01_12.Initialize();
                this.grd01_12.AllowSorting = AllowSortingEnum.None;
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "통보서 NO", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "지역", "OCCUR_DIV", "REGION");
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "접수건수", "QTY", "RECEIPT_CNTT");
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "부품비", "PART_COST", "PART_COST");
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd01_12.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "합계(원)", "SUMTOT", "SUMTOT_WON");
                this.grd01_12.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_12.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd01_12.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd01_12.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");
                this.grd01_12.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_13.AllowEditing = false;
                this.grd01_13.AllowDragging = AllowDraggingEnum.None;
                this.grd01_13.Initialize();
                this.grd01_13.AllowSorting = AllowSortingEnum.None;
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "구분", "DIV", "GBN");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "1차", "M01", "QTY01");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "2차", "M02", "QTY02");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "3차", "M03", "QTY03");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "4차", "M04", "QTY04");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "5차", "M05", "QTY05");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "6차", "M06", "QTY06");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "7차", "M07", "QTY07");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "8차", "M08", "QTY08");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "9차", "M09", "QTY09");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "10차", "M10", "QTY10");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "11차", "M11", "QTY11");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "12차", "M12", "QTY12");
                this.grd01_13.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "합계", "TOT", "SUMTOT");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M01");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M02");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M03");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M04");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M05");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M06");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M07");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M08");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M09");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M10");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M11");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "M12");
                this.grd01_13.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT");

                this.grd01_14.AllowEditing = false;
                this.grd01_14.AllowDragging = AllowDraggingEnum.None;
                this.grd01_14.Initialize();
                this.grd01_14.AllowSorting = AllowSortingEnum.None;
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "구분", "DIV", "GBN");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V01");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V02");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V03");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V04");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V05");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V06");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V07");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V08");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V09");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V10");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V11");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V12");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "", "V13");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "기타", "ETC", "ETC2");
                this.grd01_14.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "합계", "TOT", "SUMTOT");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V01");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V02");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V03");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V04");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V05");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V06");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V07");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V08");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V09");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V10");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V11");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V12");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "V13");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "ETC");
                this.grd01_14.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT");

                this.grd01_21.AllowEditing = false;
                this.grd01_21.AllowDragging = AllowDraggingEnum.None;
                this.grd01_21.Initialize();
                this.grd01_21.AllowSorting = AllowSortingEnum.None;
                this.grd01_21.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "차종", "VINNM", "VIN");
                this.grd01_21.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_21.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "SUMTOT", "PURC_WAMT");
                this.grd01_21.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_21.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_21.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_22.AllowEditing = false;
                this.grd01_22.AllowDragging = AllowDraggingEnum.None;
                this.grd01_22.Initialize();
                this.grd01_22.AllowSorting = AllowSortingEnum.None;
                this.grd01_22.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "차종", "VINNM", "VIN");
                this.grd01_22.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_22.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "SUMTOT", "PURC_WAMT");
                this.grd01_22.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_22.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_22.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_31.AllowEditing = false;
                this.grd01_31.AllowDragging = AllowDraggingEnum.None;
                this.grd01_31.Initialize();
                this.grd01_31.AllowSorting = AllowSortingEnum.None;
                this.grd01_31.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_31.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_31.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "SUMTOT", "PURC_WAMT");
                this.grd01_31.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_31.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_32.AllowEditing = false;
                this.grd01_32.AllowDragging = AllowDraggingEnum.None;
                this.grd01_32.Initialize();
                this.grd01_32.AllowSorting = AllowSortingEnum.None;
                this.grd01_32.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_32.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_32.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "SUMTOT", "PURC_WAMT");
                this.grd01_32.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_32.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_41.AllowEditing = false;
                this.grd01_41.AllowDragging = AllowDraggingEnum.None;
                this.grd01_41.Initialize();
                this.grd01_41.AllowSorting = AllowSortingEnum.None;
                this.grd01_41.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "발생지역", "REGIONNM", "OCCUR_REGION");
                this.grd01_41.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_41.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_41.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_41.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_42.AllowEditing = false;
                this.grd01_42.AllowDragging = AllowDraggingEnum.None;
                this.grd01_42.Initialize();
                this.grd01_42.AllowSorting = AllowSortingEnum.None;
                this.grd01_42.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "지역", "OCCUR_DIV", "REGION");
                this.grd01_42.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "통보서 NO", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd01_42.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "건수", "QTY", "NO_CASE");
                this.grd01_42.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_42.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_42.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_42.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_51.AllowEditing = false;
                this.grd01_51.AllowDragging = AllowDraggingEnum.None;
                this.grd01_51.Initialize();
                this.grd01_51.AllowSorting = AllowSortingEnum.None;
                this.grd01_51.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VINCD", "VIN");
                this.grd01_51.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_51.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_51.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_51.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "생산처", "VENDNM", "PROD_VEND1");
                this.grd01_51.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_51.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_52.AllowEditing = false;
                this.grd01_52.AllowDragging = AllowDraggingEnum.None;
                this.grd01_52.Initialize();
                this.grd01_52.AllowSorting = AllowSortingEnum.None;
                this.grd01_52.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VINCD", "VIN");
                this.grd01_52.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_52.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_52.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_52.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "생산처", "VENDNM", "PROD_VEND1");
                this.grd01_52.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_52.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_53.AllowEditing = false;
                this.grd01_53.AllowDragging = AllowDraggingEnum.None;
                this.grd01_53.Initialize();
                this.grd01_53.AllowSorting = AllowSortingEnum.None;
                this.grd01_53.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "국가명", "NATIONNM", "NATIONNM");
                this.grd01_53.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수량(건)", "QTY", "QTY_CNTT");
                this.grd01_53.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_53.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_53.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_61.AllowEditing = false;
                this.grd01_61.AllowDragging = AllowDraggingEnum.None;
                this.grd01_61.Initialize();
                this.grd01_61.AllowSorting = AllowSortingEnum.None;
                this.grd01_61.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "업체명", "VENDNM", "VENDNM");
                this.grd01_61.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "건수", "QTY", "NO_CASE");
                this.grd01_61.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_61.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_61.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_61.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_62.AllowEditing = false;
                this.grd01_62.AllowDragging = AllowDraggingEnum.None;
                this.grd01_62.Initialize();
                this.grd01_62.AllowSorting = AllowSortingEnum.None;
                this.grd01_62.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "업체명", "VENDNM", "VENDNM");
                this.grd01_62.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "건수", "QTY", "NO_CASE");
                this.grd01_62.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액(원)", "AMOUNT", "PURC_WAMT");
                this.grd01_62.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_62.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01_62.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");

                this.grd01_71.AllowEditing = false;
                this.grd01_71.AllowDragging = AllowDraggingEnum.None;
                this.grd01_71.Initialize();
                this.grd01_71.AllowSorting = AllowSortingEnum.None;
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "통보서 NO", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "R/O NO", "RONO", "RONO");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "품번A", "PART1", "PART1");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "품번B", "PART2", "PART2");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "판매일자", "SAL_DATE", "SAL_DATE");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VEND_VINCD", "VIN");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "이의내용", "DETAIL", "ISSUE_DETAIL");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "이의건수", "NO_CASE", "ACC_CNT");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "이의금액", "SUMTOT", "ACC_AMT");
                this.grd01_71.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_71.SetColumnType(AxFlexGrid.FCellType.Decimal, "NO_CASE");
                this.grd01_71.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                this.grd01_71.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01_71.SetColumnType(AxFlexGrid.FCellType.Date, "SAL_DATE");

                this.grd01_72.AllowEditing = false;
                this.grd01_72.AllowDragging = AllowDraggingEnum.None;
                this.grd01_72.Initialize();
                this.grd01_72.AllowSorting = AllowSortingEnum.None;
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "통보서 NO", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "R/O NO", "RONO", "RONO");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "품번A", "PART1", "PART1");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "품번B", "PART2", "PART2");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "판매일자", "SAL_DATE", "SAL_DATE");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VEND_VINCD", "VIN");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "이의내용", "DETAIL", "ISSUE_DETAIL");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "이의건수", "NO_CASE", "ACC_CNT");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "이의금액", "SUMTOT", "ACC_AMT");
                this.grd01_72.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_72.SetColumnType(AxFlexGrid.FCellType.Decimal, "NO_CASE");
                this.grd01_72.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                this.grd01_72.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01_72.SetColumnType(AxFlexGrid.FCellType.Date, "SAL_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_PROC_DATE);

                this.cdx01_SAL_VENDCD.SetValue("");

                this.pnl01_ViewC1.Dock = DockStyle.Fill;
                this.pnl01_ViewC2.Dock = DockStyle.Fill;


                //tab 1
                this.panel10.Width = this.tabPage1.Width / 2;
                this.groupBox3.Height = this.panel10.Height / 2;
                this.groupBox4.Height = this.panel20.Height / 2;

                //tab 2
                this.groupBox8.Width = this.tabPage1.Width / 2;

                //tab 3
                this.groupBox10.Width = this.tabPage1.Width / 2;

                //tab 4
                this.groupBox12.Width = this.tabPage1.Width / 2;

                //tab 5
                this.groupBox14.Width = this.tabPage1.Width / 3;
                this.groupBox15.Width = this.tabPage1.Width / 3;


                //tab 6
                this.groupBox17.Width = this.tabPage1.Width / 2;

                //tab 7
                this.groupBox18.Height = this.tabPage1.Height / 2;

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
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
            try
            {
                this.tabPage1.Text = this.GetLabel("QA30431_MSG1");
                this.tabPage2.Text = this.GetLabel("QA30431_MSG2");
                this.tabPage3.Text = this.GetLabel("QA30431_MSG3");
                this.tabPage4.Text = this.GetLabel("QA30431_MSG4");
                this.tabPage5.Text = this.GetLabel("QA30431_MSG5");
                this.tabPage6.Text = this.GetLabel("QA30431_MSG6");
                this.tabPage7.Text = this.GetLabel("QA30431_MSG7");

                this.groupBox3.Text = this.GetLabel("QA30431_MSG1_1");
                this.groupBox5.Text = this.GetLabel("QA30431_MSG1_2");
                this.groupBox4.Text = this.GetLabel("QA30431_MSG1_3");
                this.groupBox5.Text = this.GetLabel("QA30431_MSG1_4");

                this.groupBox8.Text = this.GetLabel("QA30431_MSG2_1");
                this.groupBox7.Text = this.GetLabel("QA30431_MSG2_2");

                this.groupBox10.Text = this.GetLabel("QA30431_MSG2_1");
                this.groupBox9.Text = this.GetLabel("QA30431_MSG2_2");

                this.groupBox12.Text = this.GetLabel("QA30431_MSG4_1");
                this.groupBox11.Text = this.GetLabel("QA30431_MSG4_2");

                this.groupBox14.Text = this.GetLabel("QA30431_MSG2_1");
                this.groupBox15.Text = this.GetLabel("QA30431_MSG2_2");
                this.groupBox13.Text = this.GetLabel("QA30431_MSG5_1");

                this.groupBox17.Text = this.GetLabel("QA30431_MSG2_1");
                this.groupBox16.Text = this.GetLabel("QA30431_MSG2_2");

                this.groupBox18.Text = this.GetLabel("QA30431_MSG7_1");
                this.groupBox19.Text = this.GetLabel("QA30431_MSG7_2");

                this.grd01_11.InitializeDataSource();
                this.grd01_12.InitializeDataSource();
                this.grd01_13.InitializeDataSource();
                this.grd01_14.InitializeDataSource();
                this.grd01_21.InitializeDataSource();
                this.grd01_22.InitializeDataSource();
                this.grd01_31.InitializeDataSource();
                this.grd01_32.InitializeDataSource();
                this.grd01_41.InitializeDataSource();
                this.grd01_42.InitializeDataSource();
                this.grd01_51.InitializeDataSource();
                this.grd01_52.InitializeDataSource();
                this.grd01_53.InitializeDataSource();
                this.grd01_61.InitializeDataSource();
                this.grd01_62.InitializeDataSource();
                this.grd01_71.InitializeDataSource();
                this.grd01_72.InitializeDataSource();

                this.chart1.DataSource = new DataTable();
                this.chart1.DataBind();
                this.chart2.DataSource = new DataTable();
                this.chart2.DataBind();
                this.chart3.DataSource = new DataTable();
                this.chart3.DataBind();
                this.chart4.DataSource = new DataTable();
                this.chart4.DataBind();

                chart3.Series[0].LegendText = this.GetLabel("NO_CASE");// "건수";
                chart3.Series[1].LegendText = this.GetLabel("AMT");// "금액";

                chart1.Series[0].LegendText = this.GetLabel("NO_CASE");// "건수";
                chart1.Series[1].LegendText = this.GetLabel("AMT");// "금액";

                chart4.Series[0].LegendText = this.GetLabel("NO_CASE");// "건수";
                chart4.Series[1].LegendText = this.GetLabel("ACC_RATE");// "누적비율";
                chart2.Series[0].LegendText = this.GetLabel("NO_CASE");// "건수";
                chart2.Series[1].LegendText = this.GetLabel("ACC_RATE");//"누적비율";




            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            if (!IsSelectValid()) return;

            this.SELECT_VIEW(tabControl1.SelectedIndex);
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SELECT_VIEW(tabControl1.SelectedIndex);
        }

        private void btn01_ViewC1_Click(object sender, EventArgs e)
        {
            this.pnl01_ViewC1.Visible = true;
        }

        private void btn01_ViewC2_Click(object sender, EventArgs e)
        {
            this.pnl01_ViewC2.Visible = true;
        }

        private void btn01_ViewC1_Close_Click(object sender, EventArgs e)
        {
            this.pnl01_ViewC1.Visible = false;
        }

        private void btn01_ViewC2_Close_Click(object sender, EventArgs e)
        {
            this.pnl01_ViewC2.Visible = false;
        }

        #endregion

        #region [유효성 검사]

        private bool IsSelectValid()
        {
            return true;
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void Set_grd01_14(string VIEW_VINCD)
        {
            try
            {
                string[] VINCD = VIEW_VINCD.Split(';');
                int startColIndex = this.grd01_14.Cols["V01"].Index;

                this.grd01_14.SetValue(0, startColIndex - 1, this.GetLabel("VIN"));//"차종");
                for (int i = 0; i < 13; i++)
                {
                    this.grd01_14.SetValue(0, startColIndex + i, (i >= VINCD.Length ? "-" : VINCD[i]));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SELECT_VIEW(int SelectedIndex)
        {
            try
            {
                this.chk01_CLAIM_SUPPORT.Visible = false;   

                if (SelectedIndex == 5)
                {
                    this.chk01_CLAIM_SUPPORT.Visible = true;   
                }

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();
                string PROC_DATE = this.dte01_PROC_DATE.GetDateText().ToString().Substring(0, 7);
                string CLAIM_SUPPORT = this.chk01_CLAIM_SUPPORT.GetValue().ToString();

                HEParameterSet paramSetVINLIST = new HEParameterSet();
                paramSetVINLIST.Add("CORCD", _CORCD);
                paramSetVINLIST.Add("BIZCD", BIZCD);
                paramSetVINLIST.Add("SAL_VENDCD", SAL_VENDCD);
                paramSetVINLIST.Add("PROC_DATE", PROC_DATE);
                paramSetVINLIST.Add("LANG_SET", _LANG_SET);

                //Get_VIEW_VINCD = _WSCOM.Inquery_VINLIST(paramSetVINLIST);
                Get_VIEW_VINCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VINLIST"), paramSetVINLIST).Tables[0].Rows[0][0].ToString();

                this.Set_grd01_14(Get_VIEW_VINCD);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("SAL_VENDCD", SAL_VENDCD);
                paramSet.Add("PROC_DATE", PROC_DATE);
                paramSet.Add("VINLIST", Get_VIEW_VINCD);
                paramSet.Add("CLAIM_SUPPORT", CLAIM_SUPPORT);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);
                string[] procedures ;
                System.Collections.Generic.List<HEParameterSet> paramSets = new System.Collections.Generic.List<HEParameterSet> { };

                switch (SelectedIndex)
                {
                    case 0:
                        //DataSet source_TAB1 = _WSCOM.Inquery_TAB1(paramSet);
                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_11"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_12"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_13"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_14"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_13C"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_14C")};
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);

                        DataSet source_TAB1 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);
                        this.grd01_11.SetValue(source_TAB1.Tables[0]);
                        this.grd01_12.SetValue(source_TAB1.Tables[1]);
                        this.grd01_13.SetValue(source_TAB1.Tables[2]);
                        this.grd01_14.SetValue(source_TAB1.Tables[3]);

                        this.chart1.DataSource = source_TAB1.Tables[4];
                        this.chart1.DataBind();
                        this.chart2.DataSource = source_TAB1.Tables[5];
                        this.chart2.DataBind();
                        this.chart3.DataSource = source_TAB1.Tables[4].Copy();
                        this.chart3.DataBind();
                        this.chart4.DataSource = source_TAB1.Tables[5].Copy();
                        this.chart4.DataBind();

                        break;
                    case 1:
                        //DataSet source_TAB2 = _WSCOM.Inquery_TAB2(paramSet);
                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_21"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_22")};                        
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);

                        DataSet source_TAB2 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);

                        this.grd01_21.SetValue(source_TAB2.Tables[0]);
                        this.grd01_22.SetValue(source_TAB2.Tables[1]);
                        break;
                    case 2:
                        //DataSet source_TAB3 = _WSCOM.Inquery_TAB3(paramSet);

                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_31"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_32")};                        
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);

                        DataSet source_TAB3 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);

                        this.grd01_31.SetValue(source_TAB3.Tables[0]);
                        this.grd01_32.SetValue(source_TAB3.Tables[1]);
                        break;
                    case 3:
                        //DataSet source_TAB4 = _WSCOM.Inquery_TAB4(paramSet);

                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_41"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_42")};                        
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);

                        DataSet source_TAB4 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);

                        this.grd01_41.SetValue(source_TAB4.Tables[0]);
                        this.grd01_42.SetValue(source_TAB4.Tables[1]);
                        break;
                    case 4:
                        //DataSet source_TAB5 = _WSCOM.Inquery_TAB5(paramSet);

                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_51"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_52"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_53")};                        
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);

                        DataSet source_TAB5 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);

                        this.grd01_51.SetValue(source_TAB5.Tables[0]);
                        this.grd01_52.SetValue(source_TAB5.Tables[1]);
                        this.grd01_53.SetValue(source_TAB5.Tables[2]);
                        break;
                    case 5:
                        //DataSet source_TAB6 = _WSCOM.Inquery_TAB6(paramSet);

                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_61"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_62")};                        
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);                       

                        DataSet source_TAB6 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);

                        this.grd01_61.SetValue(source_TAB6.Tables[0]);
                        this.grd01_62.SetValue(source_TAB6.Tables[1]);
                        break;
                    case 6:
                        //DataSet source_TAB7 = _WSCOM.Inquery_TAB7(paramSet);

                        procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_71"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_72")};                        
                        paramSets.Add(paramSet);
                        paramSets.Add(paramSet);                      

                        DataSet source_TAB7 = _WSCOM_N.MultipleExecuteDataSet(procedures, paramSets);

                        this.grd01_71.SetValue(source_TAB7.Tables[0]);
                        this.grd01_72.SetValue(source_TAB7.Tables[1]);
                        break;
                    default:
                        break;
                }

                this.AfterInvokeServer();
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

    }
}
