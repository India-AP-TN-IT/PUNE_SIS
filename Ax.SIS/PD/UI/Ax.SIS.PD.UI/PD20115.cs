#region ▶ Description & History
/* 
* 프로그램명 : PD20115 공정별 작업 표준서
* 설      명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*/
#endregion
using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 공정별 작업표준서
    /// </summary>
    public partial class PD20115 : AxCommonBaseControl
    {
        private byte[] _FILE;
        private bool _IsBinded;
        //private IPD20115 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD20115";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        #region [ 초기화 작업 정의 ]

        public PD20115()
        {
            _FILE = null;
            _IsBinded = false;

            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20115>("PD", "PD20115.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true,  false,  AxFlexGrid.FtextAlign.C, 060, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 090, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 160, "라인명", "LINENM", "LINENM");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 090, "공정코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 160, "공정명", "PROCNM", "PROCNM");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 090, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 120, "장착위치명", "INSTALL_POS_DESC", "INSTALL_POS_DESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "출력순서", "DISP_SEQ", "PRINT_SEQ");
                this.grd01.AddColumn(true,  true, AxFlexGrid.FtextAlign.L, 200, "파일명", "FILE_NAME", "FILE_NAME5");

                #region
                
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                set1.Add("PRDT_DIV", "");
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set1).Tables[0];
                //DataTable source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set1).Tables[0];
                
                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0];//

                #endregion

                this.cbl01_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
                this.cbl02_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
                this.cbl01_INSTALL_POS.DataBind(source2, "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");  //타입코드;타입명
                this.cbl02_INSTALL_POS.DataBind(source2, "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");  //"타입코드;타입명"

                this.SetRequired(lbl02_LINECD, lbl02_PROCCD, lbl02_INSTALL_POS, lbl02_PRINT_SEQ, lbl02_FILE_NAME5);
                
                this.txt02_FILE_SIZE.SetReadOnly(true);
                this.txt02_FILE_NAME.SetReadOnly(true);

                this.txt02_DISP_SEQ.SetValid(2, AxTextBox.TextType.OnlyNumber);

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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                _FILE = null;
                _IsBinded = false;

                this.cbl02_LINECD.Initialize();
                this.cbl02_PROCCD.Initialize();
                this.cbl02_INSTALL_POS.Initialize();
                this.txt02_DISP_SEQ.Initialize();
                this.txt02_FILE_SIZE.Initialize();
                this.txt02_FILE_NAME.Initialize();

                this.btn02_CONFIRM.SetReadOnly(true);
                this.cbl02_LINECD.SetReadOnly(false);
                this.cbl02_PROCCD.SetReadOnly(false);
                this.cbl02_INSTALL_POS.SetReadOnly(false);
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
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("PROCCD", this.cbl01_PROCCD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
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
                if (!IsSaveValid()) return;

                string CORCD = this.UserInfo.CorporationCode;
                string BIZCD = this.UserInfo.BusinessCode;
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "PROCCD", "INSTALL_POS", "DISP_SEQ", "FILE_NAME", "BLOB$FILE_IMAGE", "FILE_SIZE", "EMPNO");

                source.Tables[0].Rows.Add(
                    CORCD,
                    BIZCD,
                    LINECD,
                    PROCCD,
                    INSTALL_POS,
                    this.txt02_DISP_SEQ.GetValue(),
                    this.txt02_FILE_NAME.GetValue(),
                    _FILE,
                    this.txt02_FILE_SIZE.GetValue(),
                    this.UserInfo.EmpNo
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);

                //###bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery(CORCD, LINECD, PROCCD, INSTALL_POS);

                //MsgBox.Show("입력하신 공정별 작업표준서 정보가 저장되었습니다.");                
                MsgCodeBox.Show("CD00-0071");//저장되었습니다.
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
        
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES1090", bizcd).Tables[0].Rows[0][0].ToString();

        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0004");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0005");
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

        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeleteValid()) return;

                DataSet source = this.GetDataSourceSchema("CORCD", "LINECD", "PROCCD", "INSTALL_POS");

                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbl02_LINECD.GetValue(),
                    this.cbl02_PROCCD.GetValue(),
                    this.cbl02_INSTALL_POS.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                
                //###bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 공정별 작업표준서 정보가 삭제되었습니다");
                //삭제되었습니다.
                MsgCodeBox.Show("CD00-0072");
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

        private void cbl01_PROCCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.UserInfo.BusinessCode);
            set.Add("LINECD", this.cbl01_LINECD.GetValue());
            
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCLIST"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_PROCLIST(set).Tables[0];

            this.cbl01_PROCCD.DataBind(source, "PROCCD", "PROCNM", this.GetLabel("PROCCD") + ";" + this.GetLabel("PROCNM"), "C;L"); //공정코드;공정명
        }

        private void cbl02_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.UserInfo.BusinessCode);
            set.Add("LINECD", this.cbl02_LINECD.GetValue());

            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCLIST"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_PROCLIST(set).Tables[0];

            this.cbl02_PROCCD.DataBind(source, "PROCCD", "PROCNM", this.GetLabel("PROCCD") + ";" + this.GetLabel("PROCNM"), "C;L");  //공정코드;공정명
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;
                
                string CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                string LINECD = this.grd01.GetValue(row, "LINECD").ToString();
                string PROCCD = this.grd01.GetValue(row, "PROCCD").ToString();
                string INSTALL_POS = this.grd01.GetValue(row, "INSTALL_POS").ToString();

                this.Inquery(CORCD, LINECD, PROCCD, INSTALL_POS);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_REG_Click(object sender, EventArgs e)
        {
            FileStream oFile = null;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                //파일 선택 필터
                ofd.Title = this.GetLabel("ATTACH_PDF"); //PDF 파일 선택
                ofd.Filter = "Adobe PDF (*.pdf)|*.pdf";
                ofd.FilterIndex = 0;

                //파일 선택 되면
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    //PDF 파일을 읽어서 Grid 등록 처리함
                    oFile = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);

                    byte[] cFileBuf = new byte[oFile.Length];

                    oFile.Read(cFileBuf, 0, Convert.ToInt32(oFile.Length));

                    //파일 크기
                    this.txt02_FILE_SIZE.SetValue(oFile.Length);

                    //파일명
                    this.txt02_FILE_NAME.SetValue(ofd.SafeFileName);

                    //파일 이미지
                    _FILE = cFileBuf;

                    oFile.Close();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (oFile != null)
                    oFile.Close();
            }
        }

        private void btn02_DWN_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = this.GetLabel("ATTACH_PDF");    //PDF 파일 선택;
                sfd.Filter = "Adobe PDF (*.pdf)|*.pdf";
                sfd.FilterIndex = 0;

                sfd.FileName = this.txt02_FILE_NAME.GetValue().ToString();

                if (sfd.ShowDialog() != DialogResult.OK) return;

                string fileName = sfd.FileName;

                int ArraySize = _FILE.GetUpperBound(0);
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(_FILE, 0, ArraySize + 1);
                stream.Close();

                Process.Start(sfd.FileName, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드]

        private void Inquery(string CORCD, string LINECD, string PROCCD, string INSTALL_POS)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", LINECD);
                set.Add("PROCCD", PROCCD);
                set.Add("INSTALL_POS", INSTALL_POS);

                //DataSet source = _WSCOM.INQUERY_DETAIL(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR");

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                this.cbl02_LINECD.SetValue(row["LINECD"]);
                this.cbl02_PROCCD.SetValue(row["PROCCD"]);
                this.cbl02_INSTALL_POS.SetValue(row["INSTALL_POS"]);
                this.txt02_DISP_SEQ.SetValue(row["DISP_SEQ"]);
                this.txt02_FILE_SIZE.SetValue(row["FILE_SIZE"]);
                this.txt02_FILE_NAME.SetValue(row["FILE_NAME"]);

                if (row["FILE_IMAGE"] != System.DBNull.Value)
                {
                    _FILE = (byte[])row["FILE_IMAGE"];
                    this.btn02_CONFIRM.SetReadOnly(false);
                }

                this.cbl02_LINECD.SetReadOnly(true);
                this.cbl02_PROCCD.SetReadOnly(true);
                this.cbl02_INSTALL_POS.SetReadOnly(true);

                _IsBinded = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();
                string DISP_SEQ = this.txt02_DISP_SEQ.GetValue().ToString();
                string FILE_NAME = this.txt02_FILE_NAME.GetValue().ToString();

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show("{라인}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("LINE"));
                    return false;
                }

                if (this.GetByteCount(PROCCD) == 0)
                {
                    //MsgBox.Show("{공정}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("PROCINFO"));
                    return false;
                }

                if (this.GetByteCount(INSTALL_POS) == 0)
                {
                    //MsgBox.Show("{장착위치}가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("POSTITLE"));
                    return false;
                }

                if (this.GetByteCount(DISP_SEQ) == 0)
                {
                    //MsgBox.Show("{출력순서}가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("PRINT_SEQ"));
                    return false;
                }

                if (this.GetByteCount(FILE_NAME) == 0)
                {
                    //MsgBox.Show("{첨부파일}이 등록되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0010", this.GetLabel("ATTACH_FILE"));
                    return false;
                }

                //if (MsgBox.Show("입력하신 공정별 작업표준서 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid()
        {
            try
            {
                if (!_IsBinded)
                {
                    //MsgBox.Show("삭제할 공정별 작업표준서 정보가 선택되지 않습니다.");
                    //삭제할 데이터가 선택되지 않았습니다.
                    MsgCodeBox.Show("PD00-0011");
                    return false;
                }

                //if (MsgBox.Show("선택하신 공정별 작업표준서 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //삭제하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion
    }
}
