#region ▶ Description & History
/* 
 * 프로그램명 : 검사원 자격 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : ㅂ명희
 * 최종수정일 : 2013-12-10
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2013-12-10	    배명희		[#001] 인증일자, 갱신일자 항목 변경 -> 등록일자, 승인/갱신일자, 승인대상년도, 승인만료일자, 차기갱신일자
 *				                                   인증번호 자동 생성 로직 추가, 사번 중복 입력 체크 로직 추가
 *				2014-06-17      배명희      [#002] 검사자 자격검정 기록서(QUALIFICATION) 항목 추가 및 컬럼 명칭 변경(자격평가서-> 이론평가, Gauge RR-> 실기평가)
 *              2015-07-27      배명희      통합WCF로 변경 
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

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>검사원 자격 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 7:20:43<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 7:20:43   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20036 : AxCommonBaseControl
    {
        //private IQA20036 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;
        private String _LANG_SET;
        private AttachFile _REPORTNO;
        private AttachFile _GGRNR;
        private AttachFile _QUALIFICATION;  //#002

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20036";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20036()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20036>("QA01", "QA20036.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //#001 - 승인여부 콤보상자 데이터바인딩(1:YES, 0:NO)
                DataSet source = this.GetTypeCode("C6");
                source.Tables[0].Columns["TYPECD"].SetOrdinal(0);
                source.Tables[0].Columns["OBJECT_NM"].SetOrdinal(1);
                cbo01_APPROVE_YN.DataBind(source.Tables[0]);


                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;
                _REPORTNO = new AttachFile();
                _GGRNR = new AttachFile();
                _QUALIFICATION = new AttachFile();  //#002

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(_CORCD).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(_CORCD).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cdx02_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("INSPECTOR_LINECD");// "검사원라인코드";
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.pic01_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;


                //공장구분-------------------------------------------------------------------------
                DataTable source2 = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in source2.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(source2, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.cbo02_PLANT_DIV.DataBind(source2, false);
                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo02_PLANT_DIV.SetReadOnly(true);

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

                HEParameterSet paramSet_LICENSECD = new HEParameterSet();
                paramSet_LICENSECD.Add("CORCD", _CORCD);
                paramSet_LICENSECD.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);
                //DataSet source_LICENSECD = _WSCOMBOBOX.Inquery_LICENSECD(paramSet_LICENSECD);
                DataSet source_LICENSECD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_LICENSECD"), paramSet_LICENSECD);
                this.cbo01_LICENSECD.DataBind(source_LICENSECD.Tables[0]);
                this.cbo01_LICENSECD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_LICENSECD.DataBind(source_LICENSECD.Tables[0]);
                this.cbo02_LICENSECD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.AfterInvokeServer();

                this.grd01_QA20036.AllowEditing = false;
                this.grd01_QA20036.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20036.Initialize();
                this.grd01_QA20036.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 110, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20036.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 110, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사원사번", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "인증번호", "CERTNO", "CERTNO");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "등록일자", "CERT_DATE", "REG_DATE");              //#001
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "승인/갱신일자", "RENEWAL_DATE", "RENEWAL_DATE");      //#001
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "승인대상년도", "CERT_YEAR", "CERT_YEAR");          //#001
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "승인 만료일자", "RENEW_DATE", "ACC_EXP_DATE");         //#001
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "차기 갱신일자", "NEXT_RENEWAL_DATE", "NEXT_RENEWAL_DATE");  //#001
                this.grd01_QA20036.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "자격코드", "LICENSECD", "LICENSECD");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "자격명", "LICENSENM", "LICENSENM");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "경력", "CARRIER", "CARRIER");
                this.grd01_QA20036.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 090, "소속", "DEPT", "DEPTNM");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "소속", "DEPTNM", "DEPTNM");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사원", "INSPECT_EMPNM", "INSPECT_EMPNM");
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "입사일자", "JOIN_COMP_DATE", "JOIN_COMP_DATE");              //#001
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "검사자 자격검정 기록서", "QUALIFICATION", "QUALIFICATION");    //#002
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "이론평가", "REPORTNO", "EVALUATE_BOOK");                       //#002
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "실기평가", "GGRNR", "EVALUATE_EXEC");                          //#002
                this.grd01_QA20036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "사진", "PHOTO", "PHOTO");                          //#002

                this.grd01_QA20036.SetColumnType(AxFlexGrid.FCellType.Date, "CERT_DATE");
                this.grd01_QA20036.SetColumnType(AxFlexGrid.FCellType.Date, "RENEWAL_DATE");
                this.grd01_QA20036.SetColumnType(AxFlexGrid.FCellType.Date, "RENEW_DATE");
                this.grd01_QA20036.SetColumnType(AxFlexGrid.FCellType.Date, "NEXT_RENEWAL_DATE");
                this.grd01_QA20036.SetColumnType(AxFlexGrid.FCellType.Date, "JOIN_COMP_DATE");
                

                this.SetRequired(lbl01_BIZNM, lbl02_BIZNM, lbl02_INSPECT_EMPNO, lbl02_LICENCE_NM, lbl02_CERTNO, lbl02_REG_DATE, lbl02_LINECD, lbl02_INSPECT_EMPNM, lbl02_JOIN_COMP_DATE);
                
                this.txt02_CERTNO.SetValid(11, AxTextBox.TextType.UAlphabet);   //2013.11.21 10->11로 변경

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
                foreach (Control ctl in groupBox_QA20036_MSG2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo02_PLANT_DIV.SetReadOnly(true);

                this.txt02_INSPECT_EMPNO.Enabled = true;
                this.cbo02_LICENSECD.Enabled = true;

                this.btn02_GGRNR_DWN.SetReadOnly(true);
                this.btn02_GGRNR_REG.SetReadOnly(false);
                this.btn02_GGRNR_REM.SetReadOnly(true);
                this.btn02_REPORTNO_DWN.SetReadOnly(true);
                this.btn02_REPORTNO_REG.SetReadOnly(false);
                this.btn02_REPORTNO_REM.SetReadOnly(true);
                this.btn02_QUALIFICATION_DWN.SetReadOnly(true);     //#002
                this.btn02_QUALIFICATION_REG.SetReadOnly(false);    //#002
                this.btn02_QUALIFICATION_REM.SetReadOnly(true);     //#002
                _REPORTNO.Clear();
                _GGRNR.Clear();
                _QUALIFICATION.Clear();                             //#002

                pic01_PHOTO.Initialize();

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
                string LICENSECD = this.cbo01_LICENSECD.GetValue().ToString();
                string INSPECT_EMPNO_EMPNM = this.txt01_INSPECT_EMPNO_EMPNM.GetValue().ToString();
                string CERT_YEAR = this.txt01_CERT_YEAR.GetValue().ToString();                      //#001 승인대상년도 조회조건 추가
                string CERT_YEAR_YN = this.cbo01_APPROVE_YN.GetValue().ToString();                  //#001 승인여부 조회조건 추가
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_EMPNO_EMPNM", INSPECT_EMPNO_EMPNM);
                paramSet.Add("LICENSECD", LICENSECD);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("CERT_YEAR", CERT_YEAR);                                               //#001 승인대상년도 조회조건 추가
                paramSet.Add("CERT_YEAR_YN", CERT_YEAR_YN);                                         //#001 승인여부 조회조건 추가
                paramSet.Add("PLANT_DIV", PLANT_DIV);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20036.SetValue(source);
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
                string BIZCD            = cbo02_BIZCD.GetValue().ToString();
                string INSPECT_EMPNO    = txt02_INSPECT_EMPNO.GetValue().ToString();
                string INSPECT_EMPNM = txt02_INSPECT_EMPNM.GetValue().ToString();
                string LICENSECD        = cbo02_LICENSECD.GetValue().ToString();

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "INSPECT_EMPNO", "INSPECT_EMPNM", "JOIN_COMP_DATE", "LINECD", "LICENSECD", "CERTNO", "CERT_DATE", "RENEW_DATE", "CARRIER",
                    "REPORT_FILENO", "REPORT_FILENAME", "REPORT_OWNER_PGMIG", "BLOB$REPORT_FILEDATA",
                    "GGRNR_FILENO", "GGRNR_FILENAME", "GGRNR_OWNER_PGMIG", "BLOB$GGRNR_FILEDATA",
                    "RENEWAL_DATE", "CERT_YEAR", "NEXT_RENEWAL_DATE", "USERID",                                                     //#001 저장 항목 추가
                    "QUALIFICATION_FILENO", "QUALIFICATION_FILENAME", "QUALIFICATION_OWNER_PGMIG", "BLOB$QUALIFICATION_FILEDATA", "BLOB$PHOTO", "PLANT_DIV", "LANG_SET");  //#002 저장 항목 추가
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_EMPNO.GetValue(),
                    this.txt02_INSPECT_EMPNM.GetValue(),
                    this.dte02_JOIN_COMP_DATE.GetDateText(),
                    this.cdx02_LINECD.GetValue(),
                    this.cbo02_LICENSECD.GetValue(),
                    this.txt02_CERTNO.GetValue(),
                    this.dte02_CERT_DATE.GetDateText(),
                    this.dte02_RENEW_DATE.GetDateText(),
                    this.nme02_CARRIER.GetDBValue(),
                    _REPORTNO.FILENO,
                    _REPORTNO.FILENAME,
                    _REPORTNO.OWNER_PGMIG,
                    _REPORTNO.FILEDATA,
                    _GGRNR.FILENO,
                    _GGRNR.FILENAME,
                    _GGRNR.OWNER_PGMIG,
                    _GGRNR.FILEDATA,
                    this.dte02_RENEWAL_DATE.GetDateText(),         //#001 
                    this.dte02_CERT_YEAR.GetDateText().Substring(0,4),            //#001
                    this.dte02_NEXT_RENEWAL_DATE.GetDateText(),    //#001
                    this.UserInfo.EmpNo,                        //#001
                    _QUALIFICATION.FILENO,                      //#002
                    _QUALIFICATION.FILENAME,                    //#002
                    _QUALIFICATION.OWNER_PGMIG,                 //#002
                    _QUALIFICATION.FILEDATA ,                   //#002
                    this.pic01_PHOTO.GetValue(),
                    this.cbo02_PLANT_DIV.GetValue(),
                    this.UserInfo.Language
                );

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery_File(_CORCD, BIZCD, INSPECT_EMPNO, LICENSECD);

                //MsgBox.Show("검사원 자격 등록이 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_EMPNO", "LICENSECD");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_EMPNO.GetValue(),
                    this.cbo02_LICENSECD.GetValue()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("검사원 자격 등록이 삭제 되었습니다.");
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

        private void grd01_QA20036_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20036.SelectedRowIndex;

                if (Row >= this.grd01_QA20036.Rows.Fixed)
                {
                    string BIZCD            = this.grd01_QA20036.GetValue(Row, "BIZCD").ToString();
                    string INSPECT_EMPNO    = this.grd01_QA20036.GetValue(Row, "INSPECT_EMPNO").ToString();
                    string LICENSECD        = this.grd01_QA20036.GetValue(Row, "LICENSECD").ToString();

                    this.Inquery_File(_CORCD, BIZCD, INSPECT_EMPNO, LICENSECD);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_REPORTNO_REG_Click(object sender, EventArgs e)
        {
            FileStream stream = null;
            try
            {
                _REPORTNO.Clear();

                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.Cancel) return;

                string filename = ofd.FileName;

                _REPORTNO.FILENAME = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];
                _REPORTNO.OWNER_PGMIG = "QA20036";

                stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                _REPORTNO.FILEDATA = new byte[(int)stream.Length];
                stream.Read(_REPORTNO.FILEDATA, 0, _REPORTNO.FILEDATA.Length);

                stream.Close();

                this.txt02_REPORTNO.SetValue(_REPORTNO.FILENAME);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if(stream != null)
                    stream.Close();
            }
        }

        private void btn02_REPORTNO_REM_Click(object sender, EventArgs e)
        {
            try
            {
                _REPORTNO.ClearData();
                this.txt02_REPORTNO.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_REPORTNO_DWN_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.GetEnvironmentVariable("TEMP") + "\\" + _REPORTNO.FILENAME;

                if (File.Exists(fileName))
                    File.Delete(fileName);

                int ArraySize = _REPORTNO.FILEDATA.GetUpperBound(0);
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(_REPORTNO.FILEDATA, 0, ArraySize + 1);
                stream.Close();

                System.Diagnostics.Process.Start(fileName);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_GGRNR_REG_Click(object sender, EventArgs e)
        {
            FileStream stream = null;
            try
            {
                _GGRNR.Clear();

                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.Cancel) return;

                string filename = ofd.FileName;

                _GGRNR.FILENAME = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];
                _GGRNR.OWNER_PGMIG = "QA20036";

                stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                _GGRNR.FILEDATA = new byte[(int)stream.Length];
                stream.Read(_GGRNR.FILEDATA, 0, _GGRNR.FILEDATA.Length);

                stream.Close();

                this.txt02_GGRNR.SetValue(_GGRNR.FILENAME);
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

        private void btn02_GGRNR_REM_Click(object sender, EventArgs e)
        {
            try
            {
                _GGRNR.ClearData();
                this.txt02_GGRNR.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_GGRNR_DWN_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.GetEnvironmentVariable("TEMP") + "\\" + _GGRNR.FILENAME;

                if (File.Exists(fileName))
                    File.Delete(fileName);

                int ArraySize = _GGRNR.FILEDATA.GetUpperBound(0);
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(_GGRNR.FILEDATA, 0, ArraySize + 1);
                stream.Close();

                System.Diagnostics.Process.Start(fileName);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        //#002
        private void btn02_QUALIFICATION_REG_Click(object sender, EventArgs e)
        {
            FileStream stream = null;
            try
            {
                _QUALIFICATION.Clear();

                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.Cancel) return;

                string filename = ofd.FileName;

                _QUALIFICATION.FILENAME = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];
                _QUALIFICATION.OWNER_PGMIG = "QA20036";

                stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                _QUALIFICATION.FILEDATA = new byte[(int)stream.Length];
                stream.Read(_QUALIFICATION.FILEDATA, 0, _QUALIFICATION.FILEDATA.Length);

                stream.Close();

                this.txt02_QUALIFICATION.SetValue(_QUALIFICATION.FILENAME);
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
        private void btn02_QUALIFICATION_REM_Click(object sender, EventArgs e)
        {
            try
            {
                _QUALIFICATION.ClearData();
                this.txt02_QUALIFICATION.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //#002
        private void btn02_QUALIFICATION_DWN_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.GetEnvironmentVariable("TEMP") + "\\" + _QUALIFICATION.FILENAME;

                if (File.Exists(fileName))
                    File.Delete(fileName);

                int ArraySize = _QUALIFICATION.FILEDATA.GetUpperBound(0);
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(_QUALIFICATION.FILEDATA, 0, ArraySize + 1);
                stream.Close();

                System.Diagnostics.Process.Start(fileName);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        //#001 - 인증번호 생성 버튼 클릭
        private void btn02_GEN_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("PREFIX", "IQR-162-");
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source = _WSCOM.Inquery_CERTNO(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CERTNO"), paramSet);
                DataRow row = source.Tables[0].Rows[0];


                this.txt02_CERTNO.SetValue(row["CERTNO"]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }
        
        private void dte02_CERT_DATE_ValueChanged(object sender, EventArgs e)
        {

        }

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
        
        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void txt02_INSPECT_EMPNO_Leave(object sender, EventArgs e)
        {
            txt02_INSPECT_EMPNO.SetValue(txt02_INSPECT_EMPNO.GetValue().ToString().ToUpper());
            if (this.GetByteCount(txt02_INSPECT_EMPNO.GetValue().ToString()) == 0) return;

            if (!txt02_INSPECT_EMPNO.GetValue().ToString().Substring(0, 1).Equals("D") && this.GetByteCount(txt02_INSPECT_EMPNO.GetValue().ToString()) > 9)
            {
                MsgBox.Show("Maximum Length : 9");
                txt02_INSPECT_EMPNO.Initialize();
                txt02_INSPECT_EMPNO.Focus();
                return;
            }

            if (!txt02_INSPECT_EMPNO.GetValue().ToString().Substring(0, 1).Equals("D"))
            {
                txt02_INSPECT_EMPNO.SetValue("D" + txt02_INSPECT_EMPNO.GetValue().ToString());
            }
        }        
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            string CORCD = _CORCD;
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string INSPECT_EMPNO = this.txt02_INSPECT_EMPNO.GetValue().ToString();
            string INSPECT_EMPNM = this.txt02_INSPECT_EMPNM.GetValue().ToString();
            string LINECD = this.cdx02_LINECD.GetValue().ToString();
            string JOIN_COMP_DATE = this.dte02_JOIN_COMP_DATE.GetDateText().ToString();
            string LICENSECD = this.cbo02_LICENSECD.GetValue().ToString();
            string CERTNO = this.txt02_CERTNO.GetValue().ToString();
            string CERT_DATE = this.dte02_CERT_DATE.GetDateText().ToString();
            string RENEW_DATE = this.dte02_RENEW_DATE.GetDateText().ToString();
            string CARRIER = this.nme02_CARRIER.GetValue().ToString();

            if (this.GetByteCount(CORCD) == 0)
            {
                //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));     
                return false;
            }

            if (this.GetByteCount(BIZCD) == 0)
            {
                //MsgBox.Show("사업장이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                return false;
            }

            if (this.GetByteCount(INSPECT_EMPNO) == 0)
            {
                //MsgBox.Show("검사원코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_INSPECT_EMPNO.Text);
                return false;
            }


            if (this.GetByteCount(INSPECT_EMPNM) == 0)
            {
                //MsgBox.Show("검사원코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_INSPECT_EMPNM.Text);
                return false;
            }

            if (this.GetByteCount(LINECD) == 0)
            {
                //MsgBox.Show("검사원코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_LINECD.Text);
                return false;
            }

            if (this.GetByteCount(LICENSECD) == 0)
            {
                //MsgBox.Show("자격증코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_LICENCE_NM.Text);
                return false;
            }

            if (this.GetByteCount(CERTNO) == 0 || this.GetByteCount(CERTNO) > 11) //10->11
            {
                //MsgBox.Show("인증번호코드 입력이 잘못되었습니다.(범위 : 1~11Byte)");
                MsgCodeBox.ShowFormat("QA00-002", this.lbl02_CERTNO.Text, "1~11Byte");
                return false;
            }

            if (this.GetByteCount(CERT_DATE) == 8)
            {
                //MsgBox.Show("인증일자가 입력되지 않았습니다."); --> 디자인에 인증일자라고는 없고 등록일자만 존재
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_REG_DATE.Text);
                return false;
            }

            if (this.GetByteCount(RENEW_DATE) == 8)
            {
                //관련항목이 승인 만료일자와 동일하다 갱신일자가 아니다.
                //MsgBox.Show("갱신일자가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_ACC_EXP_DATE.Text);
                return false;
            }


            
            //#001 - 신규 데이터 등록인 경우 사번 중복 체크 로직 추가
            if (this.txt02_INSPECT_EMPNO.Enabled)
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("EMPNO", INSPECT_EMPNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
              
                //DataSet dsEmpno = _WSCOM.Inquery_CHECK_EMPNO(paramSet);
                DataSet dsEmpno = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CHECK_EMPNO"), paramSet);
                int cnt = dsEmpno.Tables[0].Rows.Count;

                if (cnt > 0)
                {
                    //MsgBox.Show("동일 사번이 이미 등록되어 있습니다.");
                    MsgCodeBox.Show("QA01-0031");
                    return false;
                }
            }

            //#001 - 인증번호 중복 체크 로직 추가
            HEParameterSet paramSet2 = new HEParameterSet();
            paramSet2.Add("EMPNO", INSPECT_EMPNO);
            paramSet2.Add("CERTNO", CERTNO);
            paramSet2.Add("LANG_SET", this.UserInfo.Language);
            //DataSet dsCERTNO = _WSCOM.Inquery_CHECK_CERTNO(paramSet2);
            DataSet dsCERTNO = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CHECK_CERTNO"), paramSet2);
            int cnt2 = dsCERTNO.Tables[0].Rows.Count;
            if (cnt2 > 0)
            {
                //MsgBox.Show("동일한 인증번호코드가 이미 등록되어 있습니다.");
                MsgCodeBox.Show("QA01-0032");
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
            string CORCD = _CORCD;
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string INSPECT_EMPNO = this.txt02_INSPECT_EMPNO.GetValue().ToString();
            string LICENSECD = this.cbo02_LICENSECD.GetValue().ToString();
            string CERTNO = this.txt02_CERTNO.GetValue().ToString();
            string CERT_DATE = this.dte02_CERT_DATE.GetDateText().ToString();
            string RENEW_DATE = this.dte02_RENEW_DATE.GetDateText().ToString();
            string CARRIER = this.nme02_CARRIER.GetValue().ToString();

            if (this.GetByteCount(CORCD) == 0)
            {
                //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD")); 
                return false;
            }

            if (this.GetByteCount(BIZCD) == 0)
            {
                //MsgBox.Show("사업장이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                return false;
            }

            if (this.GetByteCount(INSPECT_EMPNO) == 0)
            {
                //MsgBox.Show("검사원코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_INSPECT_EMPNO.Text);
                return false;
            }

            if (this.GetByteCount(LICENSECD) == 0)
            {
                //MsgBox.Show("자격증코드가 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_LICENCE_NM.Text);
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

        #region [ 사용자 정의 메서드 ] 
        
        private void Inquery_File(string CORCD, string BIZCD, string INSPECT_EMPNO, string LICENSECD)
        {
            try
            {
                this.BtnReset_Click(null, null);

                this.cbo02_BIZCD.Enabled            = false;
                this.txt02_INSPECT_EMPNO.Enabled    = false;
                //this.cbo02_LICENSECD.Enabled        = false;  //#001-자격증 콤보 변경 가능

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_EMPNO", INSPECT_EMPNO);
                paramSet.Add("LICENSECD", LICENSECD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source = _WSCOM.Inquery_FILE(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_FILE"), paramSet);

                DataRow row = source.Tables[0].Rows[0];

                string CERTNO       = row["CERTNO"].ToString();
                string CERT_DATE    = row["CERT_DATE"].ToString();
                string RENEW_DATE   = row["RENEW_DATE"].ToString();
                string CARRIER      = row["CARRIER"].ToString();
                string PLANT_DIV = row["PLANT_DIV"].ToString();

                string RENEWAL_DATE = row["RENEWAL_DATE"].ToString();           //#001 승인/갱신일자
                string CERT_YEAR = row["CERT_YEAR"].ToString();                 //#001 승인대상년도
                string NEXT_RENEWAL_DATE = row["NEXT_RENEWAL_DATE"].ToString(); //#001 차기갱신일자
                string INSPECT_EMPNM = row["NAME_KOR"].ToString();

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);
                this.txt02_INSPECT_EMPNO.SetValue(INSPECT_EMPNO);
                this.txt02_INSPECT_EMPNM.SetValue(INSPECT_EMPNM);
                this.cdx02_LINECD.SetValue(row["LINECD"].ToString());
                this.dte02_JOIN_COMP_DATE.SetValue(row["JOIN_COMP_DATE"].ToString());
                this.cbo02_LICENSECD.SetValue(LICENSECD);
                this.txt02_CERTNO.SetValue(CERTNO);

                this.dte02_CERT_DATE.SetValue(CERT_DATE);
                this.dte02_RENEW_DATE.SetValue(RENEW_DATE);
                this.nme02_CARRIER.SetValue(CARRIER);

                this.dte02_RENEWAL_DATE.SetValue(RENEWAL_DATE);                 //#001  승인/갱신일자 
                this.dte02_CERT_YEAR.SetValue(CERT_YEAR + "-01-01");            //#001  승인대상년도
                this.dte02_NEXT_RENEWAL_DATE.SetValue(NEXT_RENEWAL_DATE);       //#001  차기갱신일자

                _REPORTNO.FILENO        = row["REPORT_FILENO"].ToString();
                _REPORTNO.FILENAME      = row["REPORT_FILENAME"].ToString();
                _REPORTNO.OWNER_PGMIG   = row["REPORT_OWNER_PGMIG"].ToString();
                _REPORTNO.FILEDATA      = row["REPORT_FILEDATA"] == DBNull.Value ? null : (byte[])row["REPORT_FILEDATA"];
                _GGRNR.FILENO           = row["GGRNR_FILENO"].ToString();
                _GGRNR.FILENAME         = row["GGRNR_FILENAME"].ToString();
                _GGRNR.OWNER_PGMIG      = row["GGRNR_OWNER_PGMIG"].ToString();
                _GGRNR.FILEDATA         = row["GGRNR_FILEDATA"] == DBNull.Value ? null : (byte[])row["GGRNR_FILEDATA"];
                _QUALIFICATION.FILENO       = row["QUALIFICATION_FILENO"].ToString();           //#002
                _QUALIFICATION.FILENAME     = row["QUALIFICATION_FILENAME"].ToString();         //#002
                _QUALIFICATION.OWNER_PGMIG  = row["QUALIFICATION_OWNER_PGMIG"].ToString();      //#002
                _QUALIFICATION.FILEDATA     = row["QUALIFICATION_FILEDATA"] == DBNull.Value ? null : (byte[])row["QUALIFICATION_FILEDATA"]; //#002

                if ((row["PHOTO"]) != System.DBNull.Value)
                {
                    byte[] _PHOTO = null;
                    _PHOTO = (byte[])(row["PHOTO"]);
                    this.pic01_PHOTO.SetValue(_PHOTO);
                }


                if (_REPORTNO.FILENO.Length > 0)
                {
                    this.txt02_REPORTNO.SetValue(_REPORTNO.FILENAME);
                    this.btn02_REPORTNO_REG.SetReadOnly(true);
                    this.btn02_REPORTNO_REM.SetReadOnly(false);
                    this.btn02_REPORTNO_DWN.SetReadOnly(false);
                }
                else
                {
                    this.btn02_REPORTNO_REG.SetReadOnly(false);
                    this.btn02_REPORTNO_REM.SetReadOnly(true);
                    this.btn02_REPORTNO_DWN.SetReadOnly(true);
                }

                if (_GGRNR.FILENO.Length > 0)
                {
                    this.txt02_GGRNR.SetValue(_GGRNR.FILENAME);
                    this.btn02_GGRNR_REG.SetReadOnly(true);
                    this.btn02_GGRNR_REM.SetReadOnly(false);
                    this.btn02_GGRNR_DWN.SetReadOnly(false);
                }
                else
                {
                    this.btn02_GGRNR_REG.SetReadOnly(false);
                    this.btn02_GGRNR_REM.SetReadOnly(true);
                    this.btn02_GGRNR_DWN.SetReadOnly(true);
                }

                //#002
                if (_QUALIFICATION.FILENO.Length > 0)
                {
                    this.txt02_QUALIFICATION.SetValue(_QUALIFICATION.FILENAME);
                    this.btn02_QUALIFICATION_REG.SetReadOnly(true);
                    this.btn02_QUALIFICATION_REM.SetReadOnly(false);
                    this.btn02_QUALIFICATION_DWN.SetReadOnly(false);
                }
                else
                {
                    this.btn02_QUALIFICATION_REG.SetReadOnly(false);
                    this.btn02_QUALIFICATION_REM.SetReadOnly(true);
                    this.btn02_QUALIFICATION_DWN.SetReadOnly(true);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cdx_SETTING()
        {
            try
            {
                //this.cdx01_LINECD.HEUserParameterSetValue("TITLE", "검사원라인코드");
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }

}
