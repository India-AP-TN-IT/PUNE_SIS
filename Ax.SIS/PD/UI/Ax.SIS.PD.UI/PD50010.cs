using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using iTextSharp.text.pdf.parser;
using System.Text;
using iTextSharp.text.pdf;
using C1.Win.C1FlexGrid;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>자재창고 출고정보 집계 및 상세조회</b>
    /// - 작 성 자 : 
    /// - 작 성 일 :
    /// </summary>
    public partial class PD50010 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public PD50010()
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
                this.heDockingTab1.PanelWidth = 272;

                #region [그리드1]
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "Delivery Note", "DELIVERY_NOTE", "DELIVERY_NOTE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Seq", "SEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Invoice No", "INVOICE_NO", "INVOICE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Box Qty", "BOX_QTY", "BOX_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Ship Qty", "SHIP_QTY", "SHIP_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Gate", "GATE", "GATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Car No.", "CAR_NO", "CAR_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "ETA Date", "ETA_DATE", "ETA_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "ETA Time", "ETA_TIME", "ETA_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "Remark", "REMARK", "REMARK");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Insert Date", "INSERT_DATE", "INSERT_DATE");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "Insert ID", "INSERT_ID", "INSERT_ID");

                this.grd01.Cols["BOX_QTY"].Format = _IntFormat;
                this.grd01.Cols["SHIP_QTY"].Format = _IntFormat;
                #endregion

                #region [그리드2]
                this.grd02.AllowEditing = false;
                this.grd02.Initialize(2, 2);
                         
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "ETA Date", "ETA_DATE", "ETA_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "Time", "ETA_TIME", "ETA_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "Delivery Note", "DELIVERY_NOTE", "DELIVERY_NOTE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "Seq", "SEQ", "SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "Part Name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "Box Qty", "BOX_QTY", "BOX_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "Ship Qty", "SHIP_QTY", "SHIP_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "Gate", "GATE", "GATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Car No.", "CAR_NO", "CAR_NO");
                         
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Invoice No", "INVOICE_NO", "INVOICE_NO");
                         
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Invoice Date", "SAP_INVOICE_DATE", "SAP_INVOICE_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part No", "SAP_PARTNO", "SAP_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "Ship Qty", "SAP_SHIP_QTY", "SAP_SHIP_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Sales Order", "SAP_SALES_ORDER", "SAP_SALES_ORDER");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "Seq", "SAP_SEQ", "SAP_SEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "SAP_PNO", "SAP_PNO", "SAP_PNO");
                         
                this.grd02.Cols["BOX_QTY"].Format = _IntFormat;
                this.grd02.Cols["SHIP_QTY"].Format = _IntFormat;
                this.grd02.Cols["SAP_SHIP_QTY"].Format = _IntFormat;

                for (int i = 0; i < grd02.Cols.Count; i++)
                    this.grd02[1, i] = this.grd02.Cols[i].Caption;

                this.grd02.AddMerge(0, 1, "INVOICE_NO", "INVOICE_NO");
                         
                this.grd02.AddMerge(0, 0, "ETA_DATE", "CAR_NO");
                //Changed KMI to KIN
                this.grd02.SetHeadTitle(0, "ETA_DATE", "KIN Delivery Note Information");
                         
                this.grd02.AddMerge(0, 0, "SAP_INVOICE_DATE", "SAP_SEQ");
                this.grd02.SetHeadTitle(0, "SAP_INVOICE_DATE", "SAP Invoice Information");

                CellStyle csMATCH = grd02.Styles.Add("MATCH");
                csMATCH.Font = new Font(this.Font, FontStyle.Regular);
                csMATCH.ForeColor = Color.Black;
                csMATCH.BackColor = Color.Lime;
                #endregion

                string strcorcd = this.UserInfo.CorporationCode;

                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cbo01_CORCD.SetReadOnly(true);

                //this.cbo01_JOB_TYPE.SetValue("A10");
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 1: this.Inquery_SAP_Compare(); break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.txt_FILE.Initialize();
                        this.txt01_DELIVERY_NOTE.Initialize();
                        this.txt01_INVOICENO.Initialize();
                        this.txt01_PARTNO.Initialize();
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    case 1:
                        this.grd02.InitializeDataSource();
                        this.txt01_DELIVERY_NOTE.Initialize();
                        this.txt01_INVOICENO.Initialize();
                        this.txt01_PARTNO.Initialize();
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        private void Inquery_SAP_Compare()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("DELIVERY_NOTE", this.txt01_DELIVERY_NOTE.GetValue());
                paramSet.Add("INVOICE_NO", this.txt01_INVOICENO.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD50010.INQUERY_SAP_COMPARE", paramSet);
                this.AfterInvokeServer();

                this.grd02.SetValue(source);
                this.ShowDataCount(source);

                string LPartNo = "";
                string RPartNo = "";
                string RPNo = "";
                int LQty = 0;
                int RQty = 0;

                for (int i = 2; i < grd02.Rows.Count; i++)
                {
                    LPartNo = Convert.ToString(grd02.Rows[i]["PARTNO"]).Replace("-", "").Replace(" ", "");
                    RPartNo = Convert.ToString(grd02.Rows[i]["SAP_PARTNO"]).Replace("-", "").Replace(" ", "");
                    RPNo = Convert.ToString(grd02.Rows[i]["SAP_PNO"]).Replace("-", "").Replace(" ", "");
                    int.TryParse(Convert.ToString(grd02.Rows[i]["SHIP_QTY"]), out LQty);
                    int.TryParse(Convert.ToString(grd02.Rows[i]["SAP_SHIP_QTY"]), out RQty);

                    if ((LPartNo == RPartNo || LPartNo == RPNo) && LQty == RQty)
                    {
                        //this.grd02.Rows[i].Style = this.grd02.Styles["MATCH"];
                        this.grd02.SetCellStyle(i, 11, this.grd02.Styles["MATCH"]);
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

        private void btn01_FILE_FIND_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF 파일 (*.pdf)|*.pdf";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txt_FILE.Text = ofd.FileName;
                this.grd01.Initialize();
                this.ReadDataPDF(this.txt_FILE.Text);
            }
            else
            {
                this.txt_FILE.ResetText();
            }
        }

        private void btn01_FILE_READ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txt_FILE.Text.Trim()))
            {
                MessageBox.Show("PDF 파일을 선택한 후 PDF 읽기 버튼을 누르세요");
                return;
            }

            this.grd01.Initialize();
            this.ReadDataPDF(this.txt_FILE.Text);
        }

        private void ReadDataPDF(string fileName)
        {
            //
            // iTextSharp AGPL 사용시 정확히 Text를 읽어냄
            //
            PdfReader reader = new PdfReader(fileName);

            DataSet dsRS = new DataSet();
            DataTable dtRS = new DataTable();
            dtRS.Columns.Add("DELIVERY_NOTE");
            dtRS.Columns.Add("SEQ");
            dtRS.Columns.Add("INVOICE_NO");
            dtRS.Columns.Add("PARTNO");
            dtRS.Columns.Add("PARTNM");
            dtRS.Columns.Add("BOX_QTY");
            dtRS.Columns.Add("SHIP_QTY");
            dtRS.Columns.Add("GATE");
            dtRS.Columns.Add("CAR_NO");
            dtRS.Columns.Add("ETA_DATE");
            dtRS.Columns.Add("ETA_TIME");
            dtRS.Columns.Add("REMARK");

            string DELIVERY_NOTE = string.Empty;
            string INVOICE_NO = string.Empty;
            string CAR_NO = string.Empty;
            string ETA_DATE = string.Empty;
            string ETA_TIME = string.Empty;
            try
            {
                for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string extractedText = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                    byte[] utf8Bytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(extractedText));
                    string pageText = Encoding.UTF8.GetString(utf8Bytes);

                    //Line Split
                    string[] sData = pageText.Split(new string[] { "\n" }, StringSplitOptions.None);

                    #region Get Data From PDF String
                    for (int i = 0; i < sData.Length; i++)
                    {
                        string sRow = sData[i].ToUpper();

                        #region Get Row Datas
                        if (sRow.Contains("RPCS"))
                        {
                            for (int j = 0; j < i; j++)
                            {
                                DataRow rowRS = dtRS.NewRow();

                                //Space Split in Line
                                string[] sVal = sData[j].Split(new string[] { " " }, StringSplitOptions.None);

                                rowRS["SEQ"] = sVal[0];
                                rowRS["PARTNO"] = sVal[1].Replace("-", "");

                                int chknum = 0;
                                bool isnum = false;
                                //for (int k = 2; k < sVal.Length; k++ )
                                //{
                                //    isnum = int.TryParse(sVal[k], out chknum);

                                //    if(isnum)
                                //    {
                                //        for (int l = 2; l < k;l++ )
                                //        {
                                //            if (l > 2) rowRS["PARTNM"] += " ";
                                //            rowRS["PARTNM"] += sVal[l];
                                //        }
                                //        break;
                                //    }
                                //}

                                isnum = int.TryParse(sVal[sVal.Length - 2], out chknum);
                                if (isnum)
                                {
                                    rowRS["BOX_QTY"] = sVal[sVal.Length - 3];
                                    rowRS["SHIP_QTY"] = sVal[sVal.Length - 2];
                                    rowRS["GATE"] = sVal[sVal.Length - 1];
                                }
                                else //Remark 있는 경우
                                {
                                    rowRS["BOX_QTY"] = sVal[sVal.Length - 4];
                                    rowRS["SHIP_QTY"] = sVal[sVal.Length - 3];
                                    rowRS["GATE"] = sVal[sVal.Length - 2];
                                    rowRS["REMARK"] = sVal[sVal.Length - 1];
                                }
                                dtRS.Rows.Add(rowRS);
                            }
                        }
                        #endregion

                        #region Get DELIVERY_NOTE
                        if (sRow.Contains(" "))
                        {
                            DELIVERY_NOTE = sData[i + 1].Replace(" ", "");
                        }
                        #endregion

                        #region Get Invoice No
                        if (sRow.Contains("INVOICE NO"))
                        {
                            INVOICE_NO = sData[i + 1].Replace(" ", "");
                        }
                        #endregion

                        #region Get CAR_NO
                        if (sRow.Contains("CAR NO"))
                        {
                            CAR_NO = sData[i + 1].Replace(" ", "");
                        }
                        #endregion

                        #region Get ETA_DATE, TIME
                        if (sRow.Contains("ETA DATE/TIME"))
                        {
                            DateTime pDate;
                            DateTime.TryParseExact(sData[i + 1], "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out pDate);

                            ETA_DATE = pDate.ToString("yyyy-MM-dd");
                            ETA_TIME = pDate.ToString("HH:mm");
                        }
                        #endregion
                    }
                    #endregion
                    
                    if (dtRS.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data in PDF");
                        return;
                    }

                    foreach(DataRow r in dtRS.Rows)
                    {
                        r["DELIVERY_NOTE"]=DELIVERY_NOTE;
                        r["INVOICE_NO"]=INVOICE_NO;
                        r["CAR_NO"]=CAR_NO;
                        r["ETA_DATE"]=ETA_DATE;
                        r["ETA_TIME"]=ETA_TIME;
                    }
                    dsRS.Tables.Add(dtRS);
                    this.grd01.SetValue(dsRS);
                    this.ShowDataCount(dsRS);
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

        private void btn01_FILE_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.All
                                                      , "DELIVERY_NOTE"
                                                      , "SEQ"
                                                      , "INVOICE_NO"
                                                      , "PARTNO"
                                                      , "PARTNM"
                                                      , "BOX_QTY"
                                                      , "SHIP_QTY"
                                                      , "GATE"
                                                      , "CAR_NO"
                                                      , "ETA_DATE"
                                                      , "ETA_TIME"
                                                      , "REMARK"
                                                      , "INSERT_ID"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["INSERT_ID"] = this.UserInfo.UserID;
                    }

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_PD50010.PDF_DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();

                    BtnReset_Click(null, null);

                    //저장되었습니다.
                    MsgCodeBox.Show("CD00-0071");

                    //for (int i = 0; i < grd01.Rows.Count; i++)
                    //{
                    //    grd01.SetValue(i, "INSERT_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                    //    grd01.SetValue(i, "INSERT_ID", this.UserInfo.UserID);
                    //}
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
