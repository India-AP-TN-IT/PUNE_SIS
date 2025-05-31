#region ▶ Description & History
/* 
 * 프로그램명 : PD40500 전산보전이력관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
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

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 통전 검사 항목 그룹
    /// </summary>
    public partial class PD40500 : AxCommonBaseControl
    {
        //private IPD40500 _WSCOM;
        private AxClientProxy _WSCOM_N;
        
        private AxComboList grd_LINECD;
        private string PACKAGE_NAME = "APG_PD40500";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
            
        public PD40500()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40500>("PD", "PD40500.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            
            this.grd_LINECD = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable CORCD = this.GetCorCD().Tables[0];
                DataTable BIZCD = this.GetBizCD(this.UserInfo.CorporationCode).Tables[0];

                this.grd_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_LINECD_BeforeOpen);
               
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD", "COR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "처리일자", "PROD_DATE", "PROC_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "처리시간", "PROD_TIME", "PROC_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "공정코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "공정", "PROCNM", "PROCINFO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "SEQ", "SEQ", "SEQ");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "대분류", "NM1", "LCLASS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "중분류", "NM2", "MCLASS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "처리", "NM3", "PROCESS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "원인", "CAUSE", "ODD_REASON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "조치내용", "PROC_METHOD", "MGRT_CNTT");
                
                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, CORCD, "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, BIZCD, "BIZCD");

                this.grd01.Cols["CORCD"].AllowMerging = true;
                this.grd01.Cols["BIZCD"].AllowMerging = true;

                this.cbo01_CORCD.DataBind(CORCD);
                this.cbo01_BIZCD.DataBind(BIZCD);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetReadOnly(true);

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);

                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST(set2).Tables[0];
                //DataTable source3 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];
                DataTable source3 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];

                this.cbl02_INSTALL_POS.DataBind(source2, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명
                this.cbl01_LINECD.DataBind(source3, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
                
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
                
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", cbl02_INSTALL_POS.GetValue().ToString().Replace("A7",""));
                set.Add("PROD_DATE", heDateEdit1.GetDateText());
                set.Add("PROD_DATE2", heDateEdit2.GetDateText());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                //this.ShowMessage(source.Tables[0].Rows.Count.ToString() + "건 조회 되었습니다.");
                //{0} 개의 데이터가 조회 되었습니다.
                //MsgCodeBox.ShowFormat("CD00-0078", source.Tables[0].Rows.Count.ToString());

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
                /*
                 *  IN_CORCD           IN  VARCHAR2,
        IN_BIZCD           IN  VARCHAR2,
        IN_LINECD					 IN  VARCHAR2,
        IN_PROCCD					 IN  VARCHAR2,
        IN_INSTALL_POS		 IN  VARCHAR2,
        IN_PROD_DATE			 IN  VARCHAR2,
        IN_SEQ						 IN  VARCHAR2,
        IN_CAUSE				   IN  VARCHAR2,
        IN_PROC_METHOD	   IN  VARCHAR2
                 */
                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;
                DataSet source = GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "PROCCD", "INSTALL_POS", "PROD_DATE", "SEQ", "CAUSE", "PROC_METHOD");
                source.Tables[0].Rows.Add(
                    this.grd01.GetValue(row, "CORCD").ToString(),
                    this.grd01.GetValue(row, "BIZCD").ToString(),
                    this.grd01.GetValue(row, "LINECD").ToString(),
                    this.grd01.GetValue(row, "PROCCD").ToString(),
                    this.grd01.GetValue(row, "INSTALL_POS").ToString(),
                    this.grd01.GetValue(row, "PROD_DATE").ToString(),
                    this.grd01.GetValue(row, "SEQ").ToString(),
                    heTextBox1.GetValue(),
                    heTextBox2.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.cbo01_BIZCD.GetValue().ToString(), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.cbo01_BIZCD.GetValue().ToString());
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝
                
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 완제품 팔레트 정보가 저장되었습니다.");
                //저장되었습니다.
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "LODTBL_NO");

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.cbo01_BIZCD.GetValue().ToString(), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK =  this.DN_MESCODE(this.cbo01_BIZCD.GetValue().ToString());
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 완제품 팔레트 정보가 삭제되었습니다");
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
        
        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);

                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST(set2).Tables[0];
                DataTable source3 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];                
                //DataTable source3 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];

                this.cbl02_INSTALL_POS.DataBind(source2, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명
                this.cbl01_LINECD.DataBind(source3, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];

                this.grd_LINECD.DataBind(source, "LINECD", "LINECD", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "BIZCD", this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(i, "BEG_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                    this.grd01.SetValue(i, "END_DATE", "9998-12-31");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }        
        
        private void grd01_SelChange(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;
            if (row < this.grd01.Rows.Fixed) return;
            heTextBox1.SetValue(grd01.GetValue(row,"CAUSE"));
            heTextBox2.SetValue(grd01.GetValue(row,"PROC_METHOD"));
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 완제품 팔레트 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string LODTBL_NO = this.grd01.GetValue(i, "LODTBL_NO").ToString();

                    if (this.GetByteCount(LODTBL_NO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {팔레트 ID} 가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", i.ToString(), this.grd01.Cols[3].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(LODTBL_NO) > 12)
                    {
                        //MsgBox.Show(i + " 번째 행에 팔레트 ID는 12byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", i.ToString(), this.grd01.Cols[3].Caption.ToString(), "12");
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 완제품 팔레트 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 완제품 팔레트 정보가 존재하지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 완제품 팔레트 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
