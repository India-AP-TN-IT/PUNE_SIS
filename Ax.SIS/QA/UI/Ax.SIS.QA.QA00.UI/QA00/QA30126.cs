#region ▶ Description & History
/* 
 * 프로그램명 : QA30126 공정불량 기간별 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-24      배명희      통합WCF로 변경 
*/
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
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>공정불량 기간별 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:43:10<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:43:10   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30126 : AxCommonBaseControl
    {
        //private IQA30126 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30126";

        #region [ 초기화 작업 정의 ]

        public QA30126()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30126>("QA00", "QA30126.svc", "CustomBinding");
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
                this._buttonsControl.BtnPrint.Visible = false;
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

                DataTable combo_source1 = new DataTable();
                combo_source1.Columns.Add("CODE");
                combo_source1.Columns.Add("NAME");
                combo_source1.Rows.Add("R", this.GetLabel("PROCESS_DEFECT"));//"공정불량");
                combo_source1.Rows.Add("L", this.GetLabel("LINE_DEFECT"));//"LINE불량");
                this.cbo01_DEFTYPE.DataBind(combo_source1);
                this.cbo01_DEFTYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.17 공장구분 조회조건 추가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                DataSet source = this.GetTypeCode("F4");
                this.cbo01_IMPUT_DIVCD.DataBind(source.Tables[0]);
                this.cbo01_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA30126.AllowEditing = false;
                this.grd01_QA30126.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30126.Initialize();
                this.grd01_QA30126.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30126.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "불량일자", "RCV_DATE", "DEFECT_DATE");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "불량구분", "DEF_TYPE", "DEFECT_DIV");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "불량장소", "DEF_PLACE", "DEF_PLACE");
                this.grd01_QA30126.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "귀책업체", "VENDCD", "IMPUT_VENDCD");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDOR", "IMPUT_VENDNM");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNM", "PARTNM");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD","VIN");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD","ITEM");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "불량번호", "NOTENO", "DEFECT_NOTENO");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "불량유형", "DEFCD", "DEFCD");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "귀책구분", "IMPUT_DIV", "IMPUT_DIVCD");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "재사용여부", "MAT_REUSE_YN", "MAT_REUSE_YN");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "SHIFT", "DN_DIV", "SHIFT");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "ALC코드", "ALCCD", "ALCCD");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "LINE코드", "LINECD", "LINECD");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "완제품번", "ASSYPNO", "ASSYPNO");
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사자", "INSPECT_EMP", "INSPECT_NAME");
                //this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "결재형태", "DESIDE", "APP_TYPE"); --글로발표준 전자결재로직 제거 (2018-01-19)
                this.grd01_QA30126.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA30126.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd01_QA30126.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");

                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA30126.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA30126.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA30126.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE);

                this.BtnReset_Click(null, null);

                //this.dte01_RCV_DATE_FROM.SetMMFromStart();
                this.dte01_RCV_DATE_FROM.SetValue(this.dte01_RCV_DATE_FROM.Value.ToString("yyyy-MM-dd").Substring(0, 8) + "01");
                
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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
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
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo01_IMPUT_DIVCD.GetValue().ToString();
                string PARTNO_PARTNONM = this.txt01_PARTNO_PARTNONM.GetValue().ToString();
                string DEFTYPE = this.cbo01_DEFTYPE.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString(); //공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("IMPUT_DIVCD", IMPUT_DIVCD);
                paramSet.Add("PARTNO_PARTNONM", PARTNO_PARTNONM);
                paramSet.Add("DEFTYPE", DEFTYPE);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);   //공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30126.SetValue(source);
                this.grd_COROL(grd01_QA30126);
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

        #region [ 사용자 정의 이벤트 ]

        private void grd_COROL(AxFlexGrid grd)
        {
            //글로발표준 전자결재로직 제거 2018-01-19 
            //grd.Styles.Add("COLOR_B").ForeColor = Color.FromArgb(0, 0, 255);
            //grd.Styles.Add("COLOR_R").ForeColor = Color.FromArgb(255, 0, 0);

            //CellRange cr = new CellRange();
            //for (int i = 1; i < grd.Rows.Count; i++)
            //{
            //    cr = grd.GetCellRange(i, grd.Cols["DESIDE"].Index, i, grd.Cols["DESIDE"].Index);

            //    if (grd.GetValue(i, "DESIDE").ToString().Equals(this.GetLabel("COMPLETED"))) //완결
            //    {
            //        cr.Style = grd.Styles["COLOR_B"];
            //        //break;
            //    }
            //    else if (grd.GetValue(i, "DESIDE").ToString().Equals(this.GetLabel("NOT_COMPLETE"))) // 미결
            //    {
            //        cr.Style = grd.Styles["COLOR_R"];
            //        //break;
            //    }
            //    //else
            //    //{
            //    //    break;
            //    //}

            //    //switch (grd.GetValue(i, "DESIDE").ToString())
            //    //{
            //    //    case "완결":
            //    //        cr.Style = grd.Styles["COLOR_B"];
            //    //        break;
            //    //    case "미결":
            //    //        cr.Style = grd.Styles["COLOR_R"];
            //    //        break;
            //    //    default:
            //    //        break;
            //    //}
            //}
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void grd01_QA30126_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30126.SelectedRowIndex;

                if (Row >= this.grd01_QA30126.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA30126.GetValue(Row, "BIZCD").ToString();
                    string RCV_DATE = this.grd01_QA30126.GetValue(Row, "RCV_DATE").ToString();
                    string VENDCD = this.grd01_QA30126.GetValue(Row, "VENDCD").ToString();
                    string NOTENO = this.grd01_QA30126.GetValue(Row, "NOTENO").ToString();

                    if (this.grd01_QA30126.GetValue(Row, "DEF_TYPE").ToString() == this.GetLabel("PROCESS_DEFECT"))//"공정불량")
                    {
                        ShowPopup(new QA20123(BIZCD, RCV_DATE, VENDCD, NOTENO));
                    }
                    else
                    {
                        ShowPopup(new QA20121(BIZCD, RCV_DATE, VENDCD, NOTENO));
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
