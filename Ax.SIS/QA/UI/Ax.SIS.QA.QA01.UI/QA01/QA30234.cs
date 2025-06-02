/* 
 * 프로그램명 : 완제품폐기 종합현황 조회
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014.07.02      배명희     최초 클래스 생성
 *              2015-07-28      배명희      통합WCF로 변경
*/
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
  
    public partial class QA30234 : AxCommonBaseControl
    {
        //private IQA30234 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
       // private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30234";

        #region [ 초기화 작업 정의 ]

        public QA30234()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30234>("QA01", "QA30234.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");

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
                //this._buttonsControl.BtnPrint.Visible = true;
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


                this.grd01_QA30234.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd01_QA30234.AllowEditing = false;
                this.grd01_QA30234.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30234.Initialize(false);
                this.grd01_QA30234.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA30234.Cols.Count = this.grd01_QA30234.Cols.Fixed;
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "고객코드", "CUSTCD", "CUSTCD");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "고객명", "CUSTNM", "CUSTNM");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "차종", "VINCD","VIN");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품목", "ITEMNM","ITEM");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNM");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "입고수량", "DELI_QTY", "RCV_QTY");
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량수량", "RTN_QTY", "DEF_QTY");                
                this.grd01_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "PPM", "PPM");
                this.grd01_QA30234.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "ORDER2", "ORDER2");
                this.grd01_QA30234.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELI_QTY");
                this.grd01_QA30234.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_QTY");
                this.grd01_QA30234.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM");
                this.grd01_QA30234.Cols["PPM"].Format = "###,###,###,###,###.0";
                this.grd01_QA30234.Cols["CUSTCD"].AllowMerging = true;
                this.grd01_QA30234.Cols["CUSTNM"].AllowMerging = true;

                this.grd02_QA30234.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd02_QA30234.AllowEditing = false;
                this.grd02_QA30234.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30234.Initialize(false);
                this.grd02_QA30234.AllowSorting = AllowSortingEnum.None;

                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "등록일자", "RCV_DATE", "REG_DATE");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "고객코드", "CUSTCD", "CUSTCD");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "고객명", "CUSTNM", "CUSTNM");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발생일자", "RTN_DATE", "OCCUR_DATE");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  70, "차종", "VINCD","VIN");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품목", "ITEMNM","ITEM");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "불량코드", "DEFCD", "DEFCD");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량유형", "DEFNM", "DEFNM");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량수량", "RTN_QTY", "DEF_QTY");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "발생장소", "RTN_AREA", "RTN_AREA");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "조치내용", "CNTTCD", "MGRT_CNTT");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "시스템", "GENERATER","SYSTEM");
                this.grd02_QA30234.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "비고", "REMARK", "REMARK");

                this.grd02_QA30234.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_QTY");
                this.grd02_QA30234.SetColumnType(AxFlexGrid.FCellType.Date, "RTN_DATE");
                this.grd02_QA30234.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_REG_DATE);

                this.BtnReset_Click(null, null);

                //this.dte01_RCV_DATE_FROM.SetMMFromStart();
                this.dte01_RCV_DATE_FROM.SetValue(this.dte01_RCV_DATE_FROM.GetDateText().Substring(0, 8) + "01");
                
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
                this.grd01_QA30234.InitializeDataSource();
                this.grd02_QA30234.InitializeDataSource();
              
           
                this.chk01_DEFECT_DESC_SEARCH.Checked = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string RCV_DATE_FROM = this.dte01_RCV_DATE_FROM.GetDateText();
                string RCV_DATE_TO = this.dte01_RCV_DATE_TO.GetDateText();
               
                string DEF_YN = this.chk01_DEFECT_DESC_SEARCH.GetValue().ToString().Equals("Y") ? "1" : "0";
              
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("BEG_DATE", RCV_DATE_FROM);
                paramSet.Add("END_DATE", RCV_DATE_TO);
            
                paramSet.Add("BAD_ONLY", DEF_YN);
                paramSet.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();

             
                //source = _WSCOM.Inquery(paramSet);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.grd01_QA30234.SetValue(source);
                this.grd02_QA30234.InitializeDataSource();
                

                this.AfterInvokeServer();

                this.grd_COROL(grd01_QA30234);
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

        #region [사용자 정의 메서드]

        private void grd_COROL(AxFlexGrid grd)
        {
            if (grd.Rows.Count >= grd.Rows.Fixed)
            {
                grd.Styles.Add("COLOR_W").BackColor = Color.FromArgb(255, 255, 255);
                grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
                grd.Styles.Add("COLOR_G").BackColor = Color.FromArgb(200, 255, 200);
                grd.Styles.Add("COLOR_Y").BackColor = Color.FromArgb(255, 255, 200);

                CellRange cr = new CellRange();

                for (int i = 1; i < grd.Rows.Count; i++)
                {
                    switch (grd.GetValue(i, "ORDER2").ToString())
                    {
                        case "2":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_B"];
                            break;
                        case "3":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_G"];
                            break;
                        case "4":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_Y"];
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        #endregion

        #region [그리드 이벤트]

        private void grd01_QA30234_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int r = this.grd01_QA30234.MouseRow;
            if (r < this.grd01_QA30234.Rows.Fixed || r >= this.grd01_QA30234.Rows.Count)
            {
                this.grd02_QA30234.InitializeDataSource();
                return;
            }


            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string RCV_DATE_FROM = this.dte01_RCV_DATE_FROM.GetDateText().ToString();
                string RCV_DATE_TO = this.dte01_RCV_DATE_TO.GetDateText().ToString();

                string CUSTCD = this.grd01_QA30234.GetValue(r, "CUSTCD").ToString();
                string PARTNO = this.grd01_QA30234.GetValue(r, "PARTNO").ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("BEG_DATE", RCV_DATE_FROM);
                paramSet.Add("END_DATE", RCV_DATE_TO);

                paramSet.Add("CUSTCD", CUSTCD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();


                //source = _WSCOM.Inquery_Detail(paramSet);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);

                this.grd02_QA30234.SetValue(source);

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

        #region [ 기타 이벤트 ]

        private void btn01_CUSTOMER_MGMT_Click(object sender, EventArgs e)
        {
            QA30234P1 control = new QA30234P1();            
            PopupHelper helper = new PopupHelper(control, this.GetLabel("QA30234P1"));
            helper.ShowDialog(false);
        }

        #endregion
    }
}
