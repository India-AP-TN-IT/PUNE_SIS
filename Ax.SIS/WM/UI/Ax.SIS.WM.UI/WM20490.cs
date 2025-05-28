using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;

using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// LOCATION 품번별 자재 재고 조회 
    /// </summary>
    public partial class WM20490 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public WM20490()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            { 
                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Tree.Column = 0;
                this.grd01.Tree.Style = TreeStyleFlags.Complete;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Location NO", "LOCATION_NO", "LOCATION_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 115, "Part no", "PARTNO", "PARTNO");
                //this.grd01.Cols["PARTNO"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part name", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Mat. Type", "MAT_TYPE", "MAT_TYPE");  
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 55, "Seq", "LOTNO_SEQ", "LOTNO_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Lot no", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 75, "Qty", "QTY", "QTY");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 85, "Std Date", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 85, "Work Date", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Work Time", "WORK_TIME", "WORK_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 85, "Rcv Date", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 155, "Note No", "NOTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Invoice No", "INVOICE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Order No", "ORDERNO");
                
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BOX_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");

                //필수항목
                //SetRequired(this.lbl01_PRDT_DIV);

                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                #region 창고코드 

                HEParameterSet paramSet_WHCD_UNIT = new HEParameterSet();
                paramSet_WHCD_UNIT.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet_WHCD_UNIT.Add("BIZCD", this.UserInfo.BusinessCode);
                DataSet combo_source_WHCD_UNIT = _WSCOM.ExecuteDataSet("APG_WM20490.INQUERY_WHCD", paramSet_WHCD_UNIT);
                this.cbo01_WHCD.DataBindCodeName(combo_source_WHCD_UNIT.Tables[0], true);
                this.cbo01_WHCD.SetValue("W01");

                #endregion

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;
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
                string bizcd = this.UserInfo.BusinessCode;

                if (chk01_BASE_QUERY.Checked == false)
                {
                    grd01.Cols["LOCATION_NO"].Visible = true;
                    grd01.Cols["PARTNO"].Visible = true;
                    grd01.Cols["PARTNM"].Visible = true;
                    grd01.Cols["MAT_TYPE"].Visible = true;
                    grd01.Cols["LOTNO_SEQ"].Visible = false;
                    grd01.Cols["LOTNO"].Visible = true;
                    grd01.Cols["QTY"].Visible = true;
                    grd01.Cols["WORK_DATE"].Visible = true;
                    grd01.Cols["RCV_DATE"].Visible = true;
                    grd01.Cols["NOTENO"].Visible = true;
                    grd01.Cols["INVOICE_NO"].Visible = true;
                    grd01.Cols["ORDERNO"].Visible = true;


                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("WHCD", this.cbo01_WHCD.GetValue());
                    //set.Add("AREACD", this.cbo01_AREACD.GetValue());
                    set.Add("LOCATION_NO", this.txt01_LOCATION_NO.GetValue());
                    set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    set.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                    set.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);

                    if (chk01_SUMMARY.Checked == true)
                    {
                        DataSet source = _WSCOM.ExecuteDataSet("APG_WM20490.INQUERY_SUM", set, "OUT_CURSOR");
                        this.grd01.MergedRanges.Clear();
                        this.grd01.SetValue(source);
                        this.grd01.Cols.Frozen = 7;
                        ShowDataCount(source);
                        for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                        {
                            if (source.Tables[0].Rows[i]["LOCATION_NO"].ToString().Equals("Total"))
                                this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;

                            if (source.Tables[0].Rows[i]["PARTNO"].ToString().Equals("Sub Total"))
                                this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LemonChiffon;
                        }
                    }                        
                    else
                    {
                        DataSet source = _WSCOM.ExecuteDataSet("APG_WM20490.INQUERY", set, "OUT_CURSOR");
                        this.grd01.MergedRanges.Clear();
                        this.grd01.SetValue(source);
                        this.grd01.Cols.Frozen = 7;
                        ShowDataCount(source);
                    }
                        

                    //this.grd01.MergedRanges.Clear();
                    //this.grd01.SetValue(source);

                    //if (chk01_SUMMARY.Checked == true)
                    //{
                    //    this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["PARTNM"].Index, this.grd01.Cols["QTY"].Index);
                    //    this.grd01.Subtotal(AggregateEnum.Count, 0, this.grd01.Cols["PARTNM"].Index, this.grd01.Cols["LOTNO_SEQ"].Index);

                    //    CellStyle cs;
                    //    cs = this.grd01.Styles[CellStyleEnum.Subtotal0];
                    //    cs.BackColor = Color.FromArgb(165, 255, 255);
                    //    cs.ForeColor = Color.Black;
                    //    cs.Font = new Font(Font, FontStyle.Bold);

                    //}


                    //this.grd01.Cols.Frozen = 6;
                    //ShowDataCount(source);
                }
                else
                {
                    grd01.Cols["LOCATION_NO"].Visible = false;  
                    grd01.Cols["PARTNO"].Visible = true;   
                    grd01.Cols["PARTNM"].Visible = true;
                    grd01.Cols["MAT_TYPE"].Visible = false;
                    grd01.Cols["LOTNO_SEQ"].Visible = false;   
                    grd01.Cols["LOTNO"].Visible = false;        
                    grd01.Cols["QTY"].Visible = true;    
                    grd01.Cols["WORK_DATE"].Visible = false;
                    grd01.Cols["RCV_DATE"].Visible = false;
                    grd01.Cols["NOTENO"].Visible = false;
                    grd01.Cols["INVOICE_NO"].Visible = false;
                    grd01.Cols["ORDERNO"].Visible = false;

                    HEParameterSet set1 = new HEParameterSet();
                    set1.Add("CORCD", this.UserInfo.CorporationCode);
                    set1.Add("BIZCD", this.UserInfo.BusinessCode);
                    set1.Add("WHCD", this.cbo01_WHCD.GetValue());
                    //set1.Add("AREACD", this.cbo01_AREACD.GetValue());
                    set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    set1.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                    set1.Add("LANG_SET", this.UserInfo.Language);
                    set1.Add("STD_DATE", this.dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));

                    this.BeforeInvokeServer(true);

                    DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20490.INQUERY_STD", set1, "OUT_CURSOR");
                    this.grd01.SetValue(source1);
                    ShowDataCount(source1);
                }

                //this.grd01.SetValue(source.Tables[0]);
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

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            this.grd01.AllowMerging = (this.chk01_MERGE.Checked == true) ?
                C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }

        private void cbo01_WHCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HEParameterSet paramSet_AREACD_UNIT = new HEParameterSet();
            //paramSet_AREACD_UNIT.Add("CORCD", this.UserInfo.CorporationCode);
            //paramSet_AREACD_UNIT.Add("BIZCD", this.UserInfo.BusinessCode);
            //paramSet_AREACD_UNIT.Add("WHCD", this.cbo01_WHCD.GetValue());
            //DataSet combo_source_AREACD_UNIT = _WSCOM.ExecuteDataSet("APG_WM20490.INQUERY_AREACD", paramSet_AREACD_UNIT);
            //this.cbo01_AREACD.DataBindCodeName(combo_source_AREACD_UNIT.Tables[0], true);
        }

        private void heDockingTab1_Load(object sender, EventArgs e)
        {

        }

        private void chk01_SUMMARY_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_SUMMARY.Checked == true)
            {
                this.chk01_MERGE.Visible = true;
            }
            else
            {
                this.chk01_MERGE.Visible = false;
            }
        }

        private void chk01_STD_QUERY_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_BASE_QUERY.Checked == true)
            {
                this.lbl01_Date.Visible = true;
                this.dtp01_STD_DATE.Visible = true;
            }
            else
            {
                this.lbl01_Date.Visible = false;
                this.dtp01_STD_DATE.Visible = false;
            }
        }
        

    }
}
