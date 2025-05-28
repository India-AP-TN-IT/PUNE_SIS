using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;

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
    public partial class BM20710 : AxCommonBaseControl
    {
        //private IBM20710 _WSCOM;
        private AxClientProxy _WSCOM;

        public BM20710()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IBM20710>("BM00", "BM20710.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }
        //커밋 테스트1231S
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //cdx01_LINECD.SetValid(6, Ax.DEV.Utility.Controls.AxTextBox.TextType.UAlphabet);
                cdx01_ASSYNO.SetValid(15, Ax.DEV.Utility.Controls.AxTextBox.TextType.UAlphabet);

                this.SetRequired(this.lbl01_LINECD, this.lbl01_ASSYNO);

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd01.AllowEditing = true;

                this.grd01.Initialize();
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "P/NO", "CPNO","@@");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "PART Name", "PARTNM", "PARTNAME");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "DIVISION", "PRDT_DIV", "PRDT_DIVNM");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 30, "S/SEQ", "PROC_SEQ", "WORK_CNT");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "S/CODE", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "S/Name", "PROCNM", "PROCNM");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 50, "Part Check", "DEFF_CHECK","@@");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "M/Table No", "LOAD_TAB_POS", "LOAD_TAB_POS");

                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "S/DATE", "EPI_APP_DATE", "SDATE");
                this.grd01.AddColumn(false, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "E/DATE", "EPI_END_DATE", "END_DATE");


                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("LINECD");
                this.grd01.AddHiddenColumn("PPNO");
                this.grd01.AddHiddenColumn("PPNO_REV");
                this.grd01.AddHiddenColumn("ORG_PROCCD");
                this.grd01.Cols["EPI_APP_DATE"].Format = "yyyy-MM-dd";
                this.grd01.Cols["EPI_END_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Date, "EPI_APP_DATE");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Date, "EPI_END_DATE");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Check, "DEFF_CHECK");
                this.grd01.SetColumnType(Ax.DEV.Utility.Controls.AxFlexGrid.FCellType.Int, "PROC_SEQ");

                this.grd01.CurrentContextMenu.Items[0].Visible = false;


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 30, "S/SEQ", "PROC_SEQ","@@");
                this.grd02.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 50, "S/CODE", "PROCCD","@@");
                this.grd02.AddColumn(true, true, Ax.DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 100, "S/NAME", "PROCNM","@@");

                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cdx01_LINECD.HEPopupHelper = new BM20710P2();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("REP_LINECD");// "대표 라인코드";
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);



                cdx01_ASSYNO.PopupTitle = this.GetLabel("완제품 선택");// "완제품 선택";
                cdx01_ASSYNO.HEPopupHelper = new BM20710P1(txt01_REVISION);
                cdx01_ASSYNO.CodeParameterName = "PARTNO";
                cdx01_ASSYNO.NameParameterName = "PARTNM";
                cdx01_ASSYNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                cdx01_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                cdx01_ASSYNO.HEUserParameterSetValue("LINECD", this.cdx01_LINECD.GetValue());
                cdx01_ASSYNO.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
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
                DataSet source = (DataSet)this.grd01.GetValue(Ax.DEV.Utility.Controls.AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "LINECD", "PPNO", "PPNO_REV", "CPNO", "PROCCD","ORG_PROCCD", "PROC_SEQ", "DEFF_CHECK", "LOAD_TAB_POS", "EPI_APP_DATE","EPI_END_DATE");

                if (!IsSaveValid(source)) return;
                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx("APG_BM20710.SAVE", source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 라인/공정별 제품 정보가 정상적으로 저장되었습니다");
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
                DataSet source = (DataSet)this.grd01.GetValue(Ax.DEV.Utility.Controls.AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "LINECD", "PPNO", "PPNO_REV", "CPNO", "PROCCD");

                if (!IsRemoveValid(source)) return;
                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx("APG_BM20710.REMOVE", source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 라인/공정별 제품 정보가 정상적으로 삭제되었습니다");
                MsgCodeBox.Show("CD00-0072");
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
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", cdx01_LINECD.GetValue());
                paramSet.Add("BASE_DATE", dte01_BaseDate.GetDateText());
                paramSet.Add("ASSYNO", cdx01_ASSYNO.GetValue());
                paramSet.Add("REVISION", txt01_REVISION.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("PRDT_DIV", "M");

                if (!IsQueryValid(paramSet)) return;

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet("APG_BM20710.INQUERY", paramSet, "OUT_CURSOR", "OUT_CURSOR1");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.grd02.SetValue(source.Tables[1]);
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
            this.cdx01_ASSYNO.Initialize();
            this.txt01_REVISION.Initialize();
            this.cdx01_LINECD.Initialize();
            this.grd01.InitializeDataSource();
            this.grd02.InitializeDataSource();
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("저장할 라인,공정별 제품정보가 없습니다.");
                MsgCodeBox.Show("COM-00020");
                return false;
            }

            
            if (MsgBox.Show("라인,공정별 제품정보를 저장하시겠습니까", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //if (MsgCodeBox.ShowFormat("@@", this.GetLabel("CARE"), MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsRemoveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 라인,공정별 제품정보가 없습니다.");
                MsgCodeBox.Show("COM-00023");
                return false;
            }
            if (MsgBox.Show("라인,공정별 제품정보를 삭제하시겠습니까", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //if (MsgCodeBox.ShowFormat("@@", this.GetLabel("EIS_EI30010_WARN"), MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsQueryValid(HEParameterSet set)
        {
            if (set["LINECD"].Equals(""))
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("COM-00901", this.GetLabel("LINE"));
                return false;
            }
            else if (set["ASSYNO"].Equals(""))
            {
                //MsgBox.Show("완제품을 선택해주세요!");
                MsgCodeBox.ShowFormat("COM-00901", this.GetLabel("ASSYPNO"));
                return false;
            }
            return true;
        }

        #endregion

        #region [ 기타 이벤트 검사 ]

        private void cdx01_ASSYNO_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                if (this.cdx01_ASSYNO.SelectedPopupValue != null)
                    this.txt01_REVISION.SetValue(this.cdx01_ASSYNO.SelectedPopupValue["REVISION"]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_ASSYNO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txt01_REVISION.SetValue("");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_LINECD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            cdx01_LINECD_ButtonClickAfter(null, null);
        }

        private void cdx01_LINECD_ButtonClickAfter(object sender, EventArgs args)
        {
            if (this.cdx01_LINECD.IsEmpty)
            {
                this.cdx01_ASSYNO.HEUserParameterSetValue("LINECD", "");
            }
            else
            {
                this.cdx01_ASSYNO.HEUserParameterSetValue("LINECD", this.cdx01_LINECD.GetValue());
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Row < this.grd01.Rows.Fixed) return;

            if (e.Col < this.grd01.Cols.Fixed) return;

            if (this.grd01.Cols[e.Col].Name != "PROC_SEQ") return;

            string PROCCD = string.Empty;
            string PROCNM = string.Empty;
            string PROC_SEQ = string.Empty;

            if (!this.grd01.GetValue(e.Row, e.Col).Equals(""))
            {
                DataTable source = this.grd02.DataSource as DataTable;

                DataRow[] rows = source.Select("PROC_SEQ = '" + this.grd01.GetValue(e.Row, e.Col).ToString() + "'");

                if (rows.Length == 1)
                {
                    PROCCD = rows[0]["PROCCD"].ToString();
                    PROCNM = rows[0]["PROCNM"].ToString();
                    PROC_SEQ = rows[0]["PROC_SEQ"].ToString();
                }
            }

            this.grd01.SetValue(e.Row, this.grd01.Cols["PROCCD"].Index, PROCCD);
            this.grd01.SetValue(e.Row, this.grd01.Cols["PROCNM"].Index, PROCNM);
            this.grd01.SetValue(e.Row, this.grd01.Cols["PROC_SEQ"].Index, PROC_SEQ);
            
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdx01_ASSYNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        #endregion

    }
}
