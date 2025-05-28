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
    public partial class ZQA40120 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_ZQA40120";
        #region [ 초기화 작업 정의 ]

        public ZQA40120()
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

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "ID", "ACTNO", "ACTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 190, "NAME", "ACTNM", "ACTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "REMARK", "REMARK", "REMARK");



                

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
                string eono = Txt_EONO.GetValue().ToString();
                if(string.IsNullOrEmpty(eono))
                {
                    MsgBox.Show("Activity ID is mandatory!!");
                    return;
                }
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("ACTNO", Txt_EONO.GetValue());
                set.Add("ACTNM", Txt_EONM.GetValue());
                set.Add("REMARK", Txt_Remark.GetValue());
                set.Add("UPDATE_ID", this.UserInfo.UserID);


                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), set);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                ResetInput();
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
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            
            base.BtnDelete_Click(sender, e);
            if (grd01.SelectedRowIndex > -1)
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                
                string eono = grd01.GetValue(grd01.SelectedRowIndex, "ACTNO").ToString();
                if (!string.IsNullOrEmpty(eono))
                {
                    if (MsgBox.Show("Do you want to delete selected Activity:" + eono + "?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
                    {
                        HEParameterSet set = new HEParameterSet();
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", bizcd);
                        set.Add("ACTNO", eono);
                        _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEL_DATA"), set);
                        this.BtnQuery_Click(null, null);
                        ResetInput();
                    }
                }
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
                set.Add("ACTNO", axTextBox1.GetValue());
                set.Add("ACTNM", axTextBox6.GetValue());
                
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
            ResetInput();
        }
        
        #endregion

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResetInput();
            int row = this.grd01.SelectedRowIndex;
            string eono = grd01.GetValue(row, "ACTNO").ToString();
            if (!string.IsNullOrEmpty(eono))
            {
                Txt_EONO.SetValue(grd01.GetValue(row, "ACTNO").ToString());
                Txt_EONM.SetValue(grd01.GetValue(row, "ACTNM").ToString());
                Txt_Remark.SetValue(grd01.GetValue(row, "REMARK").ToString());
            }
        }
        private void ResetInput()
        {
            Txt_EONO.SetValue("");
            Txt_EONM.SetValue("");
            Txt_Remark.SetValue("");
        }






    }
}

