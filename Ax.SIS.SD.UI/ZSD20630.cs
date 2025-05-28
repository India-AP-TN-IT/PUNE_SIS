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
using System.Collections.Generic;
using System.IO;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class ZSD20630 : AxCommonBaseControl
    {
        #region [Initialize]
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
       
        public ZSD20630()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
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
            }
        }


        

    }
}

