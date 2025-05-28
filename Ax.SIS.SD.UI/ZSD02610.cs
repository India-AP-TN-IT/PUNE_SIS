#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using iTextSharp.text.pdf.parser;
using System.Text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Description;
using HE.Framework.Core.Report;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System.Security.Cryptography.X509Certificates;
using iTextSharp.text.pdf.security;
using System.Resources;
using System.Reflection;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZSD02610 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02600";
        private DataTable m_LastInvDT = new DataTable();
        private string m_cerPWD = "";
        private System.Drawing.Image m_cerIMG = null;
        private string m_webAddr = "";
        private byte[] m_certFile = null;
        #region [ 초기화 작업 정의 ]

        public ZSD02610()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }
        private void ClearCtl()
        {
            Lbl_EBELN.Text = "";
            Lbl_PARTNO.Text = "";
            Lbl_ZHSNSAC.Text = "";
        }
        private void SetCustPLANT(string ty)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("TY", ty);
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
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                SetCustPLANT("A");
                this.cdx01_VENDCD.SetValue("303408");
                this.cbl01_CustPLANT.SetValue("KVF1");
                cdx01_VENDCD.Enabled = false;

                ClearCtl();
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "KIN I/F", "KIN_IF", "KIN_IF");                
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "TRUCK", "CARNO", "CARNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 43, "T/SEQ", "CARSEQ", "CARSEQ");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "SCAN", "SCAN_DATE", "SCAN_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "INVOICE", "INVOICE", "INVOICE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "IRN", "E_YN", "E_YN");



                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;


                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "INVOICE", "IVNUM", "IVNUM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "SEQ", "SEQID", "SEQID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PNO", "MATNR", "MATNR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "QTY", "IVQTY", "IVQTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "T/AMT", "ZAIVAMT", "ZAIVAMT");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "GRPID", "GRPID", "GRPID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "I/F RSLT", "KIN_RSLT", "KIN_RSLT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "I/F MSG", "KIN_MSG", "KIN_MSG");


                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "PARTNO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "ZHSNSAC", "ZHSNSAC", "ZHSNSAC");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "EBELN", "EBELN", "EBELN");
                
                LoadData();

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
            LoadData();
        }
        private string GetCondition()
        {
            if (RD_AF.Checked)
            {
                return "F";
            }
            else if(RD_ALL.Checked)
            {
                return "A";
            }
            else if (RD_NF.Checked)
            {
                return "N";
            }
            else if (RD_ERR.Checked)
            {
                return "E";
            }
            return "A";
        }
        private void LoadData()
        {
            try
            {
                ClearCtl();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", axDateEdit1.GetDateText());
                set.Add("TRUCKNO", Txt_Car.Text);
                set.Add("INVOICENO", textBox1.Text);
                set.Add("CON", GetCondition());
                set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_HIST"), set, "OUT_CURSOR");
                grd03.SetValue(source);

                for (int row = 1; row < grd03.Rows.Count; row++)
                {
                    if (grd03.GetValue(row, "KIN_IF").ToString() == "O")
                    {
                        grd03.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                    }
                    else if (grd03.GetValue(row, "KIN_IF").ToString() == "E")
                    {
                        grd03.Rows[row].StyleNew.BackColor = System.Drawing.Color.Yellow;
                    }
                }

                this.AfterInvokeServer();

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

        

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            int row = this.grd02.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            Lbl_EBELN.Text = grd02.GetValue(row, "EBELN").ToString();
            Lbl_PARTNO.Text = grd02.GetValue(row, "PARTNO").ToString();
            Lbl_ZHSNSAC.Text = grd02.GetValue(row, "ZHSNSAC").ToString();
        }

        private void RD_AF_CheckedChanged(object sender, EventArgs e)
        {
            if (RD_AF.Checked || RD_NF.Checked || RD_ALL.Checked || RD_ERR.Checked)
            {
                LoadData();
            }
        }




        private void grd03_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd03.SelectedRowIndex;
                if (row < 1)
                {
                    return;
                }
                if (MsgBox.Show("Do you want to make pdf file for this?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string corcd = UserInfo.CorporationCode;
                    string bizcd = cbo01_BIZCD.GetValue().ToString();
                    string vendcd = cdx01_VENDCD.GetValue().ToString();
                    string plant = cbl01_CustPLANT.GetValue().ToString();
                    string delidate = axDateEdit1.GetDateText();
                    string carno = grd03.GetValue(row, "CARNO").ToString();
                    string carseq = grd03.GetValue(row, "CARSEQ").ToString();
                    string inv = grd03.GetValue(row, "INVOICE").ToString();
                    if (Chk_car.Checked)
                    {
                        inv = "";
                    }
                    ZSD02500 print = new ZSD02500();
                    DataSet ds = print.Print_Invoice(corcd, bizcd, vendcd, plant, delidate, carno, carseq, "", inv, false, true);
                    List<string> duplCheck = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string key = ds.Tables[0].Rows[i]["INVOICE"].ToString().Replace(" ", "");
                        if (duplCheck.Contains(key) == false)
                        {
                            duplCheck.Add(key);
                            DataTable tmpDT = ds.Tables[0].Clone();
                            tmpDT.ImportRow(ds.Tables[0].Rows[i]);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                DataSet tmpDS = new DataSet();
                                
                                tmpDS.Tables.Add(tmpDT);
                                tmpDS.Tables[0].TableName = "DATA";

                                tmpDS.WriteXml(ms, XmlWriteMode.WriteSchema);
                                string xmlData = GetBytesToString(ms.ToArray());
                                if (string.IsNullOrEmpty(xmlData)==false)
                                {
                                    
                                    HEParameterSet set = new HEParameterSet();
                                    set.Add("CORCD", corcd);
                                    set.Add("BIZCD", bizcd);
                                    set.Add("IVNUM", key);
                                    set.Add("DELI_DATE", delidate);
                                    set.Add("CLOB$PDF_XML", xmlData);
                                    //<< TEST
                                    //File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "TEST_" + ".PDF", GetstringToByte(m_LastInvDT.Rows[row]["HEXADECIMAL"].ToString()));
                                    //>>
                                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_XML_DATA"), set);
                                }
                                else
                                {
                                    MsgBox.Show("There is problem", "Error");
                                }
                            }

                        }
                    }
                }
            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
        }

        private string GetBytesToString(byte[] bytes)
        {
            //return Encoding.Default.GetString(bytes);
            string hexValues = BitConverter.ToString(bytes);

            return hexValues;
        }

    }
}

