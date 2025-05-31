#region ▶ Description & History

#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b></b>
    /// - 작 성 자 : 박의곤<br />
    /// - 작 성 일 : 2016-07-05<br />
    /// </summary>
    public partial class QA30118 : AxCommonBaseControl
    {
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM;
        //private byte[] _FILE;

        public QA30118()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
                this.heDockingTab1.PanelWidth = 272;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                //this.cdx01_VENDCD.HEPopupHelper = new CM20017P1(this.cdx01_VENDCD);
                //this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"업체코드";

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);


                #region [ grd01 ]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize(false);
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.Cols.Count = this.grd01.Cols.Fixed;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사일자", "INSPECT_DATE", "INSPECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "검사자", "INSPECTOR", "INSPECTOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "업체코드", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "PART NAME", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "납품일자", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "납품차수", "DELI_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "입고수량", "RCV_QTY", "RCV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "합격수량", "OK_QTY", "OK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "불량비율(%)", "DEFECT_RATE", "DEFECT_RATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "불량코드", "DEFCD", "DEFCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "불량명", "DEFNM", "DEFNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "비고", "REMARK", "REMARK");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Plant Div", "PLANT_DIV", "PLANT_DIV");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPECT_DATE");
                //this.grd01.Cols["INSPECT_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RCV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "OK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEFECT_RATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV");
                //this.grd01.Cols["RCV_QTY"].Format = "###,###,###,###,##0";
                //this.grd01.Cols["DEF_QTY"].Format = "###,###,###,###,##0";
                //this.grd01.Cols["OK_QTY"].Format = "###,###,###,###,##0";
                //this.grd01.Cols["DEFECT_RATE"].Format = "###,###,###,###,##0.00";
                #endregion


                DataTable ds1 = new DataTable();
                ds1.Columns.Add("ALL");
                ds1.Columns.Add("LOCAL");
                ds1.Columns.Add("SUBKD");
                ds1.Rows.Add("%", "ALL");
                ds1.Rows.Add("LP", "L/P");
                ds1.Rows.Add("KD", "SUB/KD");
                this.cbo01_MAT_DIV.DataBind(ds1);
                this.cbo01_MAT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                this.SetRequired(lbl01_BIZNM, lbl01_INSPECT_DATE);

                this.dte01_FROM_DATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_TO_DATE.SetValue(DateTime.Now);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
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
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string FROM_DATE = this.dte01_FROM_DATE.Value.ToString("yyyy-MM-dd");
                string TO_DATE = this.dte01_TO_DATE.Value.ToString("yyyy-MM-dd");
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string PARTNO = this.txt01_PARTNO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("BEG_DATE", FROM_DATE);
                paramSet.Add("END_DATE", TO_DATE);
                paramSet.Add("PARTNO1", PARTNO);                
                paramSet.Add("LANG_SET", UserInfo.Language);
                paramSet.Add("USER_ID", UserInfo.UserID);
                paramSet.Add("MAT_DIV", this.cbo01_MAT_DIV.GetValue());
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();                
                source = _WSCOM.ExecuteDataSet("APG_QA30118.INQUERY", paramSet);

                this.grd01.SetValue(source);                

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

        #region [사용자 정의 메서드]
        
        #endregion

        #region [그리드 이벤트]

        #endregion    
    }
}
