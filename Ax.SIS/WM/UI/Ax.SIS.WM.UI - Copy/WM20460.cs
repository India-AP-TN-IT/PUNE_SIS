using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using System.Diagnostics;
using C1.Win.C1FlexGrid;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class WM20460 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public WM20460()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                #region [그리드1]
                
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "Plant", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "Vehicle Code", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Part Group Code", "PGN", "PGN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 220, "Part Group Description", "PGNDESC", "PGNDESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "Part Group Short Name", "PGNDESC_SHORT", "PGNDESC_SHORT");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Part Code", "PARTGROUP", "PARTGROUP");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "D/TYPE", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "BOX TYPE", "BOX_TYPE", "BOX_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "BOX QTY", "LOAD_QTY", "LOAD_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "Force Inv", "FORCE_INV_CHK", "FORCE_INV_CHK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "C/Station", "CUST_STATION", "CUST_STATION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 270, "Vendor Name", "VENDNM", "VENDNM");

                DataTable combo_source_DELI_TYPE = new DataTable();
                combo_source_DELI_TYPE.Columns.Add("CODE");
                combo_source_DELI_TYPE.Columns.Add("NAME");
                combo_source_DELI_TYPE.Rows.Add("JIT", "JIT");
                combo_source_DELI_TYPE.Rows.Add("JIS", "JIS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_DELI_TYPE, "DELI_TYPE");

                DataTable combo_source_BOX_TYPE = new DataTable();
                combo_source_BOX_TYPE.Columns.Add("CODE");
                combo_source_BOX_TYPE.Columns.Add("NAME");
                combo_source_BOX_TYPE.Rows.Add("BIN", "BIN");
                combo_source_BOX_TYPE.Rows.Add("TROLLEY", "TROLLEY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_BOX_TYPE, "BOX_TYPE");

                DataTable combo_source_SLOT_YN = new DataTable();
                combo_source_SLOT_YN.Columns.Add("CODE");
                combo_source_SLOT_YN.Columns.Add("NAME");
                combo_source_SLOT_YN.Rows.Add("Y", "YES");
                combo_source_SLOT_YN.Rows.Add("N", "NO");
                this.grd01.SetColumnType_Original(AxFlexGrid.FCellType.ComboBox, combo_source_SLOT_YN, "FORCE_INV_CHK", false);


                DataTable combo_source_PLANT = new DataTable();
                combo_source_PLANT.Columns.Add("CODE");
                combo_source_PLANT.Columns.Add("NAME");
                combo_source_PLANT.Rows.Add("KVF1", "KVF1");
                combo_source_PLANT.Rows.Add("KVF2", "KVF2");

                this.cbo01_PLANT.DataBind(combo_source_PLANT, true);
                this.cbo01_PLANT.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_VINCD.DataBind("A3", true);
                #endregion
                
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
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PGN", this.axTextBox1.GetValue());
                set.Add("PGNDESC", this.txt01_PGNDESC.GetValue());
                set.Add("VINCD", this.cbo01_VINCD.GetValue());
                set.Add("PLANT", this.cbo01_PLANT.GetValue());

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("APG_WM20460.INQUERY_PGN", set, "OUT_CURSOR");

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
                DataSet sourceIU = null;
                DataSet sourceD = null;

                sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"
                                                              , "PGN"
                                                              , "PGNDESC"
                                                              , "PGNDESC_SHORT"
                                                              , "PARTGROUP"
                                                              , "DELI_TYPE"
                                                              , "BOX_TYPE"
                                                              , "LOAD_QTY"
                                                              , "CUST_STATION"
                                                              , "VENDCD"
                                                              , "FORCE_INV_CHK"
                                                              , "CUST_PLANT"
                                                              , "VINCD"
                                                            );
                
                sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove
                                                      , "CORCD"
                                                      , "BIZCD"
                                                      , "PGN"
                                                      , "VINCD"
                                                      , "CUST_PLANT"
                                                   );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["PGN"] = Convert.ToString(rows["PGN"]).ToUpper();
                        rows["CORCD"] = UserInfo.CorporationCode;
                        rows["BIZCD"] = UserInfo.BusinessCode;
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20460.DATA_SAVE_PGN", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {
                    if (!IsDeleteValid(sourceD)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20460.DATA_REMOVE_PGN", sourceD);

                    this.AfterInvokeServer();
                }

                this.BtnQuery_Click(null, null);

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
        #endregion

        #region [컨트롤 이벤트]
        private void grd_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;

                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    grd.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    grd.SetValue(i, "BIZCD", this.UserInfo.BusinessCode);
                }
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
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                



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
                    //저장할 데이터가 존재하지 않습니다..
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }


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

        private void txt01_Query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnQuery_Click(null, null);
            }
        }

    }
}
