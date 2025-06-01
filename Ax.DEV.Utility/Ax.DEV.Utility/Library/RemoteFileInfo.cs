using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// RemoteFileInfo
    /// </summary>
    public class RemoteFileInfo
    {
        /// <summary>
        /// xd7000.fileid
        /// </summary>
        public string DBFileID = string.Empty;                // DBFileID
        /// <summary>
        /// xd7000.filename
        /// </summary>
        public string DBFileName = string.Empty;              // DBFileName
        /// <summary>
        /// xd7000.path
        /// </summary>
        public string DBPath = string.Empty;                  // DBPath
        /// <summary>
        /// 파일 사이즈 
        /// </summary>
        public int DBFileSize = 0;                         // DBFileSize
        /// <summary>
        /// xd7000.menuid
        /// </summary>
        public string DBMenuID = string.Empty;                // DBMenuID
        /// <summary>
        /// 업로드 전 파일의 client pc 내의 경로 및 파일명(full path)
        /// </summary>
        public string LocalFilePath = string.Empty;           // LocalFilePath
        /// <summary>
        /// 서버에 저장된 물리적인 파일명(fileid + filename)
        /// </summary>
        public string RemoteFileName = string.Empty;          // RemoteFileName
        /// <summary>
        /// 파일 byte[] 데이터
        /// </summary>
        public byte[] FileContent = null;                     // FileContent

        /// <summary>
        /// Save 로컬경로에 파일을 저장한다.
        /// </summary>
        public void Save()
        {
            SaveAs(this.LocalFilePath);
        }

        /// <summary>
        /// SaveAs 로컬경로에 파일을 저장한다.
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(string fileFullPath)
        {
            if (this.DBFileSize > 0)
            {
                // 로컬 폴더가 없을 경우 폴더를 생성한다.
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(fileFullPath)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileFullPath));

                FileStream fs = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write);

                this.DBFileSize = this.FileContent.Length;

                fs.Write(this.FileContent, 0, this.DBFileSize);
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
