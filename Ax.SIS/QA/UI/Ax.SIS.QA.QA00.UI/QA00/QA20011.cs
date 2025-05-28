#region ▶ Description & History
/* 
 * 프로그램명 : QA20011 부품별 검사코드 등록
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
    /// <b>부품별 검사코드 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-20 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-20 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20011 : AxCommonBaseControl
    {
        //private IQA20011 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20011";

        #region [ 초기화 작업 정의 ]

        public QA20011()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20011>("QA00", "QA20011.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.groupBox3.Text = this.GetLabel("QA20011_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20011_MSG2");                

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

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_ITEMCD.SetCodePixedLength();

                this.cdx02_INSPECT_CLASSNM.HEPopupHelper = new QASubWindow();
                this.cdx02_INSPECT_CLASSNM.PopupTitle = this.GetLabel("INSPECT_BASECODE");
                this.cdx02_INSPECT_CLASSNM.CodeParameterName = "INSPECT_CLASSCD_BASE";
                this.cdx02_INSPECT_CLASSNM.NameParameterName = "INSPECT_CLASSNM";
                this.cdx02_INSPECT_CLASSNM.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_INSPECT_CLASSNM.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx02_INSPECT_CLASSNM.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");
                this.cdx02_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx02_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx02_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_ITEMCD.SetCodePixedLength();

                this.cdx02_POSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_POSCD.PopupTitle = this.GetLabel("POSCODE");
                this.cdx02_POSCD.CodeParameterName = "XD_CODE";
                this.cdx02_POSCD.NameParameterName = "XD_NAME";
                this.cdx02_POSCD.HEParameterAdd("XD_CLASS", "A7");
                this.cdx02_POSCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_POSCD.HEParameterAdd("USE_YN", "");
                this.cdx02_POSCD.HEParameterAdd("GROUPCD", "");

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                //공장구분-------------------------------------------------------------------------
                DataTable source = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in source.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(source, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                //---------------------------------------------------------------------------------

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
                this.cbo02_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo02_ALWAYS_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_ALWAYS_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_ALWAYS_YN.SetValue("N");
                this.cbo02_CERTIFICATE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo02_CERTIFICATE_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_CERTIFICATE_YN.SetValue("N");

                

                this.pic01_INSPECT_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_PARTNO_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01_QA20011.AllowEditing = false;
                this.grd01_QA20011.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20011.Initialize();
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD", "VIN");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "차종", "VINTYPE", "VIN");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD", "ITEM");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품목", "ITEMTYPE", "ITEM");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "품명", "ITEMNM", "PARTNMTITLE");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "업체코드", "VENDCD", "VENDCD");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "업체명", "VENDNM", "VENDNM");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 40, "위치", "INSTALL_POS", "POS");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "위치", "INSTALL_POSTYPE", "POS");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "검사명", "INSPECT_CLASSNM", "QA_AINSPECT_CLASSNQA");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD_BASE", "QA_INSPECT_BASECODE");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "기준서", "INSPECT_STD_PHOTO_YN", "STD_REPORT");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "사진", "PARTNO_PHOTO_YN", "PHOTO");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "사용", "USE_YN", "USEYN2");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "유검사", "INSPECT_YN", "INSPECT_YN2");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 140, "상시검사", "ALWAYS_YN", "ALWAYS_YN2");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "상시검사", "ALWAYS_YNNM", "ALWAYS_YN2");
                this.grd01_QA20011.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 160, "성적서관리", "CERTIFICATE_YN", "CERTIFICATE_YN2");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "성적서관리", "CERTIFICATE_YNNM", "CERTIFICATE_YN2");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "구분", "ISBASECODE", "DIVISION");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "적용수", "CNT", "APP_CNT");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "최종발생일", "CONV_DATE", "CONV_DATE2");
                this.grd01_QA20011.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA20011.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "PLANT_DIV");
                this.grd01_QA20011.SetColumnType(AxFlexGrid.FCellType.Date, "CONV_DATE");
                this.grd01_QA20011.SetColumnType(AxFlexGrid.FCellType.Int, "CNT");
                this.grd02_VINLIST.AllowEditing = false;
                this.grd02_VINLIST.AllowDragging = AllowDraggingEnum.None;
                this.grd02_VINLIST.Initialize(false);
                this.grd02_VINLIST.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "적용차종", "FULLCODE", "VINLIST2");
                this.grd02_VINLIST.Cols[0].Visible = false;
                
                this.cbo01_USE_YN.SelectedIndex = 0;
                this.cdx02_INSPECT_CLASSNM.ReadOnly = true;

                this.SetRequired(lbl01_BIZNM2,lbl02_BIZNM2,lbl02_QA_INSPECT_BASECODE,lbl02_QA_AINSPECT_CLASSNQA,lbl02_VIN,lbl02_USEYN,lbl02_POS,lbl02_PARTNMTITLE);
                this.txt02_ITEMNM.SetValid(100,1, AxTextBox.TextType.Hangle);

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
                        if (ctl.Name.ToString() != "grd02_VINLIST")
                        {
                            ((IAxControl)ctl).Initialize();
                        }
                    }
                }

                this.cbo01_USE_YN.SetValue("Y");
            
                pic01_INSPECT_STD_PHOTO.Initialize();
                pic01_PARTNO_PHOTO.Initialize();
                this.txt02_INSPECT_CLASSNM.Visible = false;
                this.cdx02_INSPECT_CLASSNM.Visible = true;

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.cdx02_INSPECT_CLASSNM.Enabled = true;
                this.txt02_INSPECT_CLASSNM.ReadOnly = false;
                this.cdx02_VINCD.Enabled = true;

                this.grd02_VINLIST.InitializeDataSource();
                this.grd02_VINLIST.Visible = false;

                this.cdx_SETTING();


                this.cbo02_ALWAYS_YN.SetValue("N");
                this.cbo02_CERTIFICATE_YN.SetValue("N");

                this.btn01_CANCEL_1004.Visible = false;
                this.btn01_TRANS_1004.Visible = false;
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
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("USE_YN", USE_YN);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
                
                this.AfterInvokeServer();

                this.grd01_QA20011.SetValue(source);
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
                string INSPECT_CLASSNM = "";
                if (this.cdx02_INSPECT_CLASSNM.Visible == false)
                {
                    INSPECT_CLASSNM = this.txt02_INSPECT_CLASSNM.GetValue().ToString();
                }
                else
                {
                    INSPECT_CLASSNM = this.cdx02_INSPECT_CLASSNM.GetText().ToString();
                }            
                
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD", "INSPECT_CLASSNM", "BLOB$INSPECT_STD_PHOTO", "VINCD", "ITEMCD", "POSCD", "ITEMNM", "USE_YN", "BLOB$PARTNO_PHOTO", "ISBASECODE", "VENDCD","ALWAYS_YN","CERTIFICATE_YN", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_CLASSCD.GetValue(),
                    INSPECT_CLASSNM,
                    this.pic01_INSPECT_STD_PHOTO.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx02_ITEMCD.GetValue(),
                    this.cdx02_POSCD.GetValue(),
                    this.txt02_ITEMNM.GetValue(),
                    this.cbo02_USE_YN.GetValue(),
                    this.pic01_PARTNO_PHOTO.GetValue(),
                    this.cdx02_INSPECT_CLASSNM.GetValue(),
                    this.cdx02_VENDCD.GetValue(),
                    this.cbo02_ALWAYS_YN.GetValue(),
                    this.cbo02_CERTIFICATE_YN.GetValue(),
                    this.UserInfo.PlantDiv.Equals("U902") ? this.UserInfo.PlantDiv : (this.cbo02_BIZCD.GetValue().ToString().Equals("5220") ? "U9A1" : "U901")
                );

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.cbo02_BIZCD.Enabled = false;
                this.cdx02_INSPECT_CLASSNM.Enabled = false;
                this.txt02_INSPECT_CLASSNM.ReadOnly = true;
                this.cdx02_VINCD.Enabled = false;

                if (this.txt02_INSPECT_CLASSCD.GetValue().ToString() == "")
                {
                    this.BtnReset_Click(null, null);
                }

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("부품별 검사코드가 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_CLASSCD.GetValue()
                );

                if (!IsDeleteValid()) return;

                this.BeforeInvokeServer(true);
                
                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("부품별 검사코드가 삭제 되었습니다.");
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

        private void grd01_QA20011_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20011.SelectedRowIndex;

                if (Row > 0)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20011.GetValue(Row, "BIZCD").ToString();
                    string INSPECT_CLASSCD = this.grd01_QA20011.GetValue(Row, "INSPECT_CLASSCD").ToString();
                    string INSPECT_CLASSCD_BASE = this.grd01_QA20011.GetValue(Row, "INSPECT_CLASSCD_BASE").ToString();
                    string INSPECT_CLASSNM = this.grd01_QA20011.GetValue(Row, "INSPECT_CLASSNM").ToString();
                    string USE_YN = this.grd01_QA20011.GetValue(Row, "USE_YN").ToString();
                    string VINCD = this.grd01_QA20011.GetValue(Row, "VINCD").ToString();
                    string ITEMCD = this.grd01_QA20011.GetValue(Row, "ITEMCD").ToString();
                    string INSTALL_POS = this.grd01_QA20011.GetValue(Row, "INSTALL_POS").ToString();
                    string ITEMNM = this.grd01_QA20011.GetValue(Row, "ITEMNM").ToString();
                    string VENDCD = this.grd01_QA20011.GetValue(Row, "VENDCD").ToString();
                    string ISBASECODE = this.grd01_QA20011.GetValue(Row, "ISBASECODE").ToString();

                    string ALWAYS_YN = this.grd01_QA20011.GetValue(Row, "ALWAYS_YN").ToString();
                    string CERTIFICATE_YN = this.grd01_QA20011.GetValue(Row, "CERTIFICATE_YN").ToString();

                    string PLANT_DIV = this.grd01_QA20011.GetValue(Row, "PLANT_DIV").ToString(); //공장구분

                    this.cdx02_POSCD.HEUserParameterSetValue("XD_CLASS", "A7");
                    this.cdx02_POSCD.HEUserParameterSetValue("USE_YN", "");
                    this.cdx02_POSCD.HEUserParameterSetValue("GROUPCD", "");

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.txt02_INSPECT_CLASSCD.SetValue(INSPECT_CLASSCD);

                    this.txt02_INSPECT_CLASSNM.Initialize();
                    this.cdx02_INSPECT_CLASSNM.Initialize();

                    this.cdx02_INSPECT_CLASSNM.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());

                    if (INSPECT_CLASSCD_BASE == "")
                    {
                        this.cdx02_INSPECT_CLASSNM.Visible = false;
                        this.txt02_INSPECT_CLASSNM.Visible = true;

                        this.txt02_INSPECT_CLASSNM.SetValue(INSPECT_CLASSNM);
                    }
                    else
                    {
                        this.txt02_INSPECT_CLASSNM.Visible = false;
                        this.cdx02_INSPECT_CLASSNM.Visible = true;

                        this.cdx02_INSPECT_CLASSNM.SetValue(INSPECT_CLASSCD_BASE);
                    }

                    this.cbo02_BIZCD.Enabled = false;
                    this.cdx02_INSPECT_CLASSNM.Enabled = false;
                    this.txt02_INSPECT_CLASSNM.ReadOnly = true;
                    this.cdx02_VINCD.Enabled = false;

                    this.cbo02_USE_YN.SetValue(USE_YN);
                    this.cdx02_VINCD.SetValue(VINCD);
                    this.cdx02_ITEMCD.SetValue(ITEMCD);
                    this.cdx02_POSCD.SetValue(INSTALL_POS);
                    this.txt02_ITEMNM.SetValue(ITEMNM);
                    this.cdx02_VENDCD.SetValue(VENDCD);

                    this.IMAGE_VIEW(BIZCD, INSPECT_CLASSCD);

                    this.VINLIST(BIZCD, INSPECT_CLASSCD);


                    this.cbo02_ALWAYS_YN.SetValue(ALWAYS_YN);
                    this.cbo02_CERTIFICATE_YN.SetValue(CERTIFICATE_YN);

                    //평소에는 안보임                    
                    this.btn01_TRANS_1004.Visible = PLANT_DIV.Equals("U901");   //울산공장의 데이터인 경우 "두서공장으로 이관" 버튼 보이게..
                    this.btn01_CANCEL_1004.Visible = PLANT_DIV.Equals("U902") && this.UserInfo.PlantDiv.Equals("U901"); //두서공장의 데이터인 경우, 사용자가 울산공장사람이면 "이관취소" 버튼 보이게..
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

                    byte[] _INSPECT_STD_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_INSPECT_STD_PHOTO, 0, _INSPECT_STD_PHOTO.Length);
                    fs.Close();

                    this.pic01_INSPECT_STD_PHOTO.SetValue(_INSPECT_STD_PHOTO);
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
                this.pic01_INSPECT_STD_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_PARTNO_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PARTNO_PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PARTNO_PHOTO, 0, _PARTNO_PHOTO.Length);
                    fs.Close();

                    this.pic01_PARTNO_PHOTO.SetValue(_PARTNO_PHOTO);
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

        private void btn01_PARTNO_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_PARTNO_PHOTO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void btn01_VINLIST_Click(object sender, EventArgs e)
        {
            this.grd02_VINLIST.Visible = !this.grd02_VINLIST.Visible;
        }

        //이관취소
        private void btn01_CANCEL_1004_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgCodeBox.ShowFormat("QA00-035", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    //이관을 취소 처리 하시겠습니까?
                    return;
                }

                this.BeforeInvokeServer(true);

                this.TRANS_PLANT_DIV("U901");

                this.AfterInvokeServer();

                this.cbo02_BIZCD.Enabled = false;
                this.cdx02_INSPECT_CLASSNM.Enabled = false;
                this.txt02_INSPECT_CLASSNM.ReadOnly = true;
                this.cdx02_VINCD.Enabled = false;
                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0013");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        //이관
        private void btn01_TRANS_1004_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgCodeBox.ShowFormat("QA00-034", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    //두서공장으로 이관처리 하시겠습니까?
                    return;
                }


                this.BeforeInvokeServer(true);

                this.TRANS_PLANT_DIV("U902");

                this.AfterInvokeServer();

                this.cbo02_BIZCD.Enabled = false;
                this.cdx02_INSPECT_CLASSNM.Enabled = false;
                this.txt02_INSPECT_CLASSNM.ReadOnly = true;
                this.cdx02_VINCD.Enabled = false;

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0013");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void pic01_INSPECT_STD_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_INSPECT_STD_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_INSPECT_STD_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_PARTNO_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_PARTNO_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_PARTNO_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_CLASSCD = this.txt02_INSPECT_CLASSCD.GetValue().ToString();
                string INSPECT_CLASSNM = this.cdx02_INSPECT_CLASSNM.GetText().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string POSCD = this.cdx02_POSCD.GetValue().ToString();
                string ITEMNM = this.txt02_ITEMNM.GetValue().ToString();
                string USE_YN = this.cbo02_USE_YN.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZCD"));
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(INSPECT_CLASSCD) == 0 && this.GetByteCount(INSPECT_CLASSNM) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("QA_AINSPECT_CLASSNQA"));
                    //MsgBox.Show("검사명이 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("VINCD"));
                    //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(ITEMCD) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("ITEMCD"));
                    //MsgBox.Show("품목코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(POSCD) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("POSCD"));
                    //MsgBox.Show("위치코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(ITEMNM) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("PARTNMTITLE") +"CODE");
                    //MsgBox.Show("품명코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(USE_YN) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("USE_YN3"));
                    //MsgBox.Show("사용유무코드가 입력되지 않았습니다.");
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

        private bool IsDeleteValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_CLASSCD = this.txt02_INSPECT_CLASSCD.GetValue().ToString();
                string INSPECT_CLASSNM = this.cdx02_INSPECT_CLASSNM.GetText().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string ITEMCD = this.cdx02_ITEMCD.GetValue().ToString();
                string POSCD = this.cdx02_POSCD.GetValue().ToString();
                string ITEMNM = this.txt02_ITEMNM.GetValue().ToString();
                string USE_YN = this.cbo02_USE_YN.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZCD"));
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(INSPECT_CLASSCD) != 6)
                {
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("QA_INSPECT_BASECODE"), "6Byte");
                    //MsgBox.Show("검사코드 입력이 잘못되었습니다.(범위 : 6Byte)");
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                this.cdx02_INSPECT_CLASSNM.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx02_POSCD.HEUserParameterSetValue("XD_CLASS", "A7");
                this.cdx02_POSCD.HEUserParameterSetValue("USE_YN", "");
                this.cdx02_POSCD.HEUserParameterSetValue("GROUPCD", "");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void VINLIST(string BIZCD, string INSPECT_CLASSCD)
        {
            if (this.GetByteCount(INSPECT_CLASSCD) != 0)
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                //DataSet source = _WSCOM.Inquery_VINLIST(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VINLIST"), paramSet);
                this.grd02_VINLIST.SetValue(source);
            }
        }

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

                if ((dr["INSPECT_STD_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _INSPECT_STD_PHOTO = null;
                    _INSPECT_STD_PHOTO = (byte[])(dr["INSPECT_STD_PHOTO"]);
                    this.pic01_INSPECT_STD_PHOTO.SetValue(_INSPECT_STD_PHOTO);
                }

                if ((dr["PARTNO_PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _PARTNO_PHOTO = null;
                    _PARTNO_PHOTO = (byte[])(dr["PARTNO_PHOTO"]);
                    this.pic01_PARTNO_PHOTO.SetValue(_PARTNO_PHOTO);
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

        //공장구분 update
        private void TRANS_PLANT_DIV(string plant_div)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                set.Add("INSPECT_CLASSCD", txt02_INSPECT_CLASSCD.GetValue());
                set.Add("PLANT_DIV", plant_div);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "TRANS_PLANT_DIV"), set);
            }            
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion
                

    }
}
