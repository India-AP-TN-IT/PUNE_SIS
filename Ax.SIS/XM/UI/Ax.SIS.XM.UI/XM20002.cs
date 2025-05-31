#region ▶ Description & History
/* 
 * 프로그램명 : 권한 그룹 메뉴 설정
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-01      배명희      프로그램 아이디 변경(XM01210 -> XM20002)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Text;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// <b>그룹 메뉴 권한 관련 UI 화면</b>
    /// - 작 성 자 : Neostyx<br />
    /// - 작 성 일 : 2010-06-16 오후 1:41:50<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-16 오후 1:41:50   Neostyx : 최초 클래스 생성<br />
    /// </summary>
    public partial class XM20002 : AxCommonBaseControl
    {
		// 권한 그룹 테이블
		private DataTable _groupTable;
		// 권한 테이블
		private DataTable _authTable;
		// 메뉴 테이블
		private DataTable _menuTable;

        private bool _isLoadCompleted = false;

        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20002";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        public XM20002()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// Shown 이벤트를 통해 초기화 작업을 수행한다.
        /// </summary>
        /// <param name="sender">객체</param>
        /// <param name="e">이벤트</param>
        protected override void UI_Shown(EventArgs e)
        {            
            this.InitializeGridStyle();
            this.InitializeControlStyle();
            
			BtnQuery_Click(null, null);

            _isLoadCompleted = true;
        }

        /// <summary>
        /// 그리드에 관련된 초기 설정을 수행한다.
        /// </summary>
        private void InitializeGridStyle()
        {			
			this.grd01.AllowEditing = true;
			this.grd01.AllowSorting = AllowSortingEnum.None;
			this.grd01.SelectionMode = SelectionModeEnum.Row;

            this.grd01.Initialize();

            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "_메뉴아이디", "MENUID", "MENUID");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "_메뉴이름", "MENUNAME", "MENUNAME");
            this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 080, "_그룹ID", "GROUPID", "GROUPID");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_추가권한", "BASICACLC", "BASICACLC");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_조회권한", "BASICACLR", "BASICACLR");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_수정권한", "BASICACLU", "BASICACLU");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_삭제권한", "BASICACLD", "BASICACLD");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한1", "EXTACL1", "EXTACL1");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한2", "EXTACL2", "EXTACL2");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한3", "EXTACL3", "EXTACL3");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한4", "EXTACL4", "EXTACL4");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한5", "EXTACL5", "EXTACL5");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한6", "EXTACL6", "EXTACL6");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한7", "EXTACL7", "EXTACL7");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한8", "EXTACL8", "EXTACL8");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한9", "EXTACL9", "EXTACL9");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한10", "EXTACL10", "EXTACL10");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한11", "EXTACL11", "EXTACL11");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한12", "EXTACL12", "EXTACL12");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한13", "EXTACL13", "EXTACL13");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한14", "EXTACL14", "EXTACL14");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한15", "EXTACL15", "EXTACL15");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한16", "EXTACL16", "EXTACL16");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한17", "EXTACL17", "EXTACL17");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한18", "EXTACL18", "EXTACL18");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한19", "EXTACL19", "EXTACL19");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한20", "EXTACL20", "EXTACL20");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한21", "EXTACL21", "EXTACL21");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한22", "EXTACL22", "EXTACL22");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한23", "EXTACL23", "EXTACL23");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한24", "EXTACL24", "EXTACL24");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한25", "EXTACL25", "EXTACL25");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한26", "EXTACL26", "EXTACL26");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한27", "EXTACL27", "EXTACL27");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한28", "EXTACL28", "EXTACL28");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한29", "EXTACL29", "EXTACL29");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한30", "EXTACL30", "EXTACL30");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한31", "EXTACL31", "EXTACL31");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_확장권한32", "EXTACL32", "EXTACL32");

            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLC");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLR");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLU");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLD");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL1");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL2");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL3");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL4");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL5");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL6");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL7");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL8");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL9");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL10");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL11");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL12");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL13");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL14");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL15");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL16");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL17");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL18");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL19");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL20");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL21");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL22");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL23");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL24");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL25");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL26");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL27");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL28");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL29");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL30");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL31");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL32");
        }

        /// <summary>
        /// 그리드를 제외한 다른 컨트롤에 관련된 초기 설정을 수행한다.
        /// </summary>
        private void InitializeControlStyle()
        {
            DataTable dtSystemCode = this.getSystemCode();
            this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, false);
            this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);           
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {         
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                                "GROUPID", "MENUID", "SYSTEMCODE",
                                "BASICACLC", "BASICACLR", "BASICACLU", "BASICACLD",
                                "EXTACL1",  "EXTACL2", "EXTACL3", "EXTACL4", "EXTACL5", 
                                "EXTACL6",  "EXTACL7", "EXTACL8", "EXTACL9", "EXTACL10", 
                                "EXTACL11", "EXTACL12", "EXTACL13", "EXTACL14", "EXTACL15", 
                                "EXTACL16", "EXTACL17", "EXTACL18", "EXTACL19", "EXTACL20",
                                "EXTACL21", "EXTACL22", "EXTACL23", "EXTACL24", "EXTACL25", 
                                "EXTACL26", "EXTACL27", "EXTACL28", "EXTACL29", "EXTACL30",
                                "EXTACL31", "EXTACL32");

                if (source.Tables[0].Rows.Count <= 0)
                {
                    MsgCodeBox.Show("XM00-0024");//저장할 데이터가 없습니다.");
                    return;
                }

                //선택하신 메뉴를 저장하시겠습니까?
                if (MsgCodeBox.Show("XM00-0025",
                   MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue().ToString();
                    dr["BASICACLC"] = dr["BASICACLC"].ToString().Equals("Y") ? "1" : "0";
                    dr["BASICACLR"] = dr["BASICACLR"].ToString().Equals("Y") ? "1" : "0";
                    dr["BASICACLU"] = dr["BASICACLU"].ToString().Equals("Y") ? "1" : "0";
                    dr["BASICACLD"] = dr["BASICACLD"].ToString().Equals("Y") ? "1" : "0";

                    dr["EXTACL1"] = dr["EXTACL1"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL2"] = dr["EXTACL2"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL3"] = dr["EXTACL3"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL4"] = dr["EXTACL4"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL5"] = dr["EXTACL5"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL6"] = dr["EXTACL6"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL7"] = dr["EXTACL7"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL8"] = dr["EXTACL8"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL9"] = dr["EXTACL9"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL10"] = dr["EXTACL10"].ToString().Equals("Y") ? "1" : "0";

                    dr["EXTACL11"] = dr["EXTACL11"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL12"] = dr["EXTACL12"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL13"] = dr["EXTACL13"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL14"] = dr["EXTACL14"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL15"] = dr["EXTACL15"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL16"] = dr["EXTACL16"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL17"] = dr["EXTACL17"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL18"] = dr["EXTACL18"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL19"] = dr["EXTACL19"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL20"] = dr["EXTACL20"].ToString().Equals("Y") ? "1" : "0";

                    dr["EXTACL21"] = dr["EXTACL21"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL22"] = dr["EXTACL22"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL23"] = dr["EXTACL23"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL24"] = dr["EXTACL24"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL25"] = dr["EXTACL25"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL26"] = dr["EXTACL26"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL27"] = dr["EXTACL27"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL28"] = dr["EXTACL28"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL29"] = dr["EXTACL29"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL30"] = dr["EXTACL30"].ToString().Equals("Y") ? "1" : "0";

                    dr["EXTACL31"] = dr["EXTACL31"].ToString().Equals("Y") ? "1" : "0";
                    dr["EXTACL32"] = dr["EXTACL32"].ToString().Equals("Y") ? "1" : "0";
                }

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                // XM00-0018 : 정상적으로 처리되었습니다.
                MsgCodeBox.Show("XM00-0018");

                // 재조회
                BtnQuery_Click(null, null);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();

                // FX00-0003 : 다음과 같은 오류가 발생하였습니다.\r\n{0}
                MsgCodeBox.ShowFormat("XM00-0019", MessageBoxButtons.OK, ImageKinds.Error, ex.ToString());
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                "GROUPID",
                                "MENUID",
                                "SYSTEMCODE");

                if (source.Tables[0].Rows.Count <= 0)
                {
                    MsgCodeBox.Show("XM00-0022");//삭제할 데이터가 없습니다.
                    return;
                }

                //선택하신 메뉴를 삭제하시겠습니까? XM00-0023
                if (MsgCodeBox.Show("XM00-0023",
                   MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue().ToString();
                }

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                // FX00-0001 : 정상적으로 처리되었습니다.
                MsgCodeBox.Show("XM00-0018");

                // 재조회
                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();

                // FX00-0003 : 다음과 같은 오류가 발생하였습니다.\r\n{0}
                MsgCodeBox.ShowFormat("XM00-0019", MessageBoxButtons.OK, ImageKinds.Error, ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

		protected override void BtnQuery_Click(object sender, EventArgs e)
        {
			this.tv01_GROUP.Nodes.Clear();

			try
			{
				// FX00-0011 : 그룹 메뉴 권한 관리 정보를 조회중입니다.
				this.BeforeInvokeServer(MessageManager.GetMessage("XM00-0021"));

				// 권한 그룹 정보를 조회
				GetAuthGroupInfo();
				
				// 확장 권한 정보를 가져옴
				GetExtensionAuthInfo();				

				// 권한 그룹 정보가 있는 경우라면
				if (_groupTable != null && _groupTable.Rows.Count > 0)
				{
					this.ConfigurateTree();
				}
				else
                {
                    this.AfterInvokeServer();

					// FX00-0017: 권한 그룹 정보가 없습니다. 권한 그룹 정보를 먼저 설정하시기 바랍니다.
					MsgCodeBox.Show("XM00-0020");
				}
			}
			catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();

				// FX00-0003 : 다음과 같은 오류가 발생하였습니다.\r\n{0}
				MsgCodeBox.ShowFormat("XM00-0019", MessageBoxButtons.OK, ImageKinds.Error, ex.ToString());
			}
			finally
			{
				this.AfterInvokeServer();
			}
        }

        #endregion

		#region [ ETC METHODS ]

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

		/// <summary>
		/// 권한 그룹 정보를 조회하는 메서드
		/// </summary>
		private void GetAuthGroupInfo()
		{
            HEParameterSet paramSet = new HEParameterSet();
            paramSet["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue().ToString();

            _groupTable = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GROUP"), paramSet).Tables[0];
		}

		/// <summary>
		/// 권한 그룹과 관련 있는 메뉴 정보를 조회
		/// </summary>
		private void GetAuthGroupMenuInfo(string groupid)
		{
			HEParameterSet paramSet = new HEParameterSet();
            paramSet["GROUPID"] = groupid;
			paramSet["LANGUAGE"] = this.UserInfo.Language;
            paramSet["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue().ToString();

            _menuTable = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GROUP_MENU_AUTHORITY"), paramSet).Tables[0];

            this.grd01.SetValue(this._menuTable);
		}

		/// <summary>
		/// 확장 권한 정보를 조회
		/// </summary>
		private void GetExtensionAuthInfo() 
		{
			HEParameterSet paramSet = new HEParameterSet();
            paramSet["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue().ToString();

            _authTable = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_EXTENSION_AUTH_LIST"), paramSet).Tables[0];
			if (_authTable != null && _authTable.Rows.Count > 0)
			{
				UnVisibleFieldForExtensionAuth();
			}
		}

		/// <summary>
		/// 권한 그룹을 Tree 형태로 만드는 메서드
		/// </summary>
		private void ConfigurateTree()
		{
			int iCount = 0;
			string selectedGroupName = string.Empty;
			string selectedGroupID = string.Empty;

            //http://msdn.microsoft.com/ko-kr/library/system.windows.forms.treeview.beginupdate(v=vs.110).aspx
            //treeview 컨트롤에 scroll생성시 마지막 노드가 가려져서 잘 안보이는 버그 있음.
            //노드 추가 전에 BeginUpdate(); 호출하고 노드 추가완료 후 EndUpdate(); 호출하여야 
            //마지막 노드가 스크롤에 가려지지 않고 잘 나타남.
            this.tv01_GROUP.BeginUpdate();

			foreach (DataRow row in _groupTable.Rows)
			{
				TreeNode tn = new TreeNode(row["GROUPNAME"].ToString());
				tn.Tag = row;
				tn.Name = row["GROUPID"].ToString();
				tn.Text = row["GROUPNAME"].ToString();
                
				this.tv01_GROUP.Nodes.Add(tn);

				// 첫 번째 그룹에 대한 권한 정보를 화면에 표시한다.
				if (iCount == 0)
				{
					selectedGroupName = tn.Text;
					selectedGroupID = tn.Name;

					this.lbl01_GROUPNAME.Value = "Group Name : " + selectedGroupName;

                    // 권한 그룹과 관련 있는 메뉴 정보를 조회
                    this.GetAuthGroupMenuInfo(selectedGroupID);
				}
                
				iCount++;
			}

            this.tv01_GROUP.EndUpdate();

			this.tv01_GROUP.SelectedNode = this.tv01_GROUP.Nodes.Find(selectedGroupID, true)[0];
            this.tv01_GROUP.Focus();
		}

		/// <summary>
		/// 사용하는 확장 권한만을 보여주기 위한 메서드
		/// </summary>
		private void UnVisibleFieldForExtensionAuth()
		{
			string extAclName = string.Empty;

			// 1부터 32까지 루프를 돈다.
			for (int i = 1; i <= 32; i++)
			{
				extAclName = "EXTACL" + i.ToString();

				// 설정된 확장 권한 정보가 있는지를 확인한다.
				DataRow[] existRows = _authTable.Select("AUTHINDEX=" + i + " AND USE_YN = '1'");

				// 설정된 확장 권한 정보가 없는 경우
				if (existRows.Length != 1)
				{
					// 없으면 해당 Column의 Visible을 false시킨다.
					this.grd01.Cols[extAclName].Visible = false;
				}
			}
		}

		/// <summary>
		/// 선택한 메뉴에 대한 정보를 해당 DataTable에 추가/그리드에 추가하는 메서드
		/// </summary>
		/// <param name="paramSet"></param>
		private void AddGroupMenuInfo(HEParameterSet paramSet)
		{
			int selectedGroupID = int.Parse(this.tv01_GROUP.SelectedNode.Name);

			foreach (HEParameterSetItem item in paramSet.Items)
			{
				DataRow[] existRows = _menuTable.Select("MENUID='" + item.Key + "' AND GROUPID=" + selectedGroupID);

				// 1개 이상이라면 이미 추가된 행이므로 무시한다.
				if (existRows.Length == 0)
				{
					DataRow drNew = _menuTable.NewRow();
                   
					drNew["GROUPID"] = selectedGroupID;
					drNew["MENUID"] = item.Key;
					drNew["MENUNAME"] = item.Value;
					drNew["BASICACLC"] = true;
					drNew["BASICACLR"] = true;
					drNew["BASICACLU"] = true;
					drNew["BASICACLD"] = true;

					for (int i = 1; i <= 32; i++)
					{
						string extName = "EXTACL" + i.ToString();

						// 현재 보이는 컬럼의 경우
						if (this.grd01.Cols[extName].Visible == true)
						{
							drNew[extName] = true;
						}
						else
						{
							drNew[extName] = false;
						}
					}

					_menuTable.Rows.Add(drNew);                    
				}
			}
			
            this.grd01.SetValue(_menuTable);
            for (int i = 0; i < _menuTable.Rows.Count; i++)
            {
                if (_menuTable.Rows[i].RowState == DataRowState.Added)
                    this.grd01[i + this.grd01.Rows.Fixed, 0] = "N";
                else if (_menuTable.Rows[i].RowState == DataRowState.Modified)
                    this.grd01[i + this.grd01.Rows.Fixed, 0] = "U";
                else if (_menuTable.Rows[i].RowState == DataRowState.Deleted)
                    this.grd01[i + this.grd01.Rows.Fixed, 0] = "D";
            }          
		}

        #endregion

        #region [ EVENTS ]

        /// <summary>
        /// 트리에 있는 권한 그룹을 더블 클릭할 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv01_GROUP_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.tv01_GROUP.SelectedNode;
			
			if (selectedNode != null)
			{
				int selectedGroupID = int.Parse(selectedNode.Name);

				// TODO :: 다국어
				this.lbl01_GROUPNAME.Value = "Group Name : " + selectedNode.Text;

                // 권한 그룹과 관련 있는 메뉴 정보를 조회
                this.GetAuthGroupMenuInfo(selectedGroupID.ToString());
			}
		}

		/// <summary>
		/// 추가 버튼 클릭 시
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn01_ADD_Click(object sender, EventArgs e)
		{
			HEParameterSet paramSet = null;

            XM20002P1 popUpForm = new XM20002P1(this.GetLabel("XM20002P1"));
            popUpForm.SystemCode = this.cbo01_SYSTEMCODE.GetValue().ToString();
            popUpForm.Language = this.UserInfo.Language;
            
            this.ShowPopup(popUpForm);

            if (popUpForm.DialogResult == DialogResult.OK)
			{
				if (popUpForm.ReturnValue != null)
				{
					paramSet = popUpForm.ReturnValue as HEParameterSet;
				}
			}

			if (paramSet != null && paramSet.Items.Count > 0)
			{
				// 선택된 그룹의 DataTable에 새로운 데이터를 추가한다.
				AddGroupMenuInfo(paramSet);
			}
		}

		/// <summary>
		/// 삭제 버튼 클릭 시
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn01_MENUDELETE_Click(object sender, EventArgs e)
		{
			//BtnDelete_Click(null, null);
            if (this.grd01.Row < this.grd01.Rows.Fixed || this.grd01.Row >= this.grd01.Rows.Count)
            {
                MsgCodeBox.Show("XM00-0026");//삭제할 메뉴를 선택하세요
            }
            else
            {               
                this.grd01[this.grd01.Row, 0] = "D";
            }
		}
		
        //시스템코드콤보 변경시 재조회함.
        private void cbo01_SYSTEMCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted)
            {
                this.BtnQuery_Click(null, null);
            }
        }

        #endregion
    }
}
