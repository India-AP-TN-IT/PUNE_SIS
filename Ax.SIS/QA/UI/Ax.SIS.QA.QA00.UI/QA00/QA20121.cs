#region ▶ Description & History
/* 
 * 프로그램명 : QA20121 공정불량발생 품질 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
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
using System.IO;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>공정불량발생 품질 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-18 오후 2:40:33<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-18 오후 2:40:33   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20121 : AxCommonBaseControl
    {
        //private IQA20121 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private String _BIZCD;
        private String _RCV_DATE;
        private String _VENDCD;
        private String _NOTENO;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20121";
        
        #region [ 초기화 작업 정의 ]

        public QA20121()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20121>("QA00", "QA20121.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            _BIZCD = "";
            _RCV_DATE = "";
            _VENDCD = "";
            _NOTENO = "";
        }

        public QA20121(string BIZCD, string RCV_DATE, string VENDCD, string NOTENO)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20121>("QA00", "QA20121.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            _BIZCD = BIZCD;
            _RCV_DATE = RCV_DATE;
            _VENDCD = VENDCD;
            _NOTENO = NOTENO;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox2.Text = this.GetLabel("QA20121_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20121_MSG2");   

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
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");// "귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_DEF_PNO.HEPopupHelper = new QASubWindow();
                this.cdx02_DEF_PNO.PopupTitle = this.GetLabel("PARTNO_INFO");//"품번정보";
                this.cdx02_DEF_PNO.CodeParameterName = "PARTNO_OF_VENDCD";
                this.cdx02_DEF_PNO.NameParameterName = "PARTNO_OF_VENDNM";
                this.cdx02_DEF_PNO.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_DEF_PNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_DEF_PNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEParameterAdd("VENDCD", "");
                this.cdx02_DEF_PNO.CodePixedLength = 20;

                this.cdx02_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("LINECD");//"라인코드";
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_LINECD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_LINECD.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());

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

                this.cdx02_INSPECT_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_INSPECT_EMPNO.PopupTitle = this.GetLabel("INSPECT_CD");//"검사원코드";
                this.cdx02_INSPECT_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_INSPECT_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                
                DataSet source = this.GetTypeCode("F4");
                this.cbo02_IMPUT_DIVCD.DataBind(source.Tables[0], false);
                this.cbo02_IMPUT_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.pic01_DEF_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01_QA20121.AllowEditing = false;
                this.grd01_QA20121.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20121.Initialize();
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZNM");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE", "OCCUR_DATE");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "귀책업체코드", "DEF_IMPUT_VENDCD", "IMPUT_VENDCD");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 220, "귀책업체", "DEF_IMPUT_VENDNM", "IMPUT_VENDNM");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VINCD");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품번", "DEF_PNO", "DEF_PNO");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "품명", "DEF_PNONM", "DEF_PNONM");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "귀책코드", "IMPUT_DIVCD", "IMPUT_DIVCD");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "귀책", "IMPUT_DIVNM", "IMPUT_DIVNM");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "번호", "NOTENO", "NOTENO");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 50, "단가", "DEF_UCOST", "DEF_UCOST");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "금액", "DEF_AMT", "DEF_AMT");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "불량내용코드", "DEFCD", "DEFCD");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "불량부위코드", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "라인코드", "LINECD", "LINECD");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "품목코드", "ITEMCD", "ITEMCD");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "불량장소", "DEF_PLACECD", "DEF_PLACECD");
                this.grd01_QA20121.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "검사원", "INSPECT_EMPNO", "INSPECT_EMPNO");

                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA20121.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA20121.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA20121.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01_QA20121.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01_QA20121.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA20121.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_UCOST");
                this.grd01_QA20121.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");

                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE, lbl02_BIZNM, lbl02_OCCUR_DATE, lbl02_INPUT_VENDCD, lbl02_DEF_PNO, lbl02_IMPUT_VENDNM, lbl02_DEF_QTY, lbl02_DEF_UCOST, lbl02_DEF_AMT, lbl02_PLANT_DIV); //공장구분 필수입력
                this.dte01_RCV_DATE.SetValue(DateTime.Now);
                if (_NOTENO != "")
                {
                    this.cbo01_BIZCD.SetValue(_BIZCD);
                    this.dte01_RCV_DATE.SetValue(_RCV_DATE);
                    this.cdx01_VENDCD.SetValue(_VENDCD);
                    this.txt01_NOTENO.SetValue(_NOTENO);
                }

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                if (_NOTENO != "")
                {
                    this.grd(1);
                }
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

                this.pic01_DEF_PHOTO.Initialize();

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.dte02_RCV_DATE.Enabled = true;
                this.cdx02_VENDCD.Enabled = true;
                this.cdx02_DEF_PNO.Enabled = true;

                this.cdx_SETTING();
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
                string RCV_DATE = this.dte01_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string NOTENO = this.txt01_NOTENO.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.17 공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("NOTENO", NOTENO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.17 공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20121.SetValue(source);
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

                DataSet source = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "RCV_DATE", "NOTENO",  
                    "DEF_PNO", "IMPUT_DIVCD", "LINECD", "DEF_QTY", "DEF_UCOST",
                    "DEF_PLACECD", "DEFCD", "DEFPOSCD", "INSPECT_EMPNO", "VENDCD", "BLOB$DEF_PHOTO",
                    "PLANT_DIV");   //공장구분 추가 2013.04.17
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.dte02_RCV_DATE.GetDateText(),
                    this.txt02_NOTENO.GetValue(),
                    this.cdx02_DEF_PNO.GetValue(),
                    this.cbo02_IMPUT_DIVCD.GetValue(),
                    this.cdx02_LINECD.GetValue(),
                    this.nme02_DEF_QTY.GetDBValue(),
                    this.nme02_DEF_UCOST.GetDBValue(),
                    this.cdx02_DEF_PLACECD.GetValue(),
                    this.cdx02_DEFCD.GetValue(),
                    this.cdx02_DEFPOSCD.GetValue(),
                    this.cdx02_INSPECT_EMPNO.GetValue(),
                    this.cdx02_VENDCD.GetValue(),
                    this.pic01_DEF_PHOTO.GetValue(),
                    this.cbo02_PLANT_DIV.GetValue() //공장구분 추가 2013.04.17
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("공정불량발생 품질이 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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

                //MsgBox.Show("공정불량발생 품질이 삭제 되었습니다.");
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

        private void grd01_QA20121_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20121.SelectedRowIndex;

                if (Row >= this.grd01_QA20121.Rows.Fixed)
                {
                    this.grd(Row);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_INSPECT_STD_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DEF_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_DEF_PHOTO, 0, _DEF_PHOTO.Length);
                    fs.Close();

                    this.pic01_DEF_PHOTO.SetValue(_DEF_PHOTO);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn01_INSPECT_STD_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_DEF_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_DEF_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_DEF_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_DEF_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
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
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_VENDCD_OF_PARTNO(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VENDCD_OF_PARTNO"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.txt02_VINCD_ITEMCD.SetValue("Vehicle : " + source.Tables[0].Rows[0]["VINCD"].ToString() + " / Item : " + source.Tables[0].Rows[0]["ITEMCD"].ToString());
                    this.nme02_DEF_UCOST.SetValue(source.Tables[0].Rows[0]["UCOST"].ToString());
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

        private void cdx02_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx02_INSPECT_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue().ToString());
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string NOTENO = this.txt02_NOTENO.GetValue().ToString();
                string RCV_DATE = this.dte02_RCV_DATE.GetDateText().ToString();
                string VENDCD = this.cdx02_VENDCD.GetValue().ToString();
                string IMPUT_DIVCD = this.cbo02_IMPUT_DIVCD.GetValue().ToString();
                string DEF_PNO = this.cdx02_DEF_PNO.GetValue().ToString();
                string DEF_QTY = this.nme02_DEF_QTY.GetValue().ToString();
                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString(); //공장구분 추가 2013.04.17

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(NOTENO) == 6)
                {
                    //MsgBox.Show("전표번호가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_NOTENO.Text);
                    return false;
                }

                if (this.GetByteCount(RCV_DATE) == 0)
                {
                    //MsgBox.Show("반입일자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_OCCUR_DATE.Text);
                    return false;
                }

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("업체코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_INPUT_VENDCD.Text);
                    return false;
                }

                if (this.GetByteCount(IMPUT_DIVCD) == 0)
                {
                    //MsgBox.Show("귀책구분코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_IMPUT_VENDNM.Text);
                    return false;
                }

                if (this.GetByteCount(DEF_PNO) == 0)
                {
                    //MsgBox.Show("불량품번코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_DEF_PNO.Text);
                    return false;
                }

                if (this.GetByteCount(DEF_QTY) == 0)
                {
                    //MsgBox.Show("불량수량이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_DEF_QTY.Text);
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
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string NOTENO = this.txt02_NOTENO.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(NOTENO) == 6)
                {
                    //MsgBox.Show("전표번호가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_NOTENO.Text);
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
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PLACECD.HEUserParameterSetValue("XD_CLASS", "FT");
                this.cdx02_DEF_PLACECD.HEUserParameterSetValue("USE_YN", "Y");
                this.cdx02_DEF_PLACECD.HEUserParameterSetValue("GROUPCD", "2");
                this.cdx02_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_INSPECT_EMPNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEUserParameterSetValue("VENDCD", this.cdx02_VENDCD.GetValue().ToString());

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                //if (this.cbo02_BIZCD.GetValue().Equals("5220"))    //2013.04.17 공장구분 기본값 설정
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

        private void grd(int Row)
        {
            try
            {
                this.BtnReset_Click(null, null);

                string BIZCD = this.grd01_QA20121.GetValue(Row, "BIZCD").ToString();
                string RCV_DATE = this.grd01_QA20121.GetValue(Row, "RCV_DATE").ToString();
                string NOTENO = this.grd01_QA20121.GetValue(Row, "NOTENO").ToString();
                string VENDCD = this.grd01_QA20121.GetValue(Row, "DEF_IMPUT_VENDCD").ToString();
                string DEF_PNO = this.grd01_QA20121.GetValue(Row, "DEF_PNO").ToString();
                string IMPUT_DIVCD = this.grd01_QA20121.GetValue(Row, "IMPUT_DIVCD").ToString();
                string VINCD_ITEMCD = "Vehicle : " + this.grd01_QA20121.GetValue(Row, "VINCD").ToString() + " / Item : " + this.grd01_QA20121.GetValue(Row, "ITEMCD").ToString();
                string LINECD = this.grd01_QA20121.GetValue(Row, "LINECD").ToString();
                string DEF_QTY = this.grd01_QA20121.GetValue(Row, "DEF_QTY").ToString();
                string DEF_UCOST = this.grd01_QA20121.GetValue(Row, "DEF_UCOST").ToString();
                string DEF_AMT = this.grd01_QA20121.GetValue(Row, "DEF_AMT").ToString();
                string DEF_PLACECD = this.grd01_QA20121.GetValue(Row, "DEF_PLACECD").ToString();
                string DEFCD = this.grd01_QA20121.GetValue(Row, "DEFCD").ToString();
                string DEFPOSCD = this.grd01_QA20121.GetValue(Row, "DEFPOSCD").ToString();
                string INSPECT_EMPNO = this.grd01_QA20121.GetValue(Row, "INSPECT_EMPNO").ToString();

                string PLANT_DIV = this.grd01_QA20121.GetValue(Row, "PLANT_DIV").ToString();        //공장구분 추가

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.dte02_RCV_DATE.SetValue(RCV_DATE);
                this.txt02_NOTENO.SetValue(NOTENO);
                this.cdx02_VENDCD.SetValue(VENDCD);
                this.cdx02_DEF_PNO.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_DEF_PNO.HEUserParameterSetValue("VENDCD", this.cdx02_VENDCD.GetValue().ToString());
                this.cdx02_DEF_PNO.SetValue(DEF_PNO);
                this.cbo02_IMPUT_DIVCD.SetValue(IMPUT_DIVCD);
                this.txt02_VINCD_ITEMCD.SetValue(VINCD_ITEMCD);
                this.cdx02_LINECD.SetValue(LINECD);
                this.nme02_DEF_QTY.SetValue(DEF_QTY);
                this.nme02_DEF_UCOST.SetValue(DEF_UCOST);
                this.nme02_DEF_AMT.SetValue(DEF_AMT);
                this.cdx02_DEF_PLACECD.SetValue(DEF_PLACECD);
                this.cdx02_DEFCD.SetValue(DEFCD);
                this.cdx02_DEFPOSCD.SetValue(DEFPOSCD);
                this.cdx02_INSPECT_EMPNO.SetValue(INSPECT_EMPNO);

                this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);               //공장구분 추가

                IMAGE_VIEW(BIZCD, NOTENO);

                this.cbo02_BIZCD.Enabled = false;
                this.dte02_RCV_DATE.Enabled = false;
                this.cdx02_VENDCD.Enabled = false;
                this.cdx02_DEF_PNO.Enabled = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void IMAGE_VIEW(string BIZCD, string NOTENO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("NOTENO", NOTENO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                if ((dr["DEF_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _DEF_PHOTO = null;
                    _DEF_PHOTO = (byte[])(dr["DEF_PHOTO"]);
                    this.pic01_DEF_PHOTO.SetValue(_DEF_PHOTO);
                }
                else
                {
                    this.pic01_DEF_PHOTO.Initialize();
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
    }
}
