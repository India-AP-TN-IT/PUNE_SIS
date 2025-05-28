#region ▶ Description & History
/* 
 * 프로그램명 : QA20115 입고불량유효성평가결과 등록 상세
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
using System.Diagnostics;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>입고불량유효성평가결과 등록 상세</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:34:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:34:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20115 : AxCommonBaseControl
    {
        //private IQA20115 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private String _BIZCD_T;
        private String _RCV_DATE_T;
        private String _PLANT_DIV_T;
        private String _DEFNO_T;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20115";

        #region [ 초기화 작업 정의 ]

        public QA20115()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20115>("QA00", "QA20115.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _BIZCD_T = "";
            _DEFNO_T = "";
            _RCV_DATE_T = "";
            _PLANT_DIV_T = "";
        }

        public QA20115(string BIZCD, string RCV_DATE, string DEFNO, string PLANT_DIV)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20115>("QA00", "QA20115.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _BIZCD_T = BIZCD;
            _DEFNO_T = DEFNO;
            _RCV_DATE_T = RCV_DATE;
            _PLANT_DIV_T = PLANT_DIV;
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
                this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                DataSet source = this.GetTypeCode("F1", "II", "IW");
                this.cbo02_VER_4M_TYPE.DataBind(source.Tables[0], true);
                this.cbo02_VER_4M_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_VER1_CHKRSLT_TYPE.DataBind(source.Tables[1], true);
                this.cbo02_VER1_CHKRSLT_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_VER1_CHKRSLT_TYPE2.DataBind(source.Tables[2], true);
                this.cbo02_VER1_CHKRSLT_TYPE2.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source1 = new DataTable();
                combo_source1.Columns.Add("CODE");
                combo_source1.Columns.Add("NAME");
                combo_source1.Rows.Add("Y", this.GetLabel("COMPLETE"));//"완료");
                combo_source1.Rows.Add("N", this.GetLabel("NOT_COMPLETE"));//"미결");
                this.cbo02_VER2_CHKRSLT.DataBind(combo_source1);
                this.cbo02_VER2_CHKRSLT.DropDownStyle = ComboBoxStyle.DropDownList;                       
                
                DataTable combo_source2 = new DataTable();
                combo_source2.Columns.Add("CODE");
                combo_source2.Columns.Add("NAME");
                combo_source2.Rows.Add("Y", this.GetLabel("EXIST"));//"유");
                combo_source2.Rows.Add("N", this.GetLabel("NOT_EXIST"));//"무");
                this.cbo02_VER2_AMEND_RSLT.DataBind(combo_source2);
                this.cbo02_VER2_AMEND_RSLT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source3 = new DataTable();
                combo_source3.Columns.Add("CODE");
                combo_source3.Columns.Add("NAME");
                combo_source3.Rows.Add("Y", this.GetLabel("NECESSARY"));//"필요");
                combo_source3.Rows.Add("N", this.GetLabel("NOT_NECESSARY"));//"불필요");
                this.cbo02_ADD_AMEND_APPLY_YN.DataBind(combo_source3);
                this.cbo02_ADD_AMEND_APPLY_YN.DropDownStyle = ComboBoxStyle.DropDownList;  

                //this.cdx02_VER2_CHK_EMPNO.HEPopupHelper = new QASubWindow();
                //this.cdx02_VER2_CHK_EMPNO.PopupTitle = this.GetLabel("HR_EMPCD");//"사원코드";
                //this.cdx02_VER2_CHK_EMPNO.CodeParameterName = "EMPNO";
                //this.cdx02_VER2_CHK_EMPNO.NameParameterName = "EMPNONM";
                //this.cdx02_VER2_CHK_EMPNO.HEParameterAdd("CORCD", _CORCD);
                //this.cdx02_VER2_CHK_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx02_VER2_CHK_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_VER2_CHK_EMPNO.PopupTitle = this.GetLabel("HR_EMPCD");
                this.cdx02_VER2_CHK_EMPNO.CodeParameterName = "INSPECT_EMPNO";
                this.cdx02_VER2_CHK_EMPNO.NameParameterName = "INSPECT_EMPNONM";
                this.cdx02_VER2_CHK_EMPNO.HEParameterAdd("CORCD", _CORCD);                
                this.cdx02_VER2_CHK_EMPNO.HEUserParameterSetValue("BIZCD", _BIZCD_T);
                this.cdx02_VER2_CHK_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.pic02_FILE_DATA1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_FILE_DATA2.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_AFILE_DATA1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_AFILE_DATA2.SizeMode = PictureBoxSizeMode.Zoom;

                this.pic02_FILE_DATA1.ContextMenuStrip = new ContextMenuStrip();
                this.pic02_FILE_DATA2.ContextMenuStrip = new ContextMenuStrip();
                this.pic02_AFILE_DATA1.ContextMenuStrip = new ContextMenuStrip();
                this.pic02_AFILE_DATA2.ContextMenuStrip = new ContextMenuStrip();

                this.pic02_FILE_DATA1.ContextMenuStrip.Items.Add(this.GetLabel("PASTE"), null, new EventHandler(this.ImagePaste1_Click)); //붙여넣기
                this.pic02_FILE_DATA2.ContextMenuStrip.Items.Add(this.GetLabel("PASTE"), null, new EventHandler(this.ImagePaste2_Click));
                this.pic02_AFILE_DATA1.ContextMenuStrip.Items.Add(this.GetLabel("PASTE"), null, new EventHandler(this.ImagePaste3_Click));
                this.pic02_AFILE_DATA2.ContextMenuStrip.Items.Add(this.GetLabel("PASTE"), null, new EventHandler(this.ImagePaste4_Click));

                this.txt02_OCCUR_CNTT.SetValid(2000, AxTextBox.TextType.Default);
                this.txt02_AMEND_CNTT.SetValid(2000, AxTextBox.TextType.Default);
                this.txt02_VER2_CHK_DETAIL.SetValid(2000, AxTextBox.TextType.Default);

                this.lbl01_ADD_IMPROV_ACTIVITY.Value = string.Format(this.GetLabel("ADD_IMPROV_ACTIVITY_VERTICAL"));// string.Format("추가\r\n개선활동");
                this.lbl01_FIELD_CHECK.Value = string.Format(this.GetLabel("FIELD_CHECK_VERTICAL"));//string.Format("현\r\n장\r\n화\r\n점\r\n검");
                this.lbl01_MGRT_RESULT.Value = string.Format(this.GetLabel("MGRT_RESULT_VERTICAL"));//string.Format("조\r\n치\r\n결\r\n과");

                this.cbo02_PLANT_DIV.DataBindCodeName("U9",false); //2013.04.16 공장구분 조회조건 추가
                //if (_BIZCD_T.Equals("5220")) this.cbo02_PLANT_DIV.SetValue("U9A1");
                //else this.cbo02_PLANT_DIV.SetValue("U901");

                this.cbo02_PLANT_DIV.SetValue(_PLANT_DIV_T);

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

                pic02_FILE_DATA1.Initialize();
                pic02_FILE_DATA2.Initialize();
                pic02_AFILE_DATA1.Initialize();
                pic02_AFILE_DATA2.Initialize();
                this.cbo02_PLANT_DIV.SetValue(_PLANT_DIV_T);
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
                this.BtnReset_Click(null, null);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", _BIZCD_T);
                paramSet.Add("RCV_DATE", _RCV_DATE_T);
                paramSet.Add("DEFNO", _DEFNO_T);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.txt02_VER2_CHK_DETAIL.SetValue(source.Tables[0].Rows[0]["VER2_CHK_DETAIL"].ToString());
                    this.cdx02_VER2_CHK_EMPNO.SetValue(source.Tables[0].Rows[0]["VER2_CHK_EMPNO"].ToString());
                    this.cbo02_VER2_AMEND_RSLT.SetValue(source.Tables[0].Rows[0]["VER2_AMEND_RSLT"].ToString());
                    this.cbo02_VER2_CHKRSLT.SetValue(source.Tables[0].Rows[0]["VER2_CHKRSLT"].ToString());
                    this.txt02_VER2_CHK_DATE.SetValue(source.Tables[0].Rows[0]["VER2_CHK_DATE"].ToString().Replace("-", ""));
                    this.cbo02_VER1_CHKRSLT_TYPE2.SetValue(source.Tables[0].Rows[0]["VER1_CHKRSLT_TYPE2"].ToString());
                    this.cbo02_VER1_CHKRSLT_TYPE.SetValue(source.Tables[0].Rows[0]["VER1_CHKRSLT_TYPE"].ToString());
                    this.txt02_AMEND_CNTT.SetValue(source.Tables[0].Rows[0]["AMEND_CNTT"].ToString());
                    this.txt02_OCCUR_CNTT.SetValue(source.Tables[0].Rows[0]["OCCUR_CNTT"].ToString());
                    this.txt02_VER1_CHK_DATE.SetValue(source.Tables[0].Rows[0]["VER1_CHK_DATE"].ToString().Replace("-", ""));
                    this.txt02_AMEND_DATE.SetValue(source.Tables[0].Rows[0]["AMEND_DATE"].ToString().Replace("-",""));
                    this.cbo02_VER_4M_TYPE.SetValue(source.Tables[0].Rows[0]["VER_4M_TYPE"].ToString());
                    this.cbo02_ADD_AMEND_APPLY_YN.SetValue(source.Tables[0].Rows[0]["ADD_AMEND_APPLY_YN"].ToString());
                    this.txt02_ADD_AMEND_CNTT.SetValue(source.Tables[0].Rows[0]["ADD_AMEND_CNTT"].ToString());
                    this.cbo02_PLANT_DIV.SetValue(source.Tables[0].Rows[0]["PLANT_DIV"].ToString());    //공장구분 추가 2013.04.16(배명희)
                }
                this.IMAGE_VIEW(_BIZCD_T, _RCV_DATE_T, _DEFNO_T);
                //this.FILE_View();
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
                string VER2_CHK_DETAIL = this.txt02_VER2_CHK_DETAIL.GetValue().ToString();
                string VER2_RET_END_DATE = "";
                string VER2_RET_BEG_DATE = "";
                string VER2_RET_TIME = "";
                string VER2_CHK_EMPNO = this.cdx02_VER2_CHK_EMPNO.GetValue().ToString();
                string VER2_RECHKRSLT = "";
                string VER2_RECHK_DATE = "";
                string VER2_AMEND_RSLT = this.cbo02_VER2_AMEND_RSLT.GetValue().ToString();
                string VER2_CHKRSLT = this.cbo02_VER2_CHKRSLT.GetValue().ToString();
                string VER2_CHK_DATE = this.txt02_VER2_CHK_DATE.GetValue().ToString();
                string VER1_RECHKRSLT_TYPE2 = "";
                string VER1_RECHKRSLT_TYPE = "";
                string VER1_RECHK_DATE = "";
                string VER1_CHKRSLT_TYPE2 = this.cbo02_VER1_CHKRSLT_TYPE2.GetValue().ToString();
                string VER1_CHKRSLT_TYPE = this.cbo02_VER1_CHKRSLT_TYPE.GetValue().ToString();
                string AMEND_CNTT = this.txt02_AMEND_CNTT.GetValue().ToString();
                string OCCUR_CNTT = this.txt02_OCCUR_CNTT.GetValue().ToString();
                string VER1_CHK_DATE = this.txt02_VER1_CHK_DATE.GetValue().ToString();
                string AMEND_DATE = this.txt02_AMEND_DATE.GetValue().ToString();
                string VER_4M_TYPE = this.cbo02_VER_4M_TYPE.GetValue().ToString();
                string ADD_AMEND_APPLY_YN = this.cbo02_ADD_AMEND_APPLY_YN.GetValue().ToString();
                string ADD_AMEND_CNTT = this.txt02_ADD_AMEND_CNTT.GetValue().ToString();
                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString();          //공장구분 추가 2013.04.16 (배명희)

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "RCV_DATE", "DEFNO", "OCCUR_CNTT", 
                    "AMEND_CNTT", "AMEND_DATE", "VER_4M_TYPE", "VER1_CHK_DATE", "VER1_CHKRSLT_TYPE", 
                    "VER1_RECHK_DATE", "VER1_RECHKRSLT_TYPE", "VER1_CHKRSLT_TYPE2", "VER1_RECHKRSLT_TYPE2", "VER2_CHK_DATE", 
                    "VER2_CHKRSLT", "VER2_AMEND_RSLT", "VER2_RECHK_DATE", "VER2_RECHKRSLT", "VER2_RET_TIME", 
                    "VER2_RET_BEG_DATE", "VER2_RET_END_DATE", "VER2_CHK_EMPNO", "VER2_CHK_DETAIL", "BLOB$FILE_DATA1",
                    "BLOB$FILE_DATA2", "BLOB$FILE_DATA3", "BLOB$FILE_DATA4", "WORK_EMPNO",
                    "ADD_AMEND_APPLY_YN", "ADD_AMEND_CNTT", "BLOB$AFILE_DATA1", "BLOB$AFILE_DATA2", 
                    "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD, _BIZCD_T, _RCV_DATE_T, _DEFNO_T, OCCUR_CNTT, 
                    AMEND_CNTT, AMEND_DATE, VER_4M_TYPE, VER1_CHK_DATE, VER1_CHKRSLT_TYPE, 
                    VER1_RECHK_DATE, VER1_RECHKRSLT_TYPE, VER1_CHKRSLT_TYPE2, VER1_RECHKRSLT_TYPE2, VER2_CHK_DATE, 
                    VER2_CHKRSLT, VER2_AMEND_RSLT, VER2_RECHK_DATE, VER2_RECHKRSLT, VER2_RET_TIME,
                    VER2_RET_BEG_DATE, VER2_RET_END_DATE, VER2_CHK_EMPNO, VER2_CHK_DETAIL, this.pic02_FILE_DATA1.GetValue(),
                    this.pic02_FILE_DATA2.GetValue(), null, null, this.UserInfo.EmpNo,
                    ADD_AMEND_APPLY_YN, ADD_AMEND_CNTT, this.pic02_AFILE_DATA1.GetValue(), this.pic02_AFILE_DATA2.GetValue(),
                    PLANT_DIV
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("입고불량유효성평가결과 등록 상세가 저장 되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "RCV_DATE", "DEFNO");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    _BIZCD_T,
                    _RCV_DATE_T,
                    _DEFNO_T
                );

                if (!IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("입고불량유효성평가결과 등록 상세가 삭제 되었습니다.");
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

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source_Save)
        {
            try
            {
                string PLANT_DIV = this.cbo02_PLANT_DIV.GetValue().ToString(); //공장구분 항목 추가 2013.04.16 (배명희)

                //공장구분 항목 추가 2013.04.15 (배명희)
                if (this.GetByteCount(PLANT_DIV) == 0)
                {
                    //MsgBox.Show("공장구분 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("PLANT_DIV"));
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

        #region [ 기타 이벤트 정의 ]

        private void btn01_FILE_DATA1_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image files (jpg, gif, bmp, png)|*.jpg;*.gif;*.bmp;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic02_FILE_DATA1.SetValue(_PHOTO);
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

        private void btn01_FILE_DATA1_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_FILE_DATA1.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_FILE_DATA2_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image files (jpg, gif, bmp, png)|*.jpg;*.gif;*.bmp;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic02_FILE_DATA2.SetValue(_PHOTO);
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

        private void btn01_FILE_DATA2_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_FILE_DATA2.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_AFILE_DATA1_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image files (jpg, gif, bmp, png)|*.jpg;*.gif;*.bmp;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic02_AFILE_DATA1.SetValue(_PHOTO);
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

        private void btn01_AFILE_DATA1_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_AFILE_DATA1.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_AFILE_DATA2_INSERT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image files (jpg, gif, bmp, png)|*.jpg;*.gif;*.bmp;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();

                    this.pic02_AFILE_DATA2.SetValue(_PHOTO);
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

        private void btn01_AFILE_DATA2_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.pic02_AFILE_DATA2.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_FILE_DATA1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_FILE_DATA1.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_FILE_DATA1.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_FILE_DATA2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_FILE_DATA2.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_FILE_DATA2.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_AFILE_DATA1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_AFILE_DATA1.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_AFILE_DATA1.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_AFILE_DATA2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_AFILE_DATA2.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_AFILE_DATA2.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void ImagePaste1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetImage() != null && !Clipboard.GetImage().Size.IsEmpty)
                    this.pic02_FILE_DATA1.Image = Clipboard.GetImage();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void ImagePaste2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetImage() != null && !Clipboard.GetImage().Size.IsEmpty)
                    this.pic02_FILE_DATA2.Image = Clipboard.GetImage();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void ImagePaste3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetImage() != null && !Clipboard.GetImage().Size.IsEmpty)
                    this.pic02_AFILE_DATA1.Image = Clipboard.GetImage();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void ImagePaste4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetImage() != null && !Clipboard.GetImage().Size.IsEmpty)
                    this.pic02_AFILE_DATA2.Image = Clipboard.GetImage();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void txtDATE_SET(object sender, EventArgs e)
        {
            Ax.DEV.Utility.Controls.AxTextBox txt = (Ax.DEV.Utility.Controls.AxTextBox)sender;
            if (txt.GetValue().ToString().Length == 8)
            {
                DateTime CHK_DATE;

                if (DateTime.TryParse(Int32.Parse(txt.GetValue().ToString()).ToString("####-##-##"), out CHK_DATE) == false)
                {
                    txt.Focus();
                    txt.SetValue("");
                }
            }
            else if (txt.GetValue().ToString().Length != 0)
            {
                txt.Focus();
                txt.SetValue("");
            }
            else
            {
                txt.SetValue("");
            }
        }

        private void btn01_ATTACH_FILE_Click(object sender, EventArgs e)
        {
            FILE_View();
        }

        private void cdx02_VER2_CHK_EMPNO_ButtonClickBefore(object sender, EventArgs args)
        {
            ((AxCodeBox)sender).HEUserParameterSetValue("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue().ToString());
        }

        #endregion

        #region [ 사용자 정의 메서드 ] 

        private void FILE_View()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", _BIZCD_T);
                paramSet.Add("RCV_DATE", _RCV_DATE_T);
                paramSet.Add("DEFNO", _DEFNO_T);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_file_view(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_FILE_VIEW"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    if ((dr["ATT_FILE"]) != System.DBNull.Value)
                    {
                        byte[] _FILE_DATA = null;
                        _FILE_DATA = (byte[])(dr["ATT_FILE"]);

                        string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["ATT_FILE_NM"].ToString();
                        System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                        TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                        TEMP_FILE.Close();
                        TEMP_FILE.Dispose();

                        //heOfficeViewer1.SetValue(FILE_NAME);  //2013.04.29 office viewer 사용하지 않음. 
                        Process.Start(FILE_NAME);               //다운로드 파일 바로 실행
                        
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

        private void IMAGE_VIEW(string BIZCD, string RCV_DATE, string DEFNO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("DEFNO", DEFNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    if ((dr["FILE_DATA1"]) != System.DBNull.Value)
                    {
                        byte[] _FILE_DATA1 = null;
                        _FILE_DATA1 = (byte[])(dr["FILE_DATA1"]);
                        this.pic02_FILE_DATA1.SetValue(_FILE_DATA1);
                    }

                    if ((dr["FILE_DATA2"]) != System.DBNull.Value)
                    {
                        byte[] _FILE_DATA2 = null;
                        _FILE_DATA2 = (byte[])(dr["FILE_DATA2"]);
                        this.pic02_FILE_DATA2.SetValue(_FILE_DATA2);
                    }

                    if ((dr["AFILE_DATA1"]) != System.DBNull.Value)
                    {
                        byte[] _AFILE_DATA1 = null;
                        _AFILE_DATA1 = (byte[])(dr["AFILE_DATA1"]);
                        this.pic02_AFILE_DATA1.SetValue(_AFILE_DATA1);
                    }

                    if ((dr["AFILE_DATA2"]) != System.DBNull.Value)
                    {
                        byte[] _AFILE_DATA2 = null;
                        _AFILE_DATA2 = (byte[])(dr["AFILE_DATA2"]);
                        this.pic02_AFILE_DATA2.SetValue(_AFILE_DATA2);
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

        #endregion
    }
}
