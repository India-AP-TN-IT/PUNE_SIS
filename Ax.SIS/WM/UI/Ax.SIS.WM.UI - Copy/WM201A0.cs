using System;
using System.Data;
using System.ServiceModel;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using HE.Framework.Core.Report;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 통전 검사 항목 그룹
    /// </summary>
    public partial class WM201A0 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private AxComboList grd_LINECD;
        private AxComboList grd_VINCD;
        private AxComboList grd_PRDT_DIVCD;

        public WM201A0()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

            this.grd_LINECD = new AxComboList();
            this.grd_VINCD = new AxComboList();
            this.grd_PRDT_DIVCD = new AxComboList();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable CORCD = this.GetCorCD().Tables[0];
                DataTable BIZCD = this.GetBizCD(this.UserInfo.CorporationCode).Tables[0];
                this.cbo01_VINCD.DataBind("A3");

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("OBJECT_ID");
                dt1.Columns.Add("OBJECT_NM");

                DataRow row = dt1.NewRow();
                row["OBJECT_ID"] = "ASSY";
                row["OBJECT_NM"] = "ASSY";
                dt1.Rows.Add(row);

                row = dt1.NewRow();
                row["OBJECT_ID"] = "SUB";
                row["OBJECT_NM"] = "SUB";
                dt1.Rows.Add(row);

                row = dt1.NewRow();
                row["OBJECT_ID"] = "MATERIAL";
                row["OBJECT_NM"] = "MATERIAL";
                dt1.Rows.Add(row);

                //this.cbo01_PRDT_DIV.DataBind("A0");

                this.cbo01_PRDT_DIV.DisplayMember = "OBJECT_NM";
                this.cbo01_PRDT_DIV.ValueMember = "OBJECT_ID";
                this.cbo01_PRDT_DIV.DataSource = dt1;

                this.grd_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_LINECD_BeforeOpen);
                this.grd_VINCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_VINCD_BeforeOpen);
                this.grd_PRDT_DIVCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PRDT_DIVCD_BeforeOpen);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C,120, "팔레트 ID", "LODTBL_NO", "LODTBL_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 60, "적재수량", "LOAD_QTY", "LOAD_QTY");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "제품구분", "PRDT_DIV", "PRDT_DIV");
                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "시작일자", "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "종료일자", "END_DATE", "END_DATE");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, this.GetLabel("LODTBL_NM"), "LODTBL_NM", "LODTBL_NM");  //팔레트명칭

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, CORCD, "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, BIZCD, "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LOAD_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.grd01.Cols["BEG_DATE"].Format = "dd/MM/yyyy";
                this.grd01.Cols["END_DATE"].Format = "dd/MM/yyyy";

                this.grd01.Cols["LINECD"].Editor = this.grd_LINECD;
                this.grd01.Cols["VINCD"].Editor = this.grd_VINCD;
                this.grd01.Cols["PRDT_DIV"].Editor = this.grd_PRDT_DIVCD;
                this.grd01.Cols["CORCD"].AllowMerging = true;
                this.grd01.Cols["BIZCD"].AllowMerging = true;

                this.cbo01_CORCD.DataBind(CORCD);
                this.cbo01_BIZCD.DataBind(BIZCD);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetReadOnly(true);

                this.chk01_GRID_MERGE_CheckedChanged(null, null);

                txt01_ST_LODTBL_NO.Text = "";
                txt01_END_LODTBL_NO.Text = "";

                this.BtnQuery_Click(null, null);
        
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("VINCD", this.cbo01_VINCD.GetText());
                set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());

                if (!string.IsNullOrEmpty(txt01_ST_LODTBL_NO.Text) || !string.IsNullOrEmpty(txt01_END_LODTBL_NO.Text))
                {
                    set.Add("ST_LODTBL", txt01_ST_LODTBL_NO.Text);
                    set.Add("END_LODTBL", txt01_END_LODTBL_NO.Text);
                }

                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source;

                this.BeforeInvokeServer(true);

                if (!string.IsNullOrEmpty(txt01_ST_LODTBL_NO.Text) || !string.IsNullOrEmpty(txt01_END_LODTBL_NO.Text))
                {
                    source = _WSCOM.ExecuteDataSet("APG_WM201A0.INQUERY_RANGE", set, "OUT_CURSOR");
                }
                else
                {
                    source = _WSCOM.ExecuteDataSet("APG_WM201A0.INQUERY", set, "OUT_CURSOR");
                }

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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "LODTBL_NO", "LOAD_QTY", "LINECD", "VINCD", "PRDT_DIV", "BEG_DATE", "END_DATE", "LODTBL_NM", "EMPNO", "LANG_SET");
                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["LANG_SET"] = this.UserInfo.Language;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                                
                _WSCOM.ExecuteNonQueryTx("APG_WM201A0.DATA_SAVE", source);

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
                    "CORCD", "BIZCD", "LODTBL_NO", "LANG_SET");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["LANG_SET"] = this.UserInfo.Language;
                }

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                
                _WSCOM.ExecuteNonQueryTx("APG_WM201A0.DATA_REMOVE", source);

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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("VINCD", this.cbo01_VINCD.GetText());
                set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetText());

                if (!string.IsNullOrEmpty(txt01_ST_LODTBL_NO.Text) || !string.IsNullOrEmpty(txt01_END_LODTBL_NO.Text))
                {
                    set.Add("ST_LODTBL", txt01_ST_LODTBL_NO.Text);
                    set.Add("END_LODTBL", txt01_END_LODTBL_NO.Text);
                }

                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet rptsource;

                this.BeforeInvokeServer(true);

                if (!string.IsNullOrEmpty(txt01_ST_LODTBL_NO.Text) || !string.IsNullOrEmpty(txt01_END_LODTBL_NO.Text))
                {
                    rptsource = _WSCOM.ExecuteDataSet("APG_WM201A0.INQUERY_RANGE", set, "OUT_CURSOR");
                }
                else
                {
                    rptsource = _WSCOM.ExecuteDataSet("APG_WM201A0.INQUERY", set, "OUT_CURSOR");
                }

                this.AfterInvokeServer();

                c1Report1.DataSource.Recordset = rptsource.Tables[0];

                if (c1Report1.IsBusy) return;

                c1PrintPreviewDialog1.Text = c1Report1.ReportName;
                c1PrintPreviewDialog1.PrintPreviewControl.Document = c1Report1;
                c1PrintPreviewDialog1.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                c1PrintPreviewDialog1.ShowDialog();
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

        #region [컨트롤 이벤트]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "BIZCD", this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(i, "LODTBL_NO", " ");
                    this.grd01.SetValue(i, "VINCD", this.cbo01_VINCD.GetText());
                    this.grd01.SetValue(i, "PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());//  .GetText());
                    this.grd01.SetValue(i, "BEG_DATE", DateTime.Now.ToShortDateString());
                    this.grd01.SetValue(i, "END_DATE", DateTime.Parse("9998-12-31").ToShortDateString());
                }
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
                
                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_LINE_LIST", set, "OUT_CURSOR").Tables[0];

                this.grd_LINECD.DataBind(source, "LINECD", "LINECD", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_VINCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);

                //set.Add("COLUMN_ID", "VINCD");
                //set.Add("LANG_SET", this.UserInfo.Language);

                //DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_TYPE_CODE", set, "OUT_CURSOR").Tables[0];
                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_CAR_TYPE", set, "OUT_CURSOR").Tables[0];

                this.grd_VINCD.DataBind(source, "OBJECT_NM", "TYPECD", this.GetLabel("VINNM") + ";" + this.GetLabel("VINCD"), "L;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PRDT_DIVCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("COLUMN_ID", "PRDT_DIV");
                set.Add("LANG_SET", "EN");

                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_TYPE_CODE", set, "OUT_CURSOR").Tables[0];

                this.grd_PRDT_DIVCD.DataBind(source, "TYPECD", "OBJECT_NM", this.GetLabel("PRDT_DIV") + ";" + this.GetLabel("PRDT_DIVNM"), "C;L");
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
                    //MsgBox.Show("저장할 완제품 팔레트 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string VINCD = this.grd01.GetValue(i, "VINCD").ToString();

                    if (this.GetByteCount(VINCD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {팔레트 ID} 가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[5].Caption.ToString());
                        return false;
                    }

                    string PRDT_DIV = this.grd01.GetValue(i, "PRDT_DIV").ToString();

                    if (this.GetByteCount(PRDT_DIV) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {팔레트 ID} 가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[6].Caption.ToString());
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

    
        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.chk01_GRID_MERGE.Checked)
                    this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                else
                    this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void _buttonsControl_Load(object sender, EventArgs e)
        {

        }
    }
}
