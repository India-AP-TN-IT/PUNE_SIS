#region ▶ Description & History
/* 
 * 프로그램명 : QA20034 한도견본 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2015-07-27      배명희      통합WCF로 변경 
 * 
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
using System.Drawing;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>한도견본 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-31 오전 10:26:06<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-31 오전 10:26:06   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20034 : AxCommonBaseControl
    {
        //private IQA20034 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20034";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20034()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20034>("QA01", "QA20034.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
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

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");// "차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_VINCD.SetCodePixedLength();               

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

                this.grd01_QA20034.AllowEditing = false;
                this.grd01_QA20034.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20034.Initialize();
                this.grd01_QA20034.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "분류코드", "CLASSCD", "CLASSCD");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "관리번호", "MGRTNO", "MGRTNO");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "관리번호", "MGRTNO_TYPE", "MGRTNO");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "관리품명", "MGRTNM", "MGRTNM");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 40, "차종", "VINCD", "VIN");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "차종", "VINCD_TYPE", "VIN");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "품명/칼라", "PRODNM", "PRODNM");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "보유수량", "QUANTITY", "REMAIN_QTY");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "사용용도", "USE", "USE");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "관리담당(정)", "MAIN_EMPNO", "MAIN_EMPNONM");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 250, "관리담당(정)", "MAIN_EMPNONM", "MAIN_EMPNONM");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "관리담당(부)", "SUB_EMPNO", "SUB_EMPNONM");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 230, "관리담당(부)", "SUB_EMPNONM", "SUB_EMPNONM");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "비고", "REMARK", "REMARK");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "승인일자", "PROD_DATE", "APPROVALDATE");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 120, "승인일자", "PROD_DATE2", "APPROVALDATE");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "B/OUT 일자", "BOUT_DATE", "BOUT_DATE");
                this.grd01_QA20034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 075, "B/OUT", "BOUT_YN", "BOUT");
                this.grd01_QA20034.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "PLANT_DIV", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA20034.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
                this.grd01_QA20034.Styles.Add("COLOR_R").BackColor = Color.FromArgb(255, 200, 200);
                this.grd01_QA20034.SetColumnType(AxFlexGrid.FCellType.Decimal, "QUANTITY");
                this.grd01_QA20034.SelectionMode = SelectionModeEnum.ListBox;
                this.grd01_QA20034.Cols[ "PROD_DATE"].Format="yyyy-MM-dd";
                this.grd01_QA20034.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01_QA20034.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE2");
                this.grd01_QA20034.SetColumnType(AxFlexGrid.FCellType.Date, "BOUT_DATE");
                this.rdo02_QA20034.Checked = true;

                this.SetRequired(lbl01_BIZNM, lbl02_BIZNM, lbl02_VIN, lbl02_CLASSCD, lbl02_PRODNM, lbl02_MGRTNO, lbl02_REMAIN_QTY, lbl02_MGRTNM);
                this.txt02_PRODNM.SetValid(100, AxTextBox.TextType.Default);
                this.txt02_MGRTNO.SetValid(10, AxTextBox.TextType.UAlphabet);
                this.txt02_MGRTNM.SetValid(50, AxTextBox.TextType.Default);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
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
                foreach (Control ctl in groupBox_QA20034_MSG2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
                //this.dte02_BOUT_DATE.SetFromEnd();
                
                this.txt02_MGRTNO.ReadOnly = false;
                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo02_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo02_BIZCD.Enabled = false;
                }
                this.cbo02_CLASSCD.Enabled = true;

                this.cbo02_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
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
                string CLASSCD = this.cbo01_CLASSCD.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string MGRTNO_MGRTNM = this.txt01_MGRTNO_MGRTNM.GetValue().ToString();
                string YN = "";
                if (this.rdo01_QA20034.Checked == true)
                {
                    YN = "0";
                }
                else if (this.rdo02_QA20034.Checked == true)
                {
                    YN = "1";
                }
                else
                {
                    YN = "2";
                }

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CLASSCD", CLASSCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("MGRTNO_MGRTNM", MGRTNO_MGRTNM);
                paramSet.Add("YN", YN);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20034.SetValue(source);
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
                string BOUT_DATE = this.dte02_BOUT_DATE.GetDateText().ToString();
                if (!this.chk02_BOUT_MOVE.Checked)
                {
                    BOUT_DATE = "";
                }

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "MGRTNO", "MGRTNM", "VINCD", 
                    "PRODNM", "QUANTITY", "USE", "MAIN_EMPNO", "SUB_EMPNO", 
                    "PROD_DATE", "BOUT_DATE", "REMARK", "CLASSCD", "BOUT_YN", "PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue().ToString(),
                    this.txt03_MGRTNO.GetValue().ToString(),
                    this.txt02_MGRTNM.GetValue().ToString(),
                    this.cdx02_VINCD.GetValue().ToString(),
                    this.txt02_PRODNM.GetValue().ToString(),
                    this.mne02_QUANTITY.GetDBValue().ToString(),
                    this.txt02_USE.GetValue().ToString(),
                    this.txt02_MAIN_EMPNO.GetValue().ToString(),
                    this.txt02_SUB_EMPNO.GetValue().ToString(),
                    this.dte02_PROD_DATE.GetDateText().ToString(),
                    BOUT_DATE,
                    this.txt02_REMARK.GetValue().ToString(),
                    this.cbo02_CLASSCD.GetValue().ToString(),
                    this.chk02_BOUT_MOVE.GetValue().ToString(),
                    this.cbo02_PLANT_DIV.GetValue().ToString()
                    );

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("한도견본 등록이 저장되었습니다.");
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
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "MGRTNO", "PROD_DATE","PLANT_DIV");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo02_BIZCD.GetValue().ToString(),
                    this.txt03_MGRTNO.GetValue().ToString(),
                    this.dte02_PROD_DATE.GetDateText().ToString(),
                    this.cbo02_PLANT_DIV.GetValue().ToString()
                );

                if (!IsDeleteValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("한도견본 등록이 삭제 되었습니다.");
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

        private void grd01_QA20034_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20034.SelectedRowIndex;

                if (Row >= this.grd01_QA20034.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);

                    string BIZCD = this.grd01_QA20034.GetValue(Row, "BIZCD").ToString();
                    string VINCD = this.grd01_QA20034.GetValue(Row, "VINCD").ToString();
                    string CLASSCD = this.grd01_QA20034.GetValue(Row, "CLASSCD").ToString();
                    string PRODNM = this.grd01_QA20034.GetValue(Row, "PRODNM").ToString();
                    string USE = this.grd01_QA20034.GetValue(Row, "USE").ToString();
                    string MGRTNO = this.grd01_QA20034.GetValue(Row, "MGRTNO").ToString();
                    string MGRTNO_TYPE = this.grd01_QA20034.GetValue(Row, "MGRTNO_TYPE").ToString();
                    string QUANTITY = this.grd01_QA20034.GetValue(Row, "QUANTITY").ToString();
                    string MAIN_EMPNO = this.grd01_QA20034.GetValue(Row, "MAIN_EMPNO").ToString();
                    string MGRTNM = this.grd01_QA20034.GetValue(Row, "MGRTNM").ToString();
                    string REMARK = this.grd01_QA20034.GetValue(Row, "REMARK").ToString();
                    string SUB_EMPNO = this.grd01_QA20034.GetValue(Row, "SUB_EMPNO").ToString();
                    string PROD_DATE = this.grd01_QA20034.GetValue(Row, "PROD_DATE").ToString();
                    string BOUT_DATE = this.grd01_QA20034.GetValue(Row, "BOUT_DATE").ToString();
                    string BOUT_YN = this.grd01_QA20034.GetValue(Row, "BOUT_YN").ToString();
                    string PLANT_DIV = this.grd01_QA20034.GetValue(Row, "PLANT_DIV").ToString();

                    this.cbo02_BIZCD.SetValue(BIZCD);
                    this.cbo02_PLANT_DIV.SetValue(PLANT_DIV);
                    this.cdx02_VINCD.SetValue(VINCD);
                    this.cbo02_CLASSCD.SetValue(CLASSCD);
                    this.txt02_PRODNM.SetValue(PRODNM);
                    this.txt02_USE.SetValue(USE);
                    this.txt03_MGRTNO.SetValue(MGRTNO);
                    this.txt02_MGRTNO.SetValue(MGRTNO_TYPE);
                    this.mne02_QUANTITY.SetValue(QUANTITY);
                    this.txt02_MAIN_EMPNO.SetValue(MAIN_EMPNO);
                    this.txt02_MGRTNM.SetValue(MGRTNM);
                    this.txt02_REMARK.SetValue(REMARK);
                    this.txt02_SUB_EMPNO.SetValue(SUB_EMPNO);
                    this.dte02_PROD_DATE.SetValue(PROD_DATE);

                    if (BOUT_DATE == "")
                    {
                        //this.dte02_BOUT_DATE.SetFromEnd();
                        this.dte02_BOUT_DATE.Initialize();//.SetValue(DateTime.Now);
                    }
                    else
                    {
                        this.dte02_BOUT_DATE.SetValue(BOUT_DATE);
                    }
                    this.chk02_BOUT_MOVE.SetValue(BOUT_YN);

                    this.txt02_MGRTNO.ReadOnly = true;
                    this.cbo02_BIZCD.Enabled = false;
                    this.cbo02_CLASSCD.Enabled = false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet_CLASSCD = new HEParameterSet();
                paramSet_CLASSCD.Add("CORCD", _CORCD);
                paramSet_CLASSCD.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
                paramSet_CLASSCD.Add("PLANT_DIV", cbo01_PLANT_DIV.GetValue().ToString());
                paramSet_CLASSCD.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source_CLASSCD = _WSCOMBOBOX.Inquery_CLASSCD(paramSet_CLASSCD);
                DataSet source_CLASSCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_CLASSCD"), paramSet_CLASSCD);

                this.cbo01_CLASSCD.DataBind(source_CLASSCD.Tables[0]);
                this.cbo01_CLASSCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.AfterInvokeServer();
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

        private void cbo02_CLASSCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt02_MGRTNO_TextChanged(null, null);
        }

        private void txt02_MGRTNO_TextChanged(object sender, EventArgs e)
        {
            this.txt03_MGRTNO.SetValue("");
            if (this.cbo02_CLASSCD.GetValue().ToString() != "" && this.txt02_MGRTNO.GetValue().ToString() != "" )
            {
                this.txt03_MGRTNO.SetValue(this.cbo02_CLASSCD.GetValue().ToString() + "-" + this.txt02_MGRTNO.GetValue().ToString());
            }
        }

        private void chk02_BOUT_YN_CheckedChanged(object sender, EventArgs e)
        {
            if (chk02_BOUT_MOVE.GetValue().ToString() == "Y")
                this.dte02_BOUT_DATE.Enabled = true;
            else
                this.dte02_BOUT_DATE.Enabled = false;
        }

        private void btn01_ALL_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.GetByteCount(this.dte02_STD_DATE.GetDateText().ToString()) != 0)
                {
                    foreach (Row row in grd01_QA20034.Rows.Selected)
                    {
                        if (!IsALL_CHK_Valid(row.Index)) return;
                        this.grd01_QA20034.SetData(row.Index, "PROD_DATE", this.dte02_STD_DATE.Value.ToString(this.grd01_QA20034.Cols["PROD_DATE"].Format));
                        this.grd01_QA20034[row.Index, 0] = "U";
                        CellRange cr = new CellRange();
                        cr = this.grd01_QA20034.GetCellRange(row.Index, this.grd01_QA20034.Cols.Fixed, row.Index, this.grd01_QA20034.Cols.Count - this.grd01_QA20034.Cols.Fixed);
                        cr.Style = this.grd01_QA20034.Styles["COLOR_B"];
                    }
                }
                else
                {
                    //MsgBox.Show("검사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("QA_INSPECT_BASECODE"));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ALL_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Row row in grd01_QA20034.Rows.Selected)
                {
                    if (!IsALL_CHK_Valid(row.Index)) return;
                    this.grd01_QA20034.SetData(row.Index, "PROD_DATE", this.grd01_QA20034.Rows[row.Index]["PROD_DATE2"].ToString());
                    this.grd01_QA20034[row.Index, 0] = "U";
                    CellRange cr = new CellRange();
                    cr = this.grd01_QA20034.GetCellRange(row.Index, this.grd01_QA20034.Cols.Fixed, row.Index, this.grd01_QA20034.Cols.Count - this.grd01_QA20034.Cols.Fixed);
                    cr.Style = this.grd01_QA20034.Styles["COLOR_R"];
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ALL_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01_QA20034.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "MGRTNO", "PROD_DATE", "PLANT_DIV");

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_PROD_DATE"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
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

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet_CLASSCD = new HEParameterSet();
                paramSet_CLASSCD.Add("CORCD", _CORCD);
                paramSet_CLASSCD.Add("BIZCD", cbo02_BIZCD.GetValue().ToString());
                paramSet_CLASSCD.Add("PLANT_DIV", cbo02_PLANT_DIV.GetValue().ToString());
                paramSet_CLASSCD.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source_CLASSCD = _WSCOMBOBOX.Inquery_CLASSCD(paramSet_CLASSCD);
                DataSet source_CLASSCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_CLASSCD"), paramSet_CLASSCD);

                this.cbo02_CLASSCD.DataBind(source_CLASSCD.Tables[0]);
                this.cbo02_CLASSCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.AfterInvokeServer();
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

        private void grd01_QA20034_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string CORCD = _CORCD;
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string CLASSCD = this.cbo02_CLASSCD.GetValue().ToString();
                string MGRTNO = this.txt03_MGRTNO.GetValue().ToString();
                string MGRTNM = this.txt02_MGRTNM.GetValue().ToString();
                string VINCD = this.cdx02_VINCD.GetValue().ToString();
                string PRODNM = this.txt02_PRODNM.GetValue().ToString();
                string PROD_DATE = this.dte02_PROD_DATE.GetDateText().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(CLASSCD) == 0)
                {
                    //MsgBox.Show("분류코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CLASSCD.Text);
                    return false;
                }

                if (this.GetByteCount(PROD_DATE) == 0)
                {
                    //MsgBox.Show("승인일자가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_APPROVALDATE.Text);
                    return false;
                }

                if (this.GetByteCount(MGRTNO) == 0 || this.GetByteCount(MGRTNO) >10)
                {
                    //MsgBox.Show("관리번호가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_MGRTNO.Text);
                    return false;
                }

                if (this.txt02_MGRTNO.ReadOnly == false)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("MGRTNO", MGRTNO);
                    paramSet.Add("PROD_DATE", PROD_DATE);
                    paramSet.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);

                    //DataSet source = _WSCOM.Save_CHK(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_CHK"), paramSet);

                    this.AfterInvokeServer();

                    if (source.Tables[0].Rows[0][0].ToString() != "0")
                    {
                        //MsgBox.Show("승인일자와 관리번호가 동일한 데이터가 존재합니다.");
                        MsgCodeBox.Show("QA01-0027");
                        return false;
                    }                
                }

                if (this.GetByteCount(MGRTNM) == 0)
                {
                    //MsgBox.Show("관리품명이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_MGRTNM.Text);
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_VIN.Text);
                    return false;
                }

                if (this.GetByteCount(PRODNM) == 0)
                {
                    //MsgBox.Show("품번/칼라가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_PRODNM.Text);
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
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());                
                return false;
            }
        }

        private bool IsDeleteValid()
        {
            try
            {
                if (this.txt02_MGRTNO.ReadOnly == true)
                {
                    string CORCD = _CORCD;
                    string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                    string MGRTNO = this.txt03_MGRTNO.GetValue().ToString();
                    string PROD_DATE = this.dte02_PROD_DATE.GetDateText().ToString();

                    if (this.GetByteCount(BIZCD) == 0)
                    {
                        //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-001", this.lbl02_BIZNM.Text);
                        return false;
                    }

                    if (this.GetByteCount(PROD_DATE) == 0)
                    {
                        //MsgBox.Show("승인일자가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-001", this.lbl02_APPROVALDATE.Text);
                        return false;
                    }

                    if (this.GetByteCount(MGRTNO) == 0 || this.GetByteCount(MGRTNO) > 10)
                    {
                        //MsgBox.Show("관리번호가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-001", this.lbl02_MGRTNO.Text);
                        return false;
                    }
                }
                else
                {
                    //MsgBox.Show("삭제 할 데이터가 없습니다.");
                    MsgCodeBox.Show("CD00-0041");
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

        private bool IsALL_CHK_Valid(int ROW)
        {
            try
            {
                if (ROW <= 0)
                {
                    //MsgBox.Show("선택한 그리드 데이터가 없습니다.");
                    MsgCodeBox.Show("QA00-009");
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
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("변경된 데이터가 존재하지 않아 저장할 수 없습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < source.Tables[0].Rows.Count; i++)
                {
                    string BIZCD = source.Tables[0].Rows[i]["BIZCD"].ToString();
                    string PROD_DATE = source.Tables[0].Rows[i]["PROD_DATE"].ToString();

                    if (this.GetByteCount(BIZCD) == 0)
                    {
                        //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZCD"));
                        return false;
                    }

                    if (this.GetByteCount(PROD_DATE) == 0)
                    {
                        MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("APPROVALDATE"));
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

        #endregion


    }
}
