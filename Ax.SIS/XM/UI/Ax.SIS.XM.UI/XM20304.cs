#region ▶ Description & History
/* 
 * 프로그램명 : 
 * 설      명 : 
 * 최초작성자 : 이현범
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
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
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;
using System.Drawing;

namespace Ax.SIS.XM.UI
{

    public partial class XM20304 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20304";
        private bool _isLoadCompleted = false;
        private bool isDoubleClick = false;
        private bool isBinding = false;

        public XM20304()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [초기화 설정]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable source2 = this.GetDataSourceSchema("CODE", "CODENAME").Tables[0];
                source2.Rows.Add("Y", "Y");
                source2.Rows.Add("N", "N");

                DataTable dtLangset = this.getLanguageCode();
                this.cbo01_LANGUAGE.DataBind(dtLangset, false);
                this.cbo01_LANGUAGE.SetValue(this.UserInfo.Language);

                this.cdx01_NATIONCD.HEPopupHelper = new CM30010P1("I3", true, false, this.cdx01_NATIONCD);

                //법인정보
                this.grd01.Initialize();               
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "법인코드", "CORCD", "CORCD");
				this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "법인명",  "CORNM", "CORNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "국가코드", "NATIONCD", "NATIONCD");
                this.grd01.AddColumn(true,  true, AxFlexGrid.FtextAlign.L, 100, "국가명",   "NATIONNM", "NATIONNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "통화코드", "COINCD", "COINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "언어코드", "LANGUAGE", "LANGUAGE");
				this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "계정과목", "ACC_TITLE", "ACC_TITLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "사용유무", "USE_YN", "USE_YN3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "정렬순서", "SEQNO", "SORT_SEQ");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "SAP 법인코드", "SAP_CORCD", "SAP_CORCD");

                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "I3", "NATIONCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtLangset, "LANGUAGE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source2, "USE_YN");

                this.grd01.Cols["CORCD"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["CORNM"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["NATIONCD"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["COINCD"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["LANGUAGE"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["ACC_TITLE"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["USE_YN"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["SEQNO"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["SAP_CORCD"].StyleNew.BackColor = Color.LightYellow;

                //사업장정보
                this.grd02.Initialize();
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "사업장코드", "BIZCD", "BIZCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "사업장명", "BIZNM", "BIZNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "법인코드", "CORCD", "CORCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "국가코드", "NATIONCD", "NATIONCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "국가명", "NATIONNM", "NATIONNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "언어코드", "LANGUAGE", "LANGUAGE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "공장달력키", "WORK_CAL", "WORK_CAL");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "SAP 사업장", "SAP_BIZCD", "SAP_BIZCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtLangset, "LANGUAGE");

                this.grd02.Cols["BIZCD"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["BIZNM"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["CORCD"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["NATIONCD"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["LANGUAGE"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["WORK_CAL"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["SORT_SEQ"].StyleNew.BackColor = Color.LightYellow;
                this.grd02.Cols["SAP_BIZCD"].StyleNew.BackColor = Color.LightYellow;

                this.BtnQuery_Click(null, null);

                _isLoadCompleted = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [공용 버튼 이벤트에 대한 정의]

        //현재 선택된 탭의  데이터 조회
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string language = this.cbo01_LANGUAGE.GetValue().ToString();
                string code = this.txt01_CODE.GetValue().ToString();

                this.BeforeInvokeServer(true);
                
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", code);
                    paramSet.Add("LANGUAGE", language);
                    //DataSet source = _WSCOM.XD1400_INQUERY(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD2000_INQUERY"), paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    this.ShowDataCount(source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", code);
                    paramSet.Add("LANGUAGE", language);
                    //DataSet source = _WSCOM.XD2010_INQUERY(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD2010_INQUERY"), paramSet);
                    this.grd02.SetValue(source.Tables[0]);
                    this.ShowDataCount(source);
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

        //현재 선택된 탭의 그리드 초기화
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    this.grd01.InitializeDataSource();
                }
                else if (tabControl1.SelectedIndex == 1)
                {   
                    this.grd02.InitializeDataSource();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        //현재 선택된 탭의 데이터 저장함.
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "CORNM", "NATIONCD", "COINCD", "LANGUAGE", "ACC_TITLE", "USE_YN", "SEQNO", "SAP_CORCD");

                    if (!IsSaveValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.XD1400_SAVE(source);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD2000_SAVE"), source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    DataSet source = grd02.GetValue(AxFlexGrid.FActionType.Save,
                    "BIZCD", "BIZNM", "CORCD", "NATIONCD", "LANGUAGE", "WORK_CAL", "SORT_SEQ", "SAP_BIZCD");

                    if (!IsSaveValid2(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.XD2010_SAVE(source);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD2010_SAVE"), source);
                }
              
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
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

        //현재 선택된 탭의 데이터 삭제함.
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (tabControl1.SelectedIndex == 0) //법인정보 등록 탭
                {

                    DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "LANGUAGE");

                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.XD1400_REMOVE(source);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD2000_REMOVE"), source);
                }
                else if (tabControl1.SelectedIndex == 1) //사업장정보 등록 탭
                {
                    DataSet source = grd02.GetValue(AxFlexGrid.FActionType.Remove, "BIZCD", "LANGUAGE");

                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.XD2010_REMOVE(source);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD2010_REMOVE"), source);
                }

                this.AfterInvokeServer();

                //재조회
                this.BtnQuery_Click(null, null);
                
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

        #region [사용자 정의 메서드]

        //언어 콤보상자용 데이터 조회
        private DataTable getLanguageCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LANG_SET"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        #endregion

        #region [유효성 체크]

        //법인정보(코드) 탭 - (XD2000 데이터) 저장시 유효성 검사
        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow seq = source.Tables[1].Rows[i];

                    string LANGUAGE = this.Nvl(source.Tables[0].Rows[i]["LANGUAGE"], "").ToString();
                    string CORCD = this.Nvl(source.Tables[0].Rows[i]["CORCD"], "").ToString();
                    string CORNM = this.Nvl(source.Tables[0].Rows[i]["CORNM"], "").ToString();
                    string SAP_CORCD = this.Nvl(source.Tables[0].Rows[i]["SAP_CORCD"], "").ToString();
                    /*
                     LANGUAGE", "CODENAME", "TYPE", "DESCRIPTION
                     */

                    if (this.GetByteCount(CORCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 법인코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("CORCD"));
                        return false;
                    }

                    if (this.GetByteCount(CORCD) > 5)
                    {
                        //MsgBox.Show(i + " 번째 행에 법인코드는 5byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.GetLabel("CORCD"), 5);
                        return false;
                    }

                    if (this.GetByteCount(CORNM) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("CORNM"));
                        return false;
                    }

                    if (this.GetByteCount(CORNM) > 100)
                    {
                        //MsgBox.Show(i + " 번째 행에 는 100byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.GetLabel("CORNM"), 100);
                        return false;
                    }

                    if (this.GetByteCount(LANGUAGE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 언어가 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("LANGUAGE"));
                        return false;
                    }

                    if (this.GetByteCount(SAP_CORCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 언어가 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["SAP_CORCD"].Caption);
                        return false;
                    }
                    if (this.GetByteCount(SAP_CORCD) > 4)
                    {
                        //MsgBox.Show(i + " 번째 행에는  4byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.grd01.Cols["SAP_CORCD"].Caption, 4);
                        return false;
                    }
                    
                }

                //if (MsgBox.Show("입력하신  정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        
        //사업장정보 탭 - (XD2010 데이터) 저장시 유효성 검사
        private bool IsSaveValid2(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 메시지  정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow seq = source.Tables[1].Rows[i];

                    string LANGUAGE = this.Nvl(source.Tables[0].Rows[i]["LANGUAGE"], "").ToString();
                    string BIZCD = this.Nvl(source.Tables[0].Rows[i]["BIZCD"], "").ToString();
                    string BIZNM = this.Nvl(source.Tables[0].Rows[i]["BIZNM"], "").ToString();
                    string CORCD = this.Nvl(source.Tables[0].Rows[i]["CORCD"], "").ToString();
                    string SAP_BIZCD = this.Nvl(source.Tables[0].Rows[i]["SAP_BIZCD"], "").ToString();

                    if (this.GetByteCount(BIZCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에  코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("BIZCD"));
                        return false;
                    }

                    if (this.GetByteCount(BIZCD) > 5)
                    {
                        //MsgBox.Show(i + " 번째 행에  코드는 5byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.GetLabel("BIZCD"), 5);
                        return false;
                    }

                    if (this.GetByteCount(BIZNM) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("BIZNM"));
                        return false;
                    }

                    if (this.GetByteCount(BIZNM) > 100)
                    {
                        //MsgBox.Show(i + " 번째 행에 는 100byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.GetLabel("BIZNM"), 100);
                        return false;
                    }

                    if (this.GetByteCount(CORCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 메시지가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("CORCD"));
                        return false;
                    }

                    if (this.GetByteCount(CORCD) > 5)
                    {
                        //MsgBox.Show(i + " 번째 행에 메시지는 50byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.GetLabel("CORCD"), 5);
                        return false;
                    }

                    if (this.GetByteCount(LANGUAGE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 언어가 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.GetLabel("LANGUAGE"));
                        return false;
                    }

                    if (this.GetByteCount(SAP_BIZCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 언어가 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd02.Cols["SAP_BIZCD"].Caption);
                        return false;
                    }
                    if (this.GetByteCount(SAP_BIZCD) > 10)
                    {
                        //MsgBox.Show(i + " 번째 행에는  10byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("CD00-0092", seq["GRIDSEQ"], this.grd02.Cols["SAP_BIZCD"].Caption, 10);
                        return false;
                    }

                }

                //if (MsgBox.Show("입력하신 메시지  정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //데이터 삭제시 확인 메시지(전 TAB 공통)
        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할  정보를 선택하지 않았습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신  정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        
        #endregion

        #region [기타컨트롤 이벤트]

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadCompleted == true)
                    this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void grd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;

                int tmpCol = grd.Col;
                int tmpRow = grd.SelectedRowIndex;

                this.cdx01_NATIONCD.Initialize();

                if (grd.Row > 0
                    && grd.Selection.TopRow == grd.Selection.BottomRow
                    && grd.Selection.LeftCol == grd.Selection.RightCol
                    )
                {

                    if (grd.Cols[grd.Col].Name == "NATIONCD")
                    {
                        //업체 선택 팝업
                        grd.Select(0, 0);

                        PopupHelper helper = new PopupHelper((DEV.Utility.Library.AxCommonPopupControl)this.cdx01_NATIONCD.HEPopupHelper, this.cdx01_NATIONCD.PopupTitle);
                        helper.ShowDialog();
                        object data = helper.SelectedValue;
                        if (data != null)
                        {
                            DataRow selectedPopupValue = (DataRow)data;
                            grd.SetValue(tmpRow, "NATIONCD", selectedPopupValue[this.cdx01_NATIONCD.CodeParameterName]);
                            grd.SetValue(tmpRow, "NATIONNM", selectedPopupValue[this.cdx01_NATIONCD.NameParameterName]);
                        }

                        grd.Select(tmpRow, tmpCol);
                    }
                }

                this.isDoubleClick = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (!this.isDoubleClick)
                {
                    this.cdx01_NATIONCD.Initialize();

                    if (grd.Cols[e.Col].Name == "NATIONCD" && !isBinding)
                    {
                        int row = grd.SelectedRowIndex;

                        this.cdx01_NATIONCD.SetValue(grd.GetValue(e.Row, "NATIONCD"));
                        grd.SetValue(row, "NATIONCD", this.cdx01_NATIONCD.GetValue());
                        grd.SetValue(row, "NATIONNM", this.cdx01_NATIONCD.GetText());

                        if (string.IsNullOrEmpty(this.cdx01_NATIONCD.GetText().ToString()))
                        {
                            grd.SetValue(row, "NATIONCD", string.Empty);
                            grd.SetValue(row, "NATIONNM", string.Empty);
                            //MsgBox.Show("존재하지 않는 국가코드 정보 입니다.");
                            MsgCodeBox.ShowFormat("CD00-0095", this.GetLabel("NATIONCD"));
                            return;
                        }

                        if (string.IsNullOrEmpty(Convert.ToString(this.cdx01_NATIONCD.GetValue())))
                        {
                            grd.SetValue(row, "NATIONCD", string.Empty);
                            grd.SetValue(row, "NATIONNM", string.Empty);
                            grd.Focus();
                            grd.Select(e.Row, e.Col - 1);
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.isDoubleClick = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }
        

        #endregion
    }
}
