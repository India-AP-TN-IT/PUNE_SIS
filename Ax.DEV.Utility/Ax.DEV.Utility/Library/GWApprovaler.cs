/*
 * GWApprovaler.cs
 *	: 하드 코드된 대칭키를 제공하는 디폴트 키 프로바이더 클래스
 * 
 * Copyright (C) 서연이화 주식회사 1980-2015. All right reserved.
 * 
 * Written by GeonWoo
 * 
 * 이 코드는 (주)서연이화의 자산입니다. 무단으로 이 코드의 전체 혹은
 * 일부를 복제, 수정하거나 공개하는 것은 저작권 위반입니다.
 *
 * 이 코드는 (주)서연이화 제품의 일부로서 사용될 때만이 유효하며
 * 그 외의 사용은 금지되어 있습니다.
 * 
 */
using System;
using System.Text;
using System.Windows.Forms;
using System.Data;
using HE.Framework.Core;
using Newtonsoft.Json;
using System.IO;
using HE.Framework.ServiceModel;
using System.Diagnostics;
using TheOne.Net;


namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 서연이화 물류 시스템에서 사용하는 전자결재자입니다.
    /// </summary>
    public class GWApprovaler
    {
        private bool _IsLauncher;
        private string _ERPID;
        private string _WorkKind;
        private string _CompanyID;
        private string _Subject;
        private string _EMPNO;
        private bool _IsAppCompleteMode;
        //private TextBox _URL;

        private HEParameterSet _fileList;
        private AxClientProxy _WSCOM;

        /// <summary>
        /// 결재창이 나타나기 전에 발생하는 이벤트에 대한 대리자입니다.
        /// </summary>
        /// <param name="ERPID"></param>
        /// <param name="procedure"></param>
        /// <param name="parameters"></param>
        /// <param name="instance"></param>
        public delegate void BeforeCall(string ERPID, string procedure, HEParameterSet parameters, DataSet instance);

        /// <summary>
        /// 결재창이 나타나기 전에 발생하는 이벤트 핸들러입니다.
        /// </summary>
        public event BeforeCall BeforeCalling;

        /// <summary>
        /// 결재창이 나타나기 전에 발생하는 이벤트입니다.
        /// </summary>
        /// <param name="ERPID"></param>
        /// <param name="procedure"></param>
        /// <param name="parameters"></param>
        /// <param name="instance"></param>
        public void OnBeforeCalling(string ERPID, string procedure, HEParameterSet parameters, DataSet instance)
        {
            if (this.BeforeCalling != null)
                this.BeforeCalling(ERPID, procedure, parameters, instance);
            else
                throw new Exception("GWApprovaler Instance에 'OnBeforeCalling' 이벤트가 정의되지 않았습니다.");
        }

        /// <summary>
        /// 결재자가 생성한 프로세스 인스턴스 OID를 가져옵니다.
        /// </summary>
        public string ERPID
        {
            set { this._ERPID = value; }
            get { return this._ERPID; }
        }

        /// <summary>
        /// 생성자입니다.
        /// </summary>
        /// <param name="workkind"></param>
        /// <param name="subject"></param>
        public GWApprovaler(string workkind, string subject)
        {
            this.Initialize(workkind, subject, false, false);
        }

        /// <summary>
        /// 생성자입니다.
        /// </summary>
        /// <param name="workkind"></param>
        /// <param name="subject"></param>
        /// <param name="subjectWithDate"></param>
        public GWApprovaler(string workkind, string subject, bool subjectWithDate)
        {
            this.Initialize(workkind, subject, subjectWithDate, false);
        }

        /// <summary>
        /// 생성자입니다.
        /// </summary>
        /// <param name="workkind"></param>
        /// <param name="subject"></param>
        /// <param name="subjectWithDate"></param>
        public GWApprovaler(string workkind, string subject, bool subjectWithDate, bool appCompleteMode)
        {
            this.Initialize(workkind, subject, subjectWithDate, appCompleteMode);
        }

        /// <summary>
        /// 생성자입니다.
        /// </summary>
        /// <param name="workKind"></param>
        /// <param name="subject"></param>
        /// <param name="subjectWithDate"></param>
        private void Initialize(string workKind, string subject, bool subjectWithDate, bool appCompleteMode)
        {
            _WSCOM = new AxClientProxy();

            _IsLauncher = GWApprovaler.isLauncher();
            _WorkKind = workKind;
            _Subject = (subjectWithDate ? DateTime.Now.ToString("yyyy.MM.dd") + " " : "") + subject;
            ERPID = String.Format("G{0}{1}",
                DateTime.Now.ToString("yyyyMMddHHmmss"),
                Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 18));


            if (StaticUserInfoContext.CorporationCode.Equals("1000"))
                _CompanyID = "10";  // 서연이화 고정
            else
                _CompanyID = "XX";  // 서연이화 아님

            _IsAppCompleteMode = appCompleteMode;

            _EMPNO = _IsLauncher ? "061208" : StaticUserInfoContext.EmpNo;
            _fileList = new HEParameterSet();

            //_URL = new TextBox();
            //_URL.Text = "";
        }

        /// <summary>
        /// 첨부파일을 추가
        /// </summary>
        /// <param name="fileFullPath"></param>
        public void FileAdd(string fileFullPath)
        {
            FileAdd(fileFullPath, false);
        }

        /// <summary>
        /// 첨부파일을 추가
        /// </summary>
        /// <param name="fileFullPath"></param>
        public void FileAdd(string fileFullPath, bool doFileDelete)
        {
            string fileKey = _fileList.Items.Count.ToString();

            // 새로운 파일을 업로드할 경우에만 처리 한다.
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(fileFullPath)))
            {
                FileStream stream = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);

                // 파일정보를 생성한다.
                RemoteFileInfo fileInfo = new RemoteFileInfo();
                fileInfo.DBPath = "GW_AppIF/" + this.ERPID;
                fileInfo.DBFileName = System.IO.Path.GetFileName(fileFullPath);
                fileInfo.DBFileSize = (int)stream.Length;
                fileInfo.DBMenuID = (doFileDelete ? fileFullPath : string.Empty);

                fileInfo.LocalFilePath = "C:/Temp/SIS/" + fileInfo.DBPath + "/" + fileInfo.DBFileName;
                fileInfo.RemoteFileName = fileInfo.DBFileName;

                fileInfo.FileContent = new byte[(int)stream.Length];

                stream.Read(fileInfo.FileContent, 0, fileInfo.FileContent.Length);
                stream.Close();
                stream.Dispose();

                // 파일 목록에 파일을 추가 한다.
                _fileList.Add(fileKey, fileInfo);
            }
            else
            {
                throw new FileNotFoundException("Not Found File : " + fileFullPath);
            }
        }

        /// <summary>
        /// 파일을 서버로 전송
        /// </summary>
        /// <param name="fileInfo"></param>
        private void FileTransfer(RemoteFileInfo fileInfo)
        {
            try
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

                        // 로걸 임시경로의 파일을 삭제
                        if (Directory.Exists(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath))) Directory.Delete(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath), true);

                        // 원본파일 삭제 옵션시 원본도 삭제
                        if (!string.IsNullOrEmpty(fileInfo.DBMenuID) && File.Exists(fileInfo.DBMenuID)) File.Delete(fileInfo.DBMenuID);
                    }
                    catch (Exception ex)
                    {
                        // 오류 발생시 로컬 파일이 있을경우 로컬 파일을 먼저 삭제처리 후 Exception 을 상위로 던진다.
                        if (Directory.Exists(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath))) Directory.Delete(System.IO.Path.GetDirectoryName(fileInfo.LocalFilePath), true);
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can't access fileServer", ex);
            }
        }

        /// <summary>
        /// 결재창을 호출 후 기간시스템에 결재에 관련된 정보를 업데이트하지 않을 경우 사용합니다.
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        public void CallWithoutEvent(string procedureName, HEParameterSet parameters)
        {
            this.Execute(true, procedureName, parameters);
        }

        /// <summary>
        /// 결재창을 호출 후 기간시스템에 결재에 관련된 정보를 업데이트 해야 할 경우 사용합니다.
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        public void Call(string procedureName, HEParameterSet parameters)
        {
            this.Execute(false, procedureName, parameters);
        }

        /// <summary>
        /// 인스턴스 데이처를 처리하고 결재 윈도우를 호출합니다.
        /// </summary>
        /// <param name="isNonUpdate"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        private void Execute(bool isNonUpdate, string procedureName, HEParameterSet parameters)
        {
            int isFile = 0;

            // 파일이 있으면 파일 처리 문저 수행
            foreach (HEParameterSetItem obj in this._fileList.Items)
            {
                RemoteFileInfo fileInfo = obj.Value as RemoteFileInfo;
                if (fileInfo != null) FileTransfer(fileInfo);

                isFile++;
            }

            // 인스턴스 및 데이터 처리
            string paramJson = JsonConvert.SerializeObject(parameters);

            // JObject 변환후 HEParameterSet 의 기본 파라메터 삭제 후 다시 Serializable
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(paramJson);
            jo.Remove("_ParameterSetName");
            jo.Remove("_ParameterSetCount");
            paramJson = JsonConvert.SerializeObject(jo);

            DataSet instance = AxStaticCommon.GetDataSourceSchema("ERPID", "WORKKIND", "COMPANYID", "EMPNO", "SUBJECT", "PROCEDURE", "PARAM", "ISFILE", "ISCOMPLETEMODE");

            // 상태값을 결재 완료 모드이면 7 아니면 0
            instance.Tables[0].Rows.Add(_ERPID, _WorkKind, _CompanyID, _EMPNO, _Subject, procedureName, paramJson, isFile, (_IsAppCompleteMode ? 7 : 0));

            if (!isNonUpdate)
                this.OnBeforeCalling(_ERPID, procedureName, parameters, instance);

            _WSCOM.ExecuteNonQueryTx("GW.PKG_GWINSTANCE.CREATE_INSTANCE", instance);

            // 결재 완료모드면 브라우저 호출 안하고 종료
            if (_IsAppCompleteMode) return;

            // 브라우저 호출
            string ApprovalURL = String.Format(AxStaticCommon.GetSysEnviroment("GW", _IsLauncher ? "URL_DEV" : "URL_RUN"), _ERPID); // ERPID 프로퍼티 에서 처리

            Process.Start(ApprovalURL);
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Launcher 여부 검사
        /// </summary>
        /// <returns></returns>
        public static bool isLauncher()
        {
            return (Application.StartupPath.IndexOf("Ax.DEV.Environment\\Launcher") > 0 || Application.StartupPath.IndexOf("HE.DEV.Environment\\Launcher") > 0 ||
                    Application.StartupPath.IndexOf("\\Addins\\HanilEhwa") > 0 || Application.StartupPath.IndexOf("\\Addins\\SeoyonEhwa") > 0);
        }

        /// <summary>
        /// 그룹웨어 Document 를 View 한다.
        /// </summary>
        /// <param name="ERPID"></param>
        public static void ViewDocument(string ERPID)
        {
            // 인스턴스 DocNo 구하기
            HEParameterSet param = new HEParameterSet();
            param.Add("ERPID", ERPID);
            DataSet ds = new DataSet();

            using (AxClientProxy proxy = new AxClientProxy())
            {
                ds = proxy.ExecuteDataSet("GW.PKG_GWINSTANCE.GET_INSTANCE", param);
            }

            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1 || ds.Tables[0].Rows[0]["DOCNO"] == null || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["DOCNO"].ToString()))
            {
                throw new Exception("The document is being processed or can not be found. \r\nPlease try again later! \r\n\r\n문서 처리중 이거나 또는 찾을수 없습니다. \r\n잠시후 재시도 바랍니다! ");
            }
            else
            {
                bool _IsLauncher = isLauncher();
                string _docno = ds.Tables[0].Rows[0]["DOCNO"].ToString();

                // 브라우저 호출
                string DocumentURL = string.Empty;
                string _empno = StaticUserInfoContext.EmpNo;

                if (StaticUserInfoContext.EmpNo.Length == 6) _empno = "110" + _empno;
                if (StaticUserInfoContext.UserDiv != "T12") _empno = string.Empty;
                if (_empno.Substring(0, 3).Equals("DEV")) _empno = string.Empty;

                _empno = _empno.Trim();

                if (_empno.Length == 9 && _empno.Substring(0, 3).Equals("100")) _empno = "110" + _empno.Substring(3);

                // 정상적인 사번이면 자동 로그인처하고 아니면 로그인창으로 이동
                if (string.IsNullOrEmpty(_empno))
                {
                    // 정상적인 사번이 아닐대 로그인창으로
                    DocumentURL = String.Format(AxStaticCommon.GetSysEnviroment("GW", _IsLauncher ? "VIEW_DEV" : "VIEW_RUN"), _docno); // ERPID 프로퍼티 에서 처리
                }
                else
                {
                    // 정상적인 사번이라면 자동로그인 처리
                    DocumentURL = String.Format(AxStaticCommon.GetSysEnviroment("GW", _IsLauncher ? "VIEW_DEV_EMPNO" : "VIEW_RUN_EMPNO"), _docno, _empno); // ERPID 프로퍼티 에서 처리
                }

                Process.Start(DocumentURL);
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
}
