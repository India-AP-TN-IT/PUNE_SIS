using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using System.Drawing;
using System;
using System.Data;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>사양정보 > 기준정보 > 공정 마스터 등록</b>
    /// - 작 성 자 : 이명희<br />
    /// - 작 성 일 : 2015-01-07<br />
    /// - 주요 변경 사항
    ///     1) 2015-01-07   이명희 : 최초 클래스 생성<br />
    ///     1) 2015-02-10   김민재 : 공정순서(PROC_SEQ) 추가<br />
    /// </summary>
    public partial class BM20020 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public BM20020()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region[grd01]

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "_사업장코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "_법인코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "_라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "_공정순서", "PROC_SEQ", "PROC_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_공정코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "_공정코드명", "PROCNM", "PROCNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_공정구분", "PROC_DIV", "PROC_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "_공정적용일", "BEG_DATE", "PROC_APP_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "_공정종료일", "END_DATE", "PROC_END_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "_C/T", "PROC_DSGN_TIME", "PROC_DSGN_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "_UPH", "PROC_DSGN_UPH", "PROC_DSGN_UPH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 160, "_인원", "PROC_DSGN_PERSON", "PROC_DSGN_PERSON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_상태", "PROC_STATUS", "PROC_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "_공정 작업내용", "PROC_WORK_DESC", "PROC_WORK_DESC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "_작업대명", "WRKTBLNM", "WRKTBLNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "_수량", "WRKTBL_QTY", "WRKTBL_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "_작업대규격", "WRKTBL_SIZE", "WRKTBL_SIZE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "_전력소모량", "WRKTBL_EP_CONS", "WRKTBL_EP_CONS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "_작업대 중요부품명", "WRKTBL_IMPT_PART", "WRKTBL_IMPT_PART");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "_지그명", "JIGNM", "JIGNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 060, "_수량", "JIG_QTY", "JIG_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "_규격", "JIG_SIZE", "JIG_SIZE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "_지그 중요부품명", "JIG_IMPT_PART", "JIG_IMPT_PART");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "_적재대명", "LODTBLNM", "LODTBLNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 070, "_수량", "LODTBL_QTY", "LODTBL_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "_적재대 규격", "LODTBL_SIZE", "LODTBL_SIZE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 160, "_적재대 전력소모량", "LODTBL_EP_CONS", "LODTBL_EP_CONS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "_적재대 중요부품명", "LODTBL_IMPT_PART", "LODTBL_IMPT_PART");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "_REMARK", "REMARK", "REMARK");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "BV", "PROC_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "BY", "PROC_STATUS");

                this.grd01.Cols["BEG_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.Cols["END_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PROC_DSGN_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PROC_DSGN_UPH");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PROC_DSGN_PERSON");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "WRKTBL_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "WRKTBL_EP_CONS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "JIG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LODTBL_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LODTBL_EP_CONS");

                #endregion

                #region [grd02]

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "사업장", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "코드", "PROCCD", "PROCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "공정코드명", "PROCNM", "PROCNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "공정구분", "PROC_DIV", "PROC_DIV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "공정적용일", "BEG_DATE", "PROC_APP_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "공정폐쇄일", "END_DATE", "PROC_END_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "공정설명", "REMARK", "REMARK");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "BV", "PROC_DIV");

                this.grd02.Cols["BEG_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd02.Cols["END_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                this.cbo03_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo03_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo03_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD")); //new PM21310P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", ""); 
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.cdx02_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD")); //new PM21310P1();
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                                
                this.cdx01_PROCCD.HEPopupHelper = new BM20020P1();
                this.cdx01_PROCCD.NameParameterName = "PROCNM";
                this.cdx01_PROCCD.CodeParameterName = "PROCCD";
                this.cdx01_PROCCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_PROCCD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);

                this.cdx02_PROCCD.HEPopupHelper = new BM20020P1();
                this.cdx02_PROCCD.NameParameterName = "PROCNM";
                this.cdx02_PROCCD.CodeParameterName = "PROCCD";
                this.cdx02_PROCCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_PROCCD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                
                this.cbo01_PROC_DIV.DataBind("BV", true);
                this.cbo01_PROC_STATUS.DataBind("BY", true);

                this.txt01_PROC_WORK_DESC.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_WRKTBLNM.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_WRKTBL_SIZE.SetValid(33, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_WRKTBL_IMPT_PART.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_JIGNM.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_JIG_SIZE.SetValid(33, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_JIG_IMPT_PART.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_LODTBLNM.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_LODTBL_SIZE.SetValid(33, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_LODTBL_IMPT_PART.SetValid(66, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);
                this.txt01_REMARK.SetValid(133, Ax.DEV.Utility.Controls.AxTextBox.TextType.Default);

                this.cbo02_PROC_DIV.DataBind("BV", false);

                this.lbl04_PROCCD.Visible = false;
                this.txt02_PROCCD.Visible = false;
                this.lbl04_PROCNM.Visible = false;
                this.txt02_PROCNM.Visible = false;

                this.dte01_END_DATE.SetValue("9998-12-31");
                this.dte02_END_DATE.SetValue("9998-12-31");

                this.SetRequired(this.lbl02_LINECD, this.lbl02_PROCCD, this.lbl03_PROCCD, this.lbl02_PROCNM, this.lbl02_PROC_SEQ);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        DataSet source = this.GetDataSourceSchema(
                                        "CORCD",
                                        "BIZCD",
                                        "LINECD",
                                        "PROCCD",
                                        "PROC_DIV",
                                        "BEG_DATE",
                                        "END_DATE",
                                        "PROC_DSGN_TIME",
                                        "PROC_DSGN_UPH",
                                        "PROC_DSGN_PERSON",
                                        "PROC_STATUS",
                                        "PROC_WORK_DESC",
                                        "WRKTBLNM",
                                        "WRKTBL_QTY",
                                        "WRKTBL_SIZE",
                                        "WRKTBL_EP_CONS",
                                        "WRKTBL_IMPT_PART",
                                        "JIGNM",
                                        "JIG_QTY",
                                        "JIG_SIZE",
                                        "JIG_IMPT_PART",
                                        "LODTBLNM",
                                        "LODTBL_QTY",
                                        "LODTBL_SIZE",
                                        "LODTBL_EP_CONS",
                                        "LODTBL_IMPT_PART",
                                        "REMARK",
                                        "PROC_SEQ");

                        source.Tables[0].Rows.Add(
                            this.UserInfo.CorporationCode,
                            this.UserInfo.BusinessCode,
                            this.cdx02_LINECD.GetValue(),
                            this.cdx02_PROCCD.GetValue(),
                            this.cbo01_PROC_DIV.GetValue(),
                            this.dte01_BEG_DATE.GetDateText(),
                            this.dte01_END_DATE.GetDateText(),
                            this.nme01_PROC_DSGN_TIME.GetDBValue(),
                            this.nme01_PROC_DSGN_UPH.GetDBValue(),
                            this.nme01_PROC_DSGN_PERSON.GetDBValue(),
                            this.cbo01_PROC_STATUS.GetValue(),
                            this.txt01_PROC_WORK_DESC.GetValue(),
                            this.txt01_WRKTBLNM.GetValue(),
                            this.nme01_WRKTBL_QTY.GetDBValue(),
                            this.txt01_WRKTBL_SIZE.GetValue(),
                            this.nme01_WRKTBL_EP_CONS.GetDBValue(),
                            this.txt01_WRKTBL_IMPT_PART.GetValue(),
                            this.txt01_JIGNM.GetValue(),
                            this.nme01_JIG_QTY.GetDBValue(),
                            this.txt01_JIG_SIZE.GetValue(),
                            this.txt01_JIG_IMPT_PART.GetValue(),
                            this.txt01_LODTBLNM.GetValue(),
                            this.nme01_LODTBL_QTY.GetDBValue(),
                            this.txt01_LODTBL_SIZE.GetValue(),
                            this.nme01_LODTBL_EP_CONS.GetDBValue(),
                            this.txt01_LODTBL_IMPT_PART.GetValue(),
                            this.txt01_REMARK.GetValue(),
                            this.nme02_PROC_SEQ.GetDBValue());

                        if (!IsSaveValid(source.Tables[0].Rows[0])) return;

                        this.BeforeInvokeServer(true);
                        _WSCOM.ExecuteNonQueryTx("APG_BM20020.INSERT_PROC", source);
                        this.AfterInvokeServer();

                        //this.BtnReset_Click(null, null);
                        this.BtnQuery_Click(null, null);

                        //MsgBox.Show("입력하신 공정별 용기 정보가 저장되었습니다");
                        MsgCodeBox.Show("CD00-0009"); 
                        break;
                    case 1:
                        //BM0360 공정마스터 - 저장
                        //법인코드,사업장코드,공정코드,공정명,시작일,종료일,공정구분,비고
                        DataSet source2 = AxFlexGrid.GetDataSourceSchema(
                            "CORCD", "BIZCD", "PROCCD", "PROCNM", "BEG_DATE", "END_DATE", "PROC_DIV", "REMARK");

                        source2.Tables[0].Rows.Add(
                            this.UserInfo.CorporationCode,
                            this.cbo03_BIZCD.GetValue().ToString(),
                            this.txt01_PROCCD.GetValue().ToString(),
                            this.txt01_PROCNM.GetValue().ToString(),
                            this.dte02_BEG_DATE.GetDateText().ToString(),
                            this.dte02_END_DATE.GetDateText().ToString(),
                            this.cbo02_PROC_DIV.GetValue().ToString(),
                            this.txt02_REMARK.GetValue().ToString()
                        );

                        if (!IsProcMasterSaveValid(source2)) return;

                        this.BeforeInvokeServer(true);
                        _WSCOM.ExecuteNonQueryTx("APG_BM20020.SAVE_PROCMASTER", source2);
                        this.AfterInvokeServer();

                        //this.BtnReset_Click(null, null);
                        this.BtnQuery_Click(null, null);

                        MsgCodeBox.Show("CD00-0009"); 
                        break;
                    default:
                        break;
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = null;

                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        HEParameterSet paramSet = new HEParameterSet();

                        paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                        paramSet.Add("BIZCD", cbo02_BIZCD.GetValue().ToString());
                        paramSet.Add("LINECD", cdx02_LINECD.GetValue());
                        paramSet.Add("PROCCD", cdx02_PROCCD.GetValue());
                        paramSet.Add("PROC_SEQ", this.nme02_PROC_SEQ.GetDBValue());

                        if (!IsRemoveValid(paramSet)) return;

                        BeforeInvokeServer(true);
                        _WSCOM.ExecuteNonQueryTx("APG_BM20020.REMOVE_PROC", paramSet);
                        this.AfterInvokeServer();

                        //MsgBox.Show("선택하신 공정별 용기 정보가 삭제되었습니다");
                        MsgCodeBox.Show("CD00-0010"); 
                        this.BtnReset_Click(null, null);

                        this.BtnQuery_Click(null, null);

                        break;
                    case 1:
                        source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "PROCCD");

                        source.Tables[0].Rows.Add(
                            this.UserInfo.CorporationCode,
                            this.cbo03_BIZCD.GetValue().ToString(),
                            this.txt01_PROCCD.GetValue().ToString());

                        if (!IsProcMasterDeleteValid(source)) return;

                        this.BeforeInvokeServer(true);
                        _WSCOM.ExecuteNonQueryTx("APG_BM20020.REMOVE_PROCMASTER", source);
                        this.AfterInvokeServer();

                        MsgCodeBox.Show("CD00-0010");

                        this.BtnReset_Click(null, null);

                        this.BtnQuery_Click(null, null);
                        break;
                    default:
                        break;
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet;
                DataSet source = null;

                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                        paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                        paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                        paramSet.Add("PROCCD", this.cdx01_PROCCD.GetValue().ToString());

                        this.BeforeInvokeServer(true);
                        source = _WSCOM.ExecuteDataSet("APG_BM20020.INQUERY_DETAIL", paramSet);
                        this.AfterInvokeServer();

                        this.grd01.SetValue(source);
                        this.ShowDataCount(source);
                        break;
                    case 1:
                        paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                        paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                        paramSet.Add("PROCCD", this.txt02_PROCCD.GetValue().ToString());
                        paramSet.Add("PROCNM", this.txt02_PROCNM.GetValue().ToString());

                        this.BeforeInvokeServer(true);
                        source = _WSCOM.ExecuteDataSet("APG_BM20020.INQUERY_PROCMASTER", paramSet);
                        this.AfterInvokeServer();

                        this.grd02.SetValue(source);
                        this.ShowDataCount(source);
                        break;
                    default:
                        break;
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();

                        this.cbo01_BIZCD.Initialize();
                        this.cdx01_LINECD.Initialize();
                        this.cdx01_PROCCD.Initialize();

                        this.cbo02_BIZCD.Initialize();
                        this.cbo02_BIZCD.SetReadOnly(false);
                        this.cdx02_LINECD.Initialize();
                        this.cdx02_LINECD.SetReadOnly(false);
                        this.cdx02_PROCCD.Initialize();
                        this.cdx02_PROCCD.SetReadOnly(false);

                        this.cbo01_PROC_DIV.Initialize();
                        this.dte01_BEG_DATE.Initialize();
                        this.dte01_END_DATE.SetValue("9998-12-31");
                        this.nme01_PROC_DSGN_TIME.Initialize();
                        this.nme01_PROC_DSGN_UPH.Initialize();
                        this.nme01_PROC_DSGN_PERSON.Initialize();
                        this.cbo01_PROC_STATUS.Initialize();
                        this.txt01_PROC_WORK_DESC.Initialize();
                        this.txt01_WRKTBLNM.Initialize();
                        this.nme01_WRKTBL_QTY.Initialize();
                        this.txt01_WRKTBL_SIZE.Initialize();
                        this.nme01_WRKTBL_EP_CONS.Initialize();
                        this.txt01_WRKTBL_IMPT_PART.Initialize();
                        this.txt01_JIGNM.Initialize();
                        this.nme01_JIG_QTY.Initialize();
                        this.txt01_JIG_SIZE.Initialize();
                        this.txt01_JIG_IMPT_PART.Initialize();
                        this.txt01_LODTBLNM.Initialize();
                        this.nme01_LODTBL_QTY.Initialize();
                        this.txt01_LODTBL_SIZE.Initialize();
                        this.nme01_LODTBL_EP_CONS.Initialize();
                        this.txt01_LODTBL_IMPT_PART.Initialize();
                        this.txt01_REMARK.Initialize();

                        this.nme02_PROC_SEQ.SetValue("");
                        break;
                    case 1:
                        this.grd02.InitializeDataSource();

                        this.cbo01_BIZCD.Initialize();
                        this.txt02_PROCCD.Initialize();
                        this.txt02_PROCNM.Initialize();

                        this.cbo03_BIZCD.Initialize();
                        this.txt01_PROCCD.Initialize();
                        this.txt01_PROCCD.SetReadOnly(false);
                        this.txt01_PROCNM.Initialize();
                        this.cbo02_PROC_DIV.Initialize();
                        this.dte02_BEG_DATE.Initialize();
                        this.dte02_END_DATE.SetValue("9998-12-31");
                        this.txt02_REMARK.Initialize();

                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsProcMasterSaveValid(DataSet source)
        {
            try
            {
                DataRow row = source.Tables[0].Rows[0];

                string strProcCD = row["PROCCD"].ToString();    //공정코드
                string strProcNM = row["PROCNM"].ToString();    //공정명

                if (this.GetByteCount(strProcCD) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0080", lbl03_PROCCD.GetValue());
                    return false;
                }

                if (this.GetByteCount(strProcCD) > 6)
                {
                    MsgCodeBox.ShowFormat("CD00-0081", lbl03_PROCCD.GetValue(), "6");
                    return false;
                }

                if (this.GetByteCount(strProcNM) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0080", lbl02_PROCNM.GetValue());
                    return false;
                }

                if (this.GetByteCount(strProcNM) > 200)
                {
                    MsgCodeBox.ShowFormat("CD00-0081", lbl02_PROCNM.GetValue(), "200");
                    return false;
                }

                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsProcMasterDeleteValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 데이터가 없습니다.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            HEParameterSet paramSet = null;
            foreach (DataRow row in source.Tables[0].Rows)
            {
                paramSet = new HEParameterSet();
                foreach (DataColumn col in source.Tables[0].Columns)
                {
                    paramSet.Add(col.ColumnName, row[col]);
                }

                DataSet ds = _WSCOM.ExecuteDataSet("APG_BM20020.CHECK_REMOVE_PROC", paramSet);
                if (ds.Tables[0].Rows.Count > 0)
                    return false;
            }

            //if (MsgBox.Show("선택하신 용기정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
            if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
                return false;
            return true;
        }

        private bool IsSaveValid(DataRow set)
        {
            if (set["PROC_SEQ"].ToString().Length == 0)
            {
                //공정순서 값은 0보다 커야합니다.
                MsgCodeBox.ShowFormat("BM00-014", this.lbl02_PROC_SEQ.Text);
                return false;
            }

            if (set["LINECD"].ToString().Length == 0)
            {
                //MsgBox.Show("공정을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0080", lbl01_LINECD.GetValue());
                return false;
            }

            if (set["PROCCD"].ToString().Length == 0)
            {
                //MsgBox.Show("공정을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0080", lbl01_PROCCD.GetValue());
                return false;
            }

            if (set["REMARK"].ToString().Length > 500)
            {
                //MsgBox.Show("용기를 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0081", lbl01_REMARK.GetValue(), "500");
                return false;
            }

            //if(MsgBox.Show("입력하신 공정 용기정보를 저장하시겠습니까?","주의",MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
                return false;
            return true;
        }

        private bool IsRemoveValid(HEParameterSet set)
        {
            if (set["LINECD"].ToString().Length == 0)
            {
                //MsgBox.Show("공정을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0080", lbl01_LINECD.GetValue());
                return false;
            }

            if (set["PROCCD"].ToString().Length == 0)
            {
                //MsgBox.Show("공정을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0080", lbl01_PROCCD.GetValue());
                return false;
            }

            //if (MsgBox.Show("선택하신 공정 용기정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]
        
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.Row;

                if (row < 1)
                {
                    MsgCodeBox.Show("CD00-0039");//MsgBox.Show("조회된 데이터가 없습니다.");
                    return;
                }

                this.cdx02_LINECD.SetValue(grd01[row, "LINECD"].ToString());
                this.cdx02_LINECD.SetReadOnly(true);
                this.cdx02_PROCCD.SetValue(grd01[row, "PROCCD"].ToString());
                this.cdx02_PROCCD.SetReadOnly(true);

                this.cbo01_PROC_DIV.SetValue(this.grd01.SelectedDataRow["PROC_DIV"]);
                this.dte01_BEG_DATE.SetValue(this.grd01.SelectedDataRow["BEG_DATE"]);
                this.dte01_END_DATE.SetValue(this.grd01.SelectedDataRow["END_DATE"]);
                this.nme01_PROC_DSGN_TIME.SetValue(this.grd01.SelectedDataRow["PROC_DSGN_TIME"]);
                this.nme01_PROC_DSGN_UPH.SetValue(this.grd01.SelectedDataRow["PROC_DSGN_UPH"]);
                this.nme01_PROC_DSGN_PERSON.SetValue(this.grd01.SelectedDataRow["PROC_DSGN_PERSON"]);
                this.cbo01_PROC_STATUS.SetValue(this.grd01.SelectedDataRow["PROC_STATUS"]);
                this.txt01_PROC_WORK_DESC.SetValue(this.grd01.SelectedDataRow["PROC_WORK_DESC"]);
                this.txt01_WRKTBLNM.SetValue(this.grd01.SelectedDataRow["WRKTBLNM"]);
                this.nme01_WRKTBL_QTY.SetValue(this.grd01.SelectedDataRow["WRKTBL_QTY"]);
                this.txt01_WRKTBL_SIZE.SetValue(this.grd01.SelectedDataRow["WRKTBL_SIZE"]);
                this.nme01_WRKTBL_EP_CONS.SetValue(this.grd01.SelectedDataRow["WRKTBL_EP_CONS"]);
                this.txt01_WRKTBL_IMPT_PART.SetValue(this.grd01.SelectedDataRow["WRKTBL_IMPT_PART"]);
                this.txt01_JIGNM.SetValue(this.grd01.SelectedDataRow["JIGNM"]);
                this.nme01_JIG_QTY.SetValue(this.grd01.SelectedDataRow["JIG_QTY"]);
                this.txt01_JIG_SIZE.SetValue(this.grd01.SelectedDataRow["JIG_SIZE"]);
                this.txt01_JIG_IMPT_PART.SetValue(this.grd01.SelectedDataRow["JIG_IMPT_PART"]);
                this.txt01_LODTBLNM.SetValue(this.grd01.SelectedDataRow["LODTBLNM"]);
                this.nme01_LODTBL_QTY.SetValue(this.grd01.SelectedDataRow["LODTBL_QTY"]);
                this.txt01_LODTBL_SIZE.SetValue(this.grd01.SelectedDataRow["LODTBL_SIZE"]);
                this.nme01_LODTBL_EP_CONS.SetValue(this.grd01.SelectedDataRow["LODTBL_EP_CONS"]);
                this.txt01_LODTBL_IMPT_PART.SetValue(this.grd01.SelectedDataRow["LODTBL_IMPT_PART"]);
                this.txt01_REMARK.SetValue(this.grd01.SelectedDataRow["REMARK"]);
                this.nme02_PROC_SEQ.SetValue(this.grd01.SelectedDataRow["PROC_SEQ"]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = this.grd02.Row;

            if (row < 1)
            {
                MsgCodeBox.Show("CD00-0039");//MsgBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            this.txt01_PROCCD.SetValue(grd02[row, "PROCCD"].ToString());
            this.txt01_PROCNM.SetValue(grd02[row, "PROCNM"].ToString());
            this.dte02_BEG_DATE.SetValue(grd02[row, "BEG_DATE"].ToString());
            this.dte02_END_DATE.SetValue(grd02[row, "END_DATE"].ToString());
            this.cbo02_PROC_DIV.SetValue(grd02[row, "PROC_DIV"].ToString());

            this.txt01_PROCCD.SetReadOnly(true);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.lbl01_LINECD.Visible = true;
                        this.cdx01_LINECD.Visible = true;
                        this.lbl01_PROCCD.Visible = true;
                        this.cdx01_PROCCD.Visible = true;
                        this.lbl04_PROCCD.Visible = false;
                        this.txt02_PROCCD.Visible = false;
                        this.lbl04_PROCNM.Visible = false;
                        this.txt02_PROCNM.Visible = false;
                        break;
                    case 1:
                        this.lbl01_LINECD.Visible = false;
                        this.cdx01_LINECD.Visible = false;
                        this.lbl01_PROCCD.Visible = false;
                        this.cdx01_PROCCD.Visible = false;
                        this.lbl04_PROCCD.Visible = true;
                        this.txt02_PROCCD.Visible = true;
                        this.lbl04_PROCNM.Visible = true;
                        this.txt02_PROCNM.Visible = true;
                        break;
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
