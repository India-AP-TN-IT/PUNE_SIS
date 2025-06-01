#region ▶ Description & History
/* 
 * 프로그램명 : PD40150 완제품 창고 현재고 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 완제품 창고 현재고 조회
    /// </summary>
    public partial class PD40150 : AxCommonBaseControl
    {
        //private IPD40150 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40150";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40150()
        {
            InitializeComponent();


            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40150>("PD", "PD40150.svc", "CustomBinding");
                //}
                //else
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40150>("PD", "PD40150_N.svc", "CustomBinding");
                //}
                _WSCOM_N = new AxClientProxy();

                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();

                this.grd04.AllowEditing = false;
                this.grd04.Initialize();
                this.grd05.AllowEditing = false;
                this.grd05.Initialize();
                this.grd06.AllowEditing = false;
                this.grd06.Initialize();

                this.grd10.AllowEditing = false;
                this.grd11.AllowEditing = false;
                this.grd10.Initialize();
                this.grd11.Initialize();


                this.grd01.AllowMerging = AllowMergingEnum.FixedOnly;
                this.grd01.EnabledActionFlag = false;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "ALC", "ALCCD", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "완제품 P/No", "PARTNO", "PART_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "장착위치", "INSTALL_POS", "POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "재고량", "STOCK_COUNT", "QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCK_COUNT");

                this.grd02.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd02.AllowSorting = AllowSortingEnum.MultiColumn;
                this.grd02.AllowMerging = AllowMergingEnum.Free;
                this.grd02.AutoGenerateColumns = false;
                this.grd02.Rows.MinSize = 22;
                this.grd02.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd02.EnabledActionFlag = false;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "적재일수", "STOCKED_DAYS", "STOCKED_DAYS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적재위치", "AREA_CODE", "AREA_CODE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCKED_DAYS");

                this.grd03.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd03.AllowSorting = AllowSortingEnum.None;
                this.grd03.AllowMerging = AllowMergingEnum.Free;
                this.grd03.AutoGenerateColumns = false;
                this.grd03.Rows.MinSize = 22;
                this.grd03.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd03.EnabledActionFlag = false;
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "ALC 코드", "ALCCD", "ALC");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "재고량", "PRDCNT", "STOCK_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "PRDCNT");


                this.grd04.AllowMerging = AllowMergingEnum.FixedOnly;
                this.grd04.EnabledActionFlag = false;
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "ALC 코드", "ALCCD", "ALC");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "장착위치", "INSTALL_POS", "POS");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "재고량", "PRDCNT", "QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "PRDCNT");

                this.grd05.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd05.AllowSorting = AllowSortingEnum.MultiColumn;
                this.grd05.AllowMerging = AllowMergingEnum.Free;
                this.grd05.AutoGenerateColumns = false;
                this.grd05.Rows.MinSize = 22;
                this.grd05.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd05.EnabledActionFlag = false;
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "LOTNO", "LOTNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "적재일수", "STOCKED_DAYS", "STOCKED_DAYS");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적재위치", "AREA_CODE", "AREA_CODE");
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCKED_DAYS");

                this.grd06.AllowMerging = AllowMergingEnum.FixedOnly;
                this.grd06.EnabledActionFlag = false;
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "ALC", "ALCCD", "ALC");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "완제품 P/No", "PARTNO", "PART_NO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "재고량", "STOCK_COUNT", "STOCK_QTY");
                this.grd06.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCK_COUNT");

                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "PGN", "PGN", "PGN");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PGN", "PGNDESC", "PGNDESC");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "LINE", "LINECD", "LINECD");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "ALC", "ALCCD", "ALC");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "완제품 P/No", "PARTNO", "PART_NO");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "장착위치", "INSTALL_POS", "POS");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "P/DIV", "PRDT_DIV", "PRDT_DIV");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "D/TYPE", "DELI_TYPE", "DELI_TYPE");                
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "재고량", "STOCK_QTY", "QTY");
                this.grd10.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCK_QTY");


                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "LOT", "LOTNO", "LOTNO");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "I/DATE", "IDATE", "IDATE");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "STATUS", "INV_STATUS", "INV_STATUS");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "TROLLEY", "LODTBL_NO", "LODTBL_NO");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "CONFIRM_QTY", "CONFIRM_QTY");
                this.grd11.SetColumnType(AxFlexGrid.FCellType.Decimal, "CONFIRM_QTY");
                

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.axComboBox1.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.axComboBox1.SetValue(this.UserInfo.BusinessCode);
                this.axComboBox1.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD"));   //라인코드
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");


                DataTable source1 = new DataTable();
                source1.Columns.Add("CODE");
                source1.Columns.Add("VALUE");
                source1.Rows.Add("JIS", "JIS");   //1 라인
                source1.Rows.Add("JIT", "JIT");   //2 라인
                cbo01_DTYPE.DataBind(source1, true);

                this.txt01_LH_COUNT.SetReadOnly(true);
                this.txt01_RH_COUNT.SetReadOnly(true);
                this.txt01_TT_COUNT.SetReadOnly(true);
                this.txt01_FA_COUNT.SetReadOnly(true);
                this.txt01_RA_COUNT.SetReadOnly(true);

                this.SetRequired(lbl01_BIZNM2, lbl02_LINE, lbl06_BIZNM2, lbl07_LINE);
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
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (!this.IsQueryValid()) return;//유효성 검사.

                    this.grd02.InitializeDataSource();
                    this.grd03.InitializeDataSource();

                    string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                    HEParameterSet set = new HEParameterSet();
                    set.Add("BIZCD", bizcd);
                    set.Add("LINECD", this.cbl01_LINECD.GetValue());

                    if (grp_LOC_SLCT.Visible == true)
                    {
                        set.Add("INSTALL_POS", this.rdo03_FRONT.Checked ? "F" : "R");   //HI조립라인 인 경우 FRONT/REAR 구분할수 있도록 변경 2016-05-16 -남광우-
                    }
                    else
                    {
                        set.Add("INSTALL_POS", "");
                    }

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                    this.grd01.SetValue(source);
                    this.AfterInvokeServer();
                    if (this.grd01.Rows.Count > 1)
                    {
                        this.grd01.Row = 1;
                        this.grd01_Click(this.grd01, e);
                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    if (!this.IsQueryValid()) return;//유효성 검사.

                    grd04.InitializeDataSource();
                    grd05.InitializeDataSource();

                    string bizcd = this.cbo02_BIZCD.GetValue().ToString();

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("LINECD", this.cbl02_LINECD.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY_RACK(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK"), set, "OUT_CURSOR");

                    this.grd04.SetValue(source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    grd10.InitializeDataSource();
                    grd11.InitializeDataSource();

                    string bizcd = this.axComboBox1.GetValue().ToString();

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("LINECD", this.cdx01_LINECD.GetValue());
                    set.Add("PGN", textBox2.Text);
                    set.Add("PARTNO", textBox3.Text);
                    set.Add("ALCCD", textBox1.Text);
                    set.Add("DELI_TYPE", cbo01_DTYPE.GetValue());
                    set.Add("LOTNO", textBox4.Text);
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY_RACK(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_STOCK"), set, "OUT_CURSOR");

                    this.grd10.SetValue(source);
                    this.AfterInvokeServer();
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

        #endregion

        #region [ 유효성 체크 ]
        private bool IsQueryValid()
        {
            try
            {
                //if (this.tabControl1.SelectedIndex == 0)
                //{
                //    if (cdx01_LINECD.ByteCount == 0)
                //    {
                //        //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                //        MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text); // this.GetLabel("LINECD"));
                //        return false;
                //    }
                //    //저장위치 필수 조건에서 제외함.2017-11-03
                //    //if (this.cdx01_STR_LOC.IsEmpty)
                //    //{
                //    //    //{0} 가(이) 입력되지 않았습니다.
                //    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_STR_LOC.Text);
                //    //    return false;
                //    //}
                //}
                //else if (this.tabControl1.SelectedIndex == 1)
                //{
                //    //if (cdx02_LINECD.ByteCount == 0)
                //    //{
                //    //    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                //    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LINECD.Text);  //this.GetLabel("LINECD"));
                //    //    return false;
                //    //}
                //}
                if (this.tabControl1.SelectedIndex == 0 && this.cbl01_LINECD.ByteCount == 0)
                {
                    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LINE.Text); // this.GetLabel("LINECD"));
                    return false;
                }

                if (this.tabControl1.SelectedIndex == 1 && this.cbl02_LINECD.ByteCount == 0)
                {
                    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl07_LINE.Text); // this.GetLabel("LINECD"));
                    return false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbo01_BIZCD.GetValue().ToString())
            {
                case "5210":
                    this.grd02.Cols["STOCKED_DAYS"].Visible = true;
                    this.grd02.Cols["AREA_CODE"].Visible = false;
                    break;
                case "5220":
                    this.grd02.Cols["STOCKED_DAYS"].Visible = false;
                    this.grd02.Cols["AREA_CODE"].Visible = true;
                    break;
            }
        }
        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbo02_BIZCD.GetValue().ToString())
            {
                case "5210":
                    this.grd05.Cols["STOCKED_DAYS"].Visible = true;
                    this.grd05.Cols["AREA_CODE"].Visible = false;
                    break;
                case "5220":
                    this.grd05.Cols["STOCKED_DAYS"].Visible = false;
                    this.grd05.Cols["AREA_CODE"].Visible = true;
                    break;
            }
        }

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            //set.Add("PRDT_DIV", "A0A");
            set.Add("PRDT_DIV", this.rdo01_ASSYPNO.Checked ? "A0A" : "A0S");  //완제품라인, 반제품 라인 선택할수 있도록 변경 2013-04-29
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl01_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            //this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
        }        
        private void cbl01_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            //----------------------------------------------------------
            //변경이력 : [2016.05.16][남광우] - HI차종인 경우 FRONT/REAR 공용 라인코드 이므로 구분이 필요
            //----------------------------------------------------------
            if (this.cbl01_LINECD.GetValue().ToString() == "HI0100" || this.cbl01_LINECD.GetValue().ToString() == "IK0100")
            {
                grp_LOC_SLCT.Visible = true;
            }
            else
            {
                grp_LOC_SLCT.Visible = false;
            }
        }
        
        private void cbl02_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo02_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo02_BIZCD.GetValue()); ;
            set.Add("PRDT_DIV", this.rdo03_ASSYPNO.Checked ? "A0A" : "A0S");  //완제품라인, 반제품 라인 선택할수 있도록 변경 2013-04-29
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl02_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            //this.cbl02_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
        }

        private void grd01_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_RACK_LIST(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK_LIST"), set, "OUT_CURSOR");

                this.grd03.SetValue(source);
                this.AfterInvokeServer();
                this.grd03.Tree.Column = 1;
                this.grd03.Subtotal(AggregateEnum.Sum, 0, -1, 4, this.GetLabel("ALL_TOT")); //전체 합계
                this.grd03.Subtotal(AggregateEnum.Sum, 1, 1, 4, "[{0}] " + this.GetLabel("TOTAL")); //합계

                if (this.grd01.Rows.Count > 1)
                {
                    this.grd01.Row = 1;
                    this.grd01_Click(this.grd01, e);
                }

                this.grd03.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd03.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd03.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd03.Styles["Subtotal1"].ForeColor = Color.Black;

                int lhcount = 0;
                int rhcount = 0;
                int facount = 0;
                int racount = 0;

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    //int count = int.Parse(this.grd01.GetValue(i, "STOCK_COUNT").ToString());
                    //switch (this.grd01.GetValue(i, "INSTALL_POS").ToString().Substring(2))
                    //{
                    //    case "LH": lhcount += count; break;
                    //    case "RH": rhcount += count; break;
                    //}
                    string s_stock_count = Convert.ToString(this.grd01.GetValue(i, "STOCK_COUNT"));
                    if (string.IsNullOrEmpty(s_stock_count)) s_stock_count = "0";
                    int count = int.Parse(s_stock_count);
                    string s_install_pos = Convert.ToString(this.grd01.GetValue(i, "INSTALL_POS"));
                    if (!string.IsNullOrEmpty(s_install_pos))
                    {
                        switch (s_install_pos.Substring(2))
                        {
                            case "LH": lhcount += count; break;
                            case "RH": rhcount += count; break;
                        }
                        ///=========Update on 17-07-2019===========
                        switch (s_install_pos){
                            case "F/All": facount += count; break;
                            case "R/All": racount += count; break;
                            case "LH": lhcount += count; break;
                            case "RH": rhcount += count; break; 
                        }
                    }
                }

                this.txt01_LH_COUNT.SetValue(lhcount);
                this.txt01_RH_COUNT.SetValue(rhcount);
                this.txt01_FA_COUNT.SetValue(facount);
                this.txt01_RA_COUNT.SetValue(racount);
                this.txt01_TT_COUNT.SetValue(lhcount + rhcount + facount + racount);
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
        private void grd04_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                string bizcd = this.cbo02_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl02_LINECD.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_RACK_LIST_DATA(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK_LIST_DATA"), set, "OUT_CURSOR");

                this.grd06.SetValue(source);
                this.AfterInvokeServer();
                this.grd06.Tree.Column = 1;
                this.grd06.Subtotal(AggregateEnum.Sum, 0, -1, 4, this.GetLabel("ALL_TOT")); //전체 합계
                this.grd06.Subtotal(AggregateEnum.Sum, 1, 1, 4, "[{0}] " + this.GetLabel("TOTAL")); //합계

                if (this.grd04.Rows.Count > 1)
                {
                    this.grd04.Row = 1;
                    this.grd04_Click(this.grd04, e);
                }

                this.grd06.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd06.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd06.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd06.Styles["Subtotal1"].ForeColor = Color.Black;

                int lhcount = 0;
                int rhcount = 0;
                int facount = 0;
                int racount = 0;

                for (int i = this.grd04.Rows.Fixed; i < this.grd04.Rows.Count; i++)
                {
                    //int count = int.Parse(this.grd04.GetValue(i, "PRDCNT").ToString());
                    //switch (this.grd04.GetValue(i, "INSTALL_POS").ToString().Substring(2))
                    //{
                    //    case "LH": lhcount += count; break;
                    //    case "RH": rhcount += count; break;
                    //}
                    string s_prod_count = Convert.ToString(this.grd04.GetValue(i, "PRDCNT"));
                    if (string.IsNullOrEmpty(s_prod_count)) s_prod_count = "0";
                    int count = int.Parse(s_prod_count);
                    string s_install_pos = Convert.ToString(this.grd04.GetValue(i, "INSTALL_POS"));
                    if (!string.IsNullOrEmpty(s_install_pos))
                    {
                        switch (s_install_pos.Substring(2))
                        {
                            case "LH": lhcount += count; break;
                            case "RH": rhcount += count; break;
                        }
                        ///=========Update on 17-07-2019===========
                        switch (s_install_pos)
                        {
                            case "F/All": facount += count; break;
                            case "R/All": racount += count; break;
                            case "LH": lhcount += count; break;
                            case "RH": rhcount += count; break;
                        }
                    }
                }

                this.txt02_LH_COUNT.SetValue(lhcount);
                this.txt02_RH_COUNT.SetValue(rhcount);
                this.txt02_FA_COUNT.SetValue(facount);
                this.txt02_RA_COUNT.SetValue(racount);
                this.txt02_TT_COUNT.SetValue(lhcount + rhcount + facount + racount);
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
        private void grd01_Click(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.MouseRow < 0 ? this.grd01.SelectedRowIndex : this.grd01.MouseRow;
                if (row < this.grd01.Rows.Fixed)
                    return;

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PARTNO", this.grd01.GetValue(row, "PARTNO"));
                set.Add("ALCCD", this.grd01.GetValue(row, "ALCCD"));

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_RACK_DETAIL(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK_DETAIL"), set, "OUT_CURSOR");

                this.grd02.SetValue(source);
                this.AfterInvokeServer();
                this.grd02.Tree.Column = 1;

                this.grd02.Subtotal(AggregateEnum.Count, 0, -1, 3, this.GetLabel("ALL_TOT"));   //전체 합계
                this.grd02.Subtotal(AggregateEnum.Count, 1, 1, 3, "[{0}] " + this.GetLabel("TOTAL")); //합계

                this.grd02.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd02.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd02.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd02.Styles["Subtotal1"].ForeColor = Color.Black;

                int intStockedDays = 0;

                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    if (this.grd02.Rows[i]["STOCKED_DAYS"] != null)
                    {
                        intStockedDays = Convert.ToInt32(this.grd02.Rows[i]["STOCKED_DAYS"].ToString());
                    }

                    if (intStockedDays > 10 && intStockedDays <= 20)
                    {
                        this.grd02.GetCellRange(i, this.grd02.Cols["STOCKED_DAYS"].Index, i, this.grd02.Cols["STOCKED_DAYS"].Index).StyleNew.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
                        this.grd02.GetCellRange(i, this.grd02.Cols["STOCKED_DAYS"].Index, i, this.grd02.Cols["STOCKED_DAYS"].Index).StyleNew.ForeColor = Color.Blue;
                    }

                    if (intStockedDays > 20)
                    {
                        this.grd02.GetCellRange(i, this.grd02.Cols["STOCKED_DAYS"].Index, i, this.grd02.Cols["STOCKED_DAYS"].Index).StyleNew.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
                        this.grd02.GetCellRange(i, this.grd02.Cols["STOCKED_DAYS"].Index, i, this.grd02.Cols["STOCKED_DAYS"].Index).StyleNew.ForeColor = Color.OrangeRed;
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
        private void grd04_Click(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd04.SelectedRowIndex;
                if (row < 0)
                    return;

                string bizcd = this.cbo02_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LODTBL_NO", this.grd04.GetValue(row, "LODTBL_NO"));
                set.Add("ALCCD", this.grd04.GetValue(row, "ALCCD"));

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_RACK_DETAIL_DATA(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK_DETAIL_DATA"), set, "OUT_CURSOR");

                this.grd05.SetValue(source);
                this.AfterInvokeServer();
                this.grd05.Tree.Column = 1;

                this.grd05.Subtotal(AggregateEnum.Count, 0, -1, 3, this.GetLabel("ALL_TOT"));   //전체 합계
                this.grd05.Subtotal(AggregateEnum.Count, 1, 1, 3, "[{0}] " + this.GetLabel("TOTAL")); //합계

                this.grd05.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd05.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd05.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd05.Styles["Subtotal1"].ForeColor = Color.Black;
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
                
        private void PD40150_Resize_1(object sender, EventArgs e)
        {
            panel9.Height = grp01_PD40150_1.Height / 2;
            panel8.Height = grp01_PD40150_1.Height / 2;

            panel11.Height = grp04_PD40150_3.Height / 2;
            panel12.Height = grp04_PD40150_3.Height / 2;
        }
        
        #endregion

        private void grd10_DoubleClick(object sender, EventArgs e)
        {
            grd11.InitializeDataSource();


            string bizcd = this.axComboBox1.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("PARTNO", grd10.GetValue(grd10.SelectedRowIndex, "PARTNO"));
            this.BeforeInvokeServer(true);
            //DataSet source = _WSCOM.INQUERY_RACK(bizcd, set);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_STOCK_DET"), set, "OUT_CURSOR");

            this.grd11.SetValue(source);
            this.AfterInvokeServer();
        }


    }
}
