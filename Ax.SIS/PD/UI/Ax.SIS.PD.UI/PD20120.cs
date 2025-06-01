#region ▶ Description & History
/* 
 * 프로그램명 : 고객 출고 정보 조회
 * 설     명 : 
 * 최초작성자 : SJH
 * 최초작성일 : 2019-04-12
 * 최종수정자 : SJH
 * 최종수정일 : 2019-04-12
 * 수정  내용 : 
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2019-04-12		SJH		최초 개발 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using System.Windows.Forms;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>기타출고 수기 등록</b>
    /// </summary>
    public partial class PD20120 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        public PD20120()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        private void PD20120_Load(object sender, EventArgs e)
        {
            try
            {
                this.AxDockingTab1.LinkPanel = this.panel1;
                this.AxDockingTab1.LinkBody = this.panel2;
                this.AxDockingTab1.PanelWidth = 250;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //사업장코드
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode); 

                //납품일자
                this.dtp01_FROM_DATE.SetValue(DateTime.Now);
                this.dtp01_TO_DATE.SetValue(DateTime.Now);
                
                //그리드
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 86, "출하지시일자", "PLAN_DATE", "OUT_DIRECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "출하번호", "OUTNO", "OUTNO2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "SEQ", "OUTSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "출하유형", "INV_STATUS", "OUT_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "평가클래스", "PRDT_DIV", "ESTI_CLASS");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 233, "Part Naem", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 76, "저장위치", "STR_LOC", "STR_LOCNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 66, "단위", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "오더수량", "SHIP_PLAN_QTY", "PO_QTY3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 98, "출고수량", "SHIP_RSLT_QTY", "OUT_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 78, "출고일자", "DELI_DATE", "OUT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "출고처", "VENDORCD", "DELI_VEND");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "출고처명", "VENDORCDNM", "DELI_VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "요청부서", "REQT_TEAMCD", "REQ_DEPT");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Insert Date", "INSERT_DATE", "INSERT_DATE");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Update Date", "UPDATE_DATE", "UPDATE_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Update ID", "UPDATE_ID", "UPDATE_ID");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("JOB_TYPE");
                this.grd01.AddHiddenColumn("PLANTCD");
                this.grd01.AddHiddenColumn("PID");
                this.grd01.AddHiddenColumn("SAL_PNO");
                this.grd01.AddHiddenColumn("ALCCD");
                this.grd01.AddHiddenColumn("OUT_DIV");
                this.grd01.AddHiddenColumn("OUT_DIV_DESC");
                this.grd01.AddHiddenColumn("REG_DATE");
                this.grd01.AddHiddenColumn("NOTE");
                this.grd01.AddHiddenColumn("STATUS");
                this.grd01.AddHiddenColumn("CHNG_QTY"); // MES7341에만 존재

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SHIP_RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");

                this.grd01.Cols["SHIP_RSLT_QTY"].Style.BackColor = System.Drawing.Color.LightYellow;
                this.grd01.Cols["DELI_DATE"].Style.BackColor = System.Drawing.Color.LightYellow;

                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);

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
                if (!this.IsQueryValid())
                {
                    return;
                }

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("FROM_DATE", this.dtp01_FROM_DATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("TO_DATE", this.dtp01_TO_DATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("OUTNO", this.txt01_OUTNO.GetValue());                
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("RSLT_YN", this.chk01_RESULT_INFO_SEARCH.Checked ? "Y" : "N");
                paramSet.Add("DIREC_YN", (this.rdo01_OUT_DIRECT_DATE.Checked) ? "Y" : "N");                
                paramSet.Add("LANG_SET", this.UserInfo.Language); 

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD20120.INQUERY", paramSet);                
                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);

                this.AfterInvokeServer();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }


        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {   
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "OUTNO", "OUTSEQ", "INV_STATUS"
                                        , "JOB_TYPE", "PLAN_DATE", "DELI_DATE", "VENDORCD", "PLANTCD", "REQT_TEAMCD", "PID"
                                        , "PARTNO", "SAL_PNO", "ALCCD", "STR_LOC", "SHIP_PLAN_QTY", "SHIP_RSLT_QTY", "UNIT"
                                        , "OUT_DIV", "OUT_DIV_DESC", "REG_DATE", "PRDT_DIV", "NOTE", "STATUS", "CHNG_QTY"
                                        , "USER_ID", "RSLT_YN");

                foreach (DataRow rows in source.Tables[0].Rows)
                {   
                    rows["USER_ID"] = this.UserInfo.UserID;
                    rows["RSLT_YN"] = ((this.chk01_RESULT_INFO_SEARCH.Checked) ? "Y" : "N");                    
                }

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx("APG_PD20120.SAVE", source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);                
                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {                
                this.txt01_PARTNO.Initialize(); 
                this.txt01_OUTNO.Initialize();
                this.chk01_RESULT_INFO_SEARCH.Checked = false;
                this.rdo01_OUT_DIRECT_DATE.Checked = true;
                this.dtp01_FROM_DATE.Initialize();
                this.dtp01_TO_DATE.Initialize();
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
          
        #region [ 유효성 체크 ]

        private bool IsQueryValid()
        { 
            return true;
        }

        private bool IsSaveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {   
                MsgCodeBox.Show("CD00-0042");
                return false;
            }

            for (int i = 0; i < source.Tables[0].Rows.Count; i++)
            {
                DataRow row = source.Tables[0].Rows[i];
                DataRow seq = source.Tables[1].Rows[i];

                if (this.Nvl(row["DELI_DATE"], "").ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("{0}행의 {차종}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["DELI_DATE"].Caption.ToString());
                    return false;
                }

                if (this.Nvl(row["SHIP_RSLT_QTY"], "").ToString().Length == 0)
                {                    
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["SHIP_RSLT_QTY"].Caption.ToString());
                    return false;
                }
            }
            //저장하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion

        private void grd01_SetupEditor(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Row < grd01.Rows.Fixed) return;
            if (this.grd01.Cols[e.Col].Name.Equals("DELI_DATE"))
            {
                grd01.Editor.Text = this.grd01.GetValue(e.Row, e.Col).ToString();
            }
        }
    }
}
