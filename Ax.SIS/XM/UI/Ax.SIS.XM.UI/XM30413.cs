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
 *				2014-07-07      배명희      프로그램 아이디 변경(XM01520 -> XM30413)
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
    public partial class XM30413 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30413";
        public XM30413()
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
            Reset();            
        }

        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string Procedure = string.Empty;
                this.BeforeInvokeServer(true);
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", UserInfo.Language);

                if (rdo01_ZMMT0360.Checked) Procedure = "ZMMT0360";
                //else if()

                //라디오버튼이므로 선택되지 않는 경우가 없으므로 else제외
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, Procedure), set);
                this.AfterInvokeServer();
                MsgCodeBox.Show("CD00-0013");
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


        private void Reset()
        {
            this._buttonsControl.BtnPrint.Visible = false;
            this._buttonsControl.BtnDownload.Visible = false;
            rdo01_ZMMT0360.Checked = true;
        }
    }

}
