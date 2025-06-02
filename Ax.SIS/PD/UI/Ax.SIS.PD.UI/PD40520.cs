#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
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
    /// 수지 Grade 관리
    /// </summary>
    public partial class PD40520 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxComboList grd_PARTNO;
        private AxComboList grd_CUSTCD;
        private string PACKAGE_NAME = "APG_PD40520";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        #region [ 초기화 작업 정의 ]

        public PD40520()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD40520>("PD", "PD40520.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            grd_PARTNO = new AxComboList();
            grd_CUSTCD = new AxComboList();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PARTNO_BeforeOpen);
                this.grd_PARTNO.SelectedValueChanged += new EventHandler(grd_PARTNO_SelectedValueChanged);
                this.grd_CUSTCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_CUSTCD_BeforeOpen);
                this.grd_CUSTCD.SelectedValueChanged += new EventHandler(grd_CUSTCD_SelectedValueChanged);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "금형번호(2)", "MOLDNO2", "MOLDNO2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "작업자", "WORKER", "WORKER");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "투입일시", "IN_DATE", "IN_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "추출일시", "OUT_DATE", "EXT_DATE");


                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Date, "IN_DATE");
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Date, "OUT_DATE");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

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
                string bizcd = cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("MOLDNO", this.txt01_MOLDNO.GetValue());
                set.Add("ST_DATE", this.dtp01_INSPEC_SDATE.GetDateText().ToString().Replace("-",""));
                set.Add("ED_DATE", this.dtp01_INSPEC_EDATE.GetDateText().ToString().Replace("-", ""));
                set.Add("NON_OUT", chk01_PD40520_CHK_1.Checked == true ? "Y" : "N");

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
        
        #endregion

        #region [ 기타 컨트롤 이벤트 ]

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

        void grd_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("LANG_SET", this.UserInfo.Language);
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_RESPARTNO"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_RESPARTNO().Tables[0];
            ////this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", "품번;품명", "L;L");
            this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", GetLabel("PARTNO3") + ";" + GetLabel("PARTNONM"), "L;L");
        }

        void grd_PARTNO_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "PARTNM", this.grd_PARTNO.GetValue("PARTNM"));

            HEParameterSet set = new HEParameterSet();
            set.Add("PARTNO", this.grd_PARTNO.GetValue());
            set.Add("LANG_SET", this.UserInfo.Language);
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_CARTYPE"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_CARTYPE(set).Tables[0];

            if (source.Rows.Count == 0) return;

            this.grd01.SetValue(row, "CAR_TYPE", source.Rows[0]["VINCD"].ToString());
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
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), grd01.Cols["PARTNO"].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(GRADE_NO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 GRADE NO가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), grd01.Cols["GRADE_NO"].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(GRADE_NO) > 20)
                    {
                        //MsgBox.Show(i + " 번째 행에 GRADE NO는 20byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), grd01.Cols["GRADE_NO"].Caption.ToString(), "20");
                        return false;
                    }

                    if (this.GetByteCount(CAR_TYPE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 차종이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), grd01.Cols["CAR_TYPE"].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(CUSTCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 납품업체가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), grd01.Cols["CUSTCD"].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(BEG_DATE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 적용일자가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), grd01.Cols["BEG_DATE"].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(END_DATE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 종료일자가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), grd01.Cols["END_DATE"].Caption.ToString());
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

    }
}
