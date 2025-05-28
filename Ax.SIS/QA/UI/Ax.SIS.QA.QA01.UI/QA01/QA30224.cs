#region ▶ Description & History
/* 
 * 프로그램명 : QA30224 고객사 입고불량 조회
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014.07.04      배명희     최초 클래스 생성
 *              2015-07-28      배명희      통합WCF로 변경
 * 
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using Ax.SIS.QA.QA09.UI;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
  
    public partial class QA30224 : AxCommonBaseControl
    {
        //private IQA30224 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30224";

        #region [ 초기화 작업 정의 ]

        public QA30224()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30224>("QA01", "QA30224.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                //this._buttonsControl.BtnPrint.Visible = true;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;


                this.grd01_QA30224.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd01_QA30224.AllowEditing = false;
                this.grd01_QA30224.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30224.Initialize(false);
                this.grd01_QA30224.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA30224.Cols.Count = this.grd01_QA30224.Cols.Fixed;
                this.grd01_QA30224.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30224.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");

                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "등록일자", "RCV_DATE", "REG_DATE");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "반송번호", "RTNNO", "RETNO");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "고객사코드", "CUSTCD", "CUSTCD");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "고객사명", "CUSTNM", "CUSTNM");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "발생일자", "RTN_DATE", "OCCUR_DATE");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종", "VINCD","VIN");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "품목", "ITEMNM","ITEM");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO","PARTNO");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNAME","PARTNM");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "불량코드", "DEFCD", "DEFCD");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "불량유형", "DEFNM", "DEFNM");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 090, "불량수량", "RTN_QTY", "DEF_QTY");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "발생장소", "RTN_AREA", "RTN_AREA");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "조치내용", "CNTTCD", "MGRT_CNTT");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "LOT NO", "LOTNO", "LOTNO");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "시스템", "GENERATER", "SYSTEM");
                this.grd01_QA30224.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01_QA30224.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 200, "PLANT_DIV", "PLANT_DIV", "PLANT_DIV");
                
                this.grd01_QA30224.SetColumnType(AxFlexGrid.FCellType.Decimal, "RTN_QTY");
                this.grd01_QA30224.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01_QA30224.SetColumnType(AxFlexGrid.FCellType.Date, "RTN_DATE");
                this.cdx01_CUSTCD.HEPopupHelper = new QASubWindow();
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("CUSTCD");// "고객사코드";
                this.cdx01_CUSTCD.CodeParameterName = "CUSTCD";
                this.cdx01_CUSTCD.NameParameterName = "CUSTNM";
                this.cdx01_CUSTCD.HEParameterAdd("LANG_SET", _LANG_SET);


                DataSet source = this.GetTypeCode("Z6");
                this.cbo01_RTN_AREA.DataBind(source.Tables[0], true);

                DataTable source2 = new DataTable();
                source2.Columns.Add("CODE");
                source2.Columns.Add("NAME");
                source2.Rows.Add("0", this.GetLabel("REG_DATE"));//"등록일자");
                source2.Rows.Add("1", this.GetLabel("OCCUR_DATE"));//"발생일자");
                this.cbo01_GUBUN.DataBind(source2, false);
                this.cbo01_GUBUN.SetValue("0");


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.SetRequired(lbl01_BIZNM);

                this.BtnReset_Click(null, null);

                //this.dte01_RCV_DATE_FROM.SetMMFromStart();
                this.dte01_RCV_DATE_FROM.SetValue(this.dte01_RCV_DATE_FROM.GetDateText().Substring(0, 8) + "01");
                
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
                this.grd01_QA30224.InitializeDataSource();
              
           
               
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
                string RCV_DATE_FROM = this.dte01_RCV_DATE_FROM.GetDateText();
                string RCV_DATE_TO = this.dte01_RCV_DATE_TO.GetDateText();
                string DATE_DIV = this.cbo01_GUBUN.GetValue().ToString();
                string CUSTCD = this.cdx01_CUSTCD.GetValue().ToString();
                string RTN_AREA = this.cbo01_RTN_AREA.GetValue().ToString();
                string PARTNO = this.txt01_PARTNO_PARTNONM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DATE_DIV", DATE_DIV);
                paramSet.Add("BEG_DATE", RCV_DATE_FROM);
                paramSet.Add("END_DATE", RCV_DATE_TO);

                paramSet.Add("CUSTCD", CUSTCD);
                paramSet.Add("RTN_AREA", RTN_AREA);
                paramSet.Add("PARTNO_PARTNM", PARTNO);

                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();

             
                //source = _WSCOM.Inquery(paramSet);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.grd01_QA30224.SetValue(source);
                

                this.AfterInvokeServer();

                //this.grd_COROL(grd01_QA30224);
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

        private void grd_COROL(AxFlexGrid grd)
        {
            if (grd.Rows.Count >= grd.Rows.Fixed)
            {
                grd.Styles.Add("COLOR_W").BackColor = Color.FromArgb(255, 255, 255);
                grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
                grd.Styles.Add("COLOR_G").BackColor = Color.FromArgb(200, 255, 200);
                grd.Styles.Add("COLOR_Y").BackColor = Color.FromArgb(255, 255, 200);

                CellRange cr = new CellRange();

                for (int i = 1; i < grd.Rows.Count; i++)
                {
                    switch (grd.GetValue(i, "ORDER2").ToString())
                    {
                        case "2":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_B"];
                            break;
                        case "3":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_G"];
                            break;
                        case "4":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_Y"];
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        #endregion

        #region [그리드 이벤트]

        private void grd01_QA30224_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        #endregion
    }
}
