#region ▶ Description & History
/* 
 * 프로그램명 : PD50061 알림글-동영상
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
using System.IO;
using System.Net;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 동영상업로드 화면
    /// </summary>
    public partial class PD50061 : AxCommonBaseControl
    {
       
        //private IPD50061 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD50061";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        string FTP_ID = "";
        string FTP_PASS = "";
        string FTP_SERVER = "";

        #region [ 초기화 작업 정의 ]

        public PD50061()
        {
           
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD50061>("PD", "PD50061.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //동영상 업로드 FTP 서버 정보 
            //일단은 서버정보도 소스에 박아둠. 
            //추후 협의하여 공통 클래스로 빼던지 환경설정 테이블에 넣던지 한다고 함.
            FTP_ID = "hanil";
            FTP_PASS = "hanil";
            FTP_SERVER = "ftp://10.10.22.61/";
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.txt01_MOVIE_NAME.SetReadOnly(true);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {

                this.BtnQuery_Click(null, null);
                txt01_MOVIE_NAME.SetValue("");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                //동영상 찾아보기 텍스트 상자 초기화 함.
                txt01_MOVIE_NAME.SetValue("");  

                if (source.Tables[0].Rows.Count > 0)
                {
                    //최신의 등록한 동영상 정보가 있는 경우 화면에 최신동영상 정보 표기한다.
                    DataRow row = source.Tables[0].Rows[0];
                    lbl02_MOVIE_NAME.SetValue(row["MOVIE_NAME"].ToString());
                    lbl02_MOVIE_DATE.SetValue(row["MOVIE_DATE"].ToString());
                    chk01_PLAY_CHK.Checked = row["MOVIE_CHK"].ToString() == "Y" ? true : false;
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string MOVIE_NAME = "";
                string MOVIE_CHK = "";
                string bizcd = this.UserInfo.BusinessCode;
                string UPLOAD_GBN = "";

                //파일사이즈 체크
                if (!IsValidFileSize()) return;

                
                if (this.GetByteCount(txt01_MOVIE_NAME.GetValue().ToString()) > 0)
                {
                    //선택한 파일이 있는 경우에만 업로드함.
                    this.BeforeInvokeServer(true);
                    MOVIE_NAME = Upload(txt01_MOVIE_NAME.GetValue().ToString());
                    this.AfterInvokeServer();
                    UPLOAD_GBN = "Y";
                    MOVIE_CHK = "Y";
                }
                else
                {
                    //선택한 파일이 없는 경우에는 기존의 DB데이터 업데이트
                    MOVIE_NAME = lbl02_MOVIE_NAME.GetValue().ToString();
                    UPLOAD_GBN = "N";
                    MOVIE_CHK = chk01_PLAY_CHK.Checked ? "Y" : "N";
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("MOVIE_NAME", MOVIE_NAME);
                set.Add("MOVIE_CHK", MOVIE_CHK);
                set.Add("UPLOAD_GBN", UPLOAD_GBN);

                //동영상 파일명이 있는 경우에만 DB에 저장한다.(수정이든 등록이든 파일명이 있음. 업로드중에 오류발생시 파일명이 없음.)
                if (!MOVIE_NAME.Equals(""))
                {
                    this.BeforeInvokeServer(true);
                    //_WSCOM.SAVE(this.UserInfo.BusinessCode, set);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), set);

                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                    //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                    this.AfterInvokeServer();

                    if (UPLOAD_GBN.Equals("Y"))
                    {
                        //동영상 업로드시
                        //동영상 업로드가 완료되었습니다.
                        MsgCodeBox.Show("PD00-0030");
                    }
                    else
                    {
                        //재생 여부만 변경시
                        //MsgBox.Show("동영상 정보가 저장되었습니다.");
                        //저장되었습니다.
                        MsgCodeBox.Show("CD00-0071");
                    }
                }
              

                //화면 초기화 하고, 재조회한다.
                BtnReset_Click(null, null);
               
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

        #region [ 기타 컨트롤 이벤트 ]

        private void btn01_FILE_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Movie File|*.avi;*.wmv";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt01_MOVIE_NAME.SetValue(openFileDialog1.FileName);
                //
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid()
        {
            try
            {
                
             

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        
        #endregion

        #region [FTP 업로드]
        //FTP 업로드
        private string Upload(string file)
        {
            string toFileName = "";
            FileInfo fileInf = new FileInfo(file);
            toFileName = get_DestFildName(fileInf.Name);
            string uri = FTP_SERVER + toFileName;
            FtpWebRequest reqFTP;

            UriBuilder URI = new UriBuilder(uri);
            URI.Scheme = "ftp";

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(URI.Uri);
            reqFTP.Credentials = new NetworkCredential(FTP_ID, FTP_PASS);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            reqFTP.UsePassive = true;

            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            FileStream fs = fileInf.OpenRead();

            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();

                return toFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
                return "";
            }
        }

        //파일 사이즈 체크
        private bool IsValidFileSize()
        {
            string filename = txt01_MOVIE_NAME.GetValue().ToString();

            if (this.GetByteCount(filename) > 0)
            {
                //동영상 찾아보기 클릭하여 파일을 선택한 경우에만 파일 사이즈 체크한다.
                FileInfo fileInf = new FileInfo(filename);
                if (fileInf.Length > 10485760) //10M바이트 초과인 경우
                {
                    //MsgBox.Show("파일 사이즈를 초과하였습니다. 동영상 파일은 10M 이하만 가능합니다.");
                    MsgCodeBox.Show("PD00-0031");                    
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                //선택된 파일이 없는 경우에는 업로드 없이 db업데이트만 함.
                return true;
            }
        }

        //서버에 올릴 파일명 찾아오기.
        private string get_DestFildName(string file)    //ex: file = "test.txt";
        {
            
            string extention = Path.GetExtension(file);
            string fileName = file.Remove(file.Length - extention.Length); //파일명에서 확장자 부분 제외

            string fileNameCopy = fileName;
            int attempt = 1;

            //해당 파일명으로 서버에 있는지 확인한다. 있으면 파일명에 "(1)", "(2)"등 숫자 넣어서 중복되지 않는 파일명 만든다.
            while (CheckFileExists(GetRequest(FTP_SERVER + fileNameCopy + extention, FTP_ID, FTP_PASS)))
            {
                fileNameCopy = fileName + "(" + attempt.ToString() + ")";
                attempt++;
            }

            return fileNameCopy + extention;
            
        }

        //FTP 서버 요청 클라이언트
        private static FtpWebRequest GetRequest(string uriString, string userId, string userPass)
        {
            var request = (FtpWebRequest)WebRequest.Create(uriString);
            request.Credentials = new NetworkCredential(userId, userPass);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            return request;
        }

        //파일 존재 여부는 TRY구문 이용하여 서버응답을 요청한다. 오류발생시 파일이 없음으로 판단.
        private static bool CheckFileExists(FtpWebRequest request)
        {
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion
       
    }
}
