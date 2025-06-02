#region ▶ Description & History
/* 
 * 프로그램명 : MS/ES 스펙관리 > MS/ES 스펙 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-05-27      배명희      신규 작성
 *				2015-06-01      배명희      수정, 삭제는 같은 부서 사람이 등록한것만 가능(단 시험부서원인 경우에는 수정 가능)
 *				                            협력사 배포설정은 시험부서만 가능(VW_CD4710_SHARETEAM)
 *				                            타부서의 SPEC을 열람하고자하는 경우 열람사유 입력하여야 하고 워터마크 처리된 파일이 열림.
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;

namespace Ax.SIS.QA.QA02.UI
{

    public partial class QA24010 : AxCommonBaseControl
    {
        Point PanelMouseDownLocation; //사유등록PANEL 마우스로 위치 이동하기위한 변수(마우스 왼쪽버튼 클릭시 좌표)
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA24010";
        private string PAKAGE_NAME_QA34010 = "APG_QA34010";
        //private IQASubWindow _WSSUBWIN;
        private String _CORCD;
        DataTable _dtLangDiv;
        DataTable _dtGrd01;

        #region [ 초기화 작업 정의 ]

        public QA24010()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            //_WSSUBWIN = ClientFactory.CreateChannel<IQASubWindow>("QA09", "QASubWindow.svc", "CustomBinding");
            _dtLangDiv = new DataTable();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                _CORCD = this.UserInfo.CorporationCode;

                #region  다운버튼 이벤트 클릭 재정의

                //base에서 정의해 놓은 클릭 이벤트 핸들러 제거하고
                //이 화면에서 클릭 이벤트 추가.
                object btndownload = this._buttonsControl.BtnDownload;
                FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(btndownload);
                PropertyInfo pi = btndownload.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(btndownload, null);
                list.RemoveHandler(obj, list[obj]);
                this._buttonsControl.BtnDownload.Click += new EventHandler(BtnDownload_Click);

                #endregion

                DataSet source = this.GetTypeCode("ML", "MP"); //ML:언어, MP:공개여부
                //_dtLangDiv = source.Tables[0].Copy();
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", "KO");
                set.Add("CLASS_ID", "ML");
                _dtLangDiv = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LANG_DIV"), set).Tables[0];

                this.cbo01_LANG_DIV.DataBind(source.Tables[0], true);
                this.cbo01_LANG_DIV.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_LANG_DIV.DataBind(source.Tables[0], true);
                this.cbo02_LANG_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_SECURITY.DataBind(source.Tables[1], true);
                this.cbo01_SECURITY.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_SECURITY.SetValue("MPY"); //기본값 : 공개

                this.grd01.AllowDrop = true;
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(1, 1);
                this.grd01.AllowEditing = true;
                this.grd01.AllowDrop = true;
                this.grd01.CurrentContextMenu.Visible = false;
                //파일명 FILE_NAME5
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 35, "", "CHK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "파일명", "FILE_NAME", "FILE_NAME5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "용량", "FILE_SIZE", "FILE_SIZE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "스펙명", "SPEC_NO", "SPEC_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "EO번호", "EONO", "EONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "언어", "LANG_DIV","LANG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차수", "DEGREE", "DEGREE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "갱신일", "RENEW_DATE","RENEW_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "제목", "SUBJECT", "SUBJECT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "FILE_PATH", "FILE_PATH");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "FILEID", "FILEID");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "LANG_DIV");

                //그리드 초기화
                _dtGrd01 = new DataTable();
                _dtGrd01.Columns.Add("CHK", typeof(bool));
                _dtGrd01.Columns.Add("FILE_NAME", typeof(string));
                _dtGrd01.Columns.Add("FILE_SIZE", typeof(decimal));
                _dtGrd01.Columns.Add("SPEC_NO", typeof(string));
                _dtGrd01.Columns.Add("EONO", typeof(string));
                _dtGrd01.Columns.Add("LANG_DIV", typeof(string));
                _dtGrd01.Columns.Add("DEGREE", typeof(string));
                _dtGrd01.Columns.Add("RENEW_DATE", typeof(string));
                _dtGrd01.Columns.Add("SUBJECT", typeof(string));
                _dtGrd01.Columns.Add("FILE_PATH", typeof(string));
                _dtGrd01.Columns.Add("FILEID", typeof(string));
                this.grd01.SetValue(_dtGrd01);

                this.grd01.Cols["FILE_SIZE"].DataType = typeof(decimal);
                this.grd01.Cols["FILE_SIZE"].Format = "###,###,###,###";                
                this.grd01.Cols["LANG_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.Cols[0].Visible = false; //행번호표시 컬럼은 사용안함.

                CellStyle cs = this.grd01.Styles.Add("csBool");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, "csBool");

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize(1, 1);
                this.grd02.SelectionMode = SelectionModeEnum.Row;
                this.grd02.Cols.Count = this.grd02.Cols.Fixed;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "스펙명", "SPEC_NO", "SPEC_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "EO번호", "EONO", "EONO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "갱신일", "RENEW_DATE", "RENEW_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "언어", "LANG_DIV", "LANG");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차수", "DEGREE", "DEGREE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "제목", "SUBJECT", "SUBJECT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "파일명", "FILENAME", "FILE_NAME5");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "사이즈", "FILE_SIZE", "FILE_SIZE2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "공개여부", "SECURITY", "SECURITY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "등록부서", "LINENM", "REG_LINENM");                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "최초등록자", "INSERT_ID", "FSTINPUTID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "최종수정자", "UPDATE_ID", "FNLUPDATEID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "등록일자", "REG_DATE", "REG_DATE");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "DOCNO", "DOCNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "FILEID", "FILEID");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 70, "LINECD", "LINECD", "LINECD");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "LANG_DIV");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "SECURITY");
                this.grd02.Cols["FILE_SIZE"].Format = "###,###,###,###";
                this.grd02.Cols["LANG_DIV"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["SECURITY"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd03.AllowEditing = false;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Initialize(1, 1);
                this.grd03.AllowEditing = true;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "업체명", "VENDNM", "COMPANYNAME");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "담당자", "USERNAME", "CHARGE");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 35, "선택", "CHK", "CHK");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "USERID", "USERID");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "DOCNO", "DOCNO");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                this.grd03.Cols[0].Visible = false;
               
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SPEC_NO", this.txt01_SPEC_NO.GetValue());
                paramSet.Add("LANG_DIV", this.cbo01_LANG_DIV.GetValue());
                paramSet.Add("SECURITY", this.cbo01_SECURITY.GetValue());
                paramSet.Add("SUBJECT", this.txt01_SUBJECT.GetValue());
                paramSet.Add("LAST_2MONTH", this.chk01_LAST_2MONTH.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                DataSet source =  _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd02.SetValue(source);

                //파일 목록 초기화
                this.grd01.SetValue(_dtGrd01);

                //상세 내역 및 협력사 배포권한 영역 초기화
                this.initDetail();                
                this.grd03.InitializeDataSource();
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

        protected override void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.
                this.grd02.Cols["DOCNO"].Visible = true;
                
                this.grd02.CurrentContextMenu.Items[1].PerformClick();
                //string temp_path = @"C:\Temp";
                //if (!Directory.Exists(temp_path))
                //    Directory.CreateDirectory(temp_path);
                //string temp_file = String.Format(@"{0}\{1}.xls", temp_path, Guid.NewGuid().ToString());
                //FileFlags flags = FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges;
                //this.grd02.SaveExcel(temp_file, flags);

                this.grd02.Cols["DOCNO"].Visible = false;
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

        #region - 파일 리스트 -
        
        private void grd01_DragDrop(object sender, DragEventArgs e)
        {

            try
            {
                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.


                //탐색기 등에서 파일을 드래그 드랍하면(그리드에) 발생하는 이벤트
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                    
                    //선택한 파일 정보를 그리드에 표시함.
                    this.setGrid(file);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
              
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_DragEnter(object sender, DragEventArgs e)
        {
            try
            {

                //드래그하여 그리드위에 마우스 올라오면 효과주기
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            int row = this.grd01.MouseRow;
            int col = this.grd01.MouseCol;

            this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.

            try
            {
                if (row == this.grd01.Rows.Fixed - 1 && col == this.grd01.Cols["CHK"].Index)
                {
                    string val = this.grd01.GetValue(row, col).ToString();
                    if (val.Equals("Y"))
                    {
                        for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                        {
                            this.grd01.SetValue(i, "CHK", true);
                        }
                    }
                    else
                    {
                        for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                        {
                            this.grd01.SetValue(i, "CHK", false);
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

      
        #endregion

        #region - 조회 목록 -
        
        //클릭시 우측에 스펙 상세 정보 표시한다.
        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            int rIdx = this.grd02.MouseRow;
            if (rIdx < this.grd02.Rows.Fixed || rIdx >= this.grd02.Rows.Count) return;

            try
            {
                string docno = this.grd02.GetValue(rIdx, "DOCNO").ToString();
                string specno = this.grd02.GetValue(rIdx, "SPEC_NO").ToString();
                string eono = this.grd02.GetValue(rIdx, "EONO").ToString();
                string subject = this.grd02.GetValue(rIdx, "SUBJECT").ToString();
                string renewdate = this.grd02.GetValue(rIdx, "RENEW_DATE").ToString();
                string langdiv = this.grd02.GetValue(rIdx, "LANG_DIV").ToString();
                string degree = this.grd02.GetValue(rIdx, "DEGREE").ToString();
                string security = this.grd02.GetValue(rIdx, "SECURITY").ToString();
                string fileid = this.grd02.GetValue(rIdx, "FILEID").ToString();
                string linecd = this.grd02.GetValue(rIdx, "LINECD").ToString();
                string reg_date = this.grd02.GetValue(rIdx, "REG_DATE").ToString();
                this.txt02_LINECD.SetValue(linecd);
                this.txt02_ROWIDX.SetValue(rIdx);
                this.txt02_FILEID.SetValue(fileid);
                this.txt02_DOCNO.SetValue(docno);
                this.txt02_SPEC_NO.SetValue(specno);
                this.txt02_EONO.SetValue(eono);
                this.txt02_SUBJECT.SetValue(subject);
                this.txt02_RENEW_DATE.SetValue(renewdate);
                this.cbo02_LANG_DIV.SetValue(langdiv);
                this.txt02_DEGREE.SetValue(degree);
                this.txt02_REG_DATE.SetValue(reg_date);                

                //공개여부 (라디오박스 값 설정)
                if (security.Equals("MPY"))
                {
                    this.rdo02_SECURITY_O.Checked = true;
                    this.rdo02_SECURITY_C.Checked = false;
                }
                else
                {
                    this.rdo02_SECURITY_O.Checked = false;
                    this.rdo02_SECURITY_C.Checked = true;
                }

                this.inqueryDeploy(docno);

                this.SetManagerSetting(linecd, docno);

            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

        }

        //더블클릭시 스펙파일(pdf) 열람한다. (C:\Temp\Ax.SIS 에 다운로드)
        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int rIdx = this.grd02.MouseRow;
                if (rIdx < this.grd02.Rows.Fixed || rIdx >= this.grd02.Rows.Count) return;

                int cIdx = this.grd02.MouseCol;
                if (cIdx != this.grd02.Cols["FILENAME"].Index) return;
              
                string fileId = this.grd02.GetValue(rIdx, "FILEID").ToString();
                string linecd = this.grd02.GetValue(rIdx, "LINECD").ToString();
                string docno = this.grd02.GetValue(rIdx, "DOCNO").ToString();
                if (this.GetAuth(linecd, docno))
                    this.openPdf(fileId, false);
                else
                {
                    this.pnl04_INPUT_REASON.Top = this.Top + (this.Height / 2) - (this.pnl04_INPUT_REASON.Height / 2);
                    this.pnl04_INPUT_REASON.Left = this.Left + (this.Width / 2) - (this.pnl04_INPUT_REASON.Width / 2);
                    this.pnl04_INPUT_REASON.Visible = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #endregion

        #region [ 사용자 정의 메서드 ]

        //스펙정보 편집 영역 초기화
        private void initDetail()
        {
            try
            {
                this.txt02_LINECD.Initialize();
                this.txt02_ROWIDX.Initialize();
                this.txt02_FILEID.Initialize();
                this.txt02_DOCNO.Initialize();
                this.txt02_SPEC_NO.Initialize();
                this.txt02_EONO.Initialize();
                this.txt02_SUBJECT.Initialize();
                this.txt02_RENEW_DATE.Initialize();
                this.cbo02_LANG_DIV.Initialize();
                this.txt02_DEGREE.Initialize();
                this.txt02_REG_DATE.Initialize();
                this.rdo02_SECURITY_O.Checked = true;
                this.rdo02_SECURITY_C.Checked = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
        }

        //파일을 선택했을때, 파일명 유효성 체크하여 해당 파일 정보 그리드에 행추가.
        private void setGrid(string[] file)
        {
            try
            {
                if (this.grd01.DataSource == null)
                    this.grd01.SetValue(_dtGrd01);
                DataTable dt = (DataTable)this.grd01.DataSource;
                foreach (string str in file)
                {
                    FileInfo info = new FileInfo(str);
                    string ext = Path.GetExtension(str);
                    string fileName = Path.GetFileName(str);
                    string fname = fileName.Substring(0, fileName.Length - ext.Length);

                    if (!ext.ToUpper().Equals(".PDF"))
                    {
                        MsgCodeBox.ShowFormat("QA02-0048", fileName); //PDF파일이 아닙니다.
                        continue; //이번 파일정보는 행추가하지 않고 다음 파일로 넘긴다.
                    }

                    if (dt.Select("FILE_NAME='" + fileName + "'").Length > 0)
                    {
                        MsgCodeBox.ShowFormat("QA02-0053", fileName);//추가할 파일명 : {0}\r\n오류내용 : 업로드 대상 리스트에 이미 존재하는 파일입니다.
                        continue;
                    }

                    DataRow dr = dt.NewRow();

                    dr["CHK"] = false;
                    dr["FILE_PATH"] = str;
                    dr["FILE_NAME"] = fileName;
                    dr["FILE_SIZE"] = Math.Round(Convert.ToDecimal(info.Length) / 1024);
                    dr["FILEID"] = string.Empty;

                    FileNameInfo fninfo = this.getFileNameInfo(fname);
                    if (fninfo.IsError)
                    {
                        MsgCodeBox.ShowFormat(fninfo.ErrorMsgCode, fileName);
                        continue; //이번 파일정보는 행추가하지 않고 다음 파일로 넘긴다.
                    }
                    else
                    {
                        dr["EONO"] = fninfo.EONo;
                        dr["SPEC_NO"] = fninfo.SpecNo;
                        dr["LANG_DIV"] = fninfo.LangDiv;
                        dr["DEGREE"] = fninfo.Degree;
                        dr["RENEW_DATE"] = fninfo.RenewDate;
                        dr["SUBJECT"] = fninfo.Subject;
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
        }

        // 파일명 유효성 체크
        private FileNameInfo getFileNameInfo(string fileName)
        {
            FileNameInfo info = new FileNameInfo();
            info.IsError = false;
            info.ErrorMsgCode = "";

            try
            {
               
                string[] fileinfo = fileName.Split(new string[] { " " }, StringSplitOptions.None);
               

                if (fileinfo.Length < 5)
                {
                    info.IsError = true;
                    info.ErrorMsgCode = "QA02-0045"; //잘못된 파일명입니다.
                    return info;
                }

                info.SpecNo = fileinfo[0].ToUpper();


                DataRow[] drs = _dtLangDiv.Select("OBJECT_NM='" + fileinfo[1].ToUpper() + "'");
                if (drs.Length > 0)
                    info.LangDiv = drs[0]["OBJECT_ID"].ToString();
                else
                {
                    info.IsError = true;
                    info.ErrorMsgCode = "QA02-0046"; //잘못된 파일명(언어구분)입니다.
                    return info;
                }

                int returnParse = 0;

                if (int.TryParse(fileinfo[2], out returnParse) == false)
                {
                    info.IsError = true;
                    info.ErrorMsgCode = "QA02-0054"; //잘못된 파일명(차수)입니다.
                    return info;
                }

                info.Degree = fileinfo[2].ToUpper();

                info.EONo = fileinfo[3].ToUpper();


                if (fileinfo[4].Length != 8)
                {
                    info.IsError = true;
                    info.ErrorMsgCode = "QA02-0047"; //잘못된 파일명(갱신일자)입니다.
                    return info;
                }
                DateTime dt;
                if (!DateTime.TryParseExact(fileinfo[4], "yyyyMMdd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                {
                    info.IsError = true;
                    info.ErrorMsgCode = "QA02-0047"; //잘못된 파일명(갱신일자)입니다.
                    return info;
                }
                else
                {
                    info.RenewDate = dt.ToString("yyyy-MM-dd");
                }

                info.Subject = "";
                for (int i = 5; i < fileinfo.Length; i++)
                {
                    if (!info.Subject.Equals(string.Empty))
                    {
                        info.Subject += " ";
                    }
                    info.Subject += fileinfo[i];
                }

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                info.IsError = true;
                info.ErrorMsgCode = "QA02-0049"; //파일명 확인 중 오류가 발생하였습니다.
                MsgBox.Show(ex.ToString());
            }

            return info;

        }

        //배포 데이터 목록 조회
        private void inqueryDeploy(string docno)
        {
            try
            {
                
                HEParameterSet set = new HEParameterSet();
                set.Add("DOCNO", docno);
                set.Add("LANG_SET", this.UserInfo.Language);
                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DEPLOY"), set);
                this.grd03.SetValue(source.Tables[0]);                
             
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //권한 체크
        private bool GetAuth(string linecd, string docno)
        {
            bool ret = false;
            try
            {

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LINECD", this.UserInfo.DeptID);
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DEPLOY_LINECD"), set2);

                if (source.Tables[0].Rows.Count > 0 && Convert.ToInt32(source.Tables[0].Rows[0][0]) > 0)
                {
                    ret = true;
                    
                }
                else
                {
                    //내부서사람이 등록한 건이면
                    if (this.UserInfo.DeptID.Equals(this.txt02_LINECD.GetValue().ToString()))
                        ret = true;
                    else
                        ret = false;
                }       
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }

            return ret;
        }

        //권한 체크
        private void  SetManagerSetting(string linecd, string docno)
        {

            try
            {

                if (this.GetAuth(linecd, docno))
                {
                    //현재 로그인한 사람이 관리자라면 or 등록자와 부서가 같은 경우
                    this.lbl02_QA24010_NOTE1.SetValue(this.GetLabel("QA24010_NOTE1"));
                    
                    this.btn02_MODIFY.Enabled = true;   //관리자 권한 부서의 경우 수정도 가능                    
                    this.btn02_DELETE.Enabled = true;   //관리자 권한 부서의 경우 삭제도 가능
                    this.btn03_SAVE.Enabled = true;     //관리자 권한 부서의 경우 배포 가능
                }
                else
                {
                    //타부서 사람이 등록한 건이면                        
                    // 배포권한 없음. 수정 및 삭제 불가
                    this.lbl02_QA24010_NOTE1.SetValue(this.GetLabel("QA24010_NOTE1") + "(Read Only)"); //타부서 spec정보 열람은 읽기 전용만 된다고 알려줌
                    this.btn02_MODIFY.Enabled = false;
                    this.btn02_DELETE.Enabled = false;
                    this.btn03_SAVE.Enabled = false;
                    
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            
        }

        //스펙 파일 (pdf) 다운로드
        private void openPdf(string fileId, bool iswatermark)
        {
            try
            {
                PDFHelper pdf = new PDFHelper(iswatermark);
                string localFileName = pdf.LoadPDF(fileId);
                Process.Start(localFileName);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion
        
        #region [ 버튼 클릭 이벤트 정의 ]

        #region [ 상단 리스트업 영역 ]

        //등록버튼 (파일 업로드 및 데이터 저장)
        private void btn01_FILE_UPLOAD2_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.

                if (this.grd01.Rows.Count <= this.grd01.Rows.Fixed) return;

                if (MsgCodeBox.Show("CD00-0023", MessageBoxButtons.YesNo) == DialogResult.Yes) //데이터를 업로드 하시겠습니까?
                {

                    this.BeforeInvokeServer(true);
                    //파일 업로드를 먼저 함. 파일업로드 후 생성되는 FILEID를 그리드에 해당 컬럼에 넣어줌.
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        string LocalFileFullPath = this.grd01.GetValue(i, "FILE_PATH").ToString();
                        string ServerFolderName = this.Name;
                        string fileId = RemoteFileHandler.FileUpload(LocalFileFullPath, ServerFolderName, "");

                        this.grd01.SetValue(i, "FILEID", fileId);

                        DataSet source = AxFlexGrid.GetDataSourceSchema(
                                        "CORCD", "DOCNO", "SPEC_NO", "EONO", "LANG_DIV", "DEGREE", "SECURITY",
                                        "RENEW_DATE", "SUBJECT", "FILEID", "USER_ID");
                        source.Tables[0].Rows.Add(
                            this.UserInfo.CorporationCode,
                            string.Empty,
                            this.grd01.GetValue(i, "SPEC_NO").ToString(),
                            this.grd01.GetValue(i, "EONO").ToString(),
                            this.grd01.GetValue(i, "LANG_DIV").ToString(),
                            this.grd01.GetValue(i, "DEGREE").ToString(),
                            "MPY", //공개
                            this.grd01.GetValue(i, "RENEW_DATE").ToString(),
                            this.grd01.GetValue(i, "SUBJECT").ToString(),
                            fileId,
                            this.UserInfo.UserID);


                        _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                    }

                    this.AfterInvokeServer();


                    //MsgBox.Show("정상적으로 업로드되었습니다.");
                    MsgCodeBox.Show("CD00-0015");

                    //this.btn01_RESET_Click(null, null);
                    BtnQuery_Click(null, null);
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

        //삭제버튼 (목록에서 선택된 레코드 제거 - db저장 아님)
        private void btn01_CANCEL_ITEM_Click(object sender, EventArgs e)
        {
            try
            {

                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.

                //리스트 업의 목록에서 제거
                if (this.grd01.DataSource == null)
                    this.grd01.SetValue(_dtGrd01);

                DataTable source = (DataTable)this.grd01.DataSource;
                if (source.Select("CHK = true").Length > 0)
                {
                    //if (MsgBox.Show("업로드 대상 목록에서 삭제합니다. 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MsgCodeBox.Show("QA02-0050", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        for (int i = source.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = source.Rows[i];
                            if (dr["CHK"].ToString().ToUpper().Equals("TRUE") || dr["CHK"].ToString().ToUpper().Equals("1"))
                            {
                                source.Rows.RemoveAt(i);
                            }
                        }
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

        //초기화 (목록 초기화)
        private void btn01_RESET_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.

                this.grd01.SetValue(_dtGrd01);
                this.grd01.SetValue(0, this.grd01.Cols["CHK"].Index, false);

                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //찾아보기 (파일 찾기 다이얼로그)
        private void btn01_ADD_ITEM_Click(object sender, EventArgs e)
        {
            try
            {
                this.pnl04_INPUT_REASON.Visible = false;   //열람 이력 등록영역이 표시중이라면 안보이게 한다.

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Pdf Files (*.pdf)|*.pdf";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string[] file = ofd.FileNames;
                    this.setGrid(file);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 우측 중간 스펙 편집 영역 ]

        //스펙 파일 다운로드(pdf)
        private void btn02_VIEW_SPEC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt02_FILEID.IsEmpty) return;


                if (this.GetAuth(this.txt02_LINECD.GetValue().ToString(), this.txt02_DOCNO.GetValue().ToString()))
                    this.openPdf(this.txt02_FILEID.GetValue().ToString(), false);
                else
                {
                    this.pnl04_INPUT_REASON.Top = this.Top + (this.Height / 2) - (this.pnl04_INPUT_REASON.Height / 2);
                    this.pnl04_INPUT_REASON.Left = this.Left + (this.Width / 2) - (this.pnl04_INPUT_REASON.Width / 2);
                    this.pnl04_INPUT_REASON.Visible = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //스펙편집(qa4710) - 제목과 공개여부만 편집 
        private void btn02_MODIFY_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt02_DOCNO.IsEmpty) return;

                int intDegree = 0;

                if (this.txt02_DEGREE.GetValue().ToString().Trim() != ""&& int.TryParse(this.txt02_DEGREE.GetValue().ToString().Trim(), out intDegree) == false)
                {
                    MsgCodeBox.Show("QA02-0055");//차수는 숫자만 입력 가능합니다.
                    return;
                }

                //if (MsgBox.Show("수정하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (MsgCodeBox.Show("CD00-0043", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("DOCNO", this.txt02_DOCNO.GetValue());
                    set.Add("SPEC_NO", this.txt02_SPEC_NO.GetValue());
                    set.Add("EONO", this.txt02_EONO.GetValue());
                    set.Add("LANG_DIV", this.cbo02_LANG_DIV.GetValue());
                    set.Add("DEGREE", this.txt02_DEGREE.GetValue().ToString().Trim());
                    set.Add("SECURITY", this.rdo02_SECURITY_O.Checked ? "MPY" : "MPN");
                    set.Add("RENEW_DATE", this.txt02_RENEW_DATE.GetValue());
                    set.Add("SUBJECT", this.txt02_SUBJECT.GetValue());
                    set.Add("FILEID", this.txt02_FILEID.GetValue());
                    set.Add("USER_ID", this.UserInfo.UserID);


                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), set);

                    this.AfterInvokeServer();

                    //전체재조회 하지 않고 해당 데이터만 변경해준다.
                    int ridx = Convert.ToInt32(this.txt02_ROWIDX.GetValue());                    
                    this.grd02.SetValue(ridx, "EONO", this.txt02_EONO.GetValue());
                    this.grd02.SetValue(ridx, "SUBJECT", this.txt02_SUBJECT.GetValue());
                    this.grd02.SetValue(ridx, "SECURITY", this.rdo02_SECURITY_O.Checked ? "MPY" : "MPN");
                    this.grd02.SetValue(ridx, "DEGREE", this.txt02_DEGREE.GetValue().ToString().Trim());
                    this.grd02.SetValue(ridx, "UPDATE_ID", this.UserInfo.UserName);
                    ((DataTable)this.grd02.DataSource).AcceptChanges();
                    this.grd02.SetValue(ridx, 0, ridx);

                    //MsgBox.Show("정상적으로 수정되었습니다.");
                    MsgCodeBox.Show("CD00-0061");
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

        //이력 조회(qa7010)
        private void btn02_VIEW_HISTORY_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt02_DOCNO.IsEmpty) return;
                
                QA24010P1 control = new QA24010P1(this.txt02_DOCNO.GetValue().ToString());              
                //PopupHelper helper = new PopupHelper(control, this.GetLabel("QA24010P1"));                
                //helper.ShowDialog(false);

                //팝업을 화면의 가운데 위치에 표시한다.(위치 계산)
                int x = this.ParentForm.Location.X + (this.ParentForm.Width / 2) - (control.Width / 2);
                if (x < 0) x = 0;

                int y = this.ParentForm.Location.Y + (this.ParentForm.Height / 2) - (control.Height / 2);
                if (y < 0) y = 0;

                control.Left = x;
                control.Top = y;
                this.ShowPopup(control);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //서버에서 파일 삭제(xd7000) 및 데이터 삭제(cd4710, cd4720, qa7010)
        private void btn02_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt02_DOCNO.IsEmpty) return;

                //if (MsgBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //정말로 삭제하시겠습니까? 삭제된 데이터 및 파일은 복구할 수 없습니다.
                    if (MsgCodeBox.Show("QA02-0052", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        HEParameterSet set = new HEParameterSet();

                        set.Add("DOCNO", this.txt02_DOCNO.GetValue());

                        this.BeforeInvokeServer(true);

                        //원격 파일 및 XD7000 삭제
                        RemoteFileHandler.FileRemove(this.txt02_FILEID.GetValue().ToString());
                        //DB 데이터 삭제
                        _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "DELETE"), set);

                        this.AfterInvokeServer();

                        this.BtnQuery_Click(null, null);

                        //MsgBox.Show("삭제되었습니다.");
                        MsgCodeBox.Show("CD00-0072");
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
        
        #region [ 우측 하단 협력사 배포권한 설정 영역 ]

        //배포권한 저장 (all delete & insert 방식)
        private void btn03_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd03.Rows.Count <= this.grd03.Rows.Fixed) return;
                //if (MsgBox.Show("협력사 배포권한을 저장하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.BeforeInvokeServer(true);

                    DataSet source = AxFlexGrid.GetDataSourceSchema("DOCNO", "ACCESS_USERID", "USER_ID");
                    DataSet remove = AxFlexGrid.GetDataSourceSchema("DOCNO");

                    string docno = "";
                    for (int i = this.grd03.Rows.Fixed; i < this.grd03.Rows.Count; i++)
                    {
                        if (i == this.grd03.Rows.Fixed)
                            docno = this.grd03.GetValue(i, "DOCNO").ToString();

                        string chk = this.grd03.GetValue(i, "CHK").ToString().ToUpper();
                        if (chk.Equals("Y"))
                        {
                            source.Tables[0].Rows.Add(this.grd03.GetValue(i, "DOCNO").ToString(),
                                                        this.grd03.GetValue(i, "USERID").ToString(),
                                                        this.UserInfo.UserID);
                        }


                    }

                    remove.Tables[0].Rows.Add(docno);

                    _WSCOM.MultipleExecuteNonQueryTx(
                        new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "DELETE_DEPLOY"), string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_DEPLOY") },
                        new DataSet[] { remove, source });

                    this.AfterInvokeServer();

                    this.inqueryDeploy(docno); //협력사 배포목록 재조회

                    //MsgBox.Show("정상적으로 저장되었습니다.");
                    MsgCodeBox.Show("CD00-0009");
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
                
        #endregion
        
        #region [ 열람 사유 등록 영역]

        //열람 사유 등록용 panel 위치 이동 관련 로직
        private void pnl01_INPUT_REASON_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PanelMouseDownLocation = e.Location;
        }

        //열람 사유 등록용 panel 위치 이동 관련 로직
        private void pnl01_INPUT_REASON_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.pnl04_INPUT_REASON.Left += e.X - PanelMouseDownLocation.X;

                this.pnl04_INPUT_REASON.Top += e.Y - PanelMouseDownLocation.Y;

            }
        }

        //닫기 버튼 클릭시 - 열람 사유 등록용 panel안보이게
        private void btn04_CLOSE_0_Click(object sender, EventArgs e)
        {
            this.pnl04_INPUT_REASON.Visible = false;
        }

        //확인 버튼 클릭시 - 열람 사유 등록 후 파일 다운로드(워터마크 추가)
        private void btn04_CONFIRM_Click(object sender, EventArgs e)
        {
            //필수체크
            if (this.txt04_ACCESS_REASON.IsEmpty)
            {
                MsgCodeBox.Show("QA02-0051"); //조회사유를 반드시 입력하여야 합니다.
                return;
            }

            if (this.GetByteCount(this.txt04_ACCESS_REASON.GetValue().ToString()) > 4000)
            {
                MsgCodeBox.ShowFormat("QA01-0014", "조회사유", 4000); //{0} 데이터는 {1} bytes 이하로 입력하여 주세요.
                return;
            }


            HEParameterSet set = new HEParameterSet();
            set.Add("DOCNO", this.txt02_DOCNO.GetValue());
            set.Add("ACCESS_USERID", this.UserInfo.UserID);
            set.Add("ACCESS_REASON", this.txt04_ACCESS_REASON.GetValue());

            _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME_QA34010, "SAVE_HISTORY"), set);

            this.openPdf(this.txt02_FILEID.GetValue().ToString(), true);

            this.pnl04_INPUT_REASON.Visible = false;


        }

        //열람 사유 등록용 panel - 표시, 미표시에 따른 초기설정
        private void pnl04_INPUT_REASON_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.pnl04_INPUT_REASON.Visible)
            {
               
                this.txt04_ACCESS_REASON.Initialize();
                this.chk04_AGREE.Checked = false;
                this.groupBox2.Enabled = true;
            }
            else
                this.groupBox2.Enabled = false;
        }

        //동의 체크박스 체크하여야 "확인"버튼 활성화한다.
        private void chk04_AGREE_CheckedChanged(object sender, EventArgs e)
        {
            this.btn04_CONFIRM.Enabled = this.chk04_AGREE.Checked;
        }


        #endregion
    
    }

    /// <summary>
    /// "스펙명 국문(K)/영문(E)/합본(U) 갱신일 제목" 정보
    /// </summary>
    public class FileNameInfo
    {
        public string EONo { get; set; }

        public string SpecNo { get; set; }

        public string LangDiv { get; set; }

        public string Degree { get; set; }

        public string RenewDate { get; set; }

        public string Subject { get; set; }

        public bool IsError { get; set; }

        public string ErrorMsgCode { get; set; }
    }
}
