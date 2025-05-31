#region ▶ Description & History
/* 
 * 프로그램명 : WM30240 LOT 입출고 이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2019-06-19      손창현      최초 개발
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.SIS.CM.UI;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// <b>LOT 입출고 이력 조회</b>
    /// </summary>
    public partial class WM30320 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_WM30320";

        #region [ 초기화 작업 정의 ]

        public WM30320()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
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
                cdx01_VENDCD.HEPopupHelper = new CM20017P1();
                cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                cdx01_VENDCD.CodeParameterName = "VENDCD";
                cdx01_VENDCD.NameParameterName = "VENDNM";
                cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "CORCD", "CORCD");      // 하부 그리드 데이터 전달용
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD");      // 하부 그리드 데이터 전달용
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "SAP GR Date", "GRN_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Supplier", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "Supplier Name", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Delivery Note", "DELI_NOTE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "P/O No", "PONO");
                //this.grd01.AddColumn(FALSE, true, AxFlexGrid.FtextAlign.C, 70, "P/O Seq", "PONO_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part No", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Part Name", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Unit", "PO_UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SAP GR Qty(A)", "GRN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "WMS Scan Qty(B)", "SIS_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Diff Qty(A-B)", "DIFF_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "GRN_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "GRN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SIS_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DIFF_QTY");
                this.grd01.Cols["GRN_QTY"].Format = "#,##0";
                this.grd01.Cols["SIS_QTY"].Format = "#,##0";
                this.grd01.Cols["DIFF_QTY"].Format = "#,##0";

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;
                
                
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Supplier", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "Delivery Note", "DELI_NOTE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "SCM Box TagNo", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "P/O No", "PONO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "P/O Seq", "PONO_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "Part No", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Unit", "PO_UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "SCM Issue Qty(A)", "ISSUE_QTY", "ISSUE_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "WMS Scan Qty(B)", "SCANNED_QTY", "SCANNED_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "Diff Qty(A-B)", "DIFF_QTY", "DIFF_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Work Date", "WORK_DATE", "WORK_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Work Time", "WORK_TIME", "WORK_TIME");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "ISSUE_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "SCANNED_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "DIFF_QTY");
                this.grd02.Cols["ISSUE_QTY"].Format = "#,##0";
                this.grd02.Cols["SCANNED_QTY"].Format = "#,##0";
                this.grd02.Cols["DIFF_QTY"].Format = "#,##0";

                this.grd02.CurrentContextMenu.Items[0].Visible = false;
                this.grd02.CurrentContextMenu.Items[1].Visible = false;
                this.grd02.CurrentContextMenu.Items[2].Visible = false;
                this.grd02.CurrentContextMenu.Items[3].Visible = false;

                this.dtp01_SDATE.SetValue(System.DateTime.Now.ToString("yyyy-MM") + "-01");
                this.dtp01_EDATE.SetValue(System.DateTime.Now.ToString("yyyy-MM-dd"));
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
                //string lotno = this.txt01_LOTNO.GetValue().ToString().Trim();
                //string partno = this.txt01_PARTNO.GetValue().ToString().Trim();
                //string dom_imp_div = this.cbo01_DOM_IMP_DIV.GetValue().ToString();

                //if (lotno.Length == 0 && partno.Length == 0 && dom_imp_div.Length == 0)
                //{
                //    MsgCodeBox.Show("COM-00030");
                //    return;
                //}

                this.grd02.InitializeDataSource();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);

                set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                set.Add("BEG_DATE", this.dtp01_SDATE.GetValue());
                set.Add("END_DATE", this.dtp01_EDATE.GetValue());
                set.Add("PONO",  this.txt01_PONO.GetValue());
                set.Add("DELI_NOTE", this.txt01_DELI_NOTE.GetValue());
                set.Add("DIFF_ONLY", this.chk01_DifferentOnly.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString().ToUpper());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.grd02.InitializeDataSource();
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

        #region [ 기타 이벤트 정의 ]

        private void grd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.grd01.GetValue(row, "CORCD"));
                set.Add("BIZCD", this.grd01.GetValue(row, "BIZCD"));
                set.Add("PONO",  this.grd01.GetValue(row, "PONO"));
                set.Add("PARTNO", this.grd01.GetValue(row, "PARTNO"));
                set.Add("DELI_NOTE", this.grd01.GetValue(row, "DELI_NOTE"));
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR");
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

        #endregion
    }
}
