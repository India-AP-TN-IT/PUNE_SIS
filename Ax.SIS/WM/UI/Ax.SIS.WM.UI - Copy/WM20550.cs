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
using Ax.SIS.CM.UI;
using System.Diagnostics;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// WMS 상품자재재고 조회
    /// </summary>
    public partial class WM20550 : AxCommonBaseControl
    {
        //private IPD20530 _WSCOM;
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM20550()
        {
            InitializeComponent();
            Trace.WriteLine(">>>>>>Trace>>>>>>>>>WM20550.cdx01_VENDCD.Width : "+this.cdx01_VENDCD.Width.ToString());
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cdx01_VENDCD.HEPopupHelper = new CM20017P1();
                this.cdx01_VENDCD.PopupTitle = lbl01_VENDCD.Text;
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                //cdx01_VENDCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
                 
                this.grd01.Tree.Column = 0;
                this.grd01.Tree.Style = TreeStyleFlags.Simple;
                this.grd01.Cols[0].Width = 70;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "VENDCD", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "VENDNM", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Deli.Count", "DELI_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 159, "BARCODE NOTE", "BARCODE_NOTE", "BARCODE_NOTE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 55, "NOTE", "NOTENO", "NOTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 121, "BARCODE", "BARCODE", "BARCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "YARD", "YARDNO", "YARDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "PARTNM", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "M/TYPE", "MAT_TYPE", "MAT_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "PONO", "PONO", "PONO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 120, "DELI_QTY", "DELI_QTY", "DELI_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "ARRIV_DATE", "ARRIV_DATE", "ARRIV_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 50, "ARRIV_QTY", "ARRIV_QTY", "ARRIV_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "BARCODE_TAG", "BARCODE_TAG", "BARCODE_TAG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "SEQ", "SEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "PO QTY", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "INPUT QTY", "STOCK_QTY", "IN_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "INV_STATUS", "INV_STATUS", "INV_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Estatus", "INV_DESC", "INV_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "LOTNO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Stock día", "STOCK_DATE", "STOCK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Stock hora", "STOCK_TIME", "STOCK_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Inspect Target", "INSPECT_YN", "INSPECT_YN");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "NOTENO");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "ARRIV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "STOCK_QTY");

                this.grd01.Cols["DELI_CNT"].Format = _IntFormat;
                this.grd01.Cols["NOTENO"].Format = _IntFormat;
                this.grd01.Cols["DELI_QTY"].Format = _IntFormat;
                this.grd01.Cols["ARRIV_QTY"].Format = _IntFormat;
                this.grd01.Cols["QTY"].Format = _IntFormat;
                this.grd01.Cols["STOCK_QTY"].Format = _IntFormat;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ARRIV_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STOCK_DATE");

                for (int i = 0; i <= this.grd01.Cols["DELI_QTY"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                string strcorcd = this.UserInfo.CorporationCode;
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cbo01_CORCD.SetReadOnly(true);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);

                this.grd01.Styles.Fixed.Font = new Font(FontFamily.GenericSansSerif, 8.0f);
                this.grd01.Styles.Normal.BackColor = Color.White;
                this.grd01.Styles.Alternate.BackColor = Color.White;
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
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("DELI_CNT", string.Empty);
                paramSet.Add("NOTENO", this.txt01_NOTENO.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("DELI_ST_DATE", this.dtp01_SDATE.GetDateText());
                paramSet.Add("DELI_ED_DATE", this.dtp01_EDATE.GetDateText());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                this.grd01.BeginUpdate();

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20550.INQUIRY", paramSet);

                //this.grd01.MergedRanges.Clear();
                this.grd01.SetValue(source.Tables[0]);

                this.grd01.Subtotal(AggregateEnum.Max, 0, this.grd01.Cols["BARCODE_NOTE"].Index, this.grd01.Cols["NOTENO"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["BARCODE_NOTE"].Index, this.grd01.Cols["QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["BARCODE_NOTE"].Index, this.grd01.Cols["ARRIV_QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["BARCODE_NOTE"].Index, this.grd01.Cols["STOCK_QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Var, 1, this.grd01.Cols["DELI_QTY"].Index, this.grd01.Cols["MAT_TYPE"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 1, this.grd01.Cols["DELI_QTY"].Index, this.grd01.Cols["QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 1, this.grd01.Cols["DELI_QTY"].Index, this.grd01.Cols["STOCK_QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Max, 1, this.grd01.Cols["DELI_QTY"].Index, this.grd01.Cols["SEQ"].Index);

                CellStyle cs;
                cs = this.grd01.Styles[CellStyleEnum.Subtotal0];
                cs.BackColor = Color.FromArgb(192, 192, 192);
                cs.ForeColor = Color.Black;
                cs.Font = new Font(Font, FontStyle.Bold);

                cs = this.grd01.Styles[CellStyleEnum.Subtotal1];
                cs.BackColor = Color.FromArgb(230, 230, 230);
                cs.ForeColor = Color.Black;
                cs.Font = new Font(Font, FontStyle.Bold);

                if (!this.grd01.Styles.Contains("STATUS_OK"))
                {
                    cs = this.grd01.Styles.Add("STATUS_OK");
                    cs.BackColor = Color.Lime;
                    cs.ForeColor = Color.Black;
                    cs.Font = new Font(Font, FontStyle.Bold);
                }
                if (!this.grd01.Styles.Contains("STATUS_SCAN"))
                {
                    cs = this.grd01.Styles.Add("STATUS_SCAN");
                    cs.BackColor = Color.Yellow;
                    cs.ForeColor = Color.Black;
                    cs.Font = new Font(Font, FontStyle.Bold);
                }
                if (!this.grd01.Styles.Contains("STATUS_NG"))
                {
                    cs = this.grd01.Styles.Add("STATUS_NG");
                    cs.BackColor = Color.OrangeRed;
                    cs.ForeColor = Color.White;
                    cs.Font = new Font(Font, FontStyle.Bold);
                }

                int expand_level = 2;
                if (this.btn01_EXPAND_ALL.Checked)
                    expand_level = 2;
                else if (this.btn01_EXPAND_MID.Checked)
                    expand_level = 1;
                else
                    expand_level = 0;

                int iColStatus = grd01.Cols["INV_STATUS"].Index;
                int iColStatusDesc = grd01.Cols["INV_DESC"].Index;
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {

                    if (this.grd01.Rows[i].Node.Level < expand_level)
                        this.grd01.Rows[i].Node.Expanded = true;
                    else
                        this.grd01.Rows[i].Node.Expanded = false;

                    if (object.Equals(this.grd01.GetData(i, iColStatus), "I0"))
                        this.grd01.SetCellStyle(i, iColStatusDesc, "STATUS_OK");
                    else if (object.Equals(this.grd01.GetData(i, iColStatus), "I"))
                        this.grd01.SetCellStyle(i, iColStatusDesc, "STATUS_SCAN");
                    else if (object.Equals(this.grd01.GetData(i, iColStatus), "N"))
                        this.grd01.SetCellStyle(i, iColStatusDesc, "STATUS_NG"); 

                    if (object.Equals(this.grd01.GetData(i, this.grd01.Cols["QTY"].Index), this.grd01.GetData(i, this.grd01.Cols["STOCK_QTY"].Index)) == false
                        && object.Equals(this.grd01.GetData(i, this.grd01.Cols["INV_STATUS"].Index), "N") == false
                        && ((this.grd01.Rows[i].IsNode == true && this.grd01.Rows[i].Node.Expanded == false)
                            || this.grd01.Rows[i].IsNode == false))
                        this.grd01.SetCellStyle(i, this.grd01.Cols["STOCK_QTY"].Index, "STATUS_SCAN");
                }

                ShowDataCount(source);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.grd01.EndUpdate();
                this.AfterInvokeServer();
            }
        }

        private void btn01_EXPAND_CheckedChanged(object sender, EventArgs e)
        {

        }

        

    }
}
