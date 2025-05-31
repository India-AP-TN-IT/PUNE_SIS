#region ▶ Description & History
/* 
 * 프로그램명 : QA20051 공정순회검사일보 기준등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-29      배명희      통합WCF로 변경 
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

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>공정 순회검사일보 기준 등록</b>
    /// - 작 성 자 : 김연수<br />
    /// - 작 성 일 : 2010-08-24 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   김연수 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20051 : AxCommonBaseControl
    {
        //private IQA20051 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20051";

        #region [초기화 작업에 대한 정의]

        public QA20051()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20051>("QA02", "QA20051.svc", "CustomBinding");
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

                this.groupBox3.Text = this.GetLabel("QA20051_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20051_MSG2");

                btn01_FRT_PHOTO_INSERT.Text = this.GetLabel("PHOTO_INSERT");
                btn01_FRT_PHOTO_DELETE.Text = this.GetLabel("PHOTO_DELETE");
                btn01_RR_PHOTO_INSERT.Text = this.GetLabel("PHOTO_INSERT");
                btn01_RR_PHOTO_DELETE.Text = this.GetLabel("PHOTO_DELETE");
                btn01_ETC_3DR_PHOTO_INSERT.Text = this.GetLabel("PHOTO_INSERT");
                btn01_ETC_3DR_PHOTO_DELETE.Text = this.GetLabel("PHOTO_DELETE");

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx02_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx02_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx02_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_ITEMCD.SetCodePixedLength();

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

                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_USE_YN.DataBind(combo_source_USE_YN);
                this.cbo02_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.pic01_FRT_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_RR_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_ETC_3DR_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                                
                this.grd01_QA20051.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20051.Initialize();
                this.grd01_QA20051.AllowEditing = false;
                this.grd01_QA20051.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20051.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20051.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD", "VIN");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINTYPE", "VIN");
                this.grd01_QA20051.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "품목", "ITEMCD", "ITEM");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "품목", "ITEMTYPE", "ITEM");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "ITEMNM", "ITEMNM3");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "사진(FRT)", "FRT_PHOTO_YN", "PHOTO_FRT");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "사진(RR)", "RR_PHOTO_YN", "PHOTO_RR");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "사진(3DR)", "ETC_3DR_PHOTO_YN", "PHOTO_3DR");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "사용", "USE_YN", "USE_YN3");
                this.grd01_QA20051.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "비고", "REMARK", "REMARK");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "젹용일자", "APPLY_DATE","APP_DATE");
                this.grd01_QA20051.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "종료일자", "END_DATE", "END_DATE");
                this.grd01_QA20051.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 0, "공장구분", "PLANT_DIV");

                this.grd01_QA20051.SetColumnType(AxFlexGrid.FCellType.Date, "APPLY_DATE");
                this.grd01_QA20051.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.grd01_QA20051.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA20051.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA20051.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA20051.CurrentContextMenu.Items[3].Visible = false;

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo02_PLANT_DIV.SetReadOnly(true);

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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.dte02_END_DATE.SetValue("9998-12-31");

                pic01_FRT_PHOTO.Initialize();
                pic01_RR_PHOTO.Initialize();
                pic01_ETC_3DR_PHOTO.Initialize();

                //this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                this.cbo02_PLANT_DIV.SetValue(this.cbo01_PLANT_DIV.GetValue());
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
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx01_ITEMCD.GetValue().ToString();
                string USE_YN = this.cbo01_USE_YN.GetValue().ToString();
                string INSPECT_CLASSCD = this.txt01_INSPECT_CLASSCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("USE_YN", USE_YN);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20051.SetValue(source);
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
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD", "VINCD", "ITEMCD", "ITEMNM", "BLOB$FRT_PHOTO", "BLOB$RR_PHOTO", "BLOB$ETC_3DR_PHOTO", "USE_YN", "REMARK", "APPLY_DATE", "END_DATE","PLANT_DIV", "LANG_SET") ;
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_CLASSCD.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_ITEMCD.GetValue(),
                    this.txt02_ITEMNM.GetValue(),
                    this.pic01_FRT_PHOTO.GetValue(),
                    this.pic01_RR_PHOTO.GetValue(),
                    this.pic01_ETC_3DR_PHOTO.GetValue(),
                    this.cbo02_USE_YN.GetValue(),
                    this.txt02_REMARK.GetValue(),
                    this.dte02_APPLY_DATE.GetDateText(),
                    this.dte02_END_DATE.GetDateText(),
                    this.cbo02_PLANT_DIV.GetValue(),
                    this.UserInfo.Language
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("정상적으로 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                //MessageBox.Show(ex.Message, "error!");
                MsgBox.Show(ex.Message);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_CLASSCD.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("정상적으로 삭제 되었습니다.");
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

        private void grd01_QA20051_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(sender, e);

                int Row = this.grd01_QA20051.SelectedRowIndex;

                if (Row >= this.grd01_QA20051.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA20051.GetValue(Row, "BIZCD").ToString();
                    string INSPECT_CLASSCD = this.grd01_QA20051.GetValue(Row, "INSPECT_CLASSCD").ToString();
                    string VINCD = this.grd01_QA20051.GetValue(Row, "VINCD").ToString();
                    string ITEMCD = this.grd01_QA20051.GetValue(Row, "ITEMCD").ToString();
                    string ITEMNM = this.grd01_QA20051.GetValue(Row, "ITEMNM").ToString();
                    string USE_YN = this.grd01_QA20051.GetValue(Row, "USE_YN").ToString();
                    string REMARK = this.grd01_QA20051.GetValue(Row, "REMARK").ToString();
                    string APPLY_DATE = this.grd01_QA20051.GetValue(Row, "APPLY_DATE").ToString();
                    string END_DATE = this.grd01_QA20051.GetValue(Row, "END_DATE").ToString();
                    string PLANT_DIV = this.grd01_QA20051.GetValue(Row, "PLANT_DIV").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.txt02_INSPECT_CLASSCD.SetValue(INSPECT_CLASSCD);
                    this.cdx02_VINCD.SetValue(VINCD);
                    this.cdx02_ITEMCD.SetValue(ITEMCD);
                    this.txt02_ITEMNM.SetValue(ITEMNM);
                    this.cbo02_USE_YN.SetValue(USE_YN);
                    this.txt02_REMARK.SetValue(REMARK);
                    this.dte02_APPLY_DATE.SetValue(APPLY_DATE);
                    this.dte02_END_DATE.SetValue(END_DATE);
                    this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);

                    IMAGE_VIEW(BIZCD, INSPECT_CLASSCD);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_FRT_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _FRT_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_FRT_PHOTO, 0, _FRT_PHOTO.Length);
                    fs.Close();

                    this.pic01_FRT_PHOTO.SetValue(_FRT_PHOTO);
                }
                else
                {
                    this.pic01_FRT_PHOTO.Initialize();
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

        private void btn01_FRT_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_FRT_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_RR_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _RR_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_RR_PHOTO, 0, _RR_PHOTO.Length);
                    fs.Close();

                    this.pic01_RR_PHOTO.SetValue(_RR_PHOTO);
                }
                else
                {
                    this.pic01_RR_PHOTO.Initialize();
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

        private void btn01_RR_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_RR_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ETC_3DR_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _ETC_3DR_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_ETC_3DR_PHOTO, 0, _ETC_3DR_PHOTO.Length);
                    fs.Close();

                    this.pic01_ETC_3DR_PHOTO.SetValue(_ETC_3DR_PHOTO);
                }
                else
                {
                    this.pic01_ETC_3DR_PHOTO.Initialize();
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

        private void btn01_ETC_3DR_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_ETC_3DR_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_FRT_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_FRT_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_FRT_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_RR_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_RR_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_RR_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_ETC_3DR_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_ETC_3DR_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_ETC_3DR_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_CLASSCD = this.txt02_INSPECT_CLASSCD.GetValue().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string ITEMNM = this.txt02_ITEMNM.GetValue().ToString();
                string USE_YN = this.cbo02_USE_YN.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    //MsgBox.Show("검사유형기준코드 입력이 잘못되었습니다.(범위 : 6Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_QA_INSPECT_BASECODE.Text, "6Byte");
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_VIN.Text);
                    return false;
                }

                if (this.GetByteCount(ITEMCD) == 0)
                {
                    //MsgBox.Show("품목코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ITEM.Text);
                    return false;
                }

                if (this.GetByteCount(ITEMNM) == 0)
                {
                    //MsgBox.Show("품명코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ITEMNM3.Text);
                    return false;
                }

                if (this.GetByteCount(USE_YN) == 0)
                {
                    //MsgBox.Show("사용유무코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_USE_YN3.Text);
                    return false;
                }

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_CLASSCD = this.txt02_INSPECT_CLASSCD.GetValue().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string ITEMNM = this.txt02_ITEMNM.GetValue().ToString();
                string USE_YN = this.cbo02_USE_YN.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    //MsgBox.Show("검사유형기준코드 입력이 잘못되었습니다.(범위 : 6Byte)");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl02_QA_INSPECT_BASECODE.Text, "6Byte");
                    return false;
                }

                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

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

        private void IMAGE_VIEW(string BIZCD, string INSPECT_CLASSCD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                DataRow dr = source.Tables[0].Rows[0];

                if ((dr["FRT_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _FRT_PHOTO = null;
                    _FRT_PHOTO = (byte[])(dr["FRT_PHOTO"]);
                    this.pic01_FRT_PHOTO.SetValue(_FRT_PHOTO);
                }

                if ((dr["RR_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _RR_PHOTO = null;
                    _RR_PHOTO = (byte[])(dr["RR_PHOTO"]);
                    this.pic01_RR_PHOTO.SetValue(_RR_PHOTO);
                }

                if ((dr["ETC_3DR_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _ETC_3DR_PHOTO = null;
                    _ETC_3DR_PHOTO = (byte[])(dr["ETC_3DR_PHOTO"]);
                    this.pic01_ETC_3DR_PHOTO.SetValue(_ETC_3DR_PHOTO);
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
