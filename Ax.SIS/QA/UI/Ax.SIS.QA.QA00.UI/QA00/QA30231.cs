#region ▶ Description & History
/* 
 * 프로그램명 : QA30231 공정불량 종합현황 조회
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014.07.02      배명희     최초 클래스 생성
 *              2015-07-24      배명희      통합WCF로 변경
 * 
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
  
    public partial class QA30231 : AxCommonBaseControl
    {
        //private IQA30231 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30231";

        #region [ 초기화 작업 정의 ]

        public QA30231()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30231>("QA00", "QA30231.svc", "CustomBinding");
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

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.19 공장구분 조회조건 추가
                //2015.07.01 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.grd01_QA30231.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd01_QA30231.AllowEditing = false;
                this.grd01_QA30231.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30231.Initialize(false);
                this.grd01_QA30231.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA30231.Cols.Count = this.grd01_QA30231.Cols.Fixed;
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "라인코드", "LINECD", "LINECD");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "라인명", "LINENM", "LINENM");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "차종", "VINCD","VIN");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품목", "ITEMNM","ITEM");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO","PARTNO");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM","PARTNM");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "생산수량", "RSLT_QTY", "PRD_QTY");
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "불량수량", "DEF_QTY", "DEF_QTY");                
                this.grd01_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "PPM", "PPM");
                this.grd01_QA30231.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "ORDER2", "ORDER2");
                this.grd01_QA30231.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY");
                this.grd01_QA30231.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA30231.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM");
                this.grd01_QA30231.Cols["PPM"].Format = "###,###,###,###,###.0";   
                this.grd01_QA30231.Cols["LINENM"].AllowMerging = true;
                this.grd01_QA30231.Cols["LINECD"].AllowMerging = true;

                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA30231.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA30231.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA30231.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;


                this.grd02_QA30231.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd02_QA30231.AllowEditing = false;
                this.grd02_QA30231.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30231.Initialize(false);
                this.grd02_QA30231.AllowSorting = AllowSortingEnum.None;
                
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  80, "발생일자", "RCV_DATE","OCCUR_DATE");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "라인코드", "LINECD", "LINECD");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "라인명", "LINENM", "LINENM");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  70, "차종", "VINCD","VIN");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품목", "ITEMNM","ITEM");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNM");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량코드", "DEFCD", "DEFCD");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량유형", "DEFNM", "DEFNM");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA30231.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "비고", "REMARK", "REMARK");
                this.grd02_QA30231.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd02_QA30231.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE);

                this.BtnReset_Click(null, null);

                //this.dte01_RCV_DATE_FROM.SetMMFromStart();
                this.dte01_RCV_DATE_FROM.SetValue(this.dte01_RCV_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");
                
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
                this.grd01_QA30231.InitializeDataSource();
                this.grd02_QA30231.InitializeDataSource();
              
           
                this.chk01_QA30231_MSG1.Checked = true;
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
                string RCV_DATE_FROM = this.dte01_RCV_DATE_FROM.GetDateText().ToString();
                string RCV_DATE_TO = this.dte01_RCV_DATE_TO.GetDateText().ToString();
               
                string DEF_YN = this.chk01_QA30231_MSG1.GetValue().ToString().Equals("Y") ? "1" : "0";
              
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("BEG_DATE", RCV_DATE_FROM);
                paramSet.Add("END_DATE", RCV_DATE_TO);
            
                paramSet.Add("BAD_ONLY", DEF_YN);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();

             
                //source = _WSCOM.Inquery(paramSet);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.grd01_QA30231.SetValue(source);
                this.grd02_QA30231.InitializeDataSource();
                

                this.AfterInvokeServer();

                this.grd_COROL(grd01_QA30231);
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

        private void grd01_QA30231_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int r = this.grd01_QA30231.MouseRow;
            if (r < this.grd01_QA30231.Rows.Fixed || r >= this.grd01_QA30231.Rows.Count)
            {
                this.grd02_QA30231.InitializeDataSource();
                return;
            }


            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string RCV_DATE_FROM = this.dte01_RCV_DATE_FROM.GetDateText().ToString();
                string RCV_DATE_TO = this.dte01_RCV_DATE_TO.GetDateText().ToString();

                string LINECD = this.grd01_QA30231.GetValue(r, "LINECD").ToString();
                string PARTNO = this.grd01_QA30231.GetValue(r, "PARTNO").ToString();

                string PLANT_DIV = this.grd01_QA30231.GetValue(r, "PLANT_DIV").ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("BEG_DATE", RCV_DATE_FROM);
                paramSet.Add("END_DATE", RCV_DATE_TO);

                paramSet.Add("LINECD", LINECD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();


                //source = _WSCOM.Inquery_Detail(paramSet);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);

                this.grd02_QA30231.SetValue(source);

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
    }
}
