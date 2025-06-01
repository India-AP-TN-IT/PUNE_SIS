#region ▶ Description & History
/* 
 * 프로그램명 : 
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 이현범
 * 최종수정일 : 2016-03-08
 * 수정  내용 :
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2016-03-08    이현범     다국어 적용
 *              2017-09-12    배명희     SIS이관
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using System.Drawing;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>근무시간 정보 등록</b>
    /// - 작 성 자 : 이현범<br />
    /// - 작 성 일 : 2016-03-08
    /// 
    /// </summary>
    public partial class PD25140 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD25140";

        private bool _isLoadComplete = false;
        private bool _isDoubleClick = false;

        public PD25140()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD25140>("PM00", "PD25140.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo02_BIZCD.SetReadOnly(false);
                else
                    this.cbo02_BIZCD.SetReadOnly(true);

                this.dtp01_BEG_DATE.SetMMFromStart();
                this.dtp01_END_DATE.SetMMFromEnd();

                DataTable dtShift = GetTypeCode("EI").Tables[0];
                DataTable dtHoliDiv = GetTypeCode("C2").Tables[0];

                this.cbo02_SHIFT.DataBind(dtShift, false);
                this.cbo02_HOLI_DIV.DataBind(dtHoliDiv, false);

                DataTable source_yn = this.GetDataSourceSchema("Code", "CodeValue").Tables[0];
                source_yn.Rows.Add("Y", "Y");
                source_yn.Rows.Add("N", "N");

                this.cbo01_NOT_USE.DataBind(source_yn, true);
                this.cbo02_NOT_USE.DataBind(source_yn, true);                

                this.nme02_HOLI_REQ_TIME.ReadOnly = true;

                this.grd01.AllowMerging = AllowMergingEnum.RestrictAll;
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.SelectionMode = SelectionModeEnum.CellRange;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "조업일자", "OPR_DATE", "OPR_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Work Center", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 320, "Line Name", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "주야구분", "SHIFT", "SHIFT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "시작시간", "BEG_TIME", "BEG_TIME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "종료시간", "END_TIME", "END_TIME");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 110, "소요시간(분)", "HOLI_REQ_TIME", "HOLI_REQ_TIME2");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 070, "휴무구분", "HOLI_DIV", "HOLI_DIV");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 300, "비고", "REMARK", "REMARK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "시간미반영유무", "NOT_USE", "NOT_USE");

                
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OPR_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "HOLI_REQ_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtShift, "SHIFT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtHoliDiv, "HOLI_DIV");
                this.grd01.AddHiddenColumn("BEG_TIME_SRC");

                this.grd01.Cols["OPR_DATE"].AllowMerging = true;
                this.grd01.Cols["OPR_DATE"].TextAlign = TextAlignEnum.LeftTop;
                this.grd01.Cols["SHIFT"].AllowMerging = true;
                this.grd01.Cols["SHIFT"].TextAlign = TextAlignEnum.CenterTop;

                this.grd01.Cols["LINECD"].AllowMerging = true;
                this.grd01.Cols["LINECD"].TextAlign = TextAlignEnum.LeftTop;
                this.grd01.Cols["LINENM"].AllowMerging = true;
                this.grd01.Cols["LINENM"].TextAlign = TextAlignEnum.LeftTop;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                set1.Add("PRDT_DIV", "");
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_PDCOMMON_ERM", "INQUERY_COMBO_LINELIST"), set1).Tables[0];
                this.cbl01_LINECD.DataBind(source1, "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명

                this.SetRequired(this.lbl02_BIZCD, this.lbl02_HOLI_DIV, this.lbl02_SHIFT, this.lbl02_BEG_TIME, this.lbl02_OPR_DATE);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                this._isLoadComplete = true;
            }
            catch(FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.GetDataSourceSchema
                (
                    "CORCD", "BIZCD", "OPR_DATE_BEG", "OPR_DATE_END",
                    "SHIFT",    "BEG_TIME",      "END_TIME",
                    "HOLI_DIV", "HOLI_REQ_TIME", "NOT_USE" ,
                    "LINECD"
                );


                source.Tables[0].Rows.Add
                (
                    this.UserInfo.CorporationCode,
                    this.cbo02_BIZCD.GetValue(),
                    this.dtp02_OPR_DATE_BEG.GetValue(),
                    this.dtp02_OPR_DATE_END.GetValue().ToString(),
                    this.cbo02_SHIFT.GetValue(),
                    this.dte02_BEG_TIME.GetValue(),
                    this.dte02_END_TIME.GetValue(),
                    this.cbo02_HOLI_DIV.GetValue(),
                    this.nme02_HOLI_REQ_TIME.GetValue(),
                    this.cbo02_NOT_USE.GetValue(),
                    this.grd01.GetValue(this.grd01.SelectedRowIndex, "LINECD")
                );


                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                this.AfterInvokeServer();

                //MsgBox.Show("정상적으로 저장되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "OPR_DATE_BEG", "OPR_DATE_END", "SHIFT", "BEG_TIME", "LINECD");
                source.Tables[0].Rows.Add(UserInfo.CorporationCode,
                                          cbo02_BIZCD.GetValue().ToString(),
                                          dtp02_OPR_DATE_BEG.GetValue().ToString(),
                                          dtp02_OPR_DATE_END.GetValue().ToString(),
                                          cbo02_SHIFT.GetValue().ToString(),
                                          dte02_BEG_TIME.GetValue().ToString(),
                                          this.grd01.GetValue(this.grd01.SelectedRowIndex, "LINECD")
                                          );

                if (!this.IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //메세지 코드 처리
                //MsgBox.Show("선택하신 일별조업형태 정보가 삭제되었습니다");
                MsgCodeBox.Show("CD00-0072");

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
                if (!this.IsQueryValid()) return;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD",    this.cbo01_BIZCD.GetValue());
                set.Add("BEG_DATE", this.dtp01_BEG_DATE.GetValue());
                set.Add("END_DATE", this.dtp01_END_DATE.GetValue());
                set.Add("NOT_USE", this.cbo01_NOT_USE.GetValue());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet dsInquery = _WSCOM.Inquery(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME ,"INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                
                //this.grd01.setSumStyle(2, 0, AxFlexGrid.eSumStyle.ColOnlyMode);
                this.grd01.Cols["OPR_DATE"].Style.BackColor = Color.White;
                this.grd01.Cols["SHIFT"].Style.BackColor = Color.White;

                ShowDataCount(source);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.cbo02_BIZCD.Initialize();
                this.cbo02_HOLI_DIV.SetValue("C2N");
                this.cbo02_HOLI_DIV.SetReadOnly(true);

                this.cbo02_SHIFT.Initialize();
                this.cbo02_NOT_USE.SetValue("N");
                this.cbo02_NOT_USE.SetReadOnly(true);

                this.dte02_BEG_TIME.SetValue("00:00");
                this.dte02_END_TIME.SetValue("00:00");
                this.dtp02_OPR_DATE_BEG.Initialize();
                this.dtp02_OPR_DATE_END.Initialize();
                this.nme02_HOLI_REQ_TIME.Initialize();
                this.nme02_HOLI_REQ_TIME.SetReadOnly(true);

                this.cbo02_BIZCD.SetReadOnly(false);
                this.cbo02_SHIFT.SetReadOnly(false);                
                this.dte02_BEG_TIME.SetReadOnly(false);
                this.dtp02_OPR_DATE_BEG.SetReadOnly(false);

                _isDoubleClick = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("저장할 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                #region Check Time Validation.
                int n_selected = this.grd01.SelectedRowIndex;
                int n_fixed = this.grd01.Rows.Fixed;
                string str_begin_date = DateTime.Parse(Convert.ToString(this.dte02_BEG_TIME.GetValue())).ToString("yyyyMMddHHmmss");
                string str_end_date = DateTime.Parse(Convert.ToString(this.dte02_END_TIME.GetValue())).ToString("yyyyMMddHHmmss");
                bool flg_valid = true;
                if (n_selected >= n_fixed && n_selected < this.grd01.Rows.Count)
                {
                    if (n_selected == n_fixed)//첫번째 로우인 경우.
                    {   //첫번째 로우인 경우.
                        string s_begin_value = Convert.ToString(this.grd01.GetValue(n_selected + 1, "BEG_TIME"));
                        string s_end_value = Convert.ToString(this.grd01.GetValue(n_selected + 1, "END_TIME"));

                        string s_nxt_begin = string.IsNullOrEmpty(s_begin_value) ? "" : DateTime.Parse(s_begin_value).ToString("yyyyMMddHHmmss");
                        string s_nxt_end = string.IsNullOrEmpty(s_end_value) ? "" : DateTime.Parse(s_end_value).ToString("yyyyMMddHHmmss");

                        if (!string.IsNullOrEmpty(s_nxt_begin) && !string.IsNullOrEmpty(s_nxt_end))
                        {
                            if (string.Compare(s_nxt_begin, str_end_date, false) >= 0) flg_valid = true;
                            {
                                MessageBox.Show(str_end_date + "~" + s_nxt_begin);
                                dte02_END_TIME.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            flg_valid = true;
                        }
                    }
                    else if (n_selected == (this.grd01.Rows.Count - 1))
                    {   //마지막 로우인경우.
                        string s_value_begin = Convert.ToString(this.grd01.GetValue(n_selected, "BEG_TIME"));
                        string s_value_end = Convert.ToString(this.grd01.GetValue(n_selected, "END_TIME"));
                        string s_pre_begin = string.IsNullOrEmpty(s_value_begin) ? "" : DateTime.Parse(s_value_begin).ToString("yyyyMMddHHmmss");
                        string s_pre_end = string.IsNullOrEmpty(s_value_end) ? "" : DateTime.Parse(s_value_end).ToString("yyyyMMddHHmmss");

                        if (string.Compare(str_begin_date, s_pre_end, false) >= 0) flg_valid = true;
                        else
                        {
                            MessageBox.Show(str_begin_date + "~" + s_pre_end);
                            dte02_BEG_TIME.Focus();
                            return false;
                        }
                    }
                    else
                    {   //두번째부터 끝 로우 전까지...
                        string s_value_begin = Convert.ToString(this.grd01.GetValue(n_selected - 1, "BEG_TIME"));
                        string s_value_end = Convert.ToString(this.grd01.GetValue(n_selected - 1, "END_TIME"));
                        string s_pre_begin = string.IsNullOrEmpty(s_value_begin) ? "" : DateTime.Parse(s_value_begin).ToString("yyyyMMddHHmmss");
                        string s_pre_end = string.IsNullOrEmpty(s_value_end) ? "" : DateTime.Parse(s_value_end).ToString("yyyyMMddHHmmss");

                        s_value_begin = Convert.ToString(this.grd01.GetValue(n_selected + 1, "BEG_TIME"));
                        s_value_end = Convert.ToString(this.grd01.GetValue(n_selected + 1, "END_TIME"));
                        string s_nxt_begin = string.IsNullOrEmpty(s_value_begin) ? "" : DateTime.Parse(s_value_begin).ToString("yyyyMMddHHmmss");
                        string s_nxt_end = string.IsNullOrEmpty(s_value_end) ? "" : DateTime.Parse(s_value_end).ToString("yyyyMMddHHmmss");

                        if (string.IsNullOrEmpty(s_nxt_begin) && string.IsNullOrEmpty(s_nxt_end)
                            && string.IsNullOrEmpty(s_pre_begin) && string.IsNullOrEmpty(s_pre_end)
                            )
                        {
                            flg_valid = true;
                        }
                        else if (string.IsNullOrEmpty(s_nxt_begin) && string.IsNullOrEmpty(s_nxt_end)
                            && !string.IsNullOrEmpty(s_pre_begin) && !string.IsNullOrEmpty(s_pre_end)
                            )
                        {
                            if (string.Compare(str_begin_date, s_pre_end, false) >= 0) flg_valid = true;
                            else
                            {
                                MessageBox.Show(str_begin_date + "~" + s_pre_end);
                                dte02_BEG_TIME.Focus();
                                return false;
                            }
                        }
                        else if (string.IsNullOrEmpty(s_pre_begin) && string.IsNullOrEmpty(s_pre_end)
                            && !string.IsNullOrEmpty(s_nxt_begin) && !string.IsNullOrEmpty(s_nxt_end)
                            )
                        {
                            if (string.Compare(s_nxt_begin, str_begin_date, false) >= 0) flg_valid = true;
                            else
                            {
                                MessageBox.Show(str_begin_date + "~" + s_pre_end);
                                dte02_BEG_TIME.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            if (string.Compare(str_begin_date, s_pre_end, false) >= 0 && string.Compare(s_nxt_begin, str_end_date, false) >= 0) flg_valid = true;
                            else
                            {
                                MessageBox.Show(str_begin_date + "~" + s_pre_end);
                                return false;
                            }
                        }

                        flg_valid = true;
                    }
                }
                #endregion

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                param.Add("OPR_DATE_BEG", this.dtp02_OPR_DATE_BEG.GetValue());
                param.Add("OPR_DATE_END", this.dtp02_OPR_DATE_END.GetValue());
                param.Add("SHIFT", this.cbo02_SHIFT.GetValue());
                param.Add("HOLI_DIV", this.cbo02_HOLI_DIV.GetValue());

                DataSet ds = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CHK"), param, "OUT_CURSOR");

                string strCnt = string.Empty;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    strCnt = ds.Tables[0].Rows[0]["CNT"].ToString();
                }

                if (_isDoubleClick == false)
                {
                    if (Convert.ToInt32(strCnt.ToString()) > 0)
                    {
                        //MsgBox.Show("정취시간 정보는 당일 시프트별로 한번만 지정 가능 합니다.");
                        MsgCodeBox.Show("PD00-0083");
                        return false;
                    }
                }

                DataRow row = source.Tables[0].Rows[0];

                string BEG_TIME = row["BEG_TIME"].ToString();
                string END_TIME = row["END_TIME"].ToString();

                DateTime dtBEG_TIME = DateTime.Parse(BEG_TIME);
                DateTime dtEND_TIME = DateTime.Parse(END_TIME);

                //if (dtBEG_TIME > dtEND_TIME)
                //{
                //    //MsgBox.Show("시작시간이 종료시간보다 클 수 없습니다.");
                //    MsgCodeBox.Show("PM05-0012");
                //    //MsgCodeBox.Show("PM00-0075");
                //    return false;
                //}

                if (dtBEG_TIME == dtEND_TIME)
                {
                    MsgCodeBox.Show("PD00-0084"); //시작시간과 종료시간 정보는 동일할 수 없습니다.
                    //MsgCodeBox.Show("PM00-0075");
                    return false;
                }
                //데이터를 저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");

                    return false;
                }

                //데이터를 삭제하시겠습니까?
                if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsQueryValid()
        {
            try
            {
                DateTime dtBEG_DATE = DateTime.Parse(this.dtp01_BEG_DATE.GetValue().ToString());
                DateTime dtEND_DATE = DateTime.Parse(this.dtp01_END_DATE.GetValue().ToString());

                if (dtBEG_DATE > dtEND_DATE)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("시작일자는 종료일자보다 작거나 같아야 합니다.");
                    MsgCodeBox.Show("PD00-0069");
                    return false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void grd02_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                grd01.SetValue(args.RowIndex, "CORCD", cbo01_BIZCD.GetValue().ToString());
                grd01.SetValue(args.RowIndex, "BIZCD", UserInfo.BusinessCode);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }
  
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                this.cbo02_BIZCD.SetValue(this.grd01.GetValue(row, "BIZCD"));
                this.cbo02_HOLI_DIV.SetValue(this.grd01.GetValue(row, "HOLI_DIV"));
                this.cbo02_SHIFT.SetValue(this.grd01.GetValue(row, "SHIFT"));
                
                if(!string.IsNullOrEmpty(this.grd01.GetValue(row, "BEG_TIME").ToString()))
                    this.dte02_BEG_TIME.SetValue(DateTime.Parse(this.grd01.GetValue(row, "BEG_TIME").ToString()).ToString("yyyyMMddHHmmss"));

                if (!string.IsNullOrEmpty(this.grd01.GetValue(row, "END_TIME").ToString()))
                    this.dte02_END_TIME.SetValue(DateTime.Parse(this.grd01.GetValue(row, "END_TIME").ToString()).ToString("yyyyMMddHHmmss"));

                this.nme02_HOLI_REQ_TIME.SetValue(this.grd01.GetValue(row, "HOLI_REQ_TIME"));
                this.dtp02_OPR_DATE_BEG.SetValue(this.grd01.GetValue(row, "OPR_DATE"));
                this.dtp02_OPR_DATE_END.SetValue(this.grd01.GetValue(row, "OPR_DATE"));

                this.cbo02_NOT_USE.SetValue(this.grd01.GetValue(row, "NOT_USE").ToString());

                this.cbo02_BIZCD.SetReadOnly(true);
                this.cbo02_SHIFT.SetReadOnly(true);
                this.cbo02_HOLI_DIV.SetReadOnly(true);
                //this.dte02_BEG_TIME.SetReadOnly(true);
                this.dtp02_OPR_DATE_BEG.SetReadOnly(true);

                _isDoubleClick = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dte02_BEG_TIME_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadComplete)
                {
                    AxDateEdit dte = (AxDateEdit)sender;

                    DateTime dtBEG_TIME = DateTime.Parse(this.dte02_BEG_TIME.GetValue().ToString());
                    DateTime dtEND_TIME = DateTime.Parse(this.dte02_END_TIME.GetValue().ToString());

                    int intYear = DateTime.Parse(this.dte02_BEG_TIME.GetValue().ToString()).Year;
                    int intMonth = DateTime.Parse(this.dte02_BEG_TIME.GetValue().ToString()).Month;
                    int intDay = DateTime.Parse(this.dte02_BEG_TIME.GetValue().ToString()).Day;

                    DateTime begTime = new DateTime(intYear, intMonth, intDay, 0, 0, 0);
                    DateTime endTime = new DateTime(intYear, intMonth, intDay, 6, 0, 0);

                    DateTime begTime2 = new DateTime(intYear, intMonth, intDay, dtBEG_TIME.Hour, dtBEG_TIME.Minute, dtBEG_TIME.Second);
                    DateTime endTime2 = new DateTime(intYear, intMonth, intDay, dtEND_TIME.Hour, dtEND_TIME.Minute, dtEND_TIME.Second);

                    if (dtBEG_TIME >= begTime && dtBEG_TIME <= endTime)
                        dtBEG_TIME = dtBEG_TIME.AddDays(1);
                    else
                        dtBEG_TIME = begTime2;

                    if (dtEND_TIME >= begTime && dtEND_TIME <= endTime)
                        dtEND_TIME = dtEND_TIME.AddDays(1);
                    else
                        dtEND_TIME = endTime2;

                    TimeSpan dt = dtEND_TIME - dtBEG_TIME;

                    if (dtBEG_TIME < dtEND_TIME)
                        this.nme02_HOLI_REQ_TIME.SetValue(dt.TotalMinutes);
                    else
                        this.nme02_HOLI_REQ_TIME.SetValue(0);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void dtp02_OPR_DATE_BEG_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadComplete)
                {
                    this.dtp02_OPR_DATE_END.SetValue(this.dtp02_OPR_DATE_BEG.Value);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void dtp02_OPR_DATE_END_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadComplete)
                {
                    DateTime dtBEG_DATE = DateTime.Parse(this.dtp02_OPR_DATE_BEG.GetValue().ToString());
                    DateTime dtEND_DATE = DateTime.Parse(this.dtp02_OPR_DATE_END.GetValue().ToString());

                    if(dtBEG_DATE > dtEND_DATE)
                        this.dtp02_OPR_DATE_BEG.SetValue(this.dtp02_OPR_DATE_END.Value);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        #endregion

        private void lbl02_HOLI_REQ_TIME2_Click(object sender, EventArgs e)
        {

        }

        private void nme02_HOLI_REQ_TIME_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
