 #region ▶ Description & History
/* 
 * 프로그램명 : INI DB관리
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
    /// 제품별 작업내역 추적 상세현황
    /// </summary>
    public partial class PD80010 : AxCommonBaseControl
    {
        private const int _MAX_SCREW_POINT = 47;
        private Color _OddRow_BackColor = Color.FromArgb(228, 248, 252);
        private Color _OddRow_ForeColor = Color.Black;
        private Color _EvenRow_BackColor = Color.White;
        private Color _EvenRow_ForeColor = Color.Black;
        private Color _GridLine_Color = Color.Gray;
        //private IPD80010 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD80010";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;

        private string CURRENT_PROGRAM_ID = "";
        private string CURRENT_SCREEN_ID = "";
        private string CURRENT_SECTION_ID = "";

        #region [ 초기화 작업 정의 ]

        public PD80010()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD80010>("PD", "PD80010.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region grd01 - 프로그램마스터

                this.grd01.AllowEditing =  true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "프로그램 ID", "PROGRAM_ID","PROGRAM_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 190, "설명", "PROGRAM_DESC", "PGM_DESC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "분석자", "USER_ID", "USER_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "ETC", "REMARK");
                
                ////기본 색상 처리
                //grd01.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd01.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd01.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd01.Styles.Normal.ForeColor = _EvenRow_ForeColor;
              
                #endregion

                #region grd02 - 공정화면 마스터

                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd02.SelectionMode = SelectionModeEnum.Cell;

                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "프로그램 ID", "PROGRAM_ID","PROGRAM_ID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "화면ID_폼명", "SCREEN_ID","SCREEN_ID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 240, "설명", "SCREEN_DESC","SCREEN_DESC");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "분석자", "USER_ID", "USER_ID");
                
                ////기본 색상 처리
                //grd02.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd02.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd02.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd02.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd02.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd03 - INI섹션 마스터

                this.grd03.AllowEditing = true;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.SelectionMode = SelectionModeEnum.Cell;

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "프로그램 ID", "PROGRAM_ID","PROGRAM_ID");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "화면ID_폼명", "SCREEN_ID","SCREEN_ID");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "섹션ID", "SECTION_ID","SECTION_ID");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "섹션설명", "SECTION_DESC","SECTION_DESC");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "분석자", "USER_ID", "USER_ID");
                ////기본 색상 처리
                //grd03.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd03.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd03.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd03.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd03.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd04 --INI 키 마스터

                this.grd04.AllowEditing = true;
                this.grd04.Initialize();
                this.grd04.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd04.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd04.SelectionMode = SelectionModeEnum.Cell;

                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "프로그램 ID", "PROGRAM_ID","PROGRAM_ID");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "화면ID_폼명", "SCREEN_ID","SCREEN_ID");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "섹션ID", "SECTION_ID","SECTION_ID");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "키", "INI_KEY","INI_KEY");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "기본값", "INI_DEFAULT","INI_DEFAULT");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "키설명", "INI_KEY_DESC","INI_KEY_DESC");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "분석자", "USER_ID", "USER_ID");

                //기본 색상 처리
                //grd04.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd04.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd04.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd04.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd04.Styles["Normal"].Border.Color = _GridLine_Color;

                grp01_PD80010_GRP_1.Text = GetLabel("PD80010_GRP_1");
                grp01_PD80010_GRP_2.Text = GetLabel("PD80010_GRP_2");
                grp01_PD80010_GRP_3.Text = GetLabel("PD80010_GRP_3");
                grp01_PD80010_GRP_4.Text = GetLabel("PD80010_GRP_4");

                #endregion
                #region grd05 --INI IP

                this.grd05.AllowEditing = true;
                this.grd05.Initialize();
                this.grd05.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd05.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd05.SelectionMode = SelectionModeEnum.Cell;
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "CORCD", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "BIZCD", "BIZCD", "BIZCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "PID", "PROGRAM_ID", "PROGRAM_ID");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "CLASS", "SCREEN_ID", "SCREEN_ID");
                this.grd05.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 210, "IP", "IP", "IP");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "분석자", "USER_ID", "USER_ID");


                #endregion

                BtnQuery_Click(null, null);
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
                this.Init_Data(0);  //전체 초기화


                this.LoadProgram();

                
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
        
        #region [프로그램마스터 저장,삭제]

        private void btn01_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveProgram();
                
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
        
        private void btn01_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoveProgram();              
               
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

        #region [공정화면 마스터 저장,삭제]
        
        private void btn02_SAVE_Click(object sender, EventArgs e)
        {
            try
            {               
                this.SaveScreen();
                
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
        
        private void btn02_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoveScreen();
                           
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

        #region [ini섹션 마스터 저장,삭제]
        
        private void btn03_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveSection();
                
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
        
        private void btn03_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {              
                this.RemoveSection();
                
              
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
        
        #region [ ini키 마스터 저장,삭제]

        private void btn04_SAVE_Click(object sender, EventArgs e)
        {
            try
            {                 
                this.SaveINIKey();
               
              
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
        
        private void btn04_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoveINIKey();
                
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

        #endregion

        #region [컨트롤 이벤트]

        #region grd01-프로그램마스터

        private void grd01_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                //신규행인경우에만 프로그램 id 입력 가능
                if (this.grd01.Cols[e.Col].Name == "PROGRAM_ID")
                {
                    if (this.grd01.GetValue(e.Row, 0).ToString() != "N")
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

                string PROGRAM_ID = this.grd01.GetValue(row, "PROGRAM_ID").ToString();

                this.CURRENT_PROGRAM_ID = PROGRAM_ID;
                this.LoadScreen(PROGRAM_ID);

                if (!PROGRAM_ID.Equals(string.Empty))
                {
                    this.grd02.CurrentContextMenu.Items[0].Visible = true;
                    this.grd02.CurrentContextMenu.Items[1].Visible = true;
                    this.grd02.CurrentContextMenu.Items[2].Visible = true;

                    this.grd03.CurrentContextMenu.Items[0].Visible = true;
                    this.grd03.CurrentContextMenu.Items[1].Visible = true;
                    this.grd03.CurrentContextMenu.Items[2].Visible = true;

                    this.grd04.CurrentContextMenu.Items[0].Visible = true;
                    this.grd04.CurrentContextMenu.Items[1].Visible = true;
                    this.grd04.CurrentContextMenu.Items[2].Visible = true;
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            Init_Data(1);
        }
        
        #endregion

        #region grd02-공정화면마스터

        private void grd02_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                //신규행인경우에만 화면 id 입력 가능
                if (this.grd02.Cols[e.Col].Name == "SCREEN_ID")
                {
                    if (this.grd02.GetValue(e.Row, 0).ToString() != "N")
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



                string PROGRAM_ID = this.grd02.GetValue(row, "PROGRAM_ID").ToString();
                string SCREEN_ID = this.grd02.GetValue(row, "SCREEN_ID").ToString();

                this.CURRENT_SCREEN_ID = SCREEN_ID;
                this.LoadSection(PROGRAM_ID, SCREEN_ID);
                if (!SCREEN_ID.Equals(string.Empty))
                {
                    this.grd03.CurrentContextMenu.Items[0].Visible = true;
                    this.grd03.CurrentContextMenu.Items[1].Visible = true;
                    this.grd03.CurrentContextMenu.Items[2].Visible = true;

                    this.grd04.CurrentContextMenu.Items[0].Visible = true;
                    this.grd04.CurrentContextMenu.Items[1].Visible = true;
                    this.grd04.CurrentContextMenu.Items[2].Visible = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            grd02.SetValue(args.RowIndex, "PROGRAM_ID", CURRENT_PROGRAM_ID);            
            Init_Data(2);
            
        }

        #endregion

        #region grd03-ini섹션마스터

        private void grd03_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                //신규행인경우에만 섹션 id 입력 가능
                if (this.grd03.Cols[e.Col].Name == "SECTION_ID")
                {
                    if (this.grd03.GetValue(e.Row, 0).ToString() != "N")
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

                string PROGRAM_ID = this.grd03.GetValue(row, "PROGRAM_ID").ToString();
                string SCREEN_ID = this.grd03.GetValue(row, "SCREEN_ID").ToString();
                string SECTION_ID = this.grd03.GetValue(row, "SECTION_ID").ToString();

                this.CURRENT_SECTION_ID = SECTION_ID;
                this.LoadINIKey(PROGRAM_ID, SCREEN_ID, SECTION_ID);

                if (!SECTION_ID.Equals(string.Empty))
                {
                    this.grd04.CurrentContextMenu.Items[0].Visible = true;
                    this.grd04.CurrentContextMenu.Items[1].Visible = true;
                    this.grd04.CurrentContextMenu.Items[2].Visible = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd03_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            grd03.SetValue(args.RowIndex, "PROGRAM_ID", CURRENT_PROGRAM_ID);
            grd03.SetValue(args.RowIndex, "SCREEN_ID", CURRENT_SCREEN_ID);
            Init_Data(3);
        }

        #endregion

        #region grd04-ini 키 마스터
        
        private void grd04_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                //신규행인경우에만 키 입력 가능
                if (this.grd04.Cols[e.Col].Name == "INI_KEY")
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
            grd04.SetValue(args.RowIndex, "PROGRAM_ID", CURRENT_PROGRAM_ID);
            grd04.SetValue(args.RowIndex, "SCREEN_ID", CURRENT_SCREEN_ID);
            grd04.SetValue(args.RowIndex, "SECTION_ID", CURRENT_SECTION_ID);           
        }

        #endregion

        #endregion

        #region [사용자 정의 메서드]

        private void Init_Data(int step)
        {
            try
            {
                if (step < 1)
                {
                    this.grd01.InitializeDataSource();
                    CURRENT_PROGRAM_ID = "";
                }

                if (step < 2)
                {
                    this.grd02.InitializeDataSource();
                    CURRENT_SCREEN_ID = "";

                    if (this.grd02.CurrentContextMenu != null)
                    {
                        this.grd02.CurrentContextMenu.Items[0].Visible = false;
                        this.grd02.CurrentContextMenu.Items[1].Visible = false;
                        this.grd02.CurrentContextMenu.Items[2].Visible = false;
                    }
                }

                if (step < 3)
                {
                    this.grd03.InitializeDataSource();
                    CURRENT_SECTION_ID = "";

                    if (this.grd03.CurrentContextMenu != null)
                    {
                        this.grd03.CurrentContextMenu.Items[0].Visible = false;
                        this.grd03.CurrentContextMenu.Items[1].Visible = false;
                        this.grd03.CurrentContextMenu.Items[2].Visible = false;
                    }
                }

                if (step < 4)
                {
                    this.grd04.InitializeDataSource();

                    if (this.grd04.CurrentContextMenu != null)
                    {
                        this.grd04.CurrentContextMenu.Items[0].Visible = false;
                        this.grd04.CurrentContextMenu.Items[1].Visible = false;
                        this.grd04.CurrentContextMenu.Items[2].Visible = false;
                    }
                }
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region --프로그램 마스터 관련--

        private void LoadProgram()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_PROGRAM(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PROGRAM"), set, "OUT_CURSOR");

                this.AfterInvokeServer();
                this.grd01.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private bool IsSaveProgramValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 프로그램 마스터 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {

                    string PROGRAM_ID = this.grd01.GetValue(i, "PROGRAM_ID").ToString();
                    string PROGRAM_DESC = this.grd01.GetValue(i, "PROGRAM_DESC").ToString();
                    string ETC = this.grd01.GetValue(i, "ETC").ToString();

                    if (this.GetByteCount(PROGRAM_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램 아이디가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("PROGRAM_ID"));                        
                        return false;
                    }

                    if (this.GetByteCount(PROGRAM_DESC) > 200)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램 설명은 200Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("PROGRAM_DESC"));                        
                        return false;
                    }
                    if (this.GetByteCount(ETC) > 200)
                    {
                        //MsgBox.Show(i + " 번째 행에 비고는 200Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("REMARK"));                        
                        return false;
                    }
                }
                
                //if (MsgBox.Show("입력하신 프로그램 마스터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0016", MessageBoxButtons.OKCancel,this.GetLabel("PD80010_GRP_4")) != DialogResult.OK)
                    return false;

                return true;
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //[#001]- 프로그램 마스터 MESCODE 전송
        private string DN_MESCODE_PROGRAM(string bizcd)
        {
            string msg = "";
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("BIZCD", bizcd);
                //msg = _WSCOM.INQUERY_DN_MESCODE_PROGRAM(param).Tables[0].Rows[0][0].ToString();

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return msg;
        }

        private void SaveProgram()
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                   "PROGRAM_ID", "PROGRAM_DESC", "USER_ID","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["USER_ID"] = this.UserInfo.EmpNo;
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsSaveProgramValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_PROGRAM(source);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_PROGRAM"), source);


                this.AfterInvokeServer();
                MsgCodeBox.Show("CD00-0041");

                //MsgBox.Show("입력하신 프로그램 마스터 정보를 저장하였습니다.");

                //[#001]- 프로그램 마스터 MESCODE 전송
                //string msg = DN_MESCODE_PROGRAM("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_PROGRAM("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}

                this.BtnQuery_Click(null, null);
                

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

        private bool IsRemoveProgramValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 프로그램 마스터 정보를 선택하세요.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            for (int i = grd01.Rows.Fixed; i < grd01.Rows.Count; i++)
            {
                if (grd01.GetValue(i, 0).ToString() == "D")
                {
                    string PROGRAM_ID = grd01.GetValue(i, "PROGRAM_ID").ToString();

                    if (this.GetProgramSub(PROGRAM_ID) > 0)
                    {
                        //MsgBox.Show(i + " 번째 행의 프로그램 아이디에 대한 하위의 데이터가 존재하여 삭제할 수 없습니다.");
                        MsgCodeBox.ShowFormat("PD00-0017", i, GetLabel("PROGRAM_ID"));
                        return false;
                    }
                }
            }

            //if (MsgBox.Show("선택하신 프로그램 마스터 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if(MsgCodeBox.Show("CD00-0077",MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        
        }
        
        private int GetProgramSub(string PROGRAM_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                //DataTable dtSub = _WSCOM.INQUERY_PROGRAM_SUB(set).Tables[0];

                DataTable dtSub = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PROGRAM_SUB"), set, "OUT_CURSOR").Tables[0];


                int subCnt = Convert.ToInt32(dtSub.Rows[0][0]);
                return subCnt;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }

        private void RemoveProgram()
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "PROGRAM_ID", "CORCD", "BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {                    
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveProgramValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_PROGRAM(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_PROGRAM"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("선택하신 프로그램 마스터 정보를 삭제하였습니다.");
                MsgCodeBox.Show("CD00-0072");

                //[#001]- 프로그램 마스터 MESCODE 전송
                //string msg = DN_MESCODE_PROGRAM("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_PROGRAM("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}

                this.BtnQuery_Click(null, null);
                
                
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


        #region --공정화면 마스터 관련--

        private void LoadScreen(string PROGRAM_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PROGRAM_ID", PROGRAM_ID);
                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_SCREEN(set).Tables[0];

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCREEN"), set, "OUT_CURSOR").Tables[0];

                this.AfterInvokeServer();
                this.grd02.SetValue(source);              
  
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private bool IsSaveScreenValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                //    MsgBox.Show("저장할 공정화면 마스터 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd02.Rows.Count; i++)
                {

                    string PROGRAM_ID = this.grd02.GetValue(i, "PROGRAM_ID").ToString();
                    string SCREEN_ID = this.grd02.GetValue(i, "SCREEN_ID").ToString();
                    string SCREEN_DESC = this.grd02.GetValue(i, "SCREEN_DESC").ToString();

                    if (this.GetByteCount(PROGRAM_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008", i, GetLabel("PROGRAM_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SCREEN_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 화면ID_품명이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0008", i, GetLabel("SCREEN_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SCREEN_DESC) > 200)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램 설명은 200Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("PROGRAM_DESC"), "200");
                        return false;
                    }
                }
                //if (MsgBox.Show("입력하신 공정화면 마스터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0016", MessageBoxButtons.OKCancel, this.GetLabel("PD80010_GRP_3")) != DialogResult.OK)
                    return false;

                return true;
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //[#001]- 공정화면 마스터 MESCODE 전송
        private string DN_MESCODE_SCREEN(string bizcd)
        {
            string msg = "";
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("BIZCD", bizcd);
                //msg = _WSCOM.INQUERY_DN_MESCODE_SCREEN(param).Tables[0].Rows[0][0].ToString();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return msg;
        }

        private void SaveScreen()
        {
            try
            {


                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Save,
                   "PROGRAM_ID", "SCREEN_ID", "SCREEN_DESC", "USER_ID","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {                   
                    dr["USER_ID"] = this.UserInfo.EmpNo;
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsSaveScreenValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_SCREEN(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_SCREEN"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("입력하신 공정화면 마스터 정보를 저장하였습니다.");
                MsgCodeBox.Show("CD00-0071");

                ////[#001]- 공정화면 마스터 MESCODE 전송
                //string msg = DN_MESCODE_SCREEN("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_SCREEN("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                
                this.LoadScreen(CURRENT_PROGRAM_ID);
                
                

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

        private bool IsRemoveScreenValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 공정화면 마스터 정보를 선택하세요.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            for (int i = grd02.Rows.Fixed; i < grd02.Rows.Count; i++)
            {
                if (grd02.GetValue(i, 0).ToString() == "D")
                {
                    string PROGRAM_ID = grd02.GetValue(i, "PROGRAM_ID").ToString();
                    string SCREEN_ID = grd02.GetValue(i, "SCREEN_ID").ToString();

                    if (this.GetScreenSub(PROGRAM_ID, SCREEN_ID) > 0)
                    {
                        //MsgBox.Show(i + " 번째 행의 공정화면 마스터에 대한 하위의 데이터가 존재하여 삭제할 수 없습니다.");
                        MsgCodeBox.ShowFormat("PD00-0017", i, "PD80010_GRP_3");
                        return false;
                    }
                }
            }

            //if (MsgBox.Show("선택하신 공정화면 마스터 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)            
            if(MsgCodeBox.Show("CD00-0077",MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;

        }

        private int GetScreenSub(string PROGRAM_ID, string SCREEN_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("SCREEN_ID", SCREEN_ID);
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                //DataTable dtSub = _WSCOM.INQUERY_SCREEN_SUB(set).Tables[0];
                DataTable dtSub = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SCREEN_SUB"), set, "OUT_CURSOR").Tables[0];

                int subCnt = Convert.ToInt32(dtSub.Rows[0][0]);
                return subCnt;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private void RemoveScreen()
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Remove, "PROGRAM_ID", "SCREEN_ID","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {                    
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveScreenValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_SCREEN(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_SCREEN"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("선택하신 공정화면 마스터 정보를 삭제하였습니다.");
                MsgCodeBox.Show("CD00-0072");

                ////[#001]- 공정화면 마스터 MESCODE 전송
                //string msg = DN_MESCODE_SCREEN("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_SCREEN("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}



                this.LoadScreen(CURRENT_PROGRAM_ID);     
                
                
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

        #region --ini섹션 마스터 관련--
        
        private void LoadSection(string PROGRAM_ID, string SCREEN_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("SCREEN_ID", SCREEN_ID);
                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_SECTION( set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SECTION"), set, "OUT_CURSOR").Tables[0];

                this.AfterInvokeServer();
                this.grd03.SetValue(source);

                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_IP"), set, "OUT_CURSOR").Tables[0];
                this.grd05.SetValue(source2);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }


        private bool IsSaveSectionValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 INI 섹션 마스터 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                for (int i = 1; i < this.grd03.Rows.Count; i++)
                {

                    string PROGRAM_ID = this.grd03.GetValue(i, "PROGRAM_ID").ToString();
                    string SCREEN_ID = this.grd03.GetValue(i, "SCREEN_ID").ToString();
                    string SECTION_ID = this.grd03.GetValue(i, "SECTION_ID").ToString();
                    string SECTION_DESC = this.grd03.GetValue(i, "SECTION_DESC").ToString();


                    if (this.GetByteCount(PROGRAM_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("PROGRAM_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SCREEN_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 화면ID_품명이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("SCREEN_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SECTION_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 섹션ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i, GetLabel("SECTION_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SECTION_DESC) > 200)
                    {
                        //MsgBox.Show(i + " 번째 행에 섹션 설명은 200Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i, GetLabel("SECTION_DESC"));
                        return false;
                    }

                }
                //if (MsgBox.Show("입력하신 INI 섹션 마스터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0016", MessageBoxButtons.OKCancel, this.GetLabel("PD80010_GRP_2")) != DialogResult.OK)
                    return false;

                return true;
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //[#001]- 섹션 마스터 MESCODE 전송
        private string DN_MESCODE_SECTION(string bizcd)
        {
            string msg = "";
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("BIZCD", bizcd);
                //msg = _WSCOM.INQUERY_DN_MESCODE_SECTION(param).Tables[0].Rows[0][0].ToString();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return msg;
        }


        private void SaveSection()
        {
            try
            {


                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Save,
                   "PROGRAM_ID", "SCREEN_ID", "SECTION_ID", "SECTION_DESC", "USER_ID","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {

                    dr["USER_ID"] = this.UserInfo.EmpNo;
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsSaveSectionValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_SECTION(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_SECTION"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("입력하신 INI 섹션 마스터 정보를 저장하였습니다.");
                MsgCodeBox.Show("CD00-0071");

                ////[#001]- 섹션 마스터 MESCODE 전송
                //string msg = DN_MESCODE_SECTION("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_SECTION("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}

                this.LoadSection(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID);
                
                
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

        private bool IsRemoveSectionValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 INI 섹션 마스터 정보를 선택하세요.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            for (int i = grd03.Rows.Fixed; i < grd03.Rows.Count; i++)
            {
                if (grd03.GetValue(i, 0).ToString() == "D")
                {
                    string PROGRAM_ID = grd03.GetValue(i, "PROGRAM_ID").ToString();
                    string SCREEN_ID = grd03.GetValue(i, "SCREEN_ID").ToString();
                    string SECTION_ID = grd03.GetValue(i, "SECTION_ID").ToString();

                    if (this.GetSectionSub(PROGRAM_ID, SCREEN_ID, SECTION_ID) > 0)
                    {
                        //MsgBox.Show(i + " 번째 행의 INI 섹션 마스터에 대한 하위의 데이터가 존재하여 삭제할 수 없습니다.");
                        MsgCodeBox.ShowFormat("PD00-0017", i, "PD80010_GRP_2");
                        return false;
                    }
                }
            }

            //if (MsgBox.Show("선택하신 INI 섹션 마스터 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;

        }

        private int GetSectionSub(string PROGRAM_ID, string SCREEN_ID, string SECTION_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("SCREEN_ID", SCREEN_ID);
                set.Add("SECTION_ID", SECTION_ID);
                //DataTable dtSub = _WSCOM.INQUERY_SECTION_SUB(set).Tables[0];
                DataTable dtSub = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SECTION_SUB"), set, "OUT_CURSOR").Tables[0];

                int subCnt = Convert.ToInt32(dtSub.Rows[0][0]);
                return subCnt;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private void RemoveSection()
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Remove, "PROGRAM_ID", "SCREEN_ID", "SECTION_ID","CORCD","BIZCD");
                
                foreach (DataRow dr in source.Tables[0].Rows)
                {                
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveSectionValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_SECTION(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_SECTION"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("선택하신 INI 섹션 마스터 정보를 삭제하였습니다.");
                MsgCodeBox.Show("CD00-0071");

                ////[#001]- 섹션 마스터 MESCODE 전송
                //string msg = DN_MESCODE_SECTION("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_SECTION("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}


                this.LoadSection(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID);
                
                
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

        #region --ini 키 마스터 관련--
        
        private void LoadINIKey(string PROGRAM_ID, string SCREEN_ID, string SECTION_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("SCREEN_ID", SCREEN_ID);
                set.Add("SECTION_ID", SECTION_ID);
                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_INI_KEY(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_INI_KEY"), set, "OUT_CURSOR").Tables[0];

                this.AfterInvokeServer();
                this.grd04.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }


        private bool IsSaveINIKeyValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 INI 키 마스터 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                for (int i = 1; i < this.grd04.Rows.Count; i++)
                {

                    string PROGRAM_ID = this.grd04.GetValue(i, "PROGRAM_ID").ToString();
                    string SCREEN_ID = this.grd04.GetValue(i, "SCREEN_ID").ToString();
                    string SECTION_ID = this.grd04.GetValue(i, "SECTION_ID").ToString();
                    string INI_KEY = this.grd04.GetValue(i, "INI_KEY").ToString();
                    string INI_DEFAULT = this.grd04.GetValue(i, "INI_DEFAULT").ToString();
                    string INI_KEY_DESC = this.grd04.GetValue(i, "INI_KEY_DESC").ToString();


                    if (this.GetByteCount(PROGRAM_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 프로그램ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), GetLabel("PROGRAM_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SCREEN_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 화면ID_품명이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), GetLabel("SCREEN_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SECTION_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 섹션ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), GetLabel("SECTION_ID"));
                        return false;
                    }

                    if (this.GetByteCount(INI_KEY) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 키가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0009", i.ToString());
                        return false;
                    }


                    if (this.GetByteCount(INI_DEFAULT) > 128)
                    {
                        //MsgBox.Show(i + " 번째 행에 INI기본값은 128Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), "INI" + GetLabel("INI_DEFAULT"), "128");
                        return false;
                    }
                    if (this.GetByteCount(INI_KEY_DESC) > 200)
                    {
                        //MsgBox.Show(i + " 번째 행에 INI 설명은 200Bytes 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), "INI" + GetLabel("PROGRAM_DESC"), "200");
                        return false;
                    }

                }
                //if (MsgBox.Show("입력하신 INI 키 마스터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0016", MessageBoxButtons.OKCancel, this.GetLabel("PD80010_GRP_1")) != DialogResult.OK)
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
        private string DN_MESCODE_INI_KEY(string bizcd)
        {
            string msg = "";
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("BIZCD", bizcd);
                //msg = _WSCOM.INQUERY_DN_MESCODE_INI_KEY(param).Tables[0].Rows[0][0].ToString();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return msg;
        }


        private void SaveINIKey()
        {
            try
            {


                DataSet source = this.grd04.GetValue(AxFlexGrid.FActionType.Save,
                   "PROGRAM_ID", "SCREEN_ID", "SECTION_ID","INI_KEY","INI_DEFAULT", "INI_KEY_DESC", "USER_ID","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["USER_ID"] = this.UserInfo.EmpNo;
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!IsSaveINIKeyValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_INI_KEY(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_INI_KEY"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("입력하신 INI 키 마스터 정보를 저장하였습니다.");
                MsgCodeBox.Show("CD00-0071");

                ////[#001]- INI KEY 마스터 MESCODE 전송
                //string msg = DN_MESCODE_INI_KEY("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_INI_KEY("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}

                this.LoadINIKey(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID, CURRENT_SECTION_ID);

                
                
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

        private bool IsRemoveINIKeyValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 INI 키 마스터 정보를 선택하세요.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }


            //if (MsgBox.Show("선택하신 INI 키 마스터 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;

        }

        private void RemoveINIKey()
        {
            try
            {
                DataSet source = this.grd04.GetValue(AxFlexGrid.FActionType.Remove, "PROGRAM_ID", "SCREEN_ID", "SECTION_ID", "INI_KEY","CORCD","BIZCD");

                foreach (DataRow dr in source.Tables[0].Rows)
                {                    
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveINIKeyValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_INI_KEY(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_INI_KEY"), source);


                this.AfterInvokeServer();
                //MsgBox.Show("선택하신 INI 키 마스터 정보를 삭제하였습니다.");
                MsgCodeBox.Show("CD00-0072");

                ////[#001]- INI KEY 마스터 MESCODE 전송
                //string msg = DN_MESCODE_INI_KEY("5210"); //울산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("울산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}
                //msg = DN_MESCODE_INI_KEY("5220"); //아산사업장
                //if (!msg.StartsWith("OK"))
                //{
                //    MsgBox.Show("아산사업장 MESCODE 다운로드에 실패하였습니다.");
                //}

                this.LoadINIKey(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID, CURRENT_SECTION_ID);
                                              
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

        private void axButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd05.GetValue(AxFlexGrid.FActionType.Save,
                  "CORCD", "BIZCD", "PROGRAM_ID", "SCREEN_ID", "IP", "USER_ID" );

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["PROGRAM_ID"] = CURRENT_PROGRAM_ID;
                    dr["SCREEN_ID"] = CURRENT_SCREEN_ID;

                    dr["USER_ID"] = this.UserInfo.EmpNo;
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["BIZCD"] = this.UserInfo.BusinessCode;
                }

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_IP"), source);
                this.LoadSection(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        #endregion

        private void axButton2_Click(object sender, EventArgs e)
        {
            DataSet source = this.grd05.GetValue(AxFlexGrid.FActionType.Remove,
                  "CORCD", "BIZCD", "PROGRAM_ID", "SCREEN_ID", "IP", "USER_ID");
            foreach (DataRow dr in source.Tables[0].Rows)
            {
                dr["PROGRAM_ID"] = CURRENT_PROGRAM_ID;
                dr["SCREEN_ID"] = CURRENT_SCREEN_ID;

                dr["USER_ID"] = this.UserInfo.EmpNo;
                dr["CORCD"] = this.UserInfo.CorporationCode;
                dr["BIZCD"] = this.UserInfo.BusinessCode;
            }
            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEL_IP"), source);
            this.LoadSection(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID);
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgBox.Show("Do you want to deploy ip?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.BeforeInvokeServer(true);
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("PROGRAM_ID", CURRENT_PROGRAM_ID);
                    set.Add("SCREEN_ID", CURRENT_SCREEN_ID);


                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEPLOY_IP"), set);
                }
            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
                this.AfterInvokeServer();
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
       
    }
}

