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
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class WM20511 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public WM20511()
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

                //제품
                this.cbo01_PRDT_DIV.DataBind("A0");
                this.cbo01_PRDT_DIV.SelectedItem = 0;

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "선택", "CHK", "CHK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "Location", "LOCATION_NO", "LOCATION_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "창고코드", "WHCD", "WHCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "창고명", "WHNM", "WHNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Area code", "AREACD", "AREACD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "Area name", "AREANM", "AREANM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Zone code", "ZONECD", "ZONECD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "Zone name", "ZONENM", "ZONENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재TYPE", "MAT_TYPE", "MAT_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Box Qty", "BOX_QTY", "BOX_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "Qty", "QTY", "QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 080, "PRDT_DIV", "PRDT_DIV", "PRDT_DIV");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BOX_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");

                //전체선택 체크박스
                CellStyle cs = this.grd01.Styles.Add("Boolean");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                #endregion 

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                // 제품구분 
                this.cbo01_PRDT_DIV.DataBind("A0", false);

                //내수구분
                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                //자재구분
                this.cbo01_MAT_TYPE.DataBindCodeName("EA", true);

                #endregion

                this.SetRequired(lbl01_BIZNM2);
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
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("WHCD", this.cbo01_WHCD.GetValue());
                //set.Add("AREACD", this.cbo01_AREACD.GetValue().Equals("ALL") ? "" : this.cbo01_AREACD.GetValue());
                //set.Add("ZONECD", this.cbo01_ZONECD.GetValue().Equals("ALL") ? "" : this.cbo01_ZONECD.GetValue());
                //set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
                set.Add("LOCATION_NO", this.txt01_LOCATION.Text);
                set.Add("PARTNO", this.txt01_PARTNO.Text);
                set.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                set.Add("MAT_TYPE", this.cbo01_MAT_TYPE.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY", set, "OUT_CURSOR");
                this.grd01.MergedRanges.Clear();
                this.AfterInvokeServer();

                this.grd01.SetValue(source1.Tables[0]);
                this.ShowDataCount(source1);

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


        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_WHCD", set1, "OUT_CURSOR").Tables[0];

            this.cbo01_WHCD.DataBindCodeName(source1, false);
        }

        private void cbo01_WHCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);
            set1.Add("WHCD", cbo01_WHCD.GetValue());

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_AREACD", set1, "OUT_CURSOR").Tables[0];

            this.cbo01_AREACD.DataBindCodeName(source1, false);
        }

        private void cbo01_AREACD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            //HEParameterSet set1 = new HEParameterSet();
            //set1.Add("CORCD", this.UserInfo.CorporationCode);
            //set1.Add("BIZCD", bizcd);
            //set1.Add("AREACD", cbo01_AREACD.GetValue());

            //DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_ZONECD", set1, "OUT_CURSOR").Tables[0];

            //this.cbo01_ZONECD.DataBindCodeName(source1, false);
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            //전체선택 체크박스 선택시 해당 선택값에 따라 모든 체크박스 업데이트 2013.10.28 (배명희)
            if (this.grd01.MouseRow == 0)
            {
                string val = this.grd01.GetValue(0, "CHK").ToString();
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.SetValue(i, "CHK", val == "Y" ? "1" : "0");
                }
            }
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            //if (this.grd01.Rows.Fixed > this.grd01.Row) return;

            //C1.Win.C1FlexGrid.Row _row = this.grd01.Rows[this.grd01.Row];

            //WM20510P1 frm = new WM20510P1();
            //frm.CORCD = this.UserInfo.CorporationCode;
            //frm.BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            //frm.LOCATION_NO = _row["LOCATION_NO"].ToString();
            //frm.PRDT_DIV = _row["PRDT_DIV"].ToString().Replace("A0", "");
            //frm.PARTNO = this.txt01_PARTNO.Text;
            //frm.LOTNO = "";
            //frm.MAT_TYPE_CD = this.cbo01_MAT_TYPE.GetValue().ToString();
            //frm.DOM_IMP_DIV_CD = this.cbo01_DOM_IMP_DIV.GetValue().ToString();

            //PopupHelper helper = new PopupHelper(frm, this.GetLabel("LOCATION_INFO"));
            //helper.Height = 600;
            //helper.Width = 740;
            //helper.ShowDialog();
        }

        private void cbo01_PRDT_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo01_PRDT_DIV.GetValue().ToString() == "A0M")
            {
                this.grd01.Cols["BOX_QTY"].Visible = true;
            }
            else
            {
                this.grd01.Cols["BOX_QTY"].Visible = false;
            }
        }

    }
}
