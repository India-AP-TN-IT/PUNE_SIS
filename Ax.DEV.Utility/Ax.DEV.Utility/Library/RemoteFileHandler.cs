using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using System.Data;
using TheOne.Net;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// EPRemoteFileHandler
    /// </summary>
    public static class RemoteFileHandler
    {
        #region FileDownload
        /// <summary>
        /// FileDownload  원격서버로 부터 파일을 RemoteFileInfo 클래스로 반환한다.
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns>EPRemoteFileInfo</returns>
        public static RemoteFileInfo FileDownload(string fileID)
        {
            HttpFileManager manager = new HttpFileManager();
            RemoteFileInfo fileInfo = getFileMetaInfo(fileID);

            if (fileInfo != null)
            {

                // 로컬 폴더가 없을 경우 폴더를 생성한다.
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath));

                try
                {
                    manager.DownloadFile(fileInfo.DBPath, fileInfo.RemoteFileName, 0, fileInfo.LocalFilePath, fileInfo.DBFileSize, "");
                }
                catch
                {
                    return null;
                }

                // 실제로 파일이 복사되었을때 읽어오도록 한다.
                if (File.Exists(fileInfo.LocalFilePath))
                {

                    // 파일을 읽어서 Bytes Array 로 생성한다.
                    FileStream fs = new FileStream(fileInfo.LocalFilePath, FileMode.Open);

                    fileInfo.DBFileSize = (int)fs.Length;   // 실제 파일사이즈로 처리한다.
                    fileInfo.FileContent = new byte[fileInfo.DBFileSize];

                    fs.Read(fileInfo.FileContent, 0, fileInfo.DBFileSize);
                    fs.Close();

                    // Read 완료후 임시 로컬파일을 삭제한다.
                    File.Delete(fileInfo.LocalFilePath);
                }
                else
                {
                    throw new FileLoadException("ERROR : Not Fount File from Remote Server  or  Don't bring remote file!\r\n원격서버에 파일이 없거나 또는 가져오지 못하였습니다.");
                }
            }

            // 읽은 파일을 EPRemoteFileInfo 클래스로 반환한다.
            return fileInfo;
        }
        #endregion

        #region FileRemove
        /// <summary>
        /// FileRemove   서버로부터 해당 파일을 삭제하고 DB XD7000의 메타정보를 삭제한다.
        /// </summary>
        /// <param name="fileInfo"></param>
        public static void FileRemove(RemoteFileInfo fileInfo)
        {
            FileRemove(fileInfo.DBFileID);
        }

        /// <summary>
        /// FileRemove  서버로부터 해당 파일을 삭제하고 DB XD7000의 메타정보를 삭제한다.
        /// </summary>
        /// <param name="fileID"></param>
        public static void FileRemove(string fileID)
        {
            RemoteFileInfo fileInfo = getFileMetaInfo(fileID);

            if (fileInfo != null)
            {
                HttpFileManager manager = new HttpFileManager();

                //// 원격지 파일삭제 처리 수행
                //if (File.Exists(fileInfo.RemoteFilePath)) File.Delete(fileInfo.RemoteFilePath);
                manager.DeleteFile(fileInfo.DBPath, fileInfo.RemoteFileName, "");

                // XD7000 의 메타정보도 함께 삭제한다.
                removeFileMetaInfo(fileID);
            }
        }
        #endregion

        #region FileUpload
        /// <summary>
        /// 주어진 로컬path의 파일을 서버에 업로드하고 DB XD7000의 메타 정보를 등록한다.
        /// </summary>
        /// <param name="filefullpath">로컬에 존재하는 파일의 경로 및 파일명</param>
        /// <param name="saveFolder">서버의 폴더명</param>
        /// <param name="oldFileID">파일을 변경하고자 하는 경우의 구 FILEID(삭제처리됨)</param>
        /// <returns>신규로 저장된 FILEID</returns>
        public static string FileUpload(string filefullpath, string saveFolder, string oldFileID)
        {
            string newFileID = string.Empty;

            // 새로운 파일을 업로드할 경우에만 처리 한다.
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(filefullpath)))
            {
                FileStream stream = new FileStream(filefullpath, FileMode.Open, FileAccess.Read);

                // 파일정보를 생성한다.
                RemoteFileInfo fileInfo = new RemoteFileInfo();
                fileInfo.DBPath = "SIS/" + saveFolder;
                fileInfo.DBFileID = System.Guid.NewGuid().ToString().Replace("-", string.Empty);
                fileInfo.DBFileName = System.IO.Path.GetFileName(filefullpath);
                fileInfo.DBFileSize = (int)stream.Length;
                fileInfo.DBMenuID = saveFolder; // ERM 은 동일하게 처리  saveFolder 가 메뉴ID 와 동일

                //fileInfo.LocalFilePath = filefullpath;
                fileInfo.LocalFilePath = "C:/Temp/SIS/" + fileInfo.DBPath + "/" + fileInfo.DBFileID + fileInfo.DBFileName;
                fileInfo.RemoteFileName = fileInfo.DBFileID + fileInfo.DBFileName;

                fileInfo.FileContent = new byte[(int)stream.Length];

                stream.Read(fileInfo.FileContent, 0, fileInfo.FileContent.Length);
                stream.Close();
                stream.Dispose();

                // 신규파일 정상 업로드
                newFileID = FileUpload(fileInfo, oldFileID);

                // 구형파일이 있을경우 신규 파일 정상 처리후 구형 파일 삭제
                if (!string.IsNullOrEmpty(oldFileID)) FileRemove(oldFileID);
            }
            else
            {
                // 없으면 기존 파일 유지를 위해 oldFileID 그대로 반환
                newFileID = oldFileID;
            }

            // 신규 파일ID 를 반환
            return newFileID;
        }


        /// <summary>
        /// FileUpload 주어진 RemoteFileInfo클래스의 파일정보를 이용하여 서버에 업로드하고 DB XD7000의 메타 정보를 등록한다.
        /// 반두스 로컬에 존재하는 파일이어야 하고 LocalFilePath에 해당 파일의 로컬 경로가 있어야 함.
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="oldFileID">파일을 변경하고자 하는 경우의 구 FILEID(삭제처리됨)</param>
        /// <returns>신규로 저장된 FILEID</returns>
        private static string FileUpload(RemoteFileInfo fileInfo, string oldFileID)
        {
            string newFileID = string.Empty;
            HttpFileManager manager = new HttpFileManager();

            if (fileInfo.FileContent.Length > 0)
            {
                try
                {
                    // 로컬 폴더가 없을 경우 폴더를 생성한다.
                    if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath)))
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath));

                    // 이미지 파일이면 축소후 저장하고 이미지 파일이 아니면 원본을 그대로 저장한다.
                    if (!ImageCollapse.Process(fileInfo.FileContent, fileInfo.LocalFilePath)) fileInfo.Save();

                    // 로컬파일을 서버로 업로드 한다.
                    manager.UploadFile(fileInfo.DBPath, fileInfo.RemoteFileName, fileInfo.LocalFilePath, 0, "");

                    // 정상완료되면 WCF 를 통하여 DB 의 XD7000 에 메타정보를 저장한다.
                    setFileMetaInfo(fileInfo);

                    newFileID = fileInfo.DBFileID;

                    // oldFileID가 있을경우 신규 파일 정상 처리후 구형 파일 삭제
                    if (!string.IsNullOrEmpty(oldFileID)) FileRemove(oldFileID);

                    // 로걸 임시경로의 파일을 삭제
                    if (File.Exists(fileInfo.LocalFilePath)) File.Delete(fileInfo.LocalFilePath);
                }
                catch (Exception ex)
                {
                    // 오류 발생시 로컬 파일이 있을경우 로컬 파일을 먼저 삭제처리 후 Exception 을 상위로 던진다.
                    if (File.Exists(fileInfo.LocalFilePath)) File.Delete(fileInfo.LocalFilePath);
                    throw ex;
                }
            }
            else
            {
                // FileInfo 에 Contents 가 없을경우 기존 파일 유지를 위해 oldFileID 반환
                newFileID = oldFileID;
            }

            // 정상 저장시 fileID 를 반환한다.
            return newFileID;
        }
        #endregion

        #region Internal Code

        /// <summary>
        /// setFileMetaInfo   DB XD7000 에 파일메타 정보를 저장한다.
        /// </summary>
        /// <param name="fileInfo"></param>
        private static void setFileMetaInfo(RemoteFileInfo fileInfo)
        {
            HEParameterSet param = new HEParameterSet();

            param.Add("FILEID", fileInfo.DBFileID);
            param.Add("FILENAME", fileInfo.DBFileName);
            param.Add("PATH", fileInfo.DBPath);
            param.Add("FILE_SIZE", fileInfo.DBFileSize);
            param.Add("MENUID", fileInfo.DBMenuID);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                proxy.ExecuteNonQueryTx("APG_FILESERVICE.SET_FILE_METAINFO", param);
            }
        }


        /// <summary>
        /// getFileMetaInfo   DB XD7000의 메타정보를 가져온다.
        /// </summary>
        /// <param name="fileID"></param>
        private static RemoteFileInfo getFileMetaInfo(string fileID)
        {
            RemoteFileInfo fileInfo = null;

            HEParameterSet param = new HEParameterSet();
            param.Add("FILEID", fileID);
            DataSet ds = new DataSet();
            using (AxClientProxy proxy = new AxClientProxy())
            {
                ds = proxy.ExecuteDataSet("APG_FILESERVICE.GET_FILE_METAINFO", param);
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // 파일정보를 생성한다.
                fileInfo = new RemoteFileInfo();

                fileInfo.DBPath = ds.Tables[0].Rows[0]["PATH"].ToString();
                fileInfo.DBFileID = ds.Tables[0].Rows[0]["FILEID"].ToString();
                fileInfo.DBFileName = ds.Tables[0].Rows[0]["FILENAME"].ToString();
                fileInfo.DBFileSize = int.Parse(ds.Tables[0].Rows[0]["FILE_SIZE"].ToString());
                fileInfo.DBMenuID = ds.Tables[0].Rows[0]["MENUID"].ToString();

                fileInfo.LocalFilePath = "C:/Temp/SIS/" + fileInfo.DBPath + "/" + System.Guid.NewGuid().ToString().Replace("-", string.Empty) /*fileInfo.DBFileID(*/ + fileInfo.DBFileName;
                fileInfo.RemoteFileName = fileInfo.DBFileID + fileInfo.DBFileName;
            }

            return fileInfo;
        }


        /// <summary>
        /// removeFileMetaInfo   DB XD7000의 메타정보를 삭제한다..
        /// </summary>
        /// <param name="fileID"></param>
        private static void removeFileMetaInfo(string fileID)
        {
            HEParameterSet param = new HEParameterSet();
            param.Add("FILEID", fileID);

            // XD7000 DB 의 메타 정보를 제거한다.
            using (AxClientProxy proxy = new AxClientProxy())
            {
                proxy.ExecuteNonQueryTx("APG_FILESERVICE.REMOVE_FILE_METAINFO", param);
            }
        }
        #endregion
    }
}
