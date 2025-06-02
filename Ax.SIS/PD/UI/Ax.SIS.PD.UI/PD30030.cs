#region ▶ Description & History
/* 
 * 프로그램명 : PD30030 수지 탱크 관리
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
    /// 수지 탱크 관리
    /// </summary>
    public partial class PD30030 : AxCommonBaseControl
    {
        //private IPD30030 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD30030";
        //private IPD30010 _WSCOM2;
        //private IPDCOMMON_ERM _WSCOM_ERM;

        private AxComboList grd_PARTNO;
        private AxComboList grd_WORK_POS;

        public PD30030()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD30030>("PD", "PD30030.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM2 = ClientFactory.CreateChannel<IPD30010>("PD", "PD30010.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");

            grd_PARTNO = new AxComboList();
            grd_WORK_POS = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PARTNO_BeforeOpen);
                this.grd_PARTNO.SelectedValueChanged += new EventHandler(grd_PARTNO_SelectedValueChanged);

                this.grd_WORK_POS.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_WORK_POS_BeforeOpen);
                this.grd_WORK_POS.SelectedValueChanged += new EventHandler(grd_WORK_POS_SelectedValueChanged);
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "수지호기", "RES_TANK_NO", "RESIN_CODE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "수지호기명", "RES_TANK_NM", "RESIN_NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "최대투입중량", "MAX_WT", "MAX_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "실시간 중량", "CURRENT_WT", "REAL_WT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "단위", "UNIT", "UNIT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "알람 레벨(%)", "ALARM_LEVEL", "ALARM_LEVEL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "수지 PART NO", "PARTNO", "RESIN_PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "공장코드", "WORK_POS", "PLANTCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 180, "설정 최소값(Kg)", "SET_MIN_VAL", "SET_MIN_VAL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 180, "설정 최대값(Kg)", "SET_MAX_VAL", "SET_MAX_VAL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 180, "수지램프 점등위치", "RES_LOAD_POS", "RES_LOAD_POS");
                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RES_LOAD_POS");
                this.grd01.Cols["RES_LOAD_POS"].EditMask = "#"; //0~9만 입력(1~7만 입력해야하므로 사용자의 입력실수를 줄이기 위해)
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAX_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CURRENT_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "ALARM_LEVEL");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SET_MIN_VAL");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SET_MAX_VAL");

                

                this.grd01.Cols["PARTNO"].Editor = this.grd_PARTNO;
               // this.grd01.Cols["WORK_POS"].Editor = this.grd_WORK_POS;

                this.grd01.Cols["SET_MIN_VAL"].Format = "###,###,###,##0.00";
                this.grd01.Cols["SET_MAX_VAL"].Format = "###,###,###,##0.00";


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "수지 PART NO", "PARTNO", "RESIN_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "CAR_TYPE","VIN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "색상", "COLOR","CLR");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                DataTable dtPlant = new DataTable();
                dtPlant.Columns.Add("CODE");
                dtPlant.Columns.Add("NAME");

                dtPlant.Rows.Add("P01", this.GetLabel("PLANT_P01")); //"생산4동");  //@@@
                dtPlant.Rows.Add("P02", this.GetLabel("PLANT_P02")); //"PILOT");   //@@@
                dtPlant.Rows.Add("P03", this.GetLabel("PLANT_P03")); //"생산2동");  //@@@
                dtPlant.Rows.Add("P04", this.GetLabel("PLANT_P04")); //"두서공장"); //@@@

                this.cbl01_Plant.DataBind(dtPlant, "CODE", "NAME", this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L"); //@@@공장코드 ; 공장명

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("WORK_POS", this.cbl01_Plant.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                this.grd02.SetValue(getPartNoData().Tables[0]);
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "RES_TANK_NO", "RES_TANK_NM", "MAX_WT", "CURRENT_WT", "UNIT", "ALARM_LEVEL", "PARTNO", "EMPNO", "WORK_POS", "RES_LOAD_POS"
                    , "SET_MIN_VAL", "SET_MAX_VAL"
                    );

                foreach (DataRow rows in source.Tables[0].Rows)
                    rows["EMPNO"] = this.UserInfo.EmpNo;

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 수지 탱크 정보가 저장되었습니다.");
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

        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "RES_TANK_NO");

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 수지 탱크 정보가 삭제되었습니다");
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

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "BIZCD", this.UserInfo.BusinessCode);
                }
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
                DataTable dtSource = getPartNoData().Tables[0];
                //A.GRADE_NO, A.PARTNO, B.PARTNM, A.CAR_TYPE, A.COLOR,
       	        //        A.SPEC, A.CUSTCD, C.VENDNM AS CUSTNM, A.BEG_DATE, A.END_DATE

                //필요없는 데이터는 빼고 PARTNO만 다시 추출
                DataTable dt = new DataTable();
                dt.Columns.Add("PARTNO");
                dt.Columns.Add("WORK_POS");
                foreach (DataRow dr  in dtSource.Rows)
                {
                    DataRow r = dt.NewRow();
                    r["PARTNO"] = dr["PARTNO"];
                    r["WORK_POS"] = dr["WORK_POS"];
                    dt.Rows.Add(r);
                }

                //this.grd_PARTNO.DataBind(dt, "PARTNO", "PARTNO", "품번", "L");
                this.grd_PARTNO.DataBind(dt, "PARTNO", "PARTNO", GetLabel("PARTNOTITLE") + ";" + this.GetLabel("PLANTCD"), "L;L"); //@@@ 품번; 공장코드
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PARTNO_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "PARTNO", this.grd_PARTNO.GetValue("PARTNO"));
            this.grd01.SetValue(row, "WORK_POS", this.grd_PARTNO.GetValue("WORK_POS"));
        }

        void grd_WORK_POS_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("WORK_POS");
                dt.Columns.Add("WORK_POSNM");

                DataRow r = dt.NewRow();
                r["WORK_POS"] = "P01";
                //r["WORK_POSNM"] = "생산4동";
                r["WORK_POSNM"] = this.GetLabel("PLANT_P01");// "생산4동"; //@@@
                dt.Rows.Add(r);

                r = dt.NewRow();
                r["WORK_POS"] = "P02";
                //r["WORK_POSNM"] = "PILOT";
                r["WORK_POSNM"] = this.GetLabel("PLANT_P02"); //"PILOT";
                dt.Rows.Add(r);

                r = dt.NewRow();
                r["WORK_POS"] = "P03";
                //r["WORK_POSNM"] = "생산2동"; 
                r["WORK_POSNM"] = this.GetLabel("PLANT_P03"); //"생산2동"; //@@@
                dt.Rows.Add(r);

                r = dt.NewRow();
                r["WORK_POS"] = "P04";
                //r["WORK_POSNM"] = "생산2동";
                r["WORK_POSNM"] = this.GetLabel("PLANT_P04"); //"두서공장"; //@@@
                dt.Rows.Add(r);

                //this.grd_WORK_POS.DataBind(dt, "WORK_POS", "WORK_POS", "공장코드;공장코드명", "C;L");
                this.grd_WORK_POS.DataBind(dt, "WORK_POS", "WORK_POS", this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L"); //@@@
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_WORK_POS_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "WORK_POS", this.grd_WORK_POS.GetValue("WORK_POS"));

        }
        
        #endregion

        #region [사용자 정의 메서드]

        private DataSet getPartNoData()
        {
            DataSet source = new DataSet();
            try
            {
                //string bizcd = this.UserInfo.BusinessCode;
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();                
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("GRADE_NO", "");
                set.Add("WORK_POS", this.cbl01_Plant.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                //this.BeforeInvokeServer(true);
                //source = _WSCOM2.INQUERY(bizcd, set);
                source = _WSCOM_N.ExecuteDataSet("APG_PD30010.INQUERY", set);
                //this.AfterInvokeServer();                
            }
            catch (Exception ex)
            {
                //this.AfterInvokeServer();
                throw ex;
            }

            return source;
        }
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 수지 탱크 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");			
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string RES_TANK_NO = this.grd01.GetValue(i, "RES_TANK_NO").ToString();
                    string RES_TANK_NM = this.grd01.GetValue(i, "RES_TANK_NM").ToString();

                    if (this.GetByteCount(RES_TANK_NO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 수지호기가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["RES_TANK_NO"].Caption.ToString());				
                        return false;
                    }

                    if (this.GetByteCount(RES_TANK_NO) > 10)
                    {
                        //MsgBox.Show(i + " 번째 행에 수지호기는 10byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols["RES_TANK_NO"].Caption.ToString(), "10");				
                        return false;
                    }

                    if (this.GetByteCount(RES_TANK_NM) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 수지호기명이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["RES_TANK_NM"].Caption.ToString());	
                        return false;
                    }

                    if (this.GetByteCount(RES_TANK_NM) > 50)
                    {
                        //MsgBox.Show(i + " 번째 행에 수지호기명은 50byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols["RES_TANK_NM"].Caption.ToString(), "50");	
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 수지 탱크 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //MsgBox.Show("삭제할 수지 탱크 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");	
                    return false;
                }

                //if (MsgBox.Show("선택하신 수지 탱크 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
        //2014.02.10 - MES1210 사출수지탱크 마스터 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
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
        #endregion

    }
}
