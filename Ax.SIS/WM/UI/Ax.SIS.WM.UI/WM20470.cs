#region ▶ Description & History
/* 
 * 프로그램명 : [PD20470] 일별/월별 검수단가 현황조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2015-01-19   이명희     폴란드ERM
*/
#endregion
//using System;
//using System.Data;
//using System.ServiceModel;
//using Ax.DEV.Utility.Controls;
//using DEV.Utility.Library;
//using HE.Framework.Core;
//using HE.Framework.ServiceModel;
//using TheOne.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.ServiceModel;
using TheOne.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.Core.Report;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// <b>Local / CKD 중포장 Tag 발행</b>
    /// - 작 성 자 : <br />
    /// - 작 성 일 :<br />
    /// </summary>
    public partial class WM20470 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        public WM20470()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;
                this.heDockingTab1.PanelWidth = 272;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
 
                #region [그리드1]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowMerging = AllowMergingEnum.None;
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "선택", "SEL_CHECK", "CHK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "인보이스번호", "INVOICE_NO", "INVOICE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "컨테이너번호", "CONTAINER_NO", "CONTAINER_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "대포장번호", "CASE_NO", "PACK_CASE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "바코드", "BOX_BARCODE", "BARCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "대포장 크기", "CASE_SIZE", "CASE_SIZE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "포장일자", "PACK_DATE", "PACKING_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "포장수량", "PACK_QTY", "PACKING_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "포장단위", "UNIT", "PACK_UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "발주번호", "PONO", "PONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체생산로트", "VENDOR_LOTNO", "VENDOR_LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "선적일자", "SHIP_DATE", "SHIPPING_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재유형", "MAT_TYPE", "MAT_TYPE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "SEL_CHECK");

                //전체선택 체크박스
                CellStyle cs = this.grd01.Styles.Add("Boolean");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd01.SetCellStyle(0, this.grd01.Cols["SEL_CHECK"].Index, cs);

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.dtp01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dtp01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                this.grd01.Cols["PACK_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PACK_DATE");
                this.grd01.Cols["SHIP_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "SHIP_DATE");

                this.grd01.Cols["PACK_QTY"].Format = _IntFormat;

                #endregion

                #region [그리드2]

                this.grd02.AllowEditing = true;
                this.grd02.Initialize();

                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "선택", "SEL_CHECK", "CHK");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "납품일자", "DELI_DATE", "DELI_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "업체", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명", "VENDNM", "VENDNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "납품전표번호", "NOTENO", "NOTENO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "납품차수", "DELI_CNT", "DELI_CNT");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "창고번호", "YARDNO", "YARDNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "품번", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "바코드", "BARCODE", "BARCODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "순번", "SEQ", "SEQ");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재유형", "MAT_TYPE", "MAT_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "납품수량", "DELI_QTY", "DELI_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "LOT NO", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "도착일자", "ARRIV_DATE", "ARRIV_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "도착시간", "ARRIV_TIME", "ARRIV_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "입하수량", "ARRIV_QTY", "ARRIV_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "분납회수", "INSDELI_CNT", "INSDELI_CNT");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "물류구분", "LOG_DIV", "LOG_DIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "품질검사여부", "INSPECT_YN", "INSPECT_YN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "발주번호", "PONO", "PONO");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "등록일시", "INSERT_DATE", "INSERT_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "변경일시", "UPDATE_DATE", "UPDATE_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "변경등록자", "UPDATE_ID", "UPDATE_ID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "ERM 도착일시", "ERM_ARRIV_TIME", "ERM_ARRIV_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "제조일자", "PRDT_DATE", "PRDT_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SQ업체", "SQ_VENDCD", "SQ_VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "트럭번호", "TRUCK_NO", "TRUCK_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "포장박스수량", "BOX_COUNT", "BOX_COUNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "전표 바코드", "BARCODE_NOTE", "BARCODE_NOTE");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재유형", "MAT_TYPE", "MAT_TYPE");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "SEL_CHECK");

                //전체선택 체크박스
                CellStyle cs2 = this.grd02.Styles.Add("Boolean");
                cs2.DataType = typeof(Boolean);
                cs2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd02.SetCellStyle(0, this.grd02.Cols["SEL_CHECK"].Index, cs2);

                for (int i = 0; i < this.grd02.Cols.Count; i++)
                    this.grd02.Cols[i].AllowMerging = true;

                #endregion

                //Local Tabpage Hide (2016-02-09 김도연 과장 요청 사항)
                tabControl1.TabPages.Remove(tpg01_PD20470_TPG2);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0: this.Inquery_CKD(); break;
                    case 1: this.Inquery_LOCAL(); break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string STD_YYMM = string.Empty;
                string SDATE = string.Empty;

                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.lbl01_PACK_CASE_NO.Visible = true;
                        this.txt01_PACK_CASE_NO.Visible = true;
                        this.lbl01_INVOICE_NO.Visible = true;
                        this.txt01_INVOICE_NO.Visible = true;
                        this.lbl01_SHIPPING_DATE.Visible = true;
                        this.lbl01_DELI_DATE.Visible = false;
                        break;

                    case 1:
                        this.lbl01_PACK_CASE_NO.Visible = false;
                        this.txt01_PACK_CASE_NO.Visible = false;
                        this.lbl01_INVOICE_NO.Visible = false;
                        this.txt01_INVOICE_NO.Visible = false;
                        this.lbl01_SHIPPING_DATE.Visible = false;
                        this.lbl01_DELI_DATE.Visible = true;
                        
                        break;
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Inquery_CKD()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.UserInfo.BusinessCode);
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("BARCODE", this.txt01_BARCODE.GetValue());
                paramSet.Add("SDATE", this.dtp01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dtp01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CASE_NO", this.txt01_PACK_CASE_NO.GetValue());
                paramSet.Add("INVOICE_NO", this.txt01_INVOICE_NO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language); 

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20470.INQUERY", paramSet);
                this.grd01.MergedRanges.Clear();
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.ShowDataCount(source);

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

        private void Inquery_LOCAL()
        {
            try
            {
                //HEParameterSet paramSet = new HEParameterSet();
                //paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                //paramSet.Add("BIZCD", this.UserInfo.BusinessCode);
                //paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                //paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                //paramSet.Add("BARCODE", this.txt01_BARCODE.GetValue());
                //paramSet.Add("SDATE", this.dtp01_SDATE.Value.ToString("yyyy-MM-dd"));
                //paramSet.Add("EDATE", this.dtp01_EDATE.Value.ToString("yyyy-MM-dd"));
                //paramSet.Add("LANG_SET", this.UserInfo.Language);

                //this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.ExecuteDataSet("APG_WM20470.INQUERY1", paramSet);
                //this.grd02.MergedRanges.Clear();
                //this.AfterInvokeServer();

                //this.grd02.SetValue(source.Tables[0]);
                //this.ShowDataCount(source);

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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);

                    if (rdo01_NORMAL.Checked)  
                        report.ReportName = "RxRpt/WM20470_R1";
                    else
                        report.ReportName = "RxRpt/WM20470_R1_S";

                    string url = "C:\\Work\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  

                    //DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                    //      "SEL_CHECK", "BIZCD", "VENDORCD", "VENDNM", "INVOICE_NO", "CONTAINER_NO", "PACK_CASE_NO", "PARTNO", "PARTNM", "BARCODE", "NET_WEIGHT", "GROSS_WEIGHT"
                    //      , "PACKING_DATE", "PACKING_QTY", "PACKING_UNIT", "ORDER_NO", "CASE_LOTNO", "VENDOR_LOTNO", "SHIPPING_DATE", "MAT_TYPE", "CORCD", "EMPNO");

                    //foreach (DataRow row in set.Tables[0].Rows)
                    //{
                    //    row["BIZCD"] = row["BIZCD"].ToString();
                    //    row["VENDORCD"] = row["VENDORCD"].ToString();
                    //    row["VENDNM"] = row["VENDNM"].ToString();
                    //    row["INVOICE_NO"] = row["INVOICE_NO"].ToString();
                    //    row["CONTAINER_NO"] = row["CONTAINER_NO"].ToString();
                    //    row["PACK_CASE_NO"] = row["PACK_CASE_NO"].ToString();
                    //    row["PARTNO"] = row["PARTNO"].ToString();
                    //    row["PARTNM"] = row["PARTNM"].ToString();
                    //    row["BARCODE"] = row["BARCODE"].ToString();
                    //    row["NET_WEIGHT"] = row["NET_WEIGHT"].ToString();
                    //    row["GROSS_WEIGHT"] = row["GROSS_WEIGHT"].ToString();
                    //    row["PACKING_DATE"] = row["PACKING_DATE"].ToString();
                    //    row["PACKING_QTY"] = row["PACKING_QTY"].ToString();
                    //    row["PACKING_UNIT"] = row["PACKING_UNIT"].ToString();
                    //    row["ORDER_NO"] = row["ORDER_NO"].ToString();
                    //    row["CASE_LOTNO"] = row["CASE_LOTNO"].ToString();
                    //    row["VENDOR_LOTNO"] = row["VENDOR_LOTNO"].ToString();
                    //    row["SHIPPING_DATE"] = row["SHIPPING_DATE"].ToString();
                    //    row["MAT_TYPE"] = row["MAT_TYPE"].ToString();
                    //    row["CORCD"] = this.UserInfo.CorporationCode;
                    //    row["EMPNO"] = this.UserInfo.EmpNo;                        
                    //    //row["LANG_SET"] = this.UserInfo.Language;       
                    //}

                    DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                                                      "SEL_CHECK", "BIZCD", "INVOICE_NO", "CONTAINER_NO", "CASE_NO", "PARTNO", "PARTNM", "BOX_BARCODE", 
                                                      "PACK_DATE", "PACK_QTY", "UNIT", "PONO", "VENDOR_LOTNO", "SHIP_DATE", "MAT_TYPE", "CORCD", "EMPNO");

                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        row["BIZCD"] = row["BIZCD"].ToString();
                        row["INVOICE_NO"] = row["INVOICE_NO"].ToString();
                        row["CONTAINER_NO"] = row["CONTAINER_NO"].ToString();
                        row["CASE_NO"] = row["CASE_NO"].ToString();
                        row["PARTNO"] = row["PARTNO"].ToString();
                        row["PARTNM"] = row["PARTNM"].ToString();
                        row["BOX_BARCODE"] = row["BOX_BARCODE"].ToString();
                        row["PACK_DATE"] = row["PACK_DATE"].ToString();
                        row["PACK_QTY"] = row["PACK_QTY"].ToString();
                        row["UNIT"] = row["UNIT"].ToString();
                        row["PONO"] = row["PONO"].ToString();
                        row["VENDOR_LOTNO"] = row["VENDOR_LOTNO"].ToString();
                        row["SHIP_DATE"] = row["SHIP_DATE"].ToString();
                        row["MAT_TYPE"] = row["MAT_TYPE"].ToString();
                        row["CORCD"] = this.UserInfo.CorporationCode;
                        row["EMPNO"] = this.UserInfo.EmpNo;                        
                    }

                    for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
                    {
                        if (set.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("N"))
                            set.Tables[0].Rows.RemoveAt(i);
                    }

                    set.Tables[0].Columns.Remove("SEL_CHECK");

                    this.AfterInvokeServer();

                    HERexSection xmlSection = new HERexSection(set, new HEParameterSet());

                    report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

                    AxRexpertReportViewer.ShowReport(report);
                    break;
                //case 1:
                //    HERexReport report2 = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);

                //    if (rdo01_NORMAL.Checked)
                //        report2.ReportName = "RxRpt/WM20470_R2";
                //    else
                //        report2.ReportName = "RxRpt/WM20470_R2_S";                    

                //    string url2 = "C:\\Work\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  

                //    DataSet set2 = this.grd02.GetValue(AxFlexGrid.FActionType.All,
                //           "SEL_CHECK", "BIZCD", "VENDCD", "VENDNM", "NOTENO", "DELI_DATE", "DELI_CNT", "YARDNO", "PARTNO", "PARTNM", "DELI_QTY", "LOTNO"
                //          , "ARRIV_DATE", "ARRIV_TIME", "ARRIV_QTY", "INSDELI_CNT", "LOG_DIV", "PONO", "BARCODE", "SEQ", "BOX_COUNT", "BARCODE_NOTE", "MAT_TYPE", "CORCD", "EMPNO");

                //    foreach (DataRow row in set2.Tables[0].Rows)
                //    {
                //        row["BIZCD"] = row["BIZCD"].ToString();
                //        row["VENDCD"] = row["VENDCD"].ToString();
                //        row["VENDNM"] = row["VENDNM"].ToString();
                //        row["NOTENO"] = row["NOTENO"].ToString();
                //        row["DELI_DATE"] = row["DELI_DATE"].ToString();
                //        row["DELI_CNT"] = row["DELI_CNT"].ToString();
                //        row["YARDNO"] = row["YARDNO"].ToString();
                //        row["PARTNO"] = row["PARTNO"].ToString();
                //        row["PARTNM"] = row["PARTNM"].ToString();
                //        row["DELI_QTY"] = row["DELI_QTY"].ToString();
                //        row["LOTNO"] = row["LOTNO"].ToString();
                //        row["ARRIV_DATE"] = row["ARRIV_DATE"].ToString();
                //        row["ARRIV_TIME"] = row["ARRIV_TIME"].ToString();
                //        row["ARRIV_QTY"] = row["ARRIV_QTY"].ToString();
                //        row["INSDELI_CNT"] = row["INSDELI_CNT"].ToString();
                //        row["LOG_DIV"] = row["LOG_DIV"].ToString();
                //        row["PONO"] = row["PONO"].ToString();
                //        row["BARCODE"] = row["BARCODE"].ToString();
                //        row["SEQ"] = row["SEQ"].ToString();
                //        row["BOX_COUNT"] = row["BOX_COUNT"].ToString();
                //        row["BARCODE_NOTE"] = row["BARCODE_NOTE"].ToString();
                //        row["MAT_TYPE"] = row["MAT_TYPE"].ToString();
                //        row["CORCD"] = this.UserInfo.CorporationCode;
                //        row["EMPNO"] = this.UserInfo.EmpNo;
                //        //row["LANG_SET"] = this.UserInfo.Language;      
                //    }

                //    for (int i = set2.Tables[0].Rows.Count - 1; i > -1; i--)
                //    {
                //        if (set2.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("N"))
                //            set2.Tables[0].Rows.RemoveAt(i);
                //    }

                //    set2.Tables[0].Columns.Remove("SEL_CHECK");

                //    //_WSCOM.ExecuteNonQueryTx("APG_WM20470.SAVE1", set2);  //MES8020에 INSERT

                //    this.AfterInvokeServer();

                //    //DataSet ds = (new Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_WM20420", "INQUERY_PRINT1"), param);
                //    //set2.Tables[0].TableName = "DATA";
                //    //set2.Tables[0].WriteXml(url2 + "/" + report2.ReportName + ".xml", XmlWriteMode.WriteSchema);

                //    HERexSection xmlSection2 = new HERexSection(set2, new HEParameterSet());

                //    report2.Sections.Add("XML", xmlSection2); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

                //    AxRexpertReportViewer.ShowReport(report2);
                //    break;
            }

        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.txt01_PARTNO.Initialize();
                        this.txt01_BARCODE.Initialize();
                        this.txt01_PACK_CASE_NO.Initialize();
                        this.txt01_INVOICE_NO.Initialize();
                        this.dtp01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                        this.dtp01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    case 1:
                        this.grd02.InitializeDataSource();
                        this.txt01_PARTNO.Initialize();
                        this.txt01_BARCODE.Initialize();
                        this.dtp01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                        this.dtp01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            //전체선택 체크박스 선택시 해당 선택값에 따라 모든 체크박스 업데이트 2013.10.28 (배명희)
            if (this.grd01.MouseRow == 0)
            {
                string val = this.grd01.GetValue(0, "SEL_CHECK").ToString();
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.SetValue(i, "SEL_CHECK", val == "Y" ? "1" : "0");
                }
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "USE_YN", "Y");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)  //aa
        {
            try
            {
                //if (e.Row >= this.grd01.Rows.Fixed)
                //{
                //    if (e.Col == this.grd01.Cols["SEL_CHECK"].Index)
                //    {
                //        string SEL_CHECK = this.grd01.GetValue(e.Row, "SEL_CHECK").ToString();
                //        this.grd01.SetValue(e.Row, "SEL_CHECK", "Y");
                //    }
                //}   

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            //전체선택 체크박스 선택시 해당 선택값에 따라 모든 체크박스 업데이트 2013.10.28 (배명희)
            if (this.grd02.MouseRow == 0)
            {
                string val = this.grd02.GetValue(0, "SEL_CHECK").ToString();
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    this.grd02.SetValue(i, "SEL_CHECK", val == "Y" ? "1" : "0");
                }
            }
        }

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.AllowMerging = (this.chk01_MERGE.Checked == true) ?
                         C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                         C1.Win.C1FlexGrid.AllowMergingEnum.None;
                        break;
                    case 1:
                        this.grd02.AllowMerging = (this.chk01_MERGE.Checked == true) ?
                        C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                        C1.Win.C1FlexGrid.AllowMergingEnum.None;
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        private void Grid_Setting()
        {
            try
            {
                for (int i = 1; i < 25; i++)
                {
                    //string Month = this.dte01_SDATE.Value.AddMonths(i - 1).ToString("yyyy-MM");
                    //string VQTY = string.Format("UCOST_{0:D2}", i);
                    ////string MON = string.Format("{0}월 단가", Month);
                    //string MON = string.Format("{0}" + this.GetLabel("MONTH") + " " + this.GetLabel("UCOST"), Month);

                    //this.grd02.SetHeadTitle(0, VQTY, MON);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
    }
}
