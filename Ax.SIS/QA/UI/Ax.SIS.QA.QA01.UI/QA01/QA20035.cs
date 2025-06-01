#region ▶ Description & History
/* 
 * 프로그램명 : 검사원 자격 갱신
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
    /// <b>검사원 자격 갱신</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-28 오전 9:49:47<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-28 오전 9:49:47   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20035 : AxCommonBaseControl
    {
        //private IQA20035 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20035";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [ 초기화 작업 정의 ]

        public QA20035()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20035>("QA01", "QA20035.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
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
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                //공장구분-------------------------------------------------------------------------
                DataTable source = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in source.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(source, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                //---------------------------------------------------------------------------------

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                HEParameterSet paramSet_LICENSECD = new HEParameterSet();
                paramSet_LICENSECD.Add("CORCD", _CORCD);
                paramSet_LICENSECD.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);

                //DataSet source_LICENSECD = _WSCOMBOBOX.Inquery_LICENSECD(paramSet_LICENSECD);
                DataSet source_LICENSECD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_LICENSECD"), paramSet_LICENSECD);

                this.cbo01_LICENSECD.DataBind(source_LICENSECD.Tables[0]);
                this.cbo01_LICENSECD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.AfterInvokeServer();

                this.grd01_QA20035.AllowEditing = true;
                this.grd01_QA20035.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20035.Initialize();
                this.grd01_QA20035.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA20035.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20035.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20035.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "검사원사번", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "인증번호", "CERTNO", "CERTNO");
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "등록일자", "CERT_DATE","REG_DATE");                  //[#001]
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "승인/갱신일자", "RENEWAL_DATE", "RENEWAL_DATE");          //[#001]
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "승인대상년도", "CERT_YEAR", "CERT_YEAR");              //[#001]
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "승인 만료일자", "RENEW_DATE", "ACC_EXP_DATE");             //[#001]
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "차기 갱신일자", "NEXT_RENEWAL_DATE", "NEXT_RENEWAL_DATE");      //[#001]
                this.grd01_QA20035.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "자격코드", "LICENSECD", "LICENSECD");
                this.grd01_QA20035.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "자격명", "LICENSENM", "LICENSENM");
                //this.grd01_QA20035.AddColumn(false, true, HEFlexGrid.FtextAlign.R, 80, "경력(년)", "CARRIER","");
                this.grd01_QA20035.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "경력", "CARRIER", "CARRIER");
                this.grd01_QA20035.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "소속", "DEPT", "DEPTNM");
                this.grd01_QA20035.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "소속", "DEPTNM", "DEPTNM");
                this.grd01_QA20035.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사원", "INSPECT_EMPNM", "INSPECT_EMPNM");
                this.grd01_QA20035.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 280, "갱신대상자", "RENEW_LICENSE", "RENEW_LICENSE");            //[#001] 체크박스 컬럼으로 설정
                this.grd01_QA20035.SelectionMode = SelectionModeEnum.ListBox;
                this.grd01_QA20035.SetColumnType(AxFlexGrid.FCellType.Date, "CERT_DATE");
                this.grd01_QA20035.SetColumnType(AxFlexGrid.FCellType.Date, "RENEWAL_DATE");
                this.grd01_QA20035.SetColumnType(AxFlexGrid.FCellType.Date, "RENEW_DATE");
                this.grd01_QA20035.SetColumnType(AxFlexGrid.FCellType.Date, "NEXT_RENEWAL_DATE");
                this.grd01_QA20035.Styles.Add("BtnQuery_Click").BackColor =  System.Drawing.Color.FromArgb(255, 255, 200);
                this.grd01_QA20035.SetColumnType(AxFlexGrid.FCellType.Check, "RENEW_LICENSE");                                  //[#001] 체크박스 컬럼으로 설정
                this.SetRequired(lbl01_BIZNM, lbl02_ACC_EXP_DATE);

                this.BtnReset_Click(null, null);
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
                foreach (Control ctl in groupBox_QA20035_MSG1.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.grd01_QA20035.SelectionMode = SelectionModeEnum.ListBox;

                this.chk01_RENEW_LICENSE.SetValue("Y");
                this.BtnQuery_Click(null, null);
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
                string CERT_YEAR = this.txt01_CERT_YEAR.GetValue().ToString();          //[#001] 승인대상년도 조회조건 추가함.
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("LICENSECD", LICENSECD);
                paramSet.Add("INSPECT_EMPNO", INSPECT_EMPNO);
                paramSet.Add("RENEW_LICENSE", RENEW_LICENSE);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("CERT_YEAR", CERT_YEAR);                                   //[#001] 승인대상년도 조회조건 추가함.
                paramSet.Add("PLANT_DIV", PLANT_DIV);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20035.SetValue(source);

                if (grd01_QA20035.Rows.Count > 1)
                {
                    CellRange cr1 = new CellRange();
                    //CellRange cr2 = new CellRange();
                    cr1 = grd01_QA20035.GetCellRange(1, grd01_QA20035.Cols["CERTNO"].Index, grd01_QA20035.Rows.Count - 1, grd01_QA20035.Cols["RENEW_DATE"].Index);
                    //cr2 = grd01_QA20035.GetCellRange(1, grd01_QA20035.Cols["CARRIER"].Index, grd01_QA20035.Rows.Count - 1, grd01_QA20035.Cols["CARRIER"].Index);

                    cr1.Style = grd01_QA20035.Styles["BtnQuery_Click"];
                    //cr2.Style = grd01_QA20035.Styles["BtnQuery_Click"];
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01_QA20035.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "INSPECT_EMPNO", "LICENSECD", "RENEW_DATE", "CERTNO", "CERT_DATE", "CARRIER",
                    "RENEWAL_DATE", "CERT_YEAR", "NEXT_RENEWAL_DATE", "USERID");//[#001] 저장 대상 추가

                //[#001] 저장시 로그인유저 이력 남김.
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["USERID"] = this.UserInfo.EmpNo;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                
                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("검사원 자격 갱신이 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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

        #region [ 기타 이벤트 정의 ]

        private void btn02_ALL_CHANGE_Click(object sender, EventArgs e)
        {
            try
            {
                //[#001] 갱신대상 체크박스 선택한 항목에 대하여 일괄변경 적용
                for (int i = this.grd01_QA20035.Rows.Fixed; i < grd01_QA20035.Rows.Count; i++)
                {
                    if (this.grd01_QA20035.GetValue(i, "RENEW_LICENSE").ToString().Equals("Y"))
                    {
                        
                        this.grd01_QA20035.SetData(i, "RENEW_DATE", this.dte02_RENEW_DATE.Value.ToString(this.grd01_QA20035.Cols["RENEW_DATE"].Format));               //승인만료일자UPDATE
                        this.grd01_QA20035.SetData(i, "CERT_YEAR", this.dte02_CERT_YEAR.Value.ToString("yyyy"));                 //승인대상년도UPDATE
                        this.grd01_QA20035.SetData(i, "RENEWAL_DATE", this.dte02_RENEWAL_DATE.Value.ToString(this.grd01_QA20035.Cols["RENEWAL_DATE"].Format));           //승인/갱신일자UPDATE
                        this.grd01_QA20035.SetData(i, "NEXT_RENEWAL_DATE", this.dte02_NEXT_RENEWAL_DATE.Value.ToString(this.grd01_QA20035.Cols["NEXT_RENEWAL_DATE"].Format)); //차기갱신일자UPDATE

                        this.grd01_QA20035[i, 0] = "U";
                    }
                }


                //foreach (Row row in grd01_QA20035.Rows.Selected)
                //{
                //    if (!IsALL_CHK_Valid(row.Index)) return;
                //    this.grd01_QA20035.SetData(row.Index, "RENEW_DATE", this.dte02_RENEW_DATE.GetValue().ToString());
                //    this.grd01_QA20035[row.Index, 0] = "U";
                //}

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("변경된 데이터가 존재하지 않아 저장할 수 없습니다.");
                    MsgCodeBox.Show("QA01-0021");
                    return false;
                } 

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsALL_CHK_Valid(int ROW)
        {
            try
            {
                if (ROW <= 0)
                {
                    //MsgBox.Show("선택한 그리드 데이터가 없습니다.");
                    MsgCodeBox.Show("QA00-009");
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }        

        #endregion

        
    }
}
