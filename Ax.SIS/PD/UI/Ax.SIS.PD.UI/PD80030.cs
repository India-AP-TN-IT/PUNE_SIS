#region ▶ Description & History
/* 
 * 프로그램명 : 공정용 PC INI관리
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
using System.Net;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 공정용 PC INI관리
    /// </summary>
    public partial class PD80030 : AxCommonBaseControl
    {
        private const int _MAX_SCREW_POINT = 47;
        private Color _OddRow_BackColor = Color.FromArgb(228, 248, 252);
        private Color _OddRow_ForeColor = Color.Black;
        private Color _EvenRow_BackColor = Color.White;
        private Color _EvenRow_ForeColor = Color.Black;
        private Color _GridLine_Color = Color.Gray;
        //private IPD80030 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD80030";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;

        private string CURRENT_PC_IP = "";
        private string CURRENT_PROGRAM_ID = "";
        private string CURRENT_SCREEN_ID = "";
        private string CURRENT_SECTION_ID = "";
        private string CURRENT_BIZCD = "";

        #region [ 초기화 작업 정의 ]

        public PD80030()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD80030>("PD", "PD80030.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region grd01 - 공정용PC INI관리

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "컴퓨터 명", "PC_NM", "PC_NM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 090, "아이피", "PC_IP", "IP");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "컴퓨터 설명", "PC_DESC", "PC_DESC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "프로그램 ID", "PROGRAM_ID", "PROGRAM_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "화면ID_폼명", "SCREEN_ID", "SCREEN_ID");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");

                ////기본 색상 처리
                //grd01.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd01.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd01.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd01.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                #endregion

                #region grd02 - INI섹션마스터

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd02.SelectionMode = SelectionModeEnum.Cell;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "섹션ID", "SECTION_ID", "SECTION_ID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "섹션설명", "SECTION_DESC", "SECTION_DESC");
                
                ////기본 색상 처리
                //grd02.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd02.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd02.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd02.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd02.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion

                #region grd03 - INI키 마스터

                this.grd03.AllowEditing = true;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.SelectionMode = SelectionModeEnum.Cell;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "키", "INI_KEY", "INI_KEY");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "설정값", "INI_KEYVALUE", "INI_KEYVALUE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "키설명", "INI_KEY_DESC", "INI_KEY_DESC");

                this.grd03.CurrentContextMenu.Items[0].Visible = false; //행추가 메뉴 안보이게함.

                ////기본 색상 처리
                //grd03.Styles.Alternate.BackColor = _OddRow_BackColor;
                //grd03.Styles.Alternate.ForeColor = _OddRow_ForeColor;

                //grd03.Styles.Normal.BackColor = _EvenRow_BackColor;
                //grd03.Styles.Normal.ForeColor = _EvenRow_ForeColor;

                //grd03.Styles["Normal"].Border.Color = _GridLine_Color;

                #endregion


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
                Init_Data(0);
                this.txt01_PC_IP.Initialize();
                this.txt01_PC_NM.Initialize();
                this.txt01_LINECD.Initialize();
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
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Init_Data(1);

                this.LoadPC(txt01_PC_NM.GetValue().ToString(), txt01_PC_IP.GetValue().ToString(), txt01_LINECD.GetValue().ToString());
               
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
                this.SaveKEYVALUE();
                
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
                this.RemoveKEYVALUE();

                //MsgBox.Show("선택하신 PDA - SMS 호출 그룹 정보가 삭제되었습니다");
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
        
        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {

                Init_Data(1);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                string PC_IP = this.grd01.GetValue(row, "PC_IP").ToString();
                string PROGRAM_ID = this.grd01.GetValue(row, "PROGRAM_ID").ToString();
                string SCREEN_ID = this.grd01.GetValue(row, "SCREEN_ID").ToString();
                string BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();

                this.CURRENT_PC_IP = PC_IP;
                this.CURRENT_PROGRAM_ID = PROGRAM_ID;
                this.CURRENT_SCREEN_ID = SCREEN_ID;
                this.CURRENT_BIZCD = BIZCD;

                this.LoadSection(PROGRAM_ID, SCREEN_ID);



            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void grd01_RowColChange(object sender, EventArgs e)
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



                string SECTION_ID = this.grd02.GetValue(row, "SECTION_ID").ToString();
                
                this.CURRENT_SECTION_ID = SECTION_ID;
                this.LoadINIKey(CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID, SECTION_ID, CURRENT_PC_IP);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void grd02_RowColChange(object sender, EventArgs e)
        {
           
        }
              
        //private void grd03_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    try
        //    {
        //        Init_Data(3);

        //        int row = this.grd03.SelectedRowIndex;
        //        if (row < this.grd03.Rows.Fixed)
        //            return;

        //        string INI_KEY = this.grd03.GetValue(row, "INI_KEY").ToString();

        //        this.CURRENT_INI_KEY = INI_KEY;
        //        this.LoadINIKeyValue(CURRENT_PC_IP, CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID, CURRENT_SECTION_ID, INI_KEY);

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //    }
        //}
        private void grd03_RowColChange(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
      
        #endregion

        #region [사용자 정의 메서드]

        private void Init_Data(int step)
        {
            try
            {
                if (step < 1)
                {
                    
                    this.grd01.InitializeDataSource();
                    CURRENT_PC_IP = "";
                    CURRENT_PROGRAM_ID = "";
                    CURRENT_SCREEN_ID = "";
                    CURRENT_BIZCD = "";
                }

                if (step < 2)
                {
                    this.grd02.InitializeDataSource();
                    CURRENT_SECTION_ID = "";
                }

                if (step < 3)
                {
                    this.grd03.InitializeDataSource();
                    //CURRENT_INI_KEY = "";
                }

                //if (step < 4)
                //{
                //    this.txt01_INI_KEYVALUE.Initialize();
                //}            
   
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private bool LoadPC(string PC_NM, string PC_IP, string LINECD)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();               
                set.Add("PC_NM", PC_NM);
                set.Add("PC_IP", PC_IP);
                set.Add("LINECD", LINECD);
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);

                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_PC(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PC"), set, "OUT_CURSOR").Tables[0];

                this.AfterInvokeServer();
                this.grd01.SetValue(source);

                return (source.Rows.Count <= 0 || source == null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return true;
        }

        private void LoadSection(string PROGRAM_ID, string SCREEN_ID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("SCREEN_ID", SCREEN_ID);

                //DataTable source = _WSCOM.INQUERY_SECTION(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SECTION"), set, "OUT_CURSOR").Tables[0];
                this.grd02.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void LoadINIKey(string PROGRAM_ID, string SCREEN_ID, string SECTION_ID, string PC_IP)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                set.Add("PROGRAM_ID", PROGRAM_ID);
                set.Add("SCREEN_ID", SCREEN_ID);
                set.Add("SECTION_ID", SECTION_ID);
                set.Add("PC_IP", PC_IP);

                //DataTable source = _WSCOM.INQUERY_KEY(set).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_KEY"), set, "OUT_CURSOR").Tables[0];
                this.grd03.SetValue(source);

                //
                // BEGIN 20190514 'CLIENT_ID' 변경 금지
                if (null != source && 0 < source.Rows.Count)
                {
                    for (int j_cnt = 0; j_cnt < source.Rows.Count; j_cnt++)
                    {
                        DataRow obj = source.Rows[j_cnt];
                        if (source.Columns.Contains("INI_KEY"))
                        {
                            string s_ini = DBNull.Value.Equals(obj["INI_KEY"]) ? "" : obj["INI_KEY"].ToString();
                            if (string.Compare(s_ini, "CLIENT_ID", false) == 0) this.grd03.Rows[j_cnt + 1].AllowEditing = false;
                        }
                    }
                }
                // END 20190514
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //private void LoadINIKeyValue(string PC_IP, string PROGRAM_ID, string SCREEN_ID, string SECTION_ID, string INI_KEY)
        //{
        //    try
        //    {
        //        HEParameterSet set = new HEParameterSet();
        //        //set.Add("CORCD", this.UserInfo.CorporationCode);

        //        set.Add("PROGRAM_ID", PROGRAM_ID);
        //        set.Add("SCREEN_ID", SCREEN_ID);
        //        set.Add("SECTION_ID", SECTION_ID);
        //        set.Add("INI_KEY", INI_KEY);
        //        set.Add("PC_IP", PC_IP);

        //        DataTable source = _WSCOM.INQUERY_KEYVALUE(set).Tables[0];

        //        if (source.Rows.Count > 0)
        //        {
        //            txt01_INI_KEYVALUE.SetValue(source.Rows[0][0].ToString());
        //        }
        //        else
        //        {
        //            txt01_INI_KEYVALUE.Initialize();
        //        }
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //    }
        //}


        private bool IsSaveValid(DataSet source)
        {
            try
            {
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow set = source.Tables[0].Rows[i];
                    string PROGRAM_ID = set["PROGRAM_ID"].ToString();
                    string SCREEN_ID = set["SCREEN_ID"].ToString();
                    string SECTION_ID = set["SECTION_ID"].ToString();
                    string INI_KEY = set["INI_KEY"].ToString();
                    string PC_IP = set["PC_IP"].ToString();
                    string KEYVALUE = set["INI_KEYVALUE"].ToString();

                    if (this.GetByteCount(PC_IP) == 0)
                    {
                        //MsgBox.Show("공정용 PC마스터 항목이 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("PC_IP"));
                        return false;
                    }

                    if (this.GetByteCount(PROGRAM_ID) == 0)
                    {
                        //MsgBox.Show("공정용 PC마스터 항목이 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("PROGRAM_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SCREEN_ID) == 0)
                    {
                        //MsgBox.Show("공정용 PC마스터 항목이 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("SCREEN_ID"));
                        return false;
                    }

                    if (this.GetByteCount(SECTION_ID) == 0)
                    {
                        //MsgBox.Show("INI 섹션 마스터 항목이 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("SECTION_ID"));
                        return false;
                    }

                    if (this.GetByteCount(INI_KEY) == 0)
                    {
                        //MsgBox.Show("INI 키 마스터 항목이 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("PD80010_GRP_1"));
                        return false;
                    }

                    if (this.GetByteCount(KEYVALUE) == 0)
                    {
                        //MsgBox.Show("키값 정보가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("INI_KEY"));
                        return false;
                    }
                }
                //if (MsgBox.Show("입력하신 키값 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //if (MsgBox.Show("입력하신 공정화면 마스터 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.ShowFormat("PD00-0016", MessageBoxButtons.OKCancel, this.GetLabel("INI_KEY")) != DialogResult.OK)
                    return false;

                return true;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private void SaveKEYVALUE()
        {
            try
            {
                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Save, "PROGRAM_ID", "SCREEN_ID", "SECTION_ID", "INI_KEY", "PC_IP", "INI_KEYVALUE", "USER_ID","CORCD","BIZCD");

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];
                    dr["PROGRAM_ID"] = CURRENT_PROGRAM_ID;
                    dr["SCREEN_ID"] = CURRENT_SCREEN_ID;
                    dr["SECTION_ID"] = CURRENT_SECTION_ID;
                    dr["PC_IP"] = CURRENT_PC_IP;
                    dr["USER_ID"] = UserInfo.EmpNo;
                    dr["CORCD"] = UserInfo.CorporationCode;
                    dr["BIZCD"] = UserInfo.BusinessCode;
                }
                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_KEYVALUE"), source);

                this.AfterInvokeServer();
                //MsgBox.Show("입력하신 키 값 정보를 저장하였습니다.");
                MsgCodeBox.Show("CD00-0071");


                this.LoadINIKey( CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID, CURRENT_SECTION_ID, CURRENT_PC_IP);
                

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

        private void CopyKEYVALUE(string IN_COPY_IP)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                set.Add("PC_IP", CURRENT_PC_IP);
                set.Add("COPY_IP", IN_COPY_IP);
                set.Add("USER_ID", UserInfo.EmpNo);

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "COPY_KEYVALUE"), set);

                this.AfterInvokeServer();

                //MsgBox.Show("입력하신 키 값 정보를 저장하였습니다.");
                MsgCodeBox.Show("CD00-0071");

                this.LoadPC(txt01_PC_NM.GetValue().ToString(), txt01_PC_IP.GetValue().ToString(), txt01_LINECD.GetValue().ToString());
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
            for (int i = 0; i < source.Tables[0].Rows.Count; i++)
            {
                DataRow set = source.Tables[0].Rows[i];
                string PROGRAM_ID = set["PROGRAM_ID"].ToString();
                string SCREEN_ID = set["SCREEN_ID"].ToString();
                string SECTION_ID = set["SECTION_ID"].ToString();
                string INI_KEY = set["INI_KEY"].ToString();
                string PC_IP = set["PC_IP"].ToString();

                if (this.GetByteCount(PC_IP) == 0)
                {
                    //MsgBox.Show("삭제할 키값 항목이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0022", GetLabel("PC_IP"));
                    return false;
                }

                if (this.GetByteCount(PROGRAM_ID) == 0)
                {
                    //MsgBox.Show("삭제할 키값 항목이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0022", GetLabel("PROGRAM_ID"));
                    return false;
                }

                if (this.GetByteCount(SCREEN_ID) == 0)
                {
                    //MsgBox.Show("삭제할 키값 항목이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0022", GetLabel("SCREEN_ID"));
                    return false;
                }

                if (this.GetByteCount(SECTION_ID) == 0)
                {
                    //MsgBox.Show("삭제할 키값 항목이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0022", GetLabel("SECTION_ID"));
                    return false;
                }

                if (this.GetByteCount(INI_KEY) == 0)
                {
                    //MsgBox.Show("삭제할 키값 항목이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0022", GetLabel("INI_KEY"));
                    return false;
                }
            }


            //if (MsgBox.Show("선택하신 키 값 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)            
            if(MsgCodeBox.Show("CD00-0077",MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;

        }

        private void RemoveKEYVALUE()
        {
            try
            {
                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Remove, "PROGRAM_ID", "SCREEN_ID", "SECTION_ID", "INI_KEY", "PC_IP","CORCD","BIZCD");


                //HEParameterSet set = new HEParameterSet();
                //set.Add("PROGRAM_ID", CURRENT_PROGRAM_ID);
                //set.Add("SCREEN_ID", CURRENT_SCREEN_ID);
                //set.Add("SECTION_ID", CURRENT_SECTION_ID);
                //set.Add("INI_KEY", CURRENT_INI_KEY);
                //set.Add("PC_IP", CURRENT_PC_IP);
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];
                    dr["PROGRAM_ID"] = CURRENT_PROGRAM_ID;
                    dr["SCREEN_ID"] = CURRENT_SCREEN_ID;
                    dr["SECTION_ID"] = CURRENT_SECTION_ID;
                    dr["PC_IP"] = CURRENT_PC_IP;
                    dr["CORCD"] = UserInfo.CorporationCode;
                    dr["BIZCD"] = UserInfo.BusinessCode;
                }

                if (!this.IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_KEYVALUE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_KEYVALUE"), source);
                this.AfterInvokeServer();

                //MsgBox.Show("선택하신 키 값 정보를 삭제하였습니다.");
                MsgCodeBox.Show("CD00-0072");

                ////[#001]- INI KEY 마스터 MESCODE 전송
                //string msg = DN_MESCODE(CURRENT_BIZCD);
                //if (!msg.StartsWith("OK"))
                //{
                //    string biz = CURRENT_BIZCD == "5210" ? "울산" : "아산";
                //    MsgBox.Show(biz + "사업장 MESCODE 다운로드에 실패하였습니다.");
                //}           

                this.LoadINIKey( CURRENT_PROGRAM_ID, CURRENT_SCREEN_ID, CURRENT_SECTION_ID, CURRENT_PC_IP);
                

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
        
        #endregion    

        private void btn01_COPY_Click(object sender, EventArgs e)
        {
            bool valid = this.ValidateIPv4(txt01_CopyIP.Text);

            //HR03-0020

            if (!valid)
            {
                MsgCodeBox.ShowFormat("HR03-0020", "Invalid Copy IP Address : " + txt01_CopyIP.Text);
                return;
            }

            valid = (!string.IsNullOrEmpty(CURRENT_PC_IP));

            if (!valid)
            {
                MsgCodeBox.ShowFormat("HR03-0020", "First Select Target PC_IP");
                return;
            }

            valid = this.LoadPC(string.Empty, txt01_CopyIP.Text, string.Empty);

            if (!valid)
            {
                MsgCodeBox.ShowFormat("HR03-0020", "Already Exist COPY PC_IP : " + txt01_CopyIP.Text);
                return;
            }

            if (valid)
            {
                try
                {
                    this.CopyKEYVALUE(txt01_CopyIP.Text);

                    txt01_CopyIP.Text = "";
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
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            IPAddress address;
            return IPAddress.TryParse(ipString, out address);
        }
    }
}
