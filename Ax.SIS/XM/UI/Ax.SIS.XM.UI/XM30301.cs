#region ▶ Description & History
/* 
 * 프로그램명 : 오류정보조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-07      배명희      프로그램 아이디 변경(XM01510 -> XM30101)
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
    /// <b>오류정보조회</b>
	/// - 작 성 자 : Administrator<br />
	/// - 작 성 일 : 2010-07-07 오후 3:24:27<br />
	/// - 주요 변경 사항
	///     1) 2010-07-07 오후 3:24:27   Administrator : 최초 클래스 생성<br />
	/// </summary>
	public partial class XM30301 : AxCommonBaseControl, IMenuHelper
	{
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30301";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        //※※※ 파라메터 전달 MENU 오픈 1 → EventHandler  선언
        public event EventHandler UI_Ready;
        
        #region [ 초기화 작업 정의 ]

        //※※※ 파라메터 전달 MENU 오픈 2 → public 메서드 추가(타화면에서 메뉴를 open했을때의 특정처리)
        public void extraSearch(HEParameterSet param)
        {
            this.dtp01_STARTDATE.SetValue(param["BEG_DATE"]);
            this.dtp01_ENDDATE.SetValue(param["END_DATE"]);

            BtnQuery_Click(this, null);
        }

        public XM30301()
		{
			InitializeComponent();
            _WSCOM = new AxClientProxy();
          
		}

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

            //※※※ 파라메터 전달 MENU 오픈 3 → 이벤트 추가
            if (UI_Ready!=null) UI_Ready(this, e);
		}

		/// <summary>
		/// 그리드에 관련된 초기 설정을 수행한다.
		/// </summary>
		private void InitializeGridStyle()
		{
			this.grd01.AllowEditing = false;
			this.grd01.AllowAddNew = false;
			this.grd01.AllowDelete = false;
            this.grd01.Initialize(1, 1);
			this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            
            //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_메뉴아이디", "MENUID", "MENUID");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "_메뉴이름", "MENUNAME", "MENUNAME");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_System", "SYSTEMCODE", "SYSTEMCODE");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "_사용자 아이디", "USERID", "USERID");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "_사용자명", "USERNAME", "USERNAME");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "_사용자아이피", "USERIP", "USERIP");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "_오류일자", "ERRORDATE", "ERRORDATE");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "_예외데이터", "EXCEPTIONDATA", "EXCEPTIONDATA");
		}

		/// <summary>
		/// 그리드를 제외한 다른 컨트롤에 관련된 초기 설정을 수행한다.
		/// </summary>
		private void InitializeControlStyle()
		{
            DataTable dtSystemCode = this.getSystemCode();
            this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, false);
            this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

			this.dtp01_STARTDATE.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToShortDateString();
			this.dtp01_ENDDATE.Text = DateTime.Now.ToShortDateString();
		}

		#endregion

		#region [ 컨트롤 바인딩 설정 ]

        private void ClearBindings()
        {
            this.txt02_MENUID.DataBindings.Clear();
            this.txt02_MENUNAME.DataBindings.Clear();
            this.txt02_SYSTEMCODE.DataBindings.Clear();
            this.txt02_USERID.DataBindings.Clear();
            this.txt02_USERNAME.DataBindings.Clear();
            this.txt02_USERIP.DataBindings.Clear();
            this.txt02_ERRORDATE.DataBindings.Clear();
            this.txt02_EXCEPTIONDATA.DataBindings.Clear();

            this.txt02_MENUID.Clear();
            this.txt02_MENUNAME.Clear();
            this.txt02_SYSTEMCODE.Clear();
            this.txt02_USERID.Clear();
            this.txt02_USERNAME.Clear();
            this.txt02_USERIP.Clear();
            this.txt02_ERRORDATE.Clear();
            this.txt02_EXCEPTIONDATA.Clear();
        }

		/// <summary>
		/// 그리드와 바인딩되는 컨트롤들의 바인딩 정의를 설정한다.
		/// </summary>
		private void SetControlBinding()
		{
            this.ClearBindings();

			this.txt02_MENUID.Enabled = true;
			this.txt02_MENUID.DataBindings.Add("Text", this.grd01.DataSource, "MENUID");
			this.txt02_MENUID.Enabled = false;
			this.txt02_MENUNAME.Enabled = true;
			this.txt02_MENUNAME.DataBindings.Add("Text", this.grd01.DataSource, "MENUNAME");
			this.txt02_MENUNAME.Enabled = false;
			this.txt02_SYSTEMCODE.Enabled = true;
			this.txt02_SYSTEMCODE.DataBindings.Add("Text", this.grd01.DataSource, "SYSTEMCODE");
			this.txt02_SYSTEMCODE.Enabled = false;
			this.txt02_USERID.Enabled = true;
			this.txt02_USERID.DataBindings.Add("Text", this.grd01.DataSource, "USERID");
			this.txt02_USERID.Enabled = false;
			this.txt02_USERNAME.Enabled = true;
			this.txt02_USERNAME.DataBindings.Add("Text", this.grd01.DataSource, "USERNAME");
			this.txt02_USERNAME.Enabled = false;
			this.txt02_USERIP.Enabled = true;
			this.txt02_USERIP.DataBindings.Add("Text", this.grd01.DataSource, "USERIP");
			this.txt02_USERIP.Enabled = false;
			this.txt02_ERRORDATE.Enabled = true;
			this.txt02_ERRORDATE.DataBindings.Add("Text", this.grd01.DataSource, "ERRORDATE");
			this.txt02_ERRORDATE.Enabled = false;
			this.txt02_EXCEPTIONDATA.DataBindings.Add("Text", this.grd01.DataSource, "EXCEPTIONDATA");
		}

		#endregion

		#region [ 공통 버튼에 대한 이벤트 정의 ]

		protected override void BtnQuery_Click(object sender, EventArgs e)
		{
			HEParameterSet paramSet = new HEParameterSet();
            paramSet["STARTDATE"] = this.dtp01_STARTDATE.GetDateText();
			// 마지막날짜까지 조회되어야 하기 때문에 1일을 추가해준다.
            paramSet["ENDDATE"] = this.dtp01_ENDDATE.GetDateText();
			paramSet["LANGUAGE"] = this.UserInfo.Language;
            paramSet["SYSTEMCODE"] = this.cbo01_SYSTEMCODE.GetValue().ToString();

			DataTable dtErrorLog = new DataTable();

			try
			{
				// FX00-0033 : 오류 로그 정보를 조회중입니다.
                this.BeforeInvokeServer(MessageManager.GetMessage("XM00-0089"));

                dtErrorLog = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet).Tables[0];
                this.AfterInvokeServer();
				// FX00-0002 : {0}개의 데이터가 조회되었습니다.
                this.ShowMessage(MessageManager.GetMessage("XM00-0079"), dtErrorLog.Rows.Count.ToString());

				//this.grd01.x_DataBind(dtErrorLog.DefaultView, false);
                this.grd01.SetValue(dtErrorLog);
                if (dtErrorLog.Rows.Count > 0)
                {
                    SetControlBinding();
                }
                else
                {
                    ClearBindings();
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
        
        protected override TheOne.Security.SecurityContext CreateSecurityContext()
		{
			//조회권한을 제외한 생성,수정,삭제 권한을 false로 지정한다.
			return new HE.Framework.Core.Security.HESecurityContext(false, true, false, false);
		}
        
        #endregion       
       
	}
}
