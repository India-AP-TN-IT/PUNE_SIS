using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.CM.UI
{
    public partial class CM80010 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_CM80010";

        #region [ 생성자 정의 ]

        public CM80010()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<ICM80010>("CM", "CM80010.svc", "CustomBinding");
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
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

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSaveValid()) return;

                DataSet source = this.GetDataSourceSchema("USERID", "USERPWD");

                source.Tables[0].Rows.Add(
                    this.UserInfo.EmpNo,
                    TheOne.Security.CryptoHelper.EncryptBase64(this.txt01_NEW_PASSWORD.GetValue().ToString())
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.txt01_NEW_PASSWORD.Initialize();
                this.txt01_CONFIRM_PASSWORD.Initialize();
                this.txt01_EXISTING_PASSWORD.Initialize();

                MsgBox.Show("Your password has been changed.");//"비밀번호가 변경 되었습니다.");
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

        #region [ 유효성 체크 ]
            
        private bool IsSaveValid()
        {
            try
            {
                if (this.UserInfo.AuthSvr.Equals("AD"))
                {
                    MsgBox.Show("DB Login user, you can only change your password.");//"DB Login 유저만 비밀번호를 변경할 수 있습니다.");
                    return false;
                }

                if (this.txt01_EXISTING_PASSWORD.IsEmpty)
                {
                    MsgBox.Show("The old password has not been entered.");//"기존 비밀번호가 입력되지 않았습니다.");
                    this.txt01_EXISTING_PASSWORD.Focus();
                    return false;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("USERID", this.UserInfo.EmpNo);

                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);

                if (!source.Tables[0].Rows[0]["USERPWD"].ToString().Equals(
                    TheOne.Security.CryptoHelper.EncryptBase64(this.txt01_EXISTING_PASSWORD.GetValue().ToString())))
                {
                    MsgBox.Show("The old password is not correct.");//"기존 비밀번호가 정확하지 않습니다.");
                    this.txt01_EXISTING_PASSWORD.Focus();
                    return false;
                }

                if (this.txt01_NEW_PASSWORD.IsEmpty)
                {
                    MsgBox.Show("New password has not been entered.");//"신규 비밀번호가 입력되지 않았습니다.");
                    this.txt01_NEW_PASSWORD.Focus();
                    return false;
                }

                if (this.txt01_CONFIRM_PASSWORD.IsEmpty)
                {
                    MsgBox.Show("Enter a new password again.");//"변경할 비밀번호를 한번더 입력하세요");
                    this.txt01_CONFIRM_PASSWORD.Focus();
                    return false;
                }

                if (!this.txt01_NEW_PASSWORD.GetValue().ToString().Equals(this.txt01_CONFIRM_PASSWORD.GetValue().ToString()))
                {
                    MsgBox.Show("The new password is different.");//"변경할 비밀번호가 다릅니다.");
                    this.txt01_CONFIRM_PASSWORD.Focus();
                    return false;
                }

                //if (MsgBox.Show("비밀번호를 변경 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgBox.Show("Do you want to change your password?", "Caution", 
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion
    }
}
