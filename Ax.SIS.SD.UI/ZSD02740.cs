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
    public partial class ZSD02740 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02740";

        #region [ 초기화 작업 정의 ]

        public ZSD02740()
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
                

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "O/NO", "ORDERNO", "ORDERNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "PO/DATE", "PO_DATE", "PO_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "D/DATE", "DUE_DATE", "DUE_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "DEL/DATE", "DEL_DATE", "DEL_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "AMOUNT", "AMOUNT", "AMOUNT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "O/CARS", "ORD_CARS", "ORD_CARS");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "O/QTY", "ALL_QTY", "ALL_QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "D/QTY", "RSLT_QTY", "RSLT_QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "DIFF", "DIFF", "DIFF");

                this.grd05.Cols["AMOUNT"].Format = "###,###,###,##0";
                this.grd05.Cols["ORD_CARS"].Format = "###,###,###,##0";
                this.grd05.Cols["RSLT_QTY"].Format = "###,###,###,##0";
                this.grd05.Cols["ALL_QTY"].Format = "###,###,###,##0";
                this.grd05.Cols["DIFF"].Format = "###,###,###,##0";

                axDateEdit1.SetValue(DateTime.Now.AddMonths(-2));


                this.grd06.AllowEditing = true;
                this.grd06.AllowAddNew = false;
                this.grd06.Initialize();

                this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "CORCD", "CORCD", "CORCD");
                this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "BIZCD", "BIZCD", "BIZCD");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "O/NO", "ORDERNO", "ORDERNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "PARTNO", "PARTNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PARTNM", "PARTNM", "PARTNM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "VENDNM", "VENDNM", "VENDNM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "P/QTY", "POQTY", "POQTY");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "D/QTY", "RSLT_QTY", "RSLT_QTY");
                this.grd06.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "EDIT", "EDIT_QTY", "EDIT_QTY");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "DIFF", "DIFF", "DIFF");
                this.grd06.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "INVOICE", "EDIT_INVOICE", "EDIT_INVOICE");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "U/P", "UP", "UP");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "AMOUNT", "AMOUNT", "AMOUNT");
                this.grd06.Cols["EDIT_QTY"].Format = "###,###,###,##0";
                this.grd06.Cols["POQTY"].Format = "###,###,###,##0";
                this.grd06.Cols["RSLT_QTY"].Format = "###,###,###,##0";
                this.grd06.Cols["UP"].Format = "###,###,###,##0";
                this.grd06.Cols["AMOUNT"].Format = "###,###,###,##0";




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

                source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02740.INQUERY_PLANT", set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.
            }
        }
        private bool SaveData()
        {

            try
            {
                if (grd06.Rows.Count <= 1)
                {
                    MsgBox.Show("There is no data to save", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                    return false;
                }

                

                DataSet source = this.grd06.GetValue(AxFlexGrid.FActionType.Save,
     "CORCD", "BIZCD", "ORDERNO", "PARTNO", "EDIT_QTY", "EDIT_INVOICE");


                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_DATA_DET"), source);
                this.AfterInvokeServer();
                this.BtnQuery_Click(null, null);
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
                set.Add("VINCD", cdx01_VINCD.GetValue());
                set.Add("PARTNO", txt01_PARTNO.GetValue());
                set.Add("ORDERNO", axTextBox1.GetValue());
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02740.GET_DATA", set, "OUT_CURSOR");
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

        private void grd05_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string corcd = UserInfo.CorporationCode;
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            string ordNO = grd05.GetValue(grd05.Row, "ORDERNO").ToString();
            HEParameterSet param = null;
            param = new HEParameterSet();
            param.Add("CORCD", corcd);
            param.Add("BIZCD", bizcd);
            param.Add("ORDERNO", ordNO);
            DataSet ds = _WSCOM_N.ExecuteDataSetTx("ZPG_ZSD02740.GET_DATA_DET", param);
            grd06.SetValue(ds);
        }


    }
}

