
using System;
using System.Data;
using System.ServiceModel;


using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Diagnostics;

namespace Ax.SIS.SD.UI
{
    public partial class ZSD02550 : AxCommonBaseControl
    {
        //private IPD20010 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02550";

        #region [ 초기화 작업 정의 ]
        public enum InvoiceTypeEnum
        {
            D_DC_SAMPLE,
            R_DC_FG_RETURN,
            J_DC_MAT_RETURN
        }
        private InvoiceTypeEnum m_InvType = InvoiceTypeEnum.D_DC_SAMPLE;
        private string GetInvType()
        {
            switch(m_InvType)
            {
                case InvoiceTypeEnum.D_DC_SAMPLE:
                    return "D";
                case InvoiceTypeEnum.R_DC_FG_RETURN:
                    return "R";
            }
            return "D";
        }

        private void SetInvType()
        {
            string menu = "";
            if (string.IsNullOrEmpty(MenuID) == true)
            {
                menu = "ZSD02550";
            }
            else
            {
                menu = MenuID;
            }
            //menu = "ZSD02501";
            switch (menu)
            {
                case "ZSD02550":    //DC SAMPLE
                    Lbl_title.Text = "(D)D.C For Sample";
                    m_InvType = InvoiceTypeEnum.D_DC_SAMPLE;
                    axLabel4.SetValue("Customer");
                    cbl01_CustPLANT.Visible = true;
                    axLabel3.Visible = true;
                    cdx01_VENDCD.SetReadOnly(true);
                    break;
                case "ZSD02551":    //DC RETURNABLE - FG
                    Lbl_title.Text = "(R)D.C For Returnable";
                    m_InvType = InvoiceTypeEnum.R_DC_FG_RETURN;
                    axLabel4.SetValue("Customer");
                    cbl01_CustPLANT.Visible = true;
                    axLabel3.Visible = true;
                    cdx01_VENDCD.SetReadOnly(true);
                    break;
            }
        }
        public ZSD02550()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }
       
        private void SetPartInfor(int row)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("CUST_PLANT", "");
            set.Add("CUSTCD", cdx01_VENDCD.GetValue());
            set.Add("PARTNO", grd01.GetValue(row,"PARTNO"));

            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("LANG_SET", this.UserInfo.Language);
            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.INQUERY_PART_INFOR", set, "OUT_CURSOR");

            if (source.Tables[0].Rows.Count > 0)
            {
                grd01.SetValue(row, "ALCCD", source.Tables[0].Rows[0]["ALCCD"].ToString());
                grd01.SetValue(row, "UOM", source.Tables[0].Rows[0]["UOM"].ToString());
            }
            else
            {
                grd01.SetValue(row, "ALCCD","");
                grd01.SetValue(row, "UOM", "");    
            }
        }
        private void CheckWorkDate(ref DEV.Utility.Controls.AxDateEdit dtCtl)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_WORKDATE"), set, "OUT_CURSOR").Tables[0];
            if (dt.Rows.Count > 0)
            {
                string workdate = dt.Rows[0]["WORKDATE"].ToString();
                if (workdate != dtCtl.GetDateText())
                {
                    if (MsgBox.Show("Delivery Date is not matched!!\nDo you want to change it automatically?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string[] wDate = workdate.Split('-');
                        dtCtl.Value = new DateTime(Convert.ToInt32(wDate[0]), Convert.ToInt32(wDate[1]), Convert.ToInt32(wDate[2]));
                    }
                }

            }
        }
        private bool SaveData()
        {

            try
            {
                
                //CheckWorkDate(ref dtp01_STD_DATE);
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD","TY", "CUSTCD", "CUST_PLANT", "INVOICE", "DELI_DATE", "CARNO", "PARTNO", "QTY", "USER_ID");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["USER_ID"] = this.UserInfo.EmpNo;
                    rows["CORCD"] = UserInfo.CorporationCode;
                    rows["BIZCD"] = cbo01_BIZCD.GetValue();
                    rows["CUSTCD"] = cdx01_VENDCD.GetValue();
                    rows["CUST_PLANT"] = cbl01_CustPLANT.GetValue();
                    rows["DELI_DATE"] = dtp01_STD_DATE.GetDateText();
                    rows["TY"] = GetInvType();
                    rows["CARNO"] = Lbl_TNO.Text;
                    rows["INVOICE"] = label2.Text;
                }

                if (!IsSaveValid(source)) return false;

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_DATA"), source);



                this.AfterInvokeServer();


                return true;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                this.AfterInvokeServer();

            }
        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                label2.Text = "";
                PAN_Supplier.Visible = false;
               

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "TRUCK", "CARNO", "CARNO");

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "SEQ", "SEQID", "SEQID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "TRUCK No.", "CARNO", "CARNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "P/NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT", "UOM", "UOM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "DC NO.", "INVOICE", "INVOICE");
                

                //<<BUFFERS
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUSTCD", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "USER_ID", "USER_ID", "USER_ID");
                //>>

                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0";

                this.grd01.Cols["PARTNO"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                this.grd01.Cols["QTY"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                //this.grd01.Cols["UPRICE"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "VENDOR", "VENDNM", "VENDNM");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "TRUCK", "CARNO", "CARNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "INVOICE", "INVOICE", "INVOICE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "I/CNT", "INV_CNT", "INV_CNT");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "IRN", "E_YN", "E_YN");

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";

                SetInvType();
                SetCustPLANT();

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
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("TRUCKNO", Txt_Car.Text);
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_TRUCK"), set, "OUT_CURSOR");
                    this.AfterInvokeServer();

                    this.grd02.SetValue(source.Tables[0]);
                }
                else if(tabControl1.SelectedIndex==1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                    set.Add("INVOICE", "");
                    set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                    set.Add("TYPE", GetInvType());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_HISTORY"), set, "OUT_CURSOR");
                    this.AfterInvokeServer();

                    this.grd03.SetValue(source.Tables[0]);

                }


            }
            catch (Exception eLog)
            {
                this.AfterInvokeServer();
            }
        }

       


        #endregion


        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                System.Collections.Generic.List<string> dupList = new System.Collections.Generic.List<string>();
                for (int row = 0; row < grd01.Rows.Count;row++ )
                {
                    string partno = grd01.GetValue(row,"PARTNO").ToString();
                    if(dupList.Contains(partno))
                    {
                        MsgBox.Show("Duplicated Part Number:" + partno, "Error", MessageBoxButtons.OK, ImageKinds.Error);
                        return false;
                    }
                    else
                    {
                        dupList.Add(partno);
                    }
                    if (string.IsNullOrEmpty(partno))
                    {
                        MsgBox.Show("Enter Part No. for the " + row + "row");
                        return false;
                    }
                    string Qty = grd01.GetValue(row, "QTY").ToString();
                    if (string.IsNullOrEmpty(Qty))
                    {
                        MsgBox.Show("Enter Qty for the " + row + "row");
                        return false;
                    }
                }
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

       
        private void axRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(axRadioButton2.Checked)
            {
                
                PAN_OUR.Visible = false;
                PAN_Supplier.Visible = true;
                PAN_Supplier.Location = new System.Drawing.Point(PAN_OUR.Location.X, PAN_OUR.Location.Y);

                PAN_Supplier.BringToFront();
            }
        }

        private void axRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (axRadioButton1.Checked)
            {
                PAN_OUR.Visible = true;
                
                PAN_OUR.BringToFront();
                PAN_Supplier.Visible = false;
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            BtnQuery_Click(null, null);
        }

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()) == true)
                {
                    MsgBox.Show("You neet to select the vendor first.", "Error", MessageBoxButtons.OK);
                    cdx01_VENDCD.Focus();
                    return;
                }
                int row = this.grd02.SelectedRowIndex;
                int col = this.grd02.ColSel;
                if (row < this.grd02.Rows.Fixed) return;

                
                Lbl_TNO.Text = grd02.GetValue(row, "CARNO").ToString();
                label2.Text = "";
                LoadDetail(label2.Text);
                
            }
            catch (Exception eLog)
            {

            }
        }
        private string GetDCType()
        {
            if (m_InvType == InvoiceTypeEnum.R_DC_FG_RETURN || m_InvType == InvoiceTypeEnum.J_DC_MAT_RETURN)
            {
                return "KJA";
            }
            else if (m_InvType == InvoiceTypeEnum.D_DC_SAMPLE)
            {
                return "KJB";
            }
            return "KJA";
        }
        private void LoadDetail(string invoice)
        {
            
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("CUSTCD", "");
            set.Add("INVOICE", invoice);
            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("TYPE", GetInvType());


            this.BeforeInvokeServer(true);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DET_DATA"), set, "OUT_CURSOR");
            this.AfterInvokeServer();
            

            this.grd01.SetValue(source.Tables[0]);
            for (int row = 1; row < grd01.Rows.Count; row++)
            {
                string strINV = grd01.GetValue(row, "INVOICE").ToString();
                if (string.IsNullOrEmpty(strINV) == false)
                {
                    grd01.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                }
            }
        }
        private void Print_Invoice()
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/ZSD02550";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("INVOICE", label2.Text);


                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_PRINTDATA"), set, "OUT_CURSOR");
                this.AfterInvokeServer();
                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
                report.Sections.Add("MAIN", xmlSection);

                AxRexpertReportViewer.ShowReport(report);

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
        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {

                int row = e.Row;
                int col = e.Col;
                if (row < this.grd01.Rows.Fixed) return;

                string cdStr = "";
                string descStr = "";
                string findStr = grd01.GetValue(e.Row, e.Col).ToString();
                DataTable dt = new DataTable();
                HEParameterSet paramSet = new HEParameterSet();

                grd01.FinishEditing(true);
                switch (grd01.Cols[col].UserData.ToString())
                {
                    
                    case "PARTNO":
                        findStr = grd01.GetValue(row, col).ToString();
                        paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", UserInfo.CorporationCode);
                        paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                        paramSet.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                        paramSet.Add("VENDCD", cdx01_VENDCD.GetValue());
                        paramSet.Add("PARTNO", string.IsNullOrEmpty(findStr) ? "@#@#@#@#" : findStr);
                        paramSet.Add("LANG_SET", this.UserInfo.Language);

                        dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02550.INQUERY_DLG_PART", paramSet, "OUT_CURSOR").Tables[0];
                        if (dt.Rows.Count > 1)
                        {
                            PopupHelper helper = null;
                            ZSD02550_DLG _bm1 = new ZSD02550_DLG("PART", "DESC", findStr, "");
                            _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                            _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                            _bm1.HEUserParameterSetValue("DELI_DATE", dtp01_STD_DATE.GetDateText());
                            _bm1.HEUserParameterSetValue("VENDCD", cdx01_VENDCD.GetValue());
                            _bm1.HEUserParameterSetValue("PARTNO", findStr);
                            _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                            helper = new PopupHelper(_bm1, "PART");

                            helper.ShowDialog();

                            DataRow slectedRow = (DataRow)helper.SelectedData;
                            if (slectedRow != null)
                            {
                                grd01.SetValue(grd01.Row, 0, "U");
                                grd01.SetValue(grd01.Row, "PARTNO", slectedRow["T_CODE"]);
                                grd01.SetValue(grd01.Row, "PARTNM", slectedRow["T_DESC"]);
                            }
                        }
                        else
                        {
                            grd01.SetValue(row, 0, "U");
                            grd01.SetValue(row, "PARTNO", dt.Rows[0]["T_CODE"]);
                            grd01.SetValue(row, "PARTNM", dt.Rows[0]["T_DESC"]);
                        }
                        SetPartInfor(row);
                        break;
                    default:
                        grd01.SetValue(row, 0, "U");
                        break;
                }






            }
            catch (Exception eLog)
            {

            }
        }


        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            if (grd01.Rows.Count == 1)
            {
                if (string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()) == true)
                {
                    args.Cancel = true;
                    MsgBox.Show("You need to check Customer Code first!!", "Error", MessageBoxButtons.OK);
                    cdx01_VENDCD.Focus();
                    return;

                }
                else if (Lbl_TNO.Text.Length<8== true)
                {
                    args.Cancel = true;
                    MsgBox.Show("You need to check Truck number first!!", "Error", MessageBoxButtons.OK);
                    Lbl_TNO.Focus();
                    return;

                }
                if (MsgBox.Show("Do you want to add new data?", "Question", MessageBoxButtons.YesNo) == DialogResult.No)                
                {
                    args.Cancel = true;
                    label2.Text = "";

                }
                else
                {
                    grd01.AllowEditing = true;
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("TY", GetInvType());
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_NEXT_INVOICE"), set, "OUT_CURSOR");
                    if (source.Tables.Count > 0 && source.Tables[0].Rows.Count > 0)
                    {
                        label2.Text = source.Tables[0].Rows[0]["NEXT_INVOICE"].ToString();
                    }
                    else
                    {
                        label2.Text = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()) == true)
            {
                MsgBox.Show("You neet to select the vendor first.", "Error", MessageBoxButtons.OK);
                cdx01_VENDCD.Focus();
                return;
            }

            Lbl_TNO.Text = textBox1.Text;
        }
        private DEV.Utility.Controls.AxFlexGrid GetSelectedGrd()
        {
            DEV.Utility.Controls.AxFlexGrid grd = null;
            if (tabControl1.SelectedIndex == 0)
            {
                grd = grd02;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                grd = grd03;
            }
            return grd;
        }
        private void axButton2_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count <= 1)
            {
                MsgBox.Show("There is no data to make D.C", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }
            for (int row = 1; row < grd01.Rows.Count; row++)
            {
                if (string.IsNullOrEmpty(grd01.GetValue(row, "INVOICE").ToString()) == false)
                {
                    MsgBox.Show("Already Closed!!", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                    return;
                }
            }
            if (MsgBox.Show("If you select 'YES', data will be closed.\nAre you sure that process this?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
            {


                if (SaveData() == false)
                {
                    return;
                }
                
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                set.Add("INVOICE", label2.Text);
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());                
                set.Add("TYPE", GetInvType());  //--A:KMI Normal, B:ETC Normal, R:Returnable Invoice, S:Resale Invoice, T:Retroactive Invoice, M:Material Return Invoice
                set.Add("DC_TYPE", GetDCType());
                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROC_DATA"), set);
                this.AfterInvokeServer();
                LoadDetail(label2.Text);
                MsgBox.Show("D.C was assigned.", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
            }
        }
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02500", "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void grd03_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.GetSelectedGrd().SelectedRowIndex;
                int col = this.GetSelectedGrd().ColSel;
                if (row < this.GetSelectedGrd().Rows.Fixed) return;

                Lbl_TNO.Text = GetSelectedGrd().GetValue(row, "CARNO").ToString();

                label2.Text = GetSelectedGrd().GetValue(row, "INVOICE").ToString();

                LoadDetail(label2.Text);
                grd01.AllowEditing = false;
            }
            catch (Exception eLog)
            {

            }
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            
            if (grd01.Rows.Count <= 1)
            {
                MsgBox.Show("Select an Invoice to Print", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }
            Print_Invoice();
        }

        private void cbl01_CustPLANT_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdx01_VENDCD.SetValue("", "");
                string selectedValue = this.cbl01_CustPLANT.GetValue().ToString();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", UserInfo.CorporationCode);
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("PLANTCD", selectedValue);
                paramSet.Add("LANG_SET", UserInfo.Language);
                DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.INQUERY_PLANT_DET", paramSet, "OUT_CURSOR").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string cd = dt.Rows[0]["VENDCD"].ToString();
                    string nm = dt.Rows[0]["VENDNM"].ToString();
                    cdx01_VENDCD.SetValue(nm, cd);
                }

            }
            catch (Exception eLog)
            {

            }
        }

    }
}
