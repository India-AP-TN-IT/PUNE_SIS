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


namespace Ax.SIS.PD.UI
{
    
    /// <summary>
    /// 임시적인 Class이며 FTP사용을 위함
    /// MES관리자모듈에서 동영상 관리자가 서버에 업로드 용이하게
    /// </summary>    
    public partial class PDFTP : AxCommonBaseControl
    {

        string m_ftpServerIP = null;
        string m_ftpUserID = null;
        string m_ftpPassword = null;
        string m_ftpPort = null;
        bool m_usePassive = false;



        public PDFTP(string ftpInfor)
        {
            try
            {
                string[] spInfor = ftpInfor.Split(';');

                m_ftpServerIP = spInfor[0];   //FTP 서버주소
                m_ftpUserID = spInfor[1];     //아이디
                m_ftpPassword = spInfor[2];  //패스워드
                m_ftpPort = spInfor[3];        //포트
                m_usePassive = true;   //패시브모드 사용여부
            }
            catch
            {
                throw new Exception("잘못된 인자전달입니다. - IP;ID;PWD;PORT를 확인하세요");
            }
        }

        //파일 업로드
        public Boolean Upload(string folder, string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + m_ftpServerIP + ":" + m_ftpPort + "/" + folder + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;
            reqFTP.UsePassive = m_usePassive;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();

                return true;
            }

            catch
            {

                MessageBox.Show("FTP 전송중 문제가 발생하였습니다.네트워크 상황 또는 접속정보를 살펴 보시기 바랍니다.");
                return false;
            }
            //catch (Exception ex){MessageBox.Show(ex.Message, "Upload Error");}

        }

        //파일 삭제         
        public void DeleteFTP(string fileName)
        {
            try
            {
                string uri = "ftp://" + m_ftpServerIP + "/" + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + fileName));

                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch { return; }
        }


        public bool GetFilesInfo(string filename, ref DateTime dt)
        {
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + filename));
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = m_usePassive;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                dt = response.LastModified;

                response.Close();
                return true;

            }
            catch { return false; }
            //catch (Exception ex){System.Windows.Forms.MessageBox.Show(ex.Message);return false;}
        }

        public System.Collections.Generic.List<string> GetFilesDetailList(string subFolder)
        {
            List<string> files = new List<string>();
            string line = null;


            try
            {
                //StringBuilder result = new StringBuilder();

                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + subFolder));
                ftp.UseBinary = true;
                ftp.UsePassive = m_usePassive;
                ftp.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);



                while ((line = reader.ReadLine()) != null)
                {
                    files.Add(line);
                }

                reader.Close();
                response.Close();
                return files;
                //MessageBox.Show(result.ToString().Split('\n'));
            }
            catch { return files; }
            //catch (Exception ex){System.Windows.Forms.MessageBox.Show(ex.Message);return files;}
        }

        public string[] GetFileList(string subFolder)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + subFolder));
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = m_usePassive;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                //MessageBox.Show(reader.ReadToEnd());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                //MessageBox.Show(response.StatusDescription);
                return result.ToString().Split('\n');
            }
            catch
            {
                downloadFiles = null;
                return downloadFiles;
            }
            
        }

        public bool checkDir(string localFullPathFile)
        {
            FileInfo fInfo = new FileInfo(localFullPathFile);

            if (!fInfo.Exists)
            {
                DirectoryInfo dInfo = new DirectoryInfo(fInfo.DirectoryName);
                if (!dInfo.Exists)
                {
                    dInfo.Create();
                }
            }

            return true;

        }
        public bool Download(string localFullPathFile, string serverFullPathFile)
        {
            FtpWebRequest reqFTP;
            try
            {
                
                checkDir(localFullPathFile);
                FileStream outputStream = new FileStream(localFullPathFile, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + serverFullPathFile));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = m_usePassive;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;

              

                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    

                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return true;
            }
            catch { return false; }
            
        }

        private long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = m_usePassive;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();

                return fileSize;
            }

            catch { return fileSize; }
        }

        public void Rename(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = m_usePassive;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }

            catch { }
        }

        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + m_ftpServerIP + "/" + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = m_usePassive;
                reqFTP.Credentials = new NetworkCredential(m_ftpUserID, m_ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch { }
            
        }


    }




}
