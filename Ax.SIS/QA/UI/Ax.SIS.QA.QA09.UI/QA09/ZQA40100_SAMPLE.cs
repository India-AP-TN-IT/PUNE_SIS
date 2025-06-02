#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA09.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZQA40100_SAMPLE : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02110";

        #region [ 초기화 작업 정의 ]

        public ZQA40100_SAMPLE()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                axTextBox1.SetValue("");
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 64, "M/ID", "MID", "MID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 88, "VENDCD", "VENDCD", "VENDCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "VENDOR NAME", "VENDNM", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "DEPARTMENT", "DEPT", "DEPT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "NAME", "NAME", "NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "MOBILE", "MPHONE", "MPHONE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "E-MAIL", "EMAIL", "EMAIL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "OTP", "OTP", "OTP");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "USE", "USE_YN", "USE_YN");




                

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
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "TAXID", "TAXDESC", "INT_DEC", "EXT_DEC", "SEQ", "USE_YN", "ST_DATE", "ED_DATE");

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                    source.Tables[0].Rows[i]["BIZCD"] = bizcd;
                }
                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_DATA"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
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

                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", axDateEdit1.GetDateText());
                set.Add("TAXID", axTextBox1.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DATA"), set, "OUT_CURSOR");
                grd01.SetValue(source);
                this.AfterInvokeServer();

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

