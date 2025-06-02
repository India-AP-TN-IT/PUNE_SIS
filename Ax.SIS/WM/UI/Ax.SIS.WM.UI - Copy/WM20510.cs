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
    /// 완반/자재 창고 재고 초기화 
    /// </summary>
    public partial class WM20510 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public WM20510()
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
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "선택", "CHK", "CHK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "Location", "LOCATION_NO", "LOCATION_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "창고코드", "WHCD", "WHCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "창고명", "WHNM", "WHNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Area code", "AREACD", "AREACD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "Area name", "AREANM", "AREANM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 070, "Zone code", "ZONECD", "ZONECD");//20190430
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 150, "Zone name", "ZONENM", "ZONENM");//20190430
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "내수/수입", "DOM_IMP_DIV_CD", "DOM_IMP_DIV_CD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재TYPE", "MAT_TYPE", "MAT_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "자재TYPE", "MAT_TYPE_CD", "MAT_TYPE_CD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part No", "PARTNO", "PARTNO");
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

                //제품구분 
                this.cbo01_PRDT_DIV.DataBind("A0", false);

                //내수구분
                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                //자재구분
                this.cbo01_MAT_TYPE.DataBindCodeName("EA", true);

                // 20190430 Replace below line.
                //SetRequired(this.lbl01_BIZNM2, this.lbl01_PRDT_DIV,  this.lbl01_WHCD, this.lbl01_AREACD, this.lbl01_ZONECD);
                SetRequired(this.lbl01_BIZNM2, this.lbl01_WHCD);

                #endregion

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
                //20190430 commented below
                //if (string.IsNullOrEmpty(this.cbo01_ZONECD.GetValue().ToString()))
                //{
                //    //Zone을 선택 하여 주십시오
                //    MsgCodeBox.Show("PD00-0042");
                //    return;
                //}

                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("WHCD", this.cbo01_WHCD.GetValue());
                //set.Add("AREACD", this.cbo01_AREACD.GetValue().Equals("ALL") ? "" : this.cbo01_AREACD.GetValue());
                //set.Add("ZONECD", "");// set.Add("ZONECD", this.cbo01_ZONECD.GetValue().Equals("ALL") ? "" : this.cbo01_ZONECD.GetValue());
                //set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
                set.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                set.Add("MAT_TYPE", this.cbo01_MAT_TYPE.GetValue());
                set.Add("LOCATION_NO", this.txt01_LOCATION.Text);
                set.Add("PARTNO", this.txt01_PARTNO.Text);
                set.Add("LOTNO", this.txt01_LOTNO.Text);
                //set.Add("PALLET_NO", this.txt01_PALLET_NO.Text);
                set.Add("LANG_SET", this.UserInfo.Language);

                //System.Diagnostics.Debug.WriteLine("CORCD:" + this.UserInfo.CorporationCode);
                //System.Diagnostics.Debug.WriteLine("BIZCD:" + this.UserInfo.BusinessCode);
                //System.Diagnostics.Debug.WriteLine("WHCD:" + this.cbo01_WHCD.GetValue().ToString());
                //System.Diagnostics.Debug.WriteLine("AREACD:" + this.cbo01_AREACD.GetValue().ToString());
                //System.Diagnostics.Debug.WriteLine("PRDT_DIV:" + this.cbo01_PRDT_DIV.GetValue().ToString());
                //System.Diagnostics.Debug.WriteLine("DOM_IMP_DIV:" + this.cbo01_DOM_IMP_DIV.GetValue().ToString());
                //System.Diagnostics.Debug.WriteLine("MAT_TYPE:" + this.cbo01_MAT_TYPE.GetValue().ToString());
                //System.Diagnostics.Debug.WriteLine("LOCATION_NO:" + this.txt01_LOCATION.Text);
                //System.Diagnostics.Debug.WriteLine("PARTNO:" + this.txt01_PARTNO.Text);
                //System.Diagnostics.Debug.WriteLine("LOTNO:" + this.txt01_LOTNO.Text);
                //System.Diagnostics.Debug.WriteLine("PALLET_NO:" + this.txt01_PALLET_NO.Text);
                //System.Diagnostics.Debug.WriteLine("LANG_SET:" + this.UserInfo.Language);

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

        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Rows.Count < 2)
                {
                    return;
                }
                //2016-06-11 김도연과장 요청 재고 초기화 2회 물음 후 처리되도록 수정 요청
                if (MsgCodeBox.Show("PD00-0023", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    if (MsgCodeBox.Show("PD00-0107", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                }
                if(AxTextBox1.GetValue().ToString().Contains(DateTime.Now.ToString("yyyyMMdd")) == false)
                {
                    MsgBox.Show("Wrong Password!!","ERROR", MessageBoxButtons.OKCancel);
                    return;
                }
                string[] grd01_Columns = new string[8];

                grd01_Columns[0] = "CHK";
                grd01_Columns[1] = "CORCD";
                grd01_Columns[2] = "BIZCD";
                grd01_Columns[3] = "LOCATION_NO";
                grd01_Columns[4] = "PRDT_DIV";
                grd01_Columns[5] = "DOM_IMP_DIV_CD";
                grd01_Columns[6] = "MAT_TYPE_CD";
                grd01_Columns[7] = "PARTNO";//20190826 추가 필수 칼럼.

                // get grid data
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All, grd01_Columns);

                set.Tables[0].Columns.Add("USER_ID");
                //set.Tables[0].Columns.Add("PARTNO");//20190826
                set.Tables[0].Columns.Add("LOTNO");
                //set.Tables[0].Columns.Add("PALLET_NO");

                for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
                {
                    set.Tables[0].Rows[i]["USER_ID"] = this.UserInfo.EmpNo;
                    //set.Tables[0].Rows[i]["PARTNO"] = this.txt01_PARTNO.Text;//20190826 : PARTNO를 명시적으로 그리드의 것을 사용.
                    set.Tables[0].Rows[i]["LOTNO"] = this.txt01_LOTNO.Text;
                    set.Tables[0].Rows[i]["PRDT_DIV"] = "M"; 
                    if (set.Tables[0].Rows[i]["CHK"].ToString().Equals("N"))
                        set.Tables[0].Rows.RemoveAt(i);
                }

                // remove check box column
                set.Tables[0].Columns.Remove("CHK");

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20510.SAVE", set);  //MES8030.INV_STATUS to 'X'

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);

            this.txt01_LOCATION.Text = "";
            this.txt01_LOTNO.Text = "";
            this.txt01_PARTNO.Text = "";
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
            //
            // 20190430 Commented this function
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
            if (this.grd01.Rows.Fixed > this.grd01.Row) return;

            C1.Win.C1FlexGrid.Row _row = this.grd01.Rows[this.grd01.Row];

            //switch (this.grd01.Cols[this.grd01.ColSel].Name)
            //{
            //    case "LOCATION_NO":
            WM20510P1 frm = new WM20510P1(true);
            frm.CORCD = this.UserInfo.CorporationCode;
            frm.BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            frm.LOCATION_NO = _row["LOCATION_NO"].ToString();
            frm.PRDT_DIV = "M";// _row["PRDT_DIV"].ToString().Replace("A0", "");
            frm.PARTNO = Convert.ToString(_row["PARTNO"]);//this.txt01_PARTNO.Text;
            frm.LOTNO = this.txt01_LOTNO.Text;
            frm.PALLET_NO = this.txt01_PALLET_NO.Text;
            frm.MAT_TYPE_CD = _row["MAT_TYPE_CD"].ToString();
            frm.DOM_IMP_DIV_CD = _row["DOM_IMP_DIV_CD"].ToString();

            PopupHelper helper = new PopupHelper(frm, this.GetLabel("LOCATION_INFO"));
            helper.Height = 600;
            helper.Width = 900;
            //helper.FixedPopupSize();
            helper.ShowDialog();
            //break;
            //}
        }

        private void cbo01_PRDT_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //20190430 COMMENTED FUNCTION
            //if (cbo01_PRDT_DIV.GetValue().ToString() == "A0M")
            //{
            //    this.grd01.Cols["BOX_QTY"].Visible = true;
            //}
            //else
            //{
            //    this.grd01.Cols["BOX_QTY"].Visible = false;
            //}
        }

        private void lbl01_DOM_IMP_DIV_Click(object sender, EventArgs e)
        {

        }

    }
}
