#region ▶ Description & History
/* 
* 프로그램명 : PD20080 완/반제품 계측 기준 정보 관리-사출SPC
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 완/반제품 계측 기준정보 관리
    /// </summary>
    public partial class PD20030 : AxCommonBaseControl
    {
        
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20030";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";


        private AxComboList grd_LINECD;
        private AxComboList grd_PROCCD;
        private AxComboList grd_PARTNO;
        private AxComboList grd_INSPEC_DIV;
        private AxComboList grd_INSPEC_ITEMCD;

        public PD20030()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20030>("PD", "PD20030.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            this.grd_LINECD = new AxComboList();
            this.grd_PROCCD = new AxComboList();
            this.grd_PARTNO = new AxComboList();
            this.grd_INSPEC_DIV = new AxComboList();
            this.grd_INSPEC_ITEMCD = new AxComboList();
        }
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
               

                this.grd_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_LINECD_BeforeOpen);
                this.grd_LINECD.SelectedValueChanged += new EventHandler(grd_LINECD_SelectedValueChanged);
                this.grd_PROCCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PROCCD_BeforeOpen);
                this.grd_PROCCD.SelectedValueChanged += new EventHandler(grd_PROCCD_SelectedValueChanged);
                this.grd_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PARTNO_BeforeOpen);
                this.grd_INSPEC_DIV.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_INSPEC_DIV_BeforeOpen);
                this.grd_INSPEC_DIV.SelectedValueChanged += new EventHandler(grd_INSPEC_DIV_SelectedValueChanged);
                this.grd_INSPEC_ITEMCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_INSPEC_ITEMCD_BeforeOpen);
                this.grd_INSPEC_ITEMCD.SelectedValueChanged += new EventHandler(grd_INSPEC_ITEMCD_SelectedValueChanged);

                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "코드", "LINECD", "LINECD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "명칭", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "명칭", "PROCNM", "PROCNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "코드", "INSPEC_DIV", "INSPEC_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "명칭", "INSPEC_DIVNM", "INSPEC_DIVNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "코드", "INSPEC_ITEMCD", "INSPEC_ITEMCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 190, "명칭", "INSPEC_ITEMNM", "INSPEC_ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "위치", "INSPEC_POS", "INSPEC_POS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 190, "명칭", "INSPEC_POSNM", "INSPEC_POSNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "표준값", "STD_VALUE", "STD_VALUE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "상한값", "MAX_VALUE", "MAX_VALUE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "하한값", "MIN_VALUE", "MIN_VALUE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "CAVITY", "CAVITY", "CAVITY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "STD_VALUE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "MAX_VALUE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "MIN_VALUE");

                this.grd01.Cols["STD_VALUE"].Format = "#########0.00000";
                this.grd01.Cols["MAX_VALUE"].Format = "#########0.00000";
                this.grd01.Cols["MIN_VALUE"].Format = "#########0.00000";

                this.grd01.Cols["LINENM"].Editor = this.grd_LINECD;
                this.grd01.Cols["PROCNM"].Editor = this.grd_PROCCD;
                this.grd01.Cols["PARTNO"].Editor = this.grd_PARTNO;
                this.grd01.Cols["INSPEC_DIVNM"].Editor = this.grd_INSPEC_DIV;
                this.grd01.Cols["INSPEC_ITEMNM"].Editor = this.grd_INSPEC_ITEMCD;

                #region [Grid Merge]

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "STD_VALUE", "STD_VALUE");
                this.grd01.AddMerge(0, 1, "MAX_VALUE", "MAX_VALUE");
                this.grd01.AddMerge(0, 1, "MIN_VALUE", "MIN_VALUE");
                this.grd01.AddMerge(0, 1, "CAVITY", "CAVITY");

                this.grd01.AddMerge(0, 0, "INSPEC_DIV", "INSPEC_DIVNM");
                this.grd01.SetHeadTitle(0, "INSPEC_DIV", this.GetLabel("INSPECTION_TYPE"));     //계측유형

                this.grd01.AddMerge(0, 0, "INSPEC_ITEMCD", "INSPEC_ITEMNM");
                this.grd01.SetHeadTitle(0, "INSPEC_ITEMCD", this.GetLabel("INSPEC_ITEMCD"));    //계측항목

                this.grd01.AddMerge(0, 0, "INSPEC_POS", "INSPEC_POSNM");
                this.grd01.SetHeadTitle(0, "INSPEC_POS", this.GetLabel("INSPEC_POS"));  //계측포인트

                this.grd01.AddMerge(0, 0, "LINECD", "LINENM");
                this.grd01.SetHeadTitle(0, "LINECD", this.GetLabel("LINE"));    //라인

                this.grd01.AddMerge(0, 0, "PROCCD", "PROCNM");
                this.grd01.SetHeadTitle(0, "PROCCD", this.GetLabel("PROCINFO")); //공정




                #endregion

                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.EnabledActionFlag = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, this.GetLabel("E_ALCCD"), "ALCCD", "ALCCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, this.GetLabel("CHK"), "CHECKED", "CHECKED");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C,  60, "CAVITY", "CAVITY", "CAVITY");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHECKED");

                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);

                #region

                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECDIV"), set).Tables[0];
                //DataTable source1 = _WSCOM_MES.INQUERY_COMBO_INSPECDIV(bizcd, set).Tables[0];

                #endregion

                this.cbl01_INSPEC_DIV.DataBind(source1, this.GetLabel("OBJECTID") + ";" + this.GetLabel("INSPEC_DIV_NM"), "C;L");
                this.cbl04_INSPEC_DIV.DataBind(source1, this.GetLabel("OBJECTID") + ";" + this.GetLabel("INSPEC_DIV_NM"), "C;L");   //유형코드;계측유형명

                this.SetRequired(lbl04_LINECD, lbl04_INSPEC_DIV, lbl04_INSPEC_ITEMCD, lbl04_INSPEC_POS, lbl04_INSPEC_POSNM, lbl04_MAX_VALUE, lbl04_MIN_VALUE, lbl04_STD_VALUE);

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
                if (this.tab_tabPage2.SelectedIndex == 1)
                {
                    this.cbl04_INSPEC_DIV.Initialize();
                    this.txt04_INSPEC_POSNM.Initialize();
                    this.nme04_INSPEC_POS.Initialize();
                    this.nme04_STD_VALUE.Initialize();
                    this.nme04_MAX_VALUE.Initialize();
                    this.nme04_MIN_VALUE.Initialize();
                }
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
                if (this.tab_tabPage2.SelectedIndex == 0)
                {
                    string bizcd = this.UserInfo.BusinessCode;

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("LINECD", this.cbl01_LINECD.GetValue());
                    set.Add("PARTNO", this.cbl01_PARTNO.GetValue());
                    set.Add("INSPEC_DIV", this.cbl01_INSPEC_DIV.GetValue());
                    set.Add("INSPEC_ITEMCD", this.cbl01_INSPEC_ITEMCD.GetValue());

                    HEParameterSet set2 = new HEParameterSet();
                    set2.Add("CORCD", this.UserInfo.CorporationCode);
                    set2.Add("BIZCD", bizcd);
                    set2.Add("PARTNO", this.cbl01_LINECD.GetValue().ToString().Equals("") ? this.txt_PARTNO.GetValue() : this.cbl01_PARTNO.GetValue());
                    set2.Add("INSPEC_DIV", this.cbl01_INSPEC_DIV.GetValue());
                    set2.Add("INSPEC_ITEMCD", this.cbl01_INSPEC_ITEMCD.GetValue());
                    set2.Add("LINECD", this.cbl01_LINECD.GetValue());
                    set2.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet dsResult = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_NEW"), set2, "OUT_CURSOR");

                    //dsResult.Tables[0].Columns.Add("LINENM");
                    dsResult.Tables[0].Columns.Add("PROCNM");

                    DataSet ds2 = new DataSet();

                    HEParameterSet set1 = new HEParameterSet();

                    set1.Add("CORCD", set.Items["CORCD"].Value.ToString());
                    set1.Add("BIZCD", set.Items["BIZCD"].Value.ToString());
                    
                    //ds2.Tables.Add(_DACCOM_ERM.INQUERY_PROC(set1).Tables[0].Copy());
                    ds2.Tables.Add(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PROC"), set1, "OUT_CURSOR").Tables[0].Copy());
                    ds2.Tables[0].TableName = "PROCCD";

                    for (int i = dsResult.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dsResult.Tables[0].Rows[i];
                        dr["PROCNM"] = ds2.Tables[0].Select("PROCCD='" + dr["PROCCD"].ToString() + "'").Length != 0 ? ds2.Tables[0].Select("PROCCD='" + dr["PROCCD"].ToString() + "'")[0]["PROCNM"] : "";
                    }

                    this.AfterInvokeServer();

                    this.grd01.SetValue(dsResult.Tables[0]);
                }
                else
                {
                    string bizcd = this.UserInfo.BusinessCode;

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("PARTNO", this.txt03_PARTNO.GetValue());
                    set.Add("LINECD", this.cbl03_LINECD.GetValue());
                    set.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    //DataTable source = _WSCOM.INQUERY_BATCH(bizcd, set).Tables[0];
                    DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_BATCH"), set, "OUT_CURSOR").Tables[0];
                    this.AfterInvokeServer();

                    this.grd02.SetValue(source);
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
                if (this.tab_tabPage2.SelectedIndex == 0)
                {
                    DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "PARTNO", "INSPEC_DIV", "INSPEC_ITEMCD", "INSPEC_POS", "INSPEC_POSNM", "LINECD", "PROCCD", "MAX_VALUE", "STD_VALUE", "MIN_VALUE", "EMPNO", "BIZCD", "CAVITY");

                    foreach (DataRow row in source.Tables[0].Rows)
                    {
                        row["EMPNO"] = this.UserInfo.EmpNo;
                        row["BIZCD"] = this.UserInfo.BusinessCode;
                    }

                    if (!this.IsSaveValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);


                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                    //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝



                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);

                    //MsgBox.Show("입력하신 완/반제품 계측 기준 정보가 저장되었습니다.");
                    //저장되었습니다.
                    MsgCodeBox.Show("CD00-0071");
                }
                else
                {
                    DataRow[] grd02 = ((DataTable)this.grd02.GetValue()).Select("CHECKED = '1'");

                    string LINECD = this.cbl04_LINECD.GetValue().ToString();
                    string INSPEC_DIV = this.cbl04_INSPEC_DIV.GetValue().ToString();
                    string INSPEC_ITEMCD = this.cbl04_INSPEC_ITEMCD.GetValue().ToString();
                    string INSPEC_POS = this.nme04_INSPEC_POS.GetDBValue().ToString();
                    string INSPEC_POSNM = this.txt04_INSPEC_POSNM.GetValue().ToString();
                    string MAX_VALUE = this.nme04_MAX_VALUE.GetDBValue().ToString();
                    string STD_VALUE = this.nme04_STD_VALUE.GetDBValue().ToString();
                    string MIN_VALUE = this.nme04_MIN_VALUE.GetDBValue().ToString();
                    string PROCCD = this.cbl04_PROCCD.GetValue().ToString();
                    string BIZCD = UserInfo.BusinessCode;
                    DataSet source = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CORCD");
                    dt.Columns.Add("PARTNO");
                    dt.Columns.Add("INSPEC_DIV");
                    dt.Columns.Add("INSPEC_ITEMCD");
                    dt.Columns.Add("INSPEC_POS");
                    dt.Columns.Add("INSPEC_POSNM");
                    dt.Columns.Add("LINECD");
                    dt.Columns.Add("PROCCD");
                    dt.Columns.Add("MAX_VALUE");
                    dt.Columns.Add("STD_VALUE");
                    dt.Columns.Add("MIN_VALUE");
                    dt.Columns.Add("EMPNO");
                    dt.Columns.Add("BIZCD");
                    dt.Columns.Add("CAVITY");
                    /*
                     * IN_CORCD           IN  VARCHAR2,
        IN_PARTNO           IN  VARCHAR2,
        IN_INSPEC_DIV           IN  VARCHAR2,
        IN_INSPEC_ITEMCD           IN  VARCHAR2,
        IN_INSPEC_POS           IN  VARCHAR2,
        IN_INSPEC_POSNM         IN  VARCHAR2,
        IN_LINECD           IN  VARCHAR2,
        IN_PROCCD           IN  VARCHAR2,
        IN_MAX_VALUE           IN  VARCHAR2,
        IN_STD_VALUE           IN  VARCHAR2,
        IN_MIN_VALUE           IN  VARCHAR2,
        IN_EMPNO           IN  VARCHAR2,
        IN_BIZCD           IN  VARCHAR2
                     */
                    source.Tables.Add(dt);

                    foreach (DataRow grd02_row in grd02)
                    {
                        dt.Rows.Add(
                                this.UserInfo.CorporationCode,
                                grd02_row["PARTNO"].ToString(),
                                INSPEC_DIV,
                                INSPEC_ITEMCD,
                                INSPEC_POS,
                                INSPEC_POSNM,
                                LINECD,
                                PROCCD,
                                MAX_VALUE,
                                STD_VALUE,
                                MIN_VALUE,
                                this.UserInfo.EmpNo,
                                BIZCD,
                                grd02_row["CAVITY"].ToString()
                        );
                        System.Diagnostics.Debug.WriteLine("cavity:" + grd02_row["CAVITY"].ToString());
                    }

                    if (!IsSaveBatchValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                    //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝



                    this.AfterInvokeServer();

                    this.tab_tabPage2.SelectedIndex = 0;
                    this.cbl01_LINECD.SetValue(this.cbl03_LINECD.GetValue());

                    this.BtnQuery_Click(null, null);
                    //MsgBox.Show("입력하신 완/반제품 계측 기준 정보가 일괄 저장되었습니다.");
                    //입력하신 정보가 일괄 저장되었습니다.
                    MsgCodeBox.Show("PD00-0006");

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
                if (this.tab_tabPage2.SelectedIndex == 0)
                {

                    DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "PARTNO", "INSPEC_DIV", "INSPEC_ITEMCD", "INSPEC_POS", "BIZCD");
                    foreach (DataRow row in source.Tables[0].Rows)
                    {
                        row["BIZCD"] = this.UserInfo.BusinessCode;
                    }
                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                    //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                    this.AfterInvokeServer();

                    this.BtnReset_Click(null, null);
                    this.BtnQuery_Click(null, null);

                    //if (isSyncOK) MsgBox.Show("선택하신 완/반제품 계측 기준 정보가 삭제되었습니다");
                    //삭제되었습니다.
                    //if (isSyncOK) 
                    MsgCodeBox.Show("CD00-0072");
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

        #region [ 기타 컨트롤 이벤트 ]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];

                this.grd_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "LINECD", this.grd_LINECD.GetValue("LINECD"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PROCCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LINECD", this.grd01.GetValue(row, "LINECD"));
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCLIST"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_PROCLIST(set).Tables[0];
                this.grd_PROCCD.DataBind(source, this.GetLabel("PROCCD") + ";" + this.GetLabel("PROCNM"), "C;L");   //공정코드;공정명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PROCCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "PROCCD", this.grd_PROCCD.GetValue("PROCCD"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "%");
                set.Add("TYPECD", "");
                set.Add("LINECD", this.grd01.GetValue(row, "LINECD").ToString());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_INSPECPARTNO"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_INSPECPARTNO(set).Tables[0];
                this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", this.GetLabel("PARTNOTITLE") + ";" + this.GetLabel("PARTNONM") + ";ALC", "L;L;C"); //품번;품명;ALC
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_INSPEC_DIV_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECDIV"), set).Tables[0];
                //DataTable source1 = _WSCOM_MES.INQUERY_COMBO_INSPECDIV(bizcd, set).Tables[0];
                this.grd_INSPEC_DIV.DataBind(source1, this.GetLabel("OBJECTID") + ";" + this.GetLabel("INSPEC_DIV_NM"), "C;L"); //유형코드;계측유형명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_INSPEC_DIV_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "INSPEC_DIV", this.grd_INSPEC_DIV.GetValue("INSPEC_DIV"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_INSPEC_ITEMCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("INSPEC_DIV", this.grd01.GetValue(row, "INSPEC_DIV"));
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECITEM"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_INSPECITEM(bizcd, set).Tables[0];
                this.grd_INSPEC_ITEMCD.DataBind(source, this.GetLabel("MGRT_EXPNCD") + ";" + this.GetLabel("MGRT_EXPNCD_NM"), "C;L");   //항목코드;계측항목명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_INSPEC_ITEMCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "INSPEC_ITEMCD", this.grd_INSPEC_ITEMCD.GetValue("INSPEC_ITEMCD"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);
                this.lbl01_LINE.Value = this.GetLabel("LINE");  //라인

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];

                this.cbl01_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); // 라인코드;라인명

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "%");
                set.Add("TYPECD", "");
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_INSPECPARTNO"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_INSPECPARTNO(set).Tables[0];
                this.cbl01_PARTNO.DataBind(source, "PARTNO", "PARTNO", this.GetLabel("PARTNOTITLE") + ";" + this.GetLabel("PARTNONM") + ";ALC", "L;L;C");   //품번;품명;ALC
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_INSPEC_ITEM_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("INSPEC_DIV", this.cbl01_INSPEC_DIV.GetValue());
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECITEM"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_INSPECITEM(bizcd, set).Tables[0];

                this.cbl01_INSPEC_ITEMCD.DataBind(source, this.GetLabel("MGRT_EXPNCD") + ";" + this.GetLabel("MGRT_EXPNCD_NM"), "C;L"); //항목코드;계측항목명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl03_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                this.cbl03_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl03_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lbl03_LINECD.Value.Equals(this.GetLabel("LINE")))  //라인
                    this.cbl04_LINECD.SetValue(this.cbl03_LINECD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl04_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl03_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl04_PROCCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LINECD", this.cbl04_LINECD.GetValue());
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCLIST"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_PROCLIST(set).Tables[0];
                this.cbl04_PROCCD.DataBind(source, this.GetLabel("PROCCD") + ";" + this.GetLabel("PROCNM"), "C;L"); //공정코드;공정명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl04_INSPEC_ITEM_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("INSPEC_DIV", this.cbl04_INSPEC_DIV.GetValue());
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECITEM"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_INSPECITEM(bizcd, set).Tables[0];
                this.cbl04_INSPEC_ITEMCD.DataBind(source, this.GetLabel("MGRT_EXPNCD") + ";" + this.GetLabel("MGRT_EXPNCD_NM"), "C;L"); //항목코드;계측항목명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk04_CHECK_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    //this.grd02.SetValue(i, "CHECKED", this.chk04_CHECK.GetValue().Equals("Y") ? "True" : "False");
                    this.grd02.SetValue(i, "CHECKED", this.chk04_CHECK.Checked);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Partno Box 변경 (LINECD 선택시 콤보BOX / 미선택시 TEXT BOX)
                change_PartnoBox();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void change_PartnoBox()
        {
            try
            {
                if (cbl01_LINECD.GetValue().ToString().Equals(""))
                {
                    txt_PARTNO.Visible = true;
                    cbl01_PARTNO.Visible = false;
                    txt_PARTNO.Value = "";
                    cbl01_PARTNO.Text = "";
                }
                else
                {
                    txt_PARTNO.Visible = false;
                    cbl01_PARTNO.Visible = true;
                    txt_PARTNO.Value = "";
                    cbl01_PARTNO.Text = "";
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 완/반제품 계측 기준 정보가 없습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow row = source.Tables[0].Rows[i];
                    DataRow seq = source.Tables[1].Rows[i];

                    if (this.Nvl(row["LINECD"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {라인}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[2].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["PARTNO"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {PARTNO}가 선택되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[6].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["INSPEC_DIV"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {계층유형}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[7].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["INSPEC_ITEMCD"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {계층항목}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[9].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["INSPEC_POS"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {계측포인트 위치}가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0008", i.ToString(), this.grd01.Cols[11].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["INSPEC_POSNM"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {게측포인트 명칭}이 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0008", i.ToString(), this.grd01.Cols[12].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["MAX_VALUE"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {상한값}이 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0008", i.ToString(), this.grd01.Cols[14].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["STD_VALUE"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {표준값}이 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0008", i.ToString(), this.grd01.Cols[13].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["MIN_VALUE"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {하한값}이 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0008", i.ToString(), this.grd01.Cols[15].Caption.ToString());
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 완/반제품 계측 기준 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveBatchValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장 할 일괄 작업이 없습니다..");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                string LINECD = this.cbl04_LINECD.GetValue().ToString();
                string INSPEC_DIV = this.cbl04_INSPEC_DIV.GetValue().ToString();
                string INSPEC_ITEMCD = this.cbl04_INSPEC_ITEMCD.GetValue().ToString();
                string INSPEC_POS = this.nme04_INSPEC_POS.GetValue().ToString();
                string INSPEC_POSNM = this.txt04_INSPEC_POSNM.GetValue().ToString();
                string MAX_VALUE = this.nme04_MAX_VALUE.GetValue().ToString();
                string STD_VALUE = this.nme04_STD_VALUE.GetValue().ToString();
                string MIN_VALUE = this.nme04_MIN_VALUE.GetValue().ToString();

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show("{라인코드}가 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.grd01.Cols[2].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(INSPEC_DIV) == 0)
                {
                    //MsgBox.Show("{계층유형}이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.grd01.Cols[7].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(INSPEC_ITEMCD) == 0)
                {
                    //MsgBox.Show("{계층항목}이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.grd01.Cols[9].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(INSPEC_POS) == 0)
                {
                    //MsgBox.Show("{계측포인트 위치}가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.grd01.Cols[9].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(INSPEC_POSNM) == 0)
                {
                    //MsgBox.Show("{게측포인트 명칭}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.grd01.Cols[12].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(MAX_VALUE) == 0)
                {
                    //MsgBox.Show("{상한값}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.grd01.Cols[14].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(STD_VALUE) == 0)
                {
                    //MsgBox.Show("{표준값}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.grd01.Cols[13].Caption.ToString());
                    return false;
                }

                if (this.GetByteCount(MIN_VALUE) == 0)
                {
                    //MsgBox.Show("{하한값}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.grd01.Cols[15].Caption.ToString());
                    return false;
                }

                //if (MsgBox.Show("입력하신 완/반제품 계측 기준 정보를 일괄 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 완/반제품 계측 기준 정보가 선택되지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 완/반제품 계측 기준 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //삭제하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [미들서버에 코드정보 전송]
        //2014.02.10 - MES0330 제품 계측 기준 정보 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {

        //        msg = _WSCOM_ERM.SyncMESIF("MES0330", bizcd).Tables[0].Rows[0][0].ToString();
        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0004");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0005");
        //                return false;
        //            }
        //            else
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show(msg);
        //                return false;
        //            }
        //        }

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }

        //    return true;
        //}
        #endregion
    }
}
