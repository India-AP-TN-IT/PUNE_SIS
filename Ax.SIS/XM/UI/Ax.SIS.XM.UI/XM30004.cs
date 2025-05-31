#region ▶ Description & History
/* 
 * 프로그램명 : 사용자별 권한 현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-02      배명희      프로그램 아이디 변경(XM60030 -> XM30004)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거     
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 사용자별 권한 현황
    /// </summary>
    public partial class XM30004 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30004";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        private bool _isLoadCompleted = false;

        #region [ 초기화 작업 정의 ]

        public XM30004()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable dtSystemCode = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, false);
                this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "_사번", "EMPNO", "EMPNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_성명", "EMPNM", "EMPNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "_라인명", "LINENAME", "LINENAME");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                //this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                //this.grd02.AutoResize = true; //row number 컬럼 사이즈가 작아져서 행번호가 이상하게 나타나서 AutoResize 처리 안함.

                this.grd02.AllowFiltering = true;

                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 080, "_그룹ID", "GROUPID", "GROUPID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "_그룹명", "GROUPNAME", "GROUPNAME");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 000, "_메뉴아이디", "MENUID", "MENUID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "_메뉴아이디", "MENUID2", "MENUID2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "_메뉴이름", "MENUNAME", "MENUNAME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_추가", "BASICACLC2", "BASICACLC2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_조회", "BASICACLR2", "BASICACLR2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_수정", "BASICACLU2", "BASICACLU2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_삭제", "BASICACLD2", "BASICACLD2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_리셋", "EXTACL1_2", "EXTACL1_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_처리", "EXTACL2_2", "EXTACL2_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_출력", "EXTACL3_2", "EXTACL3_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_다운", "EXTACL4_2", "EXTACL4_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_업", "EXTACL5_2", "EXTACL5_2");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한6", "EXTACL6", "EXTACL6");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한7", "EXTACL7", "EXTACL7");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한8", "EXTACL8", "EXTACL8");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한9", "EXTACL9", "EXTACL9");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한10", "EXTACL10", "EXTACL10");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한11", "EXTACL11", "EXTACL11");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한12", "EXTACL12", "EXTACL12");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한13", "EXTACL13", "EXTACL13");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한14", "EXTACL14", "EXTACL14");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한15", "EXTACL15", "EXTACL15");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한16", "EXTACL16", "EXTACL16");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한17", "EXTACL17", "EXTACL17");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한18", "EXTACL18", "EXTACL18");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한19", "EXTACL19", "EXTACL19");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한20", "EXTACL20", "EXTACL20");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한21", "EXTACL21", "EXTACL21");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한22", "EXTACL22", "EXTACL22");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한23", "EXTACL23", "EXTACL23");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한24", "EXTACL24", "EXTACL24");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한25", "EXTACL25", "EXTACL25");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한26", "EXTACL26", "EXTACL26");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한27", "EXTACL27", "EXTACL27");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한28", "EXTACL28", "EXTACL28");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한29", "EXTACL29", "EXTACL29");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한30", "EXTACL30", "EXTACL30");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한31", "EXTACL31", "EXTACL31");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 060, "_확장권한32", "EXTACL32", "EXTACL32");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLC2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLR2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLU2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLD2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL1_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL2_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL3_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL4_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL5_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL6");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL7");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL8");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL9");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL10");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL11");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL12");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL13");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL14");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL15");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL16");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL17");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL18");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL19");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL20");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL21");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL22");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL23");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL24");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL25");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL26");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL27");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL28");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL29");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL30");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL31");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL32");


                foreach (C1.Win.C1FlexGrid.Column col in this.grd02.Cols)
                    if (!col.Name.Equals("GROUPNAME"))
                        col.AllowFiltering = C1.Win.C1FlexGrid.AllowFiltering.None;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                
                //this.cbo01_SYSTEMCODE.DataBind(HEStaticCommon.GetSystemCode().Tables[0], false);

                _isLoadCompleted = true;

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [공통 버튼 이벤트]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("USERID", this.txt01_USERID.GetValue());
                paramSet.Add("USERNAME", this.txt01_USERNAME.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
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

        #region [컨트롤 이벤트]

        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                if(row < 0)
                {
                    return;
                }

                string USERID = this.grd01.GetValue(row, "EMPNO").ToString();
                this.Inquery_Detail(USERID);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_SYSTEMCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoadCompleted)
                return;
            try
            {
                this.grd02.InitializeDataSource();
                this.grd01_MouseDoubleClick(this.grd01, null);
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

        #region [사용자 정의 메서드]

        //시스템코드 콤보상자용 데이터 조회
        private DataTable getSystemCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20001, "INQUERY_SYSTEMCODE"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        private void Inquery_Detail(string USERID)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("USERID", USERID);
                paramSet.Add("SYSTEMCODE",this.cbo01_SYSTEMCODE.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);
                this.AfterInvokeServer();                
                this.grd02.SetValue(source.Tables[0]);
                
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
        
    }
}
