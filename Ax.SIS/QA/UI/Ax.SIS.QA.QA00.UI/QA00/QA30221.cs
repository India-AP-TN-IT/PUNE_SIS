#region ▶ Description & History
/* 
 * 프로그램명 : QA30132 완(반)제품 폐기 불량 조회
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
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>완(반)제품 폐기 불량 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:22:28<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:22:28   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30221 : AxCommonBaseControl
    {
        //private IQA30221 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30221";

        #region [ 초기화 작업 정의 ]

        public QA30221()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30221>("QA00", "QA30221.svc", "CustomBinding");
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

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD_OF_VINCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMCD_OF_VINNM";
                this.cdx01_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_ITEMCD.HEParameterAdd("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx01_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx01_DEFCD.CodeParameterName = "DEFCD";
                this.cdx01_DEFCD.NameParameterName = "DEFNM";
                this.cdx01_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                //this.cdx01_DEFCD.CodePixedLength = 5;
                this.cdx01_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx01_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx01_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx01_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet source = this.GetTypeCode("FY", "F4");
                this.cbo01_MGRT_DIV.DataBind(source.Tables[0], true);
                this.cbo01_MGRT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_IMPUT_DIVCD.DataBind(source.Tables[1], true);
                this.cbo01_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA30221.AllowEditing = false;
                this.grd01_QA30221.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30221.Initialize();
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "PROC_DATE","OCCUR_DATE");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD","ITEM");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "A'SSY NO", "ASSYPNO");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "A'SSY NAME", "ASSYPNM");
                //this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "A'SSY 단가", "DEF_UCOST", "DEF_UCOST");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "폐기수량", "DEF_QTY", "DIS_QTY");
                //this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "수정수량", "AMD_QTY", "AMD_QTY");
                //this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "폐기금액", "DEF_AMT", "DIS_AMT");
                this.grd01_QA30221.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 120, "불량내용", "DEFCD", "DEFCD");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA30221.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "불량부위", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA30221.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 120, "조치구분", "MGRT_DIV", "MGRT_CD");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "조치구분", "MGRT_NM", "MGRT_CD");
                this.grd01_QA30221.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "귀책구분", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "귀책구분", "IMPUT_DIVNM", "IMPUT_DIVNM");
                this.grd01_QA30221.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "귀책업체", "IMPUT_VENDCD", "IMPUT_VENDCD");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "IMPUT_VENDNM", "IMPUT_VENDNM");
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "폐기번호", "DEFNO", "DIS_NO");
                //this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 30, "S", "DEF_SEQ");

                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA30221.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA30221.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA30221.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01_QA30221.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");
                //this.grd01_QA30221.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_UCOST");
                this.grd01_QA30221.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                //this.grd01_QA30221.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMD_QTY");
                //this.grd01_QA30221.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.19 공장구분 조회조건 추가
                //2015.07.01 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE);

                this.BtnReset_Click(null, null);

                //this.dte01_PROC_DATE_FROM.SetMMFromStart();
                this.dte01_PROC_DATE_FROM.SetValue(this.dte01_PROC_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");

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
                this.grd01_QA30221.InitializeDataSource();
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
                string PROC_DATE_FROM = this.dte01_PROC_DATE_FROM.GetDateText().ToString();
                string PROC_DATE_TO = this.dte01_PROC_DATE_TO.GetDateText().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx01_ITEMCD.GetValue().ToString();
                string DEFCD = this.cdx01_DEFCD.GetValue().ToString();
                string DEFPOSCD = this.cdx01_DEFPOSCD.GetValue().ToString();
                string MGRT_DIV = this.cbo01_MGRT_DIV.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo01_IMPUT_DIVCD.GetValue().ToString();
                string PARTNO = this.txt01_PARTNO.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();      //공장구분 추가


                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE_FROM", PROC_DATE_FROM);
                paramSet.Add("PROC_DATE_TO", PROC_DATE_TO);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("DEFCD", DEFCD);
                paramSet.Add("DEFPOSCD", DEFPOSCD);
                paramSet.Add("MGRT_DIV", MGRT_DIV);
                paramSet.Add("IMPUT_DIVCD", IMPUT_DIVCD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);                                    //공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30221.SetValue(source);
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

        #region [ 기타 이벤트 정의 ]

        private void cdx01_ITEMCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_DEFCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_DEFPOSCD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                ((AxCodeBox)sender).HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_QA30221_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30221.SelectedRowIndex;

                if (Row >= this.grd01_QA30221.Rows.Fixed)
                {
                    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                    string PROC_DATE = this.grd01_QA30221.GetValue(Row, "PROC_DATE").ToString();
                    string IMPUT_VENDCD = this.grd01_QA30221.GetValue(Row, "IMPUT_VENDCD").ToString();
                    string PARTNO_PARTNM = this.grd01_QA30221.GetValue(Row, "PARTNO").ToString();
                    string DEFNO = this.grd01_QA30221.GetValue(Row, "DEFNO").ToString();

                    ShowPopup(new QA20211(BIZCD, PROC_DATE, IMPUT_VENDCD, PARTNO_PARTNM, DEFNO));
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
