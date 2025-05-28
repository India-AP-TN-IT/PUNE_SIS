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
    public partial class ZSD02300 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02300";

        #region [ 초기화 작업 정의 ]

        public ZSD02300()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                axTextBox1.SetValue("");
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                axDateEdit1.SetValue(DateTime.Now.AddMonths(-1));
                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("Customer Code");// "업체 코드";


                this.axCodeBox1.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.axCodeBox1);
                this.axCodeBox2.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1(this.axCodeBox2);
                this.axCodeBox2.PopupTitle = this.GetLabel("Customer Code");// "업체 코드";
                this.axCodeBox2.SetValue("303408");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "ST_DATE", "ST_DATE", "ST_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "CAR", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "C/CODE", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part NAME", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "S/QTY", "SALES_QTY", "SALES_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "S/AMT", "SALES_AMT", "SALES_AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "M/AMT", "MAT_AMT", "MAT_AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "SM/AMT", "SMAT_AMT", "SMAT_AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "G/AMT", "GOODS_AMT", "GOODS_AMT");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part NAME", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "S/LOC", "STR_LOC", "STR_LOC");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "T/DATE", "ST_DATE", "ST_DATE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "M/TYPE", "MTYPE", "MTYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "D/NO", "DNO", "DNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT", "UOM", "UOM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "QTY", "QTY", "QTY");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 150, "AMT", "AMT", "AMT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "REASON", "REASON", "REASON");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd02.Cols["ST_DATE"].Format = "yyyy-MM-dd";


                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "Customer", "CUSTCD", "CUSTCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "CAR", "VINCD", "VINCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "D/TYPE", "DTYPE", "DTYPE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "MIP", "MIP", "MIP");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "GRPCD", "GRPCD", "GRPCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "ITEM", "GRPNM", "GRPNM");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "QTY", "SQTY", "SQTY");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "U/PRICE", "UP", "UP");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 150, "Amount", "SAMT", "SAMT");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "Material", "MAMT", "MAMT");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "M/Rate", "MRATE", "MRATE");

                this.grd05.AllowEditing = false;
                this.grd05.Initialize();
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "YM", "YM", "YM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "TYPE", "TY", "TY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "Amount", "AMT", "AMT");
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");


                this.grd04.AllowEditing = false;
                this.grd04.Initialize();
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "VENDCD", "VENDCD", "VENDCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "YMD", "YMD", "YMD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "STR_LOC", "STR_LOC", "STR_LOC");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "PNO.", "PARTNO", "PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UOM", "UOM");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "CUR", "CUR", "CUR");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "CLASS", "VALUE_CLASS", "VALUE_CLASS");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "BEG/QTY", "BEG_QTY", "BEG_QTY");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "BEG/AMT", "BEG_AMT", "BEG_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 150, "REC/QTY", "REC_QTY", "REC_QTY");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "REC/AMT", "REC_AMT", "REC_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "ISS/QTY", "ISS_QTY", "ISS_QTY");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "ISS/AMT", "ISS_AMT", "ISS_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "END/QTY", "CLO_QTY", "CLO_QTY");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "END/AMT", "CLO_AMT", "CLO_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "SB/AMT", "STD_BEG_AMT", "STD_BEG_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "SR/AMT", "STD_REC_AMT", "STD_REC_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "SI/AMT", "STD_ISS_AMT", "STD_ISS_AMT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "SE/AMT", "STD_CLO_AMT", "STD_CLO_AMT");
                SetCustPLANT();


                this.grd08.AllowEditing = false;
                this.grd08.Initialize();
                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "MOVE", "MTYPE", "MTYPE");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "DESC", "NM", "NM");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "JAN", "AMT_01", "AMT_01");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "FEB", "AMT_02", "AMT_02");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "MAR", "AMT_03", "AMT_03");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "APR", "AMT_04", "AMT_04");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "MAY", "AMT_05", "AMT_05");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "JUN", "AMT_06", "AMT_06");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "JUL", "AMT_07", "AMT_07");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "AUG", "AMT_08", "AMT_08");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "SEP", "AMT_09", "AMT_09");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "OCT", "AMT_10", "AMT_10");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "NOV", "AMT_11", "AMT_11");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "DEC", "AMT_12", "AMT_12");


                this.grd09.AllowEditing = false;
                this.grd09.Initialize();

                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part NAME", "PARTNM", "PARTNM");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "AMT", "AMT", "AMT");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "%", "RATE", "RATE");


                this.grd10.AllowEditing = true;
                this.grd10.Initialize();
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "D/NOTE", "DNO", "DNO");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "LOC", "STR_LOC", "STR_LOC");
                this.grd10.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "REASON", "REASON", "REASON");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "QTY", "QTY");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 45, "UOM", "UOM", "UOM");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "AMT", "AMT", "AMT");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 90, "PARTNO", "PARTNO", "PARTNO");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 90, "MTYPE", "MTYPE", "MTYPE");

                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
        private string GetTY()
        {
            if(checkBox1.Checked == false)
            {
                return "1";
            }
            return "2";
        }
        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.DELETE_SD_CLOSE"), set);

                    DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "ST_DATE", "PARTNO", "CUSTCD", "SALES_QTY", "SALES_AMT", "MAT_AMT", "SMAT_AMT", "GOODS_AMT");
                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.SAVE_SD_CLOSE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("TY", GetTY());
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.DELETE_SCRAP"), set);

                    DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "PARTNO", "STR_LOC", "ST_DATE", "MTYPE", "DNO", "UOM", "QTY", "AMT", "REASON","TY");
                    this.BeforeInvokeServer(true);
                    for (int row = 0; row < source.Tables[0].Rows.Count;row++ )
                    {
                        source.Tables[0].Rows[row]["TY"] = GetTY();
                    }
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.SAVE_SCRAP"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("YMD", axDateEdit1.GetDateText());
                    set.Add("STR_LOC", STR_LOC());

                    if (axRadioButton1.Checked)
                    {
                        set.Add("TY", "MB5B");
                    }
                    else
                    {
                        set.Add("TY", "ZCOR10010");
                    }
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.DEL_STOCK_VALUE"), set);
                    DataSet source = this.grd04.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "YMD", "VENDCD", "STR_LOC", "PARTNO", "UOM", "CUR", "VALUE_CLASS"
                                                                , "BEG_QTY", "BEG_AMT", "REC_QTY", "REC_AMT", "ISS_QTY", "ISS_AMT", "CLO_QTY", "CLO_AMT", "STD_BEG_AMT"
                                                                , "STD_REC_AMT", "STD_ISS_AMT", "STD_CLO_AMT");

                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.SET_COST_STOCK_VALUE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    
                    DataSet source = this.grd10.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "STR_LOC", "PARTNO", "DNO","MTYPE","REASON");

                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02300.SAVE_SCRAN_D2"), source);
                    this.AfterInvokeServer();
                }
                this.AfterInvokeServer();


                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_ITEM"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("GRPCD") + ";" + this.GetLabel("GRPNM"), "C;L");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                string bizcd = cbo01_BIZCD.GetValue().ToString();
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                    set.Add("VINCD", cdx01_VINCD.GetValue());
                    set.Add("PARTNO", axTextBox9.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SD_CLOSE"), set, "OUT_CURSOR");
                    grd01.SetValue(source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("MTYPE", axTextBox10.GetValue());
                    set.Add("REASON", axTextBox11.GetValue());
                    set.Add("PARTNO", axTextBox3.GetValue());
                    set.Add("TY", "");
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCRAP"), set, "OUT_CURSOR");
                    grd02.SetValue(source);

                    set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("MTYPE", axTextBox10.GetValue());
                    set.Add("REASON", axTextBox11.GetValue());
                    set.Add("PARTNO", axTextBox3.GetValue());
                    set.Add("TY", "");
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCRAP_SUM"), set, "OUT_CURSOR");
                    grd05.SetValue(source);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("CUSTCD", axCodeBox2.GetValue());
                    set.Add("VINCD", axCodeBox1.GetValue());
                    set.Add("PARTNO", axTextBox4.GetValue());
                    set.Add("ITEM", cbl01_CustPLANT.GetValue());
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SD_REPORT"), set, "OUT_CURSOR");
                    grd03.SetValue(source);

                    set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("CUSTCD", axCodeBox2.GetValue());
                    set.Add("VINCD", axCodeBox1.GetValue());
                    set.Add("PARTNO", axTextBox4.GetValue());
                    set.Add("ITEM", cbl01_CustPLANT.GetValue());
                    DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SD_REPORT_SUM"), set, "OUT_CURSOR").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Txt_TCar_QY.Text = dt.Rows[0]["CAR02"].ToString();
                        Txt_TCar_SP.Text = dt.Rows[0]["CAR01"].ToString();
                        Txt_TCar_KY.Text = dt.Rows[0]["CAR03"].ToString();
                        Txt_TMAT.Text = dt.Rows[0]["MAMT"].ToString();
                        Txt_TMR.Text = dt.Rows[0]["MRATE"].ToString();
                        Txt_TRV.Text = dt.Rows[0]["SAMT"].ToString();
                        Txt_TUP.Text = dt.Rows[0]["UP"].ToString();
                    }
                    else
                    {
                        Txt_TCar_QY.Text = "";
                        Txt_TCar_SP.Text = "";
                        Txt_TCar_KY.Text = "";
                        Txt_TMAT.Text = "";
                        Txt_TMR.Text = "";
                        Txt_TRV.Text = "";
                        Txt_TUP.Text = "";
                    }
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("TY", GetType());
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SD_SCRAPDAM"), set, "OUT_CURSOR");
                    grd08.SetValue(source);

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
        private string GetType()
        {
            if (radioButton1.Checked)
            {
                return "A";
            }
            else if (radioButton2.Checked)
            {
                return "FG";
            }
            else if (radioButton3.Checked)
            {
                return "SFG";
            }
            else if (radioButton4.Checked)
            {
                return "MAT";
            }
            else if (radioButton5.Checked)
            {
                return "TG";
            }
            return "A";
        }

        private void ReadExcelFile(string FileName)
        {
            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", FileName);
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();


                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                DataSet dsSheet = this.GetDataSourceSchema("Code", "CodeValue");

                foreach (DataRow row in worksheets.Rows)
                {
                    dsSheet.Tables[0].Rows.Add(Convert.ToString(row["TABLE_NAME"]), Convert.ToString(row["TABLE_NAME"]));
                }
                if (tabControl1.SelectedIndex == 0)
                {
                    axTextBox1.Value = FileName;
                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    axTextBox2.Value = FileName;
                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    axTextBox5.Value = FileName;
                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                oleDB.Close();

                this.AfterInvokeServer();
            }
        }

        private void ReadExcelSheet(string SheetName, string file)
        {
            if (string.IsNullOrEmpty(SheetName)) return;

            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", file);
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();
                string commandString = "SELECT ";
                if (tabControl1.SelectedIndex == 0)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,'" + this.axDateEdit1.GetDateText() + "' as ST_DATE";
                    commandString += " ,[Customer] as CUSTCD";
                    commandString += " ,[Product Code] as PARTNO";
                    commandString += " ,[Total Sales Qty#] as SALES_QTY";
                    commandString += " ,[Total Sales value] as SALES_AMT";
                    commandString += " ,[Raw material cost] as MAT_AMT";
                    commandString += " ,[Sub Materials expense] as SMAT_AMT";
                    commandString += " ,[Cost of Sales -Purchase Item] as GOODS_AMT";
                    //commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,[Plant] AS BIZCD";
                    commandString += " ,[Material] as PARTNO";
                    commandString += " ,[Storage location] as STR_LOC";
                    commandString += " ,[Movement type] as MTYPE";
                    commandString += " ,[Material Document] as DNO";
                    commandString += " ,[Posting Date] as ST_DATE";
                    commandString += " ,[Qty in unit of entry] as QTY";
                    commandString += " ,[Unit of Entry] as UOM";
                    commandString += " ,[Document Header Text] as REASON";
                    commandString += " ,[Amt#in loc#cur#] as AMT";
                    
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD";
                    commandString += " ,[Plant] as BIZCD";
                    commandString += " ,'" + this.axDateEdit1.GetDateText().ToString() + "' as YMD";
                    commandString += " ,'ALL' as STR_LOC";
                    commandString += " ,[Vendor Code] as VENDCD";
                    commandString += " ,'INR' as CUR";

                    commandString += " ,[Material] as PARTNO";
                    commandString += " ,[Base Unit] as UOM";

                    commandString += " ,[Valuation Class] as VALUE_CLASS";
                    commandString += " ,[Opening Stock Qty#] as BEG_QTY";
                    commandString += " ,[Opening Stock Actual Price] as BEG_AMT";
                    commandString += " ,[Total Incoming Qty#] as REC_QTY";
                    commandString += " ,[Total Incoming Actual Price] as REC_AMT";
                    commandString += " ,[Total Outgoing Qty#] as ISS_QTY";
                    commandString += " ,[Total Outgoing Actual Price] as ISS_AMT";
                    commandString += " ,[Ending Stock Qty#] as CLO_QTY";
                    commandString += " ,[Ending Stock Actual Price] as CLO_AMT";


                }

                commandString += " FROM [" + SheetName + "]";
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();

                if (tabControl1.SelectedIndex == 0)
                {
                    this.grd01.SetValue(ds);
                    for (int i = 1; i < this.grd01.Rows.Count; i++)
                    {
                        this.grd01[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    this.grd02.SetValue(ds);
                    for (int i = 1; i < this.grd02.Rows.Count; i++)
                    {
                        this.grd02[i, 0] = AxFlexGrid.FLAG_N;
                        this.grd02[i, "DNO"] = this.grd02[i, "DNO"] + ":" + i.ToString();
                    }
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    this.grd04.SetValue(ds);
                    for (int i = 1; i < this.grd04.Rows.Count; i++)
                    {
                        this.grd04[i, 0] = AxFlexGrid.FLAG_N;
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
                oleDB.Close();

                this.AfterInvokeServer();
            }
        }
        private void axButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                string filename = this.ofdExcel.FileName;
                //string extension = ((string[])filename.Split('.'))[filename.Split('.').Length - 1].ToUpper();
                //string endfilename = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];

                if (!this.IsVaildFile(filename))
                {
                    //MessageBox.Show("파일에 접근할 수 없습니다. 파일이 열려있는지 확인하세요.");
                    MsgCodeBox.Show("CD00-0120");
                    return;
                }


                this.ReadExcelFile(filename);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd05_DoubleClick(object sender, EventArgs e)
        {
            int row = this.grd05.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            string ty = grd05.GetValue(row, "TY").ToString().Substring(0, 1);
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("SDATE", axDateEdit1.GetDateText());
            set.Add("MTYPE", axTextBox10.GetValue());
            set.Add("REASON", axTextBox11.GetValue());
            set.Add("PARTNO", axTextBox3.GetValue());
            set.Add("TY", ty);

            //DataSet source = _WSCOM.INQUERY(bizcd, set);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCRAP"), set, "OUT_CURSOR");
            grd02.SetValue(source);
        }
        private string STR_LOC()
        {
            return "ALL";
        }
        private void MB5B_Text_reading()
        {
            Dictionary<string, int> dicCols = new Dictionary<string, int>();
            OpenFileDialog result = new OpenFileDialog();
            result.Filter = "Text|*.txt";

            if (result.ShowDialog() == DialogResult.OK)
            {
                string filename = result.FileName;
                axTextBox5.SetValue(filename);
            }
            else
            {
                return;
            }
            System.IO.TextReader readFile = new System.IO.StreamReader(axTextBox5.GetValue().ToString());

            int row = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("CORCD", typeof(string));
            dt.Columns.Add("BIZCD", typeof(string));

            dt.Columns.Add("YMD", typeof(string));
            dt.Columns.Add("STR_LOC", typeof(string));
            dt.Columns.Add("PARTNO", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("CUR", typeof(string));
            dt.Columns.Add("BEG_QTY", typeof(string));
            dt.Columns.Add("BEG_AMT", typeof(string));
            dt.Columns.Add("REC_QTY", typeof(string));
            dt.Columns.Add("REC_AMT", typeof(string));

            dt.Columns.Add("ISS_QTY", typeof(string));
            dt.Columns.Add("ISS_AMT", typeof(string));
            dt.Columns.Add("CLO_QTY", typeof(string));
            dt.Columns.Add("CLO_AMT", typeof(string));




            while (true)
            {
                string line = readFile.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] cols = line.Split('|');

                if (cols.Length > 1)
                {
                    if (row == 0)
                    {

                        for (int col = 0; col < cols.Length; col++)
                        {

                            if (cols[col].Trim().ToUpper() == "ValA".ToUpper())
                            {
                                dicCols.Add("BIZCD", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Material".ToUpper())
                            {
                                dicCols.Add("PARTNO", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "From Date".ToUpper())
                            {
                                dicCols.Add("YMD", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "BUn".ToUpper())
                            {
                                dicCols.Add("UOM", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Crcy".ToUpper())
                            {
                                dicCols.Add("CUR", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Opening Stock".ToUpper())
                            {
                                dicCols.Add("BEG_QTY", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Opening Value".ToUpper())
                            {
                                dicCols.Add("BEG_AMT", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Total Receipt Qties".ToUpper())
                            {
                                dicCols.Add("REC_QTY", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Total Receipt Values".ToUpper())
                            {
                                dicCols.Add("REC_AMT", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Total Issue Quantities".ToUpper())
                            {
                                dicCols.Add("ISS_QTY", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Total Issue Values".ToUpper())
                            {
                                dicCols.Add("ISS_AMT", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Closing Stock".ToUpper())
                            {
                                dicCols.Add("CLO_QTY", col);
                            }
                            else if (cols[col].Trim().ToUpper() == "Closing Value".ToUpper())
                            {
                                dicCols.Add("CLO_AMT", col);
                            }


                        }

                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr["CORCD"] = UserInfo.CorporationCode;
                        dr["STR_LOC"] = STR_LOC();
                        foreach (KeyValuePair<string, int> keyVal in dicCols)
                        {
                            if (keyVal.Key.Contains("QTY") || keyVal.Key.Contains("AMT"))
                            {
                                if (cols[keyVal.Value].Trim().Contains("-"))
                                {
                                    dr[keyVal.Key] = "-" + cols[keyVal.Value].Trim().Replace("-", "").Replace(",", "");
                                }
                                else
                                {
                                    dr[keyVal.Key] = cols[keyVal.Value].Trim().Replace(",", "");
                                }
                            }
                            else
                            {
                                dr[keyVal.Key] = cols[keyVal.Value].Trim();
                            }

                        }
                        dt.Rows.Add(dr);
                    }
                    row++;
                }

            }


            if (dt.Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                HEParameterSet delParam = new HEParameterSet();
                delParam.Add("CORCD", this.UserInfo.CorporationCode);
                delParam.Add("BIZCD", dt.Rows[0]["BIZCD"]);
                delParam.Add("YMD", dt.Rows[0]["YMD"]);
                delParam.Add("STR_LOC", dt.Rows[0]["STR_LOC"]);

                _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02300.DEL_STOCK_VALUE", delParam);
                _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02300.SET_STOCK_VALUE", ds);


            }
        }
        private void axButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (axRadioButton1.Checked == true)
                {
                    MB5B_Text_reading();
                }
                else if (axRadioButton1.Checked == false)
                {
                    axButton3_Click(null, null);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private string m_ymd = "";
        private string m_ty = "";

        private void grd08_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = this.grd08.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            string yy = axDateEdit1.GetDateText().Substring(0, 4);
            string ty = grd08.GetValue(row, "MTYPE").ToString();
            string[] colname = grd08.Cols[grd08.Col].Name.Split('_');
            if (colname.Length > 1 && colname[0] == "AMT")
            {
                m_ymd = yy + "-" + colname[1];
                m_ty = ty;
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("SDATE", m_ymd);
                set.Add("MTYPE", m_ty);
                set.Add("TY", GetType());
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SD_SCRAPDAM_D1"), set, "OUT_CURSOR");
                grd09.SetValue(source);
            }



        }

        private void grd09_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = this.grd09.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            string partno = grd09.GetValue(row, "PARTNO").ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("SDATE", m_ymd);
            set.Add("MTYPE", m_ty);
            set.Add("PARTNO", partno);
            set.Add("TY", GetType());
            //DataSet source = _WSCOM.INQUERY(bizcd, set);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SD_SCRAPDAM_D2"), set, "OUT_CURSOR");
            grd10.SetValue(source);

        }

    }
}

