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
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZSD02720 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02720";

        #region [ 초기화 작업 정의 ]

        public ZSD02720()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                SetCustPLANT();
                cbl01_CustPLANT.SetValue("GVIA");
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);


                this.grd05.AllowEditing = true;
                this.grd05.AllowAddNew = false;
                this.grd05.Initialize();

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "PO/DATE", "PO_DATE", "PO_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "O/NO", "ORDERNO", "ORDERNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "O/QTY", "OQTY", "OQTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "P/QTY", "PQTY", "PQTY");


                this.grd02.AllowEditing = true;
                this.grd02.AllowAddNew = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");                
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "O/NO", "ORDERNO", "ORDERNO");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "DUE/DATE", "DUE_DATE", "DUE_DATE");
                
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "PLAN/DATE", "PLAN_DATE", "PLAN_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "O/QTY", "POQTY", "POQTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "PRE/QTY", "PRE_QTY", "PRE_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0_QTY", "D0_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1_QTY", "D1_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2_QTY", "D2_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3_QTY", "D3_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4_QTY", "D4_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5_QTY", "D5_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "SUM", "TOT_PLAN", "TOT_PLAN");
                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "REMAIN", "REM_QTY", "REM_QTY");
                label2.Text = "";
                label3.Text = "";



            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = null;

                source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02710.INQUERY_PLANT", set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

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
                string bizcd = cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", axDateEdit1.GetDateText());
                set.Add("ED_DATE", axDateEdit2.GetDateText());                
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("ORDERNO", axTextBox1.GetValue());
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02720.GET_DATA", set, "OUT_CURSOR");
                grd05.SetValue(source);
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
        private void DispDet(string corcd, string bizcd, string cust_plant, string orderno)
        {
            if(string.IsNullOrEmpty(orderno))
            {
                MsgBox.Show("No Selection of Order NO.", "Error");
                return;
            }
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("PLAN_DATE", axDateEdit3.GetDateText());
            set.Add("CUST_PLANT", cust_plant);
            set.Add("ORDERNO", orderno);

            set.Add("PARTNO", txt01_PARTNO.GetValue());
            set.Add("VINCD", cdx01_VINCD.GetValue());

            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02720.GET_DET", set, "OUT_CURSOR");
            grd02.SetValue(source);
        }
        private void grd05_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd05.SelectedRowIndex;
            if(row >=1)
            {
                string cust_plant = grd05.GetValue(row, "CUST_PLANT").ToString();
                string orderno = grd05.GetValue(row, "ORDERNO").ToString();

                label2.Text = cust_plant;
                label3.Text = orderno;
                DispDet(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), cust_plant, orderno);
            }
        }

        private void grd02_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            int row = grd02.SelectedRowIndex;
            if (row >= 1)
            {
                int d0 = Convert.ToInt32(grd02.GetValue(row,"D0_QTY").ToString());
                int d1 = Convert.ToInt32(grd02.GetValue(row,"D1_QTY").ToString());
                int d2 = Convert.ToInt32(grd02.GetValue(row,"D2_QTY").ToString());
                int d3 = Convert.ToInt32(grd02.GetValue(row,"D3_QTY").ToString());
                int d4 = Convert.ToInt32(grd02.GetValue(row,"D4_QTY").ToString());
                int d5 = Convert.ToInt32(grd02.GetValue(row,"D5_QTY").ToString());
                int pre = Convert.ToInt32(grd02.GetValue(row, "PRE_QTY").ToString());
                int po_qty = Convert.ToInt32(grd02.GetValue(row, "POQTY").ToString());
                int dSUM = d0+d1+d2+d3+d4+d5;
                grd02.SetValue(row, "TOT_PLAN", dSUM);
                grd02.SetValue(row, "REM_QTY", po_qty-(pre + dSUM));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.All,
                                            "CORCD"
                                            , "BIZCD"
                                            , "CUST_PLANT"
                                            , "ORDERNO"
                                            , "PARTNO"
                                            , "PLAN_DATE"
                                            , "D0_QTY"
                                            , "D1_QTY"
                                            , "D2_QTY"
                                            , "D3_QTY"
                                            , "D4_QTY"
                                            , "D5_QTY"
                                            , "UPDATE_ID"
                                            );
            this.BeforeInvokeServer(true);

            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02720.SAVE_DATA", source);

            this.AfterInvokeServer();
            DispDet(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), label2.Text, label3.Text);
        }

        private void axDateEdit3_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label3.Text))
            {
                return;
            }
            DispDet(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), label2.Text, label3.Text);
        }


    }
}

