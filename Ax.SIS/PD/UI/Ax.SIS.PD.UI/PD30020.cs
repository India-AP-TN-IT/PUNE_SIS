#region ▶ Description & History
/* 
 * 프로그램명 : PD30020 수지 Lot 투입 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
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

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 수지 Lot 투입 관리
    /// </summary>
    public partial class PD30020 : AxCommonBaseControl
    {
        private bool _IsBinded;
        //private IPD30020 _WSCOM;
        //private IPDCOMMON_MES _WSCOM_MES;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD30020";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        public PD30020()
        {
            _IsBinded = false;

            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD30020>("PD", "PD30020.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //데이터가 null일때 디폴트 0으로 표시되지 않게 함. null일때는 빈 문자열로 표시 2013.04.11 (배명희) 
                this.nme02_HOPPER_TEMP.NullText = "";
                this.nme02_IN_WT.NullText = "";
                this.nme02_REMAIN_WT.NullText = "";

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "투입일자", "WORK_DATE", "INPUT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "탱크번호\n(라인)", "RES_TANK_NO", "TANK_LINE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "탱크명\n(라인명)", "RES_TANK_NM", "TANK_LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "투입\n순번", "SEQ", "IN_SEQNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "Grade No", "GRADE_NO", "GRADE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "차종", "CAR_TYPE", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "LOT NO", "RES_LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "투입중량\n(kg)", "IN_WT", "IN_WT_E");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "현재잔량\n(kg)", "REMAIN_WT", "CURRENT_WT_E");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "호퍼\n온도", "HOPPER_TEMP", "HOPPER_TEMP_E");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "사용\n여부", "USE_YN", "USE_YN_E");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IN_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "REMAIN_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "HOPPER_TEMP");

                #region [Grid Merge]

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01.AddMerge(0, 1, "WORK_DATE", "WORK_DATE");
                this.grd01.AddMerge(0, 1, "RES_TANK_NO", "RES_TANK_NO");
                this.grd01.AddMerge(0, 1, "RES_TANK_NM", "RES_TANK_NM");
                this.grd01.AddMerge(0, 1, "SEQ", "SEQ");
                this.grd01.AddMerge(0, 1, "RES_LOTNO", "RES_LOTNO");
                this.grd01.AddMerge(0, 1, "IN_WT", "IN_WT");
                this.grd01.AddMerge(0, 1, "REMAIN_WT", "REMAIN_WT");
                this.grd01.AddMerge(0, 1, "HOPPER_TEMP", "HOPPER_TEMP");
                this.grd01.AddMerge(0, 1, "USE_YN", "USE_YN");

                this.grd01.AddMerge(0, 0, "PARTNO", "CAR_TYPE");
                //this.grd01.SetHeadTitle(0, "PARTNO", "사출수지");
                this.grd01.SetHeadTitle(0, "PARTNO",GetLabel("INJ_MIXER"));

                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cbo02_CORCD.DataBind_CORCD(false);
                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.dtp01_WORK_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));

                this.txt02_RES_LOTNO.SetValid(AxTextBox.TextType.UAlphabet);

                this.SetRequired(lbl02_CORCD, lbl02_BIZCD, lbl02_INPUT_DATE, lbl02_IN_SEQ, lbl02_PARTNO, lbl02_LOTNO, lbl02_IN_WT);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                grp01_PD30020_GRP_1.Text=GetLabel("PD30020_GRP_1");
                grp01_PD30020_GRP_2.Text = GetLabel("PD30020_GRP_2");
                grp01_PD30020_GRP_3.Text = GetLabel("PD30020_GRP_3");
                chk02_USEYN2.Text = GetLabel("USEYN2");
                
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
                _IsBinded = false;

                this.cbo02_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo02_BIZCD.SetValue(this.cbo01_BIZCD.GetValue());
                this.dtp02_WORK_DATE.Initialize();
                this.txt02_SEQ.Initialize();
                this.cbl02_RES_TANK_NO.Initialize();
                this.cbl02_PARTNO.Initialize();
                this.txt02_RES_LOTNO.Initialize();
                this.nme02_IN_WT.Initialize();
                this.nme02_REMAIN_WT.Initialize();
                this.nme02_HOPPER_TEMP.Initialize();
                this.chk02_USEYN2.SetValue("Y");

                this.nme02_CURRENT_WT.Initialize();

                this.btn02_APPENDWT.Enabled = false;
                this.btn02_CURRENTWT.Enabled = false;

                this.dtp02_WORK_DATE.SetReadOnly(false);
                this.txt02_SEQ.SetReadOnly(false);
                this.cbl02_RES_TANK_NO.SetReadOnly(false);

                this.grp01_PD30020_GRP_3.Visible = this.cbo01_BIZCD.GetValue().ToString().Equals("5220");
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("RES_TANK_NO", this.cbl01_RES_TANK_NO.GetValue());
                set.Add("WORK_SDATE", this.dtp01_WORK_SDATE.GetDateText());
                set.Add("WORK_EDATE", this.dtp01_WORK_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
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
                this.SAVE(false);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeleteValid()) return;

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "WORK_DATE", "RES_TANK_NO", "SEQ");

                source.Tables[0].Rows.Add(
                    this.cbo02_CORCD.GetValue(),
                    this.cbo02_BIZCD.GetValue(),
                    this.dtp02_WORK_DATE.GetDateText(),
                    this.cbl02_RES_TANK_NO.GetValue(),
                    this.txt02_SEQ.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES1230(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 수지 Lot 투입 정보가 삭제되었습니다");
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

        #region [ 기타 컨트롤 이벤트 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                string CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                string BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();
                string WORK_DATE = this.grd01.GetValue(row, "WORK_DATE").ToString();
                string RES_TANK_NO = this.grd01.GetValue(row, "RES_TANK_NO").ToString();
                string SEQ = this.grd01.GetValue(row, "SEQ").ToString();

                this.Inquery(CORCD, BIZCD, WORK_DATE, RES_TANK_NO, SEQ);
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
                this.BtnReset_Click(null, null);

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_RESTANK_LINE"), set);
                //DataSet source1 = _WSCOM_MES.INQUERY_COMBO_RESTANK_LINE(this.cbo01_BIZCD.GetValue().ToString());
                
                
                //DataSet source2 = _WSCOM_MES.INQUERY_COMBO_RESGRADE(this.cbo01_BIZCD.GetValue().ToString());                
                //this.cbl01_RES_TANK_NO.DataBind(source1.Tables[0], "수지호기코드;명칭", "C;L");
                this.cbl01_RES_TANK_NO.DataBind(source1.Tables[0],GetLabel("MIXER_CODE")+";"+GetLabel("INSPEC_POSNM"), "C;L");
                cbo02_BIZCD.SetValue(cbo01_BIZCD.GetValue());
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_RESTANK_LINE"), set);
                //DataSet source1 = _WSCOM_MES.INQUERY_COMBO_RESTANK_LINE(this.cbo01_BIZCD.GetValue().ToString());

                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_RESGRADE"));
                //DataSet source2 = _WSCOM_MES.INQUERY_COMBO_RESGRADE(this.cbo01_BIZCD.GetValue().ToString());

                //this.cbl02_RES_TANK_NO.DataBind(source1.Tables[0], "RES_INPUT", "RES_INPUT", "수지호기코드;명칭", "C;L");
                this.cbl02_PARTNO.DataBind(source2.Tables[0], "PARTNO", "PARTNO", "P/NO;" + this.GetLabel("MIXER_GRADE")+ ";" + this.GetLabel("VIN"), "L;C;C"); //@@@ "P/NO;수지Grade;차종"
                this.cbl02_RES_TANK_NO.DataBind(source1.Tables[0], "RES_INPUT", "RES_INPUT", GetLabel("MIXER_CODE") + ";" + GetLabel("INSPEC_POSNM"), "C;L");
                this.cbl02_PARTNO.DataBind(source2.Tables[0], "PARTNO", "PARTNO",GetLabel("PARTNO")+";"+GetLabel("MIXER_GRADE")+";"+GetLabel("VIN"), "L;C;C");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl02_RES_TANK_NO_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txt02_RES_TANK_NM.SetValue(this.cbl02_RES_TANK_NO.GetValue("RES_INPUT_NM"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl02_PARTNO_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txt02_GRADE_NO.SetValue(this.cbl02_PARTNO.GetValue("GRADE_NO"));
                this.txt02_CAR_TYPE.SetValue(this.cbl02_PARTNO.GetValue("CAR_TYPE"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_CURRENTWT_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MsgBox.Show("현재 잔량을 반영 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0021", MessageBoxButtons.OKCancel) != DialogResult.OK) //데이터를 처리하시겠습니까? @@@
                    return;
               
                string CurrentKey = string.Format("{0}{1}{2}{3}{4:00}", this.cbo02_CORCD.GetValue().ToString(),
                                                                           this.cbo02_BIZCD.GetValue().ToString(),
                                                                           this.dtp02_WORK_DATE.GetDateText().ToString(),
                                                                           this.cbl02_RES_TANK_NO.GetValue().ToString(),
                                                                           int.Parse(this.txt02_SEQ.GetValue().ToString()));
                
               // string CurrentKey = string.Format("{0}", this.cbl02_PARTNO.GetValue().ToString());
                                                                           
               DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "RES_TANK_NO", "CURRENTKEY");
               // DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "RES_TANK_NO", "CURRENTKEY");

                source.Tables[0].Rows.Add(
                    this.cbo02_CORCD.GetValue(),
                    this.cbo02_BIZCD.GetValue(),
                    this.cbl02_RES_TANK_NO.GetValue(),
                    CurrentKey
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_CURRENTWT(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_CURRENTWT"), source);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES1230(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.nme02_REMAIN_WT.SetValue(this.nme02_CURRENT_WT.GetValue());

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

        private void btn02_APPENDWT_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MsgBox.Show("투입 중량을 계산 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0025", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                string CurrentKey = string.Format("{0}{1}{2}{3}{4:00}", this.cbo02_CORCD.GetValue().ToString(),
                                                                           this.cbo02_BIZCD.GetValue().ToString(),
                                                                           this.dtp02_WORK_DATE.GetDateText().ToString(),
                                                                           this.cbl02_RES_TANK_NO.GetValue().ToString(),
                                                                           int.Parse(this.txt02_SEQ.GetValue().ToString()));

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.cbo02_CORCD.GetValue());
                set.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                set.Add("RES_TANK_NO", this.cbl02_RES_TANK_NO.GetValue());
                set.Add("CURRENTKEY", CurrentKey);

                //DataTable source = _WSCOM.INQUERY_LASTWT(this.UserInfo.BusinessCode, set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LASTWT"), set, "OUT_CURSOR").Tables[0];


                if (source.Rows.Count == 0) return;

                double NewWt = double.Parse(this.nme02_CURRENT_WT.GetValue().ToString()) - double.Parse(source.Rows[0]["LAST_WT"].ToString());

                this.nme02_REMAIN_WT.SetValue(NewWt);
                this.nme02_IN_WT.SetValue(NewWt);

                this.SAVE(true);                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드]

        private void Inquery(string CORCD, string BIZCD, string WORK_DATE, string RES_TANK_NO, string SEQ)
        {
            try
            {
                string bizcd = BIZCD;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("WORK_DATE", WORK_DATE);
                set.Add("RES_TANK_NO", RES_TANK_NO);
                set.Add("SEQ", SEQ);
                set.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source = _WSCOM.INQUERY_DETAIL(bizcd, set);
                DataSet source = new DataSet();
                DataTable dt1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR").Tables[0];
                DataTable dt2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_TANKCURRNTWT"), set, "OUT_CURSOR").Tables[0];

                dt1.TableName = "dt1";
                dt2.TableName = "dt2";

                source.Tables.Add(dt1.Copy());
                source.Tables.Add(dt2.Copy());                

                if (source.Tables[0].Rows.Count == 0) return;

                _IsBinded = true;

                DataRow row = source.Tables[0].Rows[0];

                this.cbo02_CORCD.SetValue(row["CORCD"]);
                this.cbo02_BIZCD.SetValue(cbo01_BIZCD.GetValue());
                this.dtp02_WORK_DATE.SetValue(row["WORK_DATE"]);
                this.txt02_SEQ.SetValue(row["SEQ"]);
                this.cbl02_RES_TANK_NO.SetValue(row["RES_TANK_NO"]);
                this.cbl02_PARTNO.SetValue(row["PARTNO"]);
                this.txt02_RES_LOTNO.SetValue(row["RES_LOTNO"]);
                this.nme02_IN_WT.SetValue(row["IN_WT"]);
                this.nme02_REMAIN_WT.SetValue(row["REMAIN_WT"]);
                this.nme02_HOPPER_TEMP.SetValue(row["HOPPER_TEMP"]);
                this.chk02_USEYN2.SetValue(row["USE_YN"]);

                this.btn02_APPENDWT.Enabled = true;
                this.btn02_CURRENTWT.Enabled = true;

                this.dtp02_WORK_DATE.SetReadOnly(true);
                this.txt02_SEQ.SetReadOnly(true);
                this.cbl02_RES_TANK_NO.SetReadOnly(true);

                if (source.Tables[1].Rows.Count == 0) return;

                row = source.Tables[1].Rows[0];

                this.nme02_CURRENT_WT.SetValue(row["CURRENT_WT"].ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SAVE(bool _IsButton)
        {
            try
            {
                if(!_IsButton) if (!IsSaveValid()) return;

                string CORCD = this.cbo02_CORCD.GetValue().ToString();
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string WORK_DATE = this.dtp02_WORK_DATE.GetDateText().ToString();
                string RES_TANK_NO = this.cbl02_RES_TANK_NO.GetValue().ToString();
                string SEQ = this.txt02_SEQ.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "WORK_DATE", "RES_TANK_NO", "SEQ", "PARTNO", "GRADE_NO", "RES_LOTNO", "IN_WT", "REMAIN_WT", "HOPPER_TEMP", "USE_YN", "EMPNO");



                source.Tables[0].Rows.Clear();
                source.Tables[0].Rows.Add(
                CORCD,
                BIZCD,
                WORK_DATE,
                RES_TANK_NO,
                SEQ,
                this.cbl02_PARTNO.GetValue(),
                txt02_GRADE_NO.GetValue(),
                txt02_RES_LOTNO.GetValue(),
                nme02_IN_WT.GetDBValue(),
                0,
                nme02_HOPPER_TEMP.GetDBValue(),
                chk02_USEYN2.Checked == true ? "1" : "0",
                this.UserInfo.EmpNo
                );


                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_PARTNO"), source);
                this.AfterInvokeServer();
                /*
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", BIZCD);
                set.Add("RES_TANK_NO", this.cbl01_RES_TANK_NO.GetValue());
                set.Add("WORK_SDATE", this.dtp01_WORK_SDATE.GetValue());
                set.Add("WORK_EDATE", this.dtp01_WORK_EDATE.GetValue());
                set.Add("PARTNO", this.cbl02_PARTNO.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet readData = _WSCOM.INQUERY_PART(BIZCD, set);
                DataSet readData = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PART", set, "OUT_CURSOR");
                this.AfterInvokeServer();
                
                double dCurrentVal = Convert.ToDouble(nme02_CURRENT_WT.GetValue());
                double dInVal = dCurrentVal;
                for (int row = 0; row < readData.Tables[0].Rows.Count; row++)
                {
                    if (row == 2)
                    {
                        int a = 0;
                    }
                    if (row == 0)
                    {
                        dInVal = dCurrentVal;
                    }
                    else
                    {
                        dInVal -= Convert.ToDouble(readData.Tables[0].Rows[row - 1]["IN_WT"] == DBNull.Value ? 0 : readData.Tables[0].Rows[row - 1]["IN_WT"]);
                    }
                    if (dInVal <= 0) dInVal = 0;
                    source.Tables[0].Rows.Clear();
                    source.Tables[0].Rows.Add(
                    CORCD,
                    BIZCD,
                    WORK_DATE,
                    RES_TANK_NO,
                    SEQ,
                    this.cbl02_PARTNO.GetValue(),
                    readData.Tables[0].Rows[row]["GRADE_NO"],
                    txt02_RES_LOTNO.GetValue(),
                    readData.Tables[0].Rows[row]["IN_WT"],
                    dInVal,
                    readData.Tables[0].Rows[row]["HOPPER_TEMP"],
                    chk02_USEYN2.Checked == true ? "1" : "0",
                    this.UserInfo.EmpNo
                    );

                    this.BeforeInvokeServer(true);
                    //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);


                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE", source);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_PARTNO", source);

                    this.AfterInvokeServer();
                }
                */
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작

                //bool isSyncOK = this.DN_MESCODE_MES1210(this.UserInfo.BusinessCode);
                //isSyncOK = this.DN_MESCODE_MES1230(this.UserInfo.BusinessCode); 
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.BtnQuery_Click(null, null);
                this.Inquery(CORCD, BIZCD, WORK_DATE, RES_TANK_NO, SEQ);

                //MsgBox.Show("입력하신 수지 Lot 투입 정보가 저장되었습니다.");
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

        private bool IsSaveValid()
        {
            try
            {
                string SEQ = this.txt02_SEQ.GetValue().ToString();
                string RES_TANK_NO = this.cbl02_RES_TANK_NO.GetValue().ToString();
                string PARTNO = this.cbl02_PARTNO.GetValue().ToString();
                string RES_LOTNO = this.txt02_RES_LOTNO.GetValue().ToString();

                if (this.GetByteCount(SEQ) == 0)
                {
                    //MsgBox.Show("투입순번이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("IN_SEQ"));				
                    return false;
                }

                if (this.GetByteCount(RES_TANK_NO) == 0)
                {
                    //MsgBox.Show("탱크가 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("TANK"));				
                    return false;
                }

                if (this.GetByteCount(PARTNO) == 0)
                {
                    //MsgBox.Show("PART No가 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("PARTNO"));				
                    return false;
                }

                if (this.GetByteCount(RES_LOTNO) == 0)
                {
                    //MsgBox.Show("LOT No가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("LOTNO"));	
                    return false;
                }

                if (this.GetByteCount(RES_LOTNO) > 20)
                {
                    //MsgBox.Show("LOT No는 20Byte를 넘을 수 없습니다.");
                    MsgCodeBox.ShowFormat("PD00-0026", this.GetLabel("LOTNO"),"20");	
                    return false;
                }

                //if (MsgBox.Show("입력하신 수지 Lot 투입 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private bool IsDeleteValid()
        {
            try
            {
                if (!_IsBinded)
                {
                    //MsgBox.Show("삭제할 수지 Lot 투입 정보가 선택되지 않습니다.");
                    MsgCodeBox.Show("PD00-0011");		
                    return false;
                }

                //if (MsgBox.Show("선택하신 수지 Lot 투입 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
        ////2014.02.10 - MES1210 사출수지탱크 마스터 MESCODE 전송
        //private bool DN_MESCODE_MES1210(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES1210", bizcd).Tables[0].Rows[0][0].ToString();

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

        ////2014.02.10 - MES1230 사출수지 투입이력 MESCODE 전송
        //private bool DN_MESCODE_MES1230(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES1230", bizcd).Tables[0].Rows[0][0].ToString();

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
