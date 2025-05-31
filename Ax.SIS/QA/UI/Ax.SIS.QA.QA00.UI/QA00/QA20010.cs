#region ▶ Description & History
/* 
 * 프로그램명 : QA20010 부품유형별 검사코드기준 등록
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
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using HE.Framework.Core.Report;
using HE.Framework.ServiceModel;
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using TheOne.Windows.Forms;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>부품유형별 검사코드기준 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-19 오후 5:28:15<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-19 오후 5:28:15   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20010 : AxCommonBaseControl
    {
        //private IQA20010 _WSCOM;        
        private String _CORCD;
        private String _Change_CHK;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20010";
        
        #region [ 초기화 작업 정의 ]
        
        public QA20010()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20010>("QA00", "QA20010.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox4.Text = this.GetLabel("QA20010_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA20010_MSG2");
                this.groupBox2.Text = this.GetLabel("QA20010_MSG3");

                _CORCD = this.UserInfo.CorporationCode;

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

                this.grd01_QA20010.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
                this.grd01_QA20010.AllowEditing = false;
                this.grd01_QA20010.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20010.Initialize();
                this.grd01_QA20010.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA20010.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20010.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD","BIZCD");
                this.grd01_QA20010.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "검사코드", "INSPECT_BASECODE", "QA_INSPECT_BASECODE");
                this.grd01_QA20010.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "검사명", "INSPECT_CLASSNM", "QA_AINSPECT_CLASSNQA");
                this.grd01_QA20010.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd01_QA20010.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사순번", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd01_QA20010.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "검사항목", "INSPECT_ITEMNM", "INSPECT_ITEMNM");

                this.grd01_QA20010.SetColumnType(AxFlexGrid.FCellType.Int, "SORT_SEQ");
                this.grd01_QA20010.SetColumnType(AxFlexGrid.FCellType.Int, "INSPECT_SEQ");

                this.grd01_QA20010.Cols["CORCD"].AllowMerging = true;
                this.grd01_QA20010.Cols["BIZCD"].AllowMerging = true;
                this.grd01_QA20010.Cols["INSPECT_BASECODE"].AllowMerging = true;
                this.grd01_QA20010.Cols["INSPECT_CLASSNM"].AllowMerging = true;
                this.grd01_QA20010.Cols["SORT_SEQ"].AllowMerging = true;
                this.grd01_QA20010.Cols["INSPECT_BASECODE"].Style.BackColor = Color.White;
                this.grd01_QA20010.Cols["INSPECT_CLASSNM"].Style.BackColor = Color.White;
                this.grd01_QA20010.Cols["SORT_SEQ"].Style.BackColor = Color.White;

                this.grd02_QA20010.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20010.Initialize();
                this.grd02_QA20010.AllowSorting = AllowSortingEnum.None;

                // 김연수 추가 2010.08.27   (팝업메뉴 기능변경   :  행추가(마지막행추가) / 행삭제(신규행만 삭제가능)
                this.grd02_QA20010.CurrentContextMenu.Items[0].Visible = false;
                this.grd02_QA20010.CurrentContextMenu.Items[1].Visible = false;
                this.grd02_QA20010.CurrentContextMenu.Items[2].Visible = false;
                this.grd02_QA20010.CurrentContextMenu.Items.Insert(0, new ToolStripMenuItem(this.GetLabel("ADD_ROW"), null, new EventHandler(this.RowAdd_Click)));
                this.grd02_QA20010.CurrentContextMenu.Items.Insert(1, new ToolStripMenuItem(this.GetLabel("DEL_ROW"), null, new EventHandler(this.RowDel_Click)));

                this.grd02_QA20010.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20010.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20010.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "검사코드", "INSPECT_BASECODE", "QA_INSPECT_BASECODE");
                this.grd02_QA20010.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사순번", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd02_QA20010.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "검사항목", "INSPECT_ITEMNM", "INSPECT_ITEMNM");

                this.grd02_QA20010.SetColumnType(AxFlexGrid.FCellType.Int, "INSPECT_SEQ");

                this.SetRequired(lbl01_BIZNM2, lbl02_BIZNM2, lbl02_QA_INSPECT_BASECODE, lbl02_QA_AINSPECT_CLASSNQA);
                this.txt02_INSPECT_BASECODE.SetValid(2, AxTextBox.TextType.UAlphabet);
                this.txt02_INSPECT_CLASSNM.SetValid(100, AxTextBox.TextType.Default);
                this.txt02_SORT_SEQ.SetValid(AxTextBox.TextType.OnlyNumber);
                this.txt01_INSPECT_BASECODE_CLASSNM.SetValid(AxTextBox.TextType.Default);

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
                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.txt02_INSPECT_BASECODE.ReadOnly = false;
                this.txt02_SORT_SEQ.ReadOnly = true;
                _Change_CHK = "N";

                this.grd02_QA20010.InitializeDataSource(); 
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
                string INSPECT_BASECODE_CLASSNM = this.txt01_INSPECT_BASECODE_CLASSNM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_BASECODE_CLASSNM", INSPECT_BASECODE_CLASSNM);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_INSPECT_BASE(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_INSPECT_BASE"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20010.SetValue(source);
                _Change_CHK = "N";
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
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_BASECODE = this.txt02_INSPECT_BASECODE.GetValue().ToString();
                string INSPECT_CLASSNM = this.txt02_INSPECT_CLASSNM.GetValue().ToString();
                string SORT_SEQ = this.txt02_SORT_SEQ.GetValue().ToString();

                DataSet source_Remove = this.grd02_QA20010.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "INSPECT_BASECODE", "INSPECT_SEQ");

                for (int i = 0; i < source_Remove.Tables[0].Rows.Count; i++)
                {
                    source_Remove.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    source_Remove.Tables[0].Rows[i]["BIZCD"] = BIZCD;
                    source_Remove.Tables[0].Rows[i]["INSPECT_BASECODE"] = INSPECT_BASECODE;
                }

                DataSet source_Save = this.grd02_QA20010.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "INSPECT_BASECODE", "INSPECT_SEQ", "INSPECT_ITEMNM", "INSPECT_CLASSNM", "SORT_SEQ");

                for (int i = 0; i < source_Save.Tables[0].Rows.Count; i++)
                {
                    source_Save.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    source_Save.Tables[0].Rows[i]["BIZCD"] = BIZCD;
                    source_Save.Tables[0].Rows[i]["INSPECT_BASECODE"] = INSPECT_BASECODE;
                    source_Save.Tables[0].Rows[i]["INSPECT_CLASSNM"] = INSPECT_CLASSNM;
                    source_Save.Tables[0].Rows[i]["SORT_SEQ"] = SORT_SEQ;
                }

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_BASECODE", "INSPECT_CLASSNM", "SORT_SEQ");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    BIZCD,
                    INSPECT_BASECODE,
                    INSPECT_CLASSNM,
                    SORT_SEQ
                );

                if (!IsSaveValid(source_Remove, source_Save)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source_Save, source_Remove, source);

                string[] procedures = new string[] {string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_REMOVE"), 
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_SAVE"), 
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "SAVE")};
                DataSet[] datasets = new DataSet[] {source_Remove, source_Save, source};
                _WSCOM_N.MultipleExecuteNonQueryTx(procedures, datasets);
                
                
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery_INSPECT_ITEM(BIZCD, INSPECT_BASECODE);

                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("부품유형별 검사코드기준이 저장 되었습니다.");
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
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_BASECODE = this.txt02_INSPECT_BASECODE.GetValue().ToString();

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_BASECODE");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_INSPECT_BASECODE.GetValue()
                );

                if (!IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);
                this.Inquery_INSPECT_ITEM(BIZCD, INSPECT_BASECODE);

                //MsgBox.Show("부품유형별 검사코드기준이 삭제 되었습니다.");
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

        private void grd01_QA20010_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20010.SelectedRowIndex;

                if (Row > 0)
                {
                    this.cbo02_BIZCD.Enabled = false;
                    this.txt02_INSPECT_BASECODE.ReadOnly = true;
                    this.txt02_SORT_SEQ.ReadOnly = false;

                    string BIZCD = this.grd01_QA20010.GetValue(Row, "BIZCD").ToString();
                    string INSPECT_BASECODE = this.grd01_QA20010.GetValue(Row, "INSPECT_BASECODE").ToString();
                    string INSPECT_CLASSNM = this.grd01_QA20010.GetValue(Row, "INSPECT_CLASSNM").ToString();
                    string SORT_SEQ = this.grd01_QA20010.GetValue(Row, "SORT_SEQ").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.txt02_INSPECT_BASECODE.SetValue(INSPECT_BASECODE);
                    this.txt02_INSPECT_CLASSNM.SetValue(INSPECT_CLASSNM);
                    this.txt02_SORT_SEQ.SetValue(SORT_SEQ);

                    this.Inquery_INSPECT_ITEM(BIZCD, INSPECT_BASECODE);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        // 김연수 추가 2010.08.27  (새로운 행 추가시 행번호 생성)
        private void grd02_QA20010_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            this.ReGenerateInspect_SeqNo();
        }

        // 김연수 추가 2010.08.27 (신규 행 삭제시 행번호 재산출 => 기존행은 건들지 않음)
        private void grd02_QA20010_RowDeleted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            this.ReGenerateInspect_SeqNo();
        }

        private void grd02_QA20010_KeyDownEdit(object sender, C1.Win.C1FlexGrid.KeyEditEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.grd02_QA20010.Rows.Count - 1 == this.grd02_QA20010.SelectedRowIndex && this.grd02_QA20010.Cols["INSPECT_ITEMNM"].Index == this.grd02_QA20010.Col)
            {
                this.grd02_QA20010.Select(this.grd02_QA20010.SelectedRowIndex, this.grd02_QA20010.Cols["INSPECT_ITEMNM"].Index - 1);
                this.grd02_QA20010.Select(this.grd02_QA20010.SelectedRowIndex, this.grd02_QA20010.Cols["INSPECT_ITEMNM"].Index);
                if (this.grd02_QA20010.GetValue(this.grd02_QA20010.SelectedRowIndex, "INSPECT_ITEMNM").ToString() != "")
                {
                    this.RowAdd_Click(null, null);
                    this.grd02_QA20010.Select(this.grd02_QA20010.SelectedRowIndex+1, this.grd02_QA20010.Cols["INSPECT_ITEMNM"].Index);
                }
            }
        }

        private void txt02_INSPECT_CLASSNM_TextChanged(object sender, EventArgs e)
        {
            _Change_CHK = "Y";
        }

        private void txt02_SORT_SEQ_TextChanged(object sender, EventArgs e)
        {
            _Change_CHK = "Y";
        }

        // 김연수 추가 2010.08.27 (마지막행 추가 기능)
        protected void RowAdd_Click(object sender, EventArgs e)
        {
            int index = this.grd02_QA20010.Rows.Count;
            int count = 1;

            if (this.grd02_QA20010.DataSource == null)
                this.grd02_QA20010.InitializeDataSource();

            AxFlexGrid.FAlterEventRow args = new AxFlexGrid.FAlterEventRow(index, count);
            this.grd02_QA20010.OnRowInserting(this, args);

            DataTable source = (DataTable)this.grd02_QA20010.DataSource;

            source.Rows.InsertAt(source.NewRow(), index);

            this.grd02_QA20010[index, 0] = AxFlexGrid.FLAG_N;

            this.grd02_QA20010.OnRowInserted(this.grd02_QA20010, args);
        }

        // 김연수 추가 2010.08.27 (신규행 삭제기능)
        protected void RowDel_Click(object sender, EventArgs e)
        {
            int index = this.grd02_QA20010.Row;
            int count = 1;

            if (index < 1) return;

            AxFlexGrid.FAlterEventRow args = new AxFlexGrid.FAlterEventRow(index, count);
            this.grd02_QA20010.OnRowDeleting(this, args);

            if (this.grd02_QA20010[index, 0].ToString().Equals(AxFlexGrid.FLAG_N))
            {
                this.grd02_QA20010.Rows.Remove(index);
                this.grd02_QA20010.OnRowDeleted(this, args);
            }
            else
            {
                if (this.grd02_QA20010.Rows.Count - 1 == index)
                {
                    this.grd02_QA20010.SetValue(index, 0, AxFlexGrid.FLAG_D);
                }
                else
                {
                    MsgBox.Show("Selected row can't delete!", "Notice", MessageBoxButtons.OK);
                }
            }
        }
        
        private void heButton1_Click(object sender, EventArgs e)
        {
            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
            report.ReportName = "RxRpt/EP20S01";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.

            /* 
                * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
                * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
                * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
                * ds.Tables[0].TableName = "DATA";
                * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
                * */

            // Main Section ( 메인리포트 파라메터셋 )
            HERexSection mainSection = new HERexSection();
            mainSection.ReportParameter.Add("PRINT_USER", this.UserInfo.UserID + "(" + this.UserInfo.UserName + ")");
            mainSection.ReportParameter.Add("TEST_PARAM1", "파라메터1");
            mainSection.ReportParameter.Add("TEST_PARAM2", "파라메터2");
            report.Sections.Add("MAIN", mainSection);

            // XML Section ( 데이터 커넥션 명 ) / 파라메터 : 데이터셋, 리포트파람(서브리포트파람존재시)
            HEParameterSet param = new HEParameterSet();
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            param.Add("VENDCD", "");
            param.Add("VINCD", "");
            param.Add("PARTNO", "");
            param.Add("LANG_SET", this.UserInfo.Language);

            // DataSet 으로 부터 XML 파일 생성용 코드 ( 디자인용 )
            // ** 주의 **  생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 리포트와 함께 포함리소스로 포함시켜주세요
            // ds.Tables[0].TableName = "DATA";
            // ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
            DataSet ds = (new HE.Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_EP20S01", "INQUERY"), param);

            HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정

            AxRexpertReportViewer.ShowReport(report);
        }
        
        #endregion

        private void Inquery_INSPECT_ITEM(string BIZCD, string INSPECT_BASECODE)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_BASECODE", INSPECT_BASECODE);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_INSPECT_ITEM(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME,"INQUERY_INSPECT_ITEM"), paramSet);
                
                this.AfterInvokeServer();

                this.grd02_QA20010.SetValue(source);
                _Change_CHK = "N";
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

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source_Remove, DataSet source_Save)
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string INSPECT_BASECODE = this.txt02_INSPECT_BASECODE.GetValue().ToString();
                string INSPECT_CLASSNM = this.txt02_INSPECT_CLASSNM.GetValue().ToString();

                if (this.GetByteCount(CORCD) == 0)
                {
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("CORCD"));
                    //MsgBox.Show("법인코드 데이터가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(BIZCD) == 0)
                {
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZCD"));
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(INSPECT_BASECODE) == 0 || this.GetByteCount(INSPECT_BASECODE) > 2)
                {
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("QA_INSPECT_BASECODE"), "1~2Byte");
                    //MsgBox.Show("검사코드 입력이 잘못되었습니다.(범위 : 1~2Byte)");
                    return false;
                }

                if (this.GetByteCount(INSPECT_CLASSNM) == 0 || this.GetByteCount(INSPECT_CLASSNM) > 200)
                {
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("QA_AINSPECT_CLASSNQA"), "1~200Byte");
                    //MsgBox.Show("검사명 입력이 잘못되었습니다.(범위 : 1~200Byte)");
                    return false;
                }

                if (_Change_CHK == "Y")
                {
                    if (this.grd02_QA20010.Rows.Count-1 < 1)
                    {
                        //MsgBox.Show("검사항목의 리스트의 데이터가 존재하지 않습니다.");
                        MsgCodeBox.Show("QA00-003");
                        return false;
                    }
                }
                else
                {
                    if (source_Remove.Tables[0].Rows.Count < 1 && source_Save.Tables[0].Rows.Count < 1)
                    {
                        MsgCodeBox.Show("QA00-004");
                        //MsgBox.Show("변경된 검사코드가 없어 저장할 수 없습니다.");
                        return false;
                    }
                }

                for (int i = 0; i < source_Save.Tables[0].Rows.Count; i++)
                {
                    if (this.GetByteCount(source_Save.Tables[0].Rows[i]["INSPECT_ITEMNM"].ToString()) == 0)
                    {
                        MsgCodeBox.ShowFormat("QA00-005", source_Save.Tables[0].Rows[i]["INSPECT_SEQ"].ToString());
                        //MsgBox.Show("검사항목의 리스트의 검사항목(" + source_Save.Tables[0].Rows[i]["INSPECT_SEQ"].ToString() + "번째줄) 데이터가 존재하지 않습니다.");
                        return false;
                    }
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
                string INSPECT_BASECODE = this.txt02_INSPECT_BASECODE.GetValue().ToString();
                string INSPECT_CLASSNM = this.txt02_INSPECT_CLASSNM.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("BIZCD"));
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    return false;
                }

                if (this.GetByteCount(INSPECT_BASECODE) == 0 || this.GetByteCount(INSPECT_BASECODE) > 2)
                {
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("QA_INSPECT_BASECODE"), "1~2Byte");
                    //MsgBox.Show("검사코드 입력이 잘못되었습니다.(범위 : 1~2Byte)");
                    return false;
                }

                if (this.GetByteCount(INSPECT_CLASSNM) == 0 || this.GetByteCount(INSPECT_CLASSNM) > 200)
                {
                    MsgCodeBox.ShowFormat("QA00-002", this.GetLabel("QA_AINSPECT_CLASSNQA"), "1~200Byte");
                    //MsgBox.Show("검사명 입력이 잘못되었습니다.(범위 : 1~200Byte)");
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

        // 김연수 추가 2010.08.27 (행번호 자동 생성)
        private void ReGenerateInspect_SeqNo()
        {
            int maxSeq = 0;

            for (int i = 1; i < this.grd02_QA20010.Rows.Count; i++)
            {
                if (this.grd02_QA20010.GetData(i, "INSPECT_SEQ").ToString().Trim() != "" &&
                    !this.grd02_QA20010.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_N) &&
                    !this.grd02_QA20010.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_D))
                {
                    if (int.Parse(this.grd02_QA20010.GetData(i, "INSPECT_SEQ").ToString()) > maxSeq)
                    {
                        maxSeq = (int.Parse(this.grd02_QA20010.GetData(i, "INSPECT_SEQ").ToString()));
                    }
                }
            }

            for (int i = 1; i < this.grd02_QA20010.Rows.Count; i++)
            {
                if (this.grd02_QA20010.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_N))
                {
                    this.grd02_QA20010.SetData(i, "INSPECT_SEQ", ++maxSeq);
                    this.grd02_QA20010.SetData(i, "INSPECT_BASECODE", txt02_INSPECT_BASECODE.GetValue().ToString());
                }
            }
        }

        #endregion

        
    }
}
