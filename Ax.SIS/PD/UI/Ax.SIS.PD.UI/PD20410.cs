#region ▶ Description & History
/* 
 * 프로그램명 : PD20360 팔레트 관리
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			    작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09      배명희         SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using System.Drawing;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>[POP] 완제품 적재대 관리</b>    
    /// </summary>
    public partial class PD20410 : AxCommonBaseControl
    {
        //private IPD20410 _WSCOM;
        private AxClientProxy _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD20410";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        private bool _isLoadCompleted = false;
        private int _MaxRow = 0;

        public PD20410()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20410>("PM00", "PD20410.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y")) 
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_CHK_SEQ.DataBind("Q5");
                this.cbo01_TYPE.DataBind("Q6", false);
                this.dte01_YYYY.SetValue(DateTime.Now);

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);

                //통합WCF
                DataTable source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CARTYPE"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_CARTYPE(set).Tables[0];
                DataTable source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source2 =  _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0];

                //this.cbl01_VINCD.DataBind(source, "TYPECD", "OBJECT_NM", "차종코드;차종명", "C;L"); 
                this.cbl01_VINCD.DataBind(source, "TYPECD", "OBJECT_NM", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L"); //차종코드;차종명
                //this.cbl01_INSTALL_POS.DataBind(source2, "위치코드;POSCD_NM", "C;L");  
                this.cbl01_INSTALL_POS.DataBind(source2, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명

                this.grd01.Initialize(2,2);
                this.grd01.AllowEditing = true;
                this.grd01.AllowSorting = AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "점검차수", "CHK_SEQ", "INSP_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "구분", "TYPE", "TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "PLT NO", "PLT_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "점검 일자", "JOB_DATE", "CHECK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "점검 여부", "INSP_YN", "INSP_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "간지끈", "CHK_INNER_1", "CHK_INNER_1");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "간지", "CHK_INNER_2", "CHK_INNER_2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "캐스터", "CHK_INNER_3", "CHK_INNER_3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "손잡이", "CHK_INNER_4", "CHK_INNER_4");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "청결상태", "CHK_INNER_5", "CHK_INNER_5");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "프레임", "CHK_CORP_1", "CHK_CORP_1");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "프레임 감싸기", "CHK_CORP_2", "CHK_CORP_2"); 
                this.grd01.AddHiddenColumn("YYYY");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetCorCD().Tables[0], "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q5", "CHK_SEQ");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q6", "TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_INNER_1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_INNER_2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_INNER_3");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_INNER_4");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_INNER_5");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_CORP_1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "CHK_CORP_2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q8", "INSP_YN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "JOB_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "YYYY");

                this.grd01.Cols["JOB_DATE"].Format = "yyyy-MM-dd";
                this.grd01.Cols["YYYY"].Format = "yyyy";

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "CHK_SEQ", "CHK_SEQ");
                this.grd01.AddMerge(0, 1, "TYPE", "TYPE");
                this.grd01.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "PLT_NO", "PLT_NO");
                this.grd01.AddMerge(0, 1, "JOB_DATE", "JOB_DATE");
                this.grd01.AddMerge(0, 1, "INSP_YN", "INSP_YN");

                this.grd01.AddMerge(0, 0, "CHK_INNER_1", "CHK_CORP_1");
                this.grd01.SetHeadTitle(0, 0, "CHK_INNER_1", "CHK_CORP_1", this.GetLabel("SELF")); //자체

                this.grd01.AddMerge(0, 0, "CHK_CORP_2", "CHK_CORP_2");
                this.grd01.SetHeadTitle(0, 0, "CHK_CORP_2", "CHK_CORP_2", this.GetLabel("VEND"));//"업체");
                //this.grd01.SetHeadTitle(0, 0, "CHK_CORP_2", "CHK_CORP_2", "업체");

                this.grd02.Initialize();
                this.grd02.AllowEditing = true;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINCD", "VIN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "총수량", "TOT_CNT", "CNT_DELI_TT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "점검수량", "INSP_CNT", "CHECKCOUNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "점검율", "RATE", "INSP_RATE");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "INSP_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "RATE");

                this.grd02.Cols["TOT_CNT"].Format = "###,###,###,###,##0";
                this.grd02.Cols["INSP_CNT"].Format = "###,###,###,###,##0";
                this.grd02.Cols["RATE"].Format = "###,###,###,###,##0.0%";

                CellStyle cs01;
                cs01 = this.grd01.Styles.Add("csColor1");  
                cs01.BackColor = Color.FromArgb(255, 166, 166);
                cs01.ForeColor = Color.Black;

                CellStyle cs02;
                cs02 = this.grd01.Styles.Add("csColor2");
                cs02.BackColor = Color.FromArgb(255, 255, 0);
                cs02.ForeColor = Color.Red;

                this.grd01.RowInserted += new AxFlexGrid.FAlterRowInsertEventHandler(grd01_RowInserted);

                this.SetRequired(this.lbl01_BIZNM, lbl01_YYYY, lbl01_TYPE);

                _isLoadCompleted = true;
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "BIZCD", "YYYY", "JOB_DATE", "CHK_SEQ", "TYPE", "VINCD", "INSTALL_POS", "PLT_NO", 
                    "CHK_INNER_1", "CHK_INNER_2", "CHK_INNER_3", "CHK_INNER_4", "CHK_INNER_5", "CHK_CORP_1", "CHK_CORP_2");

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["YYYY"] = this.dte01_YYYY.GetDateText().Substring(0, 4);
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source, this.cbo01_BIZCD.GetValue().ToString());
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer(); 

                this.BtnQuery_Click(null, null);

                //메세지 코드 처리
                MsgCodeBox.Show("CD00-0009");
                
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "YYYY", "CHK_SEQ", "PLT_NO");

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["YYYY"] = this.dte01_YYYY.GetDateText().Substring(0, 4);
                }

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source, this.cbo01_BIZCD.GetValue().ToString());
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //메세지 코드 처리
                MsgCodeBox.Show("CD00-0010");
                
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
                if (!IsQueryValid())
                    return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("YYYY", this.dte01_YYYY.GetDateText().Substring(0, 4));
                paramSet.Add("TYPE", this.cbo01_TYPE.GetValue().ToString());
                paramSet.Add("VINCD", "A3" + this.cbl01_VINCD.GetValue().ToString());
                paramSet.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue().ToString());
                paramSet.Add("CHK_SEQ", this.cbo01_CHK_SEQ.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet, this.cbo01_BIZCD.GetValue().ToString());
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet, "OUT_CURSOR", "OUT_CURSOR2");
                this.grd01.SetValue(source.Tables[0]);
                this.grd02.SetValue(source.Tables[1]);

                _MaxRow = this.grd01.Rows.Count - this.grd01.Rows.Fixed + 1;

                CellRange cr = new CellRange();

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    if (this.grd01.Rows[i]["INSP_YN"].ToString() == "Q801")
                    {
                        cr = this.grd01.GetCellRange(i, this.grd01.Cols["INSP_YN"].Index, i, this.grd01.Cols["INSP_YN"].Index);
                        cr.Style = this.grd01.Styles["csColor1"];
                    }
                    else if(this.grd01.Rows[i]["INSP_YN"].ToString() == "Q802")
                    {
                        cr = this.grd01.GetCellRange(i, this.grd01.Cols["INSP_YN"].Index, i, this.grd01.Cols["INSP_YN"].Index);
                        cr.Style = this.grd01.Styles["csColor2"];
                    }
                }
                ShowDataCount(source);

                grid01_SetColumns();
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
                this.grd01.InitializeDataSource();
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

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                if (GetByteCount(this.cbo01_BIZCD.GetValue().ToString()) == 0 || GetByteCount(this.cbo01_TYPE.GetValue().ToString()) == 0
                     || GetByteCount(this.cbl01_VINCD.GetValue().ToString()) == 0 || GetByteCount(this.cbl01_INSTALL_POS.GetValue().ToString()) == 0 ||
                     GetByteCount(this.cbo01_CHK_SEQ.GetValue().ToString()) == 0)
                {
                    //메세지 코드 처리
                    MsgCodeBox.Show("PD00-0040");

                    //this.grd01.Rows.Remove(args.RowIndex);
                    this.BtnQuery_Click(null, null);
                    return;
                }


                for (int i = 0; i < args.RowCount; i++)
                {
                    //신규행 추가시 기본 값 설정
                    this.grd01.SetValue(args.RowIndex + i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(args.RowIndex + i, "BIZCD", this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, "YYYY", this.dte01_YYYY.GetDateText().Substring(0, 4));
                    this.grd01.SetValue(args.RowIndex + i, "TYPE", this.cbo01_TYPE.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, "VINCD", "A3" + this.cbl01_VINCD.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, "INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, "CHK_SEQ", this.cbo01_CHK_SEQ.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, "PLT_NO", _MaxRow + i);
                }

                _MaxRow = this.grd01.Rows.Count - this.grd01.Rows.Fixed + 1;
                /*
                int cnt = 0;
                HEFlexGrid grd = (HEFlexGrid)sender;
                //행 추가 1개이상 못하도록
                for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                {
                    if (grd[i, 0].ToString() == "N")
                    {
                        cnt++;
                    }
                }

                int idx = cnt;
                int MaxPlt_No = 0;

                if (cnt > 1)
                {
                    for (int i = grd.Rows.Count - 1; i >= grd.Rows.Fixed; i--)
                    {
                        if (grd[i, 0].ToString() == "N")
                        {
                            if (idx > 1)
                            {
                                grd.Rows.Remove(i);
                                idx--;
                            }
                        }
                        else
                        {
                            if (grd[i, 0].ToString() != "N")
                            {
                                if (MaxPlt_No < Convert.ToInt32(grd.Rows[i]["PLT_NO"].ToString()))
                                    MaxPlt_No = Convert.ToInt32(grd.Rows[i]["PLT_NO"].ToString());
                            }
                        }
                    }
                    
                    for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                    {
                        if (grd[i, 0].ToString() == "N")
                        {
                            grd.SetValue(i, "PLT_NO", MaxPlt_No + 1);
                        }
                    }
                }
                */
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted == true)
            {
                string strEventName = "";
                strEventName = ((ComboBox)(sender)).Name;

                if (GetByteCount(strEventName) > 0)
                {
                    BtnQuery_Click(null, null);
                }
            }
        }

        private void dte01_JOB_DATE_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted == true)
            {
                string strEventName = "";
                strEventName = ((AxDateEdit)(sender)).Name;

                if (GetByteCount(strEventName) > 0)
                {
                    BtnQuery_Click(null, null);
                }
            }
        }

        private void cbl01_VINCD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted == true)
            {
                string strEventName = "";

                strEventName = ((AxComboList)(sender)).Name;

                if (GetByteCount(strEventName) > 0)
                {
                    BtnQuery_Click(null, null);
                }
            }
        }

        private void cbl01_INSTALL_POS_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted == true)
            {
                string strEventName = "";

                strEventName = ((AxComboList)(sender)).Name;

                if (GetByteCount(strEventName) > 0)
                {
                    BtnQuery_Click(null, null);
                }
            }
        }

        #endregion

        #region [ 그리드 HeadTitle 초기화 정의 ]

        private void grid01_SetColumns()
        {
            if (this.cbo01_TYPE.GetValue().ToString() == "Q603")
            {
                this.grd01.SetHeadTitle(1, 10, this.GetLabel("CHK_INNER_5")); // "청결상태"); 
                this.grd01.SetHeadTitle(1, 11, this.GetLabel("SEQ_CASE")); //"서열지CASE");
                this.grd01.SetHeadTitle(1, 12, this.GetLabel("BELT")); //"벨트");
                this.grd01.SetHeadTitle(1, 13, this.GetLabel("COVER")); //"커버");
                this.grd01.SetHeadTitle(1, 14, this.GetLabel("HOOK")); //"견인고리");
                this.grd01.SetHeadTitle(1, 15, this.GetLabel("CHK_INNER_3")); //"캐스터");
                this.grd01.SetHeadTitle(1, 16, this.GetLabel("CHK_INNER_2")); //"간지");
            }
            else
            {
                this.grd01.SetHeadTitle(1, 10, this.GetLabel("CHK_INNER_1"));//"간지끈");
                this.grd01.SetHeadTitle(1, 11, this.GetLabel("CHK_INNER_2")); //"간지");
                this.grd01.SetHeadTitle(1, 12, this.GetLabel("CHK_INNER_3")); //"캐스터");
                this.grd01.SetHeadTitle(1, 13, this.GetLabel("CHK_INNER_4")); //"손잡이");
                this.grd01.SetHeadTitle(1, 14, this.GetLabel("CHK_INNER_5")); //"청결상태");
                this.grd01.SetHeadTitle(1, 15, this.GetLabel("CHK_CORP_1")); //"프레임");
                this.grd01.SetHeadTitle(1, 16, this.GetLabel("CHK_CORP_2")); //"프레임 감싸기");
            }
        }
        
        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {

                if (this.cbo01_BIZCD.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", lbl01_BIZNM.Text);   //{0}를(을) 입력해주세요.
                    this.cbo01_BIZCD.Focus();
                    return false;
                }

                if (this.cbo01_TYPE.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", lbl01_TYPE.Text);   //{0}를(을) 입력해주세요.
                    this.cbo01_TYPE.Focus();
                    return false;
                }

                //if (this.cbl01_VINCD.IsEmpty)
                //{
                //    MsgCodeBox.ShowFormat("MM00-0001", lbl01_VIN.GetValue());   //{0}를(을) 입력해주세요.
                //    this.cbo01_TYPE.Focus();
                //    return false;
                //}

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }
                //데이터를 저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    
                    return false;
                }

                //데이터를 삭제하시겠습니까?
                //if (MsgBox.Show("선택하신 완제품 적재대를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        
    }
}
