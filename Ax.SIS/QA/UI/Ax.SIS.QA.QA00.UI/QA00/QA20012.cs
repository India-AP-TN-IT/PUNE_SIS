#region ▶ Description & History
/* 
 * 프로그램명 : QA20012 검사코드별 검사항목 등록
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
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>검사코드별 검사항목 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-24 오후 5:31:16<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:31:16   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20012 : AxCommonBaseControl
    {
        //private IQA20012 _WSCOM;
        private String _CORCD;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20012";

        #region [ 초기화 작업 정의 ]

        public QA20012()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20012>("QA00", "QA20012.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox2.Text = this.GetLabel("QA20012_MSG1");

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
                
                DataSet source = this.GetTypeCode("FR", "F7", "BC");
                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
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

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INSPECT_CLASSCD.PopupTitle = this.GetLabel("QA_INSPECT_BASECODE");
                this.cdx01_INSPECT_CLASSCD.CodeParameterName = "INSPECT_CLASSCD";
                this.cdx01_INSPECT_CLASSCD.NameParameterName = "INSPECT_CLASSNM";
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_INSPECT_CLASSCD.SetCodePixedLength();
                this.cdx01_INSPECT_CLASSCD.ButtonClickBefore += new AxCodeBox.CButtonClickEventHandler(cdx01_INSPECT_CLASSCD_ButtonClickBefore);
                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_ITEMCD.SetCodePixedLength(); 

                this.pic01_INSPECT_STD_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_PARTNO_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01_QA20012.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20012.Initialize();
                this.grd01_QA20012.AllowSorting = AllowSortingEnum.None;

                // 김연수 추가 2010.08.27   (팝업메뉴 기능변경   :  행추가(마지막행추가) / 행삭제(신규행만 삭제가능)
                this.grd01_QA20012.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA20012.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA20012.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA20012.CurrentContextMenu.Items.Insert(0, new ToolStripMenuItem(this.GetLabel("ADD_ROW"), null, new EventHandler(this.RowAdd_Click)));
                this.grd01_QA20012.CurrentContextMenu.Items.Insert(1, new ToolStripMenuItem(this.GetLabel("DEL_ROW"), null, new EventHandler(this.RowDel_Click)));

                this.grd01_QA20012.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20012.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "순번", "INSPECT_SEQ", "SEQ_NO");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "검사항목", "INSPECT_ITEMNM", "E/TESTPART");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "표준치수", "INSPECT_STD_MEAS", "INSPECT_STD_MEAS2");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "상한치", "INSPECT_MAX_MEAS", "INSPECT_MAX_MEAS2");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 130, "하한치", "INSPECT_MIN_MEAS", "INSPECT_MIN_MEAS2");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "검사단위", "INSPECT_UNITCD", "INSPECT_UNITNM");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "검사주기", "INSPECT_CYCCD", "INSPECT_CYCNM");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "구분", "CLASS_DIV", "DIVISION");
                this.grd01_QA20012.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "필수", "MAND_INPUT_ITEM_YN", "MAND_INPUT_ITEM");

                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.Int, "INSPECT_SEQ");
                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_STD_MEAS");
                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MAX_MEAS");
                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSPECT_MIN_MEAS");

                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "INSPECT_UNITCD");
                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "INSPECT_CYCCD");
                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[2], "CLASS_DIV");
                this.grd01_QA20012.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_USE_YN, "MAND_INPUT_ITEM_YN");

                this.SetRequired(lbl01_BIZNM2, lbl01_QA_INSPECT_BASECODE);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        //검사코드 팝업 사이즈 재조정 - 검사코드 팝업에는 "공장구분"콤보상자 조건이 하나 더 추가되므로 기존 팝업보다 사이즈가 커야함. 기존사이즈는 (615,338)
        void cdx01_INSPECT_CLASSCD_ButtonClickBefore(object sender, EventArgs args)
        {
            AxCommonPopupControl pop = (AxCommonPopupControl)this.cdx01_INSPECT_CLASSCD.HEPopupHelper;
            pop.Width = 770;
            pop.Height = 450;
        }


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
                this.grd01_QA20012.InitializeDataSource();
                this.pic01_INSPECT_STD_PHOTO.Initialize();
                this.pic01_PARTNO_PHOTO.Initialize();

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
                if (!IsSelectValid()) return;

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();
                
                this.grd01_QA20012.SetValue(source);
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
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                DataSet source1 = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD");
                source1.Tables[0].Rows.Add(_CORCD, BIZCD, INSPECT_CLASSCD);

                DataSet source2 = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD", "INSPECT_SEQ", "INSPECT_ITEMNM", "INSPECT_STD_MEAS", "INSPECT_MAX_MEAS", "INSPECT_MIN_MEAS", "INSPECT_UNITCD", "INSPECT_CYCCD", "CLASS_DIV", "MAND_INPUT_ITEM_YN");

                for (int i = 1; i < grd01_QA20012.Rows.Count; i++)
                    source2.Tables[0].Rows.Add(
                        _CORCD,
                        BIZCD,
                        INSPECT_CLASSCD,
                        this.grd01_QA20012.GetData(i, "INSPECT_SEQ"),
                        this.grd01_QA20012.GetData(i, "INSPECT_ITEMNM"),
                        this.grd01_QA20012.GetData(i, "INSPECT_STD_MEAS"),
                        this.grd01_QA20012.GetData(i, "INSPECT_MAX_MEAS"),
                        this.grd01_QA20012.GetData(i, "INSPECT_MIN_MEAS"),
                        this.grd01_QA20012.GetData(i, "INSPECT_UNITCD"),
                        this.grd01_QA20012.GetData(i, "INSPECT_CYCCD"),
                        this.grd01_QA20012.GetData(i, "CLASS_DIV"),
                        this.grd01_QA20012.GetData(i, "MAND_INPUT_ITEM_YN")
                    );

                if (!IsSaveValid(source2)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source1, source2);
                string[] procedures = new string[] {string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"),                                                     
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "SAVE")};
                DataSet[] datasets = new DataSet[] { source1, source2 };

                _WSCOM_N.MultipleExecuteNonQueryTx(procedures, datasets);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                MsgCodeBox.Show("CD00-0071");
                //MsgBox.Show("검사코드별 검사항목이 저장되었습니다.");
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
                    this.cbo01_BIZCD.GetValue().ToString(),
                    this.cdx01_INSPECT_CLASSCD.GetValue().ToString()
                );

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                MsgCodeBox.Show("CD00-0072");
                //MsgBox.Show("검사코드별 검사항목이 삭제 되었습니다.");
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

        private void cdx01_INSPECT_CLASSCD_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                if (this.cdx01_INSPECT_CLASSCD.GetValue().ToString() != "")
                {
                    // 2010.08.27 김연수 추가   (검사코드만 선택시 차종/품번 가져오기)
                    //cdx01_VINCD.SetValue(((HECodeBox)sender).SelectedPopupValue["VINCD"].ToString());
                    //cdx01_ITEMCD.SetValue(((HECodeBox)sender).SelectedPopupValue["ITEMCD"].ToString());

                    IMAGE_VIEW(this.cbo01_BIZCD.GetValue().ToString(), this.cdx01_INSPECT_CLASSCD.GetValue().ToString());
                    this.BtnQuery_Click(null, null);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_VINCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_VINCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_ITEMCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_ITEMCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }
        // 김연수 추가 2010.08.27  (새로운 행 추가시 행번호 생성)
        private void grd01_QA20012_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            this.ReGenerateInspect_SeqNo();
        }

        // 김연수 추가 2010.08.27 (신규 행 삭제시 행번호 재산출 => 기존행은 건들지 않음)
        private void grd01_QA20012_RowDeleted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            this.ReGenerateInspect_SeqNo();
        }

        private void grd01_QA20012_KeyDownEdit(object sender, C1.Win.C1FlexGrid.KeyEditEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.grd01_QA20012.Rows.Count - 1 == this.grd01_QA20012.SelectedRowIndex && this.grd01_QA20012.Cols["MAND_INPUT_ITEM_YN"].Index == this.grd01_QA20012.Col)
            {
                this.grd01_QA20012.Select(this.grd01_QA20012.SelectedRowIndex, this.grd01_QA20012.Cols["MAND_INPUT_ITEM_YN"].Index - 1);
                this.grd01_QA20012.Select(this.grd01_QA20012.SelectedRowIndex, this.grd01_QA20012.Cols["MAND_INPUT_ITEM_YN"].Index);
                if (this.grd01_QA20012.GetValue(this.grd01_QA20012.SelectedRowIndex, "INSPECT_ITEMNM").ToString() != "")
                {
                    this.RowAdd_Click(null, null);
                    this.grd01_QA20012.Select(this.grd01_QA20012.SelectedRowIndex + 1, this.grd01_QA20012.Cols["INSPECT_ITEMNM"].Index);
                }
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

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }
        // 김연수 추가 2010.08.27 (마지막행 추가 기능)
        protected void RowAdd_Click(object sender, EventArgs e)
        {
            int index = this.grd01_QA20012.Rows.Count;
            int count = 1;

            if (this.grd01_QA20012.DataSource == null)
                this.grd01_QA20012.InitializeDataSource();

            AxFlexGrid.FAlterEventRow args = new AxFlexGrid.FAlterEventRow(index, count);
            this.grd01_QA20012.OnRowInserting(this, args);

            DataTable source = (DataTable)this.grd01_QA20012.DataSource;

            source.Rows.InsertAt(source.NewRow(), index);

            this.grd01_QA20012[index, 0] = AxFlexGrid.FLAG_N;

            this.grd01_QA20012.OnRowInserted(this.grd01_QA20012, args);
        }

        // 김연수 추가 2010.08.27 (신규행 삭제기능)
        protected void RowDel_Click(object sender, EventArgs e)
        {
            int index = this.grd01_QA20012.Row;
            int count = 1;

            if (index < 1) return;

            AxFlexGrid.FAlterEventRow args = new AxFlexGrid.FAlterEventRow(index, count);
            this.grd01_QA20012.OnRowDeleting(this, args);

            if (this.grd01_QA20012[index, 0].ToString().Equals(AxFlexGrid.FLAG_N))
            {
                this.grd01_QA20012.Rows.Remove(index);
                this.grd01_QA20012.OnRowDeleted(this, args);
            }
            else
            {
                if (this.grd01_QA20012.Rows.Count - 1 == index)
                {
                    this.grd01_QA20012.Rows.Remove(index);
                    this.grd01_QA20012.OnRowDeleted(this, args);
                }
                else
                {
                    MsgBox.Show("Selected row can't delete!", "Notice", MessageBoxButtons.OK);
                }
            }
        }
        
        #endregion

        #region [ 유효성 검사 ]

        private bool IsSelectValid()
        {
            try
            {
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("QA_INSPECT_BASECODE"));
                    //MsgBox.Show("검사코드 데이터가 입력되지 않았습니다.");
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

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("INSPECT_CLASSCD"));
                    //MsgBox.Show("검사분류코드 데이터가 입력되지 않았습니다.");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string BIZCD = source.Tables[0].Rows[i]["BIZCD"].ToString();
                    string INSPECT_SEQ = source.Tables[0].Rows[i]["INSPECT_SEQ"].ToString();
                    string INSPECT_ITEMNM = source.Tables[0].Rows[i]["INSPECT_ITEMNM"].ToString();
                    string INSPECT_STD_MEAS = source.Tables[0].Rows[i]["INSPECT_STD_MEAS"].ToString();
                    string INSPECT_MAX_MEAS = source.Tables[0].Rows[i]["INSPECT_MAX_MEAS"].ToString();
                    string INSPECT_MIN_MEAS = source.Tables[0].Rows[i]["INSPECT_MIN_MEAS"].ToString();
                    string INSPECT_UNITCD = source.Tables[0].Rows[i]["INSPECT_UNITCD"].ToString();
                    string INSPECT_CYCCD = source.Tables[0].Rows[i]["INSPECT_CYCCD"].ToString();
                    string CLASS_DIV = source.Tables[0].Rows[i]["CLASS_DIV"].ToString();
                    string MAND_INPUT_ITEM_YN = source.Tables[0].Rows[i]["MAND_INPUT_ITEM_YN"].ToString();

                    if (this.GetByteCount(INSPECT_ITEMNM) == 0 || this.GetByteCount(INSPECT_ITEMNM) > 100)
                    {
                        //MsgBox.Show("검사항목 데이터(" + (i + 1).ToString() + "번째줄) 입력이 잘못되었습니다.(범위 : 1~100Byte)");
                        MsgCodeBox.ShowFormat("QA00-006", (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(CLASS_DIV) == 0)
                    {
                        //MsgBox.Show("구분(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("DIVISION"), (i + 1).ToString());
                        return false;
                    }

                    // 2010.08.27 김연수 추가 (외관/치수 일때 값을 입력하지 않으면 기본값 1)
                    if (CLASS_DIV == "BCA" || CLASS_DIV == "BCC")
                    {
                        if (INSPECT_STD_MEAS == "") INSPECT_STD_MEAS = "1";
                        if (INSPECT_MAX_MEAS == "") INSPECT_MAX_MEAS = "1";
                        if (INSPECT_MIN_MEAS == "") INSPECT_MIN_MEAS = "1";

                        this.grd01_QA20012.SetData(i + 1, "INSPECT_STD_MEAS", 1);
                        this.grd01_QA20012.SetData(i + 1, "INSPECT_MAX_MEAS", 1);
                        this.grd01_QA20012.SetData(i + 1, "INSPECT_MIN_MEAS", 1);

                        source.Tables[0].Rows[i]["INSPECT_STD_MEAS"] = 1;
                        source.Tables[0].Rows[i]["INSPECT_MAX_MEAS"] = 1;
                        source.Tables[0].Rows[i]["INSPECT_MIN_MEAS"] = 1;
                    }

                    if (this.GetByteCount(INSPECT_STD_MEAS) == 0)
                    {
                        //MsgBox.Show("표준치수(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("INSPECT_STD_MEAS2"), (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(INSPECT_MAX_MEAS) == 0)
                    {
                        //MsgBox.Show("상한치(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("INSPECT_MAX_MEAS2"), (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(INSPECT_MIN_MEAS) == 0)
                    {
                        //MsgBox.Show("하한치(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("INSPECT_MIN_MEAS2"), (i + 1).ToString());
                        return false;
                    }

                    if (Decimal.Parse(INSPECT_STD_MEAS) > Decimal.Parse(INSPECT_MAX_MEAS) || Decimal.Parse(INSPECT_STD_MEAS) < Decimal.Parse(INSPECT_MIN_MEAS))
                    {
                        //MsgBox.Show("표준치수(" + (i + 1).ToString() + "번째줄)는 상한치와 하한치 사이에 존재 하여야 합니다.");
                        MsgCodeBox.ShowFormat("QA00-008", this.GetLabel("INSPECT_STD_MEAS2"), (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(INSPECT_UNITCD) == 0)
                    {
                        //MsgBox.Show("검사단위(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("INSPECT_UNITNM"), (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(INSPECT_CYCCD) == 0)
                    {
                        //MsgBox.Show("검사주기(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("INSPECT_CYCNM"), (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(MAND_INPUT_ITEM_YN) == 0)
                    {
                        //MsgBox.Show("필수(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("MAND_INPUT_ITEM"), (i + 1).ToString());
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    //MsgBox.Show("검사분류코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("INSPECT_CLASSCD"));
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

                if (source.Tables[0].Rows.Count > 0)
                {
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

                    if ((dr["ITEMNM"]) != System.DBNull.Value)
                    {
                        this.txt01_ITEMNM.SetValue(dr["ITEMNM"]);
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

        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("ITEMCD", this.cdx01_ITEMCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        // 김연수 추가 2010.08.27 (행번호 자동 생성)
        private void ReGenerateInspect_SeqNo()
        {
            int maxSeq = 0;

            for (int i = 1; i < this.grd01_QA20012.Rows.Count; i++)
            {
                if (this.grd01_QA20012.GetData(i, "INSPECT_SEQ").ToString().Trim() != "" &&
                    !this.grd01_QA20012.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_N) &&
                    !this.grd01_QA20012.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_D))
                {
                    if (int.Parse(this.grd01_QA20012.GetData(i, "INSPECT_SEQ").ToString()) > maxSeq)
                    {
                        maxSeq = (int.Parse(this.grd01_QA20012.GetData(i, "INSPECT_SEQ").ToString()));
                    }
                }
            }

            for (int i = 1; i < this.grd01_QA20012.Rows.Count; i++)
            {
                if (this.grd01_QA20012.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_N))
                {
                    this.grd01_QA20012.SetData(i, "INSPECT_SEQ", ++maxSeq);
                    this.grd01_QA20012.SetData(i, "BIZCD", this.cbo01_BIZCD.GetValue());
                    this.grd01_QA20012.SetData(i, "CORCD", _CORCD);
                }
            }
        }
        
        
        #endregion

        


        

    }
}
