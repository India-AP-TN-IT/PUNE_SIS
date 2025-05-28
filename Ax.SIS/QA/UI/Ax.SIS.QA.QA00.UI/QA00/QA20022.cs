#region ▶ Description & History
/* 
 * 프로그램명 : QA20022 라인별 불량코드 등록
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
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>라인별 불량코드 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 4:16:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 4:16:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20022 : AxCommonBaseControl
    {
        //private IQA20022 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private Int32 _LINECD_ROW;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20022";

        #region [ 초기화 작업 정의 ]

        public QA20022()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IQA20022>("QA00", "QA20022.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            _LINECD_ROW = 0;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox2.Text = this.GetLabel("QA20022_MSG1");

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
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

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                this.cdx01_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");// "라인코드";
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_LINECD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_LINECD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_LINECD.SetCodePixedLength(); 

                this.grd01_QA20022.AllowEditing = false;
                this.grd01_QA20022.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20022.Initialize();
                this.grd01_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "라인코드", "LINECD", "LINECD");
                this.grd01_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 220, "라인명", "LINENM", "LINENM");
                this.grd01_QA20022.ExtendLastCol = true;
                this.grd01_QA20022.Cols[0].Visible = false;
                
                this.grd02_QA20022.AllowEditing = false;
                this.grd02_QA20022.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20022.Initialize();
                this.grd02_QA20022.AllowSorting = AllowSortingEnum.None;
                this.grd02_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "불량유형코드", "DEFKINDCD", "DEFKINDCD");
                this.grd02_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "불량유형명", "DEFKINDNM", "DEFKINDNM");
                this.grd02_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "불량코드", "DEFCD", "DEFCD");
                this.grd02_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "불량명", "DEFNM", "DEFNM");
                this.grd02_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70, "구분", "GUBN_YN", "DIVISION");
                this.grd02_QA20022.AddHiddenColumn("SORT_SEQ");
                this.grd02_QA20022.Cols[0].Visible = false;
                this.grd02_QA20022.SelectionMode = SelectionModeEnum.ListBox;

                this.grd03_QA20022.AllowEditing = false;
                this.grd03_QA20022.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA20022.Initialize();
                this.grd03_QA20022.AllowSorting = AllowSortingEnum.None;
                this.grd03_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd03_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "라인코드", "LINECD", "LINECD");
                this.grd03_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "라인명", "LINENM", "LINENM");
                this.grd03_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "불량유형코드", "DEFKINDCD", "DEFKINDCD");
                this.grd03_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "불량유형명", "DEFKINDNM", "DEFKINDNM");
                this.grd03_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "불량코드", "DEFCD", "DEFCD");
                this.grd03_QA20022.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "불량명", "DEFNM", "DEFNM");                
                this.grd03_QA20022.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70, "구분", "GUBN_YN", "DIVISION");
                
                //this.grd03_QA20022.Cols[0].Visible = false;
                this.grd03_QA20022.SelectionMode = SelectionModeEnum.ListBox;

                this.SetRequired(lbl01_BIZNM2);

                this.BtnReset_Click(null, null);
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
                this.grd01_QA20022.InitializeDataSource();
                this.grd02_QA20022.InitializeDataSource();
                this.grd03_QA20022.InitializeDataSource();

                this.grd02_QA20022.SelectionMode = SelectionModeEnum.ListBox;
                this.grd03_QA20022.SelectionMode = SelectionModeEnum.ListBox;

                this.cdx_SETTING();
                this.BtnQuery_Click(null, null);
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
                string LINECD = this.cdx01_LINECD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("LINECD", LINECD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_Line(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LINE"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20022.SetValue(source);
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
                DataSet source_Save = new DataSet();
                source_Save = grd03_QA20022.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "LINECD", "DEFCD", "SORT_SEQ", "USE_YN");

                DataSet source_Remove = new DataSet();
                source_Remove = grd03_QA20022.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "LINECD", "DEFCD");

                DataSet source = new DataSet();
                source = grd03_QA20022.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "LINECD", "DEFCD");

                if (!IsSaveValid(source_Save, source_Remove)) return;

                this.BeforeInvokeServer(true);
                
                //_WSCOM.Save(source_Save);
                //_WSCOM.Remove(source_Remove);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source_Remove);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source_Save);
                

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                string BIZCD = source.Tables[0].Rows[0]["BIZCD"].ToString();
                string LINECD = source.Tables[0].Rows[0]["LINECD"].ToString();

                this.DEFECT_INQUERY(BIZCD, LINECD);
                this.LINEDEFECT_INQUERY(BIZCD, LINECD);
                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("라인별 불량코드가 저장되었습니다.");
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

        private bool IsSaveValid(DataSet source1, DataSet source2)
        {
            try
            {
                if (source1.Tables[0].Rows.Count + source2.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("변경된 데이터가 존재하지 않아 저장할 수 없습니다.");
                    MsgCodeBox.Show("CD00-0042");
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

        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void DEFECT_INQUERY(string BIZCD, string LINECD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("LINECD", LINECD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_Defect(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DEFECT"), paramSet);

                this.AfterInvokeServer();

                this.grd02_QA20022.SetValue(source);
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

        private void LINEDEFECT_INQUERY(string BIZCD, string LINECD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("LINECD", LINECD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_LineDefect(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LINEDEFECT"), paramSet);

                this.AfterInvokeServer();

                this.grd03_QA20022.SetValue(source);
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

        private void grd01_QA20022_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20022.SelectedRowIndex;

                if (Row >= this.grd01_QA20022.Rows.Fixed)
                {
                    _LINECD_ROW = Row;

                    string BIZCD = this.grd01_QA20022.GetValue(Row, "BIZCD").ToString();
                    string LINECD = this.grd01_QA20022.GetValue(Row, "LINECD").ToString();

                    this.DEFECT_INQUERY(BIZCD, LINECD);
                    this.LINEDEFECT_INQUERY(BIZCD, LINECD);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        //저장대상 목록에 포함시 hidden처리된 항목은 삭제후 다시 insert하고, 신규 항목은 insert 처리함.
        //(그리드 맨 아래에 나타나게 하기 위해)
        private void btn01_RIGHT_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LINECD_ROW > 0)
                {
                    int cnt = this.grd02_QA20022.Rows.Selected.Count;

                    foreach (Row row in grd02_QA20022.Rows.Selected)
                    {
                        int ROW = row.Index;


                        string CORCD = this.grd01_QA20022.GetData(_LINECD_ROW, "CORCD").ToString();
                        string BIZCD = this.grd01_QA20022.GetData(_LINECD_ROW, "BIZCD").ToString();
                        string LINECD = this.grd01_QA20022.GetData(_LINECD_ROW, "LINECD").ToString();
                        string LINENM = this.grd01_QA20022.GetData(_LINECD_ROW, "LINENM").ToString();
                        string DEFCD = this.grd02_QA20022.GetData(ROW, "DEFCD").ToString();
                        string DEFNM = this.grd02_QA20022.GetData(ROW, "DEFNM").ToString();
                        string DEFKINDCD = this.grd02_QA20022.GetData(ROW, "DEFKINDCD").ToString();
                        string DEFKINDNM = this.grd02_QA20022.GetData(ROW, "DEFKINDNM").ToString();
                        
                        
                        DataTable source = (DataTable)this.grd03_QA20022.DataSource;
                        for (int i = 0; i < source.Rows.Count; i++)
                        {
                            //이미 존재하는 불량코드면([<]버튼으로 삭제한걸 다시 추가하는 경우) 삭제후 아래에서 insert
                            //왜냐면.. 추가되는 불량코드를 그리드 맨아래에 행추가하고, 해당 행 select처리 하여 사용자가 인지하기 쉽도록 하기 위해.
                            if (source.Rows[i]["CORCD"].ToString() == CORCD &&
                                source.Rows[i]["BIZCD"].ToString() == BIZCD &&
                                source.Rows[i]["LINECD"].ToString() == LINECD &&
                                source.Rows[i]["LINENM"].ToString() == LINENM &&
                                source.Rows[i]["DEFCD"].ToString() == DEFCD &&
                                source.Rows[i]["DEFNM"].ToString() == DEFNM &&
                                source.Rows[i]["DEFKINDCD"].ToString() == DEFKINDCD &&
                                source.Rows[i]["DEFKINDNM"].ToString() == DEFKINDNM)
                            {                                
                                source.Rows.RemoveAt(i);

                                break;

                            }

                        }

                        //그리드 맨 아래에 행추가.
                        this.grd03_QA20022.AddRow();
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["CORCD"] = CORCD;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["BIZCD"] = BIZCD;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["LINECD"] = LINECD;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["LINENM"] = LINENM;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["DEFCD"] = DEFCD;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["DEFNM"] = DEFNM;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["DEFKINDCD"] = DEFKINDCD;
                        this.grd03_QA20022.Rows[this.grd03_QA20022.Rows.Count - 1]["DEFKINDNM"] = DEFKINDNM;


                        //왼쪽아래의 [등록가능한목록]에서는 삭제함.
                        this.grd02_QA20022.Rows.Remove(ROW);

                    }

                    //추가된 불량코드 블록선택(맨아래부터 추가되는 항목 건수만큼 selection지정)
                    CellRange cr = this.grd03_QA20022.GetCellRange(this.grd03_QA20022.Rows.Count - cnt , this.grd03_QA20022.Cols["LINECD"].Index,
                                                                this.grd03_QA20022.Rows.Count - 1, this.grd03_QA20022.Cols["DEFNM"].Index);
                    this.grd03_QA20022.Select(cr, true);

                    //grd02_QA20022(등록가능한목록) 목록은 행선택 초기화
                    this.grd02_QA20022.Row = -1;
                   
                }

                //if (_LINECD_ROW > 0)
                //{
                //    DataSet source = new DataSet();
                //    source = grd03_QA20022.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "LINECD", "LINENM", "DEFKINDCD", "DEFKINDNM", "DEFCD", "DEFNM", "SORT_SEQ", "USE_YN", "GUBN_YN");

                //    foreach (Row row in grd02_QA20022.Rows.Selected)
                //    {
                //        int ROW = row.Index;

                //        string CORCD = this.grd01_QA20022.GetData(_LINECD_ROW, "CORCD").ToString();
                //        string BIZCD = this.grd01_QA20022.GetData(_LINECD_ROW, "BIZCD").ToString();
                //        string LINECD = this.grd01_QA20022.GetData(_LINECD_ROW, "LINECD").ToString();
                //        string LINENM = this.grd01_QA20022.GetData(_LINECD_ROW, "LINENM").ToString();
                //        string DEFCD = this.grd02_QA20022.GetData(ROW, "DEFCD").ToString();
                //        string DEFNM = this.grd02_QA20022.GetData(ROW, "DEFNM").ToString();
                //        string DEFKINDCD = this.grd02_QA20022.GetData(ROW, "DEFKINDCD").ToString();
                //        string DEFKINDNM = this.grd02_QA20022.GetData(ROW, "DEFKINDNM").ToString();
                //        string SORT_SEQ = "0";
                //        string USE_YN = "Y";
                //        string GUBN_YN = "U";

                //        for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                //        {
                //            if (source.Tables[0].Rows[i]["CORCD"].ToString() == CORCD &&
                //                source.Tables[0].Rows[i]["BIZCD"].ToString() == BIZCD &&
                //                source.Tables[0].Rows[i]["LINECD"].ToString() == LINECD &&
                //                source.Tables[0].Rows[i]["LINENM"].ToString() == LINENM &&
                //                source.Tables[0].Rows[i]["DEFCD"].ToString() == DEFCD &&
                //                source.Tables[0].Rows[i]["DEFNM"].ToString() == DEFNM &&
                //                source.Tables[0].Rows[i]["SORT_SEQ"].ToString() == SORT_SEQ &&
                //                source.Tables[0].Rows[i]["DEFKINDCD"].ToString() == DEFKINDCD &&
                //                source.Tables[0].Rows[i]["DEFKINDNM"].ToString() == DEFKINDNM &&
                //                source.Tables[0].Rows[i]["USE_YN"].ToString() == USE_YN)
                //            {
                //                source.Tables[0].Rows[i]["GUBN_YN"] = "D";
                //            }
                //        }

                //        source.Tables[0].Rows.Add(CORCD, BIZCD, LINECD, LINENM, DEFKINDCD, DEFKINDNM, DEFCD, DEFNM, SORT_SEQ, USE_YN, GUBN_YN);
                //        this.grd02_QA20022[ROW, 0] = "D";
                //        this.grd02_QA20022[ROW, "GUBN_YN"] = "D";
                //        this.grd02_QA20022.Rows[ROW].Visible = false;
                //    }

                //    this.grd03_QA20022.SetValue(source);

                //    for (int i = 1; i < grd03_QA20022.Rows.Count; i++)
                //    {
                //        if (this.grd03_QA20022.GetData(i, "GUBN_YN").ToString() == "U")
                //        {
                //            this.grd03_QA20022[i, 0] = "U";
                //        }
                //        if (this.grd03_QA20022.GetData(i, "GUBN_YN").ToString() == "D")
                //        {
                //            this.grd03_QA20022[i, 0] = "D";
                //            this.grd03_QA20022.Rows[i].Visible = false;
                //        }
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //저장대상 목록에서 제거시 hidden처리함.(플래그 : D로 변경)
        private void btn01_LEFT_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = grd02_QA20022.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD", "DEFKINDCD", "DEFKINDNM", "DEFCD", "DEFNM");

                
                int selected = this.grd03_QA20022.Rows.Selected.Count;

                foreach (Row row in grd03_QA20022.Rows.Selected)
                {
                    int ROW = row.Index;

                    string CORCD = this.grd03_QA20022.GetData(ROW, "CORCD").ToString();
                    string BIZCD = this.grd03_QA20022.GetData(ROW, "BIZCD").ToString();
                    string DEFCD = this.grd03_QA20022.GetData(ROW, "DEFCD").ToString();
                    string DEFNM = this.grd03_QA20022.GetData(ROW, "DEFNM").ToString();
                    string DEFKINDCD = this.grd03_QA20022.GetData(ROW, "DEFKINDCD").ToString();
                    string DEFKINDNM = this.grd03_QA20022.GetData(ROW, "DEFKINDNM").ToString();
                    string GUBN_YN = this.grd03_QA20022.GetValue(ROW, "GUBN_YN").ToString();

                    //플래그 "D"로 변경하여 hidden시킴.
                    this.grd03_QA20022[ROW, 0] = "D";
                    this.grd03_QA20022.Rows[ROW].Visible = false;


                    //grd02_QA20022(등록가능한 목록)에 추가함.
                    source.Tables[0].Rows.Add(CORCD, BIZCD, DEFKINDCD, DEFKINDNM, DEFCD, DEFNM);                    
                    
                }

                //hidden된 row 반영하여, 행번호 다시 먹임.
                int rowIdx = 0;
                if (selected > 0)
                {
                    for (int i = this.grd03_QA20022.Rows.Fixed; i < this.grd03_QA20022.Rows.Count; i++)
                    {
                        if (this.grd03_QA20022[i, 0].ToString() != "D" && 
                            this.grd03_QA20022[i, 0].ToString() != "N" && 
                            this.grd03_QA20022[i, 0].ToString() != "U")
                        {
                            rowIdx++;
                            this.grd03_QA20022[i, 0] = rowIdx;
                        }
                    }
                }

                //grd02_QA20022(등록가능한 목록) 그리드에 추가된 불량코드 반영.
                this.grd02_QA20022.SetValue(source.Tables[0]);

                //사용자가 인지하기 쉽도록 grd02_QA20022(등록가능한 목록) 그리드에 추가된 불량코드 해당 행 select처리.
                CellRange cr = this.grd02_QA20022.GetCellRange(this.grd02_QA20022.Rows.Count - selected, this.grd02_QA20022.Cols["DEFKINDCD"].Index,
                                                                this.grd02_QA20022.Rows.Count - 1, this.grd02_QA20022.Cols["DEFNM"].Index);
                this.grd02_QA20022.Select(cr, true);


                //DataTable source = (DataTable)this.grd02_QA20022.DataSource;               

                //DataSet source = grd02_QA20022.GetValue(AxFlexGrid.FActionType.All,
                //    "CORCD", "BIZCD", "DEFKINDCD", "DEFKINDNM", "DEFCD", "DEFNM", "GUBN_YN");

                //foreach (Row row in grd03_QA20022.Rows.Selected)
                //{
                //    int ROW = row.Index;

                //    string CORCD = this.grd03_QA20022.GetData(ROW, "CORCD").ToString();
                //    string BIZCD = this.grd03_QA20022.GetData(ROW, "BIZCD").ToString();
                //    string DEFCD = this.grd03_QA20022.GetData(ROW, "DEFCD").ToString();
                //    string DEFNM = this.grd03_QA20022.GetData(ROW, "DEFNM").ToString();
                //    string DEFKINDCD = this.grd03_QA20022.GetData(ROW, "DEFKINDCD").ToString();
                //    string DEFKINDNM = this.grd03_QA20022.GetData(ROW, "DEFKINDNM").ToString();
                //    string GUBN_YN = " ";

                //    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                //    {
                //        if (source.Tables[0].Rows[i]["CORCD"].ToString() == CORCD &&
                //            source.Tables[0].Rows[i]["BIZCD"].ToString() == BIZCD &&
                //            source.Tables[0].Rows[i]["DEFCD"].ToString() == DEFCD &&
                //            source.Tables[0].Rows[i]["DEFNM"].ToString() == DEFNM &&
                //            source.Tables[0].Rows[i]["DEFKINDCD"].ToString() == DEFKINDCD &&
                //            source.Tables[0].Rows[i]["DEFKINDNM"].ToString() == DEFKINDNM)
                //        {
                //            source.Tables[0].Rows[i]["GUBN_YN"] = "D";
                //        }
                //    }

                //    source.Tables[0].Rows.Add(CORCD, BIZCD, DEFKINDCD, DEFKINDNM, DEFCD, DEFNM, GUBN_YN);
                //    this.grd03_QA20022[ROW, 0] = "D";
                //    this.grd03_QA20022[ROW, "GUBN_YN"] = "D";
                //    this.grd03_QA20022.Rows[ROW].Visible = false;
                //}

                //this.grd02_QA20022.SetValue(source);

                //for (int i = 1; i < grd02_QA20022.Rows.Count; i++)
                //{
                //    if (this.grd02_QA20022.GetData(i, "GUBN_YN").ToString() == "D")
                //    {
                //        this.grd02_QA20022[i, 0] = "D";
                //        this.grd02_QA20022.Rows[i].Visible = false;
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion
    }
}
