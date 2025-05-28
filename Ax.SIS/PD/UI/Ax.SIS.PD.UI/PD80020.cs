#region ▶ Description & History
/* 
 * 프로그램명 : 공정용PC관리
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 배명희
 * 최종수정일 : 2013-12-11
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------------
 *				2013-12-11	  배명희		[#001] 저장/삭제시 MES.PKG_DN_MESCODE 호출(MES서버로 코드 다운로드실행)
 *				2014-02-13    배명희     [#002] 라인코드별 근무형태 저장 로직 추가.
 *				2017-07~09    배명희     SIS 이관
 * 
*/
#endregion

using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 공정용PC관리
    /// </summary>
    public partial class PD80020 : AxCommonBaseControl
    {
        private const int _MAX_SCREW_POINT = 47;
        private Color _OddRow_BackColor = Color.FromArgb(228, 248, 252);
        private Color _OddRow_ForeColor = Color.Black;
        private Color _EvenRow_BackColor = Color.White;
        private Color _EvenRow_ForeColor = Color.Black;
        private Color _GridLine_Color = Color.Gray;
        //private IPD80020 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD80020";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;


        private string CURRENT_CORCD = "";
        private string CURRENT_BIZCD = "";
        private string CURRENT_LINECD = "";

        private DataTable _DT_SCREEN;

        #region [ 초기화 작업 정의 ]

        public PD80020()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD80020>("PD", "PD80020.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
            _DT_SCREEN = new DataTable();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region grd01 - 법인코드

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "법인코드", "CORCD","CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "법인명", "CORNM","CORNM");                
                
                ////기본 색상 처리
                //grd01.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd01.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd01.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd01.Styles.Normal.ForeColor = _EvenRow_ForeColor;
              
                #endregion

                #region grd02 - 사업장

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd02.SelectionMode = SelectionModeEnum.Cell;

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "법인코드", "CORCD", "CORCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "사업장코드", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true,  AxFlexGrid.FtextAlign.L, 150, "사업장명",   "BIZCDNM","BIZNM");                
                
                ////기본 색상 처리
                //grd02.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd02.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd02.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd02.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd02.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd03 - 라인코드

                this.grd03.AllowEditing = true;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.SelectionMode = SelectionModeEnum.Cell;

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "법인코드", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "사업장코드", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "라인코드", "LINECD", "LINECD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "라인명", "LINENM", "LINENM");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 60, "근무형태", "WORK_TYPE", "WORK_DIVNM");    //#002

                
                this.grd03.CurrentContextMenu.Items[0].Visible = false;
                this.grd03.CurrentContextMenu.Items[1].Visible = false;
                this.grd03.CurrentContextMenu.Items[2].Visible = false;

                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.LoadWorkTypeCombo(this.UserInfo.CorporationCode, this.UserInfo.BusinessCode), "WORK_TYPE"); //#002

                ////기본 색상 처리
                //grd03.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd03.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd03.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd03.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd03.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd04 -- 공정용PC마스터

                this.grd04.AllowEditing = true;
                this.grd04.Initialize();
                this.grd04.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd04.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd04.SelectionMode = SelectionModeEnum.Cell;

                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "법인코드", "CORCD", "CORCD");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "사업장코드", "BIZCD", "BIZCD");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "라인코드", "LINECD", "LINECD");

                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "컴퓨터 명", "PC_NM", "PC_NM");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "컴퓨터 설명", "PC_DESC", "PC_DESC");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "아이피", "PC_IP", "IP");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "모드", "PROGRAM_MODE", "MODE");

                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "프로그램 ID", "PROGRAM_ID", "PROGRAM_ID");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "화면ID_폼명", "SCREEN_ID", "SCREEN_ID");

                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "CLIENT ID", "CLIENT_ID", "CLIENT_ID");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "최근 접근 시간", "ACCESS_DATE", "ACCESS_DATE");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "분석자", "USER_ID", "USER_ID");

                DataTable dtMode=new DataTable();
                dtMode.Columns.Add("CODE");
                dtMode.Columns.Add("NAME");
                DataRow dr = dtMode.NewRow();
                dr[0] = "COST";
                dr[1] = "COST";
                dtMode.Rows.Add(dr);
                dr = dtMode.NewRow();
                dr[0] = "PRODUCT";
                dr[1] = "PRODUCT";
                dtMode.Rows.Add(dr);

                _DT_SCREEN = this.LoadScreenCombo();
                DataTable dtProgram = this.LoadProgramCombo();

                this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtMode, "PROGRAM_MODE");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, _DT_SCREEN, "SCREEN_ID");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtProgram, "PROGRAM_ID");

                //기본 색상 처리
                //grd04.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd04.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd04.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd04.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd04.Styles["Normal"].Border.Color = _GridLine_Color;

                grp01_CORCD.Text = GetLabel("CORCD");
                grp01_BIZCD.Text = GetLabel("BIZCD");
                grp01_LINECD.Text = GetLabel("LINECD");
                grp01_PD80020_GRP_1.Text = GetLabel("PD80020_GRP_1");

                #endregion

                this.LoadCORCD();
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
                this.txt01_PC_IP.Initialize();
                this.txt01_PC_NM.Initialize();

                this.Init_Data(0);
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
                this.Init_Data(4);

                this.LoadPC(CURRENT_CORCD, CURRENT_BIZCD, CURRENT_LINECD, txt01_PC_NM.GetValue().ToString(), txt01_PC_IP.GetValue().ToString());

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SavePC();
                
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                this.RemovePC();       
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

        private void grd01_RowColChange(object sender, EventArgs e)
        {
            
        }

        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {

                Init_Data(1);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                string CORCD = this.grd01.GetValue(row, "CORCD").ToString();

                this.CURRENT_CORCD = CORCD;
                this.LoadBIZCD(CORCD);



            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_RowColChange(object sender, EventArgs e)
        {
            
        }
        
        private void grd02_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                Init_Data(2);

                int row = this.grd02.SelectedRowIndex;
                if (row < this.grd02.Rows.Fixed)
                    return;



                string CORCD = this.grd02.GetValue(row, "CORCD").ToString();
                string BIZCD = this.grd02.GetValue(row, "BIZCD").ToString();

                this.CURRENT_BIZCD = BIZCD;

                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.LoadWorkTypeCombo(CORCD, BIZCD), "WORK_TYPE");
                this.LoadLINECD(CORCD, BIZCD);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
        }
        
        private void grd03_RowColChange(object sender, EventArgs e)
        {
            
        }
        
        private void grd03_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                Init_Data(3);

                int row = this.grd03.SelectedRowIndex;
                if (row < this.grd03.Rows.Fixed)
                    return;

                string CORCD = this.grd03.GetValue(row, "CORCD").ToString();
                string BIZCD = this.grd03.GetValue(row, "BIZCD").ToString();
                string LINECD = this.grd03.GetValue(row, "LINECD").ToString();
                string PC_NM = this.txt01_PC_NM.GetValue().ToString();
                string PC_IP = this.txt01_PC_IP.GetValue().ToString();

                this.CURRENT_LINECD = LINECD;
                this.LoadPC(CORCD, BIZCD, LINECD, PC_NM, PC_IP);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd03_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
           
        }

        private void grd04_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                //신규행인경우에만 IP와 프로그램모드 입력 가능
                if (this.grd04.Cols[e.Col].Name == "PC_IP" || this.grd04.Cols[e.Col].Name == "PROGRAM_MODE")
                {
                    if (this.grd04.GetValue(e.Row, 0).ToString() != "N")
                    {
                        e.Cancel = true;
                    }
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        private void grd04_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            grd04.SetValue(args.RowIndex, "CORCD", CURRENT_CORCD);
            grd04.SetValue(args.RowIndex, "BIZCD", CURRENT_BIZCD);
            grd04.SetValue(args.RowIndex, "LINECD", CURRENT_LINECD);
        }

        private void grd04_RowColChange(object sender, EventArgs e)
        {
            try
            {
                


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        private void grd04_SetupEditor(object sender, RowColEventArgs e)
        {
            //콤보 상자 초기화 될때 불필요한 항목은 제거
            try
            {
                if (e.Row < 1 || e.Col < 1)
                    return;

                //SCREEN_ID 컬럼인 경우
                if (e.Col == this.grd04.Cols["SCREEN_ID"].Index)
                {

                    string PROGRAM_ID = this.grd04.GetValue(e.Row, "PROGRAM_ID").ToString();


                    ComboBox cbo = grd04.Editor as ComboBox;
                    if (cbo.Items.Count - 1 == _DT_SCREEN.Rows.Count)
                    {

                        for (int i = _DT_SCREEN.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = _DT_SCREEN.Rows[i];
                            if (dr["PROGRAM_ID"].ToString() != PROGRAM_ID)
                            {
                                cbo.Items.RemoveAt(i + 1);
                            }
                        }
                    }
                    
                }
            }
            catch
               (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }
        
        #endregion

        #region [사용자 정의 메서드]

        private DataTable LoadWorkTypeCombo(string corcd, string bizcd)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_WORK_TYPE(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_WORK_TYPE"), set, "OUT_CURSOR");

                this.AfterInvokeServer();
                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }
        
        private DataTable LoadProgramCombo()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_PROGRAM(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PROGRAM_COMBO"), set, "OUT_CURSOR");

                
                this.AfterInvokeServer();
                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }

        private DataTable LoadScreenCombo()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_SCREEN(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCREEN_COMBO"), set, "OUT_CURSOR");                

                this.AfterInvokeServer();
                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }

        private void Init_Data(int step)
        {
            try
            {
                if (step < 1)
                {
                    this.grd01.InitializeDataSource();
                    CURRENT_CORCD = "";
                }

                if (step < 2)
                {
                    this.grd02.InitializeDataSource();
                    CURRENT_BIZCD = "";

                    
                }

                if (step < 3)
                {
                    this.grd03.InitializeDataSource();
                    CURRENT_LINECD = "";

                   
                }

                if (step < 4)
                {
                    this.grd04.InitializeDataSource();
                    
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadCORCD()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", StaticUserInfoContext.Language);//set.Add("LANG_SET", "KO");

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_CORCD(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CORCD"), set, "OUT_CURSOR");

                this.AfterInvokeServer();
                this.grd01.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadBIZCD(string CORCD)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("LANG_SET", StaticUserInfoContext.Language);//set.Add("LANG_SET", "KO");
                set.Add("CORCD", CORCD);

                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_BIZCD(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_BIZCD"), set, "OUT_CURSOR").Tables[0];
                this.AfterInvokeServer();
                this.grd02.SetValue(source);                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadLINECD(string CORCD, string BIZCD)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("LANG_SET", StaticUserInfoContext.Language);//set.Add("LANG_SET", "KO");
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_LINECD(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LINECD"), set, "OUT_CURSOR").Tables[0];
                this.AfterInvokeServer();
                this.grd03.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadPC(string CORCD, string BIZCD, string LINECD, string PC_NM, string PC_IP)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                //set.Add("CORCD", this.UserInfo.CorporationCode);

                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("LINECD", LINECD);
                set.Add("PC_NM", PC_NM);
                set.Add("PC_IP", PC_IP);
                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_PC(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PC"), set, "OUT_CURSOR").Tables[0];
                this.AfterInvokeServer();
                this.grd04.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 공정용 PC 마스터 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                for (int i = 1; i < this.grd04.Rows.Count; i++)
                {

                    string CORCD = this.grd04.GetValue(i, "CORCD").ToString();
                    string BIZCD = this.grd04.GetValue(i, "BIZCD").ToString();
                    string LINECD = this.grd04.GetValue(i, "LINECD").ToString();
                    string PC_IP = this.grd04.GetValue(i, "PC_IP").ToString();
                    string PROGRAM_MODE = this.grd04.GetValue(i, "PROGRAM_MODE").ToString();
                    string PC_NM = this.grd04.GetValue(i, "PC_NM").ToString();

                    string PC_DESC = this.grd04.GetValue(i, "PC_DESC").ToString();
                    string PROGRAM_ID = this.grd04.GetValue(i, "PROGRAM_ID").ToString();
                    string SCREEN_ID = this.grd04.GetValue(i, "SCREEN_ID").ToString();
                    string CLIENT_ID = this.grd04.GetValue(i, "CLIENT_ID").ToString();


                   
                    if (this.GetByteCount(CORCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 법인코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008", i, GetLabel("CORCD"));
                        return false;
                    }
                    if (this.GetByteCount(BIZCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 사업장코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008", i, GetLabel("BIZCD"));
                        return false;
                    }
                    if (this.GetByteCount(LINECD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 라인코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008", i, GetLabel("LINECD"));
                        return false;
                    }


                    if (this.GetByteCount(PC_NM) == 0 )
                    {
                        //MsgBox.Show(i + " 번째 행에 컴퓨터 명이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008", i, GetLabel("PC_NM"));
                        return false;
                    }


                    if (this.GetByteCount(PC_NM) > 50)
                    {
                        //MsgBox.Show(i + " 번째 행에 컴퓨터 명은 50Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("PC_NM"), "50");
                        return false;
                    }

                    if (this.GetByteCount(PC_DESC) > 200)
                    {
                        //MsgBox.Show(i + " 번째 행에 컴퓨터 설명은 200Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("PC_DESC"), "200");
                        return false;
                    }
                    if (this.GetByteCount(PC_IP) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 IP가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, "IP");
                        return false;
                    }

                    if (this.GetByteCount(PROGRAM_MODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램 모드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("MODE"));
                        return false;
                    }

                    if (this.GetByteCount(PROGRAM_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램 아이디가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("PROGRAM_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SCREEN_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 화면ID_폼명이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("SCREEN_ID"));
                        return false;
                    }

                    if (this.GetByteCount(CLIENT_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 클라이언트 ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("CLIENT_ID"));
                        return false;
                    }

                    if (this.GetByteCount(CLIENT_ID) > 2)
                    {
                        //MsgBox.Show(i + " 번째 행에 클라이언트 ID는 2Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("CLIENT_ID"), "2");
                        return false;
                    }

                }

                //if (MsgBox.Show("입력하신 공정용 PC 마스터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0016", MessageBoxButtons.OKCancel, this.GetLabel("PD80020_GRP_1")) != DialogResult.OK)
                    return false;

                return true;
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //[#001]- INI KEY 마스터 MESCODE 전송
        private string DN_MESCODE(string bizcd)
        {
            string msg = "";
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("BIZCD", bizcd);
                //msg = _WSCOM.INQUERY_DN_MESCODE(param).Tables[0].Rows[0][0].ToString();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return msg;
        }

        private void SavePC()
        {
            try
            {


                DataSet source = this.grd04.GetValue(AxFlexGrid.FActionType.Save,
                   "CORCD", "BIZCD", "LINECD", "PC_NM", "PC_IP", "PC_DESC", "PROGRAM_ID", "SCREEN_ID", "CLIENT_ID", "USER_ID", "PROGRAM_MODE");

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["USER_ID"] = this.UserInfo.EmpNo;

                    //screen_id 에 program_id + ':' + screen_id 형태로 들어가 있음. 저장시에는 screen_id만 추출
                    string screen_id=dr["SCREEN_ID"].ToString();
                    dr["SCREEN_ID"] = screen_id == "" ? "" : screen_id.Substring(screen_id.IndexOf(":") + 1);
                }

                if (!IsSaveValid(source)) return;



                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_PC(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_PC"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("입력하신 공정용 PC 마스터 정보를 저장하였습니다.");
                MsgCodeBox.Show("CD00-0071");

                ////[#001]- INI KEY 마스터 MESCODE 전송
                //string msg = DN_MESCODE(CURRENT_BIZCD);
                //if (!msg.StartsWith("OK"))
                //{
                //    string biz = CURRENT_BIZCD == "5210" ? "울산" : "아산";
                //    MsgBox.Show(biz + "사업장 MESCODE 다운로드에 실패하였습니다.");
                //}               


                this.LoadPC(CURRENT_CORCD, CURRENT_BIZCD, CURRENT_LINECD, txt01_PC_NM.GetValue().ToString(), txt01_PC_IP.GetValue().ToString());
                

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

        private bool IsRemoveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 공정용 PC 마스터 정보를 선택하세요.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            
            //if (MsgBox.Show("선택하신 공정용 PC 마스터 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;

        }

      

        private void RemovePC()
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                DataSet source = this.grd04.GetValue(AxFlexGrid.FActionType.Remove, "PC_IP", "PROGRAM_MODE","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {                    
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_PC(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_PC"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("선택하신 공정용 PC 마스터 정보를 삭제하였습니다.");
                MsgCodeBox.Show("CD00-0072");

                //[#001]- INI KEY 마스터 MESCODE 전송
                //string msg = DN_MESCODE(CURRENT_BIZCD);
                //if (!msg.StartsWith("OK"))
                //{
                //    string biz = CURRENT_BIZCD == "5210" ? "울산" : "아산";
                //    MsgBox.Show(biz + "사업장 MESCODE 다운로드에 실패하였습니다.");
                //}   

                this.LoadPC(CURRENT_CORCD, CURRENT_BIZCD, CURRENT_LINECD, txt01_PC_NM.GetValue().ToString(), txt01_PC_IP.GetValue().ToString());
                

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

        #region [라인별 근무형태 정보(MES0170) 저장 로직 ]
        
        //#002
        private bool IsWorkTypeSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 라인별 근무형태 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }


                //if (MsgBox.Show("입력하신 라인별 근무형태 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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


        //#002 - 라인별 근무형태 저장 
        private void btn01_SAVE_Click(object sender, EventArgs e)
        {
            try
            {


                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Save,
                   "CORCD", "BIZCD", "LINECD", "WORK_TYPE");

                if (!IsWorkTypeSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_LINE_WORKTYPE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_LINE_WORKTYPE"), source);

                //IF 울산만 적용해야함. 아산의 MW에는 MES0170테이블이 없음
                //bool isSyncOK = true;
                //if (this.UserInfo.BusinessCode.Equals("5210"))
                //{
                //    //2014.02.13 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //    isSyncOK = this.DN_MESCODE_MES0170(this.UserInfo.BusinessCode);
                //    //2014.02.13 MES CODE 미들서버에 전송 로직 추가 >>> 끝
                //}

                this.AfterInvokeServer();

                MsgCodeBox.Show("CD00-0071");
                //if (isSyncOK)  MsgBox.Show("입력하신 라인별 근무형태 정보를 저장하였습니다.");


                Init_Data(2);
                this.LoadLINECD(CURRENT_CORCD, CURRENT_BIZCD);


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

       
        //#002- MES0170 라인별 근무형태 전송
        //private bool DN_MESCODE_MES0170(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES0170", bizcd).Tables[0].Rows[0][0].ToString();

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
