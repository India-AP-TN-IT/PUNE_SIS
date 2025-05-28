#region ▶ Description & History

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

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b></b>
    /// - 작 성 자 : 이현범<br />
    /// - 작 성 일 : 2015-06-23 오후 5:29:52<br />
    /// </summary>
    public partial class QA30117 : AxCommonBaseControl
    {
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM;
        //private byte[] _FILE;

        public QA30117()
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
                this.heDockingTab1.PanelWidth = 272;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                DataTable ds = new DataTable();
                ds.Columns.Add("CODE");
                ds.Columns.Add("NAME");
                ds.Rows.Add("ALL OK", "ALL OK");
                ds.Rows.Add("Inspection NG", "Inspection NG");
                this.cbo01_INS_RSLT.DataBind(ds);
                this.cbo01_INS_RSLT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable ds1 = new DataTable();
                ds1.Columns.Add("ALL");
                ds1.Columns.Add("LOCAL");
                ds1.Columns.Add("SUBKD");
                ds1.Rows.Add("%", "ALL");
                ds1.Rows.Add("LP", "L/P");
                ds1.Rows.Add("KD", "SUB/KD");
                this.cbo01_MAT_DIV.DataBind(ds1);
                this.cbo01_MAT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                #region [ grd01 ]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize(false);
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.Cols.Count = this.grd01.Cols.Fixed;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Business Code", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "검사번호", "INSPECTNO", "INSPECTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Deli Date", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Vender Code", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Vender Name", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "Note No", "NOTENO", "NOTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Deli.Count", "DELI_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PARTNM", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Line Code", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Line Name", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Inspect Date", "INSPECT_DATE", "INSPECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Inspect Time", "INSPECT_TIME", "INSPECT_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Inspector", "INSPECT_EMPNO", "INSPECT_EMPNONM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "LOT NO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Inspect Result", "INSPECT_RSLT", "INSPECT_RSLT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Receipt Qty", "RCV_QTY", "RCV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Passed Qty", "OK_QTY", "OK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Defect Qty", "DEF_QTY", "DEF_QTY");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "PPM", "PPM", "PPM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "Defect code", "DEFCD", "DEFCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Defect name", "DEFNM", "DEFNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Depect Description", "DEF_CNTT", "DEF_CNTT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "BARCODE", "BARCODE", "BARCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Position code", "DEFPOSCD", "DEFPOSCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Position name", "DEFPOSNM", "DEFPOSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Plant Div", "PLANT_DIV", "PLANT_DIV");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPECT_DATE");
                //this.grd01.Cols["INSPECT_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");
                //this.grd01.Cols["DELI_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RCV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM");
                //this.grd01.Cols["PPM"].Format = "###,###,###,###,###.#";
                //this.grd01.Cols["RCV_QTY"].Format = "###,###,###,###,##0";
                //this.grd01.Cols["OK_QTY"].Format = "###,###,###,###,##0";
                //this.grd01.Cols["DEF_QTY"].Format = "###,###,###,###,##0";

                #endregion

                #region [ grd02 ]

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.SelectionMode = SelectionModeEnum.Cell;
                this.grd02.Initialize();
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "_법인코드", "CORCD", "CORCD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "_사업장코드", "BIZCD", "BIZCD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "검사번호", "INSPECTNO", "INSPECTNO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Seq", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "Insp Class code", "INSPECT_CLASSCD", "INSPECT_CLASSCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Insp Class name", "INSPECT_CLASSNM", "INSPECT_CLASSNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "Insp Cnt", "INSPECT_CNT", "INSPECT_CNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Line Code", "LINECD", "LINECD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Line Name", "LINENM", "LINENM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "LOTNO", "LOTNO", "LOTNO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Insp Result", "INSPECT_RSLT", "INSPECT_RSLT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "Jud Result", "JUD_RESULT", "JUD_RESULT");

                #endregion

                this.SetRequired(lbl01_BIZNM, lbl01_INSPECT_DATE);

                this.dte01_FROM_DATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_TO_DATE.SetValue(DateTime.Now);

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
                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();
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
                string FROM_DATE = this.dte01_FROM_DATE.Value.ToString("yyyy-MM-dd");
                string TO_DATE = this.dte01_TO_DATE.Value.ToString("yyyy-MM-dd");
                string INSPECT_RSLT = this.cbo01_INS_RSLT.GetValue().ToString();
                string MAT_DIV = this.cbo01_MAT_DIV.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("FROM_DATE", FROM_DATE);
                paramSet.Add("TO_DATE", TO_DATE);
                paramSet.Add("INSPECT_RSLT", INSPECT_RSLT);
                paramSet.Add("MAT_DIV", MAT_DIV);
                paramSet.Add("LANG_SET", UserInfo.Language);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();

                //source = _WSCOM.Inquery(paramSet);
                source = _WSCOM.ExecuteDataSet("APG_QA30117.INQUERY", paramSet);

                this.grd01.SetValue(source);
                this.grd02.InitializeDataSource();

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

        #region [사용자 정의 메서드]
        
        #endregion

        #region [그리드 이벤트]

        private void grd01_QA30117_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int r = this.grd01.SelectedRowIndex;
            int c = this.grd01.ColSel;
            if (r < this.grd01.Rows.Fixed || r >= this.grd01.Rows.Count)
            {
                this.grd02.InitializeDataSource();
                return;
            }

            try
            {
                string BIZCD = this.grd01.Rows[r]["BIZCD"].ToString();
                string INSPECTNO = this.grd01.Rows[r]["INSPECTNO"].ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECTNO", INSPECTNO);
                paramSet.Add("LANG_SET", UserInfo.Language);
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();

                source = _WSCOM.ExecuteDataSet("APG_QA30117.INQUERY_DETAIL", paramSet);

                this.grd02.SetValue(source);

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

        #endregion}
    }
}
