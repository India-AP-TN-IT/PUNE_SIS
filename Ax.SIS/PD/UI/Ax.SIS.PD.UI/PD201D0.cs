#region ▶ Description & History
/* 
* 프로그램명 : PD201D0 초중종품 마스터 관리
* 설     명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*/
#endregion
using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using System.Drawing;
using System.ComponentModel;
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    
    /// <summary>
    /// 공정별 작업표준서
    /// </summary>
    public partial class PD201D0 : AxCommonBaseControl
    {
        private byte[] _FILE;
        private bool _IsBinded;
        //private IPD20115 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD201D0";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        //private IPDCOMMON_ERM _WSCOM_ERM;

        #region [ 초기화 작업 정의 ] 
        public PD201D0()
        {
            _FILE = null;
            _IsBinded = false;

            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20115>("PD", "PD20115.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;               
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.PopMenuVisible = true;


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "법인", "CORCD", "COR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 090, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "검사명", "CHK_TITLE", "CHK_TITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "출력순서", "CHKCD", "PRINT_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "사용유무", "USE_YN", "CHK_USE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "파일명", "FILE_NAME", "FILE_NAME5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "품번", "PARTNO", "PARTNOTITLE");

                this.grd02.AllowEditing = true;
                this.grd02.PopMenuVisible = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체코드", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "업체명", "VENDNM", "VENDNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "담당자명", "TR_NAME", "CHR_NM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "이메일", "TR_EMAIL", "CHR_EMAIL");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "연락처", "TR_MP", "CHR_TEL");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 180, "코드", "TR_SEQ", "CODE");

                this.grd03.AllowEditing = true;
                this.grd03.PopMenuVisible = true;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "담당자유형", "SM_RETY", "CHR_TYPE"); 
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "담당자사번", "EMPNO", "EMPNO3");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "담당자명", "EMPNM", "CHR_NM");


                this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q7", "SM_RETY");



                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));


                #region
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", cbo01_BIZCD.GetValue());
                set1.Add("PRDT_DIV", "");
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set1).Tables[0];
                //DataTable source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set1).Tables[0];

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0];                

                HEParameterSet set3 = new HEParameterSet();
                set3.Add("LANG_SET", this.UserInfo.Language);
                set3.Add("CORCD", this.UserInfo.CorporationCode);
                set3.Add("BIZCD", this.cbo01_BIZCD.GetValue());

                DataTable source3 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CARTYPE"), set3).Tables[0];
                //DataTable source3 = _WSCOM_ERM.INQUERY_COMBO_CARTYPE(set3).Tables[0];                

                #endregion


                this.cbl01_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
                this.cbl02_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
                this.cbl01_INSTALL_POS.DataBind(source2, "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");  //타입코드;타입명
                this.cbl02_INSTALL_POS.DataBind(source2, "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");  //"타입코드;타입명"

                this.SetRequired(lbl02_LINE,  lbl02_POSTITLE, lbl02_PRINT_SEQ, lbl02_FILE_NAME5);
                
                this.txt02_FILE_NAME.SetReadOnly(true);

                this.txt02_DISP_SEQ.SetValid(2, AxTextBox.TextType.OnlyNumber);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);


                this.cdx04_EMPNO.HEPopupHelper = new CM30020P1();
                this.cdx04_EMPNO.PopupTitle = this.GetLabel("EMPINFO"); // "사원정보"; 
                this.cdx04_EMPNO.CodeParameterName = "EMPNO";
                this.cdx04_EMPNO.NameParameterName = "NAME_KOR";
                this.cdx04_EMPNO.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx04_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);


                cdx03_VENDCD.HEPopupHelper = new CM20017P1();
                cdx03_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                cdx03_VENDCD.CodeParameterName = "VENDCD";
                cdx03_VENDCD.NameParameterName = "VENDNM";
                cdx03_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx03_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);
                cdx03_VENDCD.HEUserParameterSetValue("PURC_TYPE", "AMD");

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
            try
            {
                _FILE = null;
                _IsBinded = false;

                this.cbl02_LINECD.Initialize();
                this.cbl02_INSTALL_POS.Initialize();
                this.txt02_DISP_SEQ.Initialize();
                this.txt02_FILE_NAME.Initialize();
                this.txt02_CHK_TITLE.Initialize();
                this.txt02_CHK_COMMENT.Initialize();
                this.btn02_CONFIRM.SetReadOnly(true);
                this.cbl02_LINECD.SetReadOnly(false);
                this.cbl02_INSTALL_POS.SetReadOnly(false);
                txt02_PARTNO.Initialize();
                
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
                string bizcd = cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());                
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSaveValid()) return;

                string CORCD = this.UserInfo.CorporationCode;
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "INSTALL_POS", "CD", "BLOB$FILE_IMAGE", "RESP","USE_YN", "TITLE","COMMENT","FILE_NAME", "PARTNO");

                

                source.Tables[0].Rows.Add(
                    CORCD,
                    this.UserInfo.BusinessCode,
                    LINECD,                    
                    INSTALL_POS,
                    this.txt02_DISP_SEQ.GetValue(),                    
                    _FILE,
                    "1",
                    chk01_CHK_USE.Checked ? "1" : "0",
                    txt02_CHK_TITLE.GetValue().ToString(),
                    txt02_CHK_COMMENT.GetValue().ToString(),
                    txt02_FILE_NAME.GetValue().ToString(),
                    string.IsNullOrEmpty(txt02_PARTNO.GetValue().ToString()) ? " " : txt02_PARTNO.GetValue().ToString()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);

              
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                

                //MsgBox.Show("입력하신 공정별 작업표준서 정보가 저장되었습니다.");
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
        
        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeleteValid()) return;

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "INSTALL_POS", "CD", "PARTNO");

                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.UserInfo.BusinessCode,
                    this.cbl02_LINECD.GetValue(),                    
                    this.cbl02_INSTALL_POS.GetValue(),
                    this.txt02_DISP_SEQ.GetValue(),
                    string.IsNullOrEmpty(txt02_PARTNO.GetValue().ToString()) ? " " : txt02_PARTNO.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 공정별 작업표준서 정보가 삭제되었습니다");
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
        
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;
                
                string CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                string BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();
                string LINECD = this.grd01.GetValue(row, "LINECD").ToString();
                string INSTALL_POS = this.grd01.GetValue(row, "INSTALL_POS").ToString();
                string CHKCD = this.grd01.GetValue(row, "CHKCD").ToString();
                string FILE_NAME = this.grd01.GetValue(row, "FILE_NAME").ToString();
                string PARTNO = this.grd01.GetValue(row, "PARTNO").ToString();
                this.Inquery(CORCD, BIZCD, LINECD, INSTALL_POS, CHKCD, PARTNO);

                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void btn02_FILE_FIND_Click(object sender, EventArgs e)
        {
            FileStream oFile = null;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                //파일 선택 필터
                ofd.Title = this.GetLabel("ATTACH_PDF"); //(작업 표준서) PDF 파일 선택
                ofd.Filter = FileFilter.imageString;
                ofd.FilterIndex = 0;

                //파일 선택 되면
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    //PDF 파일을 읽어서 Grid 등록 처리함
                    oFile = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);

                    byte[] cFileBuf = new byte[oFile.Length];

                    oFile.Read(cFileBuf, 0, Convert.ToInt32(oFile.Length));


                    //파일명
                    this.txt02_FILE_NAME.SetValue(ofd.SafeFileName);

                    //파일 이미지
                    _FILE = cFileBuf;

                    oFile.Close();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (oFile != null)
                    oFile.Close();
            }
        }

        private void btn02_CONFIRM_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = this.GetLabel("ATTACH_PDF"); //PDF 파일 선택
                sfd.Filter = FileFilter.imageString;
                sfd.FilterIndex = 0;

                sfd.FileName = this.txt02_FILE_NAME.GetValue().ToString();

                if (sfd.ShowDialog() != DialogResult.OK) return;

                string fileName = sfd.FileName;

                int ArraySize = _FILE.GetUpperBound(0);
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(_FILE, 0, ArraySize + 1);
                stream.Close();

                Process.Start(sfd.FileName, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn03_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string CORCD = this.UserInfo.CorporationCode;
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();



                //CORCD,BIZCD,LINECD,INSTALL_POS,CHKCD,VENDCD,TR_SEQ,TR_NAME,TR_EMAIL,TR_MP
                this.BeforeInvokeServer(true);
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "INSTALL_POS", "CD", "VENDCD", "TR_NAME", "TR_EMAIL", "TR_MP");
                DataSet selectedDS = grd02.GetValue(AxFlexGrid.FActionType.Save, "VENDCD", "TR_NAME", "TR_EMAIL", "TR_MP");
                for (int row = 0; row < selectedDS.Tables[0].Rows.Count; row++)
                {

                    source.Tables[0].Rows.Add(
                        CORCD,
                        this.UserInfo.BusinessCode,
                        LINECD,
                        INSTALL_POS,
                        this.txt02_DISP_SEQ.GetValue(),
                        selectedDS.Tables[0].Rows[row]["VENDCD"].ToString(),
                        selectedDS.Tables[0].Rows[row]["TR_NAME"].ToString(),
                        selectedDS.Tables[0].Rows[row]["TR_EMAIL"].ToString(),
                        selectedDS.Tables[0].Rows[row]["TR_MP"].ToString()
                        );





                }
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_TR"), source);
                this.AfterInvokeServer();

                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

        }

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
            

            PopupHelper helper = null;

            CM20017P1 _bm1 = new CM20017P1();
            _bm1.Initialize_Helper(cdx03_VENDCD);
            
            helper = new PopupHelper(_bm1, this.GetLabel("VENDCD"));// "업체코드"); //@@@

            helper.ShowDialog();

            if (helper.SelectedData != null)
            {
                DataRow row = (DataRow)helper.SelectedData;

                this.grd02.SetValue(this.grd02.Row, "VENDCD", row["VENDCD"]);
                this.grd02.SetValue(this.grd02.Row, "VENDNM", row["VENDNM"]);
            }
        }

        private void grd03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string colName = this.grd03.Cols[this.grd03.Col].Name;

            if (colName == "EMPNO" || colName == "EMPNM")
            {
                PopupHelper helper = null;

                CM30020P1 _bm1 = new CM30020P1();
                _bm1.Initialize_Helper(cdx03_VENDCD);

                helper = new PopupHelper(_bm1, this.GetLabel("EMPINFO")); //"사원정보"); //@@@

                helper.ShowDialog();

                if (helper.SelectedData != null)
                {
                    DataRow row = (DataRow)helper.SelectedData;

                    if (row["USER_DIV"].ToString() != "T12")
                    {
                        MsgCodeBox.Show("CD00-0124");
                        return;
                    }

                    this.grd03.SetValue(this.grd03.Row, "EMPNO", row["EMPNO"]);
                    this.grd03.SetValue(this.grd03.Row, "EMPNM", row["NAME_KOR"]);
                }

            }
        }

        private void btn04_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                string CORCD = this.UserInfo.CorporationCode;
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                if (string.IsNullOrEmpty(LINECD) == true)
                {
                    MsgCodeBox.Show("PD00-0039");
                    return;
                }

                //if (string.IsNullOrEmpty(INSTALL_POS) == true)
                //{
                //    MsgCodeBox.Show("PM00-0007");
                //    return;
                //}

                this.BeforeInvokeServer(true);
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "INSTALL_POS", "CD", "SM_RETY", "EMPNO");
                DataSet selectedDS = grd03.GetValue(AxFlexGrid.FActionType.Save, "EMPNO", "SM_RETY");
                for (int row = 0; row < selectedDS.Tables[0].Rows.Count; row++)
                {

                    source.Tables[0].Rows.Add(
                        CORCD,
                        this.UserInfo.BusinessCode,
                        LINECD,
                        INSTALL_POS,
                        this.txt02_DISP_SEQ.GetValue(),
                        selectedDS.Tables[0].Rows[row]["SM_RETY"].ToString(),
                        selectedDS.Tables[0].Rows[row]["EMPNO"].ToString()
                        );





                }
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_EMP"), source);
                this.AfterInvokeServer();

                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn03_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeleteValid()) return;

                string CORCD = this.UserInfo.CorporationCode;
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "INSTALL_POS", "CD", "VENDCD","TR_SEQ");

                DataSet selectedDS = grd02.GetValue(AxFlexGrid.FActionType.Remove, "VENDCD", "TR_SEQ");
                for (int row = 0; row < selectedDS.Tables[0].Rows.Count; row++)
                {

                    source.Tables[0].Rows.Add(
                        CORCD,
                        this.UserInfo.BusinessCode,
                        LINECD,
                        INSTALL_POS,
                        this.txt02_DISP_SEQ.GetValue(),
                        selectedDS.Tables[0].Rows[row]["VENDCD"].ToString(),
                        selectedDS.Tables[0].Rows[row]["TR_SEQ"].ToString()
                        );





                }

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_TR"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 공정별 작업표준서 정보가 삭제되었습니다");
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

        private void btn04_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDeleteValid()) return;

                string CORCD = this.UserInfo.CorporationCode;
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                this.BeforeInvokeServer(true);
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "INSTALL_POS", "CD", "EMPNO");
                DataSet selectedDS = grd03.GetValue(AxFlexGrid.FActionType.Remove, "EMPNO");
                for (int row = 0; row < selectedDS.Tables[0].Rows.Count; row++)
                {

                    source.Tables[0].Rows.Add(
                        CORCD,
                        this.UserInfo.BusinessCode,
                        LINECD,
                        INSTALL_POS,
                        this.txt02_DISP_SEQ.GetValue(),
                        selectedDS.Tables[0].Rows[row]["EMPNO"].ToString()
                        );





                }

                
                //_WSCOM.REMOVE(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_EMP"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 공정별 작업표준서 정보가 삭제되었습니다");
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

        private void grd03_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
           
        }

        private void grd03_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            
            
        }

        private void grd03_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", cbo01_BIZCD.GetValue());
            set1.Add("PRDT_DIV", "");
            set1.Add("LANG_SET", this.UserInfo.Language);
            DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set1).Tables[0];
            //DataTable source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set1).Tables[0];
            this.cbl01_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
            this.cbl02_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
        }
        #endregion

        #region [사용자 정의 메서드]
        //this.Inquery(CORCD, BIZCD, LINECD, VINCD, INSTALL_POS, CHKCD);
        private void Inquery(string CORCD, string BIZCD, string LINECD, string INSTALL_POS, string CHKCD, string PARTNO)
        {
            try
            {
                pic02_CHK_IMG.BackgroundImage = null;
                string bizcd = BIZCD;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", LINECD);                
                set.Add("INSTALL_POS", INSTALL_POS);
                set.Add("CD", CHKCD);
                set.Add("PARTNO", PARTNO);
                set.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source = _WSCOM.INQUERY_DETAIL(set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR","OUT_CURSOR1","OUT_CURSOR2");

                if (source.Tables[0].Rows.Count == 0) return;
                grd02.SetValue(source.Tables[1]);
                grd03.SetValue(source.Tables[2]);
                DataRow row = source.Tables[0].Rows[0];

                this.cbl02_LINECD.SetValue(row["LINECD"]);
                this.cbl02_INSTALL_POS.SetValue(row["INSTALL_POS"]);
                this.txt02_DISP_SEQ.SetValue(row["CHKCD"]);
                this.txt02_CHK_TITLE.SetValue(row["CHK_TITLE"]);
                this.txt02_CHK_COMMENT.SetValue(row["CHK_COMMENT"]);

                this.txt02_PARTNO.SetValue(row["PARTNO"]);
                this.txt02_FILE_NAME.SetValue(row["FILE_NAME"]);

                this.cbl02_LINECD.SetReadOnly(true);
                this.cbl02_INSTALL_POS.SetReadOnly(true);

                if (row["CHK_IMG"] != System.DBNull.Value)
                {
                    _FILE = (byte[])row["CHK_IMG"];
                    this.btn02_CONFIRM.SetReadOnly(false);

                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                    pic02_CHK_IMG.BackgroundImage = (Bitmap)tc.ConvertFrom(_FILE);
                    pic02_CHK_IMG.BackgroundImageLayout = ImageLayout.Stretch;
                }
                _IsBinded = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();
                string DISP_SEQ = this.txt02_DISP_SEQ.GetValue().ToString();
                string FILE_NAME = this.txt02_FILE_NAME.GetValue().ToString();

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show("{라인}이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("LINE"));
                    return false;
                }


                if (this.GetByteCount(INSTALL_POS) == 0)
                {
                    //MsgBox.Show("{장착위치}가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("POSTITLE"));
                    return false;
                }

                if (this.GetByteCount(DISP_SEQ) == 0)
                {
                    //MsgBox.Show("{출력순서}가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("PRINT_SEQ"));
                    return false;
                }

                if (this.GetByteCount(FILE_NAME) == 0)
                {
                    //MsgBox.Show("{첨부파일}이 등록되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0010", this.GetLabel("ATTACH_FILE"));
                    return false;
                }

                //if (MsgBox.Show("입력하신 공정별 작업표준서 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private bool IsDeleteValid()
        {
            try
            {
                if (!_IsBinded)
                {
                    //MsgBox.Show("삭제할 공정별 작업표준서 정보가 선택되지 않습니다.");
                    //삭제할 데이터가 선택되지 않았습니다.
                    MsgCodeBox.Show("PD00-0011");
                    return false;
                }

                //if (MsgBox.Show("선택하신 공정별 작업표준서 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
