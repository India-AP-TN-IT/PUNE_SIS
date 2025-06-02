#region ▶ Description & History
/* 
 * 프로그램명 : QA20122 공정불량생산 등록 
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
 *				2017-07-17      배명희      저장시 불량수량 체크 로직에 string.IsNullOrEmpty(DEF_QTY) 조건 추가함.
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
using System.Drawing;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>공정불량생산 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:41:50<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:41:50   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20122 : AxCommonBaseControl
    {
        //private IQA20122 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20122";

        #region [ 초기화 작업 정의 ]

        public QA20122()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20122>("QA00", "QA20122.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.17 공장구분 조회조건 추가
                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.17 공장구분 입력항목 추가
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))    //2013.04.17 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                {
                    this.cbo02_PLANT_DIV.SetReadOnly(true);
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                }

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("LINECD");//"라인코드";
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_LINECD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_LINECD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());


                DataSet dsShift = AxFlexGrid.GetDataSourceSchema("CODE", "TEXT");
                dsShift.Tables[0].Rows.Add("1", "1");
                dsShift.Tables[0].Rows.Add("2", "2");
                dsShift.Tables[0].Rows.Add("3", "3");
                this.cbo02_DN_DIV.DataBind(dsShift.Tables[0], false);
                this.cbo02_DN_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx02_ALCCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ALCCD.PopupTitle = "ALC CODE";
                this.cdx02_ALCCD.CodeParameterName = "ALCCD";
                this.cdx02_ALCCD.NameParameterName = "ALCNM";
                this.cdx02_ALCCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ALCCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("RCV_DATE", this.dte02_RCV_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEParameterAdd("LINECD", this.cdx02_LINECD.GetValue().ToString());
                this.cdx02_ALCCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_ASSYPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_ASSYPNO.PopupTitle = this.GetLabel("ASSYCD");//"완제품코드";
                this.cdx02_ASSYPNO.CodeParameterName = "ASSYPNO";
                this.cdx02_ASSYPNO.NameParameterName = "ASSYPNM";
                this.cdx02_ASSYPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_ASSYPNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYPNO.HEParameterAdd("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYPNO.HEParameterAdd("RCV_DATE", this.dte02_RCV_DATE.GetDateText().ToString());
                this.cdx02_ASSYPNO.HEParameterAdd("LINECD", this.cdx02_LINECD.GetValue().ToString());
                this.cdx02_ASSYPNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEF_PNO.HEPopupHelper = new QASubWindow();
                this.cdx02_DEF_PNO.PopupTitle = this.GetLabel("PARTNO_INFO");//"PART NO 정보";
                this.cdx02_DEF_PNO.CodeParameterName = "PARTNO_OF_ASSYPNO";
                this.cdx02_DEF_PNO.NameParameterName = "PARTNO_OF_ASSYPNM";
                this.cdx02_DEF_PNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEF_PNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEParameterAdd("ASSYPNO", this.cdx02_ASSYPNO.GetValue().ToString());
                this.cdx02_DEF_PNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEF_PLACECD.HEPopupHelper = new QASubWindow();
                this.cdx02_DEF_PLACECD.PopupTitle = this.GetLabel("DEF_PLACECD");//"불량장소코드";
                this.cdx02_DEF_PLACECD.CodeParameterName = "XD_CODE";
                this.cdx02_DEF_PLACECD.NameParameterName = "XD_NAME";
                this.cdx02_DEF_PLACECD.HEParameterAdd("XD_CLASS", "FT");
                this.cdx02_DEF_PLACECD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_DEF_PLACECD.HEParameterAdd("USE_YN", "Y");
                this.cdx02_DEF_PLACECD.HEParameterAdd("GROUPCD", "2");

                this.cdx02_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx02_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx02_DEFCD.CodeParameterName = "DEFCD";
                this.cdx02_DEFCD.NameParameterName = "DEFNM";
                this.cdx02_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx02_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx02_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx02_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                DataSet IMPUT_DIVCD = this.GetTypeCode("F4");
                this.cbo02_IMPUT_DIVCD.DataBind(IMPUT_DIVCD.Tables[0], false);
                this.cbo02_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA20122.AllowEditing = false;
                this.grd01_QA20122.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20122.Initialize();
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE", "OCCUR_DATE");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "발생장소코드", "DEF_PLACECD", "DEF_PLACECD");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "발생장소", "DEF_PLACENM", "DEF_PLACENM");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "LINE CODE", "LINECD", "LINECD");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "LINE", "LINENM", "LINENM");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD","ALCCD");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "DEF_PNO", "DEF_PNO");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NAME", "DEF_PNONM", "DEF_PNONM");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "번호", "NOTENO", "NOTENO");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "ASS'Y NO", "ASSYPNO");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "SHIFT", "DN_DIV", "SHIFT");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "차종", "VINCD", "VINCD");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMCD", "ITEMNM3");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "Usage", "USAGE");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "작업자", "PROD_REG_EMPNO", "WORK_EMPNO");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "작업자", "PROD_REG_EMPNM", "WORK_EMPNO");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "판정여부", "JUD_YN", "JUD_YN");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "귀책구분", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "불량내용코드", "DEFCD", "DEFCD");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA20122.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "불량부위코드", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA20122.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01_QA20122.SetColumnType(AxFlexGrid.FCellType.ComboBox, "F4", "IMPUT_DIVCD");

                //this.grd01_QA20122.AddColumn(false, false, HEFlexGrid.FtextAlign.L, 80, "공장구분", "PLANT_DIV");    //공장구분 추가
                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA20122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA20122.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA20122.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.SetRequired(lbl01_BIZNM, lbl02_BIZNM, lbl01_OCCUR_DATE, lbl02_OCCUR_DATE, lbl02_LINECD, lbl02_ALCCD, lbl02_WORK_EMPNO, lbl02_ASSYPNO, lbl02_DEF_PNO, lbl02_DEF_QTY, lbl02_USAGE, lbl02_PLANT_DIV);

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
                foreach (Control ctl in grp01_QA20122_MSG2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.txt02_PROD_REG_EMPNO.SetValue(this.UserInfo.EmpNo);
                this.txt02_PROD_REG_EMPNM.SetValue(this.UserInfo.UserName);
                this.cbo02_BIZCD.Initialize();

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.dte02_RCV_DATE.Enabled = true;
                this.cdx02_LINECD.Enabled = true;
                this.cdx02_ALCCD.Enabled = true;
                this.cdx02_ASSYPNO.Enabled = true;

                this.cdx_SETTING();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                base.BtnClose_Click(sender, e);
                ((Form)this.Parent).Close();
            }
            catch
            {
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string RCV_DATE = this.dte01_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string NOTENO = this.txt01_NOTENO.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.18 공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("NOTENO", NOTENO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.18 공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20122.SetValue(source);

                this.grd01_QA20122.Styles.Add("A").BackColor = Color.FromArgb(200, 200, 255);

                CellRange cr = new CellRange();
                for (int i = 1; i < grd01_QA20122.Rows.Count; i++)
                {
                    cr = grd01_QA20122.GetCellRange(i, grd01_QA20122.Cols.Fixed, i, grd01_QA20122.Cols.Count - grd01_QA20122.Cols.Fixed);

                    switch (this.grd01_QA20122.GetValue(i, "JUD_YN").ToString().Substring(0, 1))
                    {
                        case "Y":
                            cr.Style = grd01_QA20122.Styles["A"];
                            break;
                        default:
                            break;
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
                {
                    //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
                    MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
                    return;
                }

                DataSet source = this.grd01_QA20122.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "RCV_DATE", "NOTENO", "LINECD",
                    "DN_DIV", "ALCCD", "PROD_REG_EMPNO", "ASSYPNO", "DEF_PNO",
                    "DEF_PLACECD", "VENDCD", "DEF_QTY", "IMPUT_DIVCD", "DEFCD", "DEFPOSCD", "PLANT_DIV"); //공장구분 추가 2013.04.18
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.dte02_RCV_DATE.GetDateText(),
                    this.txt02_NOTENO.GetValue(),
                    this.cdx02_LINECD.GetValue(),
                    this.cbo02_DN_DIV.GetValue(),
                    this.cdx02_ALCCD.GetValue(),
                    this.txt02_PROD_REG_EMPNO.GetValue(),
                    this.cdx02_ASSYPNO.GetValue(),
                    this.cdx02_DEF_PNO.GetValue(),
                    this.cdx02_DEF_PLACECD.GetValue(),
                    this.txt02_VENDCD.GetValue(),
                    this.nme02_DEF_QTY.GetDBValue(),
                    this.cbo02_IMPUT_DIVCD.GetValue(),
                    this.cdx02_DEFCD.GetValue(),
                    this.cdx02_DEFPOSCD.GetValue(),
                    this.cbo02_PLANT_DIV.GetValue() //공장구분 추가 2013.04.18
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("공정불량생산 등록이 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo01_BIZCD.Enabled != true && cbo01_BIZCD.GetValue().ToString().Trim() != this.UserInfo.BusinessCode)
                {
                    //MsgBox.Show("다른 사업장의 데이터는 조작이 불가능합니다.", "알림", MessageBoxButtons.OK);
                    MsgCodeBox.Show("QA00-013", MessageBoxButtons.OK);
                    return;
                }

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "NOTENO");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_NOTENO.GetValue()
                );

                if (!IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("공정불량생산 등록이 삭제 되었습니다.");
                MsgCodeBox.Show("CD00-0072");
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

        private void grd01_QA20122_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20122.SelectedRowIndex;

                if (Row >= this.grd01_QA20122.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA20122.GetValue(Row, "BIZCD").ToString();
                    string RCV_DATE = this.grd01_QA20122.GetValue(Row, "RCV_DATE").ToString();
                    string NOTENO = this.grd01_QA20122.GetValue(Row, "NOTENO").ToString();
                    string LINECD = this.grd01_QA20122.GetValue(Row, "LINECD").ToString();
                    string DN_DIV = this.grd01_QA20122.GetValue(Row, "DN_DIV").ToString();
                    string ALCCD = this.grd01_QA20122.GetValue(Row, "ALCCD").ToString();
                    string VINCD_ITEMCD = "Vehicle : " + this.grd01_QA20122.GetValue(Row, "VINCD").ToString() + " / Item : " + this.grd01_QA20122.GetValue(Row, "ITEMCD").ToString();
                    string PROD_REG_EMPNO = this.grd01_QA20122.GetValue(Row, "PROD_REG_EMPNO").ToString();
                    string PROD_REG_EMPNM = this.grd01_QA20122.GetValue(Row, "PROD_REG_EMPNM").ToString();
                    string ASSYPNO = this.grd01_QA20122.GetValue(Row, "ASSYPNO").ToString();
                    string DEF_PNO = this.grd01_QA20122.GetValue(Row, "DEF_PNO").ToString();
                    string DEF_PLACECD = this.grd01_QA20122.GetValue(Row, "DEF_PLACECD").ToString();
                    string VENDCD = this.grd01_QA20122.GetValue(Row, "VENDCD").ToString();
                    string VENDNM = this.grd01_QA20122.GetValue(Row, "VENDNM").ToString();
                    string DEF_QTY = this.grd01_QA20122.GetValue(Row, "DEF_QTY").ToString();
                    string USAGE = this.grd01_QA20122.GetValue(Row, "USAGE").ToString();
                    string JUD_YN = this.grd01_QA20122.GetValue(Row, "JUD_YN").ToString();
                    string IMPUT_DIVCD = this.grd01_QA20122.GetValue(Row, "IMPUT_DIVCD").ToString();
                    string DEFCD = this.grd01_QA20122.GetValue(Row, "DEFCD").ToString();
                    string DEFPOSCD = this.grd01_QA20122.GetValue(Row, "DEFPOSCD").ToString();

                    string PLANT_DIV = this.grd01_QA20122.GetValue(Row, "PLANT_DIV").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.dte02_RCV_DATE.SetValue(RCV_DATE);
                    this.txt02_NOTENO.SetValue(NOTENO);
                    this.cbo02_DN_DIV.SetValue(DN_DIV);

                    this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", BIZCD);
                    this.cdx02_LINECD.SetValue(LINECD);

                    this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", BIZCD);
                    this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", RCV_DATE);
                    this.cdx02_ALCCD.HEUserParameterSetValue("LINECD", LINECD);
                    this.cdx02_ALCCD.SetValue(ALCCD);

                    this.cdx02_ASSYPNO.HEUserParameterSetValue("BIZCD", BIZCD);
                    this.cdx02_ASSYPNO.HEUserParameterSetValue("ALCCD", ALCCD);
                    this.cdx02_ASSYPNO.HEUserParameterSetValue("RCV_DATE", RCV_DATE);
                    this.cdx02_ASSYPNO.HEUserParameterSetValue("LINECD", LINECD);
                    this.cdx02_ASSYPNO.SetValue(ASSYPNO);

                    this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", BIZCD);
                    this.cdx02_DEF_PNO.HEUserParameterSetValue("ASSYPNO", ASSYPNO);
                    this.cdx02_DEF_PNO.SetValue(DEF_PNO);

                    this.cdx02_DEF_PLACECD.HEUserParameterSetValue("XD_CLASS", "FT");
                    this.cdx02_DEF_PLACECD.SetValue(DEF_PLACECD);

                    this.cbo02_IMPUT_DIVCD.SetValue(IMPUT_DIVCD);
                    this.cdx02_DEFCD.SetValue(DEFCD);
                    this.cdx02_DEFPOSCD.SetValue(DEFPOSCD);

                    this.txt02_VENDCD.SetValue(VENDCD);
                    this.txt02_VENDNM.SetValue(VENDNM);
                    this.txt02_VINCD_ITEMCD.SetValue(VINCD_ITEMCD);
                    this.txt02_PROD_REG_EMPNO.SetValue(PROD_REG_EMPNO);
                    this.txt02_PROD_REG_EMPNM.SetValue(PROD_REG_EMPNM);
                    this.nme02_DEF_QTY.SetValue(DEF_QTY);
                    this.txt02_USAGE.SetValue(USAGE);
                    this.txt02_JUD_YN.SetValue(JUD_YN);

                    this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);   // 공장구분

                    this.cbo02_BIZCD.Enabled = false;
                    this.dte02_RCV_DATE.Enabled = false;
                    this.cdx02_LINECD.Enabled = false;
                    this.cdx02_ALCCD.Enabled = false;
                    this.cdx02_ASSYPNO.Enabled = false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cdx02_DEF_PNO_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string PARTNO = this.cdx02_DEF_PNO.GetValue().ToString();
                string ASSYPNO = this.cdx02_ASSYPNO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("ASSYPNO", ASSYPNO);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_VENDCD_OF_PARTNO(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VENDCD_OF_PARTNO"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.txt02_VINCD_ITEMCD.SetValue("Vehicle : " + source.Tables[0].Rows[0]["VINCD"].ToString() + " / Item : " + source.Tables[0].Rows[0]["ITEMCD"].ToString());
                    this.lbl02_UNITEA.Value = source.Tables[0].Rows[0]["UNIT"].ToString();
                    this.txt02_USAGE.SetValue(source.Tables[0].Rows[0]["ACM_USG"].ToString());
                    this.txt02_VENDCD.SetValue(source.Tables[0].Rows[0]["VENDCD_OF_PARTNO"].ToString());
                    this.txt02_VENDNM.SetValue(source.Tables[0].Rows[0]["VENDCD_OF_PARTNM"].ToString());
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

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void dte02_RCV_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx02_LINECD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_LINECD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ALCCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ASSYPNO_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_ASSYPNO_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }
        
        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string DN_DIV = this.cbo02_DN_DIV.GetValue().ToString();
                string LINECD = this.cdx02_LINECD.GetValue().ToString();
                string ALCCD = this.cdx02_ALCCD.GetValue().ToString();
                string PROD_REG_EMPNO = this.txt02_PROD_REG_EMPNO.GetValue().ToString();
                string ASSYPNO = this.cdx02_ASSYPNO.GetValue().ToString();
                string DEF_PNO = this.cdx02_DEF_PNO.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();
                string JUD_YN = this.txt02_JUD_YN.GetValue().ToString();
                string VENDCD = this.txt02_VENDCD.GetValue().ToString();

                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString(); //공장구분 추가 2013.04.18

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(RCV_DATE) == 0)
                {
                    //MsgBox.Show("발생일자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_OCCUR_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(DN_DIV) == 0)
                {
                    //MsgBox.Show("주야구분이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_SHIFT.Text);
                    return false;
                }

                if (this.GetByteCount(ALCCD) == 0)
                {
                    //MsgBox.Show("ALC 코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_ALCCD.Text);
                    return false;
                }

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show("라인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LINECD.Text);
                    return false;
                }

                if (this.GetByteCount(PROD_REG_EMPNO) == 0)
                {
                    //MsgBox.Show("작업자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_WORK_EMPNO.Text);
                    return false;
                }

                if (this.GetByteCount(ASSYPNO) == 0)
                {
                    //MsgBox.Show("완제품코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_ASSYPNO.Text);
                    return false;
                }

                if (this.GetByteCount(DEF_PNO) == 0)
                {
                    //MsgBox.Show("PART NO가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_DEF_PNO.Text);
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //EO된 품번이거나 업체가 지정되지 않은 품번입니다.!
                    MsgCodeBox.Show("QA00-033");
                    return false;
                }

                if (string.IsNullOrEmpty(DEF_QTY) || Int32.Parse(DEF_QTY) <= 0)
                {
                    //MsgBox.Show("불량수량이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_DEF_QTY.Text);
                    return false;
                }

                if (JUD_YN == "Y")
                {
                    //MsgBox.Show("판정이 된 상태에서는 저장이 불가능 합니다.");
                    MsgCodeBox.Show("QA00-015");
                    return false;
                }

                //공장구분 필수입력 여부 체크 2013.04.17
                if (this.GetByteCount(PLANT_DIV) == 0)
                {
                    //MsgBox.Show("공장구분이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_PLANT_DIV.Text);
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsRemoveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string NOTENO = this.txt02_NOTENO.GetValue().ToString();
                string JUD_YN = this.txt02_JUD_YN.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(NOTENO) == 0)
                {
                    //MsgBox.Show("생산전표번호가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_NOTENO.Text);
                    return false;
                }

                if (JUD_YN == "Y")
                {
                    //MsgBox.Show("판정이 된 상태에서는 삭제가 불가능 합니다.");
                    MsgCodeBox.Show("QA00-015");
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void cdx_SETTING()
        {
            try
            {
                this.cdx02_ALCCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("RCV_DATE", this.dte02_RCV_DATE.GetDateText().ToString());
                this.cdx02_ALCCD.HEUserParameterSetValue("LINECD", this.cdx02_LINECD.GetValue().ToString());
                this.cdx02_ASSYPNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_ASSYPNO.HEUserParameterSetValue("ALCCD", this.cdx02_ALCCD.GetValue().ToString());
                this.cdx02_ASSYPNO.HEUserParameterSetValue("RCV_DATE", this.dte02_RCV_DATE.GetDateText().ToString());
                this.cdx02_ASSYPNO.HEUserParameterSetValue("LINECD", this.cdx02_LINECD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEUserParameterSetValue("ASSYPNO", this.cdx02_ASSYPNO.GetValue().ToString());
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PLACECD.HEUserParameterSetValue("XD_CLASS", "FT");
                this.cdx02_DEF_PLACECD.HEUserParameterSetValue("USE_YN", "Y");
                this.cdx02_DEF_PLACECD.HEUserParameterSetValue("GROUPCD", "2");
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))    //2013.04.18 공장구분 기본값 설정
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U9A1");
                //}
                //else
                //{
                //    this.cbo02_PLANT_DIV.SetValue("U901");
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
