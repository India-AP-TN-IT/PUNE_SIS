using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ax.DEV.Utility.Library;
using System.ServiceModel;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core;
using Ax.DEV.Utility.Controls;
using System.Data.OleDb;
using System.IO;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// <b> 협력 업체를 조회하는 클래스</b>
    /// - 작 성 일 : 2019-06-27<br/>
    /// - 주요 변경 사항<br/>
    ///     1) 2019-06-27 : 최초 클래스 생성.<br/>
    /// </summary>
    public partial class ZSD02620 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;


        public ZSD02620()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
        }
       
        #region [초기화 작업 정의]
        protected override void UI_Shown(EventArgs e)
        {
            base.UI_Shown(e);
            try
            {
                // 법인
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

               

                #region grd01
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "INVOICE", "INVOICE", "INVOICE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "C/PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "TRUCK", "CARNO", "CARNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 70, "L/QTY", "GRP_QTY", "GRP_QTY");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "T/AMT", "GRP_AMT", "GRP_AMT");

                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "IF DATE", "SEND_DT", "SEND_DT");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 80, "SEND_YN", "SEND_YN", "SEND_YN");

                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "DELI_DATE", "DELI_DATE", "DELI_DATE");

                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "FILE_NAME", "FILE_NAME", "FILE_NAME");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "PDF_FILE", "PDF_FILE", "PDF_FILE");
                
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 80, "PDF", "FILE_YN", "FILE_YN");

                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "IRN", "IRN", "IRN");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "E/CNT", "ERR_CNT", "ERR_CNT");
                #endregion

                #region grd02
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 75, "C/SHOP", "ZSHOP", "ZSHOP");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "PO NO.", "EBELN", "EBELN");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "HSN", "ZHSNSAC", "ZHSNSAC");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "PART NO.", "MATNR", "MATNR");

                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 70, "QTY", "IVQTY", "IVQTY");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "PRICE", "ZANETPR", "ZANETPR");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "AMT", "ZANETWR", "ZANETWR");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "CGST", "ZCGST", "ZCGST");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "SGST", "ZSGST", "ZSGST");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "IGST", "ZIGST", "ZIGST");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "G/TOT", "ZAIVAMT", "ZAIVAMT");

                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "IF DATE", "SEND_DT", "SEND_DT");
                this.grd02.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 80, "SEND_YN", "SEND_YN", "SEND_YN");

                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "IF MSG", "KIN_MSG", "KIN_MSG");
                this.grd02.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 80, "RSLT", "KIN_RSLT", "KIN_RSLT");



                #endregion
                SetCustPLANT();


            }
            catch (FaultException<ExceptionDetail> except)
            {
                MsgBox.Show(except.ToString());
            }
            finally
            {
            }
        }
        #endregion
        private byte[] GetBytesFromString(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2),16);
            }
            return bytes;
        }
       
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("TY", "A");
                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02620", "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #region [공통 버튼에 대한 이벤트 정의]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            
            try
            {
                grd02.InitializeDataSource();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("INVOICE", Txt_ORDNO.GetValue());
                paramSet.Add("DELI_DATE", Dat_ST_DATE.GetDateText());
                paramSet.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());

                DataSet ds = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02620.INQUERY_HEAD", paramSet, "OUT_CURSOR");

                grd01.SetValue(ds);
                for(int row = grd01.Rows.Fixed;row<grd01.Rows.Count;row++)
                {
                    if(grd01.GetValue(row, "SEND_YN").ToString() == "Y")
                    {
                        grd01.Rows[row].StyleNew.BackColor = Color.Lime;
                    }
                    if (grd01.GetValue(row, "ERR_CNT").ToString() != "0")
                    {
                        grd01.Rows[row].StyleNew.BackColor = Color.Red;
                        grd01.Rows[row].StyleNew.ForeColor = Color.White;
                    }
                }
                
            }
            catch (FaultException<ExceptionDetail> except)
            {
                MsgBox.Show(except.ToString());
            }
            finally
            {
            }
        }
        #endregion

        private string GetPDFString(string corcd, string bizcd, string invoice)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", corcd);
            paramSet.Add("BIZCD", bizcd);
            paramSet.Add("INVOICE", invoice);

            DataSet ds = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02620.GET_PDF_FILE", paramSet, "OUT_CURSOR");
            if(ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0]["PDF_FILE"].ToString();
            }
            return "";
        }
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(grd01.Row >= grd01.Rows.Fixed)
            {
                if (grd01.Cols[grd01.Col].Name == "FILE_YN")
                {
                    if (MsgBox.Show("Do you want to download PDF file?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string corcd =grd01.GetValue(grd01.Row, "CORCD").ToString();
                        string bizcd =grd01.GetValue(grd01.Row, "BIZCD").ToString();
                        string invoice =grd01.GetValue(grd01.Row, "INVOICE").ToString();
                        string pdf = GetPDFString(corcd, bizcd, invoice);
                        string fileName = grd01.GetValue(grd01.Row, "FILE_NAME").ToString();
                        byte[] byPDF = GetBytesFromString(pdf);
                        SavePDF(byPDF, fileName);
                    }
                }
                else
                {
                   HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", grd01.GetValue(grd01.Row, "CORCD"));
                    paramSet.Add("BIZCD", grd01.GetValue(grd01.Row, "BIZCD"));
                    paramSet.Add("INVOICE", grd01.GetValue(grd01.Row, "INVOICE"));
                   

                    DataSet ds = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02620.INQUERY_DET", paramSet, "OUT_CURSOR");

                    grd02.SetValue(ds);
                    for (int row = grd02.Rows.Fixed; row < grd02.Rows.Count; row++)
                    {
                        if (grd02.GetValue(row, "KIN_RSLT").ToString() == "S")
                        {
                            grd02.Rows[row].StyleNew.BackColor = Color.Lime;
                            grd02.Rows[row].StyleNew.ForeColor = Color.Black;
                        }
                        else if (grd02.GetValue(row, "KIN_RSLT").ToString() == "E")
                        {
                            grd02.Rows[row].StyleNew.BackColor = Color.Red;
                            grd02.Rows[row].StyleNew.ForeColor = Color.White;
                        }
                    }
                }
                
            }
        }
        

        private void SavePDF(byte[] pdf, string fileName)
        {
            

            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.FileName = fileName;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(file.FileName, pdf);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                
            }
        }
        

    }
}

