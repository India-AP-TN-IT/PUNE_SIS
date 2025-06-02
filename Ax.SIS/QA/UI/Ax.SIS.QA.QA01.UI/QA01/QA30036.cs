#region ▶ Description & History
/* 
 * 프로그램명 : 검사원 자격 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : ㅂ명희
 * 최종수정일 : 2013-12-10
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2013-12-10	    배명희		[#001] 인증일자, 갱신일자 항목 변경 -> 등록일자, 승인/갱신일자, 승인대상년도, 승인만료일자, 차기갱신일자
 *				2015-07-27      배명희      통합WCF로 변경 
 *
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
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>검사원 자격 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-28 오전 9:51:59<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-28 오전 9:51:59   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30036 : AxCommonBaseControl
    {
        //private IQA30036 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30036";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA30036()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30036>("QA01", "QA30036.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");

            _WSCOM_N = new AxClientProxy();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;
                
                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                HEParameterSet paramSet_LICENSECD = new HEParameterSet();
                paramSet_LICENSECD.Add("CORCD", _CORCD);
                paramSet_LICENSECD.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);

                //DataSet source_LICENSECD = _WSCOMBOBOX.Inquery_LICENSECD(paramSet_LICENSECD);
                DataSet source_LICENSECD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_LICENSECD"), paramSet_LICENSECD);
                this.cbo01_LICENSECD.DataBind(source_LICENSECD.Tables[0]);
                this.cbo01_LICENSECD.DropDownStyle = ComboBoxStyle.DropDownList;


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.AfterInvokeServer();

                this.grd01_QA30036.AllowEditing = false;
                this.grd01_QA30036.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30036.Initialize();
                this.grd01_QA30036.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30036.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "검사원사번", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "인증번호", "CERTNO", "CERTNO");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "등록일자", "CERT_DATE","REG_DATE");                //[#001]
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "승인/갱신일자", "RENEWAL_DATE", "RENEWAL_DATE");        //[#001]  
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "승인대상년도", "CERT_YEAR", "CERT_YEAR");            //[#001]
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "승인 만료일자", "RENEW_DATE", "ACC_EXP_DATE");           //[#001]
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "차기 갱신일자", "NEXT_RENEWAL_DATE", "NEXT_RENEWAL_DATE");   //[#001]
                this.grd01_QA30036.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "자격코드", "LICENSECD", "LICENSECD");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "자격명", "LICENSENM", "LICENSENM");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "경력", "CARRIER", "CARRIER");
                this.grd01_QA30036.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "소속", "DEPT", "DEPTNM");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "소속", "DEPTNM", "DEPTNM");
                this.grd01_QA30036.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "검사원", "INSPECT_EMPNM", "INSPECT_EMPNM");
                //this.grd01_QA30036.AddColumn(false, true, HEFlexGrid.FtextAlign.C, 60, "갱신대상", "RENEW_LICENSE");         //[#001] 갱신대상 화면에 표시안함.
                this.grd01_QA30036.SetColumnType(AxFlexGrid.FCellType.Decimal, "CARRIER");
                this.grd01_QA30036.SetColumnType(AxFlexGrid.FCellType.Date, "CERT_DATE");
                this.grd01_QA30036.SetColumnType(AxFlexGrid.FCellType.Date, "RENEWAL_DATE");
                this.grd01_QA30036.SetColumnType(AxFlexGrid.FCellType.Date, "RENEW_DATE");
                this.grd01_QA30036.SetColumnType(AxFlexGrid.FCellType.Date, "NEXT_RENEWAL_DATE");

                this.SetRequired(lbl01_BIZNM, lbl01_CERT_YEAR);

                //this.dte01_CERT_DATE_FROM.SetMMFromStart();

                //this.dte01_CERT_DATE_FROM.SetValue(this.dte01_CERT_DATE_FROM.GetValue().ToString().Substring(0, 8) + "01");   //[#001] 필요없는 로직 주석 처리.

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
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
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string LICENSECD = this.cbo01_LICENSECD.GetValue().ToString();
                string INSPECT_EMPNO = this.txt01_INSPECT_EMPNO_EMPNM.GetValue().ToString();
                string RENEW_LICENSE = this.chk01_RENEW_LICENSE.GetValue().ToString();
                string CERT_DATE_FROM = this.dte01_CERT_DATE_FROM.GetDateText().Substring(0, 4);
                string CERT_DATE_TO = this.dte01_CERT_DATE_TO.GetDateText().Substring(0, 4);

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.15 공장구분 조회조건 추가 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("LICENSECD", LICENSECD);
                paramSet.Add("INSPECT_EMPNO", INSPECT_EMPNO);
                paramSet.Add("RENEW_LICENSE", RENEW_LICENSE);
                paramSet.Add("CERT_DATE_FROM", CERT_DATE_FROM);
                paramSet.Add("CERT_DATE_TO", CERT_DATE_TO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.15 공장구분 조회조건 추가 (배명희)

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30036.SetValue(source);
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
    }
}
