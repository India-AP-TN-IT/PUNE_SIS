#region ▶ Description & History
/* 
 * 프로그램명 : [PD20472] 자재 출고 집계 및 상세조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              
*/
#endregion
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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// <b>자재창고 출고정보 집계 및 상세조회</b>
    /// - 작 성 자 : 
    /// - 작 성 일 :
    /// </summary>
    public partial class WM20472 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM20472()
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
                this.grd01.Initialize(2, 2);

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Work Date", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Work Time", "WORK_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Std Date", "STD_DATE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "업체명", "VENDNM", "VENDNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");

                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "기준일자", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "품명", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "자재유형", "MAT_TYPE", "MAT_TYPE");  //MES8020

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "합계", "STOT", "STOT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "정상출고", "O1", "O1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "출하지시출고", "O2", "O2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "결품추가출고", "O3", "O3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "파견요청출고", "O4", "O4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "기타출고", "O5", "O5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "사급출고", "O7", "O7");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량출고", "OE", "OE");

                this.grd01.Cols["STOT"].Format = _IntFormat;
                this.grd01.Cols["O1"].Format = _IntFormat;
                this.grd01.Cols["O2"].Format = _IntFormat;
                this.grd01.Cols["O3"].Format = _IntFormat;
                this.grd01.Cols["O4"].Format = _IntFormat;
                this.grd01.Cols["O5"].Format = _IntFormat;
                this.grd01.Cols["O7"].Format = _IntFormat;
                this.grd01.Cols["OE"].Format = _IntFormat;

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01.AddMerge(0, 1, "BIZCD", "BIZCD");

                this.grd01.AddMerge(0, 1, "VENDCD", "VENDCD");
                this.grd01.AddMerge(0, 1, "VENDNM", "VENDNM");

                this.grd01.AddMerge(0, 1, "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd01.AddMerge(0, 1, "WORK_DATE", "WORK_DATE");
                this.grd01.AddMerge(0, 1, "WORK_TIME", "WORK_TIME");
                this.grd01.AddMerge(0, 1, "STD_DATE", "STD_DATE");

                this.grd01.AddMerge(0, 1, "VENDNM", "VENDNM");

                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd01.AddMerge(0, 1, "MAT_TYPE", "MAT_TYPE");

                this.grd01.AddMerge(0, 0, "STOT", "OE");
                this.grd01.SetHeadTitle(0, "STOT", this.GetLabel("OUT_DIV"));   //출고

                //this.grd01.Cols["STD_DATE"].Format = "yyyy-MM-dd";
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");

                #endregion

                #region [그리드2]

                this.grd02.AllowEditing = false;
                this.grd02.Initialize(2, 2);

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "작업시간", "WORK_TIME", "WORK_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "기준일자", "STD_DATE", "STD_DATE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "업체명", "VENDNM", "VENDNM");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "품명", "PARTNM", "PARTNM");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "LOTNO", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "일련번호", "SEQNO", "SEQNO");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "합계", "STOT", "STOT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "정상출고", "O1", "O1");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "출하지시출고", "O2", "O2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "결품추가출고", "O3", "O3");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "파견요청출고", "O4", "O4");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "기타출고", "O5", "O5");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "사급출고", "O7", "O7");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량출고", "OE", "OE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "자재유형", "MAT_TYPE", "MAT_TYPE");

                this.grd02.Cols["STOT"].Format = _IntFormat;
                this.grd02.Cols["O1"].Format = _IntFormat;
                this.grd02.Cols["O2"].Format = _IntFormat;
                this.grd02.Cols["O3"].Format = _IntFormat;
                this.grd02.Cols["O4"].Format = _IntFormat;
                this.grd02.Cols["O5"].Format = _IntFormat;
                this.grd02.Cols["O7"].Format = _IntFormat;
                this.grd02.Cols["OE"].Format = _IntFormat;

                for (int i = 0; i < grd02.Cols.Count; i++)
                    this.grd02[1, i] = this.grd02.Cols[i].Caption;

                this.grd02.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd02.AddMerge(0, 1, "BIZCD", "BIZCD");

                this.grd02.AddMerge(0, 1, "STD_DATE", "STD_DATE");
                this.grd02.AddMerge(0, 1, "VENDCD", "VENDCD");

                this.grd02.AddMerge(0, 1, "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd02.AddMerge(0, 1, "VENDNM", "VENDNM");
                this.grd02.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd02.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd02.AddMerge(0, 1, "LOTNO", "LOTNO");
                this.grd02.AddMerge(0, 1, "SEQNO", "SEQNO");
                this.grd02.AddMerge(0, 1, "MAT_TYPE", "MAT_TYPE");
                this.grd02.AddMerge(0, 1, "WORK_DATE", "WORK_DATE");
                this.grd02.AddMerge(0, 1, "WORK_TIME", "WORK_TIME");

                this.grd02.AddMerge(0, 0, "STOT", "OE");
                this.grd02.SetHeadTitle(0, "STOT", this.GetLabel("OUT_DIV"));

                this.grd02.Cols["STD_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");
                this.grd02.Cols["WORK_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");

                #endregion

                string strcorcd = this.UserInfo.CorporationCode;

                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);
                //this.cbo01_CUSTCD.DataBind(this.GetCustCD(this.UserInfo.CorporationCode).Tables[0]);
                //this.cbo01_JOB_TYPE.DataBind("A1");
                //this.cbo01_VIN.DataBind("A3");
                //this.cbo01_ITEM.DataBind("A4");

                this.cbo01_CORCD.SetReadOnly(true);

                //this.cbo01_JOB_TYPE.SetValue("A10");
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);
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
                    case 0: this.Inquery_Total1(); break;
                    case 1: this.Inquery_Detail1(); break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.txt01_PARTNO.Initialize();
                        //this.txt01_LOTNO.Initialize();
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    case 1:
                        this.grd02.InitializeDataSource();
                        this.txt01_PARTNO.Initialize();
                        this.txt01_LOTNO.Initialize();
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string STD_YYMM = string.Empty;
                //string SDATE = string.Empty;

                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        //this.lbl01_SHIPPING_DATE.SetValue("선적일자");
                        //this.lbl01_SHIPPING_DATE.SetValue(this.GetLabel("SHIPPING_DATE"));
                        //this.dtp01_SDATE.CustomFormat = "yyyy-MM-dd";
                        //this.lbl01_SHIPPING_DATE.Visible = true;
                        this.lbl01_LOTNO.Visible = false;
                        this.txt01_LOTNO.Visible = false;
                        //this.lbl01_PARTNO.Visible = true;
                        //this.txt01_PARTNO.Visible = true;  
                        break;
                    case 1:
                        this.lbl01_LOTNO.Visible = true;
                        this.txt01_LOTNO.Visible = true;
                        //this.lbl01_PARTNO.Visible = false;
                        //this.txt01_PARTNO.Visible = false;  
                        break;
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Inquery_Total1()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20472.INQUERY_TOTAL1", paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source);
                this.ShowDataCount(source);

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    //if (source.Tables[0].Rows[i]["LOTNO"].ToString().Equals("Sub Total"))
                    //    this.grd01.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LemonChiffon;

                    if (source.Tables[0].Rows[i]["PARTNO"].ToString().Equals("Total"))
                        this.grd01.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                }

                //for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                //{
                //    if (source.Tables[0].Rows[i]["PNO"].ToString().Equals("Sub Total"))
                //        this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LemonChiffon;

                //    if (source.Tables[0].Rows[i]["PNO"].ToString().IndexOf("Total") > 0)
                //        this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                //}
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

        private void Inquery_Detail1()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20472.INQUERY_DETAIL1", paramSet);
                this.AfterInvokeServer();

                this.grd02.SetValue(source);
                this.ShowDataCount(source);

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    if (source.Tables[0].Rows[i]["LOTNO"].ToString().Equals("Sub Total"))
                        this.grd02.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LemonChiffon;

                    if (source.Tables[0].Rows[i]["PARTNO"].ToString().Equals("Total"))
                        this.grd02.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
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
