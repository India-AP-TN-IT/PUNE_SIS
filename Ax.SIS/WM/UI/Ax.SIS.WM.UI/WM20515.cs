using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;

using C1.Win.C1FlexGrid;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class WM20515 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM20515()
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
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "Business", "BIZCD", "BIZNM2");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Location NO", "LOCATION_NO", "LOCATION_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part name", "PARTNM", "PARTNM");

                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Mat Type", "MAT_TYPE", "MAT_TYPE");SAP에서는 MAT_TYPE 없음. 2018.12.12
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Dom/Imp Div", "DOM_IMP_DIV", "DOM_IMP_DIV");

                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Seq", "LOTNO_SEQ", "LOTNO_SEQ");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 150, "Location No", "LOCATION_NO", "LOCATION_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Qty", "QTY", "QTY");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Std Date", "STD_DATE", "STD_DATE");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "SAP_PARTNO", "SAP_PARTNO","SAP_PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "ESTI_CLASS", "ESTI_CLASS", "ESTI_CLASS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "STR_LOC", "STR_LOC", "STR_LOCNM");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");

                this.grd01.Cols["QTY"].Format = _IntFormat;

                //for (int i = 0; i < grd01.Cols.Count; i++)
                //    this.grd01[1, i] = this.grd01.Cols[i].Caption;
                //전체선택 체크박스
                //CellStyle cs = this.grd01.Styles.Add("Boolean");
                //cs.DataType = typeof(Boolean);
                //cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                //this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);

                DataTable cbo01_DOM_IMP = new DataTable();
                cbo01_DOM_IMP.Columns.Add("CODE");
                cbo01_DOM_IMP.Columns.Add("NAME");
                cbo01_DOM_IMP.Rows.Add("", "ALL");
                cbo01_DOM_IMP.Rows.Add("EKV", "LOCAL");   //EKV
                cbo01_DOM_IMP.Rows.Add("EKL", "CKD");
                this.cbo01_DOM_IMP.DataBind(cbo01_DOM_IMP, false);
                this.cbo01_DOM_IMP.DropDownStyle = ComboBoxStyle.DropDownList;

                //cbo01_MAT_TYPE.DataBind("EA", true);SAP에서는 MAT_TYPE 없음. 2018.12.12

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

                this.lbl01_DOM_IMP.Visible = false;  // A0A : 완제품 / A0S : 반제품
                this.cbo01_DOM_IMP.Visible = false;
                //this.lbl01_MAT_TYPE.Visible = false;SAP에서는 MAT_TYPE 없음. 2018.12.12
                //this.cbo01_MAT_TYPE.Visible = false;SAP에서는 MAT_TYPE 없음. 2018.12.12

                #endregion

                //this.SetRequired(lbl01_VENDCD);
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);
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
                    HEParameterSet set = new HEParameterSet();

                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());                    
                    set.Add("DOM_IMP", this.cbo01_DOM_IMP.GetValue());
                    //set.Add("MAT_TYPE", this.cbo01_MAT_TYPE.GetValue());                  SAP에서는 MAT_TYPE 없음. 2018.12.12
                    set.Add("PARTNO", this.txt01_PARTNO.Text);
                    set.Add("LANG_SET", this.UserInfo.Language);

                    if (cbo01_PRDT_DIV.GetValue().ToString() == "A0M") //자재
                    {
                        grd01.Cols["DOM_IMP_DIV"].Visible = true;
                        //grd01.Cols["MAT_TYPE"].Visible = true;SAP에서는 MAT_TYPE 없음. 2018.12.12

                        this.BeforeInvokeServer(true);
                        DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20515.INQUERY1", set, "OUT_CURSOR");
                        this.grd01.MergedRanges.Clear();
                        this.AfterInvokeServer();

                        this.grd01.SetValue(source1.Tables[0]);
                        this.ShowDataCount(source1);

                        for (int i = 0; i < source1.Tables[0].Rows.Count; i++)
                        {
                            if (source1.Tables[0].Rows[i]["PARTNO"].ToString().Equals("Total"))
                                this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                        }
                    }
                    else  //완제품.반제품
                    {
                        grd01.Cols["DOM_IMP_DIV"].Visible = false;
                        //grd01.Cols["MAT_TYPE"].Visible = false;SAP에서는 MAT_TYPE 없음. 2018.12.12

                        this.BeforeInvokeServer(true);
                        DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20515.INQUERY", set, "OUT_CURSOR");
                        this.grd01.MergedRanges.Clear();
                        this.AfterInvokeServer();

                        this.grd01.SetValue(source1);

                        this.ShowDataCount(source1);

                        for (int i = 0; i < source1.Tables[0].Rows.Count; i++)
                        {
                            if (source1.Tables[0].Rows[i]["PARTNO"].ToString().Equals("Total"))
                                this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                        }
                    }            
                }
                else
                {
                    //grd01.Cols["MAT_TYPE"].Visible = true;SAP에서는 MAT_TYPE 없음. 2018.12.12
                    grd01.Cols["DOM_IMP_DIV"].Visible = false;
                    grd01.Cols["PARTNO"].Visible = true;
                    grd01.Cols["PARTNM"].Visible = true;                   
                    grd01.Cols["QTY"].Visible = true;  

                    HEParameterSet set1 = new HEParameterSet();
                    set1.Add("CORCD", this.UserInfo.CorporationCode);
                    set1.Add("BIZCD", this.UserInfo.BusinessCode);
                    set1.Add("DOM_IMP", this.cbo01_DOM_IMP.GetValue());
                    //set1.Add("MAT_TYPE", this.cbo01_MAT_TYPE.GetValue()); SAP에서는 MAT_TYPE 없음. 2018.12.12
                    set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    set1.Add("LANG_SET", this.UserInfo.Language);
                    set1.Add("STD_DATE", this.dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));

                    this.BeforeInvokeServer(true);

                    DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20515.INQUERY_STD", set1, "OUT_CURSOR");
                    this.grd01.SetValue(source1);
                    ShowDataCount(source1);

                    for (int i = 0; i < source1.Tables[0].Rows.Count; i++)
                    {
                        if (source1.Tables[0].Rows[i]["PARTNO"].ToString().Equals("Total"))
                            this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                    }
                }

               // string bizcd = this.UserInfo.BusinessCode;
               // HEParameterSet set = new HEParameterSet();

               // set.Add("CORCD", this.UserInfo.CorporationCode);
               // set.Add("BIZCD", this.UserInfo.BusinessCode);
               // set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
               // set.Add("DOM_IMP", this.cbo01_DOM_IMP.GetValue());
               // set.Add("PARTNO", this.txt01_PARTNO.Text);
               // set.Add("LANG_SET", this.UserInfo.Language);

               //if (cbo01_PRDT_DIV.GetValue().ToString() == "A0M") //자재
               // {
               //     this.BeforeInvokeServer(true);

               //     DataSet source1 = _WSCOM.ExecuteDataSet("PKG_WM20515.INQUERY1", set, "OUT_CURSOR");
               //     this.grd01.MergedRanges.Clear();
               //     this.AfterInvokeServer();

               //     this.grd01.SetValue(source1.Tables[0]);
               //     this.ShowDataCount(source1);
               // }
               // else  //완제품.반제품
               // {
               //     this.BeforeInvokeServer(true);
               //     DataSet source1 = _WSCOM.ExecuteDataSet("PKG_WM20515.INQUERY", set, "OUT_CURSOR");
               //     this.grd01.MergedRanges.Clear();
               //     this.AfterInvokeServer();

               //     this.grd01.SetValue(source1);

               //     this.ShowDataCount(source1);
               // }
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

            //this.cbo01_WHCD.DataBind(source1, false);
        }

        private void cbo01_WHCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);
            //set1.Add("WHCD", cbo01_WHCD.GetValue());

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_AREACD", set1, "OUT_CURSOR").Tables[0];

            //this.cbo01_AREACD.DataBind(source1, false);
        }

        private void cbo01_AREACD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);
            //set1.Add("AREACD", cbo01_AREACD.GetValue());

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_ZONECD", set1, "OUT_CURSOR").Tables[0];

            //this.cbo01_ZONECD.DataBind(source1, false);
        }

        //private void grd01_MouseClick(object sender, MouseEventArgs e)
        //{
        //    //전체선택 체크박스 선택시 해당 선택값에 따라 모든 체크박스 업데이트 2013.10.28 (배명희)
        //    if (this.grd01.MouseRow == 0)
        //    {
        //        string val = this.grd01.GetValue(0, "CHK").ToString();
        //        for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
        //        {
        //            this.grd01.SetValue(i, "CHK", val == "Y" ? "1" : "0");
        //        }
        //    }
        //}

        //private void grd01_DoubleClick(object sender, EventArgs e)
        //{
        //    if (this.grd01.Rows.Fixed > this.grd01.Row) return;

        //    C1.Win.C1FlexGrid.Row _row = this.grd01.Rows[this.grd01.Row];

        //    WM20510P1 frm = new WM20510P1();
        //    frm.CORCD = this.UserInfo.CorporationCode;
        //    frm.BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //    frm.LOCATION_NO = _row["LOCATION_NO"].ToString();
        //    frm.PRDT_DIV = _row["PRDT_DIV"].ToString().Replace("A0", "");
        //    frm.PARTNO = this.txt01_PARTNO.Text;

        //    PopupHelper helper = new PopupHelper(frm, this.GetLabel("LOCATION_INFO"));
        //    helper.Height = 600;
        //    helper.Width = 740;
        //    helper.ShowDialog();
        //}

        private void cbo01_PRDT_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo01_PRDT_DIV.GetValue().ToString() == "A0M") //자재
            {
                this.lbl01_DOM_IMP.Visible = true;
                this.cbo01_DOM_IMP.Visible = true;
                //this.lbl01_MAT_TYPE.Visible = true;SAP에서는 MAT_TYPE 없음. 2018.12.12
                //this.cbo01_MAT_TYPE.Visible = true;SAP에서는 MAT_TYPE 없음. 2018.12.12
            }
            else
            {
                this.lbl01_DOM_IMP.Visible = false;  // A0A : 완제품 / A0S : 반제품
                this.cbo01_DOM_IMP.Visible = false;
                //this.lbl01_MAT_TYPE.Visible = false;SAP에서는 MAT_TYPE 없음. 2018.12.12
                //this.cbo01_MAT_TYPE.Visible = false;SAP에서는 MAT_TYPE 없음. 2018.12.12
            }
        }

        private void chk01_BASE_QUERY_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_BASE_QUERY.Checked == true)
            {
                this.lbl01_Date.Visible = true;
                this.dtp01_STD_DATE.Visible = true;
                //this.cbo01_MAT_TYPE.SetValue("");SAP에서는 MAT_TYPE 없음. 2018.12.12
            }
            else
            {
                this.lbl01_Date.Visible = false;
                this.dtp01_STD_DATE.Visible = false;
            }
        }
    }
}
