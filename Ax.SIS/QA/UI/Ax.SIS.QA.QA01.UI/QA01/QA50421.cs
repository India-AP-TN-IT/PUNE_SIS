#region ▶ Description & History
/* 
 * 프로그램명 : QA50421 HMC, KIA Claim 판정 결과 등록
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-28      배명희      통합WCF로 변경
 * 
*/
#endregion
using System;
using System.Drawing;
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

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>HMC,KIA Claim 판정결과 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA50421 : AxCommonBaseControl
    {
        //private IQA50421 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA50421";
        // private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        // private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [초기화 작업에 대한 정의]

        public QA50421()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA50421>("QA01", "QA50421.svc", "CustomBinding");

            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");

            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox_main.Text = this.GetLabel("QA50421_MSG1");
                this.groupBox2.Text = this.GetLabel("QA50421_MSG2");
                
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

                this.cdx01_CUSTCD.HEPopupHelper = new QASubWindow();
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("CUSTCD");// "고객코드";
                this.cdx01_CUSTCD.CodeParameterName = "CUSTCD";
                this.cdx01_CUSTCD.NameParameterName = "CUSTNM";
                this.cdx01_CUSTCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_VINCD.SetCodePixedLength();

                this.cdx02_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx02_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");//"품목코드";
                this.cdx02_ITEMCD.CodeParameterName = "ITEMCD";
                this.cdx02_ITEMCD.NameParameterName = "ITEMNM";
                this.cdx02_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx02_ITEMCD.SetCodePixedLength();

                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx03_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx03_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx03_VENDCD.CodeParameterName = "VENDCD";
                this.cdx03_VENDCD.NameParameterName = "VENDNM";
                this.cdx03_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DOCRPTNO.HEPopupHelper = new QASubWindow();
                this.cdx01_DOCRPTNO.PopupTitle = this.GetLabel("DOCRPTNO");//"통보서번호";
                this.cdx01_DOCRPTNO.CodeParameterName = "DOCRPTNO";
                this.cdx01_DOCRPTNO.NameParameterName = "DOCRPTNM";
                this.cdx01_DOCRPTNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DOCRPTNO.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_DOCRPTNO.HEParameterAdd("SAL_VENDCD", "");
                this.cdx01_DOCRPTNO.HEParameterAdd("PROC_DATE", "");
                this.cdx01_DOCRPTNO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA50421.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA50421.Initialize(false);
                this.grd01_QA50421.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "고객사코드", "SAL_VENDCD","CUSTCD");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "고객사명", "SAL_VENDNM","CUSTNM");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "처리일자", "PROC_DATE", "PROC_DATE");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "완료여부", "COM_YN", "COM_YN");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "클레임발생구분", "CLAIM_OCCUR_DIV", "CLAIM_OCCUR_DIV");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "클레임발생구분", "CLAIM_OCCUR_DIVNM", "CLAIM_OCCUR_DIV");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "통보일자", "DOCRPT_DATE", "DOCRPT_DATE");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "정산일자", "ADJUST_DATE", "SETTLE_DATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "통보순번", "DOCRPT_SEQ", "DOCRPT_SEQ");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD","VIN");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINNM", "VIN");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "품목", "ITEMCD","ITEM");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMNM","ITEM");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNM", "PARTNM");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "원인부품", "APPLI_PART", "APPLI_PART");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "회사구분", "CMP_DIV", "COMP_DIV");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발생구분", "OCCUR_DIVCD", "OCCUR_DIV");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "발생순번", "OCCUR_SEQ", "OCCUR_SEQ");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "RO년월", "RO_YYMM", "RO_YYMM");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 145, "RO번호", "RONO", "RONO");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 145, "VIN번호", "VINNO", "VINNO");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "C/TYPE", "CTYPE", "CTYPE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "고객사차종", "VEND_VINCD", "VEND_VIN");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "건수", "NO_CASE", "NO_CASE");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "주작업코드", "MWORKCD", "MWORKCD");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "원인코드", "APPLICD", "APPLICD");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "현상코드", "PRESCD", "PRESCD");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "수리일자", "REPAIR_DATE", "REPAIR_DATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "판매일자", "SAL_DATE", "SAL_DATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "사용기간", "USE_TERM", "USE_TERM");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 55, "주행거리", "TRAVEL_DST", "TRAVEL_DST");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "납입율", "DELI_RATE", "DELI_RATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "분담율", "SHA_RATE", "SHA_RATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "적용율", "APP_RATE", "APP_RATE");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "부품비", "PART_COST", "PART_COST");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "합계", "SUMTOT", "SUMTOT");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "발생국가", "CLAIM_NATIONCD", "OCCUR_NATIONCD");
                this.grd01_QA50421.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "정비업체", "MAINT_VENDCD", "MAINT_VENDNM");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "거래처", "VENDCD", "VENDORCD");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "거래처", "VENDNM", "VENDORNM");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "타사품", "PROD_OTH_YN", "PROD_OTH");
                this.grd01_QA50421.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "보증초과", "NOTAS", "NOTAS");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "통보서번호", "DOCRPTNO", "DOCRPTNO");
                this.grd01_QA50421.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "고객사통보서번호", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Check, "PROD_OTH_YN");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Check, "NOTAS");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "USE_TERM");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "TRAVEL_DST");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELI_RATE");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "SHA_RATE");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "APP_RATE");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Date, "REPAIR_DATE");
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Date, "SAL_DATE");
                this.grd01_QA50421.Cols["RO_YYMM"].Format = "yyyy-MM";
                this.grd01_QA50421.SetColumnType(AxFlexGrid.FCellType.Date, "RO_YYMM");

                this.grd01_QA50421.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA50421.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA50421.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA50421.CurrentContextMenu.Items[3].Visible = false;
                this.grd01_QA50421.SelectionMode = SelectionModeEnum.ListBox;

                this.grd01_QA50421.AllowFreezing = AllowFreezingEnum.Columns;
                this.grd01_QA50421.Cols.Frozen = this.grd01_QA50421.Cols["PARTNM"].Index;

                this.grd01_QA50421.Styles.Add("BtnQuery_Click").BackColor = Color.FromArgb(255, 255, 200);

                this.SetRequired(lbl01_BIZNM, lbl01_CUSTNM, lbl01_PROYEAR, lbl01_DOCRPTNO);

                this.cdx01_CUSTCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.UserInfo.BusinessCode));

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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.chk01_PROD_OTH.SetValue("Y");
                this.chk01_NOTAS.SetValue("Y");
                this.grd01_QA50421.InitializeDataSource();

                this.grd01_QA50421.SelectionMode = SelectionModeEnum.ListBox;

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
                string DOCRPTNO = this.cdx01_DOCRPTNO.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string PARTNO_NM = this.txt01_PARTNO_NM.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DOCRPTNO", DOCRPTNO);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("PARTNO_NM", PARTNO_NM);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA50421.SetValue(source);

                if (grd01_QA50421.Rows.Count > 1)
                {
                    CellRange cr1 = new CellRange();
                    CellRange cr2 = new CellRange();
                    CellRange cr3 = new CellRange();

                    cr1 = grd01_QA50421.GetCellRange(1, grd01_QA50421.Cols["PARTNM"].Index, grd01_QA50421.Rows.Count-1, grd01_QA50421.Cols["PARTNM"].Index);
                    cr2 = grd01_QA50421.GetCellRange(1, grd01_QA50421.Cols["APPLICD"].Index, grd01_QA50421.Rows.Count - 1, grd01_QA50421.Cols["PRESCD"].Index);
                    cr3 = grd01_QA50421.GetCellRange(1, grd01_QA50421.Cols["VENDCD"].Index, grd01_QA50421.Rows.Count - 1, grd01_QA50421.Cols["NOTAS"].Index);

                    cr1.Style = grd01_QA50421.Styles["BtnQuery_Click"];
                    cr2.Style = grd01_QA50421.Styles["BtnQuery_Click"];
                    cr3.Style = grd01_QA50421.Styles["BtnQuery_Click"];
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01_QA50421.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "DOCRPTNO", "DOCRPT_SEQ", "VINCD",
                    "ITEMCD", "PARTNM", "APPLICD", "PRESCD", "VENDCD",
                    "PROD_OTH_YN", "NOTAS");

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("HMC,KIA Claim 판정결과 등록이 저장 되었습니다.");
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

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet set)
        {
            try
            {
                if (set.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("변경된 데이터가 없습니다.");
                    MsgCodeBox.Show("QA01-0021");
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
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsApply_SharateValid()
        {
            try
            {
                if (this.GetByteCount(_CORCD) == 0)
                {
                    //MsgBox.Show("법인코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CORCD"));
                    return false;
                }

                if (this.GetByteCount(this.cbo01_BIZCD.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("사업장이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
                    return false;
                }

                if (this.GetByteCount(this.cdx01_DOCRPTNO.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("통보서 번호가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_DOCRPTNO.Text);
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

        private bool IsSelectValid()
        {
            try
            {
                string CUSTCD = this.cdx01_CUSTCD.GetValue().ToString();
                string DOCRPTNO = this.cdx01_DOCRPTNO.GetValue().ToString();

                if (this.GetByteCount(CUSTCD) == 0)
                {
                    //MsgBox.Show("고객사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl01_CUSTNM.Text);
                    return false;
                }

                if (this.GetByteCount(DOCRPTNO) == 0)
                {
                    //MsgBox.Show("통보서번호 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl01_DOCRPTNO.Text);
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

        #region [ 기타 이벤트 정의 ]

        private void btn01_APPLY_SHARATE_Click(object sender, EventArgs e)
        {
            if (!IsApply_SharateValid()) return;

            try
            {
                DataSet source = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "DOCRPTNO", "LANG_SET");

                source.Tables[0].Rows.Add(
                            _CORCD,
                            this.cbo01_BIZCD.GetValue(),
                            this.cdx01_DOCRPTNO.GetValue(),
                            _LANG_SET
                        );

                this.BeforeInvokeServer(true);

                //_WSCOM.Apply_SHARATE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "APPLY_SHARATE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("분담율 처리수행이 처리되었습니다.");
                MsgCodeBox.Show("QA01-0022");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_VINCD_Click(object sender, EventArgs e)
        {
            if (grd01_QA50421.Rows.Selected.Count > 0)
            {
                foreach (Row row in grd01_QA50421.Rows.Selected)
                {
                    this.grd01_QA50421.SetValue(row.Index, "VINCD", this.cdx02_VINCD.GetValue());
                    this.grd01_QA50421.SetValue(row.Index, "VINNM", this.cdx02_VINCD.GetText());
                    this.grd01_QA50421.SetValue(row.Index, 0, "U");
                }
            }
            else
            {
                //MsgBox.Show("선택된 데이터가 없습니다.");
                MsgCodeBox.Show("QA01-0023");
            }
        }

        private void btn02_ITEMCD_Click(object sender, EventArgs e)
        {
            if (grd01_QA50421.Rows.Selected.Count > 0)
            {
                foreach (Row row in grd01_QA50421.Rows.Selected)
                {
                    this.grd01_QA50421.SetValue(row.Index, "ITEMCD", this.cdx02_ITEMCD.GetValue());
                    this.grd01_QA50421.SetValue(row.Index, "ITEMNM", this.cdx02_ITEMCD.GetText());
                    this.grd01_QA50421.SetValue(row.Index, 0, "U");
                }
            }
            else
            {
                //MsgBox.Show("선택된 데이터가 없습니다.");
                MsgCodeBox.Show("QA01-0023");
            }
        }

        private void btn02_VENDCD_Click(object sender, EventArgs e)
        {
            if (grd01_QA50421.Rows.Selected.Count > 0)
            {
                foreach (Row row in grd01_QA50421.Rows.Selected)
                {
                    this.grd01_QA50421.SetValue(row.Index, "VENDCD", this.cdx02_VENDCD.GetValue());
                    this.grd01_QA50421.SetValue(row.Index, "VENDNM", this.cdx02_VENDCD.GetText());
                    this.grd01_QA50421.SetValue(row.Index, 0, "U");
                }
            }
            else
            {
                //MsgBox.Show("선택된 데이터가 없습니다.");
                MsgCodeBox.Show("QA01-0023");
            }
        }

        private void btn01_PROD_OTH_YN_Click(object sender, EventArgs e)
        {
            if (grd01_QA50421.Rows.Selected.Count > 0)
            {
                foreach (Row row in grd01_QA50421.Rows.Selected)
                {
                    bool CHK = true;
                    if (this.chk01_PROD_OTH.GetValue().ToString() == "Y")
                    {
                        CHK = true;
                    }
                    else
                    {
                        CHK = false;
                    }

                    this.grd01_QA50421.SetValue(row.Index, "PROD_OTH_YN", CHK);
                    this.grd01_QA50421.SetValue(row.Index, 0, "U");
                }
            }
            else
            {
                //MsgBox.Show("선택된 데이터가 없습니다.");
                MsgCodeBox.Show("QA01-0023");
            }
        }

        private void btn01_NOTAS_Click(object sender, EventArgs e)
        {
            if (grd01_QA50421.Rows.Selected.Count > 0)
            {
                foreach (Row row in grd01_QA50421.Rows.Selected)
                {
                    bool CHK = true;
                    if (this.chk01_NOTAS.GetValue().ToString() == "Y")
                    {
                        CHK = true;
                    }
                    else
                    {
                        CHK = false;
                    }

                    this.grd01_QA50421.SetValue(row.Index, "NOTAS", CHK);
                    this.grd01_QA50421.SetValue(row.Index, 0, "U");
                }
            }
            else
            {
                //MsgBox.Show("선택된 데이터가 없습니다.");
                MsgCodeBox.Show("QA01-0023");
            }
        }

        private void grd01_QA50421_AfterEdit(object sender, RowColEventArgs e)
        {
            string sText = this.grd01_QA50421.GetData(e.Row, e.Col).ToString();
            this.grd01_QA50421_Code_SELECT(e.Row, e.Col, sText);
        }

        private void cdx03_VENDCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.grd01_QA50421_CODEBOX(cdx03_VENDCD, "VENDCD", "VENDNM");
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cdx01_CUSTCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_CUSTCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void dte01_RTN_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion


        #region [ 사용자 정의 메서드 ]

        private void grd01_QA50421_CODEBOX(AxCodeBox codebox, string sCOL1, string sCOL2)
        {
            int iROW = this.grd01_QA50421.Row;
            int iCOL = this.grd01_QA50421.Col;

            this.grd01_QA50421.SetValue(iROW, sCOL1, codebox.GetValue().ToString());

            if (sCOL2 != "")
            {
                this.grd01_QA50421.SetValue(iROW, sCOL2, codebox.GetText().ToString());
            }
        }

        private void grd01_QA50421_Code_SELECT(int iROW, int iCOL, string sText)
        {
            if (iROW > 0)
            {
                switch (this.grd01_QA50421.Cols[iCOL].Name.ToString().ToUpper().Trim())
                {
                    case "VENDCD":
                        this.cdx03_VENDCD.Initialize();
                        this.cdx03_VENDCD.SetValue(sText);

                        if (sText == "")
                        {
                            this.POPUP(cdx03_VENDCD);
                        }

                        break;

                    case "VENDNM":
                        this.cdx03_VENDCD.Initialize();
                        this.cdx03_VENDCD.SetValue(sText);

                        if (sText == "")
                        {
                            this.POPUP(cdx03_VENDCD);
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        private void POPUP(AxCodeBox ctl)
        {
            ctl.HEPopupHelper.Initialize_Helper(ctl);
            PopupHelper helper = new PopupHelper((AxCommonPopupControl)ctl.HEPopupHelper, ctl.PopupTitle);

            helper.ShowDialog();

            object data = helper.SelectedValue;
            if (data != null)
            {
                DataRow _SelectedPopupValue = (DataRow)data;
                ctl.SetValue(_SelectedPopupValue[ctl.CodeParameterName]);
            }

        }

        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_DOCRPTNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DOCRPTNO.HEUserParameterSetValue("SAL_VENDCD", this.cdx01_CUSTCD.GetValue().ToString());
                this.cdx01_DOCRPTNO.HEUserParameterSetValue("PROC_DATE", this.dte01_RTN_DATE.GetDateText().Substring(0,7));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

    }
}
