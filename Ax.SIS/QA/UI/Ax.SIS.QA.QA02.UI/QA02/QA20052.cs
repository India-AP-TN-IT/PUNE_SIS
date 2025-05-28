#region ▶ Description & History
/* 
 * 프로그램명 : QA20052 공정순회검사일보 항목관리
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
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>공정 순회검사일보 항목관리</b>
    /// - 작 성 자 : 김연수<br />
    /// - 작 성 일 : 2010-08-24 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   김연수 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20052 : AxCommonBaseControl
    {
        //private IQA20052 _WSCOM;
       // private IQASubWindow _WSSUBWIN;
        private String _CORCD;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20052";

        #region [초기화 작업에 대한 정의]

        public QA20052()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20052>("QA02", "QA20052.svc", "CustomBinding");
            //_WSSUBWIN = ClientFactory.CreateChannel<IQASubWindow>("QA09", "QASubWindow.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                groupBox2.Text = this.GetLabel("QA20052_MSG1");
                _CORCD = this.UserInfo.CorporationCode;

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                DataSet source = this.GetTypeCode("BC", "IU");
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
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INSPECT_CLASSCD.PopupTitle = this.GetLabel("QA_INSPECT_BASECODE");//"검사코드";
                this.cdx01_INSPECT_CLASSCD.CodeParameterName = "INSPECT_CLASSCDR";
                this.cdx01_INSPECT_CLASSCD.NameParameterName = "INSPECT_CLASSNMR";
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_INSPECT_CLASSCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_ITEMCD.SetCodePixedLength(); 

                this.pic01_FRT_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_RR_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic01_ETC_3DR_PHOTO.SizeMode = PictureBoxSizeMode.Zoom;

                this.grd01_QA20052.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20052.Initialize();
                this.grd01_QA20052.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA20052.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA20052.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA20052.CurrentContextMenu.Items.Insert(0, new ToolStripMenuItem(this.GetLabel("ADD_ROW"), null, new EventHandler(this.RowAdd_Click)));
                this.grd01_QA20052.CurrentContextMenu.Items.Insert(1, new ToolStripMenuItem(this.GetLabel("DEL_ROW"), null, new EventHandler(this.RowDel_Click)));

                this.grd01_QA20052.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20052.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20052.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사순번", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd01_QA20052.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "검사항목명", "INSPECT_ITEMNM", "INSPECT_ITEMNM");
                this.grd01_QA20052.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "표준치수", "INSPECT_STD_MEAS", "INSPECT_STD_MEAS2");
                this.grd01_QA20052.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "상한치", "INSPECT_MAX_MEAS", "INSPECT_MAX_MEAS2");
                this.grd01_QA20052.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "하한치", "INSPECT_MIN_MEAS", "INSPECT_MIN_MEAS2");
                this.grd01_QA20052.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "검사단위", "INSPECT_UNITCD", "INSPECT_UNITNM");
                this.grd01_QA20052.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "구분", "CLASS_DIV", "DIVISION");

                this.grd01_QA20052.Cols["INSPECT_STD_MEAS"].Format = "###,###,###,###.##";
                this.grd01_QA20052.Cols["INSPECT_MAX_MEAS"].Format = "###,###,###,###.##";
                this.grd01_QA20052.Cols["INSPECT_MIN_MEAS"].Format = "###,###,###,###.##";

                this.grd01_QA20052.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "CLASS_DIV");
                this.grd01_QA20052.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "INSPECT_UNITCD");

                this.SetRequired(lbl01_BIZNM, lbl01_QA_INSPECT_BASECODE);

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

                this.grd01_QA20052.InitializeDataSource();

                this.pic01_FRT_PHOTO.Initialize();
                this.pic01_RR_PHOTO.Initialize();
                this.pic01_ETC_3DR_PHOTO.Initialize();

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

                this.grd01_QA20052.SetValue(source);
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

                DataSet source2 = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "INSPECT_CLASSCD", "INSPECT_SEQ", "INSPECT_ITEMNM", "INSPECT_STD_MEAS", "INSPECT_MAX_MEAS", "INSPECT_MIN_MEAS", "CLASS_DIV", "INSPECT_UNITCD");

                for (int i = 1; i < grd01_QA20052.Rows.Count; i++)
                    source2.Tables[0].Rows.Add(
                        _CORCD,
                        BIZCD,
                        INSPECT_CLASSCD,
                        this.grd01_QA20052.GetData(i, "INSPECT_SEQ"),
                        this.grd01_QA20052.GetData(i, "INSPECT_ITEMNM"),
                        this.grd01_QA20052.GetData(i, "INSPECT_STD_MEAS"),
                        this.grd01_QA20052.GetData(i, "INSPECT_MAX_MEAS"),
                        this.grd01_QA20052.GetData(i, "INSPECT_MIN_MEAS"),
                        this.grd01_QA20052.GetData(i, "CLASS_DIV"),
                        this.grd01_QA20052.GetData(i, "INSPECT_UNITCD")
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

                //MsgBox.Show("공정 순회검사일보 항목이 저장되었습니다.");
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

                //MsgBox.Show("공정 순회검사일보 항목이 삭제 되었습니다.");
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

        private void cdx01_INSPECT_CLASSCD_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                if (this.cdx01_INSPECT_CLASSCD.GetValue().ToString() != "")
                {
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

        protected void RowAdd_Click(object sender, EventArgs e)
        {
            int index = this.grd01_QA20052.Rows.Count;
            int count = 1;

            if (this.grd01_QA20052.DataSource == null)
                this.grd01_QA20052.InitializeDataSource();

            AxFlexGrid.FAlterEventRow args = new AxFlexGrid.FAlterEventRow(index, count);
            this.grd01_QA20052.OnRowInserting(this, args);

            DataTable source = (DataTable)this.grd01_QA20052.DataSource;

            source.Rows.InsertAt(source.NewRow(), index);

            this.grd01_QA20052[index, 0] = AxFlexGrid.FLAG_N;

            this.grd01_QA20052.OnRowInserted(this.grd01_QA20052, args);
        }

        protected void RowDel_Click(object sender, EventArgs e)
        {
            int index = this.grd01_QA20052.Row;
            int count = 1;

            if (index < 1) return;

            AxFlexGrid.FAlterEventRow args = new AxFlexGrid.FAlterEventRow(index, count);
            this.grd01_QA20052.OnRowDeleting(this, args);

            if (this.grd01_QA20052[index, 0].ToString().Equals(AxFlexGrid.FLAG_N))
            {
                this.grd01_QA20052.Rows.Remove(index);
                this.grd01_QA20052.OnRowDeleted(this, args);
            }
            else
            {
                if (this.grd01_QA20052.Rows.Count - 1 == index)
                {
                    this.grd01_QA20052.Rows.Remove(index);
                    this.grd01_QA20052.OnRowDeleted(this, args);
                }
                else
                {
                    MsgBox.Show("Selected row can't delete!", "Notice", MessageBoxButtons.OK);
                }
            }
        }

        private void grd01_QA20052_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            this.ReGenerateInspect_SeqNo();
        }

        private void grd01_QA20052_RowDeleted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            this.ReGenerateInspect_SeqNo();
        }

        private void grd01_QA20052_KeyDownEdit(object sender, C1.Win.C1FlexGrid.KeyEditEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.grd01_QA20052.Rows.Count - 1 == this.grd01_QA20052.SelectedRowIndex && this.grd01_QA20052.Cols["CLASS_DIV"].Index == this.grd01_QA20052.Col)
            {
                this.grd01_QA20052.Select(this.grd01_QA20052.SelectedRowIndex, this.grd01_QA20052.Cols["CLASS_DIV"].Index - 1);
                this.grd01_QA20052.Select(this.grd01_QA20052.SelectedRowIndex, this.grd01_QA20052.Cols["CLASS_DIV"].Index);
                if (this.grd01_QA20052.GetValue(this.grd01_QA20052.SelectedRowIndex, "INSPECT_ITEMNM").ToString() != "")
                {
                    this.RowAdd_Click(null, null);
                    this.grd01_QA20052.Select(this.grd01_QA20052.SelectedRowIndex + 1, this.grd01_QA20052.Cols["INSPECT_ITEMNM"].Index);
                }
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

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx01_VINCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_VINCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }
        //private void cdx01_VINCD_ButtonClickBefore(object sender, EventArgs args)
        //{
        //    this.cdx_SETTING();
        //}

        private void cdx01_ITEMCD_ButtonClickBefore(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_ITEMCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    //MsgBox.Show("검사분류코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl01_QA_INSPECT_BASECODE.Text);
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
                    string CLASS_DIV = source.Tables[0].Rows[i]["CLASS_DIV"].ToString();

                    if (this.GetByteCount(INSPECT_ITEMNM) == 0 || this.GetByteCount(INSPECT_ITEMNM) > 100)
                    {
                        //MsgBox.Show("검사항목(" + (i + 1).ToString() + "번째줄) 데이터 입력이 잘못되었습니다.(범위 : 1~100Byte)");
                        MsgCodeBox.ShowFormat("QA00-006", (i + 1).ToString());
                        return false;
                    }

                    if (this.GetByteCount(CLASS_DIV) == 0)
                    {
                        //MsgBox.Show("구분(" + (i + 1).ToString() + "번째줄) 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-007", this.GetLabel("DIVISION"), (i + 1).ToString());
                        return false;
                    }

                    if (CLASS_DIV == "BCA" || CLASS_DIV == "BCC")
                    {
                        if (INSPECT_STD_MEAS == "") INSPECT_STD_MEAS = "1";
                        if (INSPECT_MAX_MEAS == "") INSPECT_MAX_MEAS = "1";
                        if (INSPECT_MIN_MEAS == "") INSPECT_MIN_MEAS = "1";

                        this.grd01_QA20052.SetData(i + 1, "INSPECT_STD_MEAS", 1);
                        this.grd01_QA20052.SetData(i + 1, "INSPECT_MAX_MEAS", 1);
                        this.grd01_QA20052.SetData(i + 1, "INSPECT_MIN_MEAS", 1);

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
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(INSPECT_CLASSCD) == 0)
                {
                    //MsgBox.Show("검사분류코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-002", this.lbl01_QA_INSPECT_BASECODE.Text);
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

                if (source.Tables[0].Rows.Count > 0)
                {
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

        private void ReGenerateInspect_SeqNo()
        {
            int maxSeq = 0;

            for (int i = 1; i < this.grd01_QA20052.Rows.Count; i++)
            {
                if (this.grd01_QA20052.GetData(i, "INSPECT_SEQ").ToString().Trim() != "" &&
                    !this.grd01_QA20052.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_N) &&
                    !this.grd01_QA20052.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_D))
                {
                    if (int.Parse(this.grd01_QA20052.GetData(i, "INSPECT_SEQ").ToString()) > maxSeq)
                    {
                        maxSeq = (int.Parse(this.grd01_QA20052.GetData(i, "INSPECT_SEQ").ToString()));
                    }
                }
            }

            for (int i = 1; i < this.grd01_QA20052.Rows.Count; i++)
            {
                if (this.grd01_QA20052.GetData(i, 0).ToString().Trim().Equals(AxFlexGrid.FLAG_N))
                    this.grd01_QA20052.SetData(i, "INSPECT_SEQ", ++maxSeq);
            }
        }

        #endregion


    }
}
