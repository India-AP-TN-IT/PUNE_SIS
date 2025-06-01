#region ▶ Description & History
/* 
 * 프로그램명 : QA20015 부품별검사코드 설정 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>부품별검사코드 설정 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:32:34<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:32:34   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20015 : AxCommonBaseControl
    {
        //private IQA20015 _WSCOM;
        private int iCurLine;
        private int iMaxLine;


        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20015";

        #region [ 초기화 작업 정의 ]

        public QA20015()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20015>("QA00", "QA20015.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.SetButtonVisible();

                for (int idx = 1; idx <= 10; idx++)
                {
                    Control[] c = this.Controls.Find("txt" + idx.ToString("00") + "_IN_LEFT", true);
                    if (c.Length > 0)
                    {
                        AxTextBox txt = c[0] as AxTextBox;
                        txt.SetValid(AxTextBox.TextType.OnlyNumber);
                    }
                }
                for (int idx = 1; idx <= 10; idx++)
                {
                    Control[] c = this.Controls.Find("txt" + idx.ToString("00") + "_IN_RIGHT", true);
                    if (c.Length > 0)
                    {
                        AxTextBox txt = c[0] as AxTextBox;
                        txt.SetValid(AxTextBox.TextType.OnlyNumber);
                    }
                }
                for (int idx = 1; idx <= 10; idx++)
                {
                    Control[] c = this.Controls.Find("txt" + idx.ToString("00") + "_INSPECTCOUNT", true);
                    if (c.Length > 0)
                    {
                        AxTextBox txt = c[0] as AxTextBox;
                        txt.SetValid(AxTextBox.TextType.OnlyNumber);
                    }
                }

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]


        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                iCurLine = 1;
                iMaxLine = 10;

                for (int i = 1; i <= iMaxLine; i++)
                {

                    this.SetControl(i, "pnl", "NO", false, "");
                    this.SetControl(i, "pnl", "INCOUNT", false, "");
                    this.SetControl(i, "pnl", "INSPECTCOUNT", false, "");
                    this.SetControl(i, "txt", "IN_LEFT", false, "");
                }

                this.InitSamplingdata();
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsSaveValid())
                    return;

                this.SaveSamplingData();
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
        //검사수량 입력값 체크
        private void txt01_INSPECTCOUNT_Leave(object sender, EventArgs e)
        {
            try
            {
                //AxTextBox txt = sender as AxTextBox;
                //if (this.IsNumeric(txt.Text))
                //{
                //    if (this.GetIntVal(txt.GetValue().ToString()) > 10 || this.GetIntVal(txt.GetValue().ToString()) < 1)
                //    {
                //        MsgCodeBox.Show("QAINSPECT-0005");//"1~10 까지의 숫자만 가능합니다."
                //        txt.Focus();
                //    }
                //}
                //else
                //{
                //    MsgCodeBox.Show("QAINSPECT-0005");//"1~10 까지의 숫자만 가능합니다."
                //    txt.Focus();
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------
        //수량 변경시에 자동으로 다음줄의 왼쪽 값에 1 을 더해서 보여준다.
        //-----------------------------------------------------------------------------------
        private void txt01_IN_RIGHT_TextChanged(object sender, EventArgs e)
        {
            try
            {

                AxTextBox txt = sender as AxTextBox;
                if (!this.IsNumeric(txt.GetValue().ToString()))
                    MsgCodeBox.Show("QAINSPECT-0006");//"숫자형식이 아닙니다."           
                else
                {
                    int value = this.GetIntVal(txt.GetValue().ToString());
                    if (value != 9999999)
                    {
                        // txtInLeft(Index + 1).Text = txtInRight(Index).Text + 1
                        int idx = this.GetIntVal(txt.Name.Substring(3, 2));

                        Control[] cNextLeft = this.Controls.Find("txt" + (idx + 1).ToString("00") + "_IN_LEFT", true);
                        if (cNextLeft[0] is AxTextBox)
                        {
                            ((AxTextBox)cNextLeft[0]).SetValue(Convert.ToString(value + 1));
                        }
                    }
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        //-----------------------------------------------------------------------------------
        // 추가버튼 클릭시
        //데이터 로우를  하나 더 보여준다.
        //-----------------------------------------------------------------------------------
        private void btn01_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (iCurLine < iMaxLine)
                {
                    this.SetControl(iCurLine + 1, "pnl", "NO", true, "");
                    this.SetControl(iCurLine + 1, "pnl", "INCOUNT", true, "");
                    this.SetControl(iCurLine + 1, "pnl", "INSPECTCOUNT", true, "");

                    this.SetControl(iCurLine, "txt", "IN_RIGHT", true, null);
                    this.SetControl(iCurLine + 1, "txt", "IN_RIGHT", false, "9999999");
                    this.SetControl(iCurLine + 1, "txt", "IN_LEFT", false, "0");

                    iCurLine++;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (iCurLine > 1)
                {
                    this.SetControl(iCurLine, "pnl", "NO", false, "");
                    this.SetControl(iCurLine, "pnl", "INCOUNT", false, "");
                    this.SetControl(iCurLine, "pnl", "INSPECTCOUNT", false, "");

                    this.SetControl(iCurLine - 1, "txt", "IN_RIGHT", false, "9999999");

                    iCurLine--;

                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        #endregion

        #region [유효성 검사]


        //-----------------------------------------------------------------------------------
        //입력된 값에 오류가 있는지 검사한다.
        //-----------------------------------------------------------------------------------
        private bool IsSaveValid()
        {
            try
            {
                for (int i = 1; i <= iCurLine; i++)
                {
                    string value = this.GetControlValue(i, "INSPECTCOUNT");
                    if (value.Equals("0") || value.Equals(string.Empty))
                    {
                        MsgCodeBox.Show("QAINSPECT-0007");//검사수량에 잘못된 데이터가 있습니다.
                        return false;
                    }

                    if (this.GetIntVal(value) > 10 || this.GetIntVal(value) < 1)
                    {
                        MsgCodeBox.Show("QAINSPECT-0005");//"1~10 까지의 숫자만 가능합니다."
                        return false;
                    }


                    string left = this.GetControlValue(i, "IN_LEFT");
                    if (left.Equals(string.Empty))
                    {
                        MsgCodeBox.Show("QAINSPECT-0008");//입고수량에 잘못된 데이터가 있습니다.
                        return false;
                    }


                    string right = this.GetControlValue(i, "IN_RIGHT");
                    if (right.Equals(string.Empty))
                    {
                        MsgCodeBox.Show("QAINSPECT-0008");//입고수량에 잘못된 데이터가 있습니다.
                        return false;
                    }


                    if (this.GetIntVal(left) > this.GetIntVal(right))
                    {
                        MsgCodeBox.Show("QAINSPECT-0009");//입고수량의 우측값이 좌측값보다 작거나 같을수 없습니다.
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region [ 사용자 정의 메서드 ]


        private void SetButtonVisible()
        {
            bool visible = true;

            //if (UserInfo.PlantDiv.Equals("U902"))
            //    visible = false;

            this.btn01_ADD.Visible = visible;
            this.btn01_DELETE.Visible = visible;
            this.GetCommonButton(COMMONBUTTONTYPE.QUERY).Enabled = visible;
            this.GetCommonButton(COMMONBUTTONTYPE.SAVE).Enabled = visible;

        }

        private void SetControl(int idx, string prefix, string ctrl_name, bool visible_enable, string value)
        {
            try
            {
                Control[] c = this.Controls.Find(prefix + idx.ToString("00") + "_" + ctrl_name, true);
                if (c.Length > 0)
                {
                    if (prefix.Equals("txt"))
                    {
                        AxTextBox txt = c[0] as AxTextBox;
                        if (value != null)
                            txt.SetValue(value);
                        txt.Enabled = visible_enable;
                    }
                    else
                        c[0].Visible = visible_enable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //-----------------------------------------------------------------------------------
        // 기존의 데이터를 읽어서 화면에 뿌려준다.
        //-----------------------------------------------------------------------------------
        private void InitSamplingdata()
        {
            try
            {
                HEParameterSet dic = new HEParameterSet();

                dic.Add("CORCD", this.UserInfo.CorporationCode);
                dic.Add("BIZCD", this.UserInfo.BusinessCode);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA20015", "INQUERY_SAMPLINGCOUNT"), dic);

                iCurLine = source.Tables[0].Rows.Count;

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];

                    this.SetControl(i + 1, "pnl", "NO", true, "");
                    this.SetControl(i + 1, "pnl", "INCOUNT", true, "");
                    this.SetControl(i + 1, "pnl", "INSPECTCOUNT", true, "");

                    if (i == iCurLine - 1)
                        this.SetControl(i + 1, "txt", "IN_RIGHT", false, dr["SPL_UPPER"].ToString());
                    else
                        this.SetControl(i + 1, "txt", "IN_RIGHT", true, dr["SPL_UPPER"].ToString());

                    this.SetControl(i + 1, "txt", "IN_LEFT", false, dr["SPL_LOWER"].ToString());
                    this.SetControl(i + 1, "txt", "INSPECTCOUNT", true, dr["INP_COUNT"].ToString());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-----------------------------------------------------------------------------------
        // 데이터를 저장한다.
        //-----------------------------------------------------------------------------------
        private void SaveSamplingData()
        {
            try
            {

                string[] proc = new string[] { string.Format("{0}.{1}", "APG_QA20015", "REMOVE_SAMPLINGCOUNT") ,
                                               string.Format("{0}.{1}", "APG_QA20015", "SAVE_SAMPLINGCOUNT")};


                DataSet dsRemove = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD");
                dsRemove.Tables[0].Rows.Add(this.UserInfo.CorporationCode, this.UserInfo.BusinessCode);

                DataSet dsSave = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SPL_LOWER", "SPL_UPPER", "INP_COUNT", "EMPNO");
                for (int i = 1; i <= iCurLine; i++)
                {
                    dsSave.Tables[0].Rows.Add(this.UserInfo.CorporationCode, this.UserInfo.BusinessCode,
                                                this.GetControlValue(i, "IN_LEFT"),
                                                this.GetControlValue(i, "IN_RIGHT"),
                                                this.GetControlValue(i, "INSPECTCOUNT"),
                                                this.UserInfo.UserID);
                }
                DataSet[] source = new DataSet[] { dsRemove, dsSave };

                this.BeforeInvokeServer();
                _WSCOM_N.MultipleExecuteNonQueryTx(proc, source);
                this.AfterInvokeServer();
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }
        //숫자여부 확인
        private bool IsNumeric(string value)
        {
            try
            {
                int test;
                return int.TryParse(value, out test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //문자를 숫자로 변환
        private int GetIntVal(string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private string GetControlValue(int idx, string ctrl_name)
        {
            try
            {
                Control[] c = this.Controls.Find("txt" + idx.ToString("00") + "_" + ctrl_name, true);
                if (c.Length > 0)
                {
                    TextBox txt = c[0] as TextBox;
                    return txt.Text;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion




    }
}
