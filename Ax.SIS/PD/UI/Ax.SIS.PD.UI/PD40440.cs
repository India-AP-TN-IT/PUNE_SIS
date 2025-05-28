#region ▶ Description & History
/* 
 * 프로그램명 : PD40440 당사기준 모듈자재 LOT추적(실시간)
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


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 통전검사 이력 조회
    /// </summary>
    public partial class PD40440 : AxCommonBaseControl
    {
        //private IPD40440 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40440";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40440()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM  = ClientFactory.CreateChannel<IPD40440>("PD", "PD40440.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "검사일시", "INSPECT_DT", "INSPECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "제품LOT", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "제품품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "자재LOT", "MAT_LOTNO", "MAT_LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "자재품번", "MAT_PARTNO", "MAT_PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "작업자", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "입고일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "재고파레트", "PALLET", "PALLET");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "출고일자", "OUT_READ_DATE", "OUT_DATE");

                //ASSYNO, a.ASSY_REV, a.PARTNO , b.PARTNM

                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "제품품번", "ASSYNO", "ASSYNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "버젼", "ASSY_REV", "ASSY_REV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재품번", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "자재품명", "PARTNM", "PARTNM");

                //LOTNO, SUBSTR(LOTNO, 8) PARTNO, MAT_LOTNO, MAT_PARTNO, REPLACE(INSPECT_DATE,'-','') || INSPECT_TIME  INSPECT_DT
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "모듈LOT", "LOTNO", "LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "모듈품번", "PARTNO", "PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "자재LOT", "MAT_LOTNO", "MAT_LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재품번", "MAT_PARTNO", "MAT_PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "검사일시", "INSPECT_DT", "INSPECT_DATE");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                dtp01_BEG_INSPEC_DATE.Value = dt;
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
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("ST_DATE", this.dtp01_BEG_INSPEC_DATE.GetDateText());
                set.Add("ED_DATE", this.dtp01_END_INSPEC_DATE.GetDateText());
                set.Add("MOD_NO", "M1M02");
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.grd01.SetValue(source);
                //this.grd02.InitializeDataSource();
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

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                this.cbl01_LINECD.DataBind(source1.Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_EnterCell(object sender, EventArgs e)
        {
            try
            {

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;
                /*
                 IN_LINECD          IN  VARCHAR2,
        IN_PARTNO           IN  VARCHAR2,
        IN_ST_DATE         IN  VARCHAR2,
        IN_ED_DATE         IN  VARCHAR2,
        IN_MOD_NO          IN  VARCHAR2,
                 */

                string CORCD = this.UserInfo.CorporationCode;
                string BIZCD = bizcd;
                string LINECD = this.grd01.GetValue(row, "LINECD").ToString();
                string ST_DATE = this.dtp01_BEG_INSPEC_DATE.GetDateText().ToString();
                string ED_DATE = this.dtp01_END_INSPEC_DATE.GetDateText().ToString();
                string PARTNO = this.grd01.GetValue(row, "PARTNO").ToString();
                string MAT_LOT = this.grd01.GetValue(row, "MAT_LOTNO").ToString();
                string LOTNO = this.grd01.GetValue(row, "LOTNO").ToString();
                Lbl_Assy.Text = LOTNO;
                HEParameterSet set = new HEParameterSet();
                set.Add("LINECD", LINECD);
                set.Add("PARTNO", PARTNO);
                set.Add("ST_DATE", ST_DATE);
                set.Add("ED_DATE", ED_DATE);
                set.Add("MOD_NO", "M1M02");
                set.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source1 = _WSCOM.INQUERY_DETAIL_HANIL(bizcd, set);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL_HANIL"), set, "OUT_CURSOR");

                this.grd02.SetValue(source1);
                
                HEParameterSet set2 = new HEParameterSet();

                set2.Add("MAT_LOT", MAT_LOT);
                
                //DataSet source2 = _WSCOM.INQUERY_DETAIL_TR(bizcd, set2);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL_TR"), set2, "OUT_CURSOR");

                this.grd03.SetValue(source2);
                string rVal = "";
                string lVal = "";
                for (int r = 1; r < grd02.Rows.Count; r++)
                {
                    rVal = this.grd02.GetValue(r, "PARTNO").ToString();
                    if (!IsValidPart(rVal))
                    {
                        grd02.Rows[r].StyleNew.BackColor = Color.Red;
                    }

                }


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            grd01.Focus();
        }
        
        #endregion

        #region [ 유효성 체크 ]

        private bool IsValidPart(string val)
        {
            string lVal = "";
            for (int row = 0; row < grd03.Rows.Count; row++)
            {
                lVal = this.grd03.GetValue(row, "MAT_PARTNO").ToString();
                if (val == lVal)
                {
                    return true;
                }

            }
            return false;
        }
        #endregion 
    }
}
