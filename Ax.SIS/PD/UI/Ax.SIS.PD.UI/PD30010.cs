#region ▶ Description & History
/* 
 * 프로그램명 : PD30010 수지 Grade 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
 *              2017-10-13    배명희     grd_PARTNO → CM20042P2 팝업 대체 → PD30010P1 팝업 대체
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

using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class PD30010 : AxCommonBaseControl
    {
        //private IPD30010 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private AxComboList grd_PARTNO; → CM20042P2 팝업 대체
        private AxComboList grd_CUSTCD;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD30010";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        private AxComboList grd_WORK_POS;

        public PD30010()
        {
            InitializeComponent();


            //_WSCOM = ClientFactory.CreateChannel<IPD30010>("PD", "PD30010.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //grd_PARTNO = new AxComboList();
            grd_CUSTCD = new AxComboList();
            grd_WORK_POS = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //this.grd_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PARTNO_BeforeOpen);
                //this.grd_PARTNO.SelectedValueChanged += new EventHandler(grd_PARTNO_SelectedValueChanged);
                this.grd_CUSTCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_CUSTCD_BeforeOpen);
                this.grd_CUSTCD.SelectedValueChanged += new EventHandler(grd_CUSTCD_SelectedValueChanged);
                this.grd_WORK_POS.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_WORK_POS_BeforeOpen);
                this.grd_WORK_POS.SelectedValueChanged += new EventHandler(grd_WORK_POS_SelectedValueChanged);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "수지 PART NO", "PARTNO", "RESIN_PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "수지 PART NAME", "PARTNM", "MIXER_PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장코드", "WORK_POS", "PLANTCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "Grade No", "GRADE_NO", "GRADE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "CAR_TYPE", "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "색상", "COLOR", "CLR");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "규격", "SPEC", "STANDARD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "납품업체코드", "CUSTCD", "DELI_COMPANY_CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "납품업체명", "CUSTNM", "DELI_COMPANY_NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적용일자", "BEG_DATE", "APP_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "종료일자", "END_DATE", "EDATE");

                //this.grd01.Cols["PARTNO"].Editor = grd_PARTNO;
                this.grd01.Cols["CUSTCD"].Editor = grd_CUSTCD;

                this.grd01.Cols["WORK_POS"].Editor = this.grd_WORK_POS;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                DataTable dtPlant = new DataTable();
                dtPlant.Columns.Add("CODE");
                dtPlant.Columns.Add("NAME");

                dtPlant.Rows.Add("P01", this.GetLabel("PLANT_P01")); // "생산4동");
                dtPlant.Rows.Add("P02", this.GetLabel("PLANT_P02"));//"PILOT");
                dtPlant.Rows.Add("P03", this.GetLabel("PLANT_P03"));//"생산2동");
                dtPlant.Rows.Add("P04", this.GetLabel("PLANT_P04"));//"두서공장");

                //this.cbl01_Plant.DataBind(dtPlant, "CODE", "NAME", "공장코드" + ";" + "공장명", "C;L");
                this.cbl01_Plant.DataBind(dtPlant, "CODE", "NAME", this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

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
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("GRADE_NO", this.txt01_GRADE_NO.GetValue());
                set.Add("WORK_POS", this.cbl01_Plant.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "PARTNO", "GRADE_NO", "WORK_POS", "CAR_TYPE", "COLOR", "SPEC", "CUSTCD", "BEG_DATE", "END_DATE", "EMPNO", "CORCD", "BIZCD");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["CORCD"] = this.UserInfo.CorporationCode;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 수지 Grade 정보가 저장되었습니다.");
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
                    "PARTNO", "GRADE_NO", "CORCD", "BIZCD");
                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["CORCD"] = this.UserInfo.CorporationCode;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                }
                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 수지 Grade 정보가 삭제되었습니다");
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

        #region [컨트롤 이벤트]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "BEG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                    this.grd01.SetValue(i, "END_DATE", "9998-12-31");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //void grd_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("LANG_SET", this.UserInfo.Language);
        //    DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_RESPARTNO"), set).Tables[0];
        //    //DataTable source = _WSCOM_ERM.INQUERY_COMBO_RESPARTNO().Tables[0];
        //    //this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", "품번;품명", "L;L");
        //    this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", GetLabel("PARTNOTITLE") + ";" + GetLabel("PARTNONM"), "L;L");
        //}

        //void grd_PARTNO_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    int row = this.grd01.SelectedRowIndex;

        //    this.grd01.SetValue(row, "PARTNM", this.grd_PARTNO.GetValue("PARTNM"));

        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("PARTNO", this.grd_PARTNO.GetValue());
        //    set.Add("LANG_SET", this.UserInfo.Language);
        //    DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_CARTYPE"), set).Tables[0];
        //    //DataTable source = _WSCOM_ERM.INQUERY_CARTYPE(set).Tables[0];

        //    if (source.Rows.Count == 0) return;

        //    this.grd01.SetValue(row, "CAR_TYPE", source.Rows[0]["VINCD"].ToString());
        //}

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = this.grd01.MouseRow;
            int col = this.grd01.MouseCol;
            if (row < this.grd01.Rows.Fixed || row >= this.grd01.Rows.Count) return;
            if(col != this.grd01.Cols["PARTNO"].Index) return;


            AxCodeBox cb = new AxCodeBox();
            cb.HEPopupHelper = new PD30010P1();
            cb.PopupTitle = this.GetLabel("PD30010P1");
            cb.CodeParameterName = "PARTNO";
            cb.NameParameterName = "PARTNM";            
            cb.HEUserParameterSetValue("LANG_SET", UserInfo.Language);            

            PD30010P1 frm = new PD30010P1();
            frm.Initialize_Helper(cb);
            PopupHelper helper = new PopupHelper(frm, this.GetLabel("PD30010P1"));
            
            helper.ShowDialog();
            if (helper.SelectedData != null)
            {
                DataRow dr = (DataRow)helper.SelectedData;
                this.grd01.SetValue(row, "PARTNO", dr["PARTNO"]);
                this.grd01.SetValue(row, "PARTNM", dr["PARTNM"]);
                this.grd01.SetValue(row, "CAR_TYPE", dr["VINCD"]);
            }
            
            
        }

        void grd_CUSTCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("LANG_SET", this.UserInfo.Language);
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_VENDLIST"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_VENDLIST(set).Tables[0];
            //this.grd_CUSTCD.DataBind(source, "VENDCD", "VENDCD", "납품업체코드;납품업체명", "C;L");
            this.grd_CUSTCD.DataBind(source, "VENDCD", "VENDCD", GetLabel("DELI_COMPANY_CODE")+";"+GetLabel("DELI_COMPANY_NAME"), "C;L");

        }

        void grd_CUSTCD_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "CUSTNM", this.grd_CUSTCD.GetValue("VENDNM"));
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
                r["WORK_POSNM"] = this.GetLabel("PLANT_P01");// "생산4동";//@@@
                dt.Rows.Add(r);

                r = dt.NewRow();
                r["WORK_POS"] = "P02";
                //r["WORK_POSNM"] = "PILOT";
                r["WORK_POSNM"] = this.GetLabel("PLANT_P02"); // "PILOT";
                dt.Rows.Add(r);

                r = dt.NewRow();
                r["WORK_POS"] = "P03";
                //r["WORK_POSNM"] = "생산2동";
                r["WORK_POSNM"] = this.GetLabel("PLANT_P03"); // "생산2동";//@@@
                dt.Rows.Add(r);

                r = dt.NewRow();
                r["WORK_POS"] = "P04";
                //r["WORK_POSNM"] = "생산2동";
                r["WORK_POSNM"] = this.GetLabel("PLANT_P04");// "두서공장";//@@@
                dt.Rows.Add(r);

                //this.grd_WORK_POS.DataBind(dt, "WORK_POS", "WORK_POS", "공장코드;공장코드명", "C;L");
                this.grd_WORK_POS.DataBind(dt, "WORK_POS", "WORK_POS", this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");//@@@
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

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 수지 Grade 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");				
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string PARTNO = this.grd01.GetValue(i, "PARTNO").ToString();
                    string GRADE_NO = this.grd01.GetValue(i, "GRADE_NO").ToString();
                    string CAR_TYPE = this.grd01.GetValue(i, "CAR_TYPE").ToString();
                    string CUSTCD = this.grd01.GetValue(i, "CUSTCD").ToString();
                    string BEG_DATE = this.grd01.GetValue(i, "BEG_DATE").ToString();
                    string END_DATE = this.grd01.GetValue(i, "END_DATE").ToString();

                    if (this.GetByteCount(PARTNO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 수지 PARTNO가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["PARTNO"].Caption.ToString());			
                        return false;
                    }

                    if (this.GetByteCount(GRADE_NO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 GRADE NO가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["GRADE_NO"].Caption.ToString());			
                        return false;
                    }

                    if (this.GetByteCount(GRADE_NO) > 20)
                    {
                        //MsgBox.Show(i + " 번째 행에 GRADE NO는 20byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols["GRADE_NO"].Caption.ToString(), "20");			
                        return false;
                    }

                    if (this.GetByteCount(CAR_TYPE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 차종이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["CAR_TYPE"].Caption.ToString());		
                        return false;
                    }

                    if (this.GetByteCount(CUSTCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 납품업체가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["CUSTCD"].Caption.ToString());		
                        return false;
                    }

                    if (this.GetByteCount(BEG_DATE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 적용일자가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["BEG_DATE"].Caption.ToString());		
                        return false;
                    }

                    if (this.GetByteCount(END_DATE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 종료일자가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols["END_DATE"].Caption.ToString());		
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 수지 Grade 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //MsgBox.Show("삭제할 수지 Grade 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");		
                    return false;
                }

                //if (MsgBox.Show("선택하신 수지 Grade 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
        //2014.02.10 - MES1220 수지 GRADE 관리 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES1220", bizcd).Tables[0].Rows[0][0].ToString();

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
