#region ▶ Description & History
/* 
 * 프로그램명 : PD31350 공수일지 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2015-09-24    오세민   
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;
using System.Windows.Forms;

namespace Ax.SIS.PD.UI
{
    public partial class PD31350 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD31350";
        public PD31350()
        {
            InitializeComponent();
            //_WSCOM = new AxClientProxy("HANILDEV");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                
                this.grd01.Initialize();
                this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange;
                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "납품장소", "LINENM", "DEL_STAGE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "납품차수", "JIS_CNT", "DELI_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "업무유형", "JOB_TYPENM", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "대표ALC", "ALCCD", "ALCCD_REP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "납품수량", "MAT_INPUT_QTY", "DELI_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "검사유무", "INSPECT_YN", "INSPECT_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINNM", "VIN");

                this.grd01.Cols["MAT_INPUT_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAT_INPUT_QTY");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                

                this.cdx01_VENDCD.HEPopupHelper = new CM20017P1();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);

                this.dtp01_INPUT_DATE.SetValue(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new ZZPM25110P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_INPUT_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");


                this.cdx01_CONTCD.HEPopupHelper = new PD31350P1();
                this.cdx01_CONTCD.PopupTitle = this.GetLabel("CONTCD");
                this.cdx01_CONTCD.CodeParameterName = "CONTCD";
                this.cdx01_CONTCD.NameParameterName = "CONTNM";
                this.cdx01_CONTCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_CONTCD.HEUserParameterSetValue("INPUT_DATE", this.dtp01_INPUT_DATE.GetDateText());
                this.cdx01_CONTCD.HEUserParameterSetValue("VENDCD", this.cdx01_VENDCD.GetValue());
                this.cdx01_CONTCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                this.cbo01_INSTALL_POS.DataBind("A7");

                this.txt01_JIS_CNT_FROM.SetValid(AxTextBox.TextType.OnlyNumber);
                this.txt01_JIS_CNT_TO.SetValid(AxTextBox.TextType.OnlyNumber);

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_DELI_DATE, this.lbl01_VEND, this.lbl01_LINECD, this.lbl01_CONTCD, this.lbl01_INSTALL_POS, this.lbl01_DELI_CNT);
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
            this.grd01.InitializeDataSource();            
            
        }

        private DataTable GetDataSource()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("INPUT_DATE", this.dtp01_INPUT_DATE.GetDateText());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("CONTCD", this.cdx01_CONTCD.GetValue());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue());
                paramSet.Add("JIS_CNT_FROM", this.txt01_JIS_CNT_FROM.GetValue());
                paramSet.Add("JIS_CNT_TO", this.txt01_JIS_CNT_TO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);


                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                return source.Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsQueryValidation()) return;
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);                
                
                DataTable source = this.GetDataSource();
                
                this.AfterInvokeServer();

                this.grd01.SetValue(source);

                if (sender != null)
                {
                    if (source.Rows.Count <= 0)
                        MsgCodeBox.Show("CD00-0039"); //조회된 데이터가 없습니다.
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

        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsProcessValidation()) return;

                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("INPUT_DATE", this.dtp01_INPUT_DATE.GetDateText());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("CONTCD", this.cdx01_CONTCD.GetValue());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue());
                paramSet.Add("JIS_CNT_FROM", this.txt01_JIS_CNT_FROM.GetValue());
                paramSet.Add("JIS_CNT_TO", this.txt01_JIS_CNT_TO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);


                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);                
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROCESS"), paramSet);
                this.AfterInvokeServer();


                this.BtnQuery_Click(null, null); //재조회

                //정상적으로 처리되었습니다.
                MsgCodeBox.Show("CD00-0013");



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

        #region [ 유효성 검사 ]

        private bool IsQueryValidation()
        {
            try
            {

                if (this.cbo01_BIZCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                    return false;
                }

                if (this.cdx01_VENDCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_VEND.Text);
                    return false;
                }

                DateTime inputDate = Convert.ToDateTime(this.dtp01_INPUT_DATE.GetValue());
                if (inputDate >= this.GetSysdate())
                {
                    //금일 이전 날짜만 처리 가능합니다
                    MsgCodeBox.Show("PD00-0051");
                    return false;
                }


                if (this.cdx01_LINECD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                    return false;
                }

                if (this.cdx01_CONTCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_CONTCD.Text);
                    return false;
                }

                if (this.cbo01_INSTALL_POS.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_INSTALL_POS.Text);
                    return false;
                }

                if (this.txt01_JIS_CNT_FROM.IsEmpty || this.txt01_JIS_CNT_TO.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_DELI_CNT.Text);
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        private bool IsProcessValidation()
        {
            try
            {

                if (this.cbo01_BIZCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                    return false;
                }

                if (this.cdx01_VENDCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_VEND.Text);
                    return false;
                }


                DateTime inputDate = Convert.ToDateTime(this.dtp01_INPUT_DATE.GetValue());
                if (inputDate >= this.GetSysdate())
                {
                    //금일 이전 날짜만 처리 가능합니다
                    MsgCodeBox.Show("PD00-0051");
                    return false;
                }

                if (this.cdx01_LINECD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                    return false;
                }

                if (this.cdx01_CONTCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_CONTCD.Text);
                    return false;
                }

                if (this.cbo01_INSTALL_POS.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_INSTALL_POS.Text);
                    return false;
                }

                if (this.txt01_JIS_CNT_FROM.IsEmpty || this.txt01_JIS_CNT_TO.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_DELI_CNT.Text);
                    return false;
                }


                DataTable source = this.GetDataSource();
                if (source.Rows.Count <= 0)
                {
                    MsgCodeBox.Show("COM-00021"); //처리할 대상 Data가 없습니다.
                    return false;
                }
                //if (MsgBox.Show("ASN 입고 처리 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("PD00-0050", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ 기타 이벤트 정의 ]
        
        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");            
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());

            this.cdx01_VENDCD_CodeBoxBindingAfter(null, null);
        
        }

        private void dtp01_INPUT_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.cdx01_VENDCD_CodeBoxBindingAfter(null, null);
        }


        private void cdx01_CONTCD_ButtonClickBefore(object sender, EventArgs args)
        {   
            this.cdx01_CONTCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx01_CONTCD.HEUserParameterSetValue("INPUT_DATE", this.dtp01_INPUT_DATE.GetDateText());
            this.cdx01_CONTCD.HEUserParameterSetValue("VENDCD", this.cdx01_VENDCD.GetValue());                
        }
        

        private void cdx01_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx01_CONTCD.Initialize();
            this.cdx01_CONTCD.HEUserParameterSetValue("VENDCD", this.cdx01_VENDCD.GetValue());            
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        //db로부터 현재 일자 가져온다. -- asn 강제입고 처리는 어제 날짜 부터 옛날것만 가능. 오늘일자 것은 정상적인 방식으로 현장에서 처리하여야 함.
        private DateTime GetSysdate()
        {
            try
            {
                return (DateTime)_WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SYSDATE")).Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion

        

    }
}
