#region ▶ Description & History
/* 
 * 프로그램명 : 월별 마감 등록
 * 설     명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2012-06-27
 * 최종수정자 :
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2012-06-27	  오세민		최초 개발
 *              2014-10-14    진승모     다국어 적용
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Collections;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;   
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>월별 마감 등록</b>
    /// </summary>
    public partial class PD25410 : AxCommonBaseControl
    {
        //private IPD25410 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD25410";

        public PD25410()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD25410>("PM04", "PD25410.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.dtp01_STD_DATE.SetMMFromStart();
                this.dtp01_STD_DATE_TO.SetMMFromStart();
                this.dtp02_STD_DATE.SetMMFromStart();
                this.dtp02_STD_DATE.SetReadOnly(true);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  80, "업무", "LOCK_TYPE", "LOCK_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "기준일자", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "메뉴ID", "MENUID", "MENUID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "메뉴명", "MENUNM", "MENUNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  80, "잠금상태", "LOCK_STA", "LOCK_STA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "내역", "REMARK", "REMARK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "등록자", "EMPNO", "INSERT_ID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "등록일시", "INSERT_DATE", "INSERT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "수정자", "UPDATE_EMPNO", "AMD_EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "수정일시", "UPDATE_DATE", "UPDATE_DATE2");
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                string strCorCD = this.UserInfo.CorporationCode;
                this.cbo01_SAUP.DataBind_BIZCD(strCorCD, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);
                this.txt02_MENUID.SetReadOnly(true);                
                //this.cbo01_SAUP.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                DataSet ds = this.GetDataSourceSchema("Code", "CodeValue");
                ds.Tables[0].Rows.Add("Y", "Y-Lock");
                ds.Tables[0].Rows.Add("N", "N-UnLock");                
                this.cbo02_LOCK_STA.DataBind(ds.Tables[0]);
                

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "SER", "SER");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C,  80, "잠금상태", "LOCK_STA", "LOCK_STA");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "내역", "REMARK", "REMARK");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "등록자", "INSERT_ID", "INSERT_ID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "등록일시", "INSERT_DATE", "INSERT_DATE");


                this.txt02_LOCK_TYPE.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSaveValid())
                    return;
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.txt02_CORCD.GetValue());
                paramSet.Add("BIZCD", this.txt02_BIZCD.GetValue());
                paramSet.Add("STD_DATE", this.dtp02_STD_DATE.GetDateText());
                paramSet.Add("MENUID", this.txt02_MENUID.GetValue());
                paramSet.Add("LOCK_TYPE", this.txt02_LOCK_TYPE.GetValue());
                paramSet.Add("LOCK_STA", this.cbo02_LOCK_STA.GetValue());
                paramSet.Add("EMPNO", this.UserInfo.UserID);
                paramSet.Add("REMARK", this.txt02_REMARK.GetValue());
                
                this.BeforeInvokeServer(true);
                //_WSCOM.Save(paramSet);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), paramSet);
                this.AfterInvokeServer();

                //화면 초기화 및 재조회
                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 데이터가 정상적으로 저장되었습니다");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_SAUP.GetValue());
                paramSet.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
                paramSet.Add("STD_DATE_TO", this.dtp01_STD_DATE_TO.GetDateText());
                paramSet.Add("MENUID", string.Empty);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                

                this.BeforeInvokeServer(true);

                DataSet source =  _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                this.grd01.SetValue(source.Tables[0]);
                this.grd02.InitializeDataSource();

                this.BtnReset_Click(null, null);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtp02_STD_DATE.Initialize();                
                this.cbo02_LOCK_STA.Initialize();
                this.txt02_REMARK.Initialize();
                this.txt02_MENUID.Initialize();
                this.txt02_LOCK_TYPE.Initialize();
                this.txt02_CORCD.Initialize();
                this.txt02_BIZCD.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }    
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.Row;

                if (row < this.grd01.Rows.Fixed || row>= this.grd01.Rows.Count)
                {
                    //MsgBox.Show("조회된 데이터가 없습니다.");
                    MsgCodeBox.Show("CD00-0039");
                    return;
                }

                this.dtp02_STD_DATE.SetValue(this.grd01.GetValue(row, "STD_DATE").ToString());
                this.txt02_LOCK_TYPE.SetValue(this.grd01.GetValue(row, "LOCK_TYPE").ToString());
                this.cbo02_LOCK_STA.SetValue(this.grd01.GetValue(row, "LOCK_STA"));
                this.txt02_MENUID.SetValue(this.grd01.GetValue(row, "MENUID"));
                //this.txt02_REMARK.SetValue(this.grd01.GetValue(row, "REMARK"));
                this.txt02_REMARK.Initialize();
                this.txt02_CORCD.SetValue(this.grd01.GetValue(row, "CORCD"));
                this.txt02_BIZCD.SetValue(this.grd01.GetValue(row, "BIZCD"));

                //잠금설정 이력조회
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.grd01.GetValue(row, "CORCD"));
                set.Add("BIZCD", this.grd01.GetValue(row, "BIZCD"));
                set.Add("STD_DATE", this.grd01.GetValue(row, "STD_DATE"));
                set.Add("MENUID", this.grd01.GetValue(row, "MENUID"));
                set.Add("LOCK_TYPE", this.grd01.GetValue(row, "LOCK_TYPE"));
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_HISTORY"), set);
                this.grd02.SetValue(source);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid()
        {
            try
            {
                

                string strYYMM = this.dtp02_STD_DATE.GetDateText().ToString();                
                string strLOCK_STA = this.cbo02_LOCK_STA.GetValue().ToString();
                string strMENUID = this.txt02_MENUID.GetValue().ToString();
                string strLOCK_TYPE= this.txt02_LOCK_TYPE.GetValue().ToString();
                string strREMARK = this.txt02_REMARK.GetValue().ToString();

                if (this.GetByteCount(strYYMM) == 0)
                {
                    //MsgBox.Show("대상월을 입력하여 주십시요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_STD_DATE.Text);
                    return false;
                }
             
                if (this.GetByteCount(strLOCK_STA) == 0)
                {
                    //MsgBox.Show("잠금여부를 입력하여 주십시요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LOCK_STA.Text);
                    return false;
                }

                if (this.GetByteCount(strMENUID) == 0)
                {
                    //MsgBox.Show("잠금여부를 입력하여 주십시요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_MENUID.Text);
                    return false;
                }

                if (this.GetByteCount(strLOCK_TYPE) == 0)
                {
                    //MsgBox.Show("잠금여부를 입력하여 주십시요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LOCK_TYPE.Text);
                    return false;
                }
                if (this.GetByteCount(strREMARK) == 0)
                {
                    //MsgBox.Show("잠금여부를 입력하여 주십시요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_AMDREASON.Text);
                    return false;
                }
                
                //저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
