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

namespace Ax.SIS.QA.QA01.UI
{
    public partial class QA30234P1 : AxCommonPopupControl
    {

        #region [필드에 대한 정의]
        
        private AxClientProxy _WSCOM;

        private string _PACKAGE_NAME = "APG_QA30234";
        #endregion

        #region [생성자에 대한 정의]

        public QA30234P1()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
    
        }
        #endregion

        #region [초기화 작업]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                           
                this.cbo01_DELIBAD_YN.DataBind("BI", true, "ALL");
                this.cbo01_DELIBAD_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowEditing = true;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "고객사코드", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 360, "고객사명", "CUSTNM", "CUSTNM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 160, "납입불량 적용유무", "DELIBAD_YN", "EI_EI21030_DELIBAD_YN2");
               
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "DELIBAD_YN");              
               
                this.btn01_INQUERY_Click(null, null);
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
        private void btn01_INQUERY_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);               
                set.Add("CUSTCD_CUSTNM", this.txt01_CUSTCD_CUSTNM.GetValue());               
                set.Add("DELIBAD_YN", this.cbo01_DELIBAD_YN.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);               

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.XD1410_INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", _PACKAGE_NAME , "INQUERY_CUST"), set);

                

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

        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn01_SAVE_Click(object sender, EventArgs e)
        {
            try
            {


                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "CUSTCD", "DELIBAD_YN");

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                }

                if (!this.IsSaveValid(source.Tables[0])) return;

                this.BeforeInvokeServer(true);


                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", _PACKAGE_NAME, "SAVE_CUST"), source);

                this.AfterInvokeServer();
                
                MsgCodeBox.Show("CD00-0009");
                
                this.btn01_INQUERY_Click(null, null);

               

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

        private bool IsSaveValid(DataTable source)
        {

            if (source.Rows.Count == 0)
            {
                //MsgBox.Show("저장할 데이터가 없습니다.");
                MsgCodeBox.ShowFormat("COM-00020");
                return false;
            }
            
            //if (MsgBox.Show("저장하시겠습니까?", "확인", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;


            return true;
        }

      
        #endregion
        
    }
}
