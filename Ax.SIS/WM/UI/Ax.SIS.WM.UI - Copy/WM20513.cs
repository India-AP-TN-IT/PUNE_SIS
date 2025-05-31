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
    /// 자재창고 재고실사 현황 조회
    /// <b>Material Inventory Checked Status</b>
    /// - 작 성 자 : 김지복<br />
    /// - 작 성 일 : 2016-07-15<br /> 
    /// </summary>
    public partial class WM20513 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public WM20513()
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

                #region grd01

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                //this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll; 
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "업체명", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "자재TYPE", "MAT_TYPE", "MAT_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "LOTNO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Clear Qty", "CLEAR_QTY", "CLEAR_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Real Qty", "REAL_QTY", "REAL_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Loss Qty", "LOSS_QTY", "LOSS_QTY");

                this.grd01.Cols["CLEAR_QTY"].Format = "###,###,###,###,###,##0";
                this.grd01.Cols["REAL_QTY"].Format = "###,###,###,###,###,##0";
                this.grd01.Cols["LOSS_QTY"].Format = "###,###,###,###,###,##0";

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                #endregion 

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";

                //내수구분
                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                //자재구분
                this.cbo01_MAT_TYPE.DataBindCodeName("EA", true);

                #endregion

                this.SetRequired(lbl01_BIZCD,lbl01_WORK_DATE);
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

                if ( string.IsNullOrEmpty(bizcd) == true)
                {
                    //MsgBox.Show(String.Format("사업장이 선택되지 않았습니다."));
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("BIZNM"));
                    return;
                }

                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("WORK_DATE", this.dtp01_WORK_DATE.Value.ToString("yyyy-MM-dd"));
                set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                set.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                set.Add("MAT_TYPE", this.cbo01_MAT_TYPE.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.Text);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source1 = new DataSet(); 
                if (this.rd_Summary.Checked == true)
                {
                    source1 = _WSCOM.ExecuteDataSet("APG_WM20513.INQUIRY", set, "OUT_CURSOR");
                }
                else
                {
                    source1 = _WSCOM.ExecuteDataSet("APG_WM20513.INQUIRY_DETAIL", set, "OUT_CURSOR");
                }

                this.grd01.MergedRanges.Clear();
                
                this.AfterInvokeServer();

                this.grd01.SetValue(source1.Tables[0]);

                this.ShowDataCount(source1);

                if (this.rd_Summary.Checked == true)
                {
                    grd01.Cols["LOTNO"].Visible = false;
                }
                else
                {
                    grd01.Cols["LOTNO"].Visible = true;
                }

                CellStyle LossSytle = this.grd01.Cols["LOSS_QTY"].Style;
                CellStyle cs1 = this.grd01.Styles.Add("LossSytle");
                cs1.ForeColor = Color.OrangeRed;
 
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    double LOSS_QTY = double.Parse(this.grd01.GetValue(i, "LOSS_QTY").ToString());

                    if (LOSS_QTY < 0)
                    {
                        this.grd01.SetCellStyle(i, this.grd01.Cols["LOSS_QTY"].Index, cs1);
                    }
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

    }
}
