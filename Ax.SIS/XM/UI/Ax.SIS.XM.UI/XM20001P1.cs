#region ▶ Description & History
/* 
 * 프로그램명 : 복사대상 사용자 ID 입력 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-01      배명희      프로그램 아이디 변경(XM60010P1 -> XM20001P1)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보),Popup용UserControl상속
 *                                          
*/
#endregion
using System;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 복사대상 사용자 ID 입력 팝업
    /// </summary>
    public partial class XM20001P1 : AxCommonPopupControl
    {
        private string _text = "";

        #region [ 생성자 ]

        public XM20001P1(string text)
        {
            InitializeComponent();
            _text = text;
        }

        #endregion

        #region [ 프로퍼티 ]

        public string Input_UserID
        {
            get { return this.txt03_USERID.GetValue().ToString(); }
        }

        public string Input_Option
        {
            get { return this.chk01_XM20001P1_CHK_1.Checked ? "Y" : "N"; }
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            ((Form)this.Parent).Text = _text;            
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn03_CONFIRM_Click(object sender, EventArgs e)
        {
            if (this.txt03_USERID.IsEmpty)
            {
                //MessageBox.Show("복사 대상이 될 사용자ID를 입력하세요.");
                MsgCodeBox.Show("XM00-0017");
                this.txt03_USERID.Focus();
                return;
            }

            ((Form)this.Parent).Close(); //this.Close();
        }

        private void txt03_USERID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btn03_CONFIRM_Click(null, null);
        }

        #endregion

    }
}
