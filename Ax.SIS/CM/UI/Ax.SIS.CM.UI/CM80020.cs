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
    public partial class CM80020 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_CM80020";

        #region [ 초기화 작업에 대한 정의 ]

        public CM80020()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<ICM80020>("CM", "CM80020.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.Query();
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

                DataSet source = this.GetDataSourceSchema("USERID", "ENVNAME", "ENVVALUE");

                source.Tables[0].Rows.Add(
                    this.UserInfo.EmpNo,
                    "FONT-FAMILY",
                    this.txt01_FONTFAMILY.GetValue()
                    );

                source.Tables[0].Rows.Add(
                    this.UserInfo.EmpNo,
                    "FONT-SIZE",
                    this.txt01_FONTSIZE.GetValue()
                    );

                source.Tables[0].Rows.Add(
                    this.UserInfo.EmpNo,
                    "SHOWTOPMENU",
                    (this.chk01_SHOWTOPMENU.Checked) ? "Y" : "N"
                    );

                source.Tables[0].Rows.Add(
                    this.UserInfo.EmpNo,
                    "SHOWLEFTMENUID",
                    (this.chk01_SHOWLEFTMENUID.Checked) ? "Y" : "N"
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                MsgBox.Show("User environment information has changed.");//"사용자 환경 정보가 변경 되었습니다.");
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


        #region [ 기타 이벤트 정의 ]
        
        private void btn01_FONTSETTING_Click(object sender, EventArgs e)
        {
            try
            {
                using (FontDialog fdg01 = new FontDialog())
                {
                    if (fdg01.ShowDialog() != DialogResult.Cancel)
                    {
                        this.txt01_FONTFAMILY.Enabled = true;
                        this.txt01_FONTFAMILY.Text = fdg01.Font.Name;
                        this.txt01_FONTFAMILY.Enabled = false;

                        this.txt01_FONTSIZE.Enabled = true;
                        this.txt01_FONTSIZE.Text = fdg01.Font.Size.ToString();
                        this.txt01_FONTSIZE.Enabled = false;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void Query()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("USERID", this.UserInfo.EmpNo);

                //DataTable source = _WSCOM.INQUERY(set).Tables[0];
                DataTable source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set).Tables[0];

                if (source.Rows.Count > 0)
                {
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        switch (source.Rows[i]["ENVNAME"].ToString())
                        {
                            case "FONT-FAMILY":
                                this.txt01_FONTFAMILY.Enabled = true;
                                this.txt01_FONTFAMILY.Text = source.Rows[i]["ENVVALUE"].ToString();
                                this.txt01_FONTFAMILY.Enabled = false;
                                break;
                            case "FONT-SIZE":
                                this.txt01_FONTSIZE.Enabled = true;
                                this.txt01_FONTSIZE.Text = source.Rows[i]["ENVVALUE"].ToString();
                                this.txt01_FONTSIZE.Enabled = false;
                                break;
                            case "SHOWLEFTMENUID":
                                this.chk01_SHOWLEFTMENUID.Checked = string.Compare(source.Rows[i]["ENVVALUE"].ToString(), "Y", true) == 0;
                                break;
                            case "SHOWTOPMENU":
                                this.chk01_SHOWTOPMENU.Checked = string.Compare(source.Rows[i]["ENVVALUE"].ToString(), "Y", true) == 0;
                                break;
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsSaveValid()
        {
            try
            {

                //if (MsgBox.Show("사용자 환경 정보를 저장 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgBox.Show("Do you want to save the user environment information?", "Caution", 
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
