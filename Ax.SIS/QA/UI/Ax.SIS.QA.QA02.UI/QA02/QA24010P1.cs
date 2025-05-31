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

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA02.UI
{

    public partial class QA24010P1 : AxCommonPopupControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA24010";

        //private IQASubWindow _WSSUBWIN;
        private string _DOCNO;

        #region [ 초기화 설정에 대한 정의 ]

        public QA24010P1(string docno)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            //_WSSUBWIN = ClientFactory.CreateChannel<IQASubWindow>("QA09", "QASubWindow.svc", "CustomBinding");

            _DOCNO = docno;
           
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataSet source = this.GetTypeCode("ML"); //ML:언어
              
              
             

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize(1, 1);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 125, "열람일시", "ACCESS_DATE", "ACCESS_DATE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "소속", "LINENAME", "DEPTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "열람자", "USERNAME", "ACCESS_USER");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "열람사유", "ACCESS_REASON", "ACCESS_REASON");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "스펙명", "SPEC_NO", "SPEC_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "갱신일", "RENEW_DATE", "RENEW_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "언어", "LANG_DIV", "LANG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "차수", "DEGREE", "DEGREE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "제목", "SUBJECT", "SUBJECT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "등록일자", "REG_DATE", "REG_DATE");
             
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "LANG_DIV");

              
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

        private  void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                

                HEParameterSet paramSet = new HEParameterSet();
                if(this.rdo01_ALL_SPEC_HISTORY.Checked)
                    paramSet.Add("DOCNO", "");
                else
                    paramSet.Add("DOCNO", _DOCNO);

                paramSet.Add("LANG_SET", this.UserInfo.Language);
                //this.BeforeInvokeServer(true);

                DataSet source =  _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_HISTORY"), paramSet);

               //this.AfterInvokeServer();

                this.grd01.SetValue(source);

            
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                //this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                //this.AfterInvokeServer();
            }
        }

        #endregion

        #region [ 기타 이벤트 정의 ]
    
        private void btn01_INQUERY_Click(object sender, EventArgs e)
        {
            this.BtnQuery_Click(sender, e);
        }

        #endregion


    }
    
}
