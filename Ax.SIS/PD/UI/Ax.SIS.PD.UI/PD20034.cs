#region ▶ Description & History
/* 
 * 프로그램명 : PD20034 모델 차종관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_VINCD, cdx02_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *              2014-10-16    진승모     다국어 적용
 *              2014-10-17    진승모     밸리데이션체크 추가
 *              2017-07~09   배명희      SIS 이관(구.PM20034)
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
   
    /// <summary>
    /// <b>고객사 차종 - 당사 차종 연결</b>       
    /// </summary>
    public partial class PD20034 : AxCommonBaseControl
    {
        //private IPD20034 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20034";

        private string _CORCD = "";
        private string _BIZCD = "";

        public PD20034()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPD20034>("PM00", "PD20034.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.cdx01_CUSTCD.HEPopupHelper = new CM22022P1(this.cdx01_CUSTCD);
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("CUSTCD");

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true,true,this.cdx01_VINCD);

                this.dte01_APPLY_END_DATE.SetFromEnd();
                //this.cdx01_VINCD.CodeParameterName = "CODE";
                //this.cdx01_VINCD.NameParameterName = "CODENAME";
                //this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.HEUserParameterSetValue("CLASS_ID", "A3");
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";               
                //this.cdx01_VINCD.HEPopupHelper = new CM20011P1(); //new PM20011P1();
                //this.cdx01_VINCD.PopupTitle         = "차종코드";
                //this.cdx01_VINCD.CodeParameterName  = "VINCD";
                //this.cdx01_VINCD.NameParameterName  = "VINCDNM";
                //this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";



                this.cdx02_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx02_VINCD);
                
                //this.cdx02_VINCD.HEPopupHelper = new CM30010P1("A3");
                //this.cdx02_VINCD.CodeParameterName = "CODE";
                //this.cdx02_VINCD.NameParameterName = "CODENAME";
                //this.cdx02_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx02_VINCD.HEUserParameterSetValue("CLASS_ID", "A3");
                //this.cdx02_VINCD.SetCodePixedLength();
                //this.cdx02_VINCD.PrefixCode = "A3";
                //this.cdx02_VINCD.HEPopupHelper      = new CM20011P1();
                //this.cdx02_VINCD.PopupTitle         = "차종코드";
                //this.cdx02_VINCD.CodeParameterName  = "VINCD";
                //this.cdx02_VINCD.NameParameterName  = "VINCDNM";
                //this.cdx02_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx02_VINCD.SetCodePixedLength();
                //this.cdx02_VINCD.PrefixCode = "A3";

                DataSet ds1 = this.GetDataSourceSchema("Code", "CodeValue");
                ds1.Tables[0].Rows.Add("Y", "Y");
                ds1.Tables[0].Rows.Add("N", "N");
                this.cbo01_HANIL_VINCD_YN.DataBind(ds1.Tables[0], false);                

                //this.cdx02_CUSTCD.HEPopupHelper     = new PD20034P1();
                //this.cdx02_CUSTCD.PopupTitle        = "고객코드";
                //this.cdx02_CUSTCD.CodeParameterName = "CUSTCD";
                //this.cdx02_CUSTCD.NameParameterName = "CUSTNM";
                //this.cdx02_CUSTCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                DataSet BizCD = this.GetBizCD(this.UserInfo.CorporationCode);
                DataSet CorCd   = this.GetCorCD();


                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "법인", "CORCD","CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "모델코드", "MODELCD","MODELCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 200, "당사차종유무", "HANIL_VINCD_YN", "HANIL_VINCD_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "고객사코드", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적용시작일자", "BEG_DATE", "APPLY_BEG_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적용종료일자", "END_DATE", "APPLY_END_DATE");

                //this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 120, "고객코드", "CUSTCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, BizCD.Tables[0], "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, CorCd.Tables[0], "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, GetCustCD(this.UserInfo.CorporationCode).Tables[0], "CUSTCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");
                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                this.SetRequired(this.lbl02_MODELCD, this.lbl02_VINCD, this.lbl01_HANIL_VINCD_YN, this.lbl01_CUSTCD);
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
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "MODELCD", "VINCD", "CUSTCD", "HANIL_VINCD_YN", "BEG_DATE", "END_DATE");

                if (_CORCD.Length == 0 || _BIZCD.Length == 0)
                {
                    _CORCD = this.UserInfo.CorporationCode;
                    _BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                }

                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.txt02_MODELCD.GetValue(),
                    this.cdx02_VINCD.GetValue(),
                    this.cdx01_CUSTCD.GetValue(),
                    this.cbo01_HANIL_VINCD_YN.GetValue(),
                    this.dte01_APPLY_BEG_DATE.GetDateText(),
                    this.dte01_APPLY_END_DATE.GetDateText()
                );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 고객차종대 당사 차종 연결 정보가 저장되었습니다");                
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다.
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "MODELCD");

                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.txt02_MODELCD.GetValue()
                );

                if (!this.IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 고객차종대 당사 차종 연결 정보가 삭제되었습니다");
                MsgCodeBox.Show("CD00-0010"); //정상적으로 삭제되었습니다.
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD",    this.cbo01_BIZCD.GetValue());
                set.Add("MODELCD",  this.txt01_MODELCD.GetValue());
                set.Add("VINCD",    this.cdx01_VINCD.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet Inquery = _WSCOM.Inquery(set);
                DataSet Inquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.grd01.SetValue(Inquery);
                this.AfterInvokeServer();
                ShowDataCount(Inquery);

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
                _CORCD = "";
                _BIZCD = "";
                this.txt02_MODELCD.Initialize();
                this.cdx02_VINCD.Initialize();
                this.cbo01_HANIL_VINCD_YN.Initialize();
                this.cdx01_CUSTCD.Initialize();
                this.dte01_APPLY_BEG_DATE.SetMMFromStart();
                this.dte01_APPLY_END_DATE.SetFromEnd();
                this.txt02_MODELCD.SetReadOnly(false);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;

                _CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                _BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();

                string MODELCD = this.grd01[row, "MODELCD"].ToString();
                string HANIL_VINCD_YN  = this.grd01[row, "HANIL_VINCD_YN"].ToString();
                string VINCD   = this.grd01[row, "VINCD"].ToString();

                this.txt02_MODELCD.SetValue(MODELCD);
                this.cbo01_HANIL_VINCD_YN.SetValue(HANIL_VINCD_YN);
                this.cdx02_VINCD.SetValue(VINCD);
                this.cdx01_CUSTCD.SetValue(this.grd01[row, "CUSTCD"].ToString());                
                this.dte01_APPLY_BEG_DATE.SetValue(this.grd01[row, "BEG_DATE"].ToString());
                this.dte01_APPLY_END_DATE.SetValue(this.grd01[row, "END_DATE"].ToString());

                this.txt02_MODELCD.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        public bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장 할 고객차종대 당사 차종 연결 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                DataRow row = source.Tables[0].Rows[0];

                string MODELCD = row["MODELCD"].ToString();
                string VINCD   = row["VINCD"].ToString();
                string CUSTCD = row["CUSTCD"].ToString();

                if (this.GetByteCount(MODELCD) == 0)
                {
                    //MsgBox.Show("모델코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("MODELCD"));
                    return false;
                }

                if (this.GetByteCount(MODELCD) > 10)
                {
                    //MsgBox.Show("모델코드는 10자리를 넘을 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0081", this.GetLabel("MODELCD"), "10");
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종 코드가 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0080", this.GetLabel("VINCD"));
                    return false;
                }

                if (this.GetByteCount(CUSTCD) == 0)
                {
                    
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("CUSTCD")); //고객코드가 입력되지 않았습니다.
                    return false;
                }
                
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK) //데이터를 저장하시겠습니까?
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }
        }

        public bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (!this.txt02_MODELCD.ReadOnly)
                {
                    MsgCodeBox.Show("PD00-0059"); //데이터 입력 대기 상태에서는 삭제 기능을 사용할 수 없습니다.
                    return false;
                }

                DataRow row     = source.Tables[0].Rows[0];
                string  MODELCD = row["MODELCD"].ToString();

                if (this.GetByteCount(MODELCD) == 0)
                {
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
