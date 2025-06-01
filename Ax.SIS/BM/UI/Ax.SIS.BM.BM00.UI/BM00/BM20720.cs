using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Controls;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-06-03 오후 3:39:10<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-03 오후 3:39:10   이태호 : 최초 클래스 생성<br />
    ///     2) 2010-06-07 이태호 : 현재상태로는 입력확인이 불가.<br />
    /// </summary>
    public partial class BM20720 : AxCommonBaseControl
    {
        //private IBM20720 _WSCOM;
        private AxClientProxy _WSCOM;
        private DateTime m_qDate = DateTime.Now;
        double CN_REFRESH_TIME = 10;
        public BM20720()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IBM20720>("BM00", "BM20720.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                this.axCodeBox1.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.axCodeBox1);
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "Corporation", "CORCD", "COR");
                this.grd01.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "LINECD", "LINECD", "LINECD");
                this.grd01.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 60, "CAR", "VINCD", "VIN");
                this.grd01.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "I/TYPE", "MAT_ITEM", "MAT_DIV");

                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "Pattern", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "PART Check", "DEFF_CHECK", "DEFF_CHECK");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "SPEC Send", "SPEC_CHECK", "SPEC_CHECK");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "ET Part", "ELEC_CHECK", "ELEC_CHECK");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "M/Table No", "LOAD_TAB_POS", "LOAD_TAB_POS");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "S/DATE", "APP_DATE", "SDATE");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "E/DATE", "END_DATE", "END_DATE");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "Station Code", "PROCCD", "PROCCD");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 130, "SPEC Type", "GET_TY", "GET_TY");
                this.grd01.AddColumn(false, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 130, "Module No", "MOD_NO", "MOD_NO");
                this.grd01.Cols["APP_DATE"].Format = "yyyy-MM-dd";
                this.grd01.Cols["END_DATE"].Format = "yyyy-MM-dd";

                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Date, "APP_DATE");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Date, "END_DATE");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Check, "DEFF_CHECK");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Check, "SPEC_CHECK");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Check, "ELEC_CHECK");


                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "Corporation", "CORCD", "COR");
                this.grd02.AddColumn(true, false, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "Business", "BIZCD", "BIZNM2");
                this.grd02.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 90, "CAR", "VINCD", "VINCD");
                this.grd02.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "CAR", "VINNM", "VINNM");

                this.grd02.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 180, "Pattern", "PARTNO_PAT", "PARTNO");
                this.grd02.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "LINE", "LINECD", "LINECD");
                this.grd02.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 180, "LINE", "LINENM", "LINENM");

                this.grd02.AddMerge(0, 0, "VINCD", "VINNM");
                this.grd02.AddMerge(0, 0, "LINECD", "LINENM");

                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);


                this.grd03.Initialize();
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "PLANT", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "STATE", "STATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "DATE", "STD_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "CAR", "VINCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "LINE", "LINECD");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "USER", "USERID");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "USER", "EMPNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "INPUT DATE", "INS_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "RUN DATE", "RUN_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "FINISH DATE", "FINISH_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "Message", "RUN_MSG");

                this.grd03.AddMerge(0, 0, "USERID", "EMPNM");
                //cdx01_LINECD.SetValid(6, Ax.DEV.Utility.Controls.AxTextBox.TextType.UAlphabet);
                this.cdx01_LINECD.HEPopupHelper = new BM20710P2();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("REP_LINECD");// "대표 라인코드";
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                this.cdx01_LINECD2.HEPopupHelper = new BM20710P2();
                this.cdx01_LINECD2.PopupTitle = this.GetLabel("REP_LINECD");// "대표 라인코드";
                this.cdx01_LINECD2.CodeParameterName = "LINECD";
                this.cdx01_LINECD2.NameParameterName = "LINENM";
                this.cdx01_LINECD2.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD2.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD2.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                GetJobList();

                m_qDate = DateTime.Now.AddSeconds(-1 * CN_REFRESH_TIME);
                timer1.Start();


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
               
                if (tabControl1.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(cdx01_LINECD.GetValue().ToString()) == true)
                    {
                        MessageBox.Show("You have to select the LINE");
                        return;
                    }
                    DataSet source = (DataSet)this.grd01.GetValue(Ax.DEV.Utility.Controls.AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "LINECD", "MAT_ITEM", "PARTNO", "DEFF_CHECK", "SPEC_CHECK", "ELEC_CHECK"
                        , "LOAD_TAB_POS", "APP_DATE", "END_DATE", "PROCCD", "GET_TY", "MOD_NO");
                    foreach (DataRow dr in source.Tables[0].Rows)
                    {
                        dr["CORCD"] = this.UserInfo.CorporationCode;
                        dr["BIZCD"] = cbo01_BIZCD.GetValue();
                        dr["LINECD"] = cdx01_LINECD.GetValue();
                        dr["MAT_ITEM"] = "E0E1";
                        if (string.IsNullOrEmpty(dr["APP_DATE"].ToString()))
                        {
                            dr["APP_DATE"] = dte01_BaseDate.Value.ToString("yyyy-MM-dd");
                        }
                        if (string.IsNullOrEmpty(dr["END_DATE"].ToString()))
                        {
                            dr["END_DATE"] = "9990-12-31";
                        }
                    }
                    if (!IsSaveValid(source)) return;
                    this.BeforeInvokeServer(true);
                    //_WSCOM.Save(source);
                    _WSCOM.ExecuteNonQueryTx("APG_BM20720.SAVE", source);
                    this.AfterInvokeServer();
                    //MsgBox.Show("입력하신 라인/공정별 제품 정보가 정상적으로 저장되었습니다");
                    //저장되었습니다.
                    MsgCodeBox.Show("CD00-0071");
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    DataSet source = (DataSet)this.grd02.GetValue(Ax.DEV.Utility.Controls.AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "VINCD", "PARTNO_PAT", "LINECD");
                    foreach (DataRow dr in source.Tables[0].Rows)
                    {
                        dr["CORCD"] = this.UserInfo.CorporationCode;
                        dr["BIZCD"] = cbo01_BIZCD.GetValue();
                    }
                    if (!IsSaveValid(source)) return;
                    this.BeforeInvokeServer(true);
                    //_WSCOM.Save(source);
                    _WSCOM.ExecuteNonQueryTx("APG_BM20720.SAVE_LINE", source);
                    this.AfterInvokeServer();
                    //MsgBox.Show("입력하신 라인/공정별 제품 정보가 정상적으로 저장되었습니다");
                    //저장되었습니다.
                    MsgCodeBox.Show("CD00-0071");
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    axButton1_Click(null, null);
                }
                this.BtnQuery_Click(null, null);

                
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
                if (tabControl1.SelectedIndex == 1)
                {
                    DataSet source = (DataSet)this.grd01.GetValue(Ax.DEV.Utility.Controls.AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "LINECD", "PARTNO");

                    if (!IsRemoveValid(source)) return;
                    this.BeforeInvokeServer(true);
                    //_WSCOM.Remove(source);
                    _WSCOM.ExecuteNonQueryTx("APG_BM20720.REMOVE", source);
                    this.AfterInvokeServer();
                    //MsgBox.Show("선택하신 패턴의 제품 정보가 정상적으로 삭제되었습니다");
                    // 삭제되었습니다.
                    MsgCodeBox.Show("CD00-0072");
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    DataSet source = (DataSet)this.grd02.GetValue(Ax.DEV.Utility.Controls.AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "VINCD", "PARTNO_PAT");

                    if (!IsRemoveValid(source)) return;
                    this.BeforeInvokeServer(true);
                    //_WSCOM.Remove(source);
                    _WSCOM.ExecuteNonQueryTx("APG_BM20720.REMOVE_LINE", source);
                    this.AfterInvokeServer();
                    //MsgBox.Show("선택하신 패턴의 제품 정보가 정상적으로 삭제되었습니다");
                    // 삭제되었습니다.
                    MsgCodeBox.Show("CD00-0072");
                }

                this.BtnQuery_Click(null, null);

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
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
                if (tabControl1.SelectedIndex == 1)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                    paramSet.Add("LINECD", cdx01_LINECD.GetValue());
                    paramSet.Add("BASE_DATE", dte01_BaseDate.GetDateText());
                    paramSet.Add("PARTNO", txt01_M_PARTNO.GetValue());

                    //if (!IsQueryValid(paramSet)) return;
                    if (string.IsNullOrEmpty(cdx01_LINECD.GetValue().ToString()))
                    {
                        MsgBox.Show("Line Error");
                        return;
                    }

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.Inquery(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet("APG_BM20720.INQUERY", paramSet);
                    this.AfterInvokeServer();

                    this.grd01.SetValue(source.Tables[0]);
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                    paramSet.Add("VINCD", cdx01_VINCD.GetValue());
                    paramSet.Add("PARTNO", txt01_M_PARTNO.GetValue());


                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.Inquery(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet("APG_BM20720.INQUERY_LINE", paramSet);
                    this.AfterInvokeServer();

                    this.grd02.SetValue(source.Tables[0]);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    GetJobList();
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            this.cbo01_BIZCD.Initialize();
            this.cdx01_VINCD.Initialize();
            this.grd01.InitializeDataSource();
            this.cdx01_LINECD.Initialize();
        }
        

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 패턴정보가 없습니다.");
                    MsgCodeBox.Show("COM-00020");
                    return false;
                }

                foreach (DataRow row in source.Tables[0].Rows)
                {
                    if (row["DEFF_CHECK"].ToString() == "1" && row["PROCCD"].ToString().Trim().Length == 0)
                    {
                        //MsgBox.Show(row["PARTNO"].ToString() + " 공정코드를 입력해주세요!");
                        MessageBox.Show("Please Input the station Code");
                        return false;
                    }
                    if (row["SPEC_CHECK"].ToString() == "1" && row["GET_TY"].ToString().Trim().Length == 0)
                    {
                        //MsgBox.Show(row["PARTNO"].ToString() + "사양타입을 입력해주세요!");
                        MessageBox.Show("Please Input the SPEC. TYPE");
                        return false;
                    }
                }
            }
            else
            {
                foreach (DataRow row in source.Tables[0].Rows)
                {
                    if (row["LINECD"].ToString().Length == 0)
                    {
                        MessageBox.Show("Please Input the LINECD Code");
                        return false;
                    }
                }
            }
            //if (MsgBox.Show("패턴정보를 저장하시겠습니까", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MessageBox.Show("Do you want to save the DATA?", this.GetLabel("CARE"), MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsRemoveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("패턴정보가 없습니다.");
                MsgCodeBox.Show("COM-00023");
                return false;
            }
            //if (MsgBox.Show("패턴정보를 삭제하시겠습니까", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MessageBox.Show("Do you want to delete the data?", this.GetLabel("CARE"), MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }


        #endregion

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is AxFlexGrid)
            {
                AxFlexGrid pGrid = (AxFlexGrid)sender;
                if (pGrid.Cols[pGrid.Col].Name == "VINCD" || pGrid.Cols[pGrid.Col].Name == "VINNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("CAR", "NAME", pGrid.GetValue(pGrid.Row, "VINCD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A3");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "CAR");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "VINCD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "VINNM", row["T_DESC"]);
                    }

                }
                else if (pGrid.Cols[pGrid.Col].Name == "LINECD" || pGrid.Cols[pGrid.Col].Name == "LINENM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("CODE", "NAME", pGrid.GetValue(pGrid.Row, "LINECD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "LINE");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "LINE");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "LINECD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "LINENM", row["T_DESC"]);
                    }
                }
            }
        }

        private void grd02_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (sender is AxFlexGrid)
            {


                AxFlexGrid pGrid = (AxFlexGrid)sender;
                HEParameterSet paramSet = new HEParameterSet();
                string cdStr = "";
                string descStr = "";
                string findStr = pGrid.GetValue(e.Row, e.Col).ToString();
                paramSet.Add("CORCD", UserInfo.CorporationCode);
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("TY_CODE", "");
                paramSet.Add("CODE", string.IsNullOrEmpty(findStr) ? "@#@#@#@#" : findStr);
                paramSet.Add("DESC", "");
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                if (pGrid.Cols[pGrid.Col].Name == "VINCD")
                {
                    paramSet["TY_CODE"] = "UDC:A3";
                    cdStr = "VINCD";
                    descStr = "VINNM";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "LINECD")
                {
                    paramSet["TY_CODE"] = "LINE";
                    cdStr = "LINECD";
                    descStr = "LINENM";
                }
                else
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    return;
                }
                DataTable dt = _WSCOM.ExecuteDataSet("APG_BM20115.INQUERY_DLG", paramSet, "OUT_CURSOR").Tables[0];

                if (dt.Rows.Count >= 1)
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    pGrid.SetValue(e.Row, cdStr, dt.Rows[0]["T_CODE"]);
                    if (string.IsNullOrEmpty(descStr) == false)
                    {
                        pGrid.SetValue(e.Row, descStr, dt.Rows[0]["T_DESC"]);
                    }
                }
                else
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    pGrid.SetValue(e.Row, cdStr, "");
                    if (string.IsNullOrEmpty(descStr) == false)
                    {
                        pGrid.SetValue(e.Row, descStr, "");
                    }
                }
            }
        }

        private void heButton2_Click(object sender, EventArgs e)
        {
            GetJobList();
        }

        private void GetJobList()
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", UserInfo.CorporationCode);
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("VINCD", axCodeBox1.GetValue());
            paramSet.Add("ST_DATE", dte01_BaseDate.GetDateText());

            DataTable dt = _WSCOM.ExecuteDataSet("APG_BM20720.GET_JOB_LIST", paramSet, "OUT_CURSOR").Tables[0];
            this.grd03.SetValue(dt);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            double r = (DateTime.Now - m_qDate).TotalSeconds;
            heButton2.Text = "Refresh(" + (CN_REFRESH_TIME - r).ToString("N0") + ")";
            if (r > CN_REFRESH_TIME)
            {
                GetJobList();

                m_qDate = DateTime.Now;
            }
            timer1.Start();
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(axCodeBox1.GetValue().ToString()))
                {
                    MsgBox.Show("You have to select the Car");
                    return;
                }

                if (MsgBox.Show("Do you want to expand BOM from SAP", "Question", System.Windows.Forms.MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                DataSet source02 = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD"
                                                                  , "STD_DATE", "VINCD","LINECD", "UPDATE_USER");

                source02.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbo01_BIZCD.GetValue(),
                    this.dte01_BaseDate.GetDateText(),
                    this.axCodeBox1.GetValue(),
                    this.cdx01_LINECD2.GetValue(),
                    this.UserInfo.UserID);

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_BM20720.SET_QUEUE_BATCH", source02);

                this.AfterInvokeServer();


                GetJobList();

            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());

            }
            finally
            {

                this.AfterInvokeServer();
            }
        }
        

    }
}
