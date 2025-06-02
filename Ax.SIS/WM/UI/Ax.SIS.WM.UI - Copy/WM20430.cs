#region ▶ Description & History
/* 
 * 프로그램명 : 자재 입하 등록
 * 설      명 : 
 * 최초작성자 : 김민재
 * 최초작성일 : 2015-02-04
 * 최종수정자 : 김민재
 * 최종수정일 : 2015-02-04
 * 수정  내용 : 
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-02-04		김민재		최초 개발
*/
#endregion
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
    /// Local/ CKD부품식별표 발행
    /// </summary>    
    public partial class WM20430 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        
        private AxComboList grd_LINECD;
        private AxClientProxy _WSCOM;
        private DateTime _tmpDELI_DATE;
        private bool _isSelectedIndexChangedDirectly = true;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;


        private const string _IntFormat = "###,###,###,###,##0";

        public WM20430()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            this.grd_LINECD = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_LINECD_BeforeOpen);
                this.grd_LINECD.SelectedValueChanged += new EventHandler(grd_LINECD_SelectedValueChanged);

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";

                //this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_PLAN_DATE.GetValue());
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                HEParameterSet param = new HEParameterSet();
                param.Add("BIZCD", this.UserInfo.BusinessCode);
               

                #region [ grd01 ]

                this.grd01.AllowEditing = true;
                this.grd01.AutoClipboard = true;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "선택", "SEL_CHECK", "CHK");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "LOTNO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "NOTENO", "NOTENO", "NOTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "PARTNM", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "QTY", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "DELI CNT", "DELI_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "ORDERNO", "ORDERNO", "ORDERNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "VENDCD NO", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "VEND NAME", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "INVOICE_NO", "INVOICE_NO", "INVOICE_NO");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "CASE_NO", "CASE_NO", "CASE_NO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "INV_STATUS", "INV_STATUS", "INV_STATUS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "DOM_IMP_DIV", "DOM_IMP_DIV", "DOM_IMP_DIV");         
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "STOCK_DATE", "STOCK_DATE", "STOCK_DATE");         
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "STOCK_TIME", "STOCK_TIME", "STOCK_TIME");         
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "USER_ID", "USER_ID", "USER_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "EDI_TAG", "EDI_TAG", "EDI_TAG");         
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "PROD_DATE", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재유형", "MAT_TYPE", "MAT_TYPE");
         
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "SEL_CHECK");

                this.grd01.Cols["DELI_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");
                this.grd01.Cols["STOCK_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STOCK_DATE");
                this.grd01.Cols["PROD_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                
                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;

                //전체선택 체크박스
                CellStyle cs = this.grd01.Styles.Add("Boolean");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd01.SetCellStyle(0, this.grd01.Cols["SEL_CHECK"].Index, cs);

                //this.BtnQuery_Click(null, null);
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];
                //this.cbl01_LINECD.DataBind(source2, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명

                #endregion

                DataTable combo_source_PRINT_DIV2 = new DataTable();
                combo_source_PRINT_DIV2.Columns.Add("CODE");
                combo_source_PRINT_DIV2.Columns.Add("NAME");
                combo_source_PRINT_DIV2.Rows.Add("LARGE", "LARGE");
                combo_source_PRINT_DIV2.Rows.Add("MIDDLE", "MIDDLE");
                combo_source_PRINT_DIV2.Rows.Add("SMALL", "SMALL");
                this.cbo01_PRINT_DIV2.DataBind(combo_source_PRINT_DIV2, false);
                this.cbo01_PRINT_DIV2.DropDownStyle = ComboBoxStyle.DropDownList;

                //this.cbo01_PRINT_DIV2.SelectedItem.Value = "MIDDLE";    //SCM          
                this.cbo01_PRINT_DIV2.SelectedIndex = 1;

                DataTable combo_source_PRINT_DIV3 = new DataTable();
                combo_source_PRINT_DIV3.Columns.Add("CODE");
                combo_source_PRINT_DIV3.Columns.Add("NAME");
                combo_source_PRINT_DIV3.Rows.Add("ONE", "ONE PIECE");
                combo_source_PRINT_DIV3.Rows.Add("TWO", "TWO PIECE");
                this.cbo01_PRINT_DIV3.DataBind(combo_source_PRINT_DIV3, false);
                this.cbo01_PRINT_DIV3.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_PRINT_DIV3.SelectedIndex = 0;

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_STOCK_DATE);         

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]


        //private string GetNewLotNo()  //NEWLOTNO
        //{
        //    try
        //    {
        //        HEParameterSet set = new HEParameterSet();
        //        set.Add("CORCD", this.UserInfo.CorporationCode);
        //        set.Add("BIZCD", this.UserInfo.BusinessCode);
        //        set.Add("WORK_DATE", this.dte01_STOCK_DATE.Value.ToString("yyyy-MM-dd"));
        //        set.Add("CLIENT_ID", "ZZ");
        //        //set.Add("LANG_SET", this.UserInfo.Language);                 

        //        DataSet source = _WSCOM.ExecuteDataSet("APG_WM20430.GET_NEWLOT", set);

        //        //return source.Tables[0].ToString();
        //        //return source.Tables["PRINT_SEQ1"].ToString();
        //        //return HEStaticCommon.Nvl(this.Text, "").ToString();
        //        //return source.ToString();
        //        //return ToString(source.Tables[0]);
        //        return source.Tables[0].Rows[0]["NEWLOT"].ToString();
        //    }

        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //        return "";
        //    }
        //}

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


        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string corporationCode = this.UserInfo.CorporationCode;
        //        DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "ARRIVNO");

        //        for (int i = 1; i < this.grd01.Rows.Count; i++)
        //        {
        //            source.Tables[0].Rows.Add
        //            (
        //                corporationCode
        //                , this.cbo01_BIZCD.GetValue()
        //                , this.grd01.GetValue(i, "ARRIVNO")
        //            );
        //        }

        //        if (this.IsRemoveValid(source))
        //        {
        //            _WSCOM.ExecuteNonQueryTx("APG_WM20430.REMOVE", source);

        //            //this.BtnQuery_Click(null, null);
        //            //MsgBox.Show("열람하신 자재입고 정보가 삭제되었습니다.");
        //            MsgCodeBox.Show("CD00-0072"); // 삭제되었습니다.
        //        }
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.Message);
        //    }
        //}

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            if (chkLotno.Checked == true)
            {
                if (string.IsNullOrEmpty(this.txt01_LOTNO.Text) == true)
                {
                    MsgCodeBox.Show("QA02-0034");
                    return;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20430.INQUERY_LOTNO", set);
                this.grd01.SetValue(source.Tables[0]);

                this.AfterInvokeServer();
            }
            else
            {
                try
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("STOCK_DATE", this.dte01_STOCK_DATE.Value.ToString("yyyy-MM-dd"));
                    set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                    set.Add("VENDCD", this.cdx01_VENDCD.GetValue());

                    //LOCAL
                    if (rdo01_A0A.Checked)
                    {
                        set.Add("MAT_KIND", "EKV");
                    }
                    //CKD
                    else
                    {
                        set.Add("MAT_KIND", "EKL");
                    }

                    set.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);

                    DataSet source = _WSCOM.ExecuteDataSet("APG_WM20430.INQUERY", set);
                    this.grd01.SetValue(source.Tables[0]);

                    this.AfterInvokeServer();
                }
                catch (FaultException<ExceptionDetail> ex)
                {
                    this.AfterInvokeServer();
                    MsgBox.Show(ex.Message);
                }
            }
        }

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
            //if (this.cbo01_PRINT_DIV2.GetValue().ToString() == "LARGE")
            //    report.ReportName = "RxRpt/WM20430_R1_L";
            //else if (this.cbo01_PRINT_DIV2.GetValue().ToString() == "MIDDLE")
            //    report.ReportName = "RxRpt/WM20430_R1";
            //else
            //    report.ReportName = "RxRpt/WM20430_R1_S";  

            if (this.cbo01_PRINT_DIV2.GetValue().ToString().Equals("LARGE"))
                if (this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
                    report.ReportName = "RxRpt/WM20430_R1_L";
                else
                    report.ReportName = "RxRpt/WM20430_R1_L2";
            else if (this.cbo01_PRINT_DIV2.GetValue().ToString().Equals("MIDDLE"))
                if (this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
                    report.ReportName = "RxRpt/WM20430_R1";
                else
                    report.ReportName = "RxRpt/WM20430_R12";
            else
                if (this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
                    report.ReportName = "RxRpt/WM20430_R1_S";
                else
                    report.ReportName = "RxRpt/WM20430_R1_S2";

            string url = "C:\\Work\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  

            // Main Section (main report parameter set)
            HERexSection mainSection = new HERexSection();
            mainSection.ReportParameter.Add("PRINT_USER", this.UserInfo.UserID + "(" + this.UserInfo.UserName + ")");
            mainSection.ReportParameter.Add("TEST_PARAM1", "파라메터1");
            mainSection.ReportParameter.Add("TEST_PARAM2", "파라메터2");
            report.Sections.Add("MAIN", mainSection);

            // XML Section (data connection persons) / Parameter: Data set, the report Param (sub-report in the presence of Param)
            HEParameterSet param = new HEParameterSet();
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", this.UserInfo.BusinessCode);
            param.Add("STOCK_DATE", this.dte01_STOCK_DATE.Value.ToString("yyyy-MM-dd"));
            param.Add("CHK1", this.rdo01_A0A.Checked ? "E" : "L");
            param.Add("LOTNO", this.txt01_LOTNO.GetValue());
            param.Add("VENDCD", this.cdx01_VENDCD.GetValue());
            param.Add("LANG_SET", this.UserInfo.Language);

            /* 
                * New report or report columns for design changes when columns defined XML files are calling upon reports
                * To use the generated directly by using the code (note, please produce the following xml file and creates a file reb first sub-report)
                * Parry who, if the name of the DataSet object ds
                * ds.Tables[0].TableName = "DATA";
                * ds.Tables[0].WriteXml(url + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                * Please include the generated XML file is added or modified Shimada source control design for future maintenance. (/ url under the folder)
                * */

            //DataSet ds = (new Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_WM20430", "INQUERY_PRINT"), param);
            //ds.Tables[0].TableName = "DATA";
            //ds.Tables[0].WriteXml(url + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);

            DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                  "SEL_CHECK", "BIZCD", "LOTNO", "NOTENO", "PARTNO", "PARTNM", "QTY", "DELI_DATE", "DELI_CNT", "ORDERNO", "VENDCD", "VENDNM"
                  , "INVOICE_NO", "CASE_NO", "INV_STATUS", "DOM_IMP_DIV", "STOCK_DATE", "STOCK_TIME", "USER_ID", "EDI_TAG", "PROD_DATE", "MAT_TYPE");

            foreach (DataRow row in set.Tables[0].Rows)
            {
                row["BIZCD"] = row["BIZCD"].ToString();
                row["LOTNO"] = row["LOTNO"].ToString();
                row["NOTENO"] = row["NOTENO"].ToString();
                row["PARTNO"] = row["PARTNO"].ToString();
                row["PARTNM"] = row["PARTNM"].ToString();
                row["QTY"] = row["QTY"].ToString();
                row["DELI_DATE"] = row["DELI_DATE"].ToString();
                row["DELI_CNT"] = row["DELI_CNT"].ToString();
                row["ORDERNO"] = row["ORDERNO"].ToString();
                row["VENDCD"] = row["VENDCD"].ToString();
                row["VENDNM"] = row["VENDNM"].ToString();
                row["INVOICE_NO"] = row["INVOICE_NO"].ToString();
                row["CASE_NO"] = row["CASE_NO"].ToString();
                row["INV_STATUS"] = row["INV_STATUS"].ToString();
                row["DOM_IMP_DIV"] = row["DOM_IMP_DIV"].ToString();
                row["STOCK_DATE"] = row["STOCK_DATE"].ToString();
                row["STOCK_TIME"] = row["STOCK_TIME"].ToString();
                row["USER_ID"] = row["USER_ID"].ToString();
                row["EDI_TAG"] = row["EDI_TAG"].ToString();
                row["PROD_DATE"] = row["PROD_DATE"].ToString();
                row["MAT_TYPE"] = row["MAT_TYPE"].ToString();      

                //row["EMPNO"] = this.UserInfo.EmpNo;
                //row["LANG_SET"] = this.UserInfo.Language;       
            }

            for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
            {
                if (set.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("N"))
                    set.Tables[0].Rows.RemoveAt(i);
            }

            set.Tables[0].Columns.Remove("SEL_CHECK");

            this.AfterInvokeServer();

            //DataSet ds = (new Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_WM20420", "INQUERY_PRINT1"), param);
            //set.Tables[0].TableName = "DATA";
            //set.Tables[0].WriteXml(url + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);

            HERexSection xmlSection = new HERexSection(set, new HEParameterSet());

            report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

            AxRexpertReportViewer.ShowReport(report);
        }
        
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //this.dte01_REQ_DATE.Initialize();
                //this.cdx01_VENDCD.Initialize();
                //this.cbo01_LINECD.InitializeDataSource();
                //this.dte01_ARRIV_DATE.Initialize();
                //this.txt01_ARRIV_TIME.SetValue(DateTime.Now.ToString("HH:mm"));
                //this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_LINECD();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dte01_DELI_DATE_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if (this._tmpDELI_DATE != Convert.ToDateTime(this.dte01_STOCK_DATE.GetValue()))
                {
                    this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_STOCK_DATE.GetValue());
                    this.Bind_cbo01_LINECD();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dte01_DELI_DATE_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this._tmpDELI_DATE != Convert.ToDateTime(this.dte01_STOCK_DATE.GetValue()))
                {
                    this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_STOCK_DATE.GetValue());
                    this.Bind_cbo01_LINECD();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cdx01_VENDCD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_LINECD();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_MAT_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //this.Bind_cbo01_LINECD();

                //if (Convert.ToString(this.cbo01_MAT_TYPE.GetValue()) == "EAR")
                //    this.btn01_REG_RESALE.SetReadOnly(false);
                //else
                //    this.btn01_REG_RESALE.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_YARDCD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_LINECD();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_LINECD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this._isSelectedIndexChangedDirectly)
                {
                    //this.BtnQuery_Click(null, null);
                }
                else
                {
                    this._isSelectedIndexChangedDirectly = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
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

        private void btn01_REG_RESALE_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region [사용자 정의 메서드]

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                //if (e.Row >= this.grd01.Rows.Fixed)
                //{
                //    if (e.Col == this.grd01.Cols["WHNM"].Index)
                //    {
                //        string INSPEC_DIVNM = this.grd01.GetValue(e.Row, "WHNM").ToString();
                //        this.grd01.SetValue(e.Row, "WHCD", INSPEC_DIVNM);
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

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



        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source == null || source.Tables.Count == 0 || source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 자재입고 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0042"); // 저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                if (this.cbo01_BIZCD.IsEmpty)
                {
                    //MsgBox.Show("사업장코드를 선택하세요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
                    return false;
                }

                //if (this.cdx01_VENDCD.IsEmpty)
                //{
                //    //MsgBox.Show("업체코드를 입력하세요.");
                //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_VENDCD.Text);
                //    return false;
                //}

                //if (this.cbo01_MAT_TYPE.IsEmpty)
                //{
                //    //MsgBox.Show("자재유형을 입력하세요.");
                //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_MAT_TYPE.Text);
                //    return false;
                //}

                //if (this.cbo01_YARDCD.IsEmpty)
                //{
                //    //MsgBox.Show("자재창고를 입력하세요.");
                //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_MAT_YARD.Text);
                //    return false;
                //}

                //if (this.cbo01_LINECD.IsEmpty)
                //{
                //    //MsgBox.Show("납품차수를 입력하세요.");
                //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_PRINT_SEQ.Text);
                //    return false;
                //}

                //if (this.txt01_ARRIV_TIME.IsEmpty)
                //{
                //    //MsgBox.Show("입하시간을 입력하세요.");
                //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_ARRIVE_DATE1.Text);
                //    return false;
                //}

                //string[] tmpARRIV_TIME = Convert.ToString(this.txt01_ARRIV_TIME.GetValue()).Split(':');
                int tmpHour = -1;
                int tmpMin = -1;

                //if (tmpARRIV_TIME.Length != 2 || tmpARRIV_TIME[0].Length != 2 || tmpARRIV_TIME[1].Length != 2)
                //{
                //    //MsgBox.Show("입하시간이 올바르지 않습니다.");
                //    MsgCodeBox.Show("MM02-0001");
                //    return false;
                //}

                //tmpHour = int.TryParse(tmpARRIV_TIME[0], out tmpHour) ? tmpHour : -1;
                //tmpMin = int.TryParse(tmpARRIV_TIME[1], out tmpMin) ? tmpMin : -1;

                //if (tmpHour < 0 || tmpHour > 23 || tmpMin < 0 || tmpMin > 59)
                //{
                //    //MsgBox.Show("입하시간이 올바르지 않습니다.");
                //    MsgCodeBox.Show("MM02-0001");
                //    return false;
                //}

                //int tmpARRIV_QTY = 0;
                //foreach (DataRow dr in source.Tables[0].Rows)
                //{
                //    tmpARRIV_QTY = int.TryParse(Convert.ToString(dr["ARRIV_QTY"]), out tmpARRIV_QTY) ? tmpARRIV_QTY : 0;
                //    if (tmpARRIV_QTY < 0)
                //    {
                //        //if (MsgBox.Show(string.Format(@"[{0}]의 합격수량이 0보다 작습니다. 계속 하시겠습니까?", dr["PARTNO"]), "경고", MessageBoxButtons.OKCancel)
                //        //    != DialogResult.OK)
                //        if (MsgCodeBox.ShowFormat("MM02-0002", MessageBoxButtons.OKCancel, dr["PARTNO"]) != DialogResult.OK)
                //        {
                //            return false;
                //        }
                //    }
                //}

                //if (MsgBox.Show("입력하신 자재입고 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //{
                //    return false;
                //}
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
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

        private bool IsSaveValid2(DataSet source)
        {
            try
            {
                if (source == null || source.Tables.Count == 0 || source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 자재입고 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0042"); // 저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                //string[] tmpARRIV_TIME = Convert.ToString(this.txt01_ARRIV_TIME.GetValue()).Split(':');
                int tmpHour = -1;
                int tmpMin = -1;

                //if (tmpARRIV_TIME.Length != 2 || tmpARRIV_TIME[0].Length != 2 || tmpARRIV_TIME[1].Length != 2)
                //{
                //    //MsgBox.Show("입하시간이 올바르지 않습니다.");
                //    MsgCodeBox.Show("MM02-0001");
                //    return false;
                //}

                //tmpHour = int.TryParse(tmpARRIV_TIME[0], out tmpHour) ? tmpHour : -1;
                //tmpMin = int.TryParse(tmpARRIV_TIME[1], out tmpMin) ? tmpMin : -1;

                if (tmpHour < 0 || tmpHour > 23 || tmpMin < 0 || tmpMin > 59)
                {
                    //MsgBox.Show("입하시간이 올바르지 않습니다.");
                    MsgCodeBox.Show("MM02-0001");
                    return false;
                }

                int tmpARRIV_QTY = 0;
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    tmpARRIV_QTY = int.TryParse(Convert.ToString(dr["ARRIV_QTY"]), out tmpARRIV_QTY) ? tmpARRIV_QTY : 0;
                    if (tmpARRIV_QTY < 0)
                    {
                        //if (MsgBox.Show(string.Format(@"[{0}]의 합격수량이 0보다 작습니다. 계속 하시겠습니까?", dr["PARTNO"]), "경고", MessageBoxButtons.OKCancel)
                        //    != DialogResult.OK)
                        if (MsgCodeBox.ShowFormat("MM02-0002", MessageBoxButtons.OKCancel, dr["PARTNO"]) != DialogResult.OK)
                        {
                            return false;
                        }
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

        private bool IsRemoveValid(DataSet source)
        {
            try
            {
                if (source == null || source.Tables.Count == 0 || source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 자재입고 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0041"); // 삭제할 데이터가 존재하지 않습니다.
                    return false;
                }

                if (string.IsNullOrEmpty(Convert.ToString(source.Tables[0].Rows[0]["ARRIVNO"])))
                {
                    //MsgBox.Show("삭제할 자재입고 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0041"); // 삭제할 데이터가 존재하지 않습니다.
                    return false;
                }

                //if (MsgBox.Show("자재입고 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //{
                //    return false;
                //}
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
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

        private bool IsQueryValid(HEParameterSet param)
        {
            try
            {
                if (param["BIZCD"] == null || string.IsNullOrEmpty(Convert.ToString(param["BIZCD"])))
                {
                    //MsgBox.Show("검색할 사업장코드가 없습니다.");
                    MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_BIZNM.Text);
                    return false;
                }

                if (param["DELI_DATE"] == null || string.IsNullOrEmpty(Convert.ToString(param["DELI_DATE"])))
                {
                    //MsgBox.Show("검색할 납품일자가 없습니다.");
                    MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_STOCK_DATE.Text);
                    return false;
                }

                if (param["VENDCD"] == null || string.IsNullOrEmpty(Convert.ToString(param["VENDCD"])))
                {
                    //MsgBox.Show("검색할 업체코드가 없습니다.");
                    //MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_VENDCD.Text);
                    return false;
                }

                if (param["PRINT_SEQ"] == null || string.IsNullOrEmpty(Convert.ToString(param["PRINT_SEQ"])))
                {
                    //MsgBox.Show("검색할 납품차수가 없습니다.");
                    //MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_PRINT_SEQ.Text);
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

        private void Bind_cbo01_LINECD()   //aaa
        {
            //this.cbl01_LINECD.Text = string.Empty;

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", this.UserInfo.CorporationCode);
            paramSet.Add("BIZCD", this.UserInfo.BusinessCode);
            paramSet.Add("REQ_DATE", this.dte01_STOCK_DATE.GetDateText());
            paramSet.Add("LANG_SET", this.UserInfo.Language);

            //using (DataSet ds = _WSCOM.ExecuteDataSet("APG_WM20430.INQUERY_PRINT_SEQ", paramSet))
            //{
            //    if (ds != null && ds.Tables.Count > 0)
            //    {
            //        this._isSelectedIndexChangedDirectly = false;
            //        this.cbo01_LINECD.DataBind(ds.Tables[0], false);

            //        //this.BtnQuery_Click(null, null);          //aaaa            
            //    }
            //}

            //this.dte01_ARRIV_DATE.Initialize();
            //this.txt01_ARRIV_TIME.SetValue(DateTime.Now.ToString("HH:mm"));
            //this.grd01.SetValue(new DataTable());
        }

        #endregion



        //private SerialPort comport = new SerialPort();
        //private void PD20430_Load(object sender, EventArgs e)
        //{
        //    comport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);

        //    //cmbParity.Items.Clear(); 
        //    //cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
        //    //cmbStopBits.Items.Clear(); 
        //    //cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

        //    //cmbPortName.SelectedItem = "None";
        //    //cmbStopBits.SelectedItem = "One";
        //    //cmbDataBits.SelectedItem = "8";
        //    //cmbParity.SelectedItem   = "None";
        //    //cmbBaudRate.SelectedItem = "9600";

        //    //string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

        //    //if (!String.IsNullOrEmpty(selected))
        //    //{
        //    //    //cmbPortName.Items.Clear();
        //    //    //cmbPortName.Items.AddRange(OrderedPortNames());
        //    //    //cmbPortName.SelectedItem = selected;
        //    //}

        //    //EnableControls();

        //    //if (comport.IsOpen)
        //    //    comport.Close();
        //}

        ////private void comport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        ////{
        ////    if (!comport.IsOpen) return;

        ////    System.Threading.Thread.Sleep(200);
        ////    string data = comport.ReadExisting();
        ////    this.Log(data);
        ////}

        ////private void EnableControls()
        ////{
        ////    gbPortSettings.Enabled = !comport.IsOpen;
        ////    if (comport.IsOpen) btnOpenPort.Text = "&Close Port";
        ////    else btnOpenPort.Text = "&Open Port";
        ////}

        //private string[] OrderedPortNames()
        //{
        //    int num;
        //    string[] temp = SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        //    string[] new_temp = new string[temp.Length];
        //    for (int i = temp.Length - 1; i >= 0; i--)
        //        new_temp[(temp.Length - 1) - i] = temp[i];

        //    return new_temp;
        //}

        //private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        //{
        //    string selected = null;
        //    string[] ports = SerialPort.GetPortNames();
        //    bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

        //    if (updated)
        //    {
        //        ports = OrderedPortNames();

        //        string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

        //        if (PortOpen)
        //        {
        //            if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
        //            else if (!String.IsNullOrEmpty(newest)) selected = newest;
        //            else selected = ports.LastOrDefault();
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(newest)) selected = newest;
        //            else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
        //            else selected = ports.LastOrDefault();
        //        }
        //    }

        //    return selected;
        //}

        //private void btnOpenPort_Click(object sender, EventArgs e)
        //{
        //    bool error = false;

        //    if (comport.IsOpen)
        //    {
        //        comport.Close();
        //        txt01_barcode.Text = "";
        //    }
        //    else
        //    {
        //        comport.BaudRate = int.Parse(cmbBaudRate.Text);
        //        comport.DataBits = int.Parse(cmbDataBits.Text);
        //        comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
        //        comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
        //        comport.PortName = cmbPortName.Text;

        //        try
        //        {
        //            comport.Open();
        //        }
        //        catch (UnauthorizedAccessException) { error = true; }
        //        catch (IOException) { error = true; }
        //        catch (ArgumentException) { error = true; }

        //        if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible",
        //            MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }

        //    EnableControls();
        //}

        //private void txt01_barcode_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.txt01_barcode.Text.Length >= 15)
        //    {
        //        string barcode_no = this.txt01_barcode.Text.Trim();
        //        string prefix = barcode_no.Substring(00, 1);
        //        string yymmdd = barcode_no.Substring(01, 6);
        //        string vendcd = barcode_no.Substring(07, 6);
        //        string number = barcode_no.Substring(13, 2);

        //        if (this.txt01_barcode.Text.Trim().Length >= 20)
        //        {
        //            string mat_type = barcode_no.Substring(15, 3);
        //            string yardcd = barcode_no.Substring(18, 2);

        //            //this.cbo01_MAT_TYPE.SetValue(mat_type);
        //            //this.cbo01_YARDCD.SetValue(yardcd);
        //        }

        //        //this.dte01_REQ_DATE.SetValue("20" + yymmdd);
        //        //this.cdx01_VENDCD.SetValue(vendcd);
        //        //this.cbo01_LINECD.SetValue(int.Parse(number).ToString());

        //        //this.BtnQuery_Click(null, null);
        //        //this.BtnSave_Click();
        //    }
        //}

        //private void Log(string msg)
        //{
        //    this.txt01_barcode.Invoke(new EventHandler(delegate
        //    {
        //        if (this.txt01_barcode.Text.Length >= 15)
        //            this.txt01_barcode.Text = "";

        //        this.txt01_barcode.AppendText(msg);
        //    }));
        //}

        //protected override void BtnClose_Click(object sender, EventArgs e)
        //{
        //    if (comport.IsOpen)
        //        comport.Close();

        //    base.BtnClose_Click(sender, e);
        //}


        //private void dte01_REQ_DATE_ValueChanged(object sender, EventArgs e)
        //{
        //    //this.Bind_cbo01_LINECD();   //차수 재조정
        //    this.BtnQuery_Click(null, null);
        //}


        void grd_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                //set.Add("PRDT_DIV", this.cbl01_LINECD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_LINE_LIST", set).Tables[0];

                this.grd_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "LINECD", this.grd_LINECD.GetValue("LINECD"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_LINECD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this._isSelectedIndexChangedDirectly)
                {
                    //this.BtnQuery_Click(null, null);
                }
                else
                {
                    this._isSelectedIndexChangedDirectly = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dte01_PLAN_DATE_ValueChanged(object sender, EventArgs e)
        {
            //this.BtnQuery_Click(null, null);
        }

        private void rdo01_A0A_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdo01_A0S_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}