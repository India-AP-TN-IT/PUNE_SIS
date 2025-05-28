using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 공정별 작업표준서
    /// </summary>
    public partial class WM20540 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public WM20540()
        {

            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 026, "선택", "CHK", "CHK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "Corp code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "Biz code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Rack Location", "RACK_LOC_NO", "RACK_LOC_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 085, "Rack group", "RACK_GRP", "RACK_GRP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 085, "Rack Position", "RACK_POS", "RACK_POS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "VINCD", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "Car", "VINNM", "VINNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "ITEMCD", "ITEMCD", "ITEMCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Item", "ITEMNM", "ITEMNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Rack Cell", "RACK_CELL", "RACK_CELL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "Part number", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 400, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 180, "CELL_QTY", "CELL_QTY", "CELL_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CELL_QTY");

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;

                #region partno popup
                this.cdx01_PARTNO.HEPopupHelper = new WM20540P1();
                this.cdx01_PARTNO.PopupTitle = "Part No";
                this.cdx01_PARTNO.CodeParameterName = "PARTNO";
                this.cdx01_PARTNO.NameParameterName = "PARTNM";
                this.cdx01_PARTNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_PARTNO.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_PARTNO.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                #endregion


                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                set1.Add("PRDT_DIV", "A0A");
                set1.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_CAR_TYPE", set1).Tables[0];
                this.cbl01_VINCD.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");  //차종코드;차종명
                this.cbl02_VINCD.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");  //차종코드;차종명

                //품목코드
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);

                source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_ITEM_LIST", set).Tables[0];

                this.cbl01_ITEMCD.DataBind(source, "TYPECD", "OBJECT_NM", this.GetLabel("ITEMCD") + ";" + this.GetLabel("ITEMNM"), "C;L"); //품목코드;품목명

                this.SetRequired(lbl02_RACK_GRP, lbl02_RACK_POS, lbl02_RACK_CELL_QTY, lbl02_VINCD, lbl01_ITEMCD);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
         
        #region [공통버튼]

        protected override void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.cbl01_VINCD.Initialize();
                this.cbl02_VINCD.Initialize();
                this.cbl01_ITEMCD.Initialize();
                this.txt01_RACK_GRP.Initialize();
                this.txt01_RACK_LOCNO.Initialize();
                this.txt01_RACK_POS.Initialize();
                this.txt02_RACK_GRP.Initialize();
                this.txt02_RACK_POS.Initialize();
                this.txt02_RACK_CELL_QTY.Initialize();
                //this.cbl02_VINCD.SetReadOnly(false);
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
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("RACK_LOCNO",txt01_RACK_LOCNO.Text.Trim());
                set.Add("RACK_GRP", txt01_RACK_GRP.Text.Trim());
                set.Add("RACK_POS", txt01_RACK_POS.Text.Trim());
                set.Add("RACK_CELL", "");
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet ds = new DataSet();
                ds.Tables.Add(_WSCOM.ExecuteDataSet("APG_WM20540.INQUIRY_RACK", set, "OUT_CURSOR").Tables[0].Copy());
                grd01.DataSource = ds.Tables[0];

                this.AfterInvokeServer();

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
                // get grid data
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                    "CHK", "CORCD", "BIZCD", "RACK_LOC_NO", "PARTNO", "USER_ID");

                // remove not checked row
                for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
                {
                    if (set.Tables[0].Rows[i]["CHK"].ToString().Equals("N"))
                        set.Tables[0].Rows.RemoveAt(i);
                }

                // remove check box column
                set.Tables[0].Columns.Remove("CHK");

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20540.SAVE_DETAIL", set);  //MES8030.INV_STATUS to 'X'

                this.AfterInvokeServer();

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
                // get grid data
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CHK", "CORCD", "BIZCD", "RACK_GRP", "RACK_POS", "RACK_CELL");

                // remove not checked row
                for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
                {
                    if (set.Tables[0].Rows[i]["CHK"].ToString().Equals("N"))
                        set.Tables[0].Rows.RemoveAt(i);
                }

                if (set.Tables[0].Rows.Count == 0) 
                    return;

                if (!IsDeleteValid()) 
                    return;

                // remove check box column
                set.Tables[0].Columns.Remove("CHK");

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20540.DELETE_RACK", set);  //MES8030.INV_STATUS to 'X'

                this.AfterInvokeServer();

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

        #endregion

        #region [컨트롤 이벤트]

        private void btn02_REG_Click(object sender, EventArgs e)
        {
            FileStream oFile = null;
            try
            {
                if (!IsSaveValid()) return;

                int iRow = 0;

                for (int i = grd01.Rows.Fixed; i < grd01.Rows.Count; i++)
                {
                    if (grd01.GetData(i, grd01.Cols["RACK_GRP"].Index).Equals(txt02_RACK_GRP.Text) == true &&
                       grd01.GetData(i, grd01.Cols["RACK_POS"].Index).Equals(txt02_RACK_POS.Text) == true && 
                       grd01.GetData(i, grd01.Cols["RACK_CELL"].Index).Equals(txt02_RACK_CELL_QTY.Text) == true )
                    {
                        iRow = i;
                        break;
                    }
                }

                C1.Win.C1FlexGrid.Row row;

                if (iRow == 0)
                {
                    row = grd01.Rows.Add();
                }
                else
                {
                    row = grd01.Rows[iRow];
                }
                row[grd01.Cols["RACK_LOC_NO"].Index] = txt02_RACK_GRP.Text + "-" + txt02_RACK_POS.Text + "-" + txt02_RACK_CELL_QTY.Text;
                row[grd01.Cols["RACK_GRP"].Index] = txt02_RACK_GRP.Text;
                row[grd01.Cols["RACK_POS"].Index] = txt02_RACK_POS.Text;
                row[grd01.Cols["RACK_CELL"].Index] = txt02_RACK_CELL_QTY.Text;

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


        #endregion

        #region [사용자 정의 메서드]


        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string RACK_GRP = this.txt02_RACK_GRP.GetValue().ToString();
                string RACK_POS = this.txt02_RACK_POS.GetValue().ToString();
                string RACK_CELL = this.txt02_RACK_CELL_QTY.GetValue().ToString();
                string PARTNO = this.cbl02_VINCD.GetValue().ToString();


                //if (this.GetByteCount(PARTNO) == 0)
                //{
                //    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("PARTNO"));
                //    return false;
                //}

                if (this.GetByteCount(RACK_GRP) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("RACK_GRP"));
                    return false;
                }

                if (this.GetByteCount(RACK_POS) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("RACK_POS"));
                    return false;
                }

                if (this.GetByteCount(RACK_CELL) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("RACK_CELL"));
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveValid2()
        {
            try
            {
                string RACK_GRP = this.txt02_RACK_GRP.GetValue().ToString();
                string RACK_POS = this.txt02_RACK_POS.GetValue().ToString();
                string RACK_ITEMCD = this.cbl01_ITEMCD.GetValue().ToString();
                string RACK_CELL_QTY = this.txt02_RACK_CELL_QTY.GetValue().ToString();
                string VINCD = this.cbl02_VINCD.GetValue().ToString();

                if (this.GetByteCount(VINCD) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("VINCD"));
                    return false;
                }

                if (this.GetByteCount(RACK_GRP) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("RACK_GRP"));
                    return false;
                }

                if (this.GetByteCount(RACK_POS) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("RACK_POS"));
                    return false;
                }

                if (this.GetByteCount(RACK_CELL_QTY) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("RACK_CELL_QTY"));
                    return false;
                }

                if (this.GetByteCount(RACK_ITEMCD) == 0)
                {
                    MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("ITEMCD"));
                    return false;
                }

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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int tmpCol = this.grd01.Col;
                int tmpRow = this.grd01.SelectedRowIndex;

                // select just 1cell and it's empty cell
                if (this.grd01.Row > 0
                    && this.grd01.Selection.TopRow == this.grd01.Selection.BottomRow
                    && this.grd01.Selection.LeftCol == this.grd01.Selection.RightCol)
                {
                    if (this.grd01.Cols[this.grd01.Col].Name == "PARTNO")
                    {
                        this.grd01.Select(0, 0);

                        this.cdx01_PARTNO.HEUserParameterSetValue("APP_DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                        this.cdx01_PARTNO.HEUserParameterSetValue("VINCD", this.grd01[tmpRow, "VINCD"]);
                        this.cdx01_PARTNO.HEUserParameterSetValue("ITEMCD", this.grd01[tmpRow, "ITEMCD"]);
                        this.cdx01_PARTNO.HEPopupHelper.Initialize_Helper(this.cdx01_PARTNO);
                        PopupHelper helper = new PopupHelper((AxCommonPopupControl)this.cdx01_PARTNO.HEPopupHelper, this.cdx01_PARTNO.PopupTitle);
                        helper.ShowDialog();
                        object data = helper.SelectedValue;
                        if (data != null)
                        {
                            // get code, name selection
                            DataRow selectedPopupValue = (DataRow)data;
                            this.grd01.SetValue(tmpRow, "PARTNO", selectedPopupValue[this.cdx01_PARTNO.CodeParameterName]);
                            this.grd01.SetValue(tmpRow, "PARTNM", selectedPopupValue[this.cdx01_PARTNO.NameParameterName]);

                            this.grd01.SetValue(tmpRow, this.grd01.Cols["CHK"].Index, "true");
                        }
                    }
                    else
                    {
                        this.txt02_RACK_GRP.Text = this.grd01.GetData(tmpRow, "RACK_GRP").ToString();
                        this.txt02_RACK_POS.Text = this.grd01.GetData(tmpRow, "RACK_POS").ToString();
                        this.txt02_RACK_CELL_QTY.Text = this.grd01.GetData(tmpRow, "CELL_QTY").ToString();
                        this.cbl02_VINCD.SelectedValue = this.grd01.GetData(tmpRow, "VINCD").ToString();
                        this.cbl01_ITEMCD.SelectedValue = this.grd01.GetData(tmpRow, "ITEMCD").ToString();
                    }
                }
                else if (this.grd01.Row > 0)
                {
                    txt02_RACK_GRP.Text = this.grd01[tmpRow, "RACK_GRP"].ToString();
                    txt02_RACK_POS.Text = this.grd01[tmpRow, "RACK_POS"].ToString();
                    txt02_RACK_CELL_QTY.Text = this.grd01[tmpRow, "CELL_QTY"].ToString();
                    //cbl02_VINCD.Text = this.grd01[tmpRow, "VINCD"].ToString().Replace("A7", "");
                    cbl02_VINCD.SetValue(this.grd01[tmpRow, "VINCD"]);
                    //cbl01_ITEMCD.Text = this.grd01[tmpRow, "ITEMCD"].ToString();
                    cbl01_ITEMCD.SetValue(this.grd01[tmpRow, "ITEMCD"]);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_APPLY_Click(object sender, EventArgs e)
        {
            string bizcd = this.UserInfo.BusinessCode;
            if (!this.IsSaveValid2()) return;

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.UserInfo.BusinessCode);
            set.Add("RACK_GRP", this.txt02_RACK_GRP.GetValue());
            set.Add("RACK_POS", this.txt02_RACK_POS.GetValue());
            set.Add("VINCD", this.cbl02_VINCD.GetValue());
            set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue());
            set.Add("CELL_QTY", this.txt02_RACK_CELL_QTY.GetValue());
            set.Add("USER_ID", this.UserInfo.EmpNo);

            this.BeforeInvokeServer(true);
            _WSCOM.ExecuteNonQueryTx("APG_WM20540.SAVE_GROUP", set);

            this.AfterInvokeServer();

            this.BtnQuery_Click(null, null);

            //저장되었습니다.
            MsgCodeBox.Show("CD00-0071");
        }

        private void cbl02_VINCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                set1.Add("PRDT_DIV", "A0A");
                set1.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_CAR_TYPE", set1).Tables[0];
                this.cbl02_VINCD.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");  //차종코드;차종명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_ITEMCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_ITEM_LIST", set).Tables[0];

                this.cbl01_ITEMCD.DataBind(source, "TYPECD", "OBJECT_NM", this.GetLabel("ITEMCD") + ";" + this.GetLabel("ITEMNM"), "C;L"); //품목코드;품목명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_DELETE_Click(object sender, EventArgs e)
        {
            string bizcd = this.UserInfo.BusinessCode;
            if (!this.IsSaveValid2()) return;

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.UserInfo.BusinessCode);
            set.Add("RACK_GRP", this.txt02_RACK_GRP.GetValue());
            set.Add("RACK_POS", this.txt02_RACK_POS.GetValue());
             
            if (!this.IsDeleteValid())
            {
                return;
            }

            this.BeforeInvokeServer(true);
            _WSCOM.ExecuteNonQueryTx("APG_WM20540.DELETE_GROUP", set);

            this.AfterInvokeServer();

            this.BtnQuery_Click(null, null);

            //저장되었습니다.
            MsgCodeBox.Show("CD00-0071");
        }
        
    }
}
