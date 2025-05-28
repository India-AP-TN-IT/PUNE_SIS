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
using HE.Framework.Core.Report;
using System.Diagnostics;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// CKD Invoice별 입하 실적 조회 
    /// </summary>
    public partial class WM40530 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        public WM40530()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Tree.Column = 0;
                this.grd01.Tree.Style = TreeStyleFlags.Simple;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "INVOICE_NO", "INVOICE_NO", "INVOICE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "CASE_NO", "CASE_NO", "CASE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "CKD_REG_CNT", "CKD_REG_CNT", "CKD_REG_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "CKD_REG_QTY", "CKD_REG_QTY", "CKD_REG_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "INCOMM_CNT", "INCOMM_CNT", "INCOMM_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "INCOMM_QTY", "INCOMM_QTY", "INCOMM_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Status", "STATUS", "STATUS");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CKD_REG_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CKD_REG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "INCOMM_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "INCOMM_QTY");

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;

                #endregion 
                
                this.dtp01_PROD_SDATE.SetValue(DateTime.Now);
                this.dtp01_PROD_EDATE.SetValue(DateTime.Now);

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                // tag size
                DataTable combo_source_PRINT_DIV2 = new DataTable();
                combo_source_PRINT_DIV2.Columns.Add("CODE");
                combo_source_PRINT_DIV2.Columns.Add("NAME");
                combo_source_PRINT_DIV2.Rows.Add("LARGE", "LARGE");
                combo_source_PRINT_DIV2.Rows.Add("MIDDLE", "MIDDLE");
                combo_source_PRINT_DIV2.Rows.Add("SMALL", "SMALL");

                #endregion

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_SHIPDATE);         

                BtnQuery_Click(null, null);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        //protected override void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string bizcd = this.UserInfo.BusinessCode;
        //        HEParameterSet set = new HEParameterSet();


        //        DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
        //            "INVOICE_NO", "PACK_CASE_NO","PARTNO", "PAYNO");
                


               
        //        this.BeforeInvokeServer(true);
        //        foreach (DataRow dr in source.Tables[0].Rows)
        //        {
        //            if (string.IsNullOrEmpty(dr["INVOICE_NO"].ToString()) == false
        //                    && string.IsNullOrEmpty(dr["PACK_CASE_NO"].ToString()) == false
        //                    && string.IsNullOrEmpty(dr["PARTNO"].ToString()) == false)
        //            {
        //                set = new HEParameterSet();
        //                set.Add("CORCD", this.UserInfo.CorporationCode);
        //                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
        //                set.Add("INVOICE_NO", dr["INVOICE_NO"].ToString());
        //                set.Add("PACK_CASE_NO", dr["PACK_CASE_NO"].ToString());
        //                set.Add("PARTNO", dr["PARTNO"].ToString());
        //                set.Add("PAYNO", dr["PAYNO"].ToString());
        //                _WSCOM.ExecuteNonQueryTx("APG_WM40530.SAVE", set);
        //            }

        //        }
        //        BtnQuery_Click(null, null);
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}
        protected override void BtnQuery_Click(object sender, EventArgs e)
        { 
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();


                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("INVOICE_NO", this.txt01_INVOICE_NO.GetValue());
                set.Add("CASE_NO", this.txt01_CASE_NO.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("SDATE", this.dtp01_PROD_SDATE.GetDateText());
                set.Add("EDATE", this.dtp01_PROD_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM40530.INQUIRY", set, "OUT_CURSOR");

                this.grd01.MergedRanges.Clear();
                this.grd01.SetValue(source);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["CKD_REG_CNT"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["CKD_REG_QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["INCOMM_CNT"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, 0, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["INCOMM_QTY"].Index);

                this.grd01.Subtotal(AggregateEnum.Sum, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["CASE_NO"].Index, this.grd01.Cols["CKD_REG_CNT"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["CASE_NO"].Index, this.grd01.Cols["CKD_REG_QTY"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["CASE_NO"].Index, this.grd01.Cols["INCOMM_CNT"].Index);
                this.grd01.Subtotal(AggregateEnum.Sum, this.grd01.Cols["INVOICE_NO"].Index, this.grd01.Cols["CASE_NO"].Index, this.grd01.Cols["INCOMM_QTY"].Index);

                CellStyle cs;
                cs = this.grd01.Styles[CellStyleEnum.Subtotal0];
                cs.BackColor = Color.FromArgb(152, 201, 255);
                cs.ForeColor = Color.Black;
                cs.Font = new Font(Font, FontStyle.Bold);


                cs = this.grd01.Styles[CellStyleEnum.Subtotal1];
                cs.BackColor = Color.FromArgb(165, 255, 255);
                cs.ForeColor = Color.Black;
                cs.Font = new Font(Font, FontStyle.Bold);


                bool expand = true;
                if (this.btn01_EXPAND.Checked)
                {
                    expand = true;
                }
                else
                {
                    expand = false;
                }

                if (!this.grd01.Styles.Contains("STATUS_OK"))
                {
                    cs = this.grd01.Styles.Add("STATUS_OK");
                    cs.BackColor = Color.Lime;
                    cs.ForeColor = Color.Black;
                    cs.Font = new Font(Font, FontStyle.Bold);
                }
                if (!this.grd01.Styles.Contains("STATUS_NG"))
                {
                    cs = this.grd01.Styles.Add("STATUS_NG");
                    cs.BackColor = Color.Red;
                    cs.ForeColor = Color.Black;
                    cs.Font = new Font(Font, FontStyle.Bold);
                }

                int iColStatus = grd01.Cols["STATUS"].Index;
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.Rows[i].Node.Expanded = expand;

                    if(object.Equals(this.grd01.GetData(i, iColStatus), "OK"))
                        this.grd01.SetCellStyle(i, iColStatus, "STATUS_OK");
                    else if (object.Equals(this.grd01.GetData(i, iColStatus), "NG"))
                        this.grd01.SetCellStyle(i, iColStatus, "STATUS_NG");
                }

                this.grd01.Cols.Frozen = 4;
                ShowDataCount(source);


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
