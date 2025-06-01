#region ▶ Description & History
/* 
 * 프로그램명 : 사용자 액션 로그 조회 (User Action Log Search)
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-07      배명희      프로그램 아이디 변경(XM01520 -> XM30202)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 공통컨트롤로 전환
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거        
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Text;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// <b>사용자 액션 로그 조회</b>    
    /// </summary>
    public partial class XM30202 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30202";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";

        public XM30202()
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

            if (this.UserInfo.UserID.Equals("DEV1"))
                this.heButton1.Visible = true;
            else
                this.heButton1.Visible = false;
        }

        /// <summary>
        /// 그리드에 관련된 초기 설정을 수행한다.
        /// </summary>
        private void InitializeGridStyle()
        {
            this.grd01.AllowEditing = false;
            this.grd01.Initialize(1, 1);

            //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_메뉴아이디", "MENUID", "MENUID");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "_메뉴이름", "MENUNAME", "MENUNAME");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_액션로그유형", "ACTIONLOG_TYPE", "ACTIONLOG_TYPE");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_사용자 아이디", "USERID", "USERID");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_사용자명", "USERNAME", "USERNAME");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_아이피", "IP", "IP");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "_로그시간", "LOGDATE", "LOGDATE");
        }

        /// <summary>
        /// 그리드를 제외한 다른 컨트롤에 관련된 초기 설정을 수행한다.
        /// </summary>
        private void InitializeControlStyle()
        {
			// 로그 정보를 바인딩
			string[] logTypes = new string[8] { "ALL", "LOGIN", "SAVE", "DELETE", "QUERY", "DOWNLOAD", "UPLOAD", "PROCESS" };

			foreach (string logType in logTypes)
			{
				this.cbo01_ACTIONLOG_TYPE.Items.Add(logType);
			}

			this.cbo01_ACTIONLOG_TYPE.SelectedIndex = 0;


            DataTable dtSystemCode = this.getSystemCode();
            this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, false);
            this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

        }

        protected override TheOne.Security.SecurityContext CreateSecurityContext()
		{
			//조회권한을 제외한 생성,수정,삭제 권한을 false로 지정한다.
			return new HE.Framework.Core.Security.HESecurityContext(false, true, false, false);
		}

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue();
            set["BEG_DATE"] = this.dtp01_STARTDATE.GetDateText(); //.Value.Date.ToShortDateString();
            set["END_DATE"] = this.dtp01_ENDDATE.GetDateText(); //.Value.Date.ToShortDateString(); // this.dtp01_STARTDATE.Value.Date.ToShortDateString();
            set["LOGTYPE"] = string.Empty;
            set["LANG_SET"] = this.UserInfo.Language;

            set["LOGTYPE"] = this.cbo01_ACTIONLOG_TYPE.Text.Equals("ALL") ? "" : this.cbo01_ACTIONLOG_TYPE.Text.ToString();
                     
			DataTable dtActionLog = new DataTable();

			try
			{		
				// FX00-0034 : 로그 액션 정보를 조회중입니다.
                this.BeforeInvokeServer(MessageManager.GetMessage("XM00-0080"));

                dtActionLog = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set).Tables[0];

                this.AfterInvokeServer();
				// FX00-0002 : {0}개의 데이터가 조회되었습니다.
                this.ShowMessage(MessageManager.GetMessage("XM00-0079"), dtActionLog.Rows.Count.ToString());

				//this.grd01.x_DataBind(dtActionLog.DefaultView, false);
                this.grd01.SetValue(dtActionLog);
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

        #region [ 기타 이벤트 작업 정의 ]

        //※※※ 파라메터 전달 MENU 오픈 4 → MenuHelper.OpenMenu 
        private void heButton1_Click(object sender, EventArgs e)
        {
            HEParameterSet param = new HEParameterSet();
            param.Add("BEG_DATE", this.dtp01_STARTDATE.GetDateText());
            param.Add("END_DATE", this.dtp01_ENDDATE.GetDateText());
            MenuInfo mi = MenuHelper.OpenMenu(this, "XM30301", param);
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

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
        #endregion

    }

}
