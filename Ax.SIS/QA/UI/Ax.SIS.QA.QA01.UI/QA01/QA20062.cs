#region ▶ Description & History
/* 
 * 프로그램명 : BIW 내역관리
 * 설     명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 2017-06-15
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2017-06-15	    배명희		신규 개발
 *              2017-07-06      배명희       "비고"항목 추가.
 *				2017-09-22      배명희       체크박스 기본값 날짜조건사용 안함. 
 * 
*/
#endregion

using System;
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
using System.IO;
using HE.Framework.ServiceModel;
using System.Diagnostics;

namespace Ax.SIS.QA.QA01.UI
{

    public partial class QA20062 : AxCommonBaseControl
    {        
        private string _SEQNO = string.Empty;

        private FileInfo _TakeOverDocFileInfo;
        private FileInfo _BodyPhotoFileInfo;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20062";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20062()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.BeforeInvokeServer(true);
   
                DataSet source = this.GetTypeCode("QJ", "QK", "QL", "A3");
                //[0] QJ : BODY_TYPE
                //[1] QK : BODY_STATUS
                //[2] QL : BODY_USEYN
                //[3] A3 : 차종
                //--바디상태
                this.cbo01_BODY_STATUS.DataBind(source.Tables[1]);
                this.cbo02_BODY_STATUS.DataBind(source.Tables[1]);
                this.cbo01_BODY_STATUS.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BODY_STATUS.DropDownStyle = ComboBoxStyle.DropDownList;
                //--바디타입
                this.cbo01_BODY_TYPE.DataBind(source.Tables[0]);
                this.cbo02_BODY_TYPE.DataBind(source.Tables[0]);
                this.cbo01_BODY_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BODY_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                //--사용여부
                this.cbo01_BODY_USEYN.DataBind(source.Tables[2]);
                this.cbo02_BODY_USEYN.DataBind(source.Tables[2]);
                this.cbo01_BODY_USEYN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BODY_USEYN.DropDownStyle = ComboBoxStyle.DropDownList;

                //--양산법인,사업장
                HEParameterSet paramSet_CORCD = new HEParameterSet();
                paramSet_CORCD.Add("LANG_SET", this.UserInfo.Language);
                DataSet source_CORCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CORCD"), paramSet_CORCD);
                this.cbo01_PROD_CORCD.DataBind(source_CORCD.Tables[0]);
                this.cbo02_PROD_CORCD.DataBind(source_CORCD.Tables[0]);
                this.cbo01_PROD_CORCD.SelectedValueChanged += new EventHandler(cbo01_PROD_CORCD_SelectedValueChanged);
                this.cbo02_PROD_CORCD.SelectedValueChanged += new EventHandler(cbo02_PROD_CORCD_SelectedValueChanged);
                this.cbo01_PROD_CORCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_PROD_CORCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_PROD_CORCD.SetValue(string.Empty);
                this.cbo02_PROD_CORCD.SetValue(string.Empty);

                HEParameterSet paramSet_BIZCD = new HEParameterSet();
                paramSet_BIZCD.Add("CORCD", string.Empty);
                paramSet_BIZCD.Add("LANG_SET", this.UserInfo.Language);
                DataSet source_BIZCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_BIZCD"), paramSet_BIZCD);
                this.cbo01_PROD_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_PROD_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                
               // _QUALIFICATION = new AttachFile();  //#002                                
                this._buttonsControl.BtnPrint.Visible = false;                
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                //--차종
                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_VINCD.SetCodePixedLength();

                //--바디사진
                this.pic01_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.txt02_HIDDEN_BODY_PHOTO_CHANGE_YN.SetValue("N");
                this.txt02_HIDDEN_BODY_PHOTO_FILEID.SetValue("");

                //인수인계서
                this.txt02_HIDDEN_TAKE_OVER_DOC_CHANGE_YN.SetValue("N");
                this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.SetValue("");

                //--보관위치
                HEParameterSet paramSet_BODY_LOCATION = new HEParameterSet();
                paramSet_BODY_LOCATION.Add("LANG_SET", this.UserInfo.Language);
                DataSet source_BODY_LOCATION = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_BODY_LOCATION"), paramSet_BODY_LOCATION);
                this.cbo01_BODY_LOCATION.DataBind(source_BODY_LOCATION.Tables[0]);
                this.cbo01_BODY_LOCATION.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BODY_LOCATION.DataBind(source_BODY_LOCATION.Tables[0]);
                this.cbo02_BODY_LOCATION.DropDownStyle = ComboBoxStyle.DropDownList;


                //--캐스터 장착 여부
                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo02_CASTER_INST_YN.DataBind(combo_source_USE_YN);
                this.cbo02_CASTER_INST_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                

                //날짜
                this.chk01_USE_IN_DATE.Checked = false;
                this.dte01_IN_DATE_FROM.SetMMFromStart();
                this.dte01_IN_DATE_TO.SetMMFromStart();
                this.dte02_IN_DATE.SetMMFromStart();
                this.dte02_OUT_PLAN_DATE.SetMMFromStart();
                this.chk01_USE_IN_DATE_CheckedChanged(null, null);

                //BODYNO
                this.txt01_BODYNO.SetValid(30, AxTextBox.TextType.UAlphabet);
                this.txt02_BODYNO.SetValid(30, AxTextBox.TextType.UAlphabet);

                this.txt02_BODY_CHARGE_NM.SetValue(this.UserInfo.UserName);
                
                this.txt02_TAKE_OVER_DOC_FILEID.SetReadOnly(true);

                this.AfterInvokeServer();


                #region [BIW 내역 목록 그리드]
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 110, "SEQNO", "SEQNO", "SEQNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "차종", "VINCD", "VEHICLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "B/NO", "BODYNO", "BODYNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "B/TYPE", "BODY_TYPE", "BODY_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "바디상태", "BODY_STATUS", "BODY_STATUS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "보관위치", "BODY_LOCATION", "BODY_LOC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "양산법인", "PROD_CORCD", "PROD_CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "양산사업장", "PROD_BIZCD", "PROD_BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "사용여부", "BODY_USEYN", "BODY_USEYN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "캐스터장착여부", "CASTER_INST_YN", "CASTER_INST_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "입고담당자", "BODY_CHARGE_NM", "RCV_EMPNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "입고일자", "IN_DATE", "RCV_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "출고예정일", "OUT_PLAN_DATE", "OUT_PLAN_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "인수인계서", "TAKE_OVER_DOC_YN", "TAKE_OVER_DOC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "비고", "REMARK", "NOTE");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 160, "인수인계서", "TAKE_OVER_DOC", "TAKE_OVER_DOC");                
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 090, "인수인계서", "TAKE_OVER_DOC_FILEID", "TAKE_OVER_DOC");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 160, "바디사진", "BODY_IMAGE_FILEID", "BODY_IMAGE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OUT_PLAN_DATE");

                //[0] QJ : BODY_TYPE
                //[1] QK : BODY_STATUS
                //[2] QL : BODY_USEYN
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "BODY_TYPE");
                this.grd01.Cols["BODY_TYPE"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "BODY_STATUS");
                this.grd01.Cols["BODY_STATUS"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[2], "BODY_USEYN");
                this.grd01.Cols["BODY_USEYN"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_BODY_LOCATION.Tables[0], "BODY_LOCATION");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[3], "VINCD");
                this.grd01.Cols["VINCD"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_CORCD.Tables[0], "PROD_CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source_BIZCD.Tables[0], "PROD_BIZCD");


                #endregion


                #region [보관위치 변경이력 그리드]
                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "변경일시", "MOVE_TIMESTAMP", "MOVE_TIMESTAMP");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "보관위치", "BODY_LOCATION_NM", "BODY_LOC");
                #endregion


                this.SetRequired(lbl02_VEHICLE, lbl02_BODYNO, lbl02_BODY_LOCATION, lbl02_BODY_USEYN, lbl02_CASTER_INST_YN);
                
               
                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctl in grp01_QA20062_GRP2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
                //수동 초기화 처리
                this.cbo02_PROD_CORCD.SelectedIndex = 0;

                this.txt02_BODY_CHARGE_NM.SetValue(this.UserInfo.UserName);
                
                this._SEQNO = string.Empty;
                
                this._TakeOverDocFileInfo = null;
                this.txt02_HIDDEN_TAKE_OVER_DOC_CHANGE_YN.SetValue("N");
                this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.Initialize();
                
                this._BodyPhotoFileInfo = null;
                this.txt02_HIDDEN_BODY_PHOTO_CHANGE_YN.SetValue("N");                
                this.txt02_HIDDEN_BODY_PHOTO_FILEID.Initialize();
                
                this.SetTakeOverDocButton(true);

                this.pic01_PHOTO.Initialize();

                this.grd02.InitializeDataSource();                
                
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
                string VINCD_NM = this.txt01_VINCDNM.GetValue().ToString();
                string BODYNO = this.txt01_BODYNO.GetValue().ToString();
                string BODY_TYPE = this.cbo01_BODY_TYPE.GetValue().ToString();
                string BODY_STATUS = this.cbo01_BODY_STATUS.GetValue().ToString();
                string BODY_LOCATION = this.cbo01_BODY_LOCATION.GetValue().ToString();
                string PROD_CORCD = this.cbo01_PROD_CORCD.GetValue().ToString();
                string PROD_BIZCD = this.cbo01_PROD_BIZCD.GetValue().ToString();
                string BODY_USEYN = this.cbo01_BODY_USEYN.GetValue().ToString();
                string IN_DATE_FROM = this.dte01_IN_DATE_FROM.GetDateText().ToString();
                string IN_DATE_TO = this.dte01_IN_DATE_TO.GetDateText().ToString();
                string USE_IN_DATE = this.chk01_USE_IN_DATE.Checked ? "Y" : "N";

                HEParameterSet paramSet = new HEParameterSet();
                
                paramSet.Add("VINCD_NM", VINCD_NM);
                paramSet.Add("BODYNO", BODYNO);
                paramSet.Add("BODY_TYPE", BODY_TYPE);
                paramSet.Add("BODY_STATUS", BODY_STATUS);
                paramSet.Add("BODY_LOCATION", BODY_LOCATION);
                paramSet.Add("PROD_CORCD", PROD_CORCD);
                paramSet.Add("PROD_BIZCD", PROD_BIZCD);
                paramSet.Add("BODY_USEYN", BODY_USEYN);
                paramSet.Add("USE_IN_DATE", USE_IN_DATE);
                paramSet.Add("IN_DATE_FROM", IN_DATE_FROM);
                paramSet.Add("IN_DATE_TO", IN_DATE_TO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);
                this.BtnReset_Click(null, null);
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
                string LocalFileFullPath = string.Empty;
                
                string TakeOverDocFileId = string.Empty;
                string BodyPhotoFileId = string.Empty;


                //만약 한번이라도 변경되었다면
                if (this.txt02_HIDDEN_TAKE_OVER_DOC_CHANGE_YN.GetValue().ToString().Equals("Y"))
                {
                    if (this._TakeOverDocFileInfo != null) // 신규파일이 존재한다면 삭제 후 업로드
                    {
                        LocalFileFullPath = this._TakeOverDocFileInfo.FullName;                        
                        TakeOverDocFileId = RemoteFileHandler.FileUpload(LocalFileFullPath, 
                                                                        this.Name, 
                                                                        this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.GetValue().ToString());
                    }
                    else
                    {  
                        //없으면 그냥 삭제
                        RemoteFileHandler.FileRemove(this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.GetValue().ToString());
                    }
                }
                else
                {
                    TakeOverDocFileId = this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.GetValue().ToString(); 
                }



                //만약 한번이라도 변경되었다면
                if (this.txt02_HIDDEN_BODY_PHOTO_CHANGE_YN.GetValue().ToString().Equals("Y"))
                {
                    if (this._BodyPhotoFileInfo != null) // 신규파일이 존재한다면 삭제 후 업로드
                    {
                        LocalFileFullPath = this._BodyPhotoFileInfo.FullName;                        
                        BodyPhotoFileId = RemoteFileHandler.FileUpload(LocalFileFullPath, this.Name, this.txt02_HIDDEN_BODY_PHOTO_FILEID.GetValue().ToString());
                    }
                    else
                    {
                        //없으면 그냥 삭제
                        RemoteFileHandler.FileRemove(this.txt02_HIDDEN_BODY_PHOTO_FILEID.GetValue().ToString());
                    }
                }
                else
                {
                    BodyPhotoFileId = this.txt02_HIDDEN_BODY_PHOTO_FILEID.GetValue().ToString();
                }

                    

                //DataSet source = AxFlexGrid.GetDataSourceSchema("SEQNO", "VINCD", "BODYNO", "BODY_TYPE", "BODY_STATUS", "BODY_LOCATION",
                //                                                "PROD_CORCD", "PROD_BIZCD", "BODY_USEYN", "CASTER_INST_YN", "BODY_CHARGE_NM",
                //                                                "IN_DATE", "OUT_PLAN_DATE", "BODY_IMAGE_FILEID", "TAKE_OVER_DOC_FILEID",
                //                                                "USERID");  
                //source.Tables[0].Rows.Add(
                //    _SEQNO,
                //    this.cdx02_VINCD.GetValue(),
                //    this.txt02_BODYNO.GetValue(),
                //    this.cbo02_BODY_TYPE.GetValue(),
                //    this.cbo02_BODY_STATUS.GetValue(),
                //    this.cbo02_BODY_LOCATION.GetValue(),
                //    this.cbo02_PROD_CORCD.GetValue(),
                //    this.cbo02_PROD_BIZCD.GetValue(),
                //    this.cbo02_BODY_USEYN.GetValue(),
                //    this.cbo02_CASTER_INST_YN.GetValue(),
                //    this.txt02_BODY_CHARGE_NM.GetValue(),                    
                //    this.dte02_IN_DATE.GetValue(),         
                //    this.dte02_OUT_PLAN_DATE.GetValue(),
                //    BodyPhotoFileId,
                //    TakeOverDocFileId,
                //    this.UserInfo.UserID
                //);

                HEParameterSet source = new HEParameterSet();
                source.Add("SEQNO", _SEQNO);
                source.Add("VINCD", this.cdx02_VINCD.GetValue());
                source.Add("BODYNO", this.txt02_BODYNO.GetValue());
                source.Add("BODY_TYPE", this.cbo02_BODY_TYPE.GetValue());
                source.Add("BODY_STATUS", this.cbo02_BODY_STATUS.GetValue());
                source.Add("BODY_LOCATION", this.cbo02_BODY_LOCATION.GetValue());
                source.Add("PROD_CORCD", this.cbo02_PROD_CORCD.GetValue());
                source.Add("PROD_BIZCD", this.cbo02_PROD_BIZCD.GetValue());
                source.Add("BODY_USEYN", this.cbo02_BODY_USEYN.GetValue());
                source.Add("CASTER_INST_YN", this.cbo02_CASTER_INST_YN.GetValue());
                source.Add("BODY_CHARGE_NM", this.txt02_BODY_CHARGE_NM.GetValue());
                source.Add("IN_DATE", this.dte02_IN_DATE.GetDateText());
                source.Add("OUT_PLAN_DATE", this.dte02_OUT_PLAN_DATE.GetDateText());
                source.Add("BODY_IMAGE_FILEID", BodyPhotoFileId);
                source.Add("TAKE_OVER_DOC_FILEID", TakeOverDocFileId);
                source.Add("USERID", this.UserInfo.UserID);
                source.Add("REMARK", this.txt02_REMARK.GetValue());

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);
                               
                DataSet result = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                string seqno = result.Tables[0].Rows[0][0].ToString();
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this._SEQNO = seqno;
                this.QueryDetail(seqno);
               
                //MsgBox.Show("저장되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("SEQNO");
                source.Tables[0].Rows.Add(
                    _SEQNO
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //인수인계서 파일 삭제
                if (!string.IsNullOrEmpty(this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.GetValue().ToString()))
                    RemoteFileHandler.FileRemove(this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.GetValue().ToString());

                //바디사진 삭제
                if (!string.IsNullOrEmpty(this.txt02_HIDDEN_BODY_PHOTO_FILEID.GetValue().ToString()))
                    RemoteFileHandler.FileRemove(this.txt02_HIDDEN_BODY_PHOTO_FILEID.GetValue().ToString()); 


                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("삭제 되었습니다.");
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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void cbo02_PROD_CORCD_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = this.cbo02_PROD_CORCD.GetValue().ToString();
            
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", val.Equals(string.Empty) ? "XXX" : val);
            paramSet.Add("LANG_SET", this.UserInfo.Language);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_BIZCD"), paramSet);

            this.cbo02_PROD_BIZCD.DataBind(source.Tables[0]);
        }

        private void cbo01_PROD_CORCD_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = this.cbo01_PROD_CORCD.GetValue().ToString();

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", val.Equals(string.Empty) ? "XXX" : val);
            paramSet.Add("LANG_SET", this.UserInfo.Language);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_BIZCD"), paramSet);


            this.cbo01_PROD_BIZCD.DataBind(source.Tables[0]);
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01.SelectedRowIndex;

                if (Row >= this.grd01.Rows.Fixed)
                {
                    this._SEQNO = this.grd01.GetValue(Row, "SEQNO").ToString();
                    this.QueryDetail(this.grd01.GetValue(Row, "SEQNO").ToString());
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_USE_IN_DATE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_USE_IN_DATE.Checked == true)
            {
                this.dte01_IN_DATE_FROM.SetReadOnly(false);
                this.dte01_IN_DATE_TO.SetReadOnly(false);
            }
            else
            {
                this.dte01_IN_DATE_FROM.SetReadOnly(true);
                this.dte01_IN_DATE_TO.SetReadOnly(true);
            }

        }
        #endregion

        #region [사용자 정의 method]

        private void QueryDetail(string seqno)
        {
            try
            {

                HEParameterSet set = new HEParameterSet();
                set.Add("SEQNO", seqno);
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM_N.MultipleExecuteDataSet(new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"),
                                                                                string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_HISTORY")},
                                                                 new System.Collections.Generic.List<HEParameterSet> { set, set });

                if (source.Tables[0].Rows.Count > 0)
                {

                    DataRow dr = source.Tables[0].Rows[0];
                    
                    this.cdx02_VINCD.SetValue(dr["VINCD"]);
                    this.txt02_BODYNO.SetValue(dr["BODYNO"]);
                    this.cbo02_BODY_TYPE.SetValue(dr["BODY_TYPE"]);
                    this.cbo02_BODY_STATUS.SetValue(dr["BODY_STATUS"]);
                    this.cbo02_BODY_LOCATION.SetValue(dr["BODY_LOCATION"]);
                    this.cbo02_PROD_CORCD.SetValue(dr["PROD_CORCD"]);
                    this.cbo02_PROD_BIZCD.SetValue(dr["PROD_BIZCD"]);
                    this.cbo02_BODY_USEYN.SetValue(dr["BODY_USEYN"]);
                    this.cbo02_CASTER_INST_YN.SetValue(dr["CASTER_INST_YN"]);
                    this.txt02_BODY_CHARGE_NM.SetValue(dr["BODY_CHARGE_NM"]);
                    this.dte02_IN_DATE.SetValue(dr["IN_DATE"]);
                    this.dte02_OUT_PLAN_DATE.SetValue(dr["OUT_PLAN_DATE"]);

                    this.txt02_HIDDEN_BODY_PHOTO_FILEID.SetValue(dr["BODY_IMAGE_FILEID"]);
                    this.txt02_HIDDEN_BODY_PHOTO_CHANGE_YN.SetValue("N");

                    this.txt02_TAKE_OVER_DOC_FILEID.SetValue(dr["TAKE_OVER_DOC"]);
                    this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.SetValue(dr["TAKE_OVER_DOC_FILEID"]);
                    this.txt02_HIDDEN_TAKE_OVER_DOC_CHANGE_YN.SetValue("N");

                    this.txt02_REMARK.SetValue(dr["REMARK"]);

                    if (!this.txt02_HIDDEN_BODY_PHOTO_FILEID.IsEmpty)
                    {
                        RemoteFileInfo file = RemoteFileHandler.FileDownload(this.txt02_HIDDEN_BODY_PHOTO_FILEID.GetValue().ToString());
                        if (file != null)
                            this.pic01_PHOTO.SetValue(file.FileContent);
                    }
                    else
                    {
                        this.pic01_PHOTO.Initialize();
                    }

                    if (this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.IsEmpty)
                    {
                        this.SetTakeOverDocButton(true);

                    }
                    else
                    {
                        this.SetTakeOverDocButton(false);
                    }

                    this.grd02.SetValue(source.Tables[1]);
                }
                else
                {
                    this.BtnReset_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void SetTakeOverDocButton(bool fileSelectable)
        {
            this.btn02_TAKE_OVER_DOC_DWN.SetReadOnly(fileSelectable);
            this.btn02_TAKE_OVER_DOC_REG.SetReadOnly(!fileSelectable);
            this.btn02_TAKE_OVER_DOC_REM.SetReadOnly(fileSelectable);   
        }

        #endregion

        #region [인수인계서 관련]

        //#002
        private void btn02_TAKE_OVER_DOC_REG_Click(object sender, EventArgs e)
        {
            FileStream stream = null;
            try
            {
                
                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.Cancel) return;

                
                string filename = ofd.FileName;
                this.txt02_TAKE_OVER_DOC_FILEID.SetValue(filename);

                this.txt02_HIDDEN_TAKE_OVER_DOC_CHANGE_YN.SetValue("Y");
                this._TakeOverDocFileInfo = new FileInfo(ofd.FileNames[0]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        //#002
        private void btn02_TAKE_OVER_DOC_REM_Click(object sender, EventArgs e)
        {
            try
            {   
                this.txt02_TAKE_OVER_DOC_FILEID.Initialize();
                this.txt02_HIDDEN_TAKE_OVER_DOC_CHANGE_YN.SetValue("Y");
                
                this._TakeOverDocFileInfo = null;
                this.SetTakeOverDocButton(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //#002
        private void btn02_TAKE_OVER_DOC_DWN_Click(object sender, EventArgs e)
        {
            try
            {

                string fileid = this.txt02_HIDDEN_TAKE_OVER_DOC_FILEID.GetValue().ToString();
                RemoteFileInfo file = RemoteFileHandler.FileDownload(fileid);
                file.Save();
                Process.Start(file.LocalFilePath);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion


        #region [유효성 검사]

        private bool IsSaveValid()
        {
            string VINCD = this.cdx02_VINCD.GetValue().ToString();
            string BNO = this.txt02_BODYNO.GetValue().ToString();
            string BODY_LOCATION = this.cbo02_BODY_LOCATION.GetValue().ToString();
            string BODY_USEYN = this.cbo02_BODY_USEYN.GetValue().ToString();
            string CASTER_INST_YN = this.cbo02_CASTER_INST_YN.GetValue().ToString();
           

            if (this.GetByteCount(VINCD) == 0)
            {
                //MsgBox.Show("차종 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("VEHICLE"));
                return false;
            }

            if (this.GetByteCount(BNO) == 0)
            {
                //MsgBox.Show("바디번호 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BODYNO.Text);
                return false;
            }

            if (this.GetByteCount(BODY_LOCATION) == 0)
            {
                //MsgBox.Show("보관위치 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BODY_LOCATION.Text);
                return false;
            }


            if (this.GetByteCount(BODY_USEYN) == 0)
            {
                //MsgBox.Show("사용여부 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BODY_USEYN.Text);
                return false;
            }

            if (this.GetByteCount(CASTER_INST_YN) == 0)
            {
                //MsgBox.Show("캐스터장착여부 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CASTER_INST_YN.Text);
                return false;
            }
                    

            if (this.GetByteCount(BNO) > 30) //10->11
            {
                //MsgBox.Show("인증번호코드 입력이 잘못되었습니다.(범위 : 1~11Byte)");
                MsgCodeBox.ShowFormat("QA00-002", this.lbl02_BODYNO.Text, "1~30 Byte");
                return false;
            }

            try
            {
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


            if (this.GetByteCount(_SEQNO) == 0)
            {
                //삭제할 데이터를 선택 하지 않았습니다.
                MsgCodeBox.Show("QA01-0015");
                return false;
            }

            try
            {
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
        
        #region [바디 사진 관련]
        
        private void btn01_PHOTO_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "IMAGE");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic01_PHOTO.SetValue(_PHOTO);

                    this.txt02_HIDDEN_BODY_PHOTO_CHANGE_YN.SetValue("Y");
                    this._BodyPhotoFileInfo = new FileInfo(file.FileNames[0]);

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

        private void btn01_PHOTO_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic01_PHOTO.Initialize();
                this.txt02_HIDDEN_BODY_PHOTO_CHANGE_YN.SetValue("Y");
                this._BodyPhotoFileInfo = null;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic01_PHOTO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic01_PHOTO.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic01_PHOTO.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
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
