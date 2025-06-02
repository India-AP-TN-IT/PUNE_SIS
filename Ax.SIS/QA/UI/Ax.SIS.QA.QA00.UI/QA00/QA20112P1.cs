#region ▶ Description & History
/* 
 * 프로그램명 : 입고불량 대책서 검토결과(당사) 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-10-10      배명희      신규 추가    
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

namespace Ax.SIS.QA.QA00.UI
{
    public partial class QA20112P1 : AxCommonPopupControl
    {

        #region [필드에 대한 정의]
        
        private AxClientProxy _WSCOM;
        private string _BIZCD;
        private string _VENDCD;
        private string _DOCNO;
        private string _DEFNO;
        private byte[] _ATT_FILE;
        private string _FILEID = string.Empty;
        
        #endregion

        #region [생성자에 대한 정의]

        public QA20112P1(string bizcd, string vendcd, string docno, string defno)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _BIZCD = bizcd;
            _VENDCD = vendcd;
            _DOCNO = docno;
            _DEFNO = defno;
        }
        #endregion

        #region [초기화 작업]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.QA.QA09.UI.QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//업체코드
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);


                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "발행번호",   "DOCNO",         "DOC_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "구분",       "INSPECT_DIVNM", "DIVISION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "품번",       "PARTNO",        "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "품명",       "PARTNM",        "PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "차종",       "VINCD",         "VIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "불량내용",   "DEFNM",         "DEFNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "불량장소",   "DEF_PLACENM",   "DEF_PLACE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "작성자",     "VEND_MGR",      "WRITE_EMP");

                this.cbo01_BIZCD.SetValue(_BIZCD);
                this.cdx01_VENDCD.SetValue(_VENDCD);
                this.txt01_DOCNO.SetValue(_DOCNO);

                this.cbo01_BIZCD.Enabled = false;
                this.cdx01_VENDCD.Enabled = false;
                this.txt01_DOCNO.Enabled = false;

                this.txt01_IMPROV_MEAS.Enabled = false;
                this.txt01_OCCUR_APPLI.Enabled = false;
             
                this.txt01_FILENM.Enabled = false;
                //this.cbo01_BIZCD.SetReadOnly(true);
                //this.cdx01_VENDCD.SetReadOnly(true);
                //this.txt01_DOCNO.SetReadOnly(true);

                //this.txt01_IMPROV_MEAS.SetReadOnly(true);
                //this.txt01_OCCUR_APPLI.SetReadOnly(true);
                //this.txt01_RSLT_CNTT.SetReadOnly(true);
                //this.txt01_FILENM.SetReadOnly(true);

                this.btn01_Inquery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [버튼 클릭 이벤트]

        /// <summary>
        /// 내용 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", _BIZCD);
                set.Add("VENDCD", _VENDCD);
                set.Add("DOCNO", _DOCNO);
                set.Add("LANG_SET", this.UserInfo.Language);
               // set.Add("GRIDNAME", this.txt01_GRIDNAME.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.XD1410_INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet("APG_QA20112.INQUERY_QA1020", set);

                set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", _BIZCD);
                set.Add("DOCNO", _DOCNO);
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM.ExecuteDataSet("APG_QA20112.INQUERY_QA1040", set);

                this.grd01.SetValue(source.Tables[0]);

                if (source2.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source2.Tables[0].Rows[0];
                    this.txt01_OCCUR_APPLI.SetValue(dr["OCCUR_APPLI"]);
                    this.txt01_IMPROV_MEAS.SetValue(dr["IMPROV_MEAS"]);
                    this.txt01_FILENM.SetValue(dr["ATT_FILE_NM"]);
                    this.txt01_RSLT_CNTT.SetValue(dr["RSLT_CNTT"]);
                    _ATT_FILE = dr["ATT_FILE"] == DBNull.Value ? null : (byte[])dr["ATT_FILE"];
                    _FILEID = dr["ATT_FILE_FILEID"]==DBNull.Value ? "" : dr["ATT_FILE_FILEID"].ToString();
                }
                else
                {
                    this.txt01_IMPROV_MEAS.Clear();
                    this.txt01_OCCUR_APPLI.Clear();
                    this.txt01_RSLT_CNTT.Clear();
                    this.txt01_FILENM.Clear();
                    _ATT_FILE = null;
                    _FILEID = string.Empty;
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

        /// <summary>
        /// 접수버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn01_ACCEPT_Click(object sender, EventArgs e)
        {
            try
            {
                //대책서 파일이 첨부되지 않았으면 접수불가.
                if (this.txt01_FILENM.GetValue().ToString().Equals(string.Empty))
                {
                    MsgCodeBox.Show("QA01-0008"); //대책서 데이터가 존재하지 않습니다.
                    return;
                }

                

                if (!this.IsAcceptValid()) return;

                this.BeforeInvokeServer(true);


                string fileId = string.Empty;
                string FILE_NAME = string.Empty;

                
                FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + this.txt01_FILENM.GetValue().ToString();
                System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                TEMP_FILE.Write(_ATT_FILE, 0, _ATT_FILE.Length);
                TEMP_FILE.Close();
                TEMP_FILE.Dispose();

                fileId = RemoteFileHandler.FileUpload(FILE_NAME, this.Name, "");

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", _BIZCD);
                param.Add("DOCNO", _DOCNO);
                param.Add("RSLT_CNTT", this.txt01_RSLT_CNTT.GetValue());
                param.Add("FIRM_STATUS", "FQY");//FQY:접수, FQN:반송
                param.Add("ATT_FILE_FILEID", fileId);


                HEParameterSet param2 = new HEParameterSet();
                param2.Add("CORCD", this.UserInfo.CorporationCode);
                param2.Add("BIZCD", _BIZCD);
                param2.Add("DOCNO", _DOCNO);
                param2.Add("DEFNO", _DEFNO);
                param2.Add("CONF_MGR", this.UserInfo.EmpNo);

                System.Collections.Generic.List<HEParameterSet> p = new System.Collections.Generic.List<HEParameterSet>{param, param2};
                string[] procedures = new string[] { "APG_QA20112.SAVE_FIRM_STATUS", "APG_QA20112.SAVE_CONF_OK" };
               

                _WSCOM.MultipleExecuteNonQueryTx(procedures, p);
                
                //파일아이디 저장후 임시파일 삭제
                if (fileId != string.Empty)
                {
                    System.IO.File.Delete(FILE_NAME);
                }

                this.AfterInvokeServer();
                
                //this.btn01_Inquery_Click(null, null);
                //MsgBox.Show("접수완료되었습니다.");
                MsgCodeBox.Show("CD00-0104");

               

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

        /// <summary>
        /// 반송버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn01_RETURN_Click(object sender, EventArgs e)
        {
            try
            {


                if (!this.IsReturnValid()) return;

                this.BeforeInvokeServer(true);

                if (this._FILEID != string.Empty)
                    RemoteFileHandler.FileRemove(this._FILEID);

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", _BIZCD);
                param.Add("DOCNO", _DOCNO);
                param.Add("RSLT_CNTT", this.txt01_RSLT_CNTT.GetValue());
                param.Add("FIRM_STATUS", "FQN");//FQY:접수, FQN:반송
                param.Add("ATT_FILE_FILEID", "");//첨부파일아이디


                HEParameterSet param2 = new HEParameterSet();
                param2.Add("CORCD", this.UserInfo.CorporationCode);
                param2.Add("BIZCD", _BIZCD);
                param2.Add("DOCNO", _DOCNO);
                param2.Add("DEFNO", _DEFNO);
                param2.Add("CONF_MGR", this.UserInfo.EmpNo);

                System.Collections.Generic.List<HEParameterSet> p = new System.Collections.Generic.List<HEParameterSet> { param, param2 };
                string[] procedures = new string[] { "APG_QA20112.SAVE_FIRM_STATUS", "APG_QA20112.SAVE_CONF_OK" };





                _WSCOM.MultipleExecuteNonQueryTx(procedures, p);

                this.AfterInvokeServer();

                //this.btn01_Inquery_Click(null, null);
                //MsgBox.Show("반송처리되었습니다.");
                MsgCodeBox.Show("QA00-026");
                
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

        /// <summary>
        /// 팝업 종료 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn01_CLOSE_Click(object sender, EventArgs e)
        {

            //if (MsgBox.Show("입고불량 대책서 검토결과(당사) 팝업을 닫으시겠습니까?", "주의",  MessageBoxButtons.OKCancel )== DialogResult.OK)
            if (MsgCodeBox.Show("QA00-027", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.ParentForm.Close();
       
        }

        /// <summary>
        /// 첨부파일 보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn01_VIEW_ATT_FILE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt01_FILENM.GetValue().ToString().Equals(string.Empty)) return;

                string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + this.txt01_FILENM.GetValue().ToString();
                System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                TEMP_FILE.Write(_ATT_FILE, 0, _ATT_FILE.Length);
                TEMP_FILE.Close();
                TEMP_FILE.Dispose();

                System.Diagnostics.Process.Start(FILE_NAME);
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

        #region [유효성체크]

        private bool IsAcceptValid()
        {
            if (this.txt01_OCCUR_APPLI.ByteCount <= 0)
            {
                //MsgBox.Show("발생원인이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("OCCUR_APPLI"));
                return false;
            }

            if (this.txt01_IMPROV_MEAS.ByteCount <= 0)
            {
                //MsgBox.Show("개선대책이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("IMPROV_MEAS"));
                return false;
            }

            if (this.txt01_RSLT_CNTT.ByteCount <= 0)
            {
                //MsgBox.Show("결과내용이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("RSLT_CNTT"));
                return false;
            }
            if (this.grd01.Rows.Count == this.grd01.Rows.Fixed)
            {
                //MsgBox.Show("저장할 데이터가 없습니다.");
                MsgCodeBox.ShowFormat("COM-00020");
                return false;
            }
            
            //if (MsgBox.Show("접수처리하시겠습니까?", "확인", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("QA00-028", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;


            return true;
        }

        private bool IsReturnValid()
        {
            if (this.txt01_OCCUR_APPLI.ByteCount <= 0)
            {
                //MsgBox.Show("발생원인이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("OCCUR_APPLI"));
                return false;
            }

            if (this.txt01_IMPROV_MEAS.ByteCount <= 0)
            {
                //MsgBox.Show("개선대책이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("IMPROV_MEAS"));
                return false;
            }
            
            if (this.txt01_RSLT_CNTT.ByteCount <= 0)
            {
                //MsgBox.Show("결과내용이 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("RSLT_CNTT"));
                return false;
            }
            if (this.grd01.Rows.Count == this.grd01.Rows.Fixed)
            {
                //MsgBox.Show("저장할 데이터가 없습니다.");
                MsgCodeBox.ShowFormat("COM-00020");
                return false;
            }
            
            //if (MsgBox.Show("반송처리하시겠습니까?", "확인", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("QA00-029", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;


            return true;
        }
        #endregion
        
    }
}
