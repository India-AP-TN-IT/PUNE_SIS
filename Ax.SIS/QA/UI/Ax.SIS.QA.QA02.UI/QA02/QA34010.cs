#region ▶ Description & History
/* 
 * 프로그램명 : MS/ES 스펙관리 > MS/ES 스펙 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-05-28      배명희      신규 작성
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;

namespace Ax.SIS.QA.QA02.UI
{

    public partial class QA34010 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA34010";
        //private IQASubWindow _WSSUBWIN;

        string _FILEID = string.Empty;
        string _DOCNO = string.Empty;
        Point PanelMouseDownLocation;

        #region [ 초기화 설정에 대한 정의 ]

        public QA34010()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            //_WSSUBWIN = ClientFactory.CreateChannel<IQASubWindow>("QA09", "QASubWindow.svc", "CustomBinding");
           
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {                

                #region  다운버튼 이벤트 클릭 재정의

                //base에서 정의해 놓은 클릭 이벤트 핸들러 제거하고
                //이 화면에서 클릭 이벤트 추가.
                object btndownload = this._buttonsControl.BtnDownload;
                FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(btndownload);
                PropertyInfo pi = btndownload.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(btndownload, null);
                list.RemoveHandler(obj, list[obj]);
                this._buttonsControl.BtnDownload.Click += new EventHandler(BtnDownload_Click);

                #endregion

                DataSet source = this.GetTypeCode("ML"); //ML:언어          
                this.cbo01_LANG_DIV.DataBind(source.Tables[0], true);
                this.cbo01_LANG_DIV.DropDownStyle = ComboBoxStyle.DropDownList;               
             
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize(1, 1);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "스펙명", "SPEC_NO", "SPEC_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "EONO", "EONO", "EONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "갱신일", "RENEW_DATE", "RENEW_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "언어", "LANG_DIV", "LANG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "차수", "DEGREE", "DEGREE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 400, "제목", "SUBJECT", "SUBJECT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "사이즈", "FILE_SIZE", "FILE_SIZE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "등록부서", "LINENM", "REG_LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "최초등록자", "INSERT_ID", "FSTINPUTID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "최종수정자", "UPDATE_ID", "FNLUPDATEID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "등록일자", "REG_DATE", "REG_DATE");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "DOCNO", "DOCNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "FILEID", "FILEID");
                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "FILEID", "FILEID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "DOCNO", "DOCNO");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "LANG_DIV");

                this.grd01.Cols["FILE_SIZE"].Format = "###,###,###,###";
                this.grd01.Cols["LANG_DIV"].TextAlign = TextAlignEnum.CenterCenter;

                this.BtnQuery_Click(null, null);
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
                this.pnl01_INPUT_REASON.Visible = false;  

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SPEC_NO", this.txt01_SPEC_NO.GetValue());
                paramSet.Add("LANG_DIV", this.cbo01_LANG_DIV.GetValue());            
                paramSet.Add("SUBJECT", this.txt01_SUBJECT.GetValue());
                paramSet.Add("LAST_2MONTH", this.chk01_LAST_2MONTH.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source =  _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);

            
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
        
        protected override void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.CurrentContextMenu.Items[1].PerformClick();

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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        //더블클릭시 스펙파일(pdf) 열람한다. (C:\Temp\Ax.SIS 에 다운로드)
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int rIdx = this.grd01.MouseRow;
                if (rIdx < this.grd01.Rows.Fixed || rIdx >= this.grd01.Rows.Count) return;
                string fileId = this.grd01.GetValue(rIdx, "FILEID").ToString();
                string docno = this.grd01.GetValue(rIdx, "DOCNO").ToString();

                this.pnl01_INPUT_REASON.Top = this.grd01.Top + (this.grd01.Height / 2) - (this.pnl01_INPUT_REASON.Height / 2);
                this.pnl01_INPUT_REASON.Left = this.grd01.Left + (this.grd01.Width / 2) - (this.pnl01_INPUT_REASON.Width / 2);
                this.grd01.Enabled = false;

                _FILEID = fileId;
                _DOCNO = docno;

                this.pnl01_INPUT_REASON.Visible = true;
               
              
                   
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 사용자 정의 메서드]
        
        //스펙 파일 (pdf) 다운로드
        private void openPdf(string fileId)
        {
            try
            {
                PDFHelper pdf = new PDFHelper(true);
                string localFileName = pdf.LoadPDF(fileId);
                Process.Start(localFileName);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 열람 사유 등록 영역]

        //열람 사유 등록용 panel 위치 이동 관련 로직
        private void pnl01_INPUT_REASON_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) PanelMouseDownLocation = e.Location;
        }

        //열람 사유 등록용 panel 위치 이동 관련 로직
        private void pnl01_INPUT_REASON_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.pnl01_INPUT_REASON.Left += e.X - PanelMouseDownLocation.X;

                this.pnl01_INPUT_REASON.Top += e.Y - PanelMouseDownLocation.Y;

            }
        }

        //닫기 버튼 클릭시 - 열람 사유 등록용 panel안보이게
        private void btn01_CLOSE_Click(object sender, EventArgs e)
        {                    
            this.pnl01_INPUT_REASON.Visible = false;       
        }

        //확인 버튼 클릭시 - 열람 사유 등록 후 파일 다운로드(워터마크 추가)
        private void btn01_CONFIRM_Click(object sender, EventArgs e)
        {
            //필수체크
            if (this.txt01_ACCESS_REASON.IsEmpty)
            {
                MsgCodeBox.Show("QA02-0051"); //조회사유를 반드시 입력하여야 합니다.
                return;
            }

            if (this.GetByteCount( this.txt01_ACCESS_REASON.GetValue().ToString())>4000)
            {
                MsgCodeBox.ShowFormat("QA01-0014", "조회사유", 4000); //{0} 데이터는 {1} bytes 이하로 입력하여 주세요.
                return;
            }


            HEParameterSet set = new HEParameterSet();
            set.Add("DOCNO", _DOCNO);
            set.Add("ACCESS_USERID", this.UserInfo.UserID);
            set.Add("ACCESS_REASON", this.txt01_ACCESS_REASON.GetValue());

            //_WSCOM.ExecuteNonQueryTx("APG_QA34010.SAVE_HISTORY", set);
            _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_HISTORY"), set);

            this.openPdf(_FILEID);       

            this.pnl01_INPUT_REASON.Visible = false;         

            
        }

        //열람 사유 등록용 panel - 표시, 미표시에 따른 초기설정
        private void pnl01_INPUT_REASON_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.pnl01_INPUT_REASON.Visible)
            {
                _FILEID = string.Empty;
                _DOCNO = string.Empty;
                this.txt01_ACCESS_REASON.Initialize();
                this.chk01_AGREE.Checked = false;
                this.grd01.Enabled = true;
            }
            else
                this.grd01.Enabled = false;
        }

        //동의 체크박스 체크하여야 "확인"버튼 활성화한다.
        private void chk01_AGREE_CheckedChanged(object sender, EventArgs e)
        {        
            this.btn01_CONFIRM.Enabled = this.chk01_AGREE.Checked;         
        }
        
     
        #endregion
    }
    
}
