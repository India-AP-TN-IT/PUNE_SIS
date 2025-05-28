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
    public partial class ZSD02600 : AxCommonBaseControl
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

        public ZSD02600()
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
                GetCerDATA(out m_cerPWD, out m_cerIMG, out m_certFile, out m_webAddr);
                Lbl_Web.Text = m_webAddr;
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

        private void btn01_FILE_FIND_Click(object sender, EventArgs e)
        {
            try
            {
                
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PDF File (*.pdf)|*.pdf";

                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.txt_FILE.Text = ofd.FileName;
                    BeforeInvokeServer(true);
                    this.ReadDataPDF(this.txt_FILE.Text);
                }
                else
                {
                    this.txt_FILE.ResetText();
                }
            }
            catch(Exception eLog)
            {

            }
            finally
            {
                AfterInvokeServer();
            }
        }

        private void btn01_FILE_READ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txt_FILE.Text.Trim()))
            {
                MessageBox.Show("Select the PDF and then push the read button.");
                return;
            }
            this.ReadDataPDF(this.txt_FILE.Text);
        }
        
        
        private void ReadDataPDF(string fileName)
        {
            
            PdfReader reader = new PdfReader(fileName);
            m_LastInvDT = new DataTable();
            string INVOICE_NO = string.Empty;
            List<string> dupInvoice = new List<string>();
            
            try
            {
                for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string extractedText = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                    byte[] utf8Bytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(extractedText));
                    string pageText = Encoding.UTF8.GetString(utf8Bytes);

                    

                   
                    string[] sData = pageText.Split(new string[] { "\n" }, StringSplitOptions.None);

                    #region Get Data From PDF String
                    for (int i = 0; i < sData.Length; i++)
                    {
                        string sRow = sData[i].ToUpper();                     
                       

                        if (sRow.Contains("INVOICE NO."))
                        {
                            string invNO = sData[i + 1].Replace(" ", "");
                            if (dupInvoice.Contains(invNO) == false)
                            {                                
                                dupInvoice.Add(invNO);                                
                            }
                        }

                        

                    }
                    #endregion
                    
                }
                if (dupInvoice.Count == 0)
                {
                    MessageBox.Show("No Data in PDF");
                    return;
                }
                else
                {
                    Lbl_InvCount.Text = dupInvoice.Count.ToString("N0");
                    SetInvoiceData(dupInvoice);

                    grd02.SetValue(m_LastInvDT);
                    for (int row = 1; row < grd02.Rows.Count; row++)
                    {
                        int grp = Convert.ToInt32(grd02.GetValue(row, "GRPID").ToString());
                        if ((grp%2) == 0)
                        {
                            grd02.Rows[row].StyleNew.BackColor = System.Drawing.Color.Khaki;
                        }
                        else
                        {
                            grd02.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        private void SignPdfFile(string sourceDocument, string destinationPath, string certPath, string password, string reason, string location)
        {

            X509Certificate2 cert1 = new X509Certificate2(certPath, password, X509KeyStorageFlags.Exportable);

            var pk = Org.BouncyCastle.Security.DotNetUtilities.GetKeyPair(cert1.PrivateKey).Private;
            // convert the type to be used at .SetCrypt(); 
            Org.BouncyCastle.X509.X509Certificate bcCert = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(cert1);

        }
        private void SignWithThisCert(string pdfPath)
        {

            string pfxPwd = m_cerPWD;

            string desPath = pdfPath.Substring(0, pdfPath.Length - 4) + "_" + ".PDF";

            X509Certificate2 cert = new X509Certificate2(m_certFile, pfxPwd);
            Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
            Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(cert.RawData) };

            IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");
            PdfReader pdfReader = new PdfReader(pdfPath);
            FileStream signedPdf = new FileStream(desPath, FileMode.Create);  //the output pdf file
            PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
            PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
            //here set signatureAppearance at your will
            signatureAppearance.Reason = "Invoice";
            signatureAppearance.Location = "Seoyon E-Hwa";
            signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
         
            signatureAppearance.Acro6Layers = false;
            signatureAppearance.Layer4Text = PdfSignatureAppearance.questionMark;
            
            signatureAppearance.SetVisibleSignature(new iTextSharp.text.Rectangle(630, 170, 440, 200), 1, null);



            MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CADES);
            File.Delete(pdfPath);
            File.Move(desPath, pdfPath);

        }
        private byte[] ExtractPages(string invoice, PdfReader reader, int startpage, int endpage)
        {
            try
            {
                byte[] hexData = null;
                Document sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                PdfImportedPage importedPage = null;

                sourceDocument = new Document(reader.GetPageSizeWithRotation(startpage));

                string filePath = "";
                for (int i = 0; i < 1000; i++)
                {
                    filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + invoice+"_"+i.ToString() + ".PDF";

                    if (File.Exists(filePath) == false)
                    {
                        break;
                    }
                }
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    pdfCopyProvider = new PdfCopy(sourceDocument, fs);

                    sourceDocument.Open();

                    for (int i = startpage; i <= endpage; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                      
                        pdfCopyProvider.AddPage(importedPage);
                        
                    }
                   
                    
                    sourceDocument.Close();
                    SignWithThisCert(filePath);
                    FileStream fsRD = File.OpenRead(filePath);
                    int length = Convert.ToInt32(fsRD.Length);
                    hexData = new byte[length];
                    fsRD.Read(hexData, 0, length);
                    fsRD.Close();

                    
                }
                try
                {
                    if (Chk_AutoDel.Checked)
                    {
                        File.Delete(filePath);
                    }
                }
                catch(Exception fileError)
                {

                }
                
                return hexData;
            }
            catch(Exception eLog)
            {
                return null;
            }
        }
        private string GetBytesToString(byte[] bytes)
        {
            //return Encoding.Default.GetString(bytes);
            string hexValues = BitConverter.ToString(bytes).Replace("-", "");

            return hexValues;
        }
        
        
        private void SetInvoiceData(List<string> invList)
        {

            m_LastInvDT = new DataTable();
            try
            {
                
                foreach(string  inv in invList)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                    set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                    set.Add("DELI_DATE", axDateEdit1.GetDateText());
                    set.Add("INVOICENO", inv);

                    DataTable inDT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_INVOICE"), set, "OUT_CURSOR").Tables[0];
                    if (m_LastInvDT.Columns.Count <= 0)
                    {
                        m_LastInvDT = inDT.Clone();
                        m_LastInvDT.Columns.Add("HEXADECIMAL", typeof(object));
                        
                    }
                    int row = m_LastInvDT.Rows.Count;
                    foreach(DataRow dr in inDT.Rows)
                    {
                        m_LastInvDT.ImportRow(dr);
                        row++;
                    }

                }
            }
            catch(Exception eLog)
            {
                MessageBox.Show(eLog.Message);
            }
            finally
            {
                
            }
        }
        private KIAService.TAB_DATA_HEADER GetKINHeadData(DataRow dr)
        {
            KIAService.TAB_DATA_HEADER tmp = new KIAService.TAB_DATA_HEADER();

            tmp.IVNUM = dr["IVNUM"].ToString();
            tmp.IVDAT = dr["IVDAT"].ToString(); // Invoice Date
            tmp.LIFNR = dr["LIFNR"].ToString(); // Vendor Code
            tmp.MATNR = dr["MATNR"].ToString(); // Part No
            tmp.ZSHOP = dr["ZSHOP"].ToString(); // GR Shop
            tmp.EBELN = dr["EBELN"].ToString(); // PO number
            tmp.IVQTY = dr["IVQTY"].ToString(); // Invoice Quantity
            tmp.ZAIVAMT = dr["ZAIVAMT"].ToString(); //Invoice amount
            tmp.ZANETPR = dr["ZANETPR"].ToString(); //Unit Price
            tmp.ZANETWR = dr["ZANETWR"].ToString(); //Net Value
            tmp.ZCGST = dr["ZCGST"].ToString(); //CGST
            tmp.ZSGST = dr["ZSGST"].ToString(); //SGST
            tmp.ZIGST = dr["ZIGST"].ToString(); //IGST
            tmp.ZUGST = dr["ZUGST"].ToString(); //UGST
            tmp.ZATCS = dr["ZATCS"].ToString(); //TCS Amount
            tmp.ZHSNSAC = dr["ZHSNSAC"].ToString(); //HSN or SAC Code
            tmp.ZGSTIN = dr["ZGSTIN"].ToString(); //GST NUMBER
            tmp.VEHNO = dr["VEHNO"].ToString(); //Truck number
            tmp.IRN = dr["IRN"].ToString(); //E-Invoice No
            tmp.EWAYBILL = dr["EWAYBILL"].ToString(); // EWAY BILL Number
            tmp.ZNUM1 = "";
            tmp.ZNUM2 = "";
            tmp.ZNUM3 = "";
            tmp.ZNUM4 = "";
            tmp.ZNUM5 = "";
            tmp.ZCHAR2 = "";
            tmp.ZCHAR3 = "";
            tmp.ZCHAR4 = "";
            tmp.ZCHAR5 = "";

            return tmp;
        }
        
        private bool SendDataToKIN(ref DataTable dt, out string msg)
        {
            try
            {
                KIAService.O_DATA rslt = new KIAService.O_DATA();
                KIAService.Service kinSvr = new KIAService.Service();
                kinSvr.Url = m_webAddr;
                Dictionary<string, List<KIAService.TAB_DATA_HEADER>> dicINV = new Dictionary<string, List<KIAService.TAB_DATA_HEADER>>();
                Dictionary<string, string> dicHexa = new Dictionary<string,string>();
                for (int row = 0; row < dt.Rows.Count;row++)
                {
                    string key= dt.Rows[row]["IVNUM"].ToString();
                    if(dicINV.ContainsKey(key) == false)
                    {
                        
                        dicINV.Add(key, new List<KIAService.TAB_DATA_HEADER>());
                        dicINV[key].Add(GetKINHeadData(dt.Rows[row]));
                        dicHexa.Add(key, dt.Rows[row]["HEXADECIMAL"].ToString());
                        
                    }
                    else
                    {
                        dicINV[key].Add(GetKINHeadData(dt.Rows[row]));
                    }
                }
                
                foreach(KeyValuePair<string, List<KIAService.TAB_DATA_HEADER>> pair in dicINV)
                {
                    KIAService.INUPUT_DATA input = new KIAService.INUPUT_DATA();
                    input.GET_DATA = pair.Value.ToArray();
                    rslt = kinSvr.getData(dicHexa[pair.Key], input);
                    for(int row=0;row<dt.Rows.Count;row++)
                    {
                        if(dt.Rows[row]["IVNUM"].ToString() == pair.Key)
                        {
                            string pno = dt.Rows[row]["MATNR"].ToString();
                            for(int i=0;i<rslt.GET_DATA_01.Length;i++)
                            {
                                if(pair.Value[i].MATNR == pno)
                                {
                                    dt.Rows[row]["KIN_RSLT"] = rslt.GET_DATA_01[i].IFRESULT;
                                    dt.Rows[row]["KIN_MSG"] = rslt.GET_DATA_01[i].IFFAILMSG;
                                }
                                                               
                            }
                        }
                    }
                    
                }
                
                msg = "ok";
                return true;
            }
            catch(Exception eLog)
            {
                msg = eLog.Message;
                return false;
            }
        }
        private void SetDataHex(string fileName, ref DataTable dt)
        {
            PdfReader reader = new PdfReader(fileName);
            Dictionary<string, string> dupInvoice = new Dictionary<string, string>();
            for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string extractedText = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                byte[] utf8Bytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(extractedText));
                string pageText = Encoding.UTF8.GetString(utf8Bytes);
                string[] sData = pageText.Split(new string[] { "\n" }, StringSplitOptions.None);

                for (int i = 0; i < sData.Length; i++)
                {
                    string sRow = sData[i].ToUpper();


                    if (sRow.Contains("INVOICE NO."))
                    {
                        string invNO = sData[i + 1].Replace(" ", "");
                        if (dupInvoice.ContainsKey(invNO) == false)
                        {
                            byte[] hex = ExtractPages(invNO, reader, pageNo, pageNo);
                            string hexToStr = GetBytesToString(hex);
                            dupInvoice.Add(invNO, hexToStr);                            
                        }
                    }
                }

            }
            for(int row=0;row<dt.Rows.Count;row++)
            {
                string key = dt.Rows[row]["IVNUM"].ToString();
                dt.Rows[row]["HEXADECIMAL"] = dupInvoice[key];
            }
            
        }

        private byte[] GetstringToByte(string byString)
        {
            return ZSD02100.HexStringToBytes(byString);
        }
        private System.Drawing.Image GetImage(string strData)
        {
            byte[] data = GetstringToByte(strData);
            System.Drawing.Image rslt = null;
            using (Stream stream = new MemoryStream(data))
            {
                rslt = System.Drawing.Image.FromStream(stream);
            }
            return rslt;
        }
        
        private void GetCerDATA(out string pwd, out System.Drawing.Image img, out byte[] file, out string addr)
        {
            pwd = "";
            img = null;
            file = null;
            addr = "";
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                DataTable inDT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_CERT_DATA"), set, "OUT_CURSOR").Tables[0];
                if(inDT.Rows.Count>0)
                {
                    pwd =  inDT.Rows[0]["CER_PWD"].ToString();
                    string strFile = inDT.Rows[0]["CER_FILE"].ToString();
                    string strPic = inDT.Rows[0]["CER_PIC"].ToString();
                    m_webAddr = inDT.Rows[0]["WEB_ADDR"].ToString();
                    img = GetImage(strPic);
                    file = GetstringToByte(strFile);

                }
            }
            catch(Exception eLog)
            {
            }
        }
        private void btn01_FILE_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                btn01_FILE_SAVE.Enabled = false;
                this.BeforeInvokeServer(true);
               
               
                //ToDo : Sending data to KIN
                if (m_LastInvDT.Rows.Count > 0)
                {
                    string msg = "";
                    SetDataHex(txt_FILE.GetValue().ToString(), ref m_LastInvDT);
                    
                    if (SendDataToKIN(ref m_LastInvDT, out msg) == true)
                    {
                        for (int row = 0; row < m_LastInvDT.Rows.Count; row++)
                        {

                            HEParameterSet set = new HEParameterSet();
                            set.Add("CORCD", UserInfo.CorporationCode);
                            set.Add("BIZCD", cbo01_BIZCD.GetValue());
                            set.Add("IVNUM", m_LastInvDT.Rows[row]["IVNUM"]);
                            set.Add("IVDAT", m_LastInvDT.Rows[row]["IVDAT"]);
                            set.Add("LIFNR", m_LastInvDT.Rows[row]["LIFNR"]);
                            set.Add("MATNR", m_LastInvDT.Rows[row]["MATNR"]);
                            set.Add("ZSHOP", m_LastInvDT.Rows[row]["ZSHOP"]);
                            set.Add("EBELN", m_LastInvDT.Rows[row]["EBELN"]);
                            set.Add("IVQTY", m_LastInvDT.Rows[row]["IVQTY"]);
                            set.Add("ZAIVAMT", m_LastInvDT.Rows[row]["ZAIVAMT"]);
                            set.Add("ZANETPR", m_LastInvDT.Rows[row]["ZANETPR"]);
                            set.Add("ZANETWR", m_LastInvDT.Rows[row]["ZANETWR"]);
                            set.Add("ZCGST", m_LastInvDT.Rows[row]["ZCGST"]);
                            set.Add("ZSGST", m_LastInvDT.Rows[row]["ZSGST"]);
                            set.Add("ZIGST", m_LastInvDT.Rows[row]["ZIGST"]);
                            set.Add("ZUGST", m_LastInvDT.Rows[row]["ZUGST"]);
                            set.Add("ZATCS", m_LastInvDT.Rows[row]["ZATCS"]);
                            set.Add("ZHSNSAC", m_LastInvDT.Rows[row]["ZHSNSAC"]);
                            set.Add("ZGSTIN", m_LastInvDT.Rows[row]["ZGSTIN"]);
                            set.Add("VEHNO", m_LastInvDT.Rows[row]["VEHNO"]);
                            set.Add("IRN", m_LastInvDT.Rows[row]["IRN"]);
                            set.Add("EWAYBILL", m_LastInvDT.Rows[row]["EWAYBILL"]);
                            set.Add("KIN_MSG", m_LastInvDT.Rows[row]["KIN_MSG"]);
                            set.Add("KIN_RSLT", m_LastInvDT.Rows[row]["KIN_RSLT"]);
                            set.Add("PARTNO", m_LastInvDT.Rows[row]["PARTNO"]);
                            set.Add("CLOB$HEXADECIMAL", m_LastInvDT.Rows[row]["HEXADECIMAL"]);
                            //<< TEST
                            //File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "TEST_" + ".PDF", GetstringToByte(m_LastInvDT.Rows[row]["HEXADECIMAL"].ToString()));
                            //>>
                            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_KIN_DATA"), set);

                        }
                        LoadData();

                        this.ReadDataPDF(this.txt_FILE.Text);
                    }
                    else
                    {
                        AfterInvokeServer();
                        MessageBox.Show(msg, "Error");
                    }
                    
                }
                else
                {
                    AfterInvokeServer();
                    MessageBox.Show("There is no data to send");
                }
                AfterInvokeServer();
            }
            catch(Exception eLog)
            {
                AfterInvokeServer();
                MessageBox.Show(eLog.Message);
            }
            finally
            {
                AfterInvokeServer();
                btn01_FILE_SAVE.Enabled = true;
            }
        }

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
            int row = this.grd03.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            if(MsgBox.Show("Do you want to make pdf file for this?", "Question",MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                print.Print_Invoice(corcd, bizcd, vendcd, plant, delidate, carno, carseq, "", inv, false);
                //Print_Invoice(corcd, bizcd, vendcd, plant, delidate, carno, carseq, "", inv);
            }
        }

    }
}

