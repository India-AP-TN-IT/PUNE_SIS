using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HE.Framework.Core;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;
using TheOne.Net;
using HE.Framework.ServiceModel;

namespace Ax.DEV.Utility.Library
{
    public class PDFHelper
    {
        HttpFileManager _manager;
        private AxClientProxy _WSCOM;
        private bool _iswatermark = true;

        public PDFHelper(bool iswatermark)
        {
            _WSCOM = new AxClientProxy();
            _manager = new HttpFileManager();
            _iswatermark = iswatermark;

        }

        //\\hscm.seoyoneh.com\e$\DataFile\ERM\
        //administrator/!work@

        /// <summary>
        /// blob 데이터를 client pc 임시폴더에 파일로 저장한 후 암호화 및 워터마크 적용한다.
        /// (blob용 파일인 경우 적용)
        /// </summary>
        /// <param name="blob">blob 데이터</param>
        /// <param name="fileName">로컬에 저장될 파일명(PATH불포함)</param>
        /// <returns>저장된 파일명(path포함)</returns>
        public string LoadPDF(byte[] blob, string fileName)
        {
            try
            {

                string LocalFileName = String.Format("{0}{1}", "C:/Temp/Ax.SIS/", fileName);

                // 로컬 폴더가 없을 경우 폴더를 생성한다.
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(LocalFileName)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(LocalFileName));

                string path = System.IO.Path.GetDirectoryName(LocalFileName);
                string tempFileName = String.Format(@"{0}\temp_{1}", path, fileName);

                FileStream file = new FileStream(tempFileName, FileMode.Create, FileAccess.Write);
                file.Write(blob, 0, blob.Length);
                file.Close();
                file.Dispose();

                //File.Move(fullpath, tempFileName);

                // 워터마크 삽입코드
                if (_iswatermark) PdfAddWaterMark(tempFileName);

                // PDF 파일 암호처리
                if (System.IO.File.Exists(tempFileName))
                {
                    this.PDFEncrypt(tempFileName, LocalFileName);
                    System.IO.File.Delete(tempFileName);

                }
                return LocalFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }


        /// <summary>
        /// blob 데이터를 client pc 특정폴더에 파일로 저장한 후 암호화 및 워터마크 적용한다.
        /// (blob용 파일인 경우 적용)
        /// </summary>
        /// <param name="blob">blob 데이터</param>
        /// <param name="path">로컬에 저장될 파일의 경로 </param>
        /// <param name="fileName">로컬에 저장될 파일명(PATH불포함)</param>
        /// <returns>저장된 파일명(path포함)</returns>
        public string LoadPDF(byte[] blob, string path, string fileName)
        {

            try
            {
                string LocalFileName = String.Format(@"{0}\{1}", path, fileName);
                string tempFileName = String.Format(@"{0}\temp_{1}", path, fileName);

                FileStream file = new FileStream(tempFileName, FileMode.Create, FileAccess.Write);
                file.Write(blob, 0, blob.Length);
                file.Close();
                file.Dispose();


                // 워터마크 삽입코드
                if (_iswatermark) PdfAddWaterMark(tempFileName);

                // PDF 파일 암호처리
                if (System.IO.File.Exists(tempFileName))
                {
                    this.PDFEncrypt(tempFileName, LocalFileName);
                    System.IO.File.Delete(tempFileName);

                }

                return LocalFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }

        /// <summary>
        /// fileId에 해당하는 pdf 파일을 서버로부터 다운로드한다. (임시폴더에)
        /// </summary>
        /// <param name="fileId">XD7000.FILEID(파일ID)</param>
        /// <returns>다운로드된 파일명(path포함)</returns>
        public string LoadPDF(string fileId)
        {
            return LoadPDF(fileId, "");
        }

        /// <summary>
        /// fileId에 해당하는 pdf파일을 LocalFileName이라는 이름으로 client pc에 다운로드 한다.
        /// (xd7000 정보를 모르는 경우)
        /// </summary>
        /// <param name="fileId">XD7000.FILEID(파일ID)</param>
        /// <param name="localFileName"> Path포함한 사용자 지정 파일명</param>
        /// <returns>다운로드된 파일명(path포함)</returns>
        public string LoadPDF(string fileId, string localFileName)
        {

            if (!String.IsNullOrEmpty(fileId))
            {
                try
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("FILEID", fileId);
                    //this.BeforeInvokeServer(true);
                    DataSet ds = _WSCOM.ExecuteDataSet("APG_FILESERVICE.GET_FILE_METAINFO", paramSet);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string FileName = ds.Tables[0].Rows[0]["FILENAME"].ToString();
                        string FilePath = ds.Tables[0].Rows[0]["PATH"].ToString();

                        if (localFileName.Equals(string.Empty))
                            localFileName = String.Format("{0}{1}", "C:/Temp/Ax.SIS/", FileName); ;

                        // 로컬 폴더가 없을 경우 폴더를 생성한다.
                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(localFileName)))
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(localFileName));

                        return LoadPDF(fileId, FileName, FilePath, localFileName);

                    }
                    else
                    {
                        MessageBox.Show("There is no file infomation.");
                        return "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
                finally
                {
                }
            }
            else
            {
                MessageBox.Show("Invalid value. File id missing or empty.");
                return "";
            }

        }

        /// <summary>
        /// 파일아이디, 파일명, 업로드경로, 서버의파일명등 파일에 대한 xd7000 데이터를 이미 알고 있는 경우
        /// clienc pc 디폴트 위치(C:\Users\사용자계정\AppData\Local\Temp) 다운로드한다.
        /// </summary>
        /// <param name="fileId">XD7000.FILEID(파일ID)</param>
        /// <param name="fileName">XD7000.FILENAME(파일명)</param>
        /// <param name="filePath">XD7000.PATH(파일저장경로)</param>
        /// <returns>다운로드된 파일명(path포함)</returns>
        private string LoadPDF(string fileId, string fileName, string filePath)
        {
            string LocalFileName = String.Format("{0}{1}", System.IO.Path.GetTempPath(), fileName);
            return LoadPDF(fileId, fileName, filePath, LocalFileName);

        }

        /// <summary>
        /// 파일아이디, 파일명, 업로드경로, 서버의파일명등 파일에 대한 xd7000 데이터를 이미 알고 있는 경우
        /// LocalFileName이라는 이름으로 다운로드한다.
        /// </summary>
        /// <param name="fileId">XD7000.FILEID(파일ID)</param>
        /// <param name="fileName">XD7000.FILENAME(파일명)</param>
        /// <param name="filePath">XD7000.PATH(파일저장경로)</param>
        /// <param name="localFileName">Path포함한 사용자 지정 파일명</param>
        /// <returns>다운로드된 파일명(path포함)</returns>
        private string LoadPDF(string fileId, string fileName, string filePath, string localFileName)
        {
            try
            {
                if (!String.IsNullOrEmpty(fileId))
                {
                    if (System.IO.Path.GetExtension(fileName).ToUpper().Equals(".PDF"))
                    {
                        string ServerFileName = fileId + fileName;
                        string tempFileName = String.Format("{0}temp{1}{2}", "C:/Temp/Ax.SIS/", fileId, fileName);

                        // 로컬 폴더가 없을 경우 폴더를 생성한다.
                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(tempFileName)))
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(tempFileName));

                        //파일 다운로드
                        _manager.DownloadFile(filePath, ServerFileName, 0, tempFileName, 0, "");


                        // 워터마크 삽입코드
                        if (_iswatermark) PdfAddWaterMark(tempFileName);


                        // PDF 파일 암호처리
                        if (System.IO.File.Exists(tempFileName))
                        {
                            this.PDFEncrypt(tempFileName, localFileName);
                            System.IO.File.Delete(tempFileName);

                        }
                        return localFileName;
                    }
                    else
                    {
                        MessageBox.Show("This is not a pdf file type ");
                        return "";
                    }
                }
                else
                {
                    MessageBox.Show("Invalid value. File id missing or empty.");
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }

        /// <summary>
        /// 파일 암호화 처리
        /// </summary>
        /// <param name="fileFullPath"></param>
        /// <param name="srcFileName"></param>
        private void PDFEncrypt(string fileFullPath, string srcFileName)
        {
            using (MemoryStream output = new MemoryStream())
            {
                PdfReader reader = new PdfReader(fileFullPath);

                PdfEncryptor.Encrypt(reader, output, true, null, "!work@", PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_SCREENREADERS);

                reader.Close();
                reader.Dispose();

                byte[] bytes = output.ToArray();

                FileStream file = new FileStream(srcFileName, FileMode.Create, FileAccess.Write);

                file.Write(bytes, 0, bytes.Length);

                file.Close();
                output.Close();

                file.Dispose();
                output.Dispose();
            }
        }

        /// <summary>
        /// 워터마크 처리
        /// </summary>
        /// <param name="fileFullPath"></param>
        private static void PdfAddWaterMark(String fileFullPath)
        {
            string tmpFile = fileFullPath + "_" + DateTime.Now.Ticks.ToString();

            PdfReader pdfReader = null;
            Stream outputStream = null;
            PdfStamper pdfStamper = null;

            try
            {
                File.Move(fileFullPath, tmpFile);

                pdfReader = new PdfReader(tmpFile);
                outputStream = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write, FileShare.None);

                pdfStamper = new PdfStamper(pdfReader, outputStream, '1', true);


                string fontPath = Path.Combine(Directory.GetParent(Environment.GetFolderPath(System.Environment.SpecialFolder.System)).FullName, "Fonts"); //framework 3.5
                //string fontPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts); //framework 4.0
                //string userInfo = EPUserInfoContext.Current.DeptName + " " + EPUserInfoContext.Current.UserName;  // SCM
                string userInfo = StaticUserInfoContext.DeptName + " " + StaticUserInfoContext.UserName;  // ERM
                string timeInfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                for (int pageIndex = 1; pageIndex <= pdfReader.NumberOfPages; pageIndex++)
                {
                    PdfContentByte pdfData = pdfStamper.GetOverContent(pageIndex);
                    pdfData.SaveState();

                    pdfData.SetGState(new PdfGState { FillOpacity = 0.6f, StrokeOpacity = 0.6f });
                    pdfData.SetColorFill(new BaseColor(Color.DarkGray));
                    pdfData.BeginText();

                    float offSet = 60;
                    float availWidth = pdfData.PdfDocument.PageSize.Width;//(pdfData.PdfDocument.PageSize.Width - (offSet*2));
                    float availHeight = pdfData.PdfDocument.PageSize.Height - (offSet * 2);

                    //// #### 워터마크 4개짜리 여기부터
                    //float x = availWidth / 6;
                    //float y = availHeight / 4;
                    //float markFontSize = (18f) * 96f / 72f;

                    //pdfData.SetFontAndSize(BaseFont.CreateFont(fontPath + "\\malgunbd.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), markFontSize);

                    //// Line 1
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 1 + 30, y * 4 + markFontSize - 30, 40);
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 1 + 30 + (markFontSize * 0.9f), y * 4 - 30, 40);

                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, (x * 5) - offSet, y * 3 + markFontSize - 30, 40);
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, (x * 5) - offSet + (markFontSize * 0.9f), y * 3 - 30, 40);

                    //// Line 3
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 1 + 30, y * 2 + markFontSize - 30, 40);
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 1 + 30 + (markFontSize * 0.9f), y * 2 - 30, 40);
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, (x * 7) - offSet, y * 2 + markFontSize - 30, 40);
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, (x * 7) - offSet + (markFontSize * 0.9f), y * 2 - 30, 40);

                    //// Line 4
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 3, y * 1 + markFontSize - 30, 40);
                    //pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 3 + (markFontSize * 0.9f), y * 1 - 30, 40);

                    //// #### 워터마크 4개짜리 여기까지

                    // #### 워터마크 8개 짜리 여기부터
                    float x = availWidth / 6;
                    float y = availHeight / 5;
                    float markFontSize = (14f) * 96f / 72f;

                    pdfData.SetFontAndSize(BaseFont.CreateFont(fontPath + "\\malgunbd.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), markFontSize);

                    // Line 0
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x, y * 5 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x + (markFontSize * 0.9f), y * 5, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 5, y * 5 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 5 + (markFontSize * 0.9f), y * 5, 45);

                    // Line 1
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 3, y * 4 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 3 + (markFontSize * 0.9f), y * 4, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 7, y * 4 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 7 + (markFontSize * 0.9f), y * 4, 45);

                    // Line 2
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x, y * 3 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x + (markFontSize * 0.9f), y * 3, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 5, y * 3 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 5 + (markFontSize * 0.9f), y * 3, 45);

                    // Line 3
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 3, y * 2 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 3 + (markFontSize * 0.9f), y * 2, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 7, y * 2 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 7 + (markFontSize * 0.9f), y * 2, 45);

                    // Line 4
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x, y * 1 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x + (markFontSize * 0.9f), y * 1, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, userInfo, x * 5, y * 1 + markFontSize, 45);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, timeInfo, x * 5 + (markFontSize * 0.9f), y * 1, 45);
                    // #### 워터마크 8개 짜리 여기까지


                    pdfData.EndText();
                    pdfData.Stroke();

                    // 하단 좌측 경고 문구 처리
                    pdfData.SetGState(new PdfGState { FillOpacity = 1f, StrokeOpacity = 1f });
                    pdfData.SetColorFill(new BaseColor(Color.Red));
                    pdfData.BeginText();

                    float bottomFontSize = (5f) * 96f / 72f;
                    float height = pdfData.PdfDocument.PageSize.Height;

                    pdfData.SetFontAndSize(BaseFont.CreateFont(fontPath + "\\malgunbd.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), bottomFontSize);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "※ (주)서연이화에서 제공한 스펙에 대하여 (주)서연이화 동의 없이 재 배포 할 수 없으며,", 30, ((bottomFontSize * 4f) + (bottomFontSize * 0.2f)), 0);
                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "　 무단 배포 시 민형사상의 책임 등 의 불이익이 발생 할 수 있음.", 30, (bottomFontSize * 3), 0);

                    pdfData.EndText();
                    pdfData.Stroke();

                    // 하단 우측 회사표시 처리
                    pdfData.SetColorFill(new BaseColor(Color.Black));
                    pdfData.BeginText();

                    pdfData.ShowTextAligned(iTextSharp.text.Element.ALIGN_RIGHT, "[ 주 식 회 사 서 연 이 화 ]", pdfData.PdfDocument.PageSize.Width - 30, (bottomFontSize * 3), 0);

                    pdfData.EndText();
                    pdfData.Stroke();

                    // 이미지 처리 여기부터
                    //iTextSharp.text.Rectangle pageRectangle = pdfReader.GetPageSizeWithRotation(pageIndex);
                    //FileStream fileStreamImage = new FileStream("d:\\test.gif", FileMode.Open, FileAccess.Read, FileShare.Read);
                    //iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fileStreamImage), System.Drawing.Imaging.ImageFormat.Png);

                    //float width = pageRectangle.Width;
                    //float height = pageRectangle.Height;

                    //jpeg.SetAbsolutePosition(width / 2 - jpeg.Width / 2, height / 2 - jpeg.Height / 2);
                    //jpeg.Rotation = 0;

                    //pdfData.AddImage(jpeg);
                    // 이미지 처리 여기까지
                    pdfData.RestoreState();
                }
                pdfStamper.Close();
                pdfStamper.Dispose();
                outputStream.Close();
                outputStream.Dispose();

                pdfReader.Close();
                pdfReader.Dispose();

                if (File.Exists(tmpFile)) File.Delete(tmpFile);
            }
            catch (Exception ex)
            {
                if (pdfStamper != null) { pdfStamper.Close(); pdfStamper.Dispose(); }
                if (outputStream != null) { outputStream.Close(); outputStream.Dispose(); }
                if (pdfReader != null) { pdfReader.Close(); pdfReader.Dispose(); }

                if (File.Exists(fileFullPath)) File.Delete(fileFullPath);
                if (File.Exists(tmpFile)) File.Delete(tmpFile);

                throw ex;
            }
            finally
            {
            }
        }
    }
}
