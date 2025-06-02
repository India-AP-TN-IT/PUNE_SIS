#region ▶ Description & History
/* 
 * 프로그램명 : PD50130 알림글-동영상(기간, 시간)
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
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 고객사 비가공 - 공장별
    /// </summary>
    public partial class PD50130 : AxCommonBaseControl
    {
        //private IPD50130 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD50130";
        private AxComboList grd_CUSTCD;
        private AxComboList grd_CUST_PLANT;

        #region FTP정보

        private const string CN_FTP_INFOR_ASAN = "10.10.32.11;mes;mes;21";   //IP;ID;PWD;PORT
        private const string CN_FTP_INFOR_ULSAN = "10.10.10.19;mes;mes;21";  //IP;ID;PWD;PORT
        private const string CN_FTP_MV_FOLDER = @"MES_Board/MV/";
        #endregion

        private PDFTP m_ftpHandle = null;

        #region [ 초기화 작업 정의 ]

        public PD50130()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD50130>("PD", "PD50130.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");

            this.grd_CUSTCD = new AxComboList();
            this.grd_CUST_PLANT = new AxComboList();
        }
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region grd01
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 250, "법인코드", "CORCD", "CORCD");    
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 250, "사업장코드", "BIZCD", "BIZCD");  
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "파일명", "FILENAME", "FILE_NAME5");   

                
                #endregion

                
                #region grd02
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "법인코드", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "사업장코드", "BIZCD", "BIZCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "적용공정", "PROCD", "APPLY_PROC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "파일명", "FILENAME", "FILE_NAME5");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "시작일자", "SDATE", "SDATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "종료일자", "EDATE", "EDATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "시작시간", "STIME", "BEG_TIME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "종료시간", "ETIME", "END_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "재생순서", "PSEQ", "PLAY_SEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "사번", "EMP_NO", "EMPNO");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "M0", "PROCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "SDATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "EDATE");
                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                this.cbo01_PROCD.DataBind("M0", true);

                SetFtpInstance();
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PROCD", cbo01_PROCD.GetValue());
                set.Add("GDATE", heDateEdit1.GetDateText());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);
                LoadFTPFolder();
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
                if (!ValidateCheck())
                {
                    return;
                }
                
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                DataSet set = this.grd02.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "PROCD", "FILENAME", "SDATE",
                    "EDATE", "STIME", "ETIME", "PSEQ", "EMP_NO");

                

                this.BeforeInvokeServer(true);
//                _WSCOM.SAVE(bizcd, set);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), set);

                //bool isSyncOK = this.DN_MESCODE_MES5100(bizcd);
                
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 정보가 저장되었습니다");
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다.
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                DataSet set = this.grd02.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "PROCD", "FILENAME", "SDATE", "EDATE",
                     "STIME", "ETIME", "PSEQ", "EMP_NO");

                if (set.Tables[0].Rows.Count >= 1)
                {
                    this.BeforeInvokeServer(true);
                    //_WSCOM.REMOVE(bizcd, set);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), set);
                    //bool isSyncOK = this.DN_MESCODE_MES5100(bizcd);
                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);

                    //MsgBox.Show("선택하신 공장별 고객사 비가동 정보을 삭제하였습니다.");
                    MsgCodeBox.Show("CD00-0058");//데이터가 삭제되었습니다.
                }
                else
                {
                    //MsgBox.Show("마우스 오른쪽버튼의 행삭제 이후 삭제를 진행하시기 바랍니다.");
                    MsgCodeBox.Show("CD00-0041"); //삭제할 데이터가 존재하지 않습니다.
                }
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


        #region [미들서버에 코드정보 전송]
        //2014.02.10 - MES9906 현장 SMS 호출 공정 MESCODE 전송
        //private bool DN_MESCODE_MES5100(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES5100", bizcd).Tables[0].Rows[0][0].ToString();

        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                return false;

        //            }
        //            else
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show(msg);
        //                return false;
        //            }
        //        }

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    return true;
        //}
        #endregion

        

        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetFtpInstance();
                LoadFTPFolder();
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Btn_Path_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDlg = new OpenFileDialog();
            if (fDlg.ShowDialog() == DialogResult.OK)
            {
                this.heTextBox1.Value = fDlg.FileName;
            }
        }

        private void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                m_ftpHandle.Upload(CN_FTP_MV_FOLDER, heTextBox1.Value.ToString());
                LoadFTPFolder();
                //MsgBox.Show("업로드 성공");
                MsgCodeBox.Show("CD00-0015"); //정상적으로 업로드 되었습니다.
            }
            catch(Exception eLog)
            {
                //MsgBox.Show("업로드 실패 - " + eLog.Message);
                MsgCodeBox.Show("CD00-0007"); //업로드중 에러가 발생하였습니다.
            }
        }

        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            CopyFile();
        }
        
        private void Btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                        "CORCD", "BIZCD", "FILENAME");
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                if (set.Tables[0].Rows.Count >= 1)
                {
                    for (int row = 0; row < set.Tables[0].Rows.Count; row++)
                    {
                        m_ftpHandle.DeleteFTP(CN_FTP_MV_FOLDER + set.Tables[0].Rows[row]["FILENAME"].ToString());
                    }

                    this.BeforeInvokeServer(true);
                    //_WSCOM.REMOVE_FILE(bizcd, set);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_FILE"), set);
                    this.AfterInvokeServer();
                    LoadFTPFolder();
                    this.BtnQuery_Click(null, null);

                    //MsgBox.Show("선택하신 파일을 삭제하였습니다.");
                    MsgCodeBox.Show("CD00-0010");//정상적으로 삭제되었습니다.
                }
                else
                {
                    //MsgBox.Show("마우스 오른쪽버튼의 행삭제 이후 삭제를 진행하시기 바랍니다.");
                    MsgCodeBox.Show("CD00-0041");//삭제할 데이터가 존재하지 않습니다.
                }
            }
            catch (Exception eLog)
            {
                MsgBox.Show(eLog.Message);
            }
        }

        #endregion

        

        #region 유효성검사

        private bool ValidateCheck_Time(string time)
        {
            bool bRet = false;
            if (time.Length == 5)
            {
                if (time.LastIndexOf(':') == 2)
                {
                    string[] spTime = time.Split(':');
                    if (Convert.ToInt32(spTime[0]) <= 23)
                    {
                        if (Convert.ToInt32(spTime[1]) <= 59)
                        {
                            bRet = true;
                        }
                    }
                }
            }
            return bRet;
        }
        
        private bool ValidateCheck()
        {
            
            for (int row = 1; row < grd02.Rows.Count; row++)
            {
                if (!ValidateCheck_Time(grd02.Rows[row]["STIME"].ToString()))
                {
                    //MsgBox.Show(string.Format("잘못된 {0} 입력 - 라인번호 : {1}", grd02.Cols["STIME"].Caption, row));
                    MsgCodeBox.ShowFormat("CD00-0096", row, this.grd02.Cols["STIME"].Caption); //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다. @@@
                    return false;
                }
                if (!ValidateCheck_Time(grd02.Rows[row]["ETIME"].ToString()))
                {
                    //MsgBox.Show(string.Format("잘못된 {0} 입력 - 라인번호 : {1}", grd02.Cols["ETIME"].Caption, row));
                    MsgCodeBox.ShowFormat("CD00-0096", row, this.grd02.Cols["ETIME"].Caption); //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다. @@@
                    return false;
                }
                if(string.IsNullOrEmpty(grd02.Rows[row]["FILENAME"].ToString()))
                {
                    //MsgBox.Show(string.Format("잘못된 {0} 입력 - 라인번호 : {1}", grd02.Cols["FILENAME"].Caption, row));
                    MsgCodeBox.ShowFormat("CD00-0096", row, this.grd02.Cols["FILENAME"].Caption); //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다. @@@
                    return false;
                }
                if (string.IsNullOrEmpty(grd02.Rows[row]["PROCD"].ToString()))
                {
                    //MsgBox.Show(string.Format("잘못된 {0} 입력 - 라인번호 : {1}", grd02.Cols["PROCD"].Caption, row));
                    MsgCodeBox.ShowFormat("CD00-0096", row, this.grd02.Cols["PROCD"].Caption); //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다. @@@
                    return false;
                }
            }

            return true;
        }
        
        #endregion


        #region [ 사용자 정의 메서드 ]
        
        private void LoadFTPFolder()
        {
            string[] mvFiles = m_ftpHandle.GetFileList(CN_FTP_MV_FOLDER);
            
             
            string tag1 = "FILENAME";
            DataColumn col = new DataColumn(tag1, typeof(string));
            DataTable dt = new DataTable();
            dt.Columns.Add(col);
            col = new DataColumn("CORCD", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("BIZCD", typeof(string));
            dt.Columns.Add(col);
            DataRow dr = null;
            if (mvFiles != null)
            {
                for (int i = 0; i < mvFiles.Length; i++)
                {
                    dr = dt.NewRow();
                    dr[tag1] = mvFiles[i];
                    dr["CORCD"] = UserInfo.CorporationCode;
                    dr["BIZCD"] = cbo01_BIZCD.GetValue();
                    dt.Rows.Add(dr);
                }
            }

            grd01.SetValue(dt);

        }

        private void SetFtpInstance()
        {
            if (cbo01_BIZCD.GetValue().ToString() == "5220")
            {
                m_ftpHandle = new PDFTP(CN_FTP_INFOR_ASAN);
            }
            else
            {
                m_ftpHandle = new PDFTP(CN_FTP_INFOR_ULSAN);
            }
        }
        
        private void CopyFile()
        {
            C1.Win.C1FlexGrid.Row newRow = grd02.Rows.Add();
            newRow["CORCD"] = this.UserInfo.CorporationCode;
            newRow["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
            newRow["EMP_NO"] = this.UserInfo.UserID;
            newRow["FILENAME"] = grd01.SelectedDataRow["FILENAME"];
            newRow["PROCD"] = "M0DT";
            newRow["SDATE"] = DateTime.Now.ToShortDateString();
            newRow["EDATE"] = DateTime.Now.AddMonths(1).ToShortDateString();
            newRow["STIME"] = "00:00";
            newRow["ETIME"] = "23:59";
            newRow["PSEQ"] = grd02.Rows.Count - 1;
        }
        
        #endregion

    }
}
