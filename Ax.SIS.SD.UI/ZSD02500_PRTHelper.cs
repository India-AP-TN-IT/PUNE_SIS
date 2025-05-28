using C1.C1Preview;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using ZXing;
using ZXing.QrCode;

namespace Ax.SIS.SD.UI
{
    public class ZSD02500_PRTHelper
    {
        private AxClientProxy m_DB;
        public struct CertST
        {
            public byte[] certFile;
            public string certPwd;
            public Bitmap pic;
        }
        private static CertST m_CertPDF;

        private static Bitmap GetBitmap(byte[] pic)
        {
            Image image = null;
            Bitmap bmp = null;
            if (pic != null && pic.Length > 0)
            {
                using (Stream stream = new MemoryStream(pic))
                {
                    image = System.Drawing.Image.FromStream(stream);
                }
            }
            bmp = (Bitmap)image;

            return bmp;
        }

        public static void SetCertPDF(byte[] certFile, byte[] pic, string passwd)
        {
            m_CertPDF = new CertST();
            m_CertPDF.certFile = certFile;
            m_CertPDF.certPwd = passwd;

            m_CertPDF.pic = GetBitmap(pic);
        }
        C1.C1Report.C1Report m_report = null;
        C1.Win.C1Preview.C1PrintPreviewDialog m_prtPreView = null;
        private int m_PageUnit = 8;
        public int PageUnit
        {
            get { return m_PageUnit; }
            set { m_PageUnit = value; }
        }

        public ZSD02500_PRTHelper(string rptFile, string rptName, ref AxClientProxy db)
        {
            m_report = new C1.C1Report.C1Report();
            m_prtPreView = new C1.Win.C1Preview.C1PrintPreviewDialog();

            var fileName = rptFile.Replace("/", ".");
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + fileName);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            m_report.Load(xmlDoc, rptName);
            m_DB = db;

        }
        private Bitmap BigSizeQR(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 1500,
                Height = 1500
            };

            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            // save the image to your system and set its image format to Png
            Bitmap qrCodeBitmap = writer.Write(data);
            return qrCodeBitmap;
        }
        private Bitmap SmallSizeQR(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 300,
                Height = 300
            };

            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            // save the image to your system and set its image format to Png
            Bitmap qrCodeBitmap = writer.Write(data);
            return qrCodeBitmap;
        }
        private string ZP(string num)
        {
            if (num == "0")
            {
                return "0.00";
            }
            return num;
        }
        private string GetBCDData(int row, bool bLast, DataRow dr)
        {
            string data = "";
            if (string.IsNullOrEmpty(dr["PARTNO"].ToString()) == false)
            {

                data += dr["SHOP_CODE"].ToString();
                data += dr["ORDER_NO"].ToString();
                data += dr["PARTNO"].ToString().Replace("-", "");
                data += "\r\n";
                data += dr["INVOICE"].ToString();
                data += "\t";
                data += dr["DELI_DATE"].ToString().Replace(".", "").Replace("/", "").Replace("-", "");
                data += dr["QTY"].ToString();
                data += "\t";
                data += ZP(dr["AMT_PLS_GST"].ToString());
                data += "\t";
                data += dr["HSN"].ToString();
                data += "0.00";
                data += "\t";
                data += ZP(dr["SGST"].ToString());
                data += "\t";
                data += ZP(dr["IGST"].ToString());
                data += "\t";
                data += ZP(dr["TCS"].ToString());
                data += "\t";
                data += ZP(dr["UPRICE"].ToString());
                data += "\t";
                data += ZP(dr["AMT"].ToString());
                data += "\t";
                data += ZP(dr["CGST"].ToString());
                data += "\t";
                data += "0.00";
                data += "\t";
                data += "0.00";
                data += "\t";
                data += ZP(dr["AMT"].ToString());
                data += "\t";
                data += "0.00";
                data += "\t";
                data += "0";
                data += "\t";
                data += "0";
                data += "\t";
                data += dr["GSTNO"].ToString();
                //data += "	 ";
                data += "\t";
                if (row == 0)
                {
                    data += dr["IRN"].ToString();


                }
                if (bLast == false)
                {
                    data += "\r\n";
                }
            }
            return data;
        }
        private bool IsLastPage(int curPage, int pages, int tableRows, int pageUnit, int innerIDX)
        {
            if (curPage < pages - 1)
            {
                if (innerIDX == pageUnit - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (innerIDX == tableRows - (curPage * pageUnit) - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void PrintInvoice(DataTable dt, bool bPreview = false)
        {
            if (dt != null && dt.Rows.Count > 0)
            {



                int pages = (int)Math.Ceiling(dt.Rows.Count / (m_PageUnit * 1.0));
                int remainCountRow = dt.Rows.Count % m_PageUnit;
                int addPageCount = Convert.ToInt32(dt.Rows[0]["ADDPAGE"]);

                m_report.MaxPages = addPageCount;
                m_report.RecordsPerPage = addPageCount;
                string corcd = "";
                string bizcd = "";
                string custcd = "";
                string cust_plant = "";
                string invoice = "";
                string ymd = "";
                for (int page = 0; page < pages; page++)
                {


                    int pageStartIDX = page * m_PageUnit;
                    corcd = dt.Rows[pageStartIDX]["CORCD"].ToString();
                    bizcd = dt.Rows[pageStartIDX]["BIZCD"].ToString();
                    custcd = dt.Rows[pageStartIDX]["CUSTCD"].ToString();
                    cust_plant = dt.Rows[pageStartIDX]["CUST_PLANT"].ToString();
                    invoice = dt.Rows[pageStartIDX]["INVOICE"].ToString();
                    ymd = dt.Rows[pageStartIDX]["YMD"].ToString();
                    string custQR = "";
                    int itemNO = 1;
                    int innerRow = 0;
                    for (int row = pageStartIDX; row < (pageStartIDX + m_PageUnit); row++)
                    {
                        

                        //<<Initializing 

                        WritePRT("fDATA" + (itemNO).ToString(), "");
                        WritePRT("fNUM" + (itemNO).ToString(), "");
                        WritePRT("fPONO" + (itemNO).ToString(), "");
                        WritePRT("fPART" + (itemNO).ToString(), "");
                        WritePRT("fQTY" + (itemNO).ToString(), "");
                        WritePRT("fUP" + (itemNO).ToString(), "");
                        WritePRT("fCGSTP" + (itemNO).ToString(), "");
                        WritePRT("fSGSTP" + (itemNO).ToString(), "");
                        WritePRT("fIGSTP" + (itemNO).ToString(), "");

                        WritePRT("fCGSTA" + (itemNO).ToString(), "");
                        WritePRT("fSGSTA" + (itemNO).ToString(), "");
                        WritePRT("fIGSTA" + (itemNO).ToString(), "");
                        WritePRT("fTOT" + (itemNO).ToString(), "");
                        WritePRT("fALCNUM" + (itemNO).ToString(), "");
                        WritePRT("fALC" + (itemNO).ToString(), "");
                        WritePRT("fTICK", "");
                        WritePRT("fSIGN", "");

                        WritePRT("fIRNACKNO", "");
                        WritePRT("fIRNACKDT", "");
                        WritePRT("fPAN", "");
                        WritePRT("fCUST_PLANT", "");
                        WritePRT("fSHOP_CODE", "");
                        
                        //>>

                        if ((dt.Rows.Count - 1) >= row)
                        {
                            bool bLast = IsLastPage(page, pages, dt.Rows.Count, m_PageUnit, innerRow);

                            custQR += GetBCDData(innerRow, bLast, dt.Rows[row]);
                            //<<Assigning
                            WritePRT("fDATA" + (itemNO).ToString(), invoice + "/" + dt.Rows[row]["PARTNO"].ToString());
                            WritePRT("fNUM" + (itemNO).ToString(), itemNO.ToString());
                            WritePRT("fPONO" + (itemNO).ToString(), dt.Rows[row]["ORDER_NO"].ToString());
                            WritePRT("fPART" + (itemNO).ToString(), dt.Rows[row]["PARTNO"].ToString().Replace("-", "") + "-" + dt.Rows[row]["PARTNM"].ToString());
                            WritePRT("fQTY" + (itemNO).ToString(), dt.Rows[row]["QTY"].ToString());
                            WritePRT("fUP" + (itemNO).ToString(), dt.Rows[row]["UPRICE"].ToString());
                            WritePRT("fCGSTP" + (itemNO).ToString(), dt.Rows[row]["CGST_PER"].ToString());
                            WritePRT("fSGSTP" + (itemNO).ToString(), dt.Rows[row]["SGST_PER"].ToString());
                            WritePRT("fIGSTP" + (itemNO).ToString(), dt.Rows[row]["IGST_PER"].ToString());


                            WritePRT("fCGSTP" + (itemNO).ToString(), dt.Rows[row]["CGST_PER"].ToString());
                            WritePRT("fSGSTP" + (itemNO).ToString(), dt.Rows[row]["SGST_PER"].ToString());
                            WritePRT("fIGSTP" + (itemNO).ToString(), dt.Rows[row]["IGST_PER"].ToString());

                            WritePRT("fCGSTA" + (itemNO).ToString(), dt.Rows[row]["CGST"].ToString());
                            WritePRT("fSGSTA" + (itemNO).ToString(), dt.Rows[row]["SGST"].ToString());
                            WritePRT("fIGSTA" + (itemNO).ToString(), dt.Rows[row]["IGST"].ToString());
                            WritePRT("fTOT" + (itemNO).ToString(), dt.Rows[row]["AMT"].ToString());
                            WritePRT("fALCNUM" + (itemNO).ToString(), itemNO.ToString());
                            WritePRT("fALC" + (itemNO).ToString(), dt.Rows[row]["ALC_DET"].ToString());
                            //>>
                            innerRow++;

                        }
                        itemNO++;

                    }
                    //One Time Wring Area
                    WritePRT("fSHOP_CODE", dt.Rows[pageStartIDX]["CUST_SHOP"].ToString());
                    WritePRT("fCUST_PLANT", dt.Rows[pageStartIDX]["CUST_PLANT"].ToString());
                    WritePRT("fVENDNM1", dt.Rows[pageStartIDX]["VENDNM"].ToString());
                    WritePRT("fIRN", dt.Rows[pageStartIDX]["IRN"].ToString());
                    if (string.IsNullOrEmpty(dt.Rows[pageStartIDX]["OLD_IVNO"].ToString()) == false)
                    {
                        WritePRT("fINVOICE", dt.Rows[pageStartIDX]["INVOICE"].ToString() + " / Tally:" + dt.Rows[pageStartIDX]["OLD_IVNO"].ToString());
                    }
                    else
                    {
                        WritePRT("fINVOICE", dt.Rows[pageStartIDX]["INVOICE"].ToString());
                    }
                    
                    WritePRT("fDELI_DATE", dt.Rows[pageStartIDX]["DELI_DATE_TIME"].ToString());
                    WritePRT("fHSN_CODE", dt.Rows[pageStartIDX]["HSN"].ToString());
                    WritePRT("fTRUCK_NO", dt.Rows[pageStartIDX]["CARNO"].ToString());
                    WritePRT("fEWBNO", dt.Rows[pageStartIDX]["EWAY_BILL_NO"].ToString());
                    WritePRT("fSEQ_FROM", dt.Rows[pageStartIDX]["ST_SEQNO"].ToString());
                    WritePRT("fSEQ_TO", dt.Rows[pageStartIDX]["ED_SEQNO"].ToString());
                    WritePRT("fCOMNM", dt.Rows[pageStartIDX]["COMNM"].ToString());
                    WritePRT("fCOM_ADDR", dt.Rows[pageStartIDX]["COMADDR"].ToString());
                    WritePRT("fIRN_QR", BigSizeQR(dt.Rows[pageStartIDX]["IRN"].ToString()));
                    WritePRT("fCUST_QR", BigSizeQR(custQR));
                    WritePRT("fWD_CGST", dt.Rows[pageStartIDX]["CGST_IN_WORDS"].ToString());
                    WritePRT("fWD_SGST", dt.Rows[pageStartIDX]["SGST_IN_WORDS"].ToString());
                    WritePRT("fWD_TOTAL", dt.Rows[pageStartIDX]["TOTALAMT_IN_WORDS"].ToString());
                    WritePRT("fTOTT", dt.Rows[pageStartIDX]["ASSESS_VALUE"].ToString());
                    WritePRT("fQTYT", dt.Rows[pageStartIDX]["TOTAL_QTY"].ToString());
                    WritePRT("fINVOICE_BARCODE", dt.Rows[pageStartIDX]["INVOICE"].ToString());
                    WritePRT("fPLANT", dt.Rows[pageStartIDX]["PLANTCD"].ToString());
                    WritePRT("fHKMC_VENDCD", dt.Rows[pageStartIDX]["HKMC_VENDCD"].ToString());
                    WritePRT("fSHOP_CODE", dt.Rows[pageStartIDX]["SHOP_CODE"].ToString());
                    WritePRT("fGATENO", dt.Rows[pageStartIDX]["CUST_GATE"].ToString());
                    WritePRT("fVEND_GSTNO", dt.Rows[pageStartIDX]["VEND_GST"].ToString());
                    WritePRT("fVENDNM", dt.Rows[pageStartIDX]["VENDNM"].ToString());
                    WritePRT("fVEND_ADDR", dt.Rows[pageStartIDX]["CUST_FADDR"].ToString());
                    WritePRT("fCOM_ADDR1", dt.Rows[pageStartIDX]["ADDRESS_1"].ToString());
                    WritePRT("fCGST_T", dt.Rows[pageStartIDX]["CGST_PER"].ToString());
                    WritePRT("fSGST_T", dt.Rows[pageStartIDX]["SGST_PER"].ToString());
                    WritePRT("fIGST_T", dt.Rows[pageStartIDX]["IGST_PER"].ToString());
                    WritePRT("fUGST_T", dt.Rows[pageStartIDX]["UTGST_PER"].ToString());
                    WritePRT("fTGST_T", dt.Rows[pageStartIDX]["TCS_PER"].ToString());

                    WritePRT("fCGST_A", dt.Rows[pageStartIDX]["OVERALL_CGST"].ToString());
                    WritePRT("fSGST_A", dt.Rows[pageStartIDX]["OVERALL_SGST"].ToString());
                    WritePRT("fIGST_A", dt.Rows[pageStartIDX]["OVERALL_IGST"].ToString());
                    WritePRT("fUGST_A", dt.Rows[pageStartIDX]["OVERALL_UTGST"].ToString());
                    WritePRT("fTGST_A", dt.Rows[pageStartIDX]["OVERALL_TCS"].ToString());
                    WritePRT("fTOT_AMT2", dt.Rows[pageStartIDX]["ASSESS_VALUE"].ToString());
                    WritePRT("fGAMT", dt.Rows[pageStartIDX]["TOTAL_AMT"].ToString());
                    WritePRT("fGSTNO", dt.Rows[pageStartIDX]["GSTNO"].ToString());

                    WritePRT("fIRNACKNO", dt.Rows[pageStartIDX]["IRN_ACK_NO"].ToString());
                    WritePRT("fIRNACKDT", dt.Rows[pageStartIDX]["IRN_ACK_DATE"].ToString());
                    WritePRT("fPAN", dt.Rows[pageStartIDX]["PANNO"].ToString());

                    //>>
                    if (bPreview == false)
                    {

                        if (dt.Rows[pageStartIDX]["CUST_PLANT"].ToString().Contains("KVF") || dt.Rows[pageStartIDX]["CUST_PLANT"].ToString().Contains("HVF"))
                        {
                            C1.C1Report.C1Report signedReport = new C1.C1Report.C1Report();
                            signedReport.CopyFrom(m_report);
                            signedReport.C1Document.Pages.RemoveAt(1);
                            signedReport.C1Document.Pages.RemoveAt(1);
                            signedReport.C1Document.Pages.RemoveAt(1);
                            string signedInvoiceFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + invoice + "_" + page + ".pdf";
                            signedReport.RenderToFile(signedInvoiceFile, C1.C1Report.FileFormatEnum.PDF);
                            SignWithThisCert(signedInvoiceFile);
                            byte[] hexData = null;
                            using (FileStream fs = new FileStream(signedInvoiceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                int length = Convert.ToInt32(fs.Length);
                                hexData = new byte[length];
                                fs.Read(hexData, 0, length);
                            }

                            SetXML_Table(corcd, bizcd, custcd, cust_plant, ymd, invoice, Path.GetFileName(signedInvoiceFile), hexData);
                            File.Delete(signedInvoiceFile);
                            WritePRT("fTICK", m_CertPDF.pic);
                            WritePRT("fSIGN", GetFakeSign(corcd));
                            m_report.C1Document.Pages.RemoveAt(0);
                            m_report.C1Document.Pages.RemoveAt(1);

                            m_report.Document.Print();

                        }
                        else
                        {
                            WritePRT("fTICK", m_CertPDF.pic);

                            WritePRT("fSIGN", GetFakeSign(corcd));
                            m_report.Document.Print();
                        }


                    }
                    else
                    {
                        m_prtPreView.Text = m_report.ReportName;
                        m_prtPreView.PrintPreviewControl.Document = m_report;
                        m_prtPreView.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                        m_prtPreView.ShowDialog();
                    }


                }
            }
        }

        private string GetFakeSign(string corcd)
        {
            string ret = "Digitally signed by SEOYON" + Environment.NewLine;
            if (corcd == "5300")
            {
                ret += "E-HWA SUMMIT AUTOMOTIVE Pune" + Environment.NewLine;
            }
            else
            {
                ret += "E-HWA SUMMIT AUTOMOTIVE AP" + Environment.NewLine;
            }
            ret += "PRIVATE LITMITED" + Environment.NewLine;
            ret += "Date:" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + Environment.NewLine;
            ret += "Location: Seoyon E-Hwa ";
            return ret;
        }

        private void SignWithThisCert(string pdfPath)
        {
            if (m_CertPDF.certFile != null)
            {
                try
                {
                    string pfxPwd = m_CertPDF.certPwd;

                    string desPath = pdfPath.Substring(0, pdfPath.Length - 4) + "_" + ".PDF";

                    X509Certificate2 cert = new X509Certificate2(m_CertPDF.certFile, pfxPwd);
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

                    signatureAppearance.SetVisibleSignature(new iTextSharp.text.Rectangle(520, 160, 450, 200), 1, null);
                    MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CADES);


                    File.Delete(pdfPath);
                    File.Move(desPath, pdfPath);
                }
                catch (Exception eLog)
                {

                }

            }

        }
        private string GetBytesToString(byte[] bytes)
        {
            //return Encoding.Default.GetString(bytes);
            string hexValues = BitConverter.ToString(bytes).Replace("-", "");

            return hexValues;
        }
        private void SetXML_Table(string corcd, string bizcd, string custcd, string cust_plant, string deli_Date, string invoice, string fileName, byte[] pdf)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("CUSTCD", custcd);
            set.Add("CUST_PLANT", cust_plant);
            set.Add("DELI_DATE", deli_Date);
            set.Add("INVOICENO", invoice);
            set.Add("FILE_NAME", fileName);
            set.Add("CLOB$PDF_FILE", GetBytesToString(pdf));
            m_DB.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSD02600", "SET_IF_DATA"), set);

        }
        private void WritePRT(string ctlNM, Bitmap img)
        {
            m_report.Fields[ctlNM].PictureScale = C1.C1Report.PictureScaleEnum.Stretch;
            m_report.Fields[ctlNM].Picture = img;
        }

        private void WritePRT(string ctlNM, string val, string format = "")
        {
            if (m_report.Fields.Contains(ctlNM))
            {
                m_report.Fields[ctlNM].Text = "";

                m_report.Fields[ctlNM].Text = val;

                if (string.IsNullOrEmpty(format) == false)
                {
                    switch (format)
                    {
                        case "Y-M-D":
                            if (val.Length == 8)
                            {
                                m_report.Fields[ctlNM].Text = val.Substring(0, 4) + "-" + val.Substring(4, 2) + "-" + val.Substring(6, 2);
                            }
                            break;
                        case "H:M:S":
                            if (val.Length == 6)
                            {
                                m_report.Fields[ctlNM].Text = val.Substring(0, 2) + ":" + val.Substring(2, 2);
                            }
                            break;
                    }
                }
            }
        }
    }
}
