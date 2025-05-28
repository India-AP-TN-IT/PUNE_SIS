#region ▶ Description & History
/* 
* 프로그램명 : PD20010 계측유형관리 - 사출SPC
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*/
#endregion
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

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 계측 유형 관리 - 사출 SPC
    /// </summary>
    public partial class PD30120 : AxCommonBaseControl
    {
        //private IPD20010 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD30120";
        private string m_LastCarNo = "";
        private string m_LastCarSeq = "";
        private string m_LastGate = "";
        private bool m_bClose = false;
        #region [ 초기화 작업 정의 ]

        public PD30120()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }
        private void SetCustCD()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CUSTCD"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustCD.DataBind(source, this.GetLabel("CUSTCD") + ";" + this.GetLabel("CUSTNM"), "C;L");  

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void SetPartInfor(int row)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
            set.Add("CUSTCD", cbl01_CustCD.GetValue());
            set.Add("PARTNO", grd01.GetValue(row,"PARTNO"));


            set.Add("LANG_SET", this.UserInfo.Language);
            DataSet source = _WSCOM_N.ExecuteDataSet("APG_PD30120.INQUERY_PART_INFOR", set, "OUT_CURSOR");

            if (source.Tables[0].Rows.Count > 0)
            {
                grd01.SetValue(row, "ALCCD", source.Tables[0].Rows[0]["ALCCD"].ToString());
                grd01.SetValue(row, "PGN", source.Tables[0].Rows[0]["PGN"].ToString());
                grd01.SetValue(row, "DELI_TYPE", source.Tables[0].Rows[0]["DELI_TYPE"].ToString());
                grd01.SetValue(row, "UPRICE", source.Tables[0].Rows[0]["UPRICE"].ToString());
            }
            else
            {
                grd01.SetValue(row, "ALCCD","");
                grd01.SetValue(row, "PGN","");
                grd01.SetValue(row, "DELI_TYPE","");
                grd01.SetValue(row, "UPRICE","");                
            }
        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                SetCustCD();
                SetCustPLANT();
                this.cbl01_CustCD.SetValue("303408");
                this.cbl01_CustPLANT.SetValue("KVF1");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "GATE", "GATE", "GATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "TRUCK", "CARNO", "CARNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "SEQ", "CARSEQ", "CARSEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "SCAN", "SCAN_DATE", "SCAN_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "INVOICE", "INVOICE", "INVOICE");

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "TRUCK No.", "CARNO", "CARNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 45, "PGN", "PGN", "PGN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "D/TYPE", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "O/NO", "SANO", "SANO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "P/NAME", "PARTNM", "PARTNM");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "U/PRICE", "UPRICE", "UPRICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "AMOUNT", "AMT", "AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "CGST", "CGST", "CGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "SGST", "SGST", "SGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "IGST", "IGST", "IGST");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 70, "UTGST", "UTGST", "UTGST");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "INVOICE", "INVOICE", "INVOICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "SEQ", "SEQID", "SEQID");

                //<<BUFFERS
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUSTCD", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUST_PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CARSEQ", "CARSEQ", "CARSEQ");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "GATE", "GATE", "GATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "USER_ID", "USER_ID", "USER_ID");
                //>>

                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0";

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "UPRICE");
                this.grd01.Cols["UPRICE"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd01.Cols["AMT"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grd01.Cols["CGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grd01.Cols["SGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST");
                this.grd01.Cols["IGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "UTGST");
                this.grd01.Cols["UTGST"].Format = "###,###,###,##0.##";

                this.grd01.Cols["SANO"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                this.grd01.Cols["PARTNO"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                this.grd01.Cols["QTY"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                this.grd01.Cols["UPRICE"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;


                string TotalQuantity = "0";
                this.Lbl_TotalQuantity.Text = string.Format("{0} : {1}", "Total Quantity", TotalQuantity);
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
            LoadCarData();
            LoadDetail();
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if(SaveData())
            {
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.
            }
        }
        private bool SaveData()
        {

            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD", "CUSTCD", "CUST_PLANT", "DELI_DATE", "CARNO", "CARSEQ"
                    , "GATE", "PARTNO", "DELI_TYPE", "QTY", "UPRICE", "AMT", "CGST"
                    , "SGST", "IGST", "UTGST", "USER_ID", "SANO");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["USER_ID"] = this.UserInfo.EmpNo;
                    rows["CORCD"] = cbo01_CORCD.GetValue();
                    rows["BIZCD"] = cbo01_BIZCD.GetValue();
                    rows["CUSTCD"] = cbl01_CustCD.GetValue();
                    rows["CUST_PLANT"] = cbl01_CustPLANT.GetValue();
                    rows["DELI_DATE"] = dtp01_STD_DATE.GetDateText();
                    rows["CARSEQ"] = m_LastCarSeq;
                    rows["CARNO"] = m_LastCarNo;
                    rows["GATE"] = m_LastGate;
                }

                if (!IsSaveValid(source)) return false;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);                
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_DATA"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 계측유형관리 정보가 저장되었습니다.");
                
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
                    string orderno = grd01.GetValue(row, "SANO").ToString();
                    if(string.IsNullOrEmpty(orderno))
                    {
                        MsgBox.Show("Enter Order No. for the " + row + "row");
                        return false;
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
                    string UPrice = grd01.GetValue(row, "UPRICE").ToString();
                    if (string.IsNullOrEmpty(UPrice))
                    {
                        MsgBox.Show("Unit Price not fetched for the " + row + "row. Contact IT Team.");
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

        private string GetGate()
        {
            if(axCheckBox1.Checked && axCheckBox2.Checked)
            {
                return "";
            }
            else if(axCheckBox1.Checked)
            {
                return "A";
            }
            else if(axCheckBox2.Checked)
            {
                return "B";
            }
            return "";
        }
        

        private void Txt_Car_TextChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private string GetALL_YN()
        {
            if(axRadioButton1.Checked)
            {
                return "N";
            }
            else if(axRadioButton2.Checked)
            {
                return "Y";
            }
            else if (axRadioButton3.Checked)
            {
                return "M";
            }
            return "Y";
        }
        private void LoadCarData()
        {

            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("DELI_DATE", this.dtp01_STD_DATE.GetDateText());
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("CUSTCD", cbl01_CustCD.GetValue());
                set.Add("GATE", GetGate());
                set.Add("TRUCKNO", Txt_Car.Text);
                set.Add("ALL_YN", GetALL_YN());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_TRUCK"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);

                for (int row = 1; row < grd02.Rows.Count; row++)
                {
                    if (string.IsNullOrEmpty(grd02.GetValue(row, "INVOICE").ToString()) == false)
                    {
                        grd02.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
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
        private void axButton1_Click(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private void dtp01_STD_DATE_ValueChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private void axRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }
        

        private void axCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }
        private void LoadDetail()
        {
            m_bClose = false;
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("CARNO", m_LastCarNo);
            set.Add("CARSEQ", m_LastCarSeq);
            set.Add("LANG_SET", UserInfo.Language);
            
            this.BeforeInvokeServer(true);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DET"), set, "OUT_CURSOR", "OUT_CURSOR1");
            this.AfterInvokeServer();

            string TotalQuantity = source.Tables[1].Rows[0]["TOTAL_QTY"].ToString();
            this.Lbl_TotalQuantity.Text = string.Format("{0} : {1}", "Total Quantity", TotalQuantity);

            this.grd01.SetValue(source.Tables[0]);
            if(source.Tables[0].Rows.Count <= 0)
            {
                this.grd01.Cols[4].Visible = true;
            }
            else
            {
                this.grd01.Cols[4].Visible = false;
            }

            for (int row = 1; row < grd01.Rows.Count; row++)
            {
                if (string.IsNullOrEmpty(grd01.GetValue(row, "INVOICE").ToString()) == false)
                {

                    grd01.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                    m_bClose = true;
                }
            }
            for (int row = 1; row < grd02.Rows.Count; row++)
            {
                if (grd02.GetValue(row, "CARNO").ToString() == m_LastCarNo && grd02.GetValue(row, "CARSEQ").ToString() == m_LastCarSeq)
                {
                    grd02.Rows[row].StyleNew.BackColor = System.Drawing.Color.Blue;
                    grd02.Rows[row].StyleNew.ForeColor = System.Drawing.Color.White;
                }
            }
        }
        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd02.SelectedRowIndex;
                int col = this.grd02.ColSel;
                if (row < this.grd02.Rows.Fixed) return;

                Lbl_TNO.Text = grd02.GetValue(row,"CARNO").ToString();
                Lbl_Gate.Text = grd02.GetValue(row, "GATE").ToString();
                Lbl_TSEQ.Text = grd02.GetValue(row, "CARSEQ").ToString();
                Lbl_Scan.Text = grd02.GetValue(row, "SCAN_DATE").ToString();


                m_LastCarNo = Lbl_TNO.Text;
                m_LastCarSeq = Lbl_TSEQ.Text;
                m_LastGate = Lbl_Gate.Text;
                LoadCarData();
                LoadDetail();
                
            }
            catch(Exception eLog)
            {

            }
        }

        private void ReCalcGrid(int row)
        {
            double up = Convert.ToDouble(grd01.GetValue(row, "UPRICE").ToString());
            double qty = Convert.ToDouble(grd01.GetValue(row, "QTY").ToString());

            grd01.SetValue(row, "AMT", up * qty);
           
            grd01.SetValue(row, "CGST", up * qty * 0.14);
            grd01.SetValue(row, "SGST", up * qty * 0.14);

            grd01.SetValue(row, "IGST", up * qty * 0);
            grd01.SetValue(row, "UTGST", up * qty * 0);
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
                switch(grd01.Cols[col].UserData.ToString())
                { 
                    case "UPRICE":
                    case "QTY":
                        ReCalcGrid(row);
                        break;
                    case "PARTNO":
                        findStr = grd01.GetValue(row, col).ToString();
                        paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                        paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                        paramSet.Add("PARTNO", string.IsNullOrEmpty(findStr) ? "@#@#@#@#" : findStr);
                        paramSet.Add("LANG_SET", this.UserInfo.Language);

                        dt = _WSCOM_N.ExecuteDataSet("APG_PD30120.INQUERY_DLG_PART", paramSet, "OUT_CURSOR").Tables[0];
                        if (dt.Rows.Count > 1)
                        {
                            PopupHelper helper = null;
                            PD30120_DLG _bm1 = new PD30120_DLG("PART", "DESC", findStr, "");
                            _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                            _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
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

        private void axButton2_Click(object sender, EventArgs e)
        {
            for (int row = 1; row < grd01.Rows.Count;row++ )
            {
                if(string.IsNullOrEmpty(grd01.GetValue(row,"INVOICE").ToString()) == false)
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
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("CUSTCD", cbl01_CustCD.GetValue());
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("CARNO", m_LastCarNo);
                set.Add("CARSEQ", m_LastCarSeq);

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROC_DATA"), set);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                MsgBox.Show("Invoice was assigned.", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
            }

        }

        private void grd01_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if(m_bClose)
            {
                e.Cancel = true;
                return;
            }
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;
            if (row < 0)
            {
                MsgBox.Show("Select an Invoice to Print","Notice",MessageBoxButtons.OK,ImageKinds.Information);
                return;
            }
            string Invoice_Number = grd01.GetValue(row, "INVOICE").ToString();

            Print_Invoice(Invoice_Number);
        }
        private void Print_Invoice(string invoice)
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/PD30120";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("CUSTCD", cbl01_CustCD.GetValue());
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("CARNO", Lbl_TNO.Text);
                set.Add("CARSEQ", Lbl_TSEQ.Text);
                set.Add("GATE", Lbl_Gate.Text);
                if (invoice == "All")
                {
                    set.Add("INVOICE", "");
                }
                else
                {
                    set.Add("INVOICE", invoice);
                }

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_PRINTDATA"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                int total_invoice_count = ds.Tables[0].Rows.Count % 8 == 0 ? ds.Tables[0].Rows.Count / 8 : (ds.Tables[0].Rows.Count / 8) + 1;
                int last_invoice_parts_count = ds.Tables[0].Rows.Count % 8;

                DataSet ds1 = new DataSet();
                DataTable dt1 = new DataTable();

                dt1 = ds.Tables[0].Clone();
                for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                {
                    dt1.Columns.Add("SID" + i, typeof(String));
                    dt1.Columns.Add("RPCS" + i, typeof(String));
                    dt1.Columns.Add("ORDER_NO" + i, typeof(String));
                    dt1.Columns.Add("PARTNO" + i, typeof(String));
                    dt1.Columns.Add("PARTNM" + i, typeof(String));
                    dt1.Columns.Add("HSN" + i, typeof(String));
                    dt1.Columns.Add("QTY" + i, typeof(String));
                    dt1.Columns.Add("CGST" + i, typeof(String));
                    dt1.Columns.Add("SGST" + i, typeof(String));
                    dt1.Columns.Add("UPRICE" + i, typeof(String));
                    dt1.Columns.Add("AMT" + i, typeof(String));
                }
                dt1.Columns.Add("QRCODE_INFO");

                int start = 0;
                for (int i = 0; i < total_invoice_count; i++)
                {
                    int end = last_invoice_parts_count != 0 ? (i == (total_invoice_count - 1) ? last_invoice_parts_count : 8) : 8;
                    int count = 0;
                    string qrcode_info = "";

                    for (int j = start; j < start + end; j++)
                    {
                        count++;
                        DataRow row = ds.Tables[0].Rows[j];
                        DataRow dr = dt1.NewRow();

                        string current_sid = "SID" + count.ToString();
                        string current_rpcs = "RPCS" + count.ToString();
                        string current_ordno = "ORDER_NO" + count.ToString();
                        string current_partno = "PARTNO" + count.ToString();
                        string current_partnm = "PARTNM" + count.ToString();
                        string current_hsn = "HSN" + count.ToString();
                        string current_qty = "QTY" + count.ToString();
                        string current_cgst = "CGST" + count.ToString();
                        string current_sgst = "SGST" + count.ToString();
                        string current_uprice = "UPRICE" + count.ToString();
                        string current_amt = "AMT" + count.ToString();

                        decimal cgst = Math.Round(Convert.ToDecimal(row["CGST"].ToString()), 2);
                        decimal sgst = Math.Round(Convert.ToDecimal(row["SGST"].ToString()), 2);
                        decimal uprice = Math.Round(Convert.ToDecimal(row["UPRICE"].ToString()), 2);
                        decimal amt = Math.Round(Convert.ToDecimal(row["AMT"].ToString()), 2);
                        decimal assess_value = Math.Round(Convert.ToDecimal(row["ASSESS_VALUE"].ToString()), 2);
                        decimal overall_cgst = Math.Round(Convert.ToDecimal(row["OVERALL_CGST"].ToString()), 2);
                        decimal overall_sgst = Math.Round(Convert.ToDecimal(row["OVERALL_SGST"].ToString()), 2);
                        decimal overall_igst = Math.Round(Convert.ToDecimal(row["OVERALL_IGST"].ToString()), 2);
                        decimal overall_utgst = Math.Round(Convert.ToDecimal(row["OVERALL_UTGST"].ToString()), 2);
                        decimal total_amt = Math.Round(Convert.ToDecimal(row["TOTAL_AMT"].ToString()), 2);
                        string wd_cgst = row["CGST_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                        string wd_sgst = row["SGST_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                        string wd_total_amt = row["TOTALAMT_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");

                        dr["INVOICE"] = " " + row["INVOICE"].ToString();
                        dr["DELI_DATE"] = " " + row["DELI_DATE"].ToString();
                        dr["CARNO"] = " " + row["CARNO"].ToString();
                        dr["VENDNM"] = row["VENDNM"].ToString();
                        dr["ADDRESS_1"] = row["ADDRESS_1"].ToString();
                        dr["ADDRESS_2"] = row["ADDRESS_2"].ToString();
                        dr["VEND_GST"] = row["VEND_GST"].ToString();
                        dr["TOTAL_QTY"] = row["TOTAL_QTY"].ToString();
                        dr["ASSESS_VALUE"] = assess_value.ToString().Contains(".") ? assess_value.ToString() : assess_value.ToString() + ".00";
                        dr["OVERALL_CGST"] = overall_cgst.ToString().Contains(".") ? overall_cgst.ToString() : overall_cgst.ToString() + ".00";
                        dr["OVERALL_SGST"] = overall_sgst.ToString().Contains(".") ? overall_sgst.ToString() : overall_sgst.ToString() + ".00";
                        dr["OVERALL_IGST"] = overall_igst.ToString().Contains(".") ? overall_igst.ToString() : overall_igst.ToString() + ".00";
                        dr["OVERALL_UTGST"] = overall_utgst.ToString().Contains(".") ? overall_utgst.ToString() : overall_utgst.ToString() + ".00";
                        dr["TOTAL_AMT"] = total_amt.ToString().Contains(".") ? total_amt.ToString() : total_amt.ToString() + ".00";
                        dr["CGST_IN_WORDS"] = wd_cgst;
                        dr["SGST_IN_WORDS"] = wd_sgst;
                        dr["TOTALAMT_IN_WORDS"] = wd_total_amt;
                        dr[current_sid] = row["SID"].ToString();
                        dr[current_rpcs] = row["RPCS"].ToString();
                        dr[current_ordno] = row["ORDER_NO"].ToString();
                        dr[current_partno] = row["PARTNO"].ToString();
                        dr[current_partnm] = row["PARTNO"].ToString() + " " + row["PARTNM"].ToString();
                        dr[current_hsn] = row["HSN"].ToString();
                        dr[current_qty] = row["QTY"].ToString();
                        dr[current_cgst] = cgst.ToString().Contains(".") ? "14%/" + cgst.ToString() : "14%/" + cgst.ToString() + ".00";
                        dr[current_sgst] = sgst.ToString().Contains(".") ? "14%/" + sgst.ToString() : "14%/" + sgst.ToString() + ".00";
                        dr[current_uprice] = uprice.ToString().Contains(".") ? uprice.ToString() : uprice.ToString() + ".00";
                        dr[current_amt] = amt.ToString().Contains(".") ? amt.ToString() : amt.ToString() + ".00";

                        decimal cost_with_tax = cgst + sgst + amt;

                        qrcode_info += "T1" + row["ORDER_NO"].ToString() + row["PARTNO"].ToString() + "\n"
                                        + row["INVOICE"].ToString() + " " + row["DELI_DATE"].ToString().Replace(".", "") + row["QTY"].ToString() + " " + Math.Round(cost_with_tax, 2).ToString() + " " + row["HSN"].ToString() + "0.00" + " "
                                        + cgst.ToString() + " " + "0.00 0.00 " + uprice.ToString() + " " + amt.ToString() + " " + sgst.ToString() + " " + "0.00 0.00 "
                                        + amt.ToString() + " " + "0.00 0.00 0.00 37AAZCS2637P1Z8 0" + "\n";

                        if (count == end)
                        {
                            dr["QRCODE_INFO"] = qrcode_info;
                        }
                        dt1.Rows.Add(dr);

                    }

                    if (ds1.Tables.Count == 0)
                    {
                        ds1.Tables.Add(dt1);
                    }

                    HERexSection xmlSection = new HERexSection(ds1, new HEParameterSet());

                    report.Sections.Add("XML" + (i+1), xmlSection);

                    AxRexpertReportViewer.ShowReport(report);
                    

                    dt1.Clear();

                    start += end;
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

        private void axButton3_Click(object sender, EventArgs e)
        {
            Print_Invoice("All");
        }

        private void cbl01_CustCD_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedValue = this.cbl01_CustCD.GetValue().ToString();
            switch(selectedValue)
            {
                case "303408":
                    this.cbl01_CustPLANT.SelectedValue = "KVF1";
                    break;
                case "304069":
                    this.cbl01_CustPLANT.SelectedValue = "MBIA";
                    break;
                case "304070":
                    this.cbl01_CustPLANT.SelectedValue = "GVIA";
                    break;
                default:
                    this.cbl01_CustPLANT.SelectedValue = "KVF1";
                    break;
            }
        }

        private void cbl01_CustPLANT_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedValue = this.cbl01_CustPLANT.GetValue().ToString();
            switch (selectedValue)
            {
                case "KVF1" :
                case "KVF2" :
                    this.cbl01_CustCD.SelectedValue = "303408";
                    break;
                case "MBIA":
                    this.cbl01_CustCD.SelectedValue = "304069";
                    break;
                case "GVIA":
                    this.cbl01_CustCD.SelectedValue = "304070";
                    break;
                default:
                    this.cbl01_CustCD.SelectedValue = "303408";
                    break;
            }
        }

        private void axRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }

    }
}
