#region ▶ Description & History
/* 
 * 프로그램명 : 비가동 실적 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_LINECD, cdx02_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2014-10-07    진승모     다국어 적용   
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;

using HE.Framework.Core;
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>비가동 실적등록</b>    
    /// </summary>
    public partial class PD25220 : AxCommonBaseControl
    {
        //private IPD25220 _WSCOM;
        private AxClientProxy proxy;
        private string PACKAGE_NAME = "APG_PD25220";

        //private const string _CCA = "CCA";
        //private const string _CCB = "CCB";
        //private const string _CCC = "CCC";
        //private const string _CCD = "CCD";
        private string _prdt_div = string.Empty;
        
     
        public PD25220()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD25220>("PM05", "PD25220.svc", "CustomBinding");
            proxy = new AxClientProxy();

        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.Initialize();
                this.grd01.AllowEditing = false;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "인원", "PERSON", "PERSON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 130, "발생시간(분)", "OCCUR_TIME", "OCCUR_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "정지시간(인원*발생시간)", "STOP_TIME", "PD25220_STOP_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "실정지공수(정지시간/60)", "STOP_PERSON_TIME", "PD25220_STOP_PERSON_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PERSON");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "OCCUR_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOP_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOP_PERSON_TIME");
                this.grd01.Cols["PERSON"].Format = "###,##0";
                this.grd01.Cols["OCCUR_TIME"].Format = "###,###,##0";
                this.grd01.Cols["STOP_TIME"].Format = "###,###,##0";
                this.grd01.Cols["STOP_PERSON_TIME"].Format = "###,###,##0.00";
                this.grd01.Cols[0].Visible = false;
                this.grd01.Rows.Add();

                this.grd02.Initialize();
                this.grd02.AllowEditing = true;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "선택자 사번", "EMPNO", "PD25220_EMPNO2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 115, "성명", "EMPNM", "EMPNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 055, "선택", "CHK", "CHK");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                this.grd03.Initialize();
                this.grd03.AllowEditing = true;
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "대상자 사번", "EMPNO", "PD25220_EMPNO1");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 115, "성명", "EMPNM", "EMPNM");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 055, "선택", "CHK", "CHK");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                this.grd04.Initialize();
                this.grd04.AllowEditing = false;
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인코드", "CORCD", "CORCD");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "사업장", "BIZCD", "BIZCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "비가동번호", "NON_OPRNO", "NON_OPRNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "발생일자", "OCCUR_DATE", "OCCUR_DATE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "LINE", "LINECD", "LINECD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "시작시간", "BEG_TIME", "BEG_TIME");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "종료시간", "END_TIME", "END_TIME");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "비가동코드", "NON_OPRCD", "NON_OPRCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "인원", "PERSON", "PERSON");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "실정지시간", "STOP_TIME_SUM", "PD25220_STOP_TIME_SUM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "정지공수", "STOP_MH_SUM", "PD25220_STOP_MH_SUM");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "설비코드", "EQUIPCD", "EQUIPCD");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 230, "PARTNO", "PARTNO", "PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "세부내역", "DET_DESC", "DET_DESC");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "PERSON");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOP_MH_SUM");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7","INSTALL_POS");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                DateTime dt = DateTime.Now;
                dt = dt.AddHours(dt.Hour * -1);
                dt = dt.AddHours(8);
                dt = dt.AddMinutes(dt.Minute * -1);
                dt = dt.AddMilliseconds(dt.Millisecond * -1);

                this.dte01_OCCUR_BEG_TIME.Value = dt;
                dt = dt.AddHours(9);
                this.dte01_OCCUR_END_TIME.Value = dt;


                this.cdx01_LINECD.HEPopupHelper = new CM30030P1();// new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_OCCUR_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();// new PM20015P1();
                //this.cdx01_LINECD.PopupTitle = "대표 라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_OCCUR_DATE.GetValue());


                this.cdx02_LINECD.HEPopupHelper = new CM30030P1();//new PM20015P1();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", this.dte01_OCCUR_DATE.GetDateText());
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                //this.cdx02_LINECD.HEPopupHelper = new CM20020P1();//new PM20015P1();
                //this.cdx02_LINECD.PopupTitle = "대표 라인코드";
                //this.cdx02_LINECD.CodeParameterName = "LINECD";
                //this.cdx02_LINECD.NameParameterName = "LINENM";
                //this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx02_LINECD.HEUserParameterSetValue("DATE", this.dte01_OCCUR_DATE.GetValue());

                this.cdx01_NON_OPRCD.HEPopupHelper = new PD25220P1();
                this.cdx01_NON_OPRCD.PopupTitle = this.GetLabel("NON_OPRCD");
                this.cdx01_NON_OPRCD.CodeParameterName = "NON_OPRCD";
                this.cdx01_NON_OPRCD.NameParameterName = "NON_OPRNM";
                this.cdx01_NON_OPRCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_NON_OPRCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_NON_OPRCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                //this.cdx01_EQUIPCD.HEPopupHelper = new PD25220P2();
                //this.cdx01_EQUIPCD.PopupTitle = this.GetLabel("EQUIPCD");
                //this.cdx01_EQUIPCD.CodeParameterName = "EQUIPCD";
                //this.cdx01_EQUIPCD.NameParameterName = "EQUIPNM";
                //this.cdx01_EQUIPCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_EQUIPCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_EQUIPCD.HEUserParameterSetValue("OCCUR_DATE", this.dte01_OCCUR_DATE.GetValue());
                //this.cdx01_EQUIPCD.HEUserParameterSetValue("LINECD", this.cdx01_LINECD.GetValue());

                //this.cdx01_PROCCD.HEPopupHelper = new PD25220P3();
                //this.cdx01_PROCCD.PopupTitle = this.GetLabel("PROCCD");
                //this.cdx01_PROCCD.CodeParameterName = "PROCCD";
                //this.cdx01_PROCCD.NameParameterName = "PROCNM";
                //this.cdx01_PROCCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_PROCCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_PROCCD.HEUserParameterSetValue("LINECD", this.cdx01_LINECD.GetValue());
                //this.cdx01_PROCCD.HEUserParameterSetValue("OCCUR_DATE", this.dte01_OCCUR_DATE.GetValue());

                //this.cdx01_OUT_PARTNO.HEPopupHelper = new PD25220P4();
                //this.cdx01_OUT_PARTNO.PopupTitle = this.GetLabel("PARTNO");
                //this.cdx01_OUT_PARTNO.CodeParameterName = "PARTNO";
                //this.cdx01_OUT_PARTNO.NameParameterName = "PARTNM";
                //this.cdx01_OUT_PARTNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_OUT_PARTNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_OUT_PARTNO.HEUserParameterSetValue("OCCUR_DATE", this.dte01_OCCUR_DATE.GetValue());
                //this.cdx01_OUT_PARTNO.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                //this.cdx01_EQUIPCD.SetReadOnly(true);
                //this.cdx01_PROCCD.SetReadOnly(true);
                //this.cdx01_OUT_PARTNO.SetReadOnly(true);
                //this.cbo01_VENCD.SetReadOnly(true);
                this.txt01_NON_OPRNO.SetReadOnly(true);

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_LINECD, this.lbl01_OCCUR_DATE, this.lbl01_NON_OPRCD);

                //DataSet ds03 = this.GetDataSourceSchema("Code", "CodeValue");
                //ds03.Tables[0].Rows.Add("N", "개분생산(DT)");
                //ds03.Tables[0].Rows.Add("Y", "대분생산(SEAT)");

                //this.cbo01_INSTALL_POS.DataBind("A7", "LR", true);
                this.cbo01_INSTALL_POS.DataBind("A7", true);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string STA_INFO = this.lbl01_STACD.Value.ToString();
                //string STACD = STA_INFO.Substring(0, STA_INFO.IndexOf(":"));
                string NON_OPRNO = this.txt01_NON_OPRNO.GetValue().ToString();

                if (NON_OPRNO.Length == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    set.Add("OCCUR_DATE", this.dte01_OCCUR_DATE.GetDateText());
                    //NON_OPRNO = _WSCOM.Inquery_MAX_NON_OPRNO(set).Tables[0].Rows[0][0].ToString();
                    NON_OPRNO = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_MAX_NON_OPRNO"), set).Tables[0].Rows[0][0].ToString();
                }

                DataSet nonOpr = this.MakePM6110Dataset(NON_OPRNO);
                DataSet person = this.MakePM6120Dataset(NON_OPRNO);

                if (!IsSaveValid(person)) return;

                this.BeforeInvokeServer(true);

                DataSet param = this.GetDataSourceSchema("CORCD", "BIZCD", "NON_OPRNO");
                param.Tables[0].Rows.Add
                        (
                            this.UserInfo.CorporationCode,
                            this.cbo01_BIZCD.GetValue(),
                            this.txt01_NON_OPRNO.GetValue()
                        );

                                  
                proxy.MultipleExecuteNonQueryTx(new string[] { 
                    string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), 
                    string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_PERSON_BEFORE"),
                    string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_PERSON")}, new DataSet[] { nonOpr, param, person});
                        
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 비가동 실적 정보가 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
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
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "NON_OPRNO");
                source.Tables[0].Rows.Add
                (
                    this.UserInfo.CorporationCode,
                    this.cbo01_BIZCD.GetValue(),
                    this.txt01_NON_OPRNO.GetValue()
                );

                if (!this.IsDeleteValid(source))
                    return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);

                //발생일자 : 기존값 저장.
                this.dte01_OCCUR_DATE_OLD.SetValue(this.dte01_OCCUR_DATE.GetDateText().ToString());

                //MsgBox.Show("선택한 비가동 실적 정보가 삭제되었습니다.");
                MsgCodeBox.Show("CD00-0072");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
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
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("LINECD", this.cdx01_LINECD.GetValue());
                set.Add("OCCUR_DATE", this.dte01_OCCUR_DATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(set);
                DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.grd04.SetValue(source);
                this.AfterInvokeServer();
                this.BtnReset_Click(null, null);

                //발생일자 : 기존값 저장.
                this.dte01_OCCUR_DATE_OLD.SetValue(this.dte01_OCCUR_DATE.GetDateText().ToString());
                
                this.LockStatusCheck(); //2017-11-08
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
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
                this.lbl01_TIME_CAL_RES.Value = "";
//                this.lbl01_STACD.Value = "";

                this.txt01_NON_OPRNO.Initialize();
                this.dte01_OCCUR_BEG_TIME.SetValue("00:00");
                this.dte01_OCCUR_END_TIME.SetValue("00:00");
                this.cdx01_NON_OPRCD.Initialize();
                this.txt01_DET_DESC.Initialize();

                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();
                this.grd03.InitializeDataSource();
                this.grd01.Rows.Add();

                this.cdx02_LINECD.Initialize();
                this.chk01_PD25220_CHK2.Initialize();

                //this.cdx01_EQUIPCD.Initialize();
                //this.cdx01_PROCCD.Initialize();
                //this.cdx01_OUT_PARTNO.Initialize();
                //this.cbo01_VENCD.Initialize();

                //this.cdx01_EQUIPCD.SetReadOnly(true);
                this.cdx01_PROCCD.SetReadOnly(true);
                //this.cdx01_OUT_PARTNO.SetReadOnly(true);
                //this.cbo01_VENCD.SetReadOnly(true);

                this.cbo01_INSTALL_POS.Initialize();

                this.chk01_PD25220_CHK1.Initialize();
                this.dte01_OCCUR_DATE.SetReadOnly(false);

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]

        private void btn01_TIME_CAL_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("BEG_TIME", this.dte01_OCCUR_BEG_TIME.GetValue());
                set.Add("END_TIME", this.dte01_OCCUR_END_TIME.GetValue());
                set.Add("WORK_DATE", this.dte01_OCCUR_DATE.GetDateText());
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("TIME_DIV", this.chk01_PD25220_CHK1.GetValue());
                if (!IsCalWorkTime(set)) return;

                BeforeInvokeServer(true);
                //DataSet source = _WSCOM.CalculateWorkTime(set);
                DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "CAL_WORKTIME"), set);
                AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    lbl01_TIME_CAL_RES.SetValue(source.Tables[0].Rows[0]["WORK_TIME"].ToString());
                }

                //시간 수정시 그리드 재계산 로직
                if (!this.txt01_NON_OPRNO.IsEmpty)
                {
                    int iNonMinutes = 0;
                    string strNonMinutes = this.lbl01_TIME_CAL_RES.Value.ToString().Trim().Replace(",", "");
                    if (this.GetByteCount(strNonMinutes) > 0)
                        iNonMinutes = Int32.Parse(strNonMinutes);
                    int iPerson = this.grd02.Rows.Count - 1;
                    decimal iStopTime = iPerson * iNonMinutes;
                    decimal iStopPersonTime = Math.Round(iStopTime / 60, 2, MidpointRounding.ToEven);

                    this.grd01.SetValue(1, "PERSON", iPerson);
                    this.grd01.SetValue(1, "OCCUR_TIME", iNonMinutes);
                    this.grd01.SetValue(1, "STOP_TIME", iStopTime);
                    this.grd01.SetValue(1, "STOP_PERSON_TIME", iStopPersonTime);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }

        private void btn01_WORKER_ALL_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < this.grd03.Rows.Count; i++)
                    this.grd03[i, "CHK"] = true;
                this.MoveEmployees(this.grd03, this.grd02);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void btn01_CLEAR_WORKER_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < this.grd02.Rows.Count; i++)
                    this.grd02[i, "CHK"] = true;
                this.MoveEmployees(this.grd02, this.grd03);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void btn01_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                this.MoveEmployees(this.grd02, this.grd03);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void btn01_SELECT_Click(object sender, EventArgs e)
        {
            try
            {
                this.MoveEmployees(this.grd03, this.grd02);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        //private void cdx01_NON_OPRCD_ValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HEParameterSet set = new HEParameterSet();
        //        set.Add("CORCD", this.UserInfo.CorporationCode);
        //        set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
        //        set.Add("NON_OPRCD", this.cdx01_NON_OPRCD.GetValue());
        //        set.Add("NON_OPRNM", "");
        //        set.Add("LANG_SET", this.UserInfo.Language);

        //        //DataSet ds = _WSCOM.Inquery_NON_OPRCD(set);
        //        DataSet ds = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_NON_OPRCD"), set);

        //        DataRow selectedRow = (DataRow)((AxCodeBox)sender).HEPopupHelper.SelectedValue;

        //        if (selectedRow == null && ds.Tables[0].Rows.Count == 0)
        //            return;

                //string STACD = "";
                //string STANM = "";

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    STACD = ds.Tables[0].Rows[0]["STACD"].ToString();
                //    STANM = ds.Tables[0].Rows[0]["STANM"].ToString();
                //}
                //else
                //{
                //    STACD = selectedRow["STACD"].ToString();
                //    STANM = selectedRow["STANM"].ToString();
                //}

                //this.lbl01_STACD.Value = STANM;

                
                //this.cdx01_EQUIPCD.SetReadOnly(true);
                //this.cdx01_PROCCD.SetReadOnly(true);
                //this.cdx01_OUT_PARTNO.SetReadOnly(true);
                //this.cbo01_VENCD.SetReadOnly(true);
                      
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.Message);
        //    }
        //}

        //private void cdx01_OUT_PARTNO_ValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string PARTNO = ((AxCodeBox)sender).GetValue().ToString();

        //        HEParameterSet set = new HEParameterSet();
        //        set.Add("CORCD", this.UserInfo.CorporationCode);
        //        set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
        //        set.Add("PARTNO", PARTNO);
        //        set.Add("OCCUR_DATE", this.dte01_OCCUR_DATE.GetValue());
        //        set.Add("LANG_SET", this.UserInfo.Language);

        //        //DataSet source = _WSCOM.Inquery_VENDCD_BY_PARTNO(set);
        //        DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_VENDCD_BY_PARTNO"), set);
        //        this.cbo01_VENCD.DataBind(source.Tables[0]);
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.Message);
        //    }
        //}

        private void cdx02_LINECD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string LINECD = ((AxCodeBox)sender).GetValue().ToString();
                string OCCUR_DATE = this.dte01_OCCUR_DATE.GetDateText().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("OCCUR_DATE", OCCUR_DATE);
                set.Add("LINECD", LINECD);                                    

                if (this.chk01_PD25220_CHK2.Checked == true)
                {
                    set.Add("S_DIV", "1");
                }
                else
                {
                    set.Add("S_DIV", "");
                }
                set.Add("BEG_HHMM", dte01_OCCUR_BEG_TIME.GetValue());
                set.Add("END_HHMM", dte01_OCCUR_END_TIME.GetValue());
                //DataSet source = _WSCOM.Inquery_EMPNO_BY_LINECD(set);
                DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EMPNO_BY_LINECD"), set);
                this.grd03.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void chk01_OPTION_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string LINECD = this.cdx02_LINECD.GetValue().ToString();
                string OCCUR_DATE = this.dte01_OCCUR_DATE.GetDateText().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("OCCUR_DATE", OCCUR_DATE);
                set.Add("LINECD", LINECD);

                if (this.chk01_PD25220_CHK2.Checked == true)
                {
                    set.Add("S_DIV", "1");
                }
                else
                {
                    set.Add("S_DIV", "");
                }
                set.Add("BEG_HHMM", dte01_OCCUR_BEG_TIME.GetValue());
                set.Add("END_HHMM", dte01_OCCUR_END_TIME.GetValue());
                //DataSet source = _WSCOM.Inquery_EMPNO_BY_LINECD(set);
                DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EMPNO_BY_LINECD"), set);
                this.grd03.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void grd04_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd04.SelectedRowIndex;
                if (row < 1) return;

                object CORCD = this.grd04.GetValue(row, "CORCD");
                object BIZCD = this.grd04.GetValue(row, "BIZCD");
                object NON_OPRNO = this.grd04.GetValue(row, "NON_OPRNO");

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("NON_OPRNO", NON_OPRNO);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_DETAIL(set);
                DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set,"OUT_CURSOR_1","OUT_CURSOR_2");
                DataTable dtHeader = source.Tables[0];
                DataTable dtDetail = source.Tables[1];
                DataRow drHeader = dtHeader.Rows[0];

                this.txt01_NON_OPRNO.SetValue(drHeader["NON_OPRNO"]);
                this.cdx01_LINECD.SetValue(drHeader["LINECD"]);

                this.dte01_OCCUR_DATE_OLD.SetValue(drHeader["OCCUR_DATE"]);//발생일자 : 기존값 저장.
                this.dte01_OCCUR_DATE.SetValue(drHeader["OCCUR_DATE"]);
                
                this.dte01_OCCUR_BEG_TIME.SetValue(drHeader["OCCUR_BEG_TIME"]);
                this.dte01_OCCUR_END_TIME.SetValue(drHeader["OCCUR_END_TIME"]);
                this.cdx01_NON_OPRCD.SetValue(drHeader["NON_OPRCD"]);
                this.txt01_DET_DESC.SetValue(drHeader["DET_DESC"]);
                this.lbl01_TIME_CAL_RES.Value = drHeader["TIME_DIFF"];
                //this.lbl01_STACD.Value = drHeader["STANM"];
                this.cbo01_INSTALL_POS.SetValue(drHeader["INSTALL_POS"]);
                this.grd01[1, "PERSON"] = drHeader["PERSON"];
                this.grd01[1, "OCCUR_TIME"] = drHeader["TIME_DIFF"];
                this.grd01[1, "STOP_TIME"] = drHeader["STOP_TIME_SUM"];
                this.grd01[1, "STOP_PERSON_TIME"] = drHeader["STOP_MH_SUM"];

               
                //this.cdx01_EQUIPCD.SetReadOnly(true); this.cdx01_EQUIPCD.Initialize();
                //this.cdx01_PROCCD.SetReadOnly(true); this.cdx01_PROCCD.Initialize();
                //this.cdx01_OUT_PARTNO.SetReadOnly(true); this.cdx01_OUT_PARTNO.Initialize();
                //this.cbo01_VENCD.SetReadOnly(true); this.cbo01_VENCD.Initialize();
                       
                this.grd02.SetValue(dtDetail);
                this.grd03.InitializeDataSource();

                ////2017-11-08
                //if (this.pnlLOCK.Visible)
                //    this.dte01_OCCUR_DATE.SetReadOnly(true);
                //else
                //    this.dte01_OCCUR_DATE.SetReadOnly(false);
                            
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void cdx01_LINECD_TextChanged(object sender, EventArgs e)
        {
            this.cdx01_EQUIPCD.HEUserParameterSetValue("LINECD", this.cdx01_LINECD.GetValue());
            //this.cdx01_PROCCD.HEUserParameterSetValue("LINECD", this.cdx01_LINECD.GetValue());
        }

        private void cdx01_LINECD_ValueChanged(object sender, EventArgs e)
        {
            //if (this.cdx01_LINECD.SelectedPopupValue != null)
            //    this.cdx01_LINECD_CodeBoxBindingAfter(null, null);
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx01_LINECD.Initialize();
            this.dte01_OCCUR_DATE_ValueChanged(null, null); //마감여부 체크 2017-11-08
        }

        private void cdx01_LINECD_Leave(object sender, EventArgs e)
        {
            //this.cdx01_LINECD_CodeBoxBindingAfter(null, null);
        }

        private void cdx01_LINECD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            if (!(this.cdx01_LINECD.Value.ToString().Equals("")))
            {
                _prdt_div = this.cdx01_LINECD.SelectedPopupValue["PRDT_DIV"].ToString();
                if (_prdt_div.Equals("A0A"))
                {
                    string where = string.Empty;
                    DataTable dt = this.GetTypeCode("A7").Tables[0].Copy();
                    if (this.cdx01_LINECD.SelectedPopupValue["INSTALL_POS"].ToString().Equals("A7FA"))
                    {
                        where = "'A7FL','A7FR',''";
                        dt.DefaultView.RowFilter = "OBJECT_ID IN (" + where + ")";
                        DataRow dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = "";
                        dt.Rows.InsertAt(dr, 0);
                        cbo01_INSTALL_POS.DataSource = dt;
                    }
                    else
                    {
                        where = "'A7RL','A7RR',''";
                        dt.DefaultView.RowFilter = "OBJECT_ID IN (" + where + ")";
                        DataRow dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = "";
                        dt.Rows.InsertAt(dr, 0);
                        cbo01_INSTALL_POS.DataSource = dt;
                    }
                }
                else
                {
                    this.cbo01_INSTALL_POS.DataBind("A7", "LR", true);
                }
            }
        }
        
        #endregion

        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet person)
        {
            try
            {
                if (this.cdx01_LINECD.GetValue().ToString().Equals(""))
                {
                    //MsgBox.Show("라인코드를 입력하세요");
                    MsgCodeBox.ShowFormat("PD00-0009", this.lbl01_LINECD.Text); //{0} 을(를) 입력하세요.
                    return false;
                }

                if (this.cdx01_NON_OPRCD.GetValue().ToString().Equals(""))
                {
                    //MsgBox.Show("비가동코드를 입력하세요");
                    MsgCodeBox.ShowFormat("PD00-0009", this.lbl01_NON_OPRCD.Text); //{0} 을(를) 입력하세요.
                    return false;
                }

                if (person.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("선택된 작업자가 없습니다.");
                    MsgCodeBox.Show("PD00-0085");
                    return false;
                }

                if (lbl01_TIME_CAL_RES.Text.Trim().Length == 0)
                {
                    //MsgBox.Show("시간 계산 버튼을 눌러주세요!");
                    MsgCodeBox.Show("PD00-0086");
                    return false;
                }

                //마감 여부 체크 2017-11-08
                if (this.IsLock())
                {
                    //마감완료된 건입니다. 변경이 불가합니다.
                    MsgCodeBox.Show("PD00-0087");
                    return false;
                }

                //if (MsgBox.Show("입력하신 비가동 실적 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                //마감 여부 체크 2017-11-08
                if (this.IsLock())
                {
                    //마감완료된 건입니다. 변경이 불가합니다.
                    MsgCodeBox.Show("PD00-0087");
                    return false;
                }

                //if (MsgBox.Show("선택하신 비가동 실적 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsCalWorkTime(HEParameterSet set)
        {
            int iend = Convert.ToInt32(set["END_TIME"].ToString().Replace(":", ""));
            int ibeg = Convert.ToInt32(set["BEG_TIME"].ToString().Replace(":", ""));
            if ((iend < 800 && iend < ibeg && ibeg < 800) || (iend > 800 && ibeg > 800 && ibeg >= iend))
            {
                //MsgBox.Show("발생시간을 확인해주세요!");
                MsgCodeBox.Show("PD00-0088");
                return false;
            }
            return true;
        }

        #endregion

        #region [ 헬퍼 메소드 정의 ]

        private DataSet MakePM6110Dataset(string nonOprNo)
        {
            DataSet source = null;

            try
            {
                source = AxFlexGrid.GetDataSourceSchema
                (
                    "CORCD", "BIZCD", "NON_OPRNO", "OCCUR_DATE",
                    "LINECD", "INSTALL_POS", "BEG_HH", "BEG_MM", "END_HH",
                    "END_MM", "NON_OPRCD", "PERSON", "STOP_TIME_SUM",
                    "STOP_MH_SUM", "STACD", "DET_DESC", "TIME_DIFF"
                );
                string[] OCCUR_BEG_TIME = this.dte01_OCCUR_BEG_TIME.GetValue().ToString().Split(':');
                string[] OCCUR_END_TIME = this.dte01_OCCUR_END_TIME.GetValue().ToString().Split(':');
                source.Tables[0].Rows.Add
                (
                    this.UserInfo.CorporationCode,
                    this.cbo01_BIZCD.GetValue(),
                    nonOprNo,
                    this.dte01_OCCUR_DATE.GetDateText(),
                    this.cdx01_LINECD.GetValue(),
                    this.cbo01_INSTALL_POS.GetValue(),
                    OCCUR_BEG_TIME[0],
                    OCCUR_BEG_TIME[1],
                    OCCUR_END_TIME[0],
                    OCCUR_END_TIME[1],
                    this.cdx01_NON_OPRCD.GetValue(),
                    this.grd01[1, "PERSON"],
                    this.grd01[1, "STOP_TIME"],
                    this.grd01[1, "STOP_PERSON_TIME"],
                    "", //--STACD
                    this.txt01_DET_DESC.GetValue(),
                    this.grd01[1, "OCCUR_TIME"]
                );
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }

            return source;
        }

        private DataSet MakePM6120Dataset(string nonOprNo)
        {
            DataSet person = null;

            try
            {
                person = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "NON_OPRNO", "EMPNO");
                foreach (DataRow row in person.Tables[0].Rows)
                {
                    row["CORCD"] = this.UserInfo.CorporationCode;
                    row["BIZCD"] = this.cbo01_BIZCD.GetValue();
                    row["NON_OPRNO"] = nonOprNo;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }

            return person;
        }

        //private DataSet MakePM6130Dataset(string nonOprNo)
        //{
        //    DataSet equip = null;

        //    try
        //    {
        //        equip = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "NON_OPRNO", "PROCCD", "EQUIPCD");
        //        equip.Tables[0].Rows.Add
        //        (
        //            this.UserInfo.CorporationCode,
        //            this.cbo01_BIZCD.GetValue(),
        //            nonOprNo,
        //            this.cdx01_PROCCD.GetValue(),
        //            this.cdx01_EQUIPCD.GetValue()
        //        );
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        throw ex;
        //    }

        //    return equip;
        //}

        //private DataSet MakePM6140Dataset(string nonOprNo)
        //{
        //    DataSet partno = null;

        //    try
        //    {
        //        partno = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "NON_OPRNO", "PARTNO", "VENDCD");
        //        partno.Tables[0].Rows.Add
        //        (
        //            this.UserInfo.CorporationCode,
        //            this.cbo01_BIZCD.GetValue(),
        //            nonOprNo,
        //            this.cdx01_OUT_PARTNO.GetValue(),
        //            this.cbo01_VENCD.GetValue()
        //        );
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        throw ex;
        //    }

        //    return partno;
        //}

        private void MoveEmployees(AxFlexGrid grdSource, AxFlexGrid grdDest)
        {
            try
            {
                if (this.GetByteCount(this.lbl01_TIME_CAL_RES.Value.ToString().Trim().Replace(",", "")) <= 0)
                {
                    MsgCodeBox.Show("PD00-0086"); //시간 계산 버튼을 눌러주세요
                    return;
                }

                if (Int32.Parse(this.lbl01_TIME_CAL_RES.Value.ToString().Trim().Replace(",", "")) <= 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0099", this.btn01_PD25220_BTN1.Text); //시간 계산 이(가) 잘못되었습니다.
                    return;
                }


                if (grdSource.Rows.Count <= 1)
                {
                    //MsgBox.Show("이동시키고자 하는 사원정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("PD00-0089");
                    return;
                }

                DataTable dtSource = grdSource.GetValue(AxFlexGrid.FActionType.All).Tables[0];
                DataTable dtChecked = dtSource.Clone();
                DataRow[] drChecked = dtSource.Select("CHK = 'Y'");

                if (drChecked.Length == 0)
                    return;

                for (int i = 0; i < drChecked.Length; i++)
                {
                    DataRow newRow = dtChecked.NewRow();
                    newRow["EMPNO"] = drChecked[i]["EMPNO"];
                    newRow["EMPNM"] = drChecked[i]["EMPNM"];
                    newRow["CHK"] = drChecked[i]["CHK"];

                    dtChecked.Rows.Add(newRow);
                }

                DataTable dtSelected = null;
                if (grdDest.Rows.Count <= 1)
                {
                    dtSelected = AxFlexGrid.GetDataSourceSchema("EMPNO", "EMPNM", "CHK").Tables[0];
                    dtSelected.Merge(dtChecked);
                }
                else
                {
                    dtSelected = grdDest.GetValue(AxFlexGrid.FActionType.All).Tables[0];
                    DataTable dtAppend = dtSelected.Clone();
                    foreach (DataRow row in dtChecked.Rows)
                    {
                        bool bExists = false;
                        string EMPNO = row["EMPNO"].ToString();
                        foreach (DataRow inRow in dtSelected.Rows)
                        {
                            string IN_EMPNO = inRow["EMPNO"].ToString();
                            if (EMPNO.Equals(IN_EMPNO))
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (!bExists)
                        {
                            DataRow newRow = dtAppend.NewRow();
                            newRow["EMPNO"] = row["EMPNO"];
                            newRow["EMPNM"] = row["EMPNM"];
                            newRow["CHK"] = "N";

                            dtAppend.Rows.Add(newRow);
                        }
                    }
                    dtSelected.Merge(dtAppend);
                }
                grdDest.SetValue(dtSelected);

                DataTable dtUnChecked = dtSource.Clone();
                DataRow[] drUnChecked = dtSource.Select("CHK <> 'Y'");
                for (int i = 0; i < drUnChecked.Length; i++)
                {
                    DataRow newRow = dtUnChecked.NewRow();
                    newRow["EMPNO"] = drUnChecked[i]["EMPNO"];
                    newRow["EMPNM"] = drUnChecked[i]["EMPNM"];
                    newRow["CHK"] = drUnChecked[i]["CHK"];

                    dtUnChecked.Rows.Add(newRow);
                }
                grdSource.SetValue(dtUnChecked);

                int iNonMinutes = 0;
                string strNonMinutes = this.lbl01_TIME_CAL_RES.Value.ToString().Trim().Replace(",", "");
                if (this.GetByteCount(strNonMinutes) > 0)
                    iNonMinutes = Int32.Parse(strNonMinutes);
                int iPerson = this.grd02.Rows.Count - 1;
                decimal iStopTime = iPerson * iNonMinutes;
                decimal iStopPersonTime = Math.Round(iStopTime / 60, 2, MidpointRounding.ToEven);

                this.grd01.SetValue(1, "PERSON", iPerson);
                this.grd01.SetValue(1, "OCCUR_TIME", iNonMinutes);
                this.grd01.SetValue(1, "STOP_TIME", iStopTime);
                this.grd01.SetValue(1, "STOP_PERSON_TIME", iStopPersonTime);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        /// <summary>
        /// 마감여부 확인 및 컨트롤 Disable 처리
        /// </summary>
        private void LockStatusCheck()
        {
            try
            {
                bool isLock = this.IsLock();
                if (isLock)
                {
                    this.SetControlLock(true);
                }
                else
                {
                    this.SetControlLock(false);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// bizcd, 날짜 기준으로 마감여부 조회
        /// </summary>
        /// <returns>true:마감, false:마감전</returns>
        private bool IsLock()
        {
            HEParameterSet paramSet2 = new HEParameterSet();

            paramSet2.Add("CORCD", this.UserInfo.CorporationCode);
            paramSet2.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            paramSet2.Add("OCCUR_DATE", this.dte01_OCCUR_DATE.GetDateText());

            
            DataSet dsLock = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LOCK_STA"), paramSet2, "OUT_CURSOR");
            if (dsLock.Tables[0].Rows.Count > 0 && dsLock.Tables[0].Rows[0]["LOCK_STA"].ToString().Equals("Y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 마감메시지, 각정 처리 버튼 활성/비활성 처리
        /// </summary>
        /// <param name="islock"></param>
        private void SetControlLock(bool islock)
        {
            //true;
            this.pnlLOCK.Visible = islock;

            //false;
            this.btn01_PD25220_BTN2.Enabled = !islock;
            this.btn01_PD25220_BTN3.Enabled = !islock;
            this.btn01_SELECT_PD25220.Enabled = !islock;
            this.btn01_CLEAR_PD25220.Enabled = !islock;
            this.GetCommonButton(COMMONBUTTONTYPE.SAVE).Enabled = !islock;
            this.GetCommonButton(COMMONBUTTONTYPE.DELETE).Enabled = !islock;
        }

        #endregion

        private void dte01_OCCUR_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.BtnReset_Click(null, null); //입력 영역 초기화
            
            //발생일자 사용자 직접 변경시 그리드 초기화 함.
            if(!this.dte01_OCCUR_DATE_OLD.GetDateText().ToString().Equals(this.dte01_OCCUR_DATE.GetDateText().ToString()))
                this.grd04.InitializeDataSource();//조회목록 초기화

            this.LockStatusCheck(); //마감여부 체크 2017-11-08
        }

       
    }
}