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
using HE.Framework.Core.Report;
using Ax.SIS.WM.UI.BarcodePRT;
using System.Collections.Generic;
using System.IO;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class WM20600 : AxCommonBaseControl
    {
        #region [Initialize]
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        private const string CN_dir = @"C:\SIS_COFING";
        private const string CN_conFile = @"WM20600.CFG";
        BarcodePrt m_Prt = new BarcodePrt();
        public WM20600()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }
        private bool ReadCfg()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            string filePath = CN_dir + "\\" + CN_conFile;
            if (File.Exists(filePath))
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    string configStr = reader.ReadToEnd();
                    string[] cfg = configStr.Split(':');
                    textBox1.Text = cfg[0].Trim();
                    textBox2.Text = cfg[1].Trim();
                }
                return true;
            }
            return false;
        }
        private bool WriteCfg(string ip, string port)
        {
            try
            {
                if (Directory.Exists(CN_dir) == false)
                {
                    Directory.CreateDirectory(CN_dir);
                }
                string filePath = CN_dir + "\\" + CN_conFile;
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(ip + ":" + port);
                }
                return true;
            }
            catch (Exception eLog)
            {

            }
            return false;
        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {


                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                //제품
                //this.cbo01_PRDT_DIV.DataBind("A0");
                //this.cbo01_PRDT_DIV.SelectedItem = 0;
                this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");
                this.cdx01_LINECD.SetCodePixedLength();





                #endregion

                //this.SetRequired(lbl01_VENDCD);
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "C/Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "B/Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "W/Center", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "SHIFT", "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 260, "Part name", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PLAN", "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "S/QTY", "STUFF_QTY", "STUFF_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "STUFF_QTY");

                this.grd01.Cols["PLAN_QTY"].Format = _IntFormat;
                this.grd01.Cols["STUFF_QTY"].Format = _IntFormat;

                #endregion

                ReadCfg();

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [Common Btn Event]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set_plan = new HEParameterSet();
                set_plan.Add("CORCD", this.UserInfo.CorporationCode);
                set_plan.Add("BIZCD", cbo01_BIZCD.GetValue());
                set_plan.Add("PLAN_DATE", dtp01_STD_DATE.GetDateText());
                set_plan.Add("LINECD", cdx01_LINECD.GetValue());
                set_plan.Add("PARTNO", txt01_PARTNO.Text);


                DataSet source_plan = _WSCOM.ExecuteDataSet("APG_WM20600.INQUERY", set_plan, "OUT_CURSOR");
                grd01.SetValue(source_plan);
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

        #region [Define Method]
        
        private void Query_Cust_Plan_ASSY()
        {
            
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.UserInfo.BusinessCode);
            set1.Add("LINECD", cdx01_LINECD.GetValue());
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
            

            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20514.INQUERY_ASSY", set1, "OUT_CURSOR");
            this.grd01.SetValue(source1);
            ShowDataCount(source1);

        }
        #endregion

        #region [Controls Event]
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_WHCD", set1, "OUT_CURSOR").Tables[0];

            //this.cbo01_WHCD.DataBind(source1, false);
        }

        #endregion


        private bool PrintLabel(Dictionary<string, string> param, out string errMsg)
        {
            errMsg = "";
            bool bRet = false;
            try
            {
                int xPos = 0;   //Start X Position
                int yPos = 0;   //Start Y Position

                 m_Prt.Header(xPos, yPos);
                //<<BODY Start
                //string premenna = "2M";
                // if (param.Count > 0)
                {
                  /*  m_Prt.Body("^XA");
                    m_Prt.Body("^MMT");
                    m_Prt.Body("^PW799");
                    m_Prt.Body("^LL1199");
                    m_Prt.Body("^LS0");
                    m_Prt.Body("FT717,378^A0B,34,33^FH^FD" + param["LOTNO"] + "^FS");
                    m_Prt.Body("FT,710,185^A0B,34,55^FH^FD" + param["SIDE"] + "^FS");
                    m_Prt.Body("^FT165,915^A0B,34,74^FH^FD" + param["STUFF_QTY"] + "^FS");
                    m_Prt.Body("^FT164,1119^A0B,34,33^FH^FDSTUFF_QTY:^FS");
                    m_Prt.Body("^FT337,1113^A0B,34,33^FH^FDPart Description:^FS");
                    m_Prt.Body("^FT331,794^A0B,34,33^FH^FD" + param["PARTNM"] + "^FS");
                    m_Prt.Body("FT247,915^A0B,39,64^FH^FD" + param["PLAN_QTY"] + "^FS");
                    m_Prt.Body("^FT247,1117^A0B,39,38^FH^FDPLAN_QTY:^FS");
                    m_Prt.Body("^FT94,1119^A0B,39,43^FH^FDPart No:^FS");
                    m_Prt.Body("^FT92,933^A0B,39,43^FH^FD" + param["PARTNO"] + "^FS");
                    //<<Stock Barcode
                    m_Prt.Body("^FT48,326^BQN,2,9");
                    m_Prt.Body("^FDMAT" + "TR>STOCK>" + param["LOTNO"] + "^FS");      //Stock -- Barcode
                    m_Prt.Body("^FT331,310^A0B,34,33^FH^FD" + "<STOCK>" + "^FS");
                    //>>

                    //<<Issue Barcode
                    m_Prt.Body("^FT509,1178^BQN,2,10");                             //Location
                    m_Prt.Body("^FDMAT" + "TR>ISSUE>" + param["LOTNO"] + "^FS");    //Issue -- Barcode
                    //>>
                    
                    
                    
                    // m_Prt.Body("^FDMA,STOCK: "+"TR>ISSUE>" +param["LOTNO"] + "^FS");
                    
                    m_Prt.Body("^FO18,20^GB756,0,15^FS");
                    m_Prt.Body("^FO16,1166^GB763,0,9^FS");
                    m_Prt.Body("^FO770,15^GB0,1160,8^FS");
                    m_Prt.Body("^FO19,13^GB0,1165,8^FS");
                    m_Prt.Body("^PQ1,0,1,Y^XZ"); */

                    m_Prt.Body("^XA");
                    m_Prt.Body("^MMT");
                    m_Prt.Body("^PW799");
                    m_Prt.Body("^LL1199");
                    m_Prt.Body("^LS0");
                    m_Prt.Body("^FT321,874^A0B,51,45^FH^FD" +param["PLAN_QTY"] + "^FS");
                    m_Prt.Body("^FT447,733^A0B,48,43^FH^FD" + param["PARTNM"] + "^FS");
                    m_Prt.Body("^FT442,1140^A0B,48,43^FH^FDPART DESCRIPTION :^FS");
                    m_Prt.Body("^FT230,858^A0B,51,45^FH^FD" + param["STUFF_QTY"] + "^FS");
                    m_Prt.Body("^FT601,797^A0B,48,43^FH^FD<ISSUE>^FS");
                    m_Prt.Body("^FT319,1126^A0B,48,43^FH^FDPLAN_QTY :^FS");
                    m_Prt.Body("^FT228,1124^A0B,48,43^FH^FDSTUFF_QTY :^FS");
                    m_Prt.Body("^FT130,1119^A0B,48,74^FH^FDPart no :^FS");
                    m_Prt.Body("^FT130,840^A0B,48,64^FH^FD" + param["PARTNO"] + "^FS");
                    m_Prt.Body("^FT349,317^A0B,47,38^FH^FD<STOCK>^FS");
                    m_Prt.Body("^FT70,344^BQN,2,8");
                    m_Prt.Body("^FDMA,STOCK :"+"TR>STOCK>" + param["LOTNO"] + "^FS");
                    m_Prt.Body("^FDMA" + param["LOTNO"] + "^FS");
                    m_Prt.Body("^FT491,1125^BQN,2,9");
                    m_Prt.Body("^FDMA,ISSUE : "+"TR>ISSUE>" + param["LOTNO"] + "^FS");
                    m_Prt.Body("^FDMA" + param["LOTNO"] + "^FS");
                    m_Prt.Body("^F039,1169^GB714,0,10^FS");
                    m_Prt.Body("^F034,57^GB724,0,8^FS");
                    m_Prt.Body("^F0756,65^GB0,1108,10^FS");
                    m_Prt.Body("^F037,61^GB0,1108,8^FS");
                    m_Prt.Body("^PQ1,,1,Y^XZ");
                }
                //>>BODY END
                m_Prt.Footer();
            }
            catch (Exception eLog)
            {
                errMsg = eLog.Message;
                MsgBox.Show(eLog.Message, "Error");
                bRet = false;
            }
            return bRet;
        }

        private void axButton1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MsgBox.Show("No IP setting for Printer", "Error");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MsgBox.Show("No Port setting for Printer", "Error");
                return;
            }
            if (m_Prt.IsConnected == false)
            {
                string errMsg = "";
                m_Prt.OpenDevice(textBox1.Text, Convert.ToInt16(textBox2.Text), out errMsg);
            }
            if(grd01.Rows.Count>1)
            {
                int idx = grd01.Row;
                if(idx>=1)
                {
                    
                    int max = Convert.ToInt32(axTextBox3.GetValue().ToString());
                    int dblSide = 1;
                    if(axCheckBox1.Checked)
                    {
                        dblSide = 2;
                    }
                    
                    for (int i = 0; i < max; i++)
                    {
                        HEParameterSet set = new HEParameterSet();
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", cbo01_BIZCD.GetValue());

                        DataTable lotDT = _WSCOM.ExecuteDataSet("APG_WM20600.GET_LOTNO", set, "OUT_CURSOR").Tables[0];
                        string lotno = "";
                        if(lotDT.Rows.Count>0)
                        {
                            lotno = lotDT.Rows[0]["LOTNO"].ToString();
                        }

                        
                        
                        string msg = "";
                        for(int s=0;s<dblSide;s++)
                        {
                            /*
                            Dictionary<string, string> param = new Dictionary<string, string>();
                            param.Add("PARTNO", grd01.GetValue(idx, "PARTNO").ToString());
                            param.Add("PARTNM", grd01.GetValue(idx, "PARTNM").ToString());
                            param.Add("LOTNO", lotno);
                            param.Add("SIDE", "["+ (s + 1).ToString() + " / " + dblSide +"]");
                            */
                            Dictionary<string, string> param = new Dictionary<string, string>();
                            param.Add("PARTNO", grd01.GetValue(idx, "PARTNO").ToString());
                            param.Add("PARTNM", grd01.GetValue(idx, "PARTNM").ToString());
                            param.Add("LOTNO", lotno);
                            //param.Add("LOTNO", grd01.GetValue(idx, "LOTNO").ToString());
                            param.Add("SIDE", "[" + (s + 1).ToString() + " / " + dblSide + "]");
                            param.Add("PLAN_QTY", axTextBox1.GetValue().ToString());
                            param.Add("STUFF_QTY", axTextBox2.GetValue().ToString());
                            
                            PrintLabel(param, out msg);
                        }
                        HEParameterSet set1 = new HEParameterSet();
                        set1.Add("CORCD", this.UserInfo.CorporationCode);
                        set1.Add("BIZCD", cbo01_BIZCD.GetValue());
                        set1.Add("LOTNO", lotno);
                        set1.Add("PLAN_DATE", dtp01_STD_DATE.GetDateText());
                        set1.Add("LINECD", grd01.GetValue(idx, "LINECD").ToString());

                        set1.Add("PARTNO", grd01.GetValue(idx, "PARTNO").ToString());
                        set1.Add("STUFF_QTY", axTextBox2.GetValue());
                        set1.Add("LOAD_QTY", axTextBox1.GetValue());

                        _WSCOM.ExecuteNonQueryTx("APG_WM20600.SAVE_LOT_MASTER", set1);
                    }
                    
                }
                else
                {
                    MsgBox.Show("There is no data selection", "Error");
                }
            }
            else
            {
                MsgBox.Show("There is no data", "Error");
            }
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;            
            
            ReadCfg();
            
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            WriteCfg(textBox1.Text, textBox2.Text);
            panel2.Visible = false;
        }

        private void grd01_SelChange(object sender, EventArgs e)
        {
            int row = grd01.Row;
            if(row>=1)
            {
                Txt_PartNO.SetValue(grd01.GetValue(row, "PARTNO"));
                Txt_PartNM.SetValue(grd01.GetValue(row, "PARTNM"));
                Txt_TQTY.SetValue(grd01.GetValue(row, "PLAN_QTY"));
                axTextBox2.SetValue(grd01.GetValue(row, "STUFF_QTY"));
                axTextBox1.SetValue(grd01.GetValue(row, "STUFF_QTY"));
                CalcBox(Txt_TQTY.GetValue().ToString(), axTextBox2.GetValue().ToString());
            }
        }
        private void CalcBox(string planQTY, string stuffQTY)
        {
            try
            {
                int plan = Convert.ToInt32(planQTY);
                int stff = Convert.ToInt32(stuffQTY);
                if(plan%stff == 0)
                {
                    axTextBox3.SetValue(plan / stff);
                }
                else
                {
                    axTextBox3.SetValue((plan / stff)+1);
                }
                
            }
            catch(Exception eLog)
            {
                axTextBox3.SetValue(0);
            }
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            CalcBox(Txt_TQTY.GetValue().ToString(), axTextBox2.GetValue().ToString());
        }

        

    }
}

