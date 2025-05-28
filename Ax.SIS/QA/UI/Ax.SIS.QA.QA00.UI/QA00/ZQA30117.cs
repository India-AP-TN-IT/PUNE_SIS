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
    public partial class ZQA30117 : AxCommonBaseControl
    {
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM;
        //private byte[] _FILE;

        public ZQA30117()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel3;
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
                this.dte01_TO_DATE.Visible = true;
                this.lbl01_MAT_DIV.Visible = true;
                this.cbo01_MAT_DIV.Visible = true;
                this.lbl01_SHIFT.Visible = false;
                this.cbo01_SHIFT.Visible = false;
                this.heLabel2.Visible = true;

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                DataTable ds = new DataTable();
                ds.Columns.Add("CODE");
                ds.Columns.Add("NAME");
                ds.Rows.Add("ALL OK", "ALL OK");
                ds.Rows.Add("Inspection NG", "Inspection NG");
                ds.Rows.Add("Rework Done", "Rework Done");
                this.cbo01_INS_RSLT.DataBind(ds);
                this.cbo01_INS_RSLT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable ds3 = new DataTable();
                ds3.Columns.Add("CODE");
                ds3.Columns.Add("NAME");
                ds3.Rows.Add("1", "Shift 1");
                ds3.Rows.Add("2", "Shift 2");
                ds3.Rows.Add("3", "Shift 3");
                this.cbo01_SHIFT.DataBind(ds3);
                this.cbo01_SHIFT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable ds4 = new DataTable();
                ds4.Columns.Add("CODE");
                ds4.Columns.Add("NAME");
                ds4.Rows.Add("BLOCK A", "BLOCK A");
                ds4.Rows.Add("BLOCK B", "BLOCK B");
                this.cbo01_BLOCK.DataBind(ds4);
                this.cbo01_BLOCK.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable ds1 = new DataTable();
                ds1.Columns.Add("ALL");
                ds1.Columns.Add("LOCAL");
                ds1.Columns.Add("SUBKD");
                ds1.Rows.Add("%", "ALL");
                ds1.Rows.Add("LP", "L/P");
                ds1.Rows.Add("KD", "SUB/KD");
                this.cbo01_MAT_DIV.DataBind(ds1);
                this.cbo01_MAT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_VINCD.DataBind("A3");


                DataSet source_PLANT_DIV = this.GetTypeCode("U9");
                this.cbo01_PLANT_DIV.DataBindCodeName(source_PLANT_DIV.Tables[0], false);

                //this.cdx01_VENDCD.HEPopupHelper = new CM20017P1(this.cdx01_VENDCD);
                //this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"업체코드";

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                #region [ grd01 ]

                this.grd01.AllowEditing = true;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.Cols.Count = this.grd01.Cols.Fixed;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "InspectNo", "INSPECTNO", "INSPECTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "DeliDate", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "Supplier", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "SupplierName", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "Note No", "NOTENO", "NOTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "DeliCnt", "DELI_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 115, "Part No", "PARTNO", "PARNTO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 175, "Part Name", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "IncomeQty", "RCV_QTY", "RCV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "SampleQty", "ZSMP_QTY", "SMP_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "PassedQty", "OK_QTY", "OK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "DefectQty", "DEF_QTY", "DEF_QTY");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Rework Qty", "RE_DONE", "RE_DONE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 075, "Rework OK", "RE_OK_QTY", "RE_OK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Rework NG", "RE_DEF_QTY", "RE_DEF_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "Direct OK", "D_OK_QTY", "D_OK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "Direct NG", "D_DEF_QTY", "D_DEF_QTY");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 065, "PPM", "PPM", "PPM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "Defect", "DEFCD", "DEFCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Defectname", "DEFNM", "DEFNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Defect Remark", "DEF_CNTT", "DEF_CNTT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "BLOCK", "PLANT_BLOCK", "PLANT_BLOCK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "Lot No", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "InspectResult", "INSPECT_RSLT", "INSPECT_RSLT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "InspectDate", "INSPECT_DATE", "INSPECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "InspectTime", "INSPECT_TIME", "INSPECT_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Inspector", "ZINSPECT_EMPNM", "INSPECT_EMPNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "PlantDiv", "PLANT_DIV", "PLANT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "Barcode", "BARCODE", "BARCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Car Model", "VINCD", "VINCD");

                this.grd01.Cols["INSPECT_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPECT_DATE");

                this.grd01.Cols["DELI_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RCV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "ZSMP_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RE_DONE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RE_OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RE_DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D_OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D_DEF_QTY");
                
                DataSet source = this.GetTypeCode("U9");
                //source.Tables[0].DefaultView.RowFilter = "GROUPCD = '" + this.UserInfo.BusinessCode + "'";
                DataTable dtPlant_Div = source.Tables[0].DefaultView.ToTable().Copy();
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPlant_Div, "PLANT_DIV", true, true);



                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.Cols.Count = this.grd01.Cols.Fixed;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "Supplier", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "SupplierName", "VENDNM", "VENDNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 115, "Part No", "PARTNO", "PARNTO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 175, "Part Name", "PARTNM", "PARTNM");
                         
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "BLOCK", "PLANT_BLOCK", "PLANT_BLOCK");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "InspectDate", "INSPECT_DATE", "INSPECT_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "Shift", "SHIFT", "SHIFT");
                         
                         
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "IncomeQty", "RCV_QTY", "RCV_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "PassedQty", "OK_QTY", "OK_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "DefectQty", "DEF_QTY", "DEF_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "SampleQty", "ZSMP_QTY", "ZSMP_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Car Model", "VINCD", "VINCD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Rework Qty", "RE_DONE", "RE_DONE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 075, "Rework OK", "RE_OK_QTY", "RE_OK_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Rework NG", "RE_DEF_QTY", "RE_DEF_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "Direct OK", "D_OK_QTY", "D_OK_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 075, "Direct NG", "D_DEF_QTY", "D_DEF_QTY");

                this.grd02.Cols["INSPECT_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "INSPECT_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RCV_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "ZSMP_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "OK_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RE_DONE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RE_OK_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RE_DEF_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D_OK_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D_DEF_QTY");

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
                if (tabControl1.SelectedIndex == 0)
                {

                    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                    string FROM_DATE = this.dte01_FROM_DATE.Value.ToString("yyyy-MM-dd");
                    string TO_DATE = this.dte01_TO_DATE.Value.ToString("yyyy-MM-dd");
                    string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                    string INSPECT_RSLT = this.cbo01_INS_RSLT.GetValue().ToString();
                    string MAT_DIV = this.cbo01_MAT_DIV.GetValue().ToString();
                    string PART_NO = this.txt01_PARTNO.GetValue().ToString();
                    string BLOCK = this.cbo01_BLOCK.GetValue().ToString();
                    string VINCD = this.cbo01_VINCD.GetValue().ToString();


                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("FROM_DATE", FROM_DATE);
                    paramSet.Add("TO_DATE", TO_DATE);
                    paramSet.Add("VENDCD", VENDCD);
                    paramSet.Add("INSPECT_RSLT", INSPECT_RSLT);
                    paramSet.Add("MAT_DIV", MAT_DIV);
                    paramSet.Add("PART_NO_PRTNO", PART_NO);
                    paramSet.Add("PLANT_BLOCK", BLOCK);
                    paramSet.Add("LANG_SET", UserInfo.Language);
                    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
                    paramSet.Add("VINCD", VINCD);
                    this.BeforeInvokeServer(true);

                    DataSet source = new DataSet();
                    AxFlexGrid grd = new AxFlexGrid();

                    //source = _WSCOM.Inquery(paramSet);
                    source = _WSCOM.ExecuteDataSet("ZPG_ZQA30117.INQUERY", paramSet);

                    this.grd01.SetValue(source);

                    this.AfterInvokeServer();
                }
                else
                {

                    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                    string INSPECT_SDATE = this.dte01_FROM_DATE.Value.ToString("yyyy-MM-dd");
                    string INSPECT_EDATE = this.dte01_TO_DATE.Value.ToString("yyyy-MM-dd");
                    string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                    string INSPECT_RSLT = this.cbo01_INS_RSLT.GetValue().ToString();
                    string PART_NO = this.txt01_PARTNO.GetValue().ToString();
                    string BLOCK = this.cbo01_BLOCK.GetValue().ToString().Replace("BLOCK ","");
                    string SHIFT = this.cbo01_SHIFT.GetValue().ToString();
                    string VINCD = this.cbo01_VINCD.GetValue().ToString();

                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("INSPECT_SDATE", INSPECT_SDATE);
                    paramSet.Add("INSPECT_EDATE", INSPECT_EDATE);
                    paramSet.Add("VENDCD", VENDCD);
                    paramSet.Add("INSPECT_RSLT", INSPECT_RSLT);
                    paramSet.Add("PARTNO", PART_NO);
                    paramSet.Add("PLANT_BLOCK", BLOCK);
                    paramSet.Add("SHIFT", SHIFT);
                    paramSet.Add("LANG_SET", UserInfo.Language);
                    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
                    paramSet.Add("VINCD", VINCD);
                    this.BeforeInvokeServer(true);

                    DataSet source = new DataSet();
                    AxFlexGrid grd = new AxFlexGrid();

                    //source = _WSCOM.Inquery(paramSet);
                    source = _WSCOM.ExecuteDataSet("ZPG_ZQA30117.INQUERY_TOTALINSPECTION", paramSet);

                    this.grd02.SetValue(source);

                    this.AfterInvokeServer();
                }
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    DataSet ds_selected = grd01.GetValue(AxFlexGrid.FActionType.Save
                , "BIZCD", "INSPECTNO", "NOTENO", "RE_OK_QTY", "BARCODE");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx("ZPG_ZQA30117.SAVE", ds_selected);
                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);

                    //MsgBox.Show("정상적으로 유형코드가 저장되었습니다.");
                    MsgCodeBox.Show("XM00-0090");
                }
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.dte01_TO_DATE.Visible = true;
                this.lbl01_MAT_DIV.Visible = true;
                this.cbo01_MAT_DIV.Visible = true;
                this.lbl01_SHIFT.Visible = false;
                this.cbo01_SHIFT.Visible = false;
                this.heLabel2.Visible = true;
            }
            else
            {
                this.dte01_TO_DATE.Visible = true;
                this.lbl01_MAT_DIV.Visible = false;
                this.cbo01_MAT_DIV.Visible = false;
                this.lbl01_SHIFT.Visible = true;
                this.cbo01_SHIFT.Visible = true;
                this.heLabel2.Visible = true;
            }
        }

        #region [사용자 정의 메서드]
        
        #endregion

    }
}
